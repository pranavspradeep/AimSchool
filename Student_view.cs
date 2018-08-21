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
    public partial class Student_view : Form
    {
        string adno="";
        
        DataLayer d= new DataLayer();
        public Student_view()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Student_view_Load(object sender, EventArgs e)
        {
            d.con_open();
            SqlDataAdapter ad1 = new SqlDataAdapter("select  adno as [Admission No],sname as Name ,cstandard as Class,remarks as Remarks from tbl_student", d.con);
            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);
            dgvsview.DataSource = ds1.Tables[0];
            d.con_close();
        }
        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (r1.Checked == false && r2.Checked == false && r3.Checked == false)
            {
                MessageBox.Show("Select option for search", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (r1.Checked == true)
            {
                txtrol.Text = null;
                txtcls.Text = null;

                if (txt_Cname.Text == "" || txt_Cname.Text == null)
                {
                    MessageBox.Show("Enter Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("select sname from tbl_student  where sname like '" + txt_Cname.Text + "%'  ", d.con);
                    DataSet dt1 = new DataSet();
                    da1.Fill(dt1);
                    if (dt1.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("Search name does not exist", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                SqlDataAdapter ad1 = new SqlDataAdapter("select  adno as [Admission No],sname as Name ,cstandard as Class,remarks as Remarks from tbl_student where sname like '" + txt_Cname.Text + "%' ", d.con);
                DataSet ds1 = new DataSet();
                ad1.Fill(ds1);
                DataTable dt = ds1.Tables[0];
                if (ds1.Tables[0].Rows.Count >= 1)
                {
                    dgvsview.DataSource = ds1.Tables[0];
                }
            }
            if (r2.Checked == true)
            {
                txtcls.Text = null;
                txt_Cname.Text =null;

                if (txtrol.Text == "" || txtrol.Text == null)
                {
                    MessageBox.Show("Enter Roll Number ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    SqlDataAdapter da2 = new SqlDataAdapter("select adno from tbl_student where adno='" + txtrol.Text + "' ", d.con);
                    DataSet dt2 = new DataSet();
                    da2.Fill(dt2);
                    if (dt2.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("Search roll number does not exist", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                SqlDataAdapter ad1 = new SqlDataAdapter("select  adno as [Admission No],sname as Name ,cstandard as Class,remarks as Remarks from tbl_student where adno='" + txtrol.Text + "' ", d.con);
                DataSet ds1 = new DataSet();
                ad1.Fill(ds1);
                DataTable dt = ds1.Tables[0];

                if (ds1.Tables[0].Rows.Count >= 1)
                {
                    dgvsview.DataSource = ds1.Tables[0];

                }
            }

            if (r3.Checked == true)
            {
                txt_Cname.Text =null;
                txtrol.Text = null;  
                if (txtcls.Text == "" || txtcls.Text == null)
                {
                    MessageBox.Show("Enter the class", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    SqlDataAdapter da3 = new SqlDataAdapter("select cstandard from tbl_student where cstandard='" + txtcls.Text + "'", d.con);
                    DataSet dt3 = new DataSet();
                    da3.Fill(dt3);
                    if (dt3.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("Search class  does not exist", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                SqlDataAdapter ad1 = new SqlDataAdapter("select  adno as [Admission No],sname as Name ,cstandard as Class,remarks as Remarks from tbl_student where cstandard='" + txtcls.Text + "' ", d.con);
                DataSet ds1 = new DataSet();
                ad1.Fill(ds1);
                DataTable dt = ds1.Tables[0];
                if (ds1.Tables[0].Rows.Count >= 1)
                {
                    dgvsview.DataSource = ds1.Tables[0];
                }
                                               
            }
            

          }

      
        private void dgvsview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            adno = dgvsview.Rows[e.RowIndex].Cells[0].Value.ToString();
            SqlDataAdapter ad = new SqlDataAdapter("select adno from tbl_student where adno='" + adno + "'", d.con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Data does not exist", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SchoolManagement.rno = adno;
            }
        }

        private void btn_Edit_Click_1(object sender, EventArgs e)
        {
           

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (adno == "" || adno == null)
            {
                MessageBox.Show("Please select one student", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Students_Edit ed = new Students_Edit();
                ed.Show();
                this.Hide();
            }
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            txt_Cname.Text = "";
            txtcls.Text = "";
            txtrol.Text = "";
            txt_Cname.Focus();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
     
    }
}