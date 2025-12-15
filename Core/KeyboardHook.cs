using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TapCaps.Core
{
    /// <summary>
    /// 底层键盘钩子 - 用于拦截和处理键盘事件
    /// </summary>
    public class KeyboardHook : IDisposable
    {
        #region Windows API 常量

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;
        private const int WM_SYSKEYDOWN = 0x0104;
        private const int WM_SYSKEYUP = 0x0105;

        #endregion

        #region 私有字段

        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;

        #endregion

        #region 公共事件

        /// <summary>
        /// 按键按下事件
        /// </summary>
        public static event Action<Keys> KeyDown;

        /// <summary>
        /// 按键释放事件
        /// </summary>
        public static event Action<Keys> KeyUp;

        /// <summary>
        /// 是否应该拦截按键按下事件
        /// </summary>
        public static event Func<Keys, bool> ShouldSuppressKeyDown;

        /// <summary>
        /// 是否应该拦截按键释放事件
        /// </summary>
        public static event Func<Keys, bool> ShouldSuppressKeyUp;

        #endregion

        #region 公共方法

        /// <summary>
        /// 启动键盘钩子
        /// </summary>
        public void Start()
        {
            _hookID = SetHook(_proc);
        }

        /// <summary>
        /// 停止键盘钩子
        /// </summary>
        public void Stop()
        {
            if (_hookID != IntPtr.Zero)
            {
                UnhookWindowsHookEx(_hookID);
                _hookID = IntPtr.Zero;
            }
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            Stop();
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 设置键盘钩子
        /// </summary>
        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        /// <summary>
        /// 键盘钩子回调函数
        /// </summary>
        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                KBDLLHOOKSTRUCT hookStruct = (KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(KBDLLHOOKSTRUCT));

                // 忽略我们自己注入的按键事件，避免无限循环
                if (hookStruct.dwExtraInfo == (UIntPtr)AppConfig.KeyboardHookSignature)
                {
                    return CallNextHookEx(_hookID, nCode, wParam, lParam);
                }

                Keys key = (Keys)hookStruct.vkCode;

                // 处理按键按下事件
                if (wParam == (IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_SYSKEYDOWN)
                {
                    // 检查是否需要拦截
                    if (ShouldSuppressKeyDown != null && ShouldSuppressKeyDown(key))
                        return (IntPtr)1;

                    // 触发按键按下事件
                    KeyDown?.Invoke(key);
                }
                // 处理按键释放事件
                else if (wParam == (IntPtr)WM_KEYUP || wParam == (IntPtr)WM_SYSKEYUP)
                {
                    // 检查是否需要拦截
                    if (ShouldSuppressKeyUp != null && ShouldSuppressKeyUp(key))
                        return (IntPtr)1;

                    // 触发按键释放事件
                    KeyUp?.Invoke(key);
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        #endregion

        #region Windows API 结构和委托

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        [StructLayout(LayoutKind.Sequential)]
        private struct KBDLLHOOKSTRUCT
        {
            public uint vkCode;
            public uint scanCode;
            public uint flags;
            public uint time;
            public UIntPtr dwExtraInfo;
        }

        #endregion

        #region Windows API 导入

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        #endregion
    }
}
