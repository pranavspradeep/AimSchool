namespace SchoolManagement
{
    partial class frmBankBalance
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
            this.btnSave = new System.Windows.Forms.Button();
            this.txtIFSCcode = new System.Windows.Forms.TextBox();
            this.txtbankname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtamount = new System.Windows.Forms.TextBox();
            this.cmbtype = new System.Windows.Forms.ComboBox();
            this.cmbAccNo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(288, 308);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtIFSCcode
            // 
            this.txtIFSCcode.BackColor = System.Drawing.SystemColors.Menu;
            this.txtIFSCcode.Enabled = false;
            this.txtIFSCcode.Location = new System.Drawing.Point(166, 148);
            this.txtIFSCcode.Name = "txtIFSCcode";
            this.txtIFSCcode.Size = new System.Drawing.Size(167, 20);
            this.txtIFSCcode.TabIndex = 12;
            this.txtIFSCcode.AcceptsTabChanged += new System.EventHandler(this.cmbAccNo_SelectedIndexChanged);
            // 
            // txtbankname
            // 
            this.txtbankname.BackColor = System.Drawing.SystemColors.Window;
            this.txtbankname.Enabled = false;
            this.txtbankname.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtbankname.Location = new System.Drawing.Point(166, 110);
            this.txtbankname.Name = "txtbankname";
            this.txtbankname.Size = new System.Drawing.Size(167, 20);
            this.txtbankname.TabIndex = 11;
            this.txtbankname.AcceptsTabChanged += new System.EventHandler(this.cmbAccNo_SelectedIndexChanged);
            this.txtbankname.TextChanged += new System.EventHandler(this.cmbAccNo_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(55, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "IFSC Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Bank Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Account Number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Ammount";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Type";
            // 
            // txtamount
            // 
            this.txtamount.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtamount.Location = new System.Drawing.Point(166, 186);
            this.txtamount.Name = "txtamount";
            this.txtamount.Size = new System.Drawing.Size(83, 20);
            this.txtamount.TabIndex = 16;
            this.txtamount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmbtype
            // 
            this.cmbtype.FormattingEnabled = true;
            this.cmbtype.Items.AddRange(new object[] {
            "Debit",
            "Credit"});
            this.cmbtype.Location = new System.Drawing.Point(166, 225);
            this.cmbtype.Name = "cmbtype";
            this.cmbtype.Size = new System.Drawing.Size(83, 21);
            this.cmbtype.TabIndex = 17;
            // 
            // cmbAccNo
            // 
            this.cmbAccNo.FormattingEnabled = true;
            this.cmbAccNo.Location = new System.Drawing.Point(166, 74);
            this.cmbAccNo.Name = "cmbAccNo";
            this.cmbAccNo.Size = new System.Drawing.Size(167, 21);
            this.cmbAccNo.TabIndex = 18;
            this.cmbAccNo.SelectedIndexChanged += new System.EventHandler(this.cmbAccNo_SelectedIndexChanged);
            this.cmbAccNo.SelectedValueChanged += new System.EventHandler(this.cmbAccNo_SelectedIndexChanged);
            // 
            // frmBankBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(478, 384);
            this.Controls.Add(this.cmbAccNo);
            this.Controls.Add(this.cmbtype);
            this.Controls.Add(this.txtamount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtIFSCcode);
            this.Controls.Add(this.txtbankname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmBankBalance";
            this.Text = "frmBankBalance";
            this.Load += new System.EventHandler(this.frmBankBalance_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtIFSCcode;
        private System.Windows.Forms.TextBox txtbankname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtamount;
        private System.Windows.Forms.ComboBox cmbtype;
        private System.Windows.Forms.ComboBox cmbAccNo;
    }
}