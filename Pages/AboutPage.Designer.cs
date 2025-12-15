namespace TapCaps.Pages
{
    partial class AboutPage
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutPage));
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblSubHeader = new System.Windows.Forms.Label();
            this.groupAbout = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelInfo = new System.Windows.Forms.TableLayoutPanel();
            this.pictureEditLogo = new DevExpress.XtraEditors.PictureEdit();
            this.tableLayoutPanelDetails = new System.Windows.Forms.TableLayoutPanel();
            this.lblAppName = new System.Windows.Forms.Label();
            this.lblTagline = new System.Windows.Forms.Label();
            this.linkProject = new System.Windows.Forms.LinkLabel();
            this.groupHighlights = new System.Windows.Forms.GroupBox();
            this.txtHighlights = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanelMain.SuspendLayout();
            this.groupAbout.SuspendLayout();
            this.tableLayoutPanelInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEditLogo.Properties)).BeginInit();
            this.tableLayoutPanelDetails.SuspendLayout();
            this.groupHighlights.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Controls.Add(this.lblHeader, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.lblSubHeader, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.groupAbout, 0, 2);
            this.tableLayoutPanelMain.Controls.Add(this.groupHighlights, 0, 3);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 4;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(741, 571);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // lblHeader
            // 
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft YaHei UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHeader.Location = new System.Drawing.Point(20, 0);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(20, 0, 3, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(718, 55);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "关于 TapCaps";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSubHeader
            // 
            this.lblSubHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSubHeader.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblSubHeader.Location = new System.Drawing.Point(22, 55);
            this.lblSubHeader.Margin = new System.Windows.Forms.Padding(22, 0, 3, 0);
            this.lblSubHeader.Name = "lblSubHeader";
            this.lblSubHeader.Size = new System.Drawing.Size(716, 30);
            this.lblSubHeader.TabIndex = 1;
            this.lblSubHeader.Text = "让 CapsLock 更聪明，减少无效切换。";
            this.lblSubHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupAbout
            // 
            this.groupAbout.Controls.Add(this.tableLayoutPanelInfo);
            this.groupAbout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupAbout.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupAbout.Location = new System.Drawing.Point(18, 88);
            this.groupAbout.Margin = new System.Windows.Forms.Padding(18, 3, 18, 3);
            this.groupAbout.Name = "groupAbout";
            this.groupAbout.Size = new System.Drawing.Size(705, 244);
            this.groupAbout.TabIndex = 2;
            this.groupAbout.TabStop = false;
            this.groupAbout.Text = "项目信息";
            // 
            // tableLayoutPanelInfo
            // 
            this.tableLayoutPanelInfo.ColumnCount = 2;
            this.tableLayoutPanelInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 230F));
            this.tableLayoutPanelInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelInfo.Controls.Add(this.pictureEditLogo, 0, 0);
            this.tableLayoutPanelInfo.Controls.Add(this.tableLayoutPanelDetails, 1, 0);
            this.tableLayoutPanelInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelInfo.Location = new System.Drawing.Point(3, 25);
            this.tableLayoutPanelInfo.Name = "tableLayoutPanelInfo";
            this.tableLayoutPanelInfo.RowCount = 1;
            this.tableLayoutPanelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelInfo.Size = new System.Drawing.Size(699, 216);
            this.tableLayoutPanelInfo.TabIndex = 0;
            // 
            // pictureEditLogo
            // 
            this.pictureEditLogo.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.False;
            this.pictureEditLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureEditLogo.EditValue = ((object)(resources.GetObject("pictureEditLogo.EditValue")));
            this.pictureEditLogo.Location = new System.Drawing.Point(20, 20);
            this.pictureEditLogo.Margin = new System.Windows.Forms.Padding(20);
            this.pictureEditLogo.Name = "pictureEditLogo";
            this.pictureEditLogo.Properties.AllowAnimationOnValueChanged = DevExpress.Utils.DefaultBoolean.False;
            this.pictureEditLogo.Properties.AllowFocused = false;
            this.pictureEditLogo.Properties.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.False;
            this.pictureEditLogo.Properties.AllowScrollOnMouseWheel = DevExpress.Utils.DefaultBoolean.False;
            this.pictureEditLogo.Properties.AllowZoom = DevExpress.Utils.DefaultBoolean.False;
            this.pictureEditLogo.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEditLogo.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEditLogo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEditLogo.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEditLogo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pictureEditLogo.Size = new System.Drawing.Size(190, 176);
            this.pictureEditLogo.TabIndex = 0;
            // 
            // tableLayoutPanelDetails
            // 
            this.tableLayoutPanelDetails.ColumnCount = 1;
            this.tableLayoutPanelDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelDetails.Controls.Add(this.lblAppName, 0, 0);
            this.tableLayoutPanelDetails.Controls.Add(this.lblTagline, 0, 1);
            this.tableLayoutPanelDetails.Controls.Add(this.linkProject, 0, 2);
            this.tableLayoutPanelDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelDetails.Location = new System.Drawing.Point(233, 3);
            this.tableLayoutPanelDetails.Name = "tableLayoutPanelDetails";
            this.tableLayoutPanelDetails.RowCount = 4;
            this.tableLayoutPanelDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelDetails.Size = new System.Drawing.Size(463, 210);
            this.tableLayoutPanelDetails.TabIndex = 1;
            // 
            // lblAppName
            // 
            this.lblAppName.AutoSize = true;
            this.lblAppName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAppName.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAppName.Location = new System.Drawing.Point(10, 0);
            this.lblAppName.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(450, 40);
            this.lblAppName.TabIndex = 0;
            this.lblAppName.Text = "TapCaps";
            this.lblAppName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTagline
            // 
            this.lblTagline.AutoSize = true;
            this.lblTagline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTagline.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTagline.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTagline.Location = new System.Drawing.Point(12, 40);
            this.lblTagline.Margin = new System.Windows.Forms.Padding(12, 0, 3, 0);
            this.lblTagline.Name = "lblTagline";
            this.lblTagline.Size = new System.Drawing.Size(448, 30);
            this.lblTagline.TabIndex = 1;
            this.lblTagline.Text = "智能区分短按/长按，让输入法切换与大小写锁定更顺手。";
            this.lblTagline.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // linkProject
            // 
            this.linkProject.AutoSize = true;
            this.linkProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linkProject.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkProject.Location = new System.Drawing.Point(12, 70);
            this.linkProject.Margin = new System.Windows.Forms.Padding(12, 0, 3, 0);
            this.linkProject.Name = "linkProject";
            this.linkProject.Size = new System.Drawing.Size(448, 30);
            this.linkProject.TabIndex = 3;
            this.linkProject.TabStop = true;
            this.linkProject.Tag = "https://github.com/honue/TapCaps";
            this.linkProject.Text = "项目地址： https://github.com/honue/TapCaps";
            this.linkProject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkProject.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkProject_LinkClicked);
            // 
            // groupHighlights
            // 
            this.groupHighlights.Controls.Add(this.txtHighlights);
            this.groupHighlights.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupHighlights.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupHighlights.Location = new System.Drawing.Point(18, 338);
            this.groupHighlights.Margin = new System.Windows.Forms.Padding(18, 3, 18, 18);
            this.groupHighlights.Name = "groupHighlights";
            this.groupHighlights.Size = new System.Drawing.Size(705, 215);
            this.groupHighlights.TabIndex = 3;
            this.groupHighlights.TabStop = false;
            this.groupHighlights.Text = "功能描述";
            // 
            // txtHighlights
            // 
            this.txtHighlights.BackColor = System.Drawing.SystemColors.Control;
            this.txtHighlights.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHighlights.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHighlights.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtHighlights.Location = new System.Drawing.Point(3, 25);
            this.txtHighlights.Name = "txtHighlights";
            this.txtHighlights.ReadOnly = true;
            this.txtHighlights.Size = new System.Drawing.Size(699, 187);
            this.txtHighlights.TabIndex = 0;
            this.txtHighlights.Text = "• CapsLock 短按：自动切换输入法，并弹出 HUD 状态提示\n• CapsLock 长按：直接开启/关闭大小写锁定，减少误切换\n• 按键映射：将常用组合键" +
    "改为单键触发，提升效率\n• 托盘常驻：关闭窗口后最小化到托盘，随时召回\n• HUD 提示：切换输入法或大小写状态时弹窗提醒";
            // 
            // AboutPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Name = "AboutPage";
            this.Size = new System.Drawing.Size(741, 571);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.groupAbout.ResumeLayout(false);
            this.tableLayoutPanelInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEditLogo.Properties)).EndInit();
            this.tableLayoutPanelDetails.ResumeLayout(false);
            this.tableLayoutPanelDetails.PerformLayout();
            this.groupHighlights.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblSubHeader;
        private System.Windows.Forms.GroupBox groupAbout;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelInfo;
        private DevExpress.XtraEditors.PictureEdit pictureEditLogo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDetails;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Label lblTagline;
        private System.Windows.Forms.LinkLabel linkProject;
        private System.Windows.Forms.GroupBox groupHighlights;
        private System.Windows.Forms.RichTextBox txtHighlights;
    }
}
