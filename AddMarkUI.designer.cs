namespace SchoolManagement
{
    partial class AddMarkUI
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
            this.dgvClassDetaits = new System.Windows.Forms.DataGridView();
            this.dgvStddetails = new System.Windows.Forms.DataGridView();
            this.lblSelectExam = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtmark = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnViewRpt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClassDetaits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStddetails)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvClassDetaits
            // 
            this.dgvClassDetaits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClassDetaits.Location = new System.Drawing.Point(8, 16);
            this.dgvClassDetaits.Name = "dgvClassDetaits";
            this.dgvClassDetaits.RowTemplate.Height = 24;
            this.dgvClassDetaits.Size = new System.Drawing.Size(345, 307);
            this.dgvClassDetaits.TabIndex = 0;
            this.dgvClassDetaits.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClassDetaits_CellClick);
            // 
            // dgvStddetails
            // 
            this.dgvStddetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStddetails.Location = new System.Drawing.Point(-2, 16);
            this.dgvStddetails.Name = "dgvStddetails";
            this.dgvStddetails.Size = new System.Drawing.Size(487, 221);
            this.dgvStddetails.TabIndex = 1;
            this.dgvStddetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStddetails_CellClick);
            this.dgvStddetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStddetails_CellClick);
            // 
            // lblSelectExam
            // 
            this.lblSelectExam.AutoSize = true;
            this.lblSelectExam.Location = new System.Drawing.Point(16, 4);
            this.lblSelectExam.Name = "lblSelectExam";
            this.lblSelectExam.Size = new System.Drawing.Size(66, 13);
            this.lblSelectExam.TabIndex = 2;
            this.lblSelectExam.Text = "Select Exam";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(19, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(160, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(239, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Enter Mark";
            // 
            // txtmark
            // 
            this.txtmark.Location = new System.Drawing.Point(242, 20);
            this.txtmark.Name = "txtmark";
            this.txtmark.Size = new System.Drawing.Size(160, 20);
            this.txtmark.TabIndex = 1;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(242, 63);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(77, 23);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dgvClassDetaits);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(369, 339);
            this.panel1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Select Class";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dgvStddetails);
            this.panel2.Location = new System.Drawing.Point(377, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(493, 245);
            this.panel2.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Select Student";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.btnViewRpt);
            this.panel3.Controls.Add(this.comboBox1);
            this.panel3.Controls.Add(this.txtmark);
            this.panel3.Controls.Add(this.btnSubmit);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.lblSelectExam);
            this.panel3.Location = new System.Drawing.Point(377, 255);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(493, 93);
            this.panel3.TabIndex = 9;
            // 
            // btnViewRpt
            // 
            this.btnViewRpt.Location = new System.Drawing.Point(327, 63);
            this.btnViewRpt.Name = "btnViewRpt";
            this.btnViewRpt.Size = new System.Drawing.Size(75, 23);
            this.btnViewRpt.TabIndex = 5;
            this.btnViewRpt.Text = "View Report";
            this.btnViewRpt.UseVisualStyleBackColor = true;
            this.btnViewRpt.Click += new System.EventHandler(this.btnViewRpt_Click);
            // 
            // AddMarkUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(887, 359);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "AddMarkUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddMarkUI";
            this.Load += new System.EventHandler(this.AddMarkUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClassDetaits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStddetails)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvClassDetaits;
        private System.Windows.Forms.DataGridView dgvStddetails;
        private System.Windows.Forms.Label lblSelectExam;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtmark;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnViewRpt;
    }
}