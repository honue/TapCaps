using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TapCaps.Core
{
    /// <summary>
    /// 短按 CapsLock 时用来切换输入法的组合键方案。
    /// </summary>
    public enum ImeSwitchHotkey
    {
        /// <summary>Ctrl+Space：切换当前输入法的中/英文模式。</summary>
        CtrlSpace = 0,

        /// <summary>Win+Space：切换输入语言（Windows 自带的输入法切换快捷键）。</summary>
        WinSpace = 1
    }

    /// <summary>
    /// Input simulator: keyboard helpers and IME state checks.
    /// </summary>
    public static class InputSimulator
    {
        #region Windows API constants

        private const uint KEYEVENTF_EXTENDEDKEY = 0x0001;
        private const uint KEYEVENTF_KEYUP = 0x0002;
        private const byte VK_CAPITAL = 0x14;
        private const byte VK_CONTROL = 0x11;
        private const byte VK_MENU = 0x12;
        private const byte VK_SPACE = 0x20;
        private const byte VK_SHIFT = 0x10;
        private const byte VK_LWIN = 0x5B;

        private const int IME_CMODE_NATIVE = 0x0001;
        private const int WM_IME_CONTROL = 0x0283;
        private const int IMC_GETCONVERSIONMODE = 0x0001;

        // 主语言 ID（PRIMARYLANGID）：这些语言由输入法接管，其余按纯键盘布局处理
        private const int LANG_CHINESE = 0x04;
        private const int LANG_JAPANESE = 0x11;
        private const int LANG_KOREAN = 0x12;

        // 等待输入法状态切换时的轮询间隔
        private const int InputModeSettlePollIntervalMs = 10;

        #endregion

        #region Windows API imports

        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        [DllImport("user32.dll")]
        private static extern short GetKeyState(int nVirtKey);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("user32.dll")]
        private static extern IntPtr GetKeyboardLayout(uint idThread);

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        [DllImport("imm32.dll")]
        private static extern IntPtr ImmGetDefaultIMEWnd(IntPtr hWnd);

        #endregion

        #region Public methods

        /// <summary>
        /// Check whether CapsLock is on.
        /// </summary>
        public static bool IsCapsLockOn()
        {
            return (GetKeyState(VK_CAPITAL) & 1) != 0;
        }

        /// <summary>
        /// Ensure CapsLock matches the expected state.
        /// </summary>
        public static void EnsureCapsLock(bool shouldBeOn)
        {
            bool isOn = IsCapsLockOn();
            if (isOn != shouldBeOn)
            {
                keybd_event(VK_CAPITAL, 0x45, KEYEVENTF_EXTENDEDKEY, (UIntPtr)AppConfig.KeyboardHookSignature);
                keybd_event(VK_CAPITAL, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, (UIntPtr)AppConfig.KeyboardHookSignature);
            }
        }

        /// <summary>
        /// Send Ctrl+Space to toggle IME.
        /// </summary>
        public static void SendCtrlSpace()
        {
            var signature = (UIntPtr)AppConfig.KeyboardHookSignature;

            keybd_event(VK_CONTROL, 0, KEYEVENTF_EXTENDEDKEY, signature);
            keybd_event(VK_SPACE, 0, KEYEVENTF_EXTENDEDKEY, signature);
            keybd_event(VK_SPACE, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, signature);
            keybd_event(VK_CONTROL, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, signature);
        }

        /// <summary>
        /// Send Win+Space to switch input language / IME (Windows built-in shortcut).
        /// </summary>
        public static void SendWinSpace()
        {
            var signature = (UIntPtr)AppConfig.KeyboardHookSignature;

            keybd_event(VK_LWIN, 0, KEYEVENTF_EXTENDEDKEY, signature);
            keybd_event(VK_SPACE, 0, KEYEVENTF_EXTENDEDKEY, signature);
            keybd_event(VK_SPACE, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, signature);
            keybd_event(VK_LWIN, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, signature);
        }

        /// <summary>
        /// Detect whether the current input mode is English (i.e. typing Latin characters).
        ///
        /// 两种切换方式的信号不同，必须分开判断：
        ///   - Win+Space 换的是键盘布局本身，布局切到纯拉丁键盘（如美式键盘）后
        ///     就已经没有输入法在做转换了，此时只有 HKL 能反映真实状态；
        ///   - Ctrl+Space 只在同一种布局内部切换中/英，布局不变，
        ///     这时唯一的依据是输入法的转换模式，NATIVE 置位表示处于本地语言（中文）模式。
        /// </summary>
        public static bool IsEnglishInputMode()
        {
            try
            {
                var hWnd = GetForegroundWindow();
                if (hWnd == IntPtr.Zero) return true;

                uint pid;
                uint threadId = GetWindowThreadProcessId(hWnd, out pid);
                if (threadId == 0) return true;

                int langId = (int)(GetKeyboardLayout(threadId).ToInt64() & 0xFFFF);
                if (!IsImeLanguage(langId)) return true;

                var imeWnd = ImmGetDefaultIMEWnd(hWnd);
                if (imeWnd == IntPtr.Zero) return true;

                var result = SendMessage(imeWnd, WM_IME_CONTROL, new IntPtr(IMC_GETCONVERSIONMODE), IntPtr.Zero);
                int conversionMode = result.ToInt32();

                return (conversionMode & IME_CMODE_NATIVE) == 0;
            }
            catch
            {
            }

            return false;
        }

        /// <summary>
        /// 该语言当前是否由输入法接管（中日韩）。
        /// </summary>
        private static bool IsImeLanguage(int langId)
        {
            switch (langId & 0x3FF)
            {
                case LANG_CHINESE:
                case LANG_JAPANESE:
                case LANG_KOREAN:
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// 等待输入法状态真正切换完成。
        ///
        /// keybd_event 注入的按键是异步入队的，而 Win+Space 由 shell 处理，
        /// 实测要 20~40ms 才反映到键盘布局上，注入后立刻读取会读到切换前的旧值。
        /// 这里轮询到状态变化为止，超时则返回最近一次读到的值。
        /// </summary>
        /// <param name="previousIsEnglish">注入按键之前读到的状态</param>
        /// <param name="timeoutMs">最长等待时间（毫秒）</param>
        public static bool WaitForInputModeChange(bool previousIsEnglish, int timeoutMs)
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            bool current = previousIsEnglish;

            while (stopwatch.ElapsedMilliseconds < timeoutMs)
            {
                System.Threading.Thread.Sleep(InputModeSettlePollIntervalMs);

                current = IsEnglishInputMode();
                if (current != previousIsEnglish) return current;
            }

            return current;
        }

        /// <summary>
        /// Send an arbitrary keystroke with optional modifiers.
        /// </summary>
        public static void SendKeyStroke(KeyStroke stroke)
        {
            if (stroke == null || stroke.Key == Keys.None) return;

            var signature = (UIntPtr)AppConfig.KeyboardHookSignature;
            var modifiers = new System.Collections.Generic.List<byte>();
            if (stroke.Ctrl) modifiers.Add(VK_CONTROL);
            if (stroke.Shift) modifiers.Add(VK_SHIFT);
            if (stroke.Alt) modifiers.Add(VK_MENU);
            if (stroke.Win) modifiers.Add(VK_LWIN);

            foreach (var mod in modifiers)
            {
                keybd_event(mod, 0, KEYEVENTF_EXTENDEDKEY, signature);
            }

            keybd_event((byte)stroke.Key, 0, KEYEVENTF_EXTENDEDKEY, signature);
            keybd_event((byte)stroke.Key, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, signature);

            for (int i = modifiers.Count - 1; i >= 0; i--)
            {
                keybd_event(modifiers[i], 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, signature);
            }
        }

        #endregion
    }
}
