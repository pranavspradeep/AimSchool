namespace SchoolManagement
{
    partial class Assignroutetostud
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Assignroutetostud));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_search = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_assign = new System.Windows.Forms.ToolStripButton();
            this.side4 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_Cancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_close = new System.Windows.Forms.ToolStripButton();
            this.dgv_assigned = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_route = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.r3 = new System.Windows.Forms.RadioButton();
            this.r2 = new System.Windows.Forms.RadioButton();
            this.r1 = new System.Windows.Forms.RadioButton();
            this.txtcls = new System.Windows.Forms.TextBox();
            this.txtrol = new System.Windows.Forms.TextBox();
            this.txt_Cname = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label21 = new System.Windows.Forms.Label();
            this.dgv_stud = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_assigned)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_route)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_stud)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_search,
            this.toolStripSeparator1,
            this.btn_assign,
            this.side4,
            this.btn_Cancel,
            this.toolStripSeparator7,
            this.btn_close});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(943, 31);
            this.toolStrip1.TabIndex = 25;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btn_search
            // 
            this.btn_search.Image = ((System.Drawing.Image)(resources.GetObject("btn_search.Image")));
            this.btn_search.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(70, 28);
            this.btn_search.Text = "&Search";
            this.btn_search.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // btn_assign
            // 
            this.btn_assign.Image = ((System.Drawing.Image)(resources.GetObject("btn_assign.Image")));
            this.btn_assign.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_assign.Name = "btn_assign";
            this.btn_assign.Size = new System.Drawing.Size(70, 28);
            this.btn_assign.Text = "&Assign";
            this.btn_assign.Click += new System.EventHandler(this.btn_assign_Click);
            // 
            // side4
            // 
            this.side4.Name = "side4";
            this.side4.Size = new System.Drawing.Size(6, 31);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.Image")));
            this.btn_Cancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(71, 28);
            this.btn_Cancel.Text = "&Cancel";
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 31);
            // 
            // btn_close
            // 
            this.btn_close.Image = ((System.Drawing.Image)(resources.GetObject("btn_close.Image")));
            this.btn_close.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(64, 28);
            this.btn_close.Text = "&Close";
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // dgv_assigned
            // 
            this.dgv_assigned.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_assigned.Location = new System.Drawing.Point(6, 6);
            this.dgv_assigned.Name = "dgv_assigned";
            this.dgv_assigned.Size = new System.Drawing.Size(510, 239);
            this.dgv_assigned.TabIndex = 61;
            this.dgv_assigned.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_assigned_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(6, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 13);
            this.label2.TabIndex = 60;
            this.label2.Text = "Route assigned Details";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 59;
            this.label1.Text = "Route Details";
            // 
            // dgv_route
            // 
            this.dgv_route.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_route.Location = new System.Drawing.Point(9, 19);
            this.dgv_route.Name = "dgv_route";
            this.dgv_route.Size = new System.Drawing.Size(507, 169);
            this.dgv_route.TabIndex = 58;
            this.dgv_route.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_route_CellClick);
            this.dgv_route.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_route_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.r3);
            this.panel1.Controls.Add(this.r2);
            this.panel1.Controls.Add(this.r1);
            this.panel1.Controls.Add(this.txtcls);
            this.panel1.Controls.Add(this.txtrol);
            this.panel1.Controls.Add(this.txt_Cname);
            this.panel1.Location = new System.Drawing.Point(12, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(380, 140);
            this.panel1.TabIndex = 29;
            // 
            // r3
            // 
            this.r3.AutoSize = true;
            this.r3.Location = new System.Drawing.Point(22, 89);
            this.r3.Name = "r3";
            this.r3.Size = new System.Drawing.Size(65, 17);
            this.r3.TabIndex = 14;
            this.r3.TabStop = true;
            this.r3.Text = "By Class";
            this.r3.UseVisualStyleBackColor = true;
            // 
            // r2
            // 
            this.r2.AutoSize = true;
            this.r2.Location = new System.Drawing.Point(22, 57);
            this.r2.Name = "r2";
            this.r2.Size = new System.Drawing.Size(95, 17);
            this.r2.TabIndex = 13;
            this.r2.TabStop = true;
            this.r2.Text = "By RollNumber";
            this.r2.UseVisualStyleBackColor = true;
            // 
            // r1
            // 
            this.r1.AutoSize = true;
            this.r1.Location = new System.Drawing.Point(22, 22);
            this.r1.Name = "r1";
            this.r1.Size = new System.Drawing.Size(68, 17);
            this.r1.TabIndex = 12;
            this.r1.TabStop = true;
            this.r1.Text = "By Name";
            this.r1.UseVisualStyleBackColor = true;
            // 
            // txtcls
            // 
            this.txtcls.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtcls.Location = new System.Drawing.Point(121, 91);
            this.txtcls.Name = "txtcls";
            this.txtcls.Size = new System.Drawing.Size(195, 20);
            this.txtcls.TabIndex = 11;
            // 
            // txtrol
            // 
            this.txtrol.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtrol.Location = new System.Drawing.Point(121, 56);
            this.txtrol.Name = "txtrol";
            this.txtrol.Size = new System.Drawing.Size(195, 20);
            this.txtrol.TabIndex = 10;
            // 
            // txt_Cname
            // 
            this.txt_Cname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_Cname.Location = new System.Drawing.Point(121, 19);
            this.txt_Cname.Name = "txt_Cname";
            this.txt_Cname.Size = new System.Drawing.Size(195, 20);
            this.txt_Cname.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.dgv_stud);
            this.panel2.Location = new System.Drawing.Point(12, 187);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(380, 342);
            this.panel2.TabIndex = 30;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label21.Location = new System.Drawing.Point(6, 10);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(94, 13);
            this.label21.TabIndex = 59;
            this.label21.Text = "Student Details";
            // 
            // dgv_stud
            // 
            this.dgv_stud.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_stud.Location = new System.Drawing.Point(9, 26);
            this.dgv_stud.Name = "dgv_stud";
            this.dgv_stud.Size = new System.Drawing.Size(360, 300);
            this.dgv_stud.TabIndex = 58;
            this.dgv_stud.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_stud_CellClick);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dgv_route);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(398, 41);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(534, 207);
            this.panel3.TabIndex = 31;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.dgv_assigned);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(398, 255);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(534, 275);
            this.panel4.TabIndex = 62;
            // 
            // Assignroutetostud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(943, 540);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.Name = "Assignroutetostud";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Assign Bus Route to Student";
            this.Load += new System.EventHandler(this.Assignroutetostud_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_assigned)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_route)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_stud)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton btn_close;
        private System.Windows.Forms.DataGridView dgv_route;
        private System.Windows.Forms.DataGridView dgv_assigned;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton btn_assign;
        private System.Windows.Forms.ToolStripButton btn_Cancel;
        private System.Windows.Forms.ToolStripButton btn_search;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator side4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton r3;
        private System.Windows.Forms.RadioButton r2;
        private System.Windows.Forms.RadioButton r1;
        private System.Windows.Forms.TextBox txtcls;
        private System.Windows.Forms.TextBox txtrol;
        private System.Windows.Forms.TextBox txt_Cname;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.DataGridView dgv_stud;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
    }
}