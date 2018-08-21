namespace SchoolManagement
{
    partial class MarkSheetrpt
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
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_Stdrd = new System.Windows.Forms.ComboBox();
            this.cmb_Divs = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Student = new System.Windows.Forms.TextBox();
            this.lstbx_Students = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cmb_Exam = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Right;
            this.crystalReportViewer1.Location = new System.Drawing.Point(203, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(851, 554);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crystalReportViewer1.Load += new System.EventHandler(this.crystalReportViewer1_Load);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Standard";
            // 
            // cmb_Stdrd
            // 
            this.cmb_Stdrd.FormattingEnabled = true;
            this.cmb_Stdrd.Items.AddRange(new object[] {
            "LKG",
            "UKG",
            "I",
            "II",
            "III",
            "IV",
            "V",
            "VI",
            "VII",
            "VIII",
            "IX",
            "X",
            "XI",
            "XII"});
            this.cmb_Stdrd.Location = new System.Drawing.Point(15, 80);
            this.cmb_Stdrd.Name = "cmb_Stdrd";
            this.cmb_Stdrd.Size = new System.Drawing.Size(154, 21);
            this.cmb_Stdrd.TabIndex = 1;
            this.cmb_Stdrd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_Stdrd_KeyPress);
            // 
            // cmb_Divs
            // 
            this.cmb_Divs.FormattingEnabled = true;
            this.cmb_Divs.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F"});
            this.cmb_Divs.Location = new System.Drawing.Point(15, 129);
            this.cmb_Divs.Name = "cmb_Divs";
            this.cmb_Divs.Size = new System.Drawing.Size(154, 21);
            this.cmb_Divs.TabIndex = 2;
            this.cmb_Divs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_Divs_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Division";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmb_Exam);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_Student);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmb_Stdrd);
            this.groupBox1.Controls.Add(this.cmb_Divs);
            this.groupBox1.Location = new System.Drawing.Point(12, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(185, 211);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Student";
            // 
            // txt_Student
            // 
            this.txt_Student.Location = new System.Drawing.Point(15, 174);
            this.txt_Student.Name = "txt_Student";
            this.txt_Student.Size = new System.Drawing.Size(154, 20);
            this.txt_Student.TabIndex = 3;
            this.txt_Student.TextChanged += new System.EventHandler(this.txt_Student_TextChanged);
            this.txt_Student.Enter += new System.EventHandler(this.txt_Student_Enter);
            this.txt_Student.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Student_KeyPress);
            // 
            // lstbx_Students
            // 
            this.lstbx_Students.FormattingEnabled = true;
            this.lstbx_Students.Location = new System.Drawing.Point(12, 217);
            this.lstbx_Students.Name = "lstbx_Students";
            this.lstbx_Students.Size = new System.Drawing.Size(185, 290);
            this.lstbx_Students.TabIndex = 4;
            this.lstbx_Students.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstbx_Students_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(46, 513);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 29);
            this.button1.TabIndex = 5;
            this.button1.Text = "View Report";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmb_Exam
            // 
            this.cmb_Exam.FormattingEnabled = true;
            this.cmb_Exam.Location = new System.Drawing.Point(15, 31);
            this.cmb_Exam.Name = "cmb_Exam";
            this.cmb_Exam.Size = new System.Drawing.Size(154, 21);
            this.cmb_Exam.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Exam";
            // 
            // MarkSheetrpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 554);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lstbx_Students);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "MarkSheetrpt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mark Sheet";
            this.Load += new System.EventHandler(this.MarkSheetrpt_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_Stdrd;
        private System.Windows.Forms.ComboBox cmb_Divs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_Student;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstbx_Students;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_Exam;


    }
}