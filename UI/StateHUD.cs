using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TapCaps.Core;
using TapCaps.Helpers;

namespace TapCaps.UI
{
    /// <summary>
    /// 状态提示窗口 - 显示输入法状态和 CapsLock 状态
    /// </summary>
    public class StateHUD : Form
    {
        #region 私有字段

        private Label _lblIcon;
        private System.Windows.Forms.Timer _hideTimer;
        private System.Windows.Forms.Timer _fadeTimer;
        private System.Windows.Forms.Timer _delayShowTimer;
        private static StateHUD _instance;
        private static Control _uiInvoker;
        private string _pendingIcon; // 待显示的图标文本

        #endregion

        #region 构造函数

        public StateHUD()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);
            DoubleBuffered = true;
            UpdateStyles();
            InitializeComponent();
            SetupTimers();
        }

        public static void BindInvoker(Control invoker)
        {
            if (invoker == null || invoker.IsDisposed) return;
            _uiInvoker = invoker;
        }

        #endregion

        #region Windows API

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        private const int SW_SHOWNOACTIVATE = 4;
        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const uint SWP_NOACTIVATE = 0x0010;
        private const uint SWP_NOMOVE = 0x0002;
        private const uint SWP_NOSIZE = 0x0001;
        private const uint SWP_SHOWWINDOW = 0x0040;

        #endregion

        #region Windows 窗口样式

        /// <summary>
        /// 重写 CreateParams 以防止窗口获得焦点
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_EX_NOACTIVATE = 0x08000000;
                const int WS_EX_TOOLWINDOW = 0x00000080;
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= WS_EX_NOACTIVATE | WS_EX_TOOLWINDOW;
                return cp;
            }
        }

        /// <summary>
        /// 防止窗口在显示时获得焦点
        /// </summary>
        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }

        #endregion

        #region 初始化方法

        /// <summary>
        /// 初始化窗口组件
        /// </summary>
        private void InitializeComponent()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Size = new Size(36, 24);
            this.BackColor = ColorTranslator.FromHtml(AppConfig.HudBackgroundColor);
            this.Opacity = 0.0; // 初始不可见

            // 设置文本/图标标签
            _lblIcon = new Label
            {
                AutoSize = false,
                Font = new Font(AppConfig.HudFontName, AppConfig.HudFontSize, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent,
                Padding = Padding.Empty
            };

            this.Controls.Add(_lblIcon);
            this.Load += (s, e) => SetRoundedRegion();
            this.Paint += StateHUD_Paint;
        }

        /// <summary>
        /// 设置定时器
        /// </summary>
        private void SetupTimers()
        {
            // 隐藏定时器 - 控制显示时长
            _hideTimer = new System.Windows.Forms.Timer
            {
                Interval = AppConfig.HudDisplayDurationMs
            };
            _hideTimer.Tick += (s, e) =>
            {
                _hideTimer.Stop();
                _fadeTimer.Start();
            };

            // 淡出定时器 - 控制淡出动画
            _fadeTimer = new System.Windows.Forms.Timer
            {
                Interval = AppConfig.HudFadeIntervalMs
            };
            _fadeTimer.Tick += (s, e) =>
            {
                if (this.Opacity > 0)
                {
                    this.Opacity -= AppConfig.HudFadeStep;
                }
                else
                {
                    _fadeTimer.Stop();
                    // 使用 SetWindowPos 隐藏窗口,不影响焦点
                    const uint SWP_HIDEWINDOW = 0x0080;
                    SetWindowPos(this.Handle, IntPtr.Zero, 0, 0, 0, 0, 
                        SWP_HIDEWINDOW | SWP_NOACTIVATE | SWP_NOMOVE | SWP_NOSIZE);
                }
            };

            // 延迟显示定时器 - 等待输入法切换完成后再显示
            _delayShowTimer = new System.Windows.Forms.Timer
            {
                Interval = 50 // 延迟50ms
            };
            _delayShowTimer.Tick += (s, e) =>
            {
                _delayShowTimer.Stop();
                ActuallyShowWindow();
            };
        }

        #endregion

        #region 窗口样式方法

        /// <summary>
        /// 设置圆角区域
        /// </summary>
        public void SetRoundedRegion()
        {
            var rect = new RectangleF(0.5f, 0.5f, this.Width - 1f, this.Height - 1f);
            this.Region = new Region(BuildRoundedPath(rect, AppConfig.HudCornerRadius));
        }

        /// <summary>
        /// 绘制窗口
        /// </summary>
        private void StateHUD_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            var rect = new RectangleF(0.5f, 0.5f, this.Width - 1f, this.Height - 1f);
            float radius = AppConfig.HudCornerRadius;

            // drop shadow
            using (GraphicsPath shadowPath = BuildRoundedPath(new RectangleF(rect.X + 2f, rect.Y + 3f, rect.Width, rect.Height), radius))
            using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(50, 0, 0, 0)))
            {
                e.Graphics.FillPath(shadowBrush, shadowPath);
            }

            // background
            using (GraphicsPath bgPath = BuildRoundedPath(rect, radius))
            using (SolidBrush bgBrush = new SolidBrush(ColorTranslator.FromHtml(AppConfig.HudBackgroundColor)))
            {
                e.Graphics.FillPath(bgBrush, bgPath);
            }

            // subtle border
            using (Pen borderPen = new Pen(Color.FromArgb(80, Color.White), 1))
            using (GraphicsPath borderPath = BuildRoundedPath(rect, radius))
            {
                e.Graphics.DrawPath(borderPen, borderPath);
            }
        }

        #endregion

        #region 公共静态方法

        /// <summary>
        /// 显示状态提示
        /// </summary>
        /// <param name="icon">要显示的图标文本</param>
        /// <param name="text">状态描述文本（当前未使用）</param>
        public static void ShowState(string icon, string text)
        {
            Action showAction = () =>
            {
                // 创建或获取实例
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new StateHUD();
                }

                // 保存待显示的图标文本
                _instance._pendingIcon = icon;

                // 启动延迟显示
                _instance.ShowWindow();
            };

            // 确保在 UI 线程执行
            var target = _uiInvoker ?? (Application.OpenForms.Count > 0 ? Application.OpenForms[0] : null);
            if (target != null && !target.IsDisposed && target.InvokeRequired)
            {
                try
                {
                    target.BeginInvoke(showAction);
                    return;
                }
                catch
                {
                    // fall through to direct call if invoke fails
                }
            }

            showAction();
        }

        /// <summary>
        /// 立即隐藏状态提示
        /// </summary>
        public static void HideState()
        {
            Action hideAction = () =>
            {
                if (_instance != null && !_instance.IsDisposed && _instance.Opacity > 0)
                {
                    _instance.QuickHide();
                }
            };

            var target = _uiInvoker ?? (Application.OpenForms.Count > 0 ? Application.OpenForms[0] : null);
            if (target != null && !target.IsDisposed && target.InvokeRequired)
            {
                try
                {
                    target.BeginInvoke(hideAction);
                    return;
                }
                catch
                {
                    // ignore invoke failure
                }
            }

            hideAction();
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 根据文本内容更新窗口大小
        /// </summary>
        private void UpdateSize(string icon)
        {
            var textSize = TextRenderer.MeasureText(
                icon,
                _lblIcon.Font,
                Size.Empty,
                TextFormatFlags.NoPadding | TextFormatFlags.SingleLine);

            int newWidth = textSize.Width + AppConfig.HudPaddingX;
            int newHeight = textSize.Height + AppConfig.HudPaddingY;
            this.Size = new Size(newWidth, newHeight);
            SetRoundedRegion(); // 重新应用圆角
        }

        /// <summary>
        /// 定位窗口到光标位置
        /// </summary>
        private void PositionWindow()
        {
            Point caret = CaretHelper.GetCaretPosition();

            // 在光标正下方显示
            int x = caret.X - (this.Width / 2);
            int y = caret.Y + AppConfig.HudCaretOffsetY;

            // 边界检查
            Rectangle screen = Screen.FromPoint(caret).WorkingArea;
            if (x < screen.Left) x = screen.Left + 10;
            if (x + this.Width > screen.Right) x = screen.Right - this.Width - 10;

            // 如果超出底部边界，显示在光标上方
            if (y + this.Height > screen.Bottom)
            {
                y = caret.Y - this.Height - AppConfig.HudCaretOffsetY;
            }
            if (y < screen.Top) y = screen.Top + 10;

            this.Location = new Point(x, y);
        }

        /// <summary>
        /// 显示窗口并启动定时器(延迟显示)
        /// </summary>
        private void ShowWindow()
        {
            // 停止之前的延迟显示
            _delayShowTimer.Stop();
            // 启动延迟显示定时器
            _delayShowTimer.Start();
        }

        /// <summary>
        /// 实际显示窗口的方法
        /// </summary>
        private void ActuallyShowWindow()
        {
            // 首先确保窗口句柄已创建(UpdateSize 需要用到 CreateGraphics)
            if (!this.IsHandleCreated)
            {
                this.CreateHandle();
            }

            // 确保 Label 控件的句柄也被创建
            if (!_lblIcon.IsHandleCreated)
            {
                var handle = _lblIcon.Handle; // 访问 Handle 属性会强制创建句柄
            }

            // 设置显示内容
            _lblIcon.Text = _pendingIcon;

            // 动态计算窗口大小
            UpdateSize(_pendingIcon);

            // 定位窗口
            PositionWindow();

            // 设置透明度
            this.Opacity = AppConfig.HudOpacity;

            if (!this.Visible)
            {
                // 使用 SetWindowPos 显示窗口,完全不激活焦点
                // SWP_NOACTIVATE: 不激活窗口
                // SWP_SHOWWINDOW: 显示窗口
                // SWP_NOMOVE | SWP_NOSIZE: 不改变位置和大小(已经在 PositionWindow 中设置)
                SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, 
                    SWP_NOACTIVATE | SWP_SHOWWINDOW | SWP_NOMOVE | SWP_NOSIZE);
            }
            else
            {
                // 如果已经可见,确保在最上层但不激活
                SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, 
                    SWP_NOACTIVATE | SWP_NOMOVE | SWP_NOSIZE);
            }

            // 强制刷新控件
            _lblIcon.Refresh();
            this.Refresh();

            _hideTimer.Stop();
            _hideTimer.Start();
            _fadeTimer.Stop();
        }

        /// <summary>
        /// 快速隐藏窗口
        /// </summary>
        private void QuickHide()
        {
            _delayShowTimer.Stop();
            _hideTimer.Stop();
            _fadeTimer.Stop();

            // 使用 SetWindowPos 隐藏窗口
            const uint SWP_HIDEWINDOW = 0x0080;
            const uint SWP_NOACTIVATE = 0x0010;
            const uint SWP_NOMOVE = 0x0002;
            const uint SWP_NOSIZE = 0x0001;
            
            if (this.IsHandleCreated)
            {
                SetWindowPos(this.Handle, IntPtr.Zero, 0, 0, 0, 0, 
                    SWP_HIDEWINDOW | SWP_NOACTIVATE | SWP_NOMOVE | SWP_NOSIZE);
            }
            
            this.Opacity = 0;
        }

        private static GraphicsPath BuildRoundedPath(RectangleF rect, float radius)
        {
            float diameter = radius * 2f;
            var path = new GraphicsPath();

            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            return path;
        }

        #endregion
    }
}
