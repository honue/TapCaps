using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace TapCaps.Core
{
    [DataContract]
    public class KeyMappingRule
    {
        [DataMember] public string Source { get; set; }
        [DataMember] public string Target { get; set; }
    }

    public struct ModifierState
    {
        public bool Ctrl;
        public bool Shift;
        public bool Alt;
        public bool Win;
    }

    public class KeyStroke : IEquatable<KeyStroke>
    {
        public Keys Key { get; }
        public bool Ctrl { get; }
        public bool Shift { get; }
        public bool Alt { get; }
        public bool Win { get; }

        public KeyStroke(Keys key, bool ctrl, bool shift, bool alt, bool win)
        {
            Key = NormalizeKeyCode(key);
            Ctrl = ctrl;
            Shift = shift;
            Alt = alt;
            Win = win;
        }

        public static KeyStroke FromKeyEvent(Keys key, ModifierState modifiers)
        {
            return new KeyStroke(NormalizeKeyCode(key), modifiers.Ctrl, modifiers.Shift, modifiers.Alt, modifiers.Win);
        }

        public static bool TryParse(string text, out KeyStroke stroke)
        {
            stroke = null;
            if (string.IsNullOrWhiteSpace(text)) return false;

            var converter = new KeysConverter();
            bool ctrl = false, shift = false, alt = false, win = false;
            Keys key = Keys.None;

            var normalized = text.Replace(" ", string.Empty);
            var parts = normalized.Split(new[] { '+', '-' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var rawPart in parts)
            {
                var part = rawPart.Trim();
                if (part.Length == 0) continue;

                switch (part.ToLowerInvariant())
                {
                    case "ctrl":
                    case "control":
                        ctrl = true;
                        continue;
                    case "shift":
                        shift = true;
                        continue;
                    case "alt":
                        alt = true;
                        continue;
                    case "win":
                    case "windows":
                    case "lwin":
                    case "rwin":
                        win = true;
                        continue;
                }

                try
                {
                    var parsed = (Keys)converter.ConvertFromInvariantString(part);
                    key = NormalizeKeyCode(parsed);
                }
                catch
                {
                    return false;
                }
            }

            if (key == Keys.None) return false;

            stroke = new KeyStroke(key, ctrl, shift, alt, win);
            return true;
        }

        public Keys ToKeys()
        {
            Keys result = Key;
            if (Ctrl) result |= Keys.Control;
            if (Shift) result |= Keys.Shift;
            if (Alt) result |= Keys.Alt;
            if (Win) result |= Keys.LWin;
            return result;
        }

        public string ToDisplayString()
        {
            var parts = new List<string>();
            if (Ctrl) parts.Add("Ctrl");
            if (Shift) parts.Add("Shift");
            if (Alt) parts.Add("Alt");
            if (Win) parts.Add("Win");
            parts.Add(Key.ToString());
            return string.Join("+", parts);
        }

        public bool Equals(KeyStroke other)
        {
            if (other == null) return false;
            return Key == other.Key &&
                   Ctrl == other.Ctrl &&
                   Shift == other.Shift &&
                   Alt == other.Alt &&
                   Win == other.Win;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as KeyStroke);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Key.GetHashCode();
                hash = hash * 23 + Ctrl.GetHashCode();
                hash = hash * 23 + Shift.GetHashCode();
                hash = hash * 23 + Alt.GetHashCode();
                hash = hash * 23 + Win.GetHashCode();
                return hash;
            }
        }

        private static Keys NormalizeKeyCode(Keys key)
        {
            var code = key & Keys.KeyCode;
            switch (code)
            {
                case Keys.Control:
                    return Keys.ControlKey;
                case Keys.Shift:
                    return Keys.ShiftKey;
                case Keys.Alt:
                case Keys.Menu:
                    return Keys.Menu;
                case Keys.LWin:
                case Keys.RWin:
                    return Keys.LWin;
                default:
                    return code;
            }
        }
    }
}
