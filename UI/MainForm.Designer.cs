namespace TapCaps.UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.fluentDesignFormContainer1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.AccordionControl = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.HomePageElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.KeyMappingPageElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.AboutPageElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.fluentFormDefaultManager = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.AccordionControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager)).BeginInit();
            this.SuspendLayout();
            // 
            // fluentDesignFormContainer1
            // 
            this.fluentDesignFormContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fluentDesignFormContainer1.Location = new System.Drawing.Point(181, 39);
            this.fluentDesignFormContainer1.Name = "fluentDesignFormContainer1";
            this.fluentDesignFormContainer1.Size = new System.Drawing.Size(919, 669);
            this.fluentDesignFormContainer1.TabIndex = 0;
            // 
            // AccordionControl
            // 
            this.AccordionControl.Appearance.AccordionControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.AccordionControl.Appearance.AccordionControl.Options.UseBackColor = true;
            this.AccordionControl.Appearance.Group.Hovered.ForeColor = System.Drawing.Color.White;
            this.AccordionControl.Appearance.Group.Hovered.Options.UseForeColor = true;
            this.AccordionControl.Appearance.Group.Normal.ForeColor = System.Drawing.Color.White;
            this.AccordionControl.Appearance.Group.Normal.Options.UseForeColor = true;
            this.AccordionControl.Appearance.Group.Pressed.ForeColor = System.Drawing.Color.White;
            this.AccordionControl.Appearance.Group.Pressed.Options.UseForeColor = true;
            this.AccordionControl.Appearance.Item.Hovered.ForeColor = System.Drawing.Color.White;
            this.AccordionControl.Appearance.Item.Hovered.Options.UseForeColor = true;
            this.AccordionControl.Appearance.Item.Normal.ForeColor = System.Drawing.Color.White;
            this.AccordionControl.Appearance.Item.Normal.Options.UseForeColor = true;
            this.AccordionControl.Appearance.Item.Pressed.ForeColor = System.Drawing.Color.White;
            this.AccordionControl.Appearance.Item.Pressed.Options.UseForeColor = true;
            this.AccordionControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.AccordionControl.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.HomePageElement,
            this.KeyMappingPageElement,
            this.AboutPageElement});
            this.AccordionControl.Location = new System.Drawing.Point(0, 39);
            this.AccordionControl.Name = "AccordionControl";
            this.AccordionControl.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Hidden;
            this.AccordionControl.Size = new System.Drawing.Size(181, 669);
            this.AccordionControl.TabIndex = 1;
            this.AccordionControl.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // HomePageElement
            // 
            this.HomePageElement.Appearance.Default.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HomePageElement.Appearance.Default.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.ControlText;
            this.HomePageElement.Appearance.Default.Options.UseFont = true;
            this.HomePageElement.Appearance.Default.Options.UseForeColor = true;
            this.HomePageElement.Expanded = true;
            this.HomePageElement.Height = 50;
            this.HomePageElement.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("HomePageElement.ImageOptions.SvgImage")));
            this.HomePageElement.Name = "HomePageElement";
            this.HomePageElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.HomePageElement.Text = "主  页";
            this.HomePageElement.Click += new System.EventHandler(this.HomePageElement_Click);
            // 
            // KeyMappingPageElement
            // 
            this.KeyMappingPageElement.Appearance.Default.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F);
            this.KeyMappingPageElement.Appearance.Default.ForeColor = System.Drawing.Color.Black;
            this.KeyMappingPageElement.Appearance.Default.Options.UseFont = true;
            this.KeyMappingPageElement.Appearance.Default.Options.UseForeColor = true;
            this.KeyMappingPageElement.Height = 50;
            this.KeyMappingPageElement.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("KeyMappingPageElement.ImageOptions.SvgImage")));
            this.KeyMappingPageElement.Name = "KeyMappingPageElement";
            this.KeyMappingPageElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.KeyMappingPageElement.Text = "按键映射";
            this.KeyMappingPageElement.Click += new System.EventHandler(this.KeyMappingPageElement_Click);
            // 
            // AboutPageElement
            // 
            this.AboutPageElement.Appearance.Default.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F);
            this.AboutPageElement.Appearance.Default.ForeColor = System.Drawing.Color.Black;
            this.AboutPageElement.Appearance.Default.Options.UseFont = true;
            this.AboutPageElement.Appearance.Default.Options.UseForeColor = true;
            this.AboutPageElement.Expanded = true;
            this.AboutPageElement.Height = 50;
            this.AboutPageElement.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("SettingsPageElement.ImageOptions.SvgImage")));
            this.AboutPageElement.Name = "AboutPageElement";
            this.AboutPageElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.AboutPageElement.Text = "关  于";
            this.AboutPageElement.Click += new System.EventHandler(this.AboutPageElement_Click);
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Manager = this.fluentFormDefaultManager;
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(1100, 39);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            // 
            // fluentFormDefaultManager
            // 
            this.fluentFormDefaultManager.Form = this;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 708);
            this.ControlContainer = this.fluentDesignFormContainer1;
            this.Controls.Add(this.fluentDesignFormContainer1);
            this.Controls.Add(this.AccordionControl);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("MainForm.IconOptions.Image")));
            this.Name = "MainForm";
            this.NavigationControl = this.AccordionControl;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TapCaps";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AccordionControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer fluentDesignFormContainer1;
        private DevExpress.XtraBars.Navigation.AccordionControl AccordionControl;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement HomePageElement;
        private DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager fluentFormDefaultManager;
        private DevExpress.XtraBars.Navigation.AccordionControlElement AboutPageElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement KeyMappingPageElement;
    }
}
