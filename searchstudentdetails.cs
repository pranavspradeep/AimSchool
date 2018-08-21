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
    public partial class searchstudentdetails : Form
    {
        DataLayer d=new DataLayer();
        string adno = "";
        public searchstudentdetails()
        {
            InitializeComponent();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (r1.Checked == false && r2.Checked == false && r3.Checked == false)
            {
                MessageBox.Show("Please select one option for search", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           

            if (r1.Checked == true)
            {
                txtcls.Text = null;
                txtrol.Text = null;
                if (txt_Cname.Text == "" || txt_Cname.Text == null)
                {
                    MessageBox.Show("Enter Name", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                // to display the student detail in grid by name

                SqlDataAdapter ad = new SqlDataAdapter("select adno as [Roll Number],sname as Name,cstandard as Standard from tbl_student where sname like '" + txt_Cname.Text + "%'", d.con);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    dgvsview.DataSource = ds.Tables[0];
                }
               

            }

            if (r2.Checked == true)
            {
                txt_Cname.Text = null;
                txtcls.Text = null;

                if ( txtrol.Text == "" || txtrol.Text == null)
                {
                    MessageBox.Show("Enter Roll Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                // to display the student detail in grid by roll number

                SqlDataAdapter ad1 = new SqlDataAdapter("select adno as [Roll Number],sname as Name,cstandard as Standard from tbl_student where adno='"+ txtrol.Text+"'", d.con);
                DataSet ds1 = new DataSet();
                ad1.Fill(ds1);
                dgvsview.DataSource = ds1.Tables[0];
               

            }
            if (r3.Checked == true)
            {
                txt_Cname.Text = null;
                txtrol.Text = null;
                if (txtcls.Text == "" || txtcls.Text == null)
                {
                    MessageBox.Show("Enter Class", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                // to display the student detail in grid by standard 

                SqlDataAdapter ad2 = new SqlDataAdapter("select adno as [Roll Number],sname as Name,cstandard as Standard from tbl_student where cstandard='"+ txtcls.Text +"'", d.con);
                DataSet ds2 = new DataSet();
                ad2.Fill(ds2);
                dgvsview.DataSource = ds2.Tables[0];
               
            }

        }

        private void searchstudentdetails_Load(object sender, EventArgs e)
        {
        
            SqlDataAdapter ad = new SqlDataAdapter("select adno as [Roll Number],sname as [Student Name],Sex,sfname AS [Father Name],cstandard as Standard from tbl_student", d.con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dgvsview.DataSource = ds.Tables[0];
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
            ////else
            ////{
            ////    SchoolManagement.rno = adno;
            ////    studentdetails sd = new studentdetails();
            ////    sd.Show();
            ////}
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            txt_Cname.Text = "";
            txtcls.Text = "";
            txtrol.Text = "";

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        }

        }
    
