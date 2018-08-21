namespace SchoolManagement
{
    partial class BusForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BusForm));
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.butQstnPrpsn = new System.Windows.Forms.Button();
            this.butExam = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(229, 148);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 34);
            this.button4.TabIndex = 14;
            this.button4.Text = "Delete Route";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(229, 106);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 34);
            this.button3.TabIndex = 13;
            this.button3.Text = "Assign Route To Student";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // butQstnPrpsn
            // 
            this.butQstnPrpsn.Location = new System.Drawing.Point(229, 63);
            this.butQstnPrpsn.Margin = new System.Windows.Forms.Padding(2);
            this.butQstnPrpsn.Name = "butQstnPrpsn";
            this.butQstnPrpsn.Size = new System.Drawing.Size(100, 34);
            this.butQstnPrpsn.TabIndex = 12;
            this.butQstnPrpsn.Text = "Add Route Point";
            this.butQstnPrpsn.UseVisualStyleBackColor = true;
            this.butQstnPrpsn.Click += new System.EventHandler(this.butQstnPrpsn_Click);
            // 
            // butExam
            // 
            this.butExam.Location = new System.Drawing.Point(229, 20);
            this.butExam.Margin = new System.Windows.Forms.Padding(2);
            this.butExam.Name = "butExam";
            this.butExam.Size = new System.Drawing.Size(100, 34);
            this.butExam.TabIndex = 11;
            this.butExam.Text = "Add Bus Route";
            this.butExam.UseVisualStyleBackColor = true;
            this.butExam.Click += new System.EventHandler(this.butExam_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(16, 20);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(188, 162);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // BusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 205);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.butQstnPrpsn);
            this.Controls.Add(this.butExam);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BusForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BusForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button butQstnPrpsn;
        private System.Windows.Forms.Button butExam;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}