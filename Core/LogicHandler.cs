using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TapCaps.UI;

namespace TapCaps.Core
{
    /// <summary>
    /// CapsLock logic handler: macOS-style short/long press behavior.
    /// Short press: switch IME (or turn off CapsLock if already on).
    /// Long press: turn on CapsLock.
    /// </summary>
    public class LogicHandler
    {
        #region Fields

        private readonly System.Timers.Timer _longPressTimer;
        private bool _isCapsLockDown;
        private bool _longPressTriggered;
        private int _longPressThresholdMs = AppConfig.LongPressThresholdMs;
        private readonly HashSet<Keys> _pressedKeys = new HashSet<Keys>();
        private readonly HashSet<Keys> _swallowedMappingKeys = new HashSet<Keys>();
        private readonly List<CompiledKeyMapping> _compiledMappings = new List<CompiledKeyMapping>();
        private List<KeyMappingRule> _rawMappings = new List<KeyMappingRule>();

        private bool lastModeCN = true;

        #endregion

        #region Ctor

        public LogicHandler()
        {
            _longPressTimer = new System.Timers.Timer
            {
                Interval = _longPressThresholdMs,
                AutoReset = false
            };
            _longPressTimer.Elapsed += LongPressTimer_Elapsed;

            KeyboardHook.ShouldSuppressKeyDown += Hook_ShouldSuppressKeyDown;
            KeyboardHook.ShouldSuppressKeyUp += Hook_ShouldSuppressKeyUp;
        }

        #endregion

        #region Public props

        /// <summary>
        /// Enable macOS-style CapsLock behavior.
        /// </summary>
        public bool EnableMacCapsLock { get; set; } = true;

        /// <summary>
        /// Enable custom key mapping.
        /// </summary>
        public bool EnableKeyMapping { get; set; } = false;

        /// <summary>
        /// Enable HUD popups.
        /// </summary>
        public bool EnableHud { get; set; } = true;

        /// <summary>
        /// Long press threshold in milliseconds.
        /// </summary>
        public int LongPressThresholdMs
        {
            get => _longPressThresholdMs;
            set
            {
                // clamp to sane range
                int clamped = Math.Max(50, Math.Min(2000, value));
                _longPressThresholdMs = clamped;
                _longPressTimer.Interval = clamped;
            }
        }

        #endregion

        #region Event handlers

        private bool Hook_ShouldSuppressKeyDown(Keys key)
        {
            // Hide HUD when other keys are pressed.
            if (key != Keys.Capital && EnableHud)
            {
                StateHUD.HideState();
            }

            if (key == Keys.Capital && EnableMacCapsLock)
            {
                if (!_isCapsLockDown)
                {
                    _isCapsLockDown = true;
                    _longPressTriggered = false;

                    _longPressTimer.Stop();
                    _longPressTimer.Interval = _longPressThresholdMs;
                    _longPressTimer.Start();
                }

                // Swallow system default handling.
                return true;
            }

            bool swallowedByMapping = EnableKeyMapping && HandleKeyMapping(key, true);
            TrackKeyState(key, true);
            return swallowedByMapping;
        }

        private bool Hook_ShouldSuppressKeyUp(Keys key)
        {
            if (key == Keys.Capital && EnableMacCapsLock)
            {
                _isCapsLockDown = false;
                _longPressTimer.Stop();

                if (!_longPressTriggered)
                {
                    HandleShortPress();
                }

                // Swallow system default handling.
                return true;
            }

            bool swallowedByMapping = EnableKeyMapping && HandleKeyMapping(key, false);
            TrackKeyState(key, false);
            return swallowedByMapping;
        }

        #endregion

        #region Private methods

        private void HandleShortPress()
        {
            bool isCapOn = InputSimulator.IsCapsLockOn();
            if (isCapOn)
            {
                InputSimulator.EnsureCapsLock(false);
                if (lastModeCN)
                {
                    StateHUD.ShowState("中", "中文");
                }
                else
                {
                    StateHUD.ShowState("英", "英文");
                }
            }
            else
            {
                InputSimulator.SendCtrlSpace();
                ShowInputModeHUD();
            }
        }

        private void HandleLongPress()
        {
            InputSimulator.EnsureCapsLock(true);
            if (EnableHud)
            {
                StateHUD.ShowState("⇪", "Caps Lock");
            }
        }

        private void ShowInputModeHUD()
        {
            if (!EnableHud) return;
            if (InputSimulator.IsEnglishInputMode())
            {
                lastModeCN = false;
                StateHUD.ShowState("英", "英文");
            }
            else
            {
                lastModeCN = true;
                StateHUD.ShowState("中", "中文");
            }
        }

        private void LongPressTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _longPressTriggered = true;
            HandleLongPress();
        }

        private bool HandleKeyMapping(Keys key, bool isKeyDown)
        {
            if (_compiledMappings.Count == 0) return false;

            if (isKeyDown)
            {
                if (_swallowedMappingKeys.Contains(key))
                {
                    return true;
                }

                var modifiers = GetModifierState(key, true);
                var stroke = KeyStroke.FromKeyEvent(key, modifiers);
                var match = _compiledMappings.FirstOrDefault(m => m.Source.Equals(stroke));
                if (match != null && match.Target != null)
                {
                    InputSimulator.SendKeyStroke(match.Target);
                    _swallowedMappingKeys.Add(key);
                    return true;
                }
            }
            else
            {
                if (_swallowedMappingKeys.Contains(key))
                {
                    _swallowedMappingKeys.Remove(key);
                    return true;
                }
            }

            return false;
        }

        private ModifierState GetModifierState(Keys currentKey, bool isKeyDown)
        {
            bool ctrl = IsAnyCtrlDown();
            bool shift = IsAnyShiftDown();
            bool alt = IsAnyAltDown();
            bool win = IsAnyWinDown();

            if (isKeyDown)
            {
                if (IsCtrlKey(currentKey)) ctrl = true;
                if (IsShiftKey(currentKey)) shift = true;
                if (IsAltKey(currentKey)) alt = true;
                if (IsWinKey(currentKey)) win = true;
            }

            return new ModifierState
            {
                Ctrl = ctrl,
                Shift = shift,
                Alt = alt,
                Win = win
            };
        }

        private bool IsAnyCtrlDown()
        {
            return _pressedKeys.Contains(Keys.ControlKey) ||
                   _pressedKeys.Contains(Keys.LControlKey) ||
                   _pressedKeys.Contains(Keys.RControlKey);
        }

        private bool IsAnyShiftDown()
        {
            return _pressedKeys.Contains(Keys.ShiftKey) ||
                   _pressedKeys.Contains(Keys.LShiftKey) ||
                   _pressedKeys.Contains(Keys.RShiftKey);
        }

        private bool IsAnyAltDown()
        {
            return _pressedKeys.Contains(Keys.Menu) ||
                   _pressedKeys.Contains(Keys.Alt) ||
                   _pressedKeys.Contains(Keys.LMenu) ||
                   _pressedKeys.Contains(Keys.RMenu);
        }

        private bool IsAnyWinDown()
        {
            return _pressedKeys.Contains(Keys.LWin) ||
                   _pressedKeys.Contains(Keys.RWin);
        }

        private static bool IsCtrlKey(Keys key)
        {
            return key == Keys.ControlKey || key == Keys.LControlKey || key == Keys.RControlKey || key == Keys.Control;
        }

        private static bool IsShiftKey(Keys key)
        {
            return key == Keys.ShiftKey || key == Keys.LShiftKey || key == Keys.RShiftKey || key == Keys.Shift;
        }

        private static bool IsAltKey(Keys key)
        {
            return key == Keys.Menu || key == Keys.LMenu || key == Keys.RMenu || key == Keys.Alt;
        }

        private static bool IsWinKey(Keys key)
        {
            return key == Keys.LWin || key == Keys.RWin;
        }

        private void TrackKeyState(Keys key, bool isDown)
        {
            if (isDown)
            {
                _pressedKeys.Add(key);
            }
            else
            {
                _pressedKeys.Remove(key);
            }
        }

        public IReadOnlyList<KeyMappingRule> GetKeyMappings()
        {
            return _rawMappings.ToList();
        }

        public void SetKeyMappings(IEnumerable<KeyMappingRule> rules)
        {
            _compiledMappings.Clear();
            _rawMappings = new List<KeyMappingRule>();
            _swallowedMappingKeys.Clear();

            if (rules == null) return;

            foreach (var rule in rules)
            {
                if (rule == null) continue;
                if (!KeyStroke.TryParse(rule.Source, out var source)) continue;
                if (!KeyStroke.TryParse(rule.Target, out var target)) continue;

                _compiledMappings.Add(new CompiledKeyMapping
                {
                    Source = source,
                    Target = target
                });

                _rawMappings.Add(new KeyMappingRule
                {
                    Source = source.ToDisplayString(),
                    Target = target.ToDisplayString()
                });
            }
        }

        #endregion

        private class CompiledKeyMapping
        {
            public KeyStroke Source { get; set; }
            public KeyStroke Target { get; set; }
        }
    }
}
