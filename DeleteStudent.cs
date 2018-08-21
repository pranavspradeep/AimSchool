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
    public partial class DeleteStudent : DevComponents.DotNetBar.Office2007Form
    {
        DataLayer d = new DataLayer();
        string StdNo = "";
        public DeleteStudent()
        {
            InitializeComponent();
        }

        private void DeleteStudent_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select adno AS Number,sname [Student Name],sex,sfname AS [Father Name],pnum AS [Phone Number],Religion from tbl_student", d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            string s = "Select adno AS StudentNumber,sname StudentName,sex,sfname AS FatherName,pnum AS PhoneNumber,Religion from tbl_student where sname LIKE '" + txtEmp.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(s, d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (txtEmp.Text == "")
            {
                MessageBox.Show("Please enter name", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    dataGridView1.DataSource = null;
                    MessageBox.Show("Search name does not exist", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


            }  
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            StdNo = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            if (StdNo == null || StdNo == "")
            {
                MessageBox.Show("Please select one student", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult d1 = MessageBox.Show("Are you sure to delete", "Confirm..", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d1 == DialogResult.Yes)
                {
                    SqlDataAdapter da = new SqlDataAdapter("Delete from tbl_student where adno='" + StdNo + "'", d.con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    SqlDataAdapter da1 = new SqlDataAdapter("Select adno AS Number,sname [Student Name],sex,sfname AS [Father Name],pnum AS [Phone Number],Religion from tbl_student", d.con);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);
                    dataGridView1.DataSource = ds1.Tables[0];
                }
            }
        }
    }
}