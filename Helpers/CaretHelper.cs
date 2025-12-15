using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TapCaps.Helpers
{
    /// <summary>
    /// 光标位置辅助类 - 用于获取当前文本光标的屏幕位置
    /// 支持多种检测方法以兼容不同的应用程序
    /// </summary>
    public static class CaretHelper
    {
        #region Windows API 常量

        private const uint OBJID_CARET = 0xFFFFFFF8;

        #endregion

        #region Windows API 结构

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct GUITHREADINFO
        {
            public int cbSize;
            public int flags;
            public IntPtr hwndActive;
            public IntPtr hwndFocus;
            public IntPtr hwndCapture;
            public IntPtr hwndMenuOwner;
            public IntPtr hwndMoveSize;
            public IntPtr hwndCaret;
            public RECT rcCaret;
        }

        #endregion

        #region Windows API 接口

        [ComImport]
        [Guid("618736E0-3C3D-11CF-810C-00AA00389B71")]
        [InterfaceType(ComInterfaceType.InterfaceIsDual)]
        private interface IAccessible
        {
            [return: MarshalAs(UnmanagedType.IDispatch)]
            object get_accParent();
            int get_accChildCount();
            [return: MarshalAs(UnmanagedType.IDispatch)]
            object get_accChild(object varChild);
            [return: MarshalAs(UnmanagedType.BStr)]
            string get_accName(object varChild);
            [return: MarshalAs(UnmanagedType.BStr)]
            string get_accValue(object varChild);
            [return: MarshalAs(UnmanagedType.BStr)]
            string get_accDescription(object varChild);
            [return: MarshalAs(UnmanagedType.Struct)]
            object get_accRole(object varChild);
            [return: MarshalAs(UnmanagedType.Struct)]
            object get_accState(object varChild);
            [return: MarshalAs(UnmanagedType.BStr)]
            string get_accHelp(object varChild);
            int get_accHelpTopic(out string psiHelpFile, object varChild);
            [return: MarshalAs(UnmanagedType.BStr)]
            string get_accKeyboardShortcut(object varChild);
            [return: MarshalAs(UnmanagedType.Struct)]
            object get_accFocus();
            [return: MarshalAs(UnmanagedType.Struct)]
            object get_accSelection();
            [return: MarshalAs(UnmanagedType.BStr)]
            string get_accDefaultAction(object varChild);

            void accSelect(int flagsSelect, object varChild);
            void accLocation(out int pxLeft, out int pyTop, out int pcxWidth, out int pcyHeight, object varChild);
            void accNavigate(int navDir, object varStart, [MarshalAs(UnmanagedType.Struct)] out object pvarEndUpAt);
            void accHitTest(int xLeft, int yTop, [MarshalAs(UnmanagedType.Struct)] out object pvarChild);
            void accDoDefaultAction(object varChild);

            void put_accName(object varChild, string szName);
            void put_accValue(object varChild, string szValue);
        }

        #endregion

        #region Windows API 导入

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("user32.dll")]
        private static extern bool GetGUIThreadInfo(uint idThread, ref GUITHREADINFO lpgui);

        [DllImport("user32.dll")]
        private static extern bool ClientToScreen(IntPtr hWnd, ref Point lpPoint);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("oleacc.dll")]
        private static extern int AccessibleObjectFromWindow(
            IntPtr hwnd,
            uint dwId,
            ref Guid riid,
            [MarshalAs(UnmanagedType.Interface)] out IAccessible ppvObject);

        #endregion

        #region 公共方法

        /// <summary>
        /// 获取当前文本光标的屏幕位置
        /// 使用多种方法尝试检测，以兼容不同的应用程序
        /// </summary>
        /// <returns>光标的屏幕坐标</returns>
        public static Point GetCaretPosition()
        {
            Point caretPosition = Point.Empty;
            IntPtr hWnd = GetForegroundWindow();

            if (hWnd == IntPtr.Zero)
                return Cursor.Position;

            // 优先级 1: UI Automation (对现代应用如 VSCode、Chrome 最可靠)
            if (TryGetCaretPositionViaUIAutomation(out caretPosition))
                return caretPosition;

            // 优先级 2: GUI Thread Info (Win32 - 适用于传统应用)
            if (TryGetCaretPositionViaGUIThreadInfo(hWnd, out caretPosition))
                return caretPosition;

            // 优先级 3: MSAA (OLEACC - 某些浏览器的后备方案)
            if (TryGetCaretPositionViaMSAA(hWnd, out caretPosition))
                return caretPosition;

            // 优先级 4: 鼠标光标位置 (最后的备选方案)
            return Cursor.Position;
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 尝试通过 UI Automation 获取光标位置
        /// </summary>
        private static bool TryGetCaretPositionViaUIAutomation(out Point position)
        {
            position = Point.Empty;
            try
            {
                var element = System.Windows.Automation.AutomationElement.FocusedElement;
                if (element != null)
                {
                    object patternObj;
                    if (element.TryGetCurrentPattern(System.Windows.Automation.TextPattern.Pattern, out patternObj))
                    {
                        var textPattern = (System.Windows.Automation.TextPattern)patternObj;
                        var ranges = textPattern.GetSelection();
                        if (ranges != null && ranges.Length > 0)
                        {
                            var range = ranges[0];
                            var rects = range.GetBoundingRectangles();
                            if (rects != null && rects.Length > 0)
                            {
                                var r = rects[0];
                                position = new Point((int)r.Left, (int)r.Bottom);
                                return position.X != 0 || position.Y != 0;
                            }
                        }
                    }
                }
            }
            catch
            {
                // 忽略 UI Automation 错误
            }
            return false;
        }

        /// <summary>
        /// 尝试通过 GUI Thread Info 获取光标位置
        /// </summary>
        private static bool TryGetCaretPositionViaGUIThreadInfo(IntPtr hWnd, out Point position)
        {
            position = Point.Empty;
            try
            {
                uint processId;
                uint threadId = GetWindowThreadProcessId(hWnd, out processId);
                GUITHREADINFO guiInfo = new GUITHREADINFO();
                guiInfo.cbSize = Marshal.SizeOf(guiInfo);

                if (GetGUIThreadInfo(threadId, ref guiInfo) && guiInfo.hwndCaret != IntPtr.Zero)
                {
                    if (guiInfo.rcCaret.Right > 0 || guiInfo.rcCaret.Bottom > 0)
                    {
                        Point pt = new Point(guiInfo.rcCaret.Left, guiInfo.rcCaret.Bottom);
                        ClientToScreen(guiInfo.hwndCaret, ref pt);
                        position = pt;
                        return position.X != 0 || position.Y != 0;
                    }
                }
            }
            catch
            {
                // 忽略 Win32 错误
            }
            return false;
        }

        /// <summary>
        /// 尝试通过 MSAA 获取光标位置
        /// </summary>
        private static bool TryGetCaretPositionViaMSAA(IntPtr hWnd, out Point position)
        {
            position = Point.Empty;
            try
            {
                Guid IID_IAccessible = new Guid("618736E0-3C3D-11CF-810C-00AA00389B71");
                IAccessible accessible;
                int hr = AccessibleObjectFromWindow(hWnd, OBJID_CARET, ref IID_IAccessible, out accessible);

                if (hr >= 0 && accessible != null)
                {
                    int left, top, width, height;
                    accessible.accLocation(out left, out top, out width, out height, 0);
                    if (left != 0 || top != 0)
                    {
                        position = new Point(left + width, top + height);
                        return true;
                    }
                }
            }
            catch
            {
                // 忽略 MSAA 错误
            }
            return false;
        }

        #endregion
    }
}
