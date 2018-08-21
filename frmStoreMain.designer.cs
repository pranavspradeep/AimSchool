namespace SchoolManagement
{
    partial class frmStoreMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStoreMain));
            this.tsIMS = new System.Windows.Forms.ToolStrip();
            this.tsbSupplier = new System.Windows.Forms.ToolStripButton();
            this.tsbItem = new System.Windows.Forms.ToolStripButton();
            this.tsbStock = new System.Windows.Forms.ToolStripButton();
            this.tsbBilling = new System.Windows.Forms.ToolStripButton();
            this.tsbReports = new System.Windows.Forms.ToolStripSplitButton();
            this.tsmSearchInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbTools = new System.Windows.Forms.ToolStripSplitButton();
            this.tsbCalc = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbNotePad = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbAbout = new System.Windows.Forms.ToolStripButton();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.previousBillsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsIMS.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsIMS
            // 
            this.tsIMS.AutoSize = false;
            this.tsIMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSupplier,
            this.tsbItem,
            this.tsbStock,
            this.tsbBilling,
            this.tsbReports,
            this.tsbTools,
            this.tsbAbout,
            this.tsbExit});
            this.tsIMS.Location = new System.Drawing.Point(0, 0);
            this.tsIMS.Name = "tsIMS";
            this.tsIMS.Size = new System.Drawing.Size(793, 50);
            this.tsIMS.TabIndex = 1;
            // 
            // tsbSupplier
            // 
            this.tsbSupplier.Image = ((System.Drawing.Image)(resources.GetObject("tsbSupplier.Image")));
            this.tsbSupplier.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSupplier.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSupplier.Name = "tsbSupplier";
            this.tsbSupplier.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.tsbSupplier.Size = new System.Drawing.Size(180, 47);
            this.tsbSupplier.Text = "Suppliers/Customer [F1]";
            this.tsbSupplier.Click += new System.EventHandler(this.tsbSupplier_Click);
            // 
            // tsbItem
            // 
            this.tsbItem.Image = ((System.Drawing.Image)(resources.GetObject("tsbItem.Image")));
            this.tsbItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbItem.Name = "tsbItem";
            this.tsbItem.Size = new System.Drawing.Size(123, 47);
            this.tsbItem.Text = "Add Item [F2]";
            this.tsbItem.Click += new System.EventHandler(this.tsbItem_Click);
            // 
            // tsbStock
            // 
            this.tsbStock.Image = ((System.Drawing.Image)(resources.GetObject("tsbStock.Image")));
            this.tsbStock.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbStock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStock.Name = "tsbStock";
            this.tsbStock.Size = new System.Drawing.Size(103, 47);
            this.tsbStock.Text = "Stock [F3]";
            this.tsbStock.Click += new System.EventHandler(this.tsbStock_Click);
            // 
            // tsbBilling
            // 
            this.tsbBilling.Image = ((System.Drawing.Image)(resources.GetObject("tsbBilling.Image")));
            this.tsbBilling.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbBilling.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBilling.Name = "tsbBilling";
            this.tsbBilling.Size = new System.Drawing.Size(107, 47);
            this.tsbBilling.Text = "Billing [F4]";
            this.tsbBilling.Click += new System.EventHandler(this.tsbBilling_Click);
            // 
            // tsbReports
            // 
            this.tsbReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSearchInvoice,
            this.previousBillsToolStripMenuItem});
            this.tsbReports.Image = ((System.Drawing.Image)(resources.GetObject("tsbReports.Image")));
            this.tsbReports.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbReports.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbReports.Name = "tsbReports";
            this.tsbReports.Size = new System.Drawing.Size(103, 47);
            this.tsbReports.Text = "Reports";
            // 
            // tsmSearchInvoice
            // 
            this.tsmSearchInvoice.Image = ((System.Drawing.Image)(resources.GetObject("tsmSearchInvoice.Image")));
            this.tsmSearchInvoice.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmSearchInvoice.Name = "tsmSearchInvoice";
            this.tsmSearchInvoice.Size = new System.Drawing.Size(200, 70);
            this.tsmSearchInvoice.Text = "Sales Report";
            this.tsmSearchInvoice.Click += new System.EventHandler(this.tsmSearchInvoice_Click);
            // 
            // tsbTools
            // 
            this.tsbTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCalc,
            this.tsbNotePad});
            this.tsbTools.Image = ((System.Drawing.Image)(resources.GetObject("tsbTools.Image")));
            this.tsbTools.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbTools.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTools.Name = "tsbTools";
            this.tsbTools.Size = new System.Drawing.Size(92, 47);
            this.tsbTools.Text = "Tools";
            this.tsbTools.ButtonClick += new System.EventHandler(this.tsbTools_ButtonClick);
            this.tsbTools.MouseEnter += new System.EventHandler(this.tsbTools_MouseEnter);
            // 
            // tsbCalc
            // 
            this.tsbCalc.Image = ((System.Drawing.Image)(resources.GetObject("tsbCalc.Image")));
            this.tsbCalc.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbCalc.Name = "tsbCalc";
            this.tsbCalc.Size = new System.Drawing.Size(175, 46);
            this.tsbCalc.Text = "Calculator [F8]";
            this.tsbCalc.Click += new System.EventHandler(this.tsbCalc_Click);
            // 
            // tsbNotePad
            // 
            this.tsbNotePad.Image = ((System.Drawing.Image)(resources.GetObject("tsbNotePad.Image")));
            this.tsbNotePad.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbNotePad.Name = "tsbNotePad";
            this.tsbNotePad.Size = new System.Drawing.Size(175, 46);
            this.tsbNotePad.Text = "Notepad [F9]";
            this.tsbNotePad.Click += new System.EventHandler(this.tsbNotePad_Click);
            // 
            // tsbAbout
            // 
            this.tsbAbout.Image = ((System.Drawing.Image)(resources.GetObject("tsbAbout.Image")));
            this.tsbAbout.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAbout.Name = "tsbAbout";
            this.tsbAbout.Size = new System.Drawing.Size(84, 44);
            this.tsbAbout.Text = "About";
            // 
            // tsbExit
            // 
            this.tsbExit.Image = ((System.Drawing.Image)(resources.GetObject("tsbExit.Image")));
            this.tsbExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(98, 44);
            this.tsbExit.Text = "Exit [F10]";
            this.tsbExit.Click += new System.EventHandler(this.tsbExit_Click);
            // 
            // previousBillsToolStripMenuItem
            // 
            this.previousBillsToolStripMenuItem.Image = global::SchoolManagement.Properties.Resources.Book;
            this.previousBillsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.previousBillsToolStripMenuItem.Name = "previousBillsToolStripMenuItem";
            this.previousBillsToolStripMenuItem.Size = new System.Drawing.Size(200, 70);
            this.previousBillsToolStripMenuItem.Text = "Previous Bills";
            this.previousBillsToolStripMenuItem.Click += new System.EventHandler(this.previousBillsToolStripMenuItem_Click);
            // 
            // frmStoreMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 390);
            this.ControlBox = false;
            this.Controls.Add(this.tsIMS);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.IsMdiContainer = true;
            this.Name = "frmStoreMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmStoreMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmStoreMain_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmStoreMain_KeyUp);
            this.tsIMS.ResumeLayout(false);
            this.tsIMS.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsIMS;
        private System.Windows.Forms.ToolStripButton tsbSupplier;
        private System.Windows.Forms.ToolStripButton tsbItem;
        private System.Windows.Forms.ToolStripButton tsbStock;
        private System.Windows.Forms.ToolStripButton tsbBilling;
        private System.Windows.Forms.ToolStripSplitButton tsbReports;
        private System.Windows.Forms.ToolStripMenuItem tsmSearchInvoice;
        private System.Windows.Forms.ToolStripSplitButton tsbTools;
        private System.Windows.Forms.ToolStripMenuItem tsbCalc;
        private System.Windows.Forms.ToolStripMenuItem tsbNotePad;
        private System.Windows.Forms.ToolStripButton tsbAbout;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.ToolStripMenuItem previousBillsToolStripMenuItem;
    }
}