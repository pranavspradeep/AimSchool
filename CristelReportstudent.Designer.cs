namespace SchoolManagement
{
    partial class CristelReportstudent
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
            this.crpviewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btn_report = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // crpviewer1
            // 
            this.crpviewer1.ActiveViewIndex = -1;
            this.crpviewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crpviewer1.Location = new System.Drawing.Point(12, 65);
            this.crpviewer1.Name = "crpviewer1";
            this.crpviewer1.SelectionFormula = "";
            this.crpviewer1.Size = new System.Drawing.Size(662, 410);
            this.crpviewer1.TabIndex = 0;
            this.crpviewer1.ViewTimeSelectionFormula = "";
            // 
            // btn_report
            // 
            this.btn_report.Location = new System.Drawing.Point(265, 24);
            this.btn_report.Name = "btn_report";
            this.btn_report.Size = new System.Drawing.Size(75, 23);
            this.btn_report.TabIndex = 1;
            this.btn_report.Text = "ViewReport";
            this.btn_report.UseVisualStyleBackColor = true;
            this.btn_report.Click += new System.EventHandler(this.btn_report_Click);
            // 
            // CristelReportstudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 484);
            this.Controls.Add(this.btn_report);
            this.Controls.Add(this.crpviewer1);
            this.Name = "CristelReportstudent";
            this.Text = "CristelReportstudent";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crpviewer1;
        private System.Windows.Forms.Button btn_report;
    }
}