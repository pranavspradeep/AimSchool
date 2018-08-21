using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SchoolManagement
{
    public partial class frmViewComents : Form
    {
        DataLayer d = new DataLayer();
        string stdno = "";
        string prntno = "";
        public frmViewComents()
        {
            InitializeComponent();
        }

        private void frmViewComents_Load(object sender, EventArgs e)
        {
            string s = "select s.adno,p.prntno,s.sname AS [Student Name],p.parentname AS [Parent Name],c.Comments from tbl_student s INNER JOIN tbl_parent p ON s.adno=p.stdno INNER JOIN tbl_Comment c ON p.prntno=c.ParentNo where c.TeacherNo='" + SchoolManagement.empno + "' AND c.Status='SendTeacher' AND c.Status!='TeacherViewed'";
            SqlDataAdapter da = new SqlDataAdapter(s, d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dgv1.DataSource = ds.Tables[0];
                this.dgv1.Columns["adno"].Visible = false;
                this.dgv1.Columns["prntno"].Visible = false;

            }
            else
            {
                MessageBox.Show("No comments for you", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            stdno = dgv1.Rows[e.RowIndex].Cells[0].Value.ToString();
            prntno = dgv1.Rows[e.RowIndex].Cells[1].Value.ToString();
            string msg = dgv1.Rows[e.RowIndex].Cells[4].Value.ToString();
            lbl_message.Text = msg;
            panel1.Visible = true;
           
            d.con_open();
            string status = "TeacherViewed";
            SqlCommand cmd = new SqlCommand("upd_Coment", d.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@prntno", prntno));
            cmd.Parameters.Add(new SqlParameter("@stdno", stdno));
            cmd.Parameters.Add(new SqlParameter("@techrno", SchoolManagement.empno));
            cmd.Parameters.Add(new SqlParameter("@sts",status));
            cmd.ExecuteNonQuery();
            d.con_close();

        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            frmAddComment cmnt = new frmAddComment();
            cmnt.Show();
            this.Close();
        }
    }
}