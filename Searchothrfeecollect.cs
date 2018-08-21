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
    public partial class Searchothrfeecollect : Form
    {
        DataLayer d = new DataLayer();
        string adno = "";
        string standard = "";
        public Searchothrfeecollect()
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

                SqlDataAdapter ad = new SqlDataAdapter("select adno as [Roll Number],sname as Name,cstandard as Standard from tbl_student where sname like '" + txt_Cname.Text + "%'", d.con);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                dgvsview.DataSource = ds.Tables[0];
                
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
                    SqlDataAdapter da2 = new SqlDataAdapter("select adno from tbl_student where adno='" + txtrol.Text + "' ", d.con);
                    DataSet dt2 = new DataSet();
                    da2.Fill(dt2);
                    if (dt2.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("Search roll number does not exist", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                SqlDataAdapter ad1 = new SqlDataAdapter("select adno as [Roll Number],sname as Name,cstandard as Standard from tbl_student where adno='" + txtrol.Text + "'", d.con);
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

                SqlDataAdapter ad2 = new SqlDataAdapter("select adno as [Roll Number],sname as Name,cstandard as Standard from tbl_student where cstandard='" + txtcls.Text + "'", d.con);
                DataSet ds2 = new DataSet();
                ad2.Fill(ds2);
                dgvsview.DataSource = ds2.Tables[0];

            }  
        }

        private void dgvsview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            adno = dgvsview.Rows[e.RowIndex].Cells[0].Value.ToString();
            standard = dgvsview.Rows[e.RowIndex].Cells[2].Value.ToString();
            SchoolManagement.standard = standard;
            SchoolManagement.rno = adno;
            
            Addothrfeecollect c = new Addothrfeecollect();
            c.Show();
            this.Hide();
        }

        private void Searchothrfeecollect_Load(object sender, EventArgs e)
        {
            SqlDataAdapter ad = new SqlDataAdapter("select adno as [Roll Number],sname as Name,cstandard as Standard from tbl_student", d.con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dgvsview.DataSource = ds.Tables[0];
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}