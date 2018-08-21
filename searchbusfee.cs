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
    public partial class searchbusfee : Form
    {
        DataLayer d = new DataLayer();
        string adno = "";
        string ptnum = "";
        public searchbusfee()
        {
            InitializeComponent();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (r1.Checked == false && r2.Checked == false && r3.Checked == false)
            {
                MessageBox.Show("Select option for search", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            if (r1.Checked == true)
            {
                txtcls.Text = null;
                txtrol.Text = null;
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
                        SqlDataAdapter da2 = new SqlDataAdapter("select s.adno as [Roll Number],a.ptnum as [Point Number],s.sname as Name,s.cstandard as Standard from tbl_student s inner join tbl_assignroute a on s.adno=a.adno where s.sname like '" + txt_Cname.Text + "%'", d.con);
                        DataSet ds2 = new DataSet();
                        da2.Fill(ds2);
                        dgvsview.DataSource = ds2.Tables[0];
                


            }

            if (r2.Checked == true)
            {
                txt_Cname.Text = null;
                txtcls.Text = null;

                if (txtrol.Text == "" || txtrol.Text == null)
                {
                    MessageBox.Show("Enter Roll Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    SqlDataAdapter da3 = new SqlDataAdapter("select adno from tbl_student where adno='" + txtrol.Text + "' ", d.con);
                    DataSet dt3 = new DataSet();
                    da3.Fill(dt3);
                    if (dt3.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("Search roll number does not exist", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                    SqlDataAdapter da4 = new SqlDataAdapter("select s.adno as [Roll Number],a.ptnum as [Point Number],s.sname as Name,s.cstandard as Standard from tbl_student s inner join tbl_assignroute a on s.adno=a.adno where s.adno='" + txtrol.Text + "'", d.con);
                    DataSet ds4 = new DataSet();
                    da4.Fill(ds4);
                    dgvsview.DataSource = ds4.Tables[0];
                

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

                    SqlDataAdapter da5 = new SqlDataAdapter("select cstandard from tbl_student where cstandard='" + txtcls.Text + "'", d.con);
                    DataSet dt5 = new DataSet();
                    da5.Fill(dt5);
                    if (dt5.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("Search class  does not exist", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                SqlDataAdapter da6 = new SqlDataAdapter("select s.adno as [Roll Number],a.ptnum as [Point Number],s.sname as Name,s.cstandard as Standard from tbl_student s inner join tbl_assignroute a on s.adno=a.adno where s.cstandard='" + txtcls.Text + "'", d.con);
                DataSet ds6 = new DataSet();
                da6.Fill(ds6);
                dgvsview.DataSource = ds6.Tables[0];
                

            }

        }

        private void searchbusfee_Load(object sender, EventArgs e)
        {

            SqlDataAdapter ad = new SqlDataAdapter("select s.adno as [Roll Number],a.ptnum as [Point Number],s.sname as Name,s.cstandard as Standard from tbl_student s inner join tbl_assignroute a on s.adno=a.adno", d.con);
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
            ptnum = dgvsview.Rows[e.RowIndex].Cells[1].Value.ToString();
            SchoolManagement.rno = adno;
            SchoolManagement.ptnum = ptnum;
            Buspayment p = new Buspayment();
            p.Show();
            this.Hide();
           
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