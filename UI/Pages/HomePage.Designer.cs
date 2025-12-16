namespace TapCaps.Pages
{
    partial class HomePage
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblHint = new System.Windows.Forms.Label();
            this.groupSwitches = new System.Windows.Forms.GroupBox();
            this.lblAutoStart = new System.Windows.Forms.Label();
            this.toggleAutoStart = new DevExpress.XtraEditors.ToggleSwitch();
            this.lblLongPressUnit = new System.Windows.Forms.Label();
            this.numLongPress = new System.Windows.Forms.NumericUpDown();
            this.lblLongPress = new System.Windows.Forms.Label();
            this.lblHudText = new System.Windows.Forms.Label();
            this.toggleHud = new DevExpress.XtraEditors.ToggleSwitch();
            this.lblMacStyleText = new System.Windows.Forms.Label();
            this.toggleMacStyle = new DevExpress.XtraEditors.ToggleSwitch();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupSwitches.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toggleAutoStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLongPress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleHud.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleMacStyle.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblHeader, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblHint, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupSwitches, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 129F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(681, 593);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(18, 212);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(18, 3, 18, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(645, 378);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "测试框";
            // 
            // richTextBox
            // 
            this.richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox.Location = new System.Drawing.Point(3, 25);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(639, 350);
            this.richTextBox.TabIndex = 0;
            this.richTextBox.Text = "可以在这进行测试";
            // 
            // lblHeader
            // 
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft YaHei UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHeader.Location = new System.Drawing.Point(20, 0);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(20, 0, 3, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(658, 50);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "TapCaps 快速设置";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHint
            // 
            this.lblHint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHint.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblHint.Location = new System.Drawing.Point(22, 50);
            this.lblHint.Margin = new System.Windows.Forms.Padding(22, 0, 3, 0);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(656, 30);
            this.lblHint.TabIndex = 1;
            this.lblHint.Text = "在这里快速启用/关闭常用功能。";
            this.lblHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupSwitches
            // 
            this.groupSwitches.Controls.Add(this.lblAutoStart);
            this.groupSwitches.Controls.Add(this.toggleAutoStart);
            this.groupSwitches.Controls.Add(this.lblLongPressUnit);
            this.groupSwitches.Controls.Add(this.numLongPress);
            this.groupSwitches.Controls.Add(this.lblLongPress);
            this.groupSwitches.Controls.Add(this.lblHudText);
            this.groupSwitches.Controls.Add(this.toggleHud);
            this.groupSwitches.Controls.Add(this.lblMacStyleText);
            this.groupSwitches.Controls.Add(this.toggleMacStyle);
            this.groupSwitches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupSwitches.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupSwitches.Location = new System.Drawing.Point(18, 83);
            this.groupSwitches.Margin = new System.Windows.Forms.Padding(18, 3, 18, 3);
            this.groupSwitches.Name = "groupSwitches";
            this.groupSwitches.Size = new System.Drawing.Size(645, 123);
            this.groupSwitches.TabIndex = 2;
            this.groupSwitches.TabStop = false;
            this.groupSwitches.Text = "设置开关";
            // 
            // lblAutoStart
            // 
            this.lblAutoStart.AutoSize = true;
            this.lblAutoStart.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAutoStart.Location = new System.Drawing.Point(22, 35);
            this.lblAutoStart.Name = "lblAutoStart";
            this.lblAutoStart.Size = new System.Drawing.Size(78, 23);
            this.lblAutoStart.TabIndex = 8;
            this.lblAutoStart.Text = "开机自启";
            // 
            // toggleAutoStart
            // 
            this.toggleAutoStart.Location = new System.Drawing.Point(190, 33);
            this.toggleAutoStart.Name = "toggleAutoStart";
            this.toggleAutoStart.Properties.Appearance.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.toggleAutoStart.Properties.Appearance.Options.UseFont = true;
            this.toggleAutoStart.Properties.OffText = "关";
            this.toggleAutoStart.Properties.OnText = "开";
            this.toggleAutoStart.Size = new System.Drawing.Size(95, 27);
            this.toggleAutoStart.TabIndex = 1;
            this.toggleAutoStart.Toggled += new System.EventHandler(this.toggleAutoStart_Toggled);
            // 
            // lblLongPressUnit
            // 
            this.lblLongPressUnit.AutoSize = true;
            this.lblLongPressUnit.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLongPressUnit.Location = new System.Drawing.Point(579, 77);
            this.lblLongPressUnit.Name = "lblLongPressUnit";
            this.lblLongPressUnit.Size = new System.Drawing.Size(34, 23);
            this.lblLongPressUnit.TabIndex = 6;
            this.lblLongPressUnit.Text = "ms";
            // 
            // numLongPress
            // 
            this.numLongPress.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numLongPress.Increment = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numLongPress.Location = new System.Drawing.Point(493, 75);
            this.numLongPress.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numLongPress.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numLongPress.Name = "numLongPress";
            this.numLongPress.Size = new System.Drawing.Size(80, 29);
            this.numLongPress.TabIndex = 5;
            this.numLongPress.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numLongPress.ValueChanged += new System.EventHandler(this.numLongPress_ValueChanged);
            // 
            // lblLongPress
            // 
            this.lblLongPress.AutoSize = true;
            this.lblLongPress.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLongPress.Location = new System.Drawing.Point(325, 75);
            this.lblLongPress.Name = "lblLongPress";
            this.lblLongPress.Size = new System.Drawing.Size(112, 23);
            this.lblLongPress.TabIndex = 4;
            this.lblLongPress.Text = "长按阈值设置";
            // 
            // lblHudText
            // 
            this.lblHudText.AutoSize = true;
            this.lblHudText.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHudText.Location = new System.Drawing.Point(325, 35);
            this.lblHudText.Name = "lblHudText";
            this.lblHudText.Size = new System.Drawing.Size(122, 23);
            this.lblHudText.TabIndex = 7;
            this.lblHudText.Text = "HUD 提示气泡";
            // 
            // toggleHud
            // 
            this.toggleHud.Location = new System.Drawing.Point(493, 33);
            this.toggleHud.Name = "toggleHud";
            this.toggleHud.Properties.Appearance.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.toggleHud.Properties.Appearance.Options.UseFont = true;
            this.toggleHud.Properties.OffText = "关";
            this.toggleHud.Properties.OnText = "开";
            this.toggleHud.Size = new System.Drawing.Size(95, 27);
            this.toggleHud.TabIndex = 4;
            this.toggleHud.Toggled += new System.EventHandler(this.toggleHud_Toggled);
            // 
            // lblMacStyleText
            // 
            this.lblMacStyleText.AutoSize = true;
            this.lblMacStyleText.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMacStyleText.Location = new System.Drawing.Point(22, 75);
            this.lblMacStyleText.Name = "lblMacStyleText";
            this.lblMacStyleText.Size = new System.Drawing.Size(150, 23);
            this.lblMacStyleText.TabIndex = 6;
            this.lblMacStyleText.Text = "macOS CapsLock";
            // 
            // toggleMacStyle
            // 
            this.toggleMacStyle.Location = new System.Drawing.Point(190, 73);
            this.toggleMacStyle.Name = "toggleMacStyle";
            this.toggleMacStyle.Properties.Appearance.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.toggleMacStyle.Properties.Appearance.Options.UseFont = true;
            this.toggleMacStyle.Properties.OffText = "关";
            this.toggleMacStyle.Properties.OnText = "开";
            this.toggleMacStyle.Size = new System.Drawing.Size(95, 27);
            this.toggleMacStyle.TabIndex = 2;
            this.toggleMacStyle.Toggled += new System.EventHandler(this.toggleMacStyle_Toggled);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "HomePage";
            this.Size = new System.Drawing.Size(681, 593);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupSwitches.ResumeLayout(false);
            this.groupSwitches.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toggleAutoStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLongPress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleHud.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleMacStyle.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.GroupBox groupSwitches;
        private System.Windows.Forms.Label lblMacStyleText;
        private DevExpress.XtraEditors.ToggleSwitch toggleMacStyle;
        private System.Windows.Forms.Label lblHudText;
        private DevExpress.XtraEditors.ToggleSwitch toggleHud;
        private System.Windows.Forms.Label lblLongPress;
        private System.Windows.Forms.NumericUpDown numLongPress;
        private System.Windows.Forms.Label lblLongPressUnit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.Label lblAutoStart;
        private DevExpress.XtraEditors.ToggleSwitch toggleAutoStart;
    }
}
