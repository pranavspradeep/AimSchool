namespace SchoolManagement
{
    partial class AttendanceReport
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
            this.pnl_studdetails = new System.Windows.Forms.Panel();
            this.btn_Select = new System.Windows.Forms.Button();
            this.dgv_Studlist = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmb_Division = new System.Windows.Forms.ComboBox();
            this.cmb_Standard = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Student = new System.Windows.Forms.TextBox();
            this.pnl_mode = new System.Windows.Forms.Panel();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btn_classwise = new DevComponents.DotNetBar.ButtonX();
            this.btn_studwise = new DevComponents.DotNetBar.ButtonX();
            this.dtp_classwise = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_ViewReport = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.pnl_studdetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Studlist)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.pnl_mode.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(12, 69);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(879, 496);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // pnl_studdetails
            // 
            this.pnl_studdetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_studdetails.Controls.Add(this.btn_Select);
            this.pnl_studdetails.Controls.Add(this.dgv_Studlist);
            this.pnl_studdetails.Controls.Add(this.groupBox1);
            this.pnl_studdetails.Location = new System.Drawing.Point(190, 135);
            this.pnl_studdetails.Name = "pnl_studdetails";
            this.pnl_studdetails.Size = new System.Drawing.Size(448, 360);
            this.pnl_studdetails.TabIndex = 1;
            this.pnl_studdetails.Visible = false;
            // 
            // btn_Select
            // 
            this.btn_Select.Location = new System.Drawing.Point(180, 330);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(75, 23);
            this.btn_Select.TabIndex = 5;
            this.btn_Select.Text = "Select";
            this.btn_Select.UseVisualStyleBackColor = true;
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // dgv_Studlist
            // 
            this.dgv_Studlist.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgv_Studlist.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_Studlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Studlist.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dgv_Studlist.Location = new System.Drawing.Point(19, 171);
            this.dgv_Studlist.MultiSelect = false;
            this.dgv_Studlist.Name = "dgv_Studlist";
            this.dgv_Studlist.Size = new System.Drawing.Size(399, 145);
            this.dgv_Studlist.TabIndex = 4;
            this.dgv_Studlist.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Studlist_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmb_Division);
            this.groupBox1.Controls.Add(this.cmb_Standard);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_Student);
            this.groupBox1.Location = new System.Drawing.Point(19, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(399, 151);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Student Details";
            // 
            // cmb_Division
            // 
            this.cmb_Division.FormattingEnabled = true;
            this.cmb_Division.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F"});
            this.cmb_Division.Location = new System.Drawing.Point(147, 71);
            this.cmb_Division.Name = "cmb_Division";
            this.cmb_Division.Size = new System.Drawing.Size(145, 21);
            this.cmb_Division.TabIndex = 5;
            // 
            // cmb_Standard
            // 
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
            this.cmb_Standard.Location = new System.Drawing.Point(147, 36);
            this.cmb_Standard.Name = "cmb_Standard";
            this.cmb_Standard.Size = new System.Drawing.Size(145, 21);
            this.cmb_Standard.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Division";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Standard";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Student";
            // 
            // txt_Student
            // 
            this.txt_Student.Location = new System.Drawing.Point(147, 109);
            this.txt_Student.Name = "txt_Student";
            this.txt_Student.Size = new System.Drawing.Size(145, 20);
            this.txt_Student.TabIndex = 0;
            this.txt_Student.TextChanged += new System.EventHandler(this.txt_Student_TextChanged);
            this.txt_Student.Enter += new System.EventHandler(this.txt_Student_Enter);
            // 
            // pnl_mode
            // 
            this.pnl_mode.Controls.Add(this.groupPanel1);
            this.pnl_mode.Location = new System.Drawing.Point(236, 221);
            this.pnl_mode.Name = "pnl_mode";
            this.pnl_mode.Size = new System.Drawing.Size(349, 173);
            this.pnl_mode.TabIndex = 6;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.btn_classwise);
            this.groupPanel1.Controls.Add(this.btn_studwise);
            this.groupPanel1.Location = new System.Drawing.Point(23, 16);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(306, 142);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.Class = "";
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.Class = "";
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.Class = "";
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 0;
            this.groupPanel1.Text = "Select Mode";
            // 
            // btn_classwise
            // 
            this.btn_classwise.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_classwise.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_classwise.Location = new System.Drawing.Point(161, 40);
            this.btn_classwise.Name = "btn_classwise";
            this.btn_classwise.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btn_classwise.Size = new System.Drawing.Size(90, 45);
            this.btn_classwise.Style = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.btn_classwise.TabIndex = 0;
            this.btn_classwise.Text = "Class Wise";
            this.btn_classwise.Click += new System.EventHandler(this.btn_classwise_Click);
            // 
            // btn_studwise
            // 
            this.btn_studwise.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_studwise.BackColor = System.Drawing.SystemColors.Control;
            this.btn_studwise.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_studwise.Enabled = false;
            this.btn_studwise.Location = new System.Drawing.Point(43, 40);
            this.btn_studwise.Name = "btn_studwise";
            this.btn_studwise.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btn_studwise.Size = new System.Drawing.Size(90, 45);
            this.btn_studwise.Style = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.btn_studwise.TabIndex = 0;
            this.btn_studwise.Text = "Student Wise";
            this.btn_studwise.Click += new System.EventHandler(this.btn_studwise_Click);
            // 
            // dtp_classwise
            // 
            this.dtp_classwise.Location = new System.Drawing.Point(15, 23);
            this.dtp_classwise.Name = "dtp_classwise";
            this.dtp_classwise.Size = new System.Drawing.Size(200, 20);
            this.dtp_classwise.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_ViewReport);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(12, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(739, 63);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Visible = false;
            // 
            // btn_ViewReport
            // 
            this.btn_ViewReport.Location = new System.Drawing.Point(614, 28);
            this.btn_ViewReport.Name = "btn_ViewReport";
            this.btn_ViewReport.Size = new System.Drawing.Size(75, 23);
            this.btn_ViewReport.TabIndex = 9;
            this.btn_ViewReport.Text = "View Report";
            this.btn_ViewReport.UseVisualStyleBackColor = true;
            this.btn_ViewReport.Click += new System.EventHandler(this.btn_ViewReport_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dtp_classwise);
            this.groupBox5.Controls.Add(this.groupBox4);
            this.groupBox5.Location = new System.Drawing.Point(290, 8);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(231, 49);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Select Date";
            this.groupBox5.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dateTimePicker2);
            this.groupBox4.Location = new System.Drawing.Point(67, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(216, 49);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "To Date";
            this.groupBox4.Visible = false;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(10, 23);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dateTimePicker1);
            this.groupBox3.Location = new System.Drawing.Point(6, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(211, 49);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "From Date";
            this.groupBox3.Visible = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(6, 23);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // AttendanceReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 583);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pnl_mode);
            this.Controls.Add(this.pnl_studdetails);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "AttendanceReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AttendanceReport";
            this.pnl_studdetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Studlist)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnl_mode.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Panel pnl_studdetails;
        private System.Windows.Forms.DataGridView dgv_Studlist;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmb_Division;
        private System.Windows.Forms.ComboBox cmb_Standard;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Student;
        private System.Windows.Forms.Button btn_Select;
        private System.Windows.Forms.Panel pnl_mode;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX btn_classwise;
        private DevComponents.DotNetBar.ButtonX btn_studwise;
        private System.Windows.Forms.DateTimePicker dtp_classwise;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btn_ViewReport;
    }
}