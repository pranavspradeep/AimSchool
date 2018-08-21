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
    public partial class Addothrfeecollect : Form
    {
        DataLayer d = new DataLayer();
        //string mnyr = "";
        //string nyr = "";
        public Addothrfeecollect()
        {
            InitializeComponent();
        }

        private void Addothrfeecollect_Load(object sender, EventArgs e)
        {
            SqlDataAdapter ad = new SqlDataAdapter("select sname,sfname,address,cstandard,email from tbl_student where adno='" + SchoolManagement.rno + "' ", d.con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dr = ds.Tables[0].Rows[0];
                txtsname.Text = dr[0].ToString();
                txtfname.Text = dr[1].ToString();
                txtadrs.Text = dr[2].ToString();
                txtstd.Text = dr[3].ToString();
                txtmail.Text = dr[4].ToString();

            }
            d.con_open();

            // Select feetype from table using stored procedure
            SqlCommand cmd = new SqlCommand("sel_feetype", d.con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                cmbtype.Items.Add(r[0].ToString());
            }
            d.con_close();

            string s = "SELECT stud.sname as Name,stud.cstandard as Standard,other.datefpay as Date,other.amount as Amount,other.fine as Fine FROM tbl_othrfeecollect AS other INNER JOIN tbl_student AS stud ON other.adno = stud.adno where other.adno='" + SchoolManagement.rno + "'";
            SqlDataAdapter ad1 = new SqlDataAdapter(s, d.con);
            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);
            if (ds1.Tables[0].Rows.Count >= 1)
            {
                dgv_feeview.DataSource = ds1.Tables[0];
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void cmbtype_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            SqlDataAdapter ad = new SqlDataAdapter("select collection,amount from tbl_fee where feetype='" + cmbtype.Text + "'and cstandard='"+txtstd.Text+"'", d.con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dr = ds.Tables[0].Rows[0];
                txtdate.Text = DateTime.Parse(dr[0].ToString()).ToString("dd");
                txtamt.Text = dr[1].ToString();
            }
            
            //SqlDataAdapter ad1 = new SqlDataAdapter("select datefpay  from tbl_othrfeecollect where adno= '"+SchoolManagement.rno+"'", d.con);
            //DataSet ds1 = new DataSet();
            //ad1.Fill(ds1);
            //DataRow dr1;
            //if (ds1.Tables[0].Rows.Count >= 1)
            //{
            //    dr1 = ds1.Tables[0].Rows[0];
            
            //    mnyr = DateTime.Parse(dr1[0].ToString()).ToString("MM-yy");
              
            //}

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            string fine = "";
            string id = "";
            SqlDataAdapter ad = new SqlDataAdapter("select feeid,fine from tbl_fee where feetype='" + cmbtype.Text + "'and cstandard='" + txtstd.Text + "'", d.con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dr = ds.Tables[0].Rows[0];
                id = dr[0].ToString();
                fine = dr[1].ToString();

            }

            if (Convert.ToInt32(txtdate.Text) <= Convert.ToInt32(DateTime.Parse(dtppaiddate.Text.ToString()).ToString("dd")))
            {
                txtfine.Text = fine;
            }
            else
            {
                txtfine.Text = "";
            }

            //to validate 

            //if (mnyr ==DateTime.Parse(dtppaiddate.Text.ToString()).ToString("dd-MM-yy"))   
            //{
            //    MessageBox.Show("xx");
            //}
            //else
            //{
                d.con_open();
                SqlCommand cmd = new SqlCommand("ins_addothrfeecollect", d.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@feeid", id);
                cmd.Parameters.AddWithValue("@adno", SchoolManagement.rno);
                cmd.Parameters.AddWithValue("@datefpay", DateTime.Parse(dtppaiddate.Text.ToString()).ToString("dd-MMM-yy"));
                cmd.Parameters.AddWithValue("@amount", txtamt.Text);
                cmd.Parameters.AddWithValue("@fine", txtfine.Text);
                MessageBox.Show("Fee saved successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmd.ExecuteNonQuery();
                txtfine.Text = "";
                txtadrs.Text = "";
                txtamt.Text = "";
                txtdate.Text = "";
                txtfname.Text = "";
                txtmail.Text = "";
                txtsname.Text = "";
                txtstd.Text = "";
                cmbtype.Text = "";
                dtppaiddate.Text = "";

                d.con_close();
                dgv_feeview.DataSource = null;

                SqlDataAdapter ad2 = new SqlDataAdapter("SELECT stud.sname as Name,stud.cstandard as Standard,other.datefpay as Date,other.amount as Amount,other.fine as Fine FROM tbl_othrfeecollect AS other INNER JOIN tbl_student AS stud ON other.adno = stud.adno where other.adno='" + SchoolManagement.rno + "'", d.con);
                DataSet ds2 = new DataSet();
                ad2.Fill(ds2);
                if (ds2.Tables[0].Rows.Count >= 1)
                {
                    dgv_feeview.DataSource = ds2.Tables[0];
                }
           // }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            txtfine.Text = "";
            txtadrs.Text = "";
            txtamt.Text = "";
            txtdate.Text = "";
            txtfname.Text = "";
            txtmail.Text = "";
            txtsname.Text = "";
            txtstd.Text = "";
            cmbtype.Text = "";
            dtppaiddate.Text = "";
        }
                           
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}