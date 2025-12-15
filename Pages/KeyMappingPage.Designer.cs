namespace TapCaps.Pages
{
    partial class KeyMappingPage
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
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblHint = new System.Windows.Forms.Label();
            this.btnAddMapping = new DevExpress.XtraEditors.SimpleButton();
            this.btnRemoveMapping = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Shortcuts = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ShortcutActions = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Font = new System.Drawing.Font("Microsoft YaHei UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHeader.Location = new System.Drawing.Point(34, 20);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(359, 40);
            this.lblHeader.TabIndex = 1;
            this.lblHeader.Text = "按键映射";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHint
            // 
            this.lblHint.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHint.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblHint.Location = new System.Drawing.Point(36, 60);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(554, 40);
            this.lblHint.TabIndex = 2;
            this.lblHint.Text = "在下方输入“源快捷键”与“目标快捷键”，格式如 Ctrl+Alt+K。";
            this.lblHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAddMapping
            // 
            this.btnAddMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddMapping.Location = new System.Drawing.Point(671, 34);
            this.btnAddMapping.Name = "btnAddMapping";
            this.btnAddMapping.Size = new System.Drawing.Size(101, 32);
            this.btnAddMapping.TabIndex = 3;
            this.btnAddMapping.Text = "新增映射";
            this.btnAddMapping.Click += new System.EventHandler(this.btnAddMapping_Click);
            // 
            // btnRemoveMapping
            // 
            this.btnRemoveMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveMapping.Location = new System.Drawing.Point(778, 34);
            this.btnRemoveMapping.Name = "btnRemoveMapping";
            this.btnRemoveMapping.Size = new System.Drawing.Size(105, 32);
            this.btnRemoveMapping.TabIndex = 4;
            this.btnRemoveMapping.Text = "删除选中";
            this.btnRemoveMapping.Click += new System.EventHandler(this.btnRemoveMapping_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(38, 110);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(845, 455);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Shortcuts,
            this.ShortcutActions});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // Shortcuts
            // 
            this.Shortcuts.Caption = "快捷键";
            this.Shortcuts.MinWidth = 25;
            this.Shortcuts.Name = "Shortcuts";
            this.Shortcuts.Visible = true;
            this.Shortcuts.VisibleIndex = 0;
            this.Shortcuts.Width = 94;
            // 
            // ShortcutActions
            // 
            this.ShortcutActions.Caption = "目的快捷键";
            this.ShortcutActions.MinWidth = 25;
            this.ShortcutActions.Name = "ShortcutActions";
            this.ShortcutActions.Visible = true;
            this.ShortcutActions.VisibleIndex = 1;
            this.ShortcutActions.Width = 94;
            // 
            // KeyMappingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRemoveMapping);
            this.Controls.Add(this.btnAddMapping);
            this.Controls.Add(this.lblHint);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.gridControl1);
            this.Name = "KeyMappingPage";
            this.Size = new System.Drawing.Size(924, 595);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblHint;
        private DevExpress.XtraEditors.SimpleButton btnAddMapping;
        private DevExpress.XtraEditors.SimpleButton btnRemoveMapping;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Shortcuts;
        private DevExpress.XtraGrid.Columns.GridColumn ShortcutActions;
    }
}
