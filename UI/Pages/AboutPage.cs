using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace TapCaps.Pages
{
    public partial class AboutPage : UserControl
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private void linkProject_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var url = linkProject.Tag as string ?? linkProject.Text;
            if (string.IsNullOrWhiteSpace(url))
            {
                return;
            }

            url = url.Replace("项目地址：", string.Empty).Trim();
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch
            {
                // 打开链接失败时静默处理，避免阻塞用户界面。
            }
        }
    }
}
