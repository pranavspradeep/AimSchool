namespace SchoolManagement
{
    partial class Student_Promotion
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Srch = new System.Windows.Forms.Button();
            this.cmb_Div = new System.Windows.Forms.ComboBox();
            this.cmb_Standard = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Submit = new System.Windows.Forms.Button();
            this.lstbx_Students = new System.Windows.Forms.ListBox();
            this.btn_canselection = new System.Windows.Forms.Button();
            this.txt_Searchstud = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Standard";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Srch);
            this.groupBox1.Controls.Add(this.cmb_Div);
            this.groupBox1.Controls.Add(this.cmb_Standard);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(23, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(401, 97);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // btn_Srch
            // 
            this.btn_Srch.Location = new System.Drawing.Point(293, 38);
            this.btn_Srch.Name = "btn_Srch";
            this.btn_Srch.Size = new System.Drawing.Size(88, 46);
            this.btn_Srch.TabIndex = 8;
            this.btn_Srch.Text = "Search";
            this.btn_Srch.UseVisualStyleBackColor = true;
            this.btn_Srch.Click += new System.EventHandler(this.btn_Srch_Click);
            // 
            // cmb_Div
            // 
            this.cmb_Div.FormattingEnabled = true;
            this.cmb_Div.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F"});
            this.cmb_Div.Location = new System.Drawing.Point(125, 63);
            this.cmb_Div.Name = "cmb_Div";
            this.cmb_Div.Size = new System.Drawing.Size(140, 21);
            this.cmb_Div.TabIndex = 7;
            this.cmb_Div.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_Div_KeyPress);
            // 
            // cmb_Standard
            // 
            this.cmb_Standard.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cmb_Standard.FormattingEnabled = true;
            this.cmb_Standard.Items.AddRange(new object[] {
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
            this.cmb_Standard.Location = new System.Drawing.Point(125, 22);
            this.cmb_Standard.Name = "cmb_Standard";
            this.cmb_Standard.Size = new System.Drawing.Size(140, 21);
            this.cmb_Standard.TabIndex = 0;
            this.cmb_Standard.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_Standard_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Division";
            
            // 
            // btn_Submit
            // 
            this.btn_Submit.Location = new System.Drawing.Point(316, 478);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(77, 30);
            this.btn_Submit.TabIndex = 9;
            this.btn_Submit.Text = "Submit";
            this.btn_Submit.UseVisualStyleBackColor = true;
            this.btn_Submit.Click += new System.EventHandler(this.btn_Submit_Click);
            // 
            // lstbx_Students
            // 
            this.lstbx_Students.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstbx_Students.FormattingEnabled = true;
            this.lstbx_Students.ItemHeight = 15;
            this.lstbx_Students.Location = new System.Drawing.Point(63, 141);
            this.lstbx_Students.Name = "lstbx_Students";
            this.lstbx_Students.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstbx_Students.Size = new System.Drawing.Size(330, 319);
            this.lstbx_Students.TabIndex = 10;
            this.lstbx_Students.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstbx_Students_KeyPress);
            // 
            // btn_canselection
            // 
            this.btn_canselection.Location = new System.Drawing.Point(206, 478);
            this.btn_canselection.Name = "btn_canselection";
            this.btn_canselection.Size = new System.Drawing.Size(104, 30);
            this.btn_canselection.TabIndex = 11;
            this.btn_canselection.Text = "Cancel Selection";
            this.btn_canselection.UseVisualStyleBackColor = true;
            this.btn_canselection.Click += new System.EventHandler(this.btn_canselection_Click);
            // 
            // txt_Searchstud
            // 
            // 
            // 
            // 
            this.txt_Searchstud.Border.Class = "TextBoxBorder";
            this.txt_Searchstud.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_Searchstud.Location = new System.Drawing.Point(233, 115);
            this.txt_Searchstud.Name = "txt_Searchstud";
            this.txt_Searchstud.Size = new System.Drawing.Size(160, 20);
            this.txt_Searchstud.TabIndex = 13;
            this.txt_Searchstud.WatermarkFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Searchstud.WatermarkText = "Search Student";
            this.txt_Searchstud.TextChanged += new System.EventHandler(this.txt_Searchstud_TextChanged);
            this.txt_Searchstud.Enter += new System.EventHandler(this.txt_Searchstud_Enter);
            // 
            // Student_Promotion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 520);
            this.Controls.Add(this.txt_Searchstud);
            this.Controls.Add(this.btn_canselection);
            this.Controls.Add(this.lstbx_Students);
            this.Controls.Add(this.btn_Submit);
            this.Controls.Add(this.groupBox1);
            this.Name = "Student_Promotion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student_Promotion";
           
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmb_Div;
        private System.Windows.Forms.ComboBox cmb_Standard;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Srch;
        private System.Windows.Forms.Button btn_Submit;
        private System.Windows.Forms.ListBox lstbx_Students;
        private System.Windows.Forms.Button btn_canselection;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_Searchstud;
    }
}