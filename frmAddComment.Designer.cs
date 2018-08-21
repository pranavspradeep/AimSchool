namespace SchoolManagement
{
    partial class frmAddComment
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
            this.dgvStdDetails = new System.Windows.Forms.DataGridView();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.btn_Send = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_ViewCmnts = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStdDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStdDetails
            // 
            this.dgvStdDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStdDetails.Location = new System.Drawing.Point(3, 19);
            this.dgvStdDetails.Name = "dgvStdDetails";
            this.dgvStdDetails.Size = new System.Drawing.Size(544, 193);
            this.dgvStdDetails.TabIndex = 0;
            this.dgvStdDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStdDetails_CellClick);
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(3, 232);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(544, 61);
            this.txtComment.TabIndex = 1;
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(290, 299);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(112, 23);
            this.btn_Send.TabIndex = 2;
            this.btn_Send.Text = "Send Comment";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.btn_Send_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(5, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select Student";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(0, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Enter Your Comments";
            // 
            // btn_ViewCmnts
            // 
            this.btn_ViewCmnts.Location = new System.Drawing.Point(435, 299);
            this.btn_ViewCmnts.Name = "btn_ViewCmnts";
            this.btn_ViewCmnts.Size = new System.Drawing.Size(112, 23);
            this.btn_ViewCmnts.TabIndex = 5;
            this.btn_ViewCmnts.Text = "View Comments";
            this.btn_ViewCmnts.UseVisualStyleBackColor = true;
            this.btn_ViewCmnts.Click += new System.EventHandler(this.btn_ViewCmnts_Click);
            // 
            // frmAddComment
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(551, 329);
            this.Controls.Add(this.btn_ViewCmnts);
            this.Controls.Add(this.dgvStdDetails);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Send);
            this.Controls.Add(this.txtComment);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmAddComment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Comment";
            this.Load += new System.EventHandler(this.frmAddComment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStdDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStdDetails;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_ViewCmnts;
    }
}