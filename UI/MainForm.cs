using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TapCaps.Core;
using TapCaps.Pages;

namespace TapCaps.UI
{
    /// <summary>
    /// 主窗体 - 应用程序的主界面
    /// </summary>
    public partial class MainForm : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        #region 私有字段

        private KeyboardHook _hook;
        private LogicHandler _handler;
        private NotifyIcon _trayIcon;
        private ContextMenuStrip _trayMenu;
        private readonly bool _startHidden;
        private bool _isHidingToTray;
        private bool _exitRequested;
        private bool _trayIconEnabled = true;
        private UserSettings _settings;

        #endregion

        #region 构造函数

        public MainForm(UserSettings settings = null, bool startHidden = false)
        {
            _settings = settings;
            _startHidden = startHidden;
            InitializeComponent();
            InitializeCore();
            InitializeTrayIcon();
            if (_startHidden)
            {
                this.Load += MainForm_StartHidden;
            }
            this.Resize += MainForm_Resize;
        }

        #endregion

        #region 初始化方法

        /// <summary>
        /// 初始化核心组件
        /// </summary>
        private void InitializeCore()
        {
            _hook = new KeyboardHook();
            _handler = new LogicHandler();
            if (_settings == null)
            {
                _settings = UserSettingsStore.Load() ?? new UserSettings();
            }

            // Apply persisted settings to runtime state.
            if (_settings != null)
            {
                _handler.EnableMacCapsLock = _settings.EnableMacCapsLock;
                _handler.EnableKeyMapping = _settings.EnableKeyMapping;
                _handler.EnableHud = _settings.EnableHud;
                _handler.LongPressThresholdMs = _settings.LongPressThresholdMs;
                _trayIconEnabled = _settings.TrayIconEnabled;
                _handler.SetKeyMappings(_settings.KeyMappings);
            }

            StateHUD.BindInvoker(this);
        }

        #endregion

        #region 事件处理

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            StartKeyboardHook();
            LoadDefaultPage();
        }

        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!_exitRequested && e.CloseReason == CloseReason.UserClosing)
            {
                // 点击关闭时不退出，转为后台驻留
                e.Cancel = true;
                if (_trayIconEnabled)
                {
                    HideToTray();
                }
                else
                {
                    // 没有托盘图标时，窗口最小化
                    this.WindowState = FormWindowState.Minimized;
                    this.ShowInTaskbar = true;
                    this.Show();
                }
                return;
            }

            StopKeyboardHook();
            if (_trayIcon != null)
            {
                _trayIcon.Visible = false;
            }
            base.OnFormClosing(e);
        }

        /// <summary>
        /// 主页按钮点击事件
        /// </summary>
        private void HomePageElement_Click(object sender, EventArgs e)
        {
            SwitchToPage(new HomePage(_handler));
        }

        /// <summary>
        /// 按键映射页面按钮点击事件
        /// </summary>
        private void KeyMappingPageElement_Click(object sender, EventArgs e)
        {
            SwitchToPage(new KeyMappingPage(_handler));
        }

        /// <summary>
        /// 设置页面按钮点击事件
        /// </summary>
        private void AboutPageElement_Click(object sender, EventArgs e)
        {
            SwitchToPage(new AboutPage());
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 启动键盘钩子
        /// </summary>
        private void StartKeyboardHook()
        {
            try
            {
                _hook.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"无法安装键盘钩子: {ex.Message}", "错误", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 停止键盘钩子
        /// </summary>
        private void StopKeyboardHook()
        {
            _hook?.Stop();
        }

        /// <summary>
        /// 加载默认页面
        /// </summary>
        private void LoadDefaultPage()
        {
            if (HomePageElement != null)
            {
                AccordionControl.SelectedElement = HomePageElement;
                SwitchToPage(new HomePage(_handler));
            }
        }

        /// <summary>
        /// 切换到指定页面
        /// </summary>
        /// <param name="newPage">要显示的新页面</param>
        private void SwitchToPage(UserControl newPage)
        {
            if (newPage == null) return;

            // 清理旧页面
            if (fluentDesignFormContainer1.Controls.Count > 0)
            {
                var oldControl = fluentDesignFormContainer1.Controls[0];
                fluentDesignFormContainer1.Controls.Remove(oldControl);
                oldControl.Dispose();
            }

            // 添加新页面
            newPage.Dock = DockStyle.Fill;
            fluentDesignFormContainer1.Controls.Add(newPage);
        }

        #endregion

        #region 托盘机制

        /// <summary>
        /// 初始化托盘图标和菜单
        /// </summary>
        private void InitializeTrayIcon()
        {
            if (components == null)
            {
                components = new System.ComponentModel.Container();
            }

            _trayMenu = new ContextMenuStrip(components);
            var openItem = new ToolStripMenuItem("打开主界面", null, (s, e) => RestoreFromTray());
            var exitItem = new ToolStripMenuItem("退出", null, (s, e) => ExitFromTray());
            _trayMenu.Items.Add(openItem);
            _trayMenu.Items.Add(exitItem);

            var icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath) ?? SystemIcons.Application;
            _trayIcon = new NotifyIcon(components)
            {
                Icon = icon,
                Text = "TapCaps",
                Visible = _trayIconEnabled,
                ContextMenuStrip = _trayMenu
            };
            _trayIcon.DoubleClick += (s, e) => RestoreFromTray();
        }

        private void MainForm_StartHidden(object sender, EventArgs e)
        {
            // Defer hiding to avoid re-entrancy during initial layout.
            this.BeginInvoke((Action)(HideToTray));
        }

        /// <summary>
        /// 最小化时也隐藏到托盘
        /// </summary>
        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (_isHidingToTray) return;
            if (this.WindowState == FormWindowState.Minimized && !_exitRequested && _trayIconEnabled)
            {
                HideToTray();
            }
        }

        /// <summary>
        /// 隐藏到托盘
        /// </summary>
        private void HideToTray()
        {
            if (!_trayIconEnabled) return;
            _isHidingToTray = true;
            try
            {
                this.Hide();
                this.ShowInTaskbar = false;
                if (_trayIcon != null && !_trayIcon.Visible)
                {
                    _trayIcon.Visible = true;
                }
            }
            finally
            {
                _isHidingToTray = false;
            }
        }

        /// <summary>
        /// 从托盘恢复
        /// </summary>
        private void RestoreFromTray()
        {
            this.ShowInTaskbar = true;
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        /// <summary>
        /// 托盘退出操作
        /// </summary>
        private void ExitFromTray()
        {
            _exitRequested = true;
            this.ShowInTaskbar = true;
            Close();
        }

        #endregion

        #region 公共设置接口

        public bool TrayIconEnabled => _trayIconEnabled;

        public void SetTrayIconEnabled(bool enabled)
        {
            _trayIconEnabled = enabled;
            if (_trayIcon != null)
            {
                _trayIcon.Visible = enabled;
            }

            if (!enabled)
            {
                // Ensure window is accessible when tray is disabled.
                RestoreFromTray();
            }

            PersistSettings();
        }

        public void PersistSettings()
        {
            if (_settings == null)
            {
                _settings = new UserSettings();
            }

            _settings.EnableMacCapsLock = _handler.EnableMacCapsLock;
            _settings.EnableKeyMapping = _handler.EnableKeyMapping;
            _settings.EnableHud = _handler.EnableHud;
            _settings.LongPressThresholdMs = _handler.LongPressThresholdMs;
            _settings.TrayIconEnabled = _trayIconEnabled;
            _settings.KeyMappings = _handler.GetKeyMappings().ToList();

            UserSettingsStore.Save(_settings);
        }

        public bool AutoStartEnabled => _settings?.AutoStartEnabled ?? true;

        public void SetAutoStartEnabled(bool enabled)
        {
            if (_settings == null)
            {
                _settings = new UserSettings();
            }

            _settings.AutoStartEnabled = enabled;
            AutoStartManager.SetAutoStart(enabled);
            PersistSettings();
        }

        #endregion
    }
}
