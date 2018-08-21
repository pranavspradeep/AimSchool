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

    public partial class DeleteEmp : DevComponents.DotNetBar.Office2007Form
    {
        DataLayer d = new DataLayer();
        string TeacherNo = "";
        public DeleteEmp()
        {
            InitializeComponent();
        }

        private void DeleteEmp_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select EmpNo AS [Number],EmpName AS [Teacher Name],Sex,Mobnum AS [Phone Number],Qualification,Salary from teacherdet", d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select EmpNo AS [Number],EmpName AS [Teacher Name],Sex,Mobnum AS [Phone Number],Qualification,Salary from teacherdet where EmpName like '" + txtEmp.Text + "%'", d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            //dataGridView1.DataSource = ds.Tables[0];
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
           TeacherNo = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            if (TeacherNo == null || TeacherNo == "")
            {
                MessageBox.Show("Please select one employee", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult d1 = MessageBox.Show("Are you sure to delete", "Confirm..", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d1 == DialogResult.Yes)
                {
                    SqlDataAdapter da = new SqlDataAdapter("Delete from teacherdet where EmpNo='" + TeacherNo + "'", d.con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dataGridView1.DataSource = null;

                    SqlDataAdapter da1 = new SqlDataAdapter("Select EmpNo AS [Number],EmpName AS [Teacher Name],Sex,Mobnum AS [Phone Number],Qualification,Salary from teacherdet", d.con);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);
                    dataGridView1.DataSource = ds1.Tables[0];

                }

            }

        }
    } 
}