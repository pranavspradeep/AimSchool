namespace SchoolManagement
{
    partial class FeesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeesForm));
            this.button3 = new System.Windows.Forms.Button();
            this.butQstnPrpsn = new System.Windows.Forms.Button();
            this.butExam = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(231, 150);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 34);
            this.button3.TabIndex = 13;
            this.button3.Text = "Fee Collection";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // butQstnPrpsn
            // 
            this.butQstnPrpsn.Enabled = false;
            this.butQstnPrpsn.Location = new System.Drawing.Point(231, 109);
            this.butQstnPrpsn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.butQstnPrpsn.Name = "butQstnPrpsn";
            this.butQstnPrpsn.Size = new System.Drawing.Size(100, 34);
            this.butQstnPrpsn.TabIndex = 12;
            this.butQstnPrpsn.Text = "Add Other Fee";
            this.butQstnPrpsn.UseVisualStyleBackColor = true;
            this.butQstnPrpsn.Click += new System.EventHandler(this.butQstnPrpsn_Click);
            // 
            // butExam
            // 
            this.butExam.Enabled = false;
            this.butExam.Location = new System.Drawing.Point(231, 66);
            this.butExam.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.butExam.Name = "butExam";
            this.butExam.Size = new System.Drawing.Size(100, 34);
            this.butExam.TabIndex = 11;
            this.butExam.Text = "Add Tution Fee";
            this.butExam.UseVisualStyleBackColor = true;
            this.butExam.Click += new System.EventHandler(this.butExam_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(18, 23);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(188, 162);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(231, 23);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 34);
            this.button1.TabIndex = 14;
            this.button1.Text = "Add  Fee";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FeesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 210);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.butQstnPrpsn);
            this.Controls.Add(this.butExam);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "FeesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FeesForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button butQstnPrpsn;
        private System.Windows.Forms.Button butExam;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
    }
}