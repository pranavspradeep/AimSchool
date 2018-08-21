namespace SchoolManagement
{
    partial class FeeCollection
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
            this.btnsearch = new System.Windows.Forms.Button();
            this.r3 = new System.Windows.Forms.RadioButton();
            this.r2 = new System.Windows.Forms.RadioButton();
            this.r1 = new System.Windows.Forms.RadioButton();
            this.txtcls = new System.Windows.Forms.TextBox();
            this.txtrol = new System.Windows.Forms.TextBox();
            this.txt_Cname = new System.Windows.Forms.TextBox();
            this.dgvsview = new System.Windows.Forms.DataGridView();
            this.butPayFee = new System.Windows.Forms.Button();
            this.butReceipt = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsview)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnsearch
            // 
            this.btnsearch.Location = new System.Drawing.Point(373, 18);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(86, 92);
            this.btnsearch.TabIndex = 9;
            this.btnsearch.Text = "Search";
            this.btnsearch.UseVisualStyleBackColor = true;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // r3
            // 
            this.r3.AutoSize = true;
            this.r3.Location = new System.Drawing.Point(11, 90);
            this.r3.Name = "r3";
            this.r3.Size = new System.Drawing.Size(65, 17);
            this.r3.TabIndex = 8;
            this.r3.TabStop = true;
            this.r3.Text = "By Class";
            this.r3.UseVisualStyleBackColor = true;
            // 
            // r2
            // 
            this.r2.AutoSize = true;
            this.r2.Location = new System.Drawing.Point(11, 58);
            this.r2.Name = "r2";
            this.r2.Size = new System.Drawing.Size(127, 17);
            this.r2.TabIndex = 7;
            this.r2.TabStop = true;
            this.r2.Text = "By Admission Number";
            this.r2.UseVisualStyleBackColor = true;
            // 
            // r1
            // 
            this.r1.AutoSize = true;
            this.r1.Location = new System.Drawing.Point(11, 23);
            this.r1.Name = "r1";
            this.r1.Size = new System.Drawing.Size(68, 17);
            this.r1.TabIndex = 6;
            this.r1.TabStop = true;
            this.r1.Text = "By Name";
            this.r1.UseVisualStyleBackColor = true;
            // 
            // txtcls
            // 
            this.txtcls.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtcls.Location = new System.Drawing.Point(143, 92);
            this.txtcls.Name = "txtcls";
            this.txtcls.Size = new System.Drawing.Size(195, 20);
            this.txtcls.TabIndex = 2;
            // 
            // txtrol
            // 
            this.txtrol.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtrol.Location = new System.Drawing.Point(143, 57);
            this.txtrol.Name = "txtrol";
            this.txtrol.Size = new System.Drawing.Size(195, 20);
            this.txtrol.TabIndex = 1;
            // 
            // txt_Cname
            // 
            this.txt_Cname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_Cname.Location = new System.Drawing.Point(143, 20);
            this.txt_Cname.Name = "txt_Cname";
            this.txt_Cname.Size = new System.Drawing.Size(195, 20);
            this.txt_Cname.TabIndex = 0;
            // 
            // dgvsview
            // 
            this.dgvsview.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvsview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvsview.Location = new System.Drawing.Point(11, 8);
            this.dgvsview.Name = "dgvsview";
            this.dgvsview.RowTemplate.Height = 24;
            this.dgvsview.Size = new System.Drawing.Size(498, 197);
            this.dgvsview.TabIndex = 23;
            this.dgvsview.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvsview_CellClick);
            this.dgvsview.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvsview_CellContentClick);
            // 
            // butPayFee
            // 
            this.butPayFee.Location = new System.Drawing.Point(31, 11);
            this.butPayFee.Margin = new System.Windows.Forms.Padding(2);
            this.butPayFee.Name = "butPayFee";
            this.butPayFee.Size = new System.Drawing.Size(95, 30);
            this.butPayFee.TabIndex = 29;
            this.butPayFee.Text = "Pay Fee";
            this.butPayFee.UseVisualStyleBackColor = true;
            this.butPayFee.Click += new System.EventHandler(this.butPayFee_Click);
            // 
            // butReceipt
            // 
            this.butReceipt.Location = new System.Drawing.Point(393, 11);
            this.butReceipt.Margin = new System.Windows.Forms.Padding(2);
            this.butReceipt.Name = "butReceipt";
            this.butReceipt.Size = new System.Drawing.Size(95, 30);
            this.butReceipt.TabIndex = 32;
            this.butReceipt.Text = "Receipt";
            this.butReceipt.UseVisualStyleBackColor = true;
            this.butReceipt.Click += new System.EventHandler(this.butReceipt_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtrol);
            this.panel1.Controls.Add(this.txt_Cname);
            this.panel1.Controls.Add(this.txtcls);
            this.panel1.Controls.Add(this.r1);
            this.panel1.Controls.Add(this.btnsearch);
            this.panel1.Controls.Add(this.r2);
            this.panel1.Controls.Add(this.r3);
            this.panel1.Location = new System.Drawing.Point(10, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(525, 138);
            this.panel1.TabIndex = 33;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dgvsview);
            this.panel2.Location = new System.Drawing.Point(10, 151);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(525, 213);
            this.panel2.TabIndex = 34;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.butPayFee);
            this.panel3.Controls.Add(this.butReceipt);
            this.panel3.Location = new System.Drawing.Point(10, 370);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(525, 56);
            this.panel3.TabIndex = 35;
            // 
            // FeeCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(542, 433);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "FeeCollection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FeeCollection";
            this.Load += new System.EventHandler(this.FeeCollection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvsview)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.RadioButton r3;
        private System.Windows.Forms.RadioButton r2;
        private System.Windows.Forms.RadioButton r1;
        private System.Windows.Forms.TextBox txtcls;
        private System.Windows.Forms.TextBox txtrol;
        private System.Windows.Forms.TextBox txt_Cname;
        private System.Windows.Forms.Button butPayFee;
        private System.Windows.Forms.Button butReceipt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvsview;
    }
}