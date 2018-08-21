namespace school
{
    partial class transferstudent
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
            this.btntransfer = new System.Windows.Forms.Button();
            this.Dgv1 = new System.Windows.Forms.DataGridView();
            this.cmbbox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cachedFeeReport1 = new SchoolManagement.CachedFeeReport();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // btntransfer
            // 
            this.btntransfer.Location = new System.Drawing.Point(592, 291);
            this.btntransfer.Name = "btntransfer";
            this.btntransfer.Size = new System.Drawing.Size(75, 23);
            this.btntransfer.TabIndex = 0;
            this.btntransfer.Text = "transfer";
            this.btntransfer.UseVisualStyleBackColor = true;
            this.btntransfer.Click += new System.EventHandler(this.btntransfer_Click);
            // 
            // Dgv1
            // 
            this.Dgv1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv1.Location = new System.Drawing.Point(37, 22);
            this.Dgv1.Name = "Dgv1";
            this.Dgv1.Size = new System.Drawing.Size(643, 225);
            this.Dgv1.TabIndex = 1;
            // 
            // cmbbox1
            // 
            this.cmbbox1.FormattingEnabled = true;
            this.cmbbox1.Location = new System.Drawing.Point(205, 293);
            this.cmbbox1.Name = "cmbbox1";
            this.cmbbox1.Size = new System.Drawing.Size(77, 21);
            this.cmbbox1.TabIndex = 2;
            this.cmbbox1.SelectedIndexChanged += new System.EventHandler(this.cmbbox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 296);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select Current Year";
            // 
            // transferstudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(720, 360);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbbox1);
            this.Controls.Add(this.Dgv1);
            this.Controls.Add(this.btntransfer);
            this.DoubleBuffered = true;
            this.Name = "transferstudent";
            this.Text = "transferstudent";
            this.Load += new System.EventHandler(this.transferstudent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btntransfer;
        private System.Windows.Forms.DataGridView Dgv1;
        private System.Windows.Forms.ComboBox cmbbox1;
        private System.Windows.Forms.Label label1;
        private SchoolManagement.CachedFeeReport cachedFeeReport1;
    }
}