namespace Merlino
{
    partial class RibbonMenu : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public RibbonMenu()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RibbonMenu));
            this.tab1 = this.Factory.CreateRibbonTab();
            this.grpMerlino = this.Factory.CreateRibbonGroup();
            this.btnOpen = this.Factory.CreateRibbonButton();
            this.btnFilter = this.Factory.CreateRibbonButton();
            this.separator1 = this.Factory.CreateRibbonSeparator();
            this.brtnOpzioni = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.grpMerlino.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.grpMerlino);
            this.tab1.Label = "Merlino";
            this.tab1.Name = "tab1";
            // 
            // grpMerlino
            // 
            this.grpMerlino.Items.Add(this.btnOpen);
            this.grpMerlino.Items.Add(this.btnFilter);
            this.grpMerlino.Items.Add(this.separator1);
            this.grpMerlino.Items.Add(this.brtnOpzioni);
            this.grpMerlino.Name = "grpMerlino";
            // 
            // btnOpen
            // 
            this.btnOpen.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.Label = "Merlino";
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.ShowImage = true;
            this.btnOpen.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button1_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnFilter.Image = ((System.Drawing.Image)(resources.GetObject("btnFilter.Image")));
            this.btnFilter.Label = "Filtra RPO";
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.ShowImage = true;
            this.btnFilter.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnFilter_Click);
            // 
            // separator1
            // 
            this.separator1.Name = "separator1";
            // 
            // brtnOpzioni
            // 
            this.brtnOpzioni.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.brtnOpzioni.Image = ((System.Drawing.Image)(resources.GetObject("brtnOpzioni.Image")));
            this.brtnOpzioni.Label = "Opzioni";
            this.brtnOpzioni.Name = "brtnOpzioni";
            this.brtnOpzioni.ShowImage = true;
            this.brtnOpzioni.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.brtnOpzioni_Click);
            // 
            // RibbonMenu
            // 
            this.Name = "RibbonMenu";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.RibbonMenu_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.grpMerlino.ResumeLayout(false);
            this.grpMerlino.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpMerlino;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnOpen;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton brtnOpzioni;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnFilter;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator1;
    }

    partial class ThisRibbonCollection
    {
        internal RibbonMenu RibbonMenu
        {
            get { return this.GetRibbon<RibbonMenu>(); }
        }
    }
}
