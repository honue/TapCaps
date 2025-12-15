using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TapCaps.Core
{
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

        #endregion

        #region Windows API imports

        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        [DllImport("user32.dll")]
        private static extern short GetKeyState(int nVirtKey);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

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
        /// Detect whether the current IME is in English/half-width mode (mirrors LangIndicator).
        /// </summary>
        public static bool IsEnglishInputMode()
        {
            try
            {
                var hWnd = GetForegroundWindow();
                if (hWnd == IntPtr.Zero) return true;

                var imeWnd = ImmGetDefaultIMEWnd(hWnd);
                if (imeWnd == IntPtr.Zero) return true;

                var result = SendMessage(imeWnd, WM_IME_CONTROL, new IntPtr(IMC_GETCONVERSIONMODE), IntPtr.Zero);
                int conversionMode = result.ToInt32();

                bool isChineseMode = (conversionMode & IME_CMODE_NATIVE) == 0;
                return !isChineseMode;
            }
            catch
        {
            }

            return false;
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
