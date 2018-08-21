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
    public partial class frmAddComment : Form
    {
        DataLayer d = new DataLayer();
        string prntno = "";
        string stdno = "";
        public frmAddComment()
        {
            InitializeComponent();
        }

        private void frmAddComment_Load(object sender, EventArgs e)
        {
            studentdetails();

        }
        private void studentdetails()
        {
            string s = "select p.prntno AS [Parent No],s.adno AS [Admission No],p.parentname AS [Parent Name],s.sname AS [Student Name],std.cstandard AS Standard,std.division AS Division from tbl_Parent p INNER JOIN tbl_student s ON p.stdno=s.adno INNER JOIN tbl_stddivision std ON s.adno=std.adno INNER JOIN tbl_class c ON std.classno=c.classno where c.classteacherno='" + SchoolManagement.empno + "'";
            SqlDataAdapter da = new SqlDataAdapter(s, d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dgvStdDetails.DataSource = null;
                dgvStdDetails.DataSource = ds.Tables[0];
                this.dgvStdDetails.Columns["Parent No"].Visible = false;
            }
 
        }

       

        private void dgvStdDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            prntno = dgvStdDetails.Rows[e.RowIndex].Cells[0].Value.ToString();
            stdno = dgvStdDetails.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            if (prntno == "" && stdno == "")
            {
                MessageBox.Show("Please select student", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtComment.Text == "" || txtComment.Text == null)
            {
                MessageBox.Show("Please enter your comments ", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                d.con_open();
                string status = "sendParent";
                SqlCommand cmd = new SqlCommand("ins_Comment", d.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@prntno", prntno));
                cmd.Parameters.Add(new SqlParameter("@stdno", stdno));
                cmd.Parameters.Add(new SqlParameter("@techrno", SchoolManagement.empno));
                cmd.Parameters.Add(new SqlParameter("@coment", txtComment.Text));
                cmd.Parameters.Add(new SqlParameter("@sts", status));
                cmd.ExecuteNonQuery();
                d.con_close();

                txtComment.Text = "";

                MessageBox.Show("Your comment send", "Send..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_ViewCmnts_Click(object sender, EventArgs e)
        {
            frmViewComents viewcmnt = new frmViewComents();
            viewcmnt.Show();
        }
    
    }
}