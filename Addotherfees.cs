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
    public partial class addotherfees : Form
    {
        DataLayer d = new DataLayer();
        DataSet ds1 = new DataSet();
        DataRow dr;
        string feeid = "";

        public addotherfees()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (cmboth.Text == "" || cmboth.Text == null)
            {
                MessageBox.Show("Enter Feetype ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbstd.Text == "" || cmbstd.Text == null)
            {
                MessageBox.Show("Enter Standard", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbsyll.Text == "" || cmbsyll.Text == null)
            {
                MessageBox.Show("Enter Syllabus", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtamount.Text == "" || txtamount.Text == null)
            {
                MessageBox.Show("Enter Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlDataAdapter ad1 = new SqlDataAdapter("select feetype,cstandard,Newsyll from tbl_fee where cstandard='" + cmbstd.Text + "'and Newsyll='" + cmbsyll.Text + "'and feetype='" + cmboth.Text + "' ", d.con);
                DataSet ds1 = new DataSet();
                ad1.Fill(ds1);
                if (ds1.Tables[0].Rows.Count >= 1)
                {
                    MessageBox.Show("Fees already exist", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbstd.Text = "";
                    cmbsyll.Text = "";
                    txtamount.Text = "";
                    dtpcollect.Text = "";
                    txtfine.Text = "";
                    cmboth.Text = "";
                }

                else
                {
                    d.con_open();

                    SqlCommand cmd = new SqlCommand("ins_fee", d.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@feetype", cmboth.Text);
                    cmd.Parameters.AddWithValue("@cstandard", cmbstd.Text);
                    cmd.Parameters.AddWithValue("@Newsyll", cmbsyll.Text);
                    cmd.Parameters.AddWithValue("@amount", txtamount.Text);
                    cmd.Parameters.AddWithValue("@collection", DateTime.Parse(dtpcollect.Text.ToString()).ToString("dd-MMM-yy"));
                    cmd.Parameters.AddWithValue("@fine", txtfine.Text);
                    cmd.ExecuteNonQuery();
                    cmbstd.Text = "";
                    cmbsyll.Text = "";
                    txtamount.Text = "";
                    dtpcollect.Text = "";
                    txtfine.Text = "";
                    cmboth.Text = "";
                    d.con_close();

                    // Display added fee details in datagridview

                    dgv_fees.DataSource = null;
                    DataSet ds2 = new DataSet();
                    SqlDataAdapter ad = new SqlDataAdapter("select feeid,feetype,cstandard,Newsyll,amount,collection,fine from tbl_fee", d.con);
                    ad.Fill(ds2);
                    dr = ds2.Tables[0].Rows[0];
                    dgv_fees.DataSource = ds2.Tables[0];
                    MessageBox.Show("Data added successfully", "Added..", MessageBoxButtons.OK, MessageBoxIcon.Information);

                  
                }
            }
        }

        
        private void dgv_fees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            feeid = dgv_fees.Rows[e.RowIndex].Cells[0].Value.ToString();
            SqlDataAdapter ad = new SqlDataAdapter("select feetype,cstandard,Newsyll,amount,collection,fine from tbl_fee where feeid='" + feeid + "'", d.con);
            DataSet ds2 = new DataSet();
            ad.Fill(ds2);
            DataRow dr2;
            if (ds2.Tables[0].Rows.Count >= 1)
            {
                dr2 = ds2.Tables[0].Rows[0];
                cmboth.Text = dr2[0].ToString();
                cmbstd.Text = dr2[1].ToString();
                cmbsyll.Text = dr2[2].ToString();
                txtamount.Text = dr2[3].ToString();
                dtpcollect.Text = dr2[4].ToString().Trim();
                txtfine.Text = dr2[5].ToString();
            }
            else
            {
                MessageBox.Show("Data does not exist", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }         
               
        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (txtamount.Text == "" || txtamount.Text == null)
            {
                MessageBox.Show("Enter Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmboth.Text == "" || cmboth.Text == null)
            {
                MessageBox.Show("Enter Feetype ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbstd.Text == "" || cmbstd.Text == null)
            {
                MessageBox.Show("Enter Standard", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbsyll.Text == "" || cmbsyll.Text == null)
            {
                MessageBox.Show("Enter Syllabus", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlDataAdapter ad1 = new SqlDataAdapter("select feetype,cstandard,Newsyll from tbl_fee where feetype='" + cmboth.Text + "' and cstandard='" + cmbstd.Text + "'and Newsyll='" + cmbsyll.Text + "'", d.con);
                DataSet ds1 = new DataSet();
                ad1.Fill(ds1);
                if (ds1.Tables[0].Rows.Count >= 1)
                {
                    MessageBox.Show("Fees already exist", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbstd.Text = "";
                    cmbsyll.Text = "";
                    txtamount.Text = "";
                    dtpcollect.Text = "";
                    txtfine.Text = "";
                    cmboth.Text = "";
                }
                else
                {
                    d.con_open();

                    SqlCommand cmnd = new SqlCommand("upd_fee", d.con);
                    cmnd.CommandType = CommandType.StoredProcedure;
                    cmnd.Parameters.AddWithValue("@feeid", feeid);
                    cmnd.Parameters.AddWithValue("@feetype", cmboth.Text);
                    cmnd.Parameters.AddWithValue("@cstandard", cmbstd.Text);
                    cmnd.Parameters.AddWithValue("@Newsyll", cmbsyll.Text);
                    cmnd.Parameters.AddWithValue("@amount", txtamount.Text);
                    cmnd.Parameters.AddWithValue("@collection", DateTime.Parse(dtpcollect.Text.ToString()).ToString("dd-MMM-yy"));
                    cmnd.Parameters.AddWithValue("@fine", txtfine.Text);
                    cmnd.ExecuteNonQuery();

                    cmbstd.Text = "";
                    cmbsyll.Text = "";
                    txtamount.Text = "";
                    dtpcollect.Text = "";
                    txtfine.Text = "";
                    cmboth.Text = "";

                    d.con_close();

                    // Display edited fees in datagridview

                    dgv_fees.DataSource = null;
                    SqlDataAdapter ads = new SqlDataAdapter("select  feeid,feetype,cstandard,Newsyll,amount,collection,fine from tbl_fee ", d.con);
                    DataSet dsa = new DataSet();
                    ads.Fill(dsa);
                    dgv_fees.DataSource = dsa.Tables[0];
                    MessageBox.Show("Fees Edited Successfully", "Edited...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            cmboth.Text = "";
            cmbstd.Text = "";
            cmbsyll.Text = "";
            txtamount.Text = "";
            txtfine.Text = "";
                         
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you sure to remove the fees", "warning..", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {

                d.con_open();
                SqlCommand cmd = new SqlCommand("delete from tbl_fee where feeid='" + feeid + "'", d.con);
                cmd.Parameters.AddWithValue("feetype", cmboth.Text);
                cmd.Parameters.AddWithValue("cstandard", cmbstd.Text);
                cmd.Parameters.AddWithValue("Newsyll", cmbsyll.Text);
                cmd.Parameters.AddWithValue("amount", txtamount.Text);
                cmd.Parameters.AddWithValue("collection", DateTime.Parse(dtpcollect.Text.ToString()).ToString("dd-MMM-yy"));
                cmd.Parameters.AddWithValue("fine", txtfine.Text);
                cmd.ExecuteNonQuery();
                d.con_close();
                // Display the remaining fees in datagridview

                dgv_fees.DataSource = null;
                SqlDataAdapter ads = new SqlDataAdapter("select  feeid,feetype,cstandard,Newsyll,amount,collection,fine from tbl_fee ", d.con);
                DataSet dsa = new DataSet();
                ads.Fill(dsa);
                dgv_fees.DataSource = dsa.Tables[0];
                //MessageBox.Show("Fees removed Successfully", "Removed...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbstd.Text = "";
                cmbsyll.Text = "";
                txtamount.Text = "";
                dtpcollect.Text = "";
                txtfine.Text = "";
                cmboth.Text = "";
            }


        }

        private void addotherfees_Load(object sender, EventArgs e)
        {
            //select syllabus from table

            d.con_open();

            SqlCommand cmd1 = new SqlCommand("sel_syllabus", d.con);
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlDataReader rd = cmd1.ExecuteReader();
            cmbsyll.Items.Clear();
            while (rd.Read())
            {
                cmbsyll.Items.Add(rd[0].ToString());
            }

            d.con_close();

            //select feetype from table 

            d.con_open();

            SqlCommand cmd2 = new SqlCommand("sel_fee", d.con);
            cmd2.CommandType = CommandType.StoredProcedure;
            SqlDataReader rd1 = cmd2.ExecuteReader();
            while (rd1.Read())
            {
                cmboth.Items.Add(rd1[0].ToString());
            }

            d.con_close();

            //display fees details in datagridview

            string s = "select feeid,feetype,cstandard,Newsyll,amount,collection,fine from tbl_fee";
            SqlDataAdapter ad = new SqlDataAdapter(s, d.con);
            ad.Fill(ds1);
            DataRow dr;
            if (ds1.Tables[0].Rows.Count >= 1)
            {
                dr = ds1.Tables[0].Rows[0];
                dgv_fees.DataSource = ds1.Tables[0];
            }
        }

        //private void cmboth_Click(object sender, EventArgs e)
        //{

        //}
}
    
}