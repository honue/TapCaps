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
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblHint = new System.Windows.Forms.Label();
            this.groupSwitches = new System.Windows.Forms.GroupBox();
            this.chkKeyMapping = new System.Windows.Forms.CheckBox();
            this.chkTrayIcon = new System.Windows.Forms.CheckBox();
            this.lblLongPressUnit = new System.Windows.Forms.Label();
            this.numLongPress = new System.Windows.Forms.NumericUpDown();
            this.lblLongPress = new System.Windows.Forms.Label();
            this.chkHud = new System.Windows.Forms.CheckBox();
            this.chkMacStyle = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupSwitches.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLongPress)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 299F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(681, 593);
            this.tableLayoutPanel1.TabIndex = 1;
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
            this.groupSwitches.Controls.Add(this.chkKeyMapping);
            this.groupSwitches.Controls.Add(this.chkTrayIcon);
            this.groupSwitches.Controls.Add(this.lblLongPressUnit);
            this.groupSwitches.Controls.Add(this.numLongPress);
            this.groupSwitches.Controls.Add(this.lblLongPress);
            this.groupSwitches.Controls.Add(this.chkHud);
            this.groupSwitches.Controls.Add(this.chkMacStyle);
            this.groupSwitches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupSwitches.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupSwitches.Location = new System.Drawing.Point(18, 83);
            this.groupSwitches.Margin = new System.Windows.Forms.Padding(18, 3, 18, 3);
            this.groupSwitches.Name = "groupSwitches";
            this.groupSwitches.Size = new System.Drawing.Size(645, 293);
            this.groupSwitches.TabIndex = 2;
            this.groupSwitches.TabStop = false;
            this.groupSwitches.Text = "设置开关";
            // 
            // chkKeyMapping
            // 
            this.chkKeyMapping.AutoSize = true;
            this.chkKeyMapping.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkKeyMapping.Location = new System.Drawing.Point(24, 71);
            this.chkKeyMapping.Name = "chkKeyMapping";
            this.chkKeyMapping.Size = new System.Drawing.Size(168, 27);
            this.chkKeyMapping.TabIndex = 1;
            this.chkKeyMapping.Text = "启用按键映射功能";
            this.chkKeyMapping.UseVisualStyleBackColor = true;
            this.chkKeyMapping.CheckedChanged += new System.EventHandler(this.chkKeyMapping_CheckedChanged);
            // 
            // chkTrayIcon
            // 
            this.chkTrayIcon.AutoSize = true;
            this.chkTrayIcon.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkTrayIcon.Location = new System.Drawing.Point(24, 135);
            this.chkTrayIcon.Name = "chkTrayIcon";
            this.chkTrayIcon.Size = new System.Drawing.Size(236, 27);
            this.chkTrayIcon.TabIndex = 2;
            this.chkTrayIcon.Text = "在任务栏托盘显示程序图标";
            this.chkTrayIcon.UseVisualStyleBackColor = true;
            this.chkTrayIcon.CheckedChanged += new System.EventHandler(this.chkTrayIcon_CheckedChanged);
            // 
            // lblLongPressUnit
            // 
            this.lblLongPressUnit.AutoSize = true;
            this.lblLongPressUnit.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLongPressUnit.Location = new System.Drawing.Point(239, 181);
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
            this.numLongPress.Location = new System.Drawing.Point(153, 178);
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
            this.lblLongPress.Location = new System.Drawing.Point(22, 180);
            this.lblLongPress.Name = "lblLongPress";
            this.lblLongPress.Size = new System.Drawing.Size(112, 23);
            this.lblLongPress.TabIndex = 4;
            this.lblLongPress.Text = "长按阈值设置";
            // 
            // chkHud
            // 
            this.chkHud.AutoSize = true;
            this.chkHud.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkHud.Location = new System.Drawing.Point(24, 102);
            this.chkHud.Name = "chkHud";
            this.chkHud.Size = new System.Drawing.Size(183, 27);
            this.chkHud.TabIndex = 3;
            this.chkHud.Text = "显示 HUD 提示气泡";
            this.chkHud.UseVisualStyleBackColor = true;
            this.chkHud.CheckedChanged += new System.EventHandler(this.chkHud_CheckedChanged);
            // 
            // chkMacStyle
            // 
            this.chkMacStyle.AutoSize = true;
            this.chkMacStyle.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkMacStyle.Location = new System.Drawing.Point(24, 34);
            this.chkMacStyle.Name = "chkMacStyle";
            this.chkMacStyle.Size = new System.Drawing.Size(306, 27);
            this.chkMacStyle.TabIndex = 0;
            this.chkMacStyle.Text = "启用 macOS 风格的 CapsLock 行为";
            this.chkMacStyle.UseVisualStyleBackColor = true;
            this.chkMacStyle.CheckedChanged += new System.EventHandler(this.chkMacStyle_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(18, 382);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(18, 3, 18, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(645, 208);
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
            this.richTextBox.Size = new System.Drawing.Size(639, 180);
            this.richTextBox.TabIndex = 0;
            this.richTextBox.Text = "可以在这进行测试";
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "HomePage";
            this.Size = new System.Drawing.Size(681, 593);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupSwitches.ResumeLayout(false);
            this.groupSwitches.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLongPress)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.GroupBox groupSwitches;
        private System.Windows.Forms.CheckBox chkKeyMapping;
        private System.Windows.Forms.CheckBox chkMacStyle;
        private System.Windows.Forms.CheckBox chkHud;
        private System.Windows.Forms.CheckBox chkTrayIcon;
        private System.Windows.Forms.Label lblLongPress;
        private System.Windows.Forms.NumericUpDown numLongPress;
        private System.Windows.Forms.Label lblLongPressUnit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox richTextBox;
    }
}
