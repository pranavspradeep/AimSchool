namespace SchoolManagement
{
    partial class Searchothrfeecollect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Searchothrfeecollect));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnsearch = new System.Windows.Forms.Button();
            this.dgvsview = new System.Windows.Forms.DataGridView();
            this.r3 = new System.Windows.Forms.RadioButton();
            this.r2 = new System.Windows.Forms.RadioButton();
            this.r1 = new System.Windows.Forms.RadioButton();
            this.txtcls = new System.Windows.Forms.TextBox();
            this.txtrol = new System.Windows.Forms.TextBox();
            this.txt_Cname = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.side4 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_Cancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_close = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsview)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnsearch);
            this.groupBox1.Controls.Add(this.dgvsview);
            this.groupBox1.Controls.Add(this.r3);
            this.groupBox1.Controls.Add(this.r2);
            this.groupBox1.Controls.Add(this.r1);
            this.groupBox1.Controls.Add(this.txtcls);
            this.groupBox1.Controls.Add(this.txtrol);
            this.groupBox1.Controls.Add(this.txt_Cname);
            this.groupBox1.Location = new System.Drawing.Point(12, 38);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(613, 491);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnsearch
            // 
            this.btnsearch.Location = new System.Drawing.Point(471, 44);
            this.btnsearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(115, 113);
            this.btnsearch.TabIndex = 9;
            this.btnsearch.Text = "Search";
            this.btnsearch.UseVisualStyleBackColor = true;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // dgvsview
            // 
            this.dgvsview.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvsview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvsview.Location = new System.Drawing.Point(31, 185);
            this.dgvsview.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvsview.Name = "dgvsview";
            this.dgvsview.Size = new System.Drawing.Size(555, 293);
            this.dgvsview.TabIndex = 25;
            this.dgvsview.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvsview_CellClick);
            // 
            // r3
            // 
            this.r3.AutoSize = true;
            this.r3.Location = new System.Drawing.Point(31, 130);
            this.r3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.r3.Name = "r3";
            this.r3.Size = new System.Drawing.Size(83, 21);
            this.r3.TabIndex = 8;
            this.r3.TabStop = true;
            this.r3.Text = "By Class";
            this.r3.UseVisualStyleBackColor = true;
            // 
            // r2
            // 
            this.r2.AutoSize = true;
            this.r2.Location = new System.Drawing.Point(31, 91);
            this.r2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.r2.Name = "r2";
            this.r2.Size = new System.Drawing.Size(123, 21);
            this.r2.TabIndex = 7;
            this.r2.TabStop = true;
            this.r2.Text = "By RollNumber";
            this.r2.UseVisualStyleBackColor = true;
            // 
            // r1
            // 
            this.r1.AutoSize = true;
            this.r1.Location = new System.Drawing.Point(31, 48);
            this.r1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.r1.Name = "r1";
            this.r1.Size = new System.Drawing.Size(86, 21);
            this.r1.TabIndex = 6;
            this.r1.TabStop = true;
            this.r1.Text = "By Name";
            this.r1.UseVisualStyleBackColor = true;
            // 
            // txtcls
            // 
            this.txtcls.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtcls.Location = new System.Drawing.Point(163, 133);
            this.txtcls.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtcls.Name = "txtcls";
            this.txtcls.Size = new System.Drawing.Size(259, 22);
            this.txtcls.TabIndex = 2;
            // 
            // txtrol
            // 
            this.txtrol.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtrol.Location = new System.Drawing.Point(163, 90);
            this.txtrol.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtrol.Name = "txtrol";
            this.txtrol.Size = new System.Drawing.Size(259, 22);
            this.txtrol.TabIndex = 1;
            // 
            // txt_Cname
            // 
            this.txt_Cname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_Cname.Location = new System.Drawing.Point(163, 44);
            this.txt_Cname.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_Cname.Name = "txt_Cname";
            this.txt_Cname.Size = new System.Drawing.Size(259, 22);
            this.txt_Cname.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.side4,
            this.btn_Cancel,
            this.toolStripSeparator7,
            this.btn_close});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(637, 31);
            this.toolStrip1.TabIndex = 26;
            this.toolStrip1.Text = "toolStrip1";
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
            this.btn_Cancel.Size = new System.Drawing.Size(81, 28);
            this.btn_Cancel.Text = "&Cancel";
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
            this.btn_close.Size = new System.Drawing.Size(73, 28);
            this.btn_close.Text = "&Close";
            // 
            // Searchothrfeecollect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(637, 538);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Searchothrfeecollect";
            this.Text = "Searchothrfeecollect";
            this.Load += new System.EventHandler(this.Searchothrfeecollect_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsview)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.RadioButton r3;
        private System.Windows.Forms.RadioButton r2;
        private System.Windows.Forms.RadioButton r1;
        private System.Windows.Forms.TextBox txtcls;
        private System.Windows.Forms.TextBox txtrol;
        private System.Windows.Forms.TextBox txt_Cname;
        private System.Windows.Forms.DataGridView dgvsview;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator side4;
        private System.Windows.Forms.ToolStripButton btn_Cancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton btn_close;
    }
}