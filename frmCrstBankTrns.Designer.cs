namespace SchoolManagement
{
    partial class frmCrstBankTrns
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
            this.btnreport = new System.Windows.Forms.Button();
            this.btnshow = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.Lblfrm = new System.Windows.Forms.Label();
            this.dtpb2 = new System.Windows.Forms.DateTimePicker();
            this.dtpb1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbAccNo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnreport
            // 
            this.btnreport.Location = new System.Drawing.Point(477, 152);
            this.btnreport.Name = "btnreport";
            this.btnreport.Size = new System.Drawing.Size(75, 23);
            this.btnreport.TabIndex = 13;
            this.btnreport.Text = "View Report";
            this.btnreport.UseVisualStyleBackColor = true;
            this.btnreport.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnshow
            // 
            this.btnshow.Location = new System.Drawing.Point(477, 112);
            this.btnshow.Name = "btnshow";
            this.btnshow.Size = new System.Drawing.Size(75, 23);
            this.btnshow.TabIndex = 12;
            this.btnshow.Text = "Show";
            this.btnshow.UseVisualStyleBackColor = true;
            this.btnshow.Click += new System.EventHandler(this.btnshow_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Location = new System.Drawing.Point(12, 243);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(592, 239);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "To";
            // 
            // Lblfrm
            // 
            this.Lblfrm.AutoSize = true;
            this.Lblfrm.Location = new System.Drawing.Point(66, 116);
            this.Lblfrm.Name = "Lblfrm";
            this.Lblfrm.Size = new System.Drawing.Size(30, 13);
            this.Lblfrm.TabIndex = 9;
            this.Lblfrm.Text = "From";
            // 
            // dtpb2
            // 
            this.dtpb2.Location = new System.Drawing.Point(163, 152);
            this.dtpb2.Name = "dtpb2";
            this.dtpb2.Size = new System.Drawing.Size(186, 20);
            this.dtpb2.TabIndex = 8;
            // 
            // dtpb1
            // 
            this.dtpb1.Location = new System.Drawing.Point(163, 109);
            this.dtpb1.Name = "dtpb1";
            this.dtpb1.Size = new System.Drawing.Size(186, 20);
            this.dtpb1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Account Number";
            // 
            // cmbAccNo
            // 
            this.cmbAccNo.FormattingEnabled = true;
            this.cmbAccNo.Location = new System.Drawing.Point(163, 70);
            this.cmbAccNo.Name = "cmbAccNo";
            this.cmbAccNo.Size = new System.Drawing.Size(186, 21);
            this.cmbAccNo.TabIndex = 15;
            this.cmbAccNo.SelectedIndexChanged += new System.EventHandler(this.cmbAccNo_SelectedIndexChanged);
            // 
            // frmCrstBankTrns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(617, 494);
            this.Controls.Add(this.cmbAccNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnreport);
            this.Controls.Add(this.btnshow);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Lblfrm);
            this.Controls.Add(this.dtpb2);
            this.Controls.Add(this.dtpb1);
            this.Name = "frmCrstBankTrns";
            this.Text = "frmCrstBankTrns";
            this.Load += new System.EventHandler(this.frmCrstBankTrns_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnreport;
        private System.Windows.Forms.Button btnshow;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Lblfrm;
        private System.Windows.Forms.DateTimePicker dtpb2;
        private System.Windows.Forms.DateTimePicker dtpb1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbAccNo;

    }
}