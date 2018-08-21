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
    public partial class Tuitionfees : Form
    {
        DataLayer d = new DataLayer();
        string feeno = "";

        public Tuitionfees()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (cmbstd.Text == "" || cmbstd.Text == null)
            {
                MessageBox.Show("Enter standard ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbsyll.Text == "" || cmbsyll.Text == null)
            {
                MessageBox.Show("Enter Syllabus", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtamt.Text == "" || txtamt.Text == null)
            {
                MessageBox.Show("Enter amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbdte.Text == "" || cmbdte.Text == null)
            {
                MessageBox.Show("Enter collection date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtfine.Text == "" || txtfine.Text == null)
            {
                MessageBox.Show("Enter fine", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                SqlDataAdapter ad1 = new SqlDataAdapter("select cstandard,Newsyll from tbl_tuitionfee where cstandard='" + cmbstd.Text + "' and Newsyll='" + cmbsyll.Text + "'", d.con);
                DataSet ds1 = new DataSet();
                ad1.Fill(ds1);
                if (ds1.Tables[0].Rows.Count >= 1)
                {
                    MessageBox.Show("standard and syllabus already exist", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    cmbstd.Text = "";
                    cmbsyll.Text = "";
                    cmbdte.Text = "";
                    txtamt.Text = "";
                    txtfine.Text = "";

                }
                else
                {

                    d.con_open();

                    SqlCommand cmd = new SqlCommand("ins_tuition", d.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@cstandard", cmbstd.Text);
                    cmd.Parameters.AddWithValue("@Newsyll", cmbsyll.Text);
                    cmd.Parameters.AddWithValue("@amount", txtamt.Text);
                    cmd.Parameters.AddWithValue("@collectiondate", cmbdte.Text);
                    cmd.Parameters.AddWithValue("@fine", txtfine.Text);
                    cmd.ExecuteNonQuery();
                    cmbstd.Text = "";
                    cmbsyll.Text = "";
                    cmbdte.Text = "";
                    txtamt.Text = "";
                    txtfine.Text = "";

                    d.con_close();

                    //Display the added details in datagridview

                    dgv_tuition.DataSource = null;
                    SqlDataAdapter ad = new SqlDataAdapter("select feeno as [Fee Number],cstandard as Stamdard,Newsyll as Syllabus,amount as Amount,collectiondate as [Collection Date],fine as Fine from tbl_tuitionfee ", d.con);
                    DataSet ds = new DataSet();
                    ad.Fill(ds);
                    dgv_tuition.DataSource = ds.Tables[0];
                    MessageBox.Show("Tuitionfees Added Successfully", "Added..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
        }

        private void Tuitionfees_Load(object sender, EventArgs e)
        {
            
            //To select syllabus from table

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

            // display details in datagridview

            SqlDataAdapter ad = new SqlDataAdapter("select feeno as [Fee Number],cstandard as Standard,Newsyll as Syllabus,amount as Amount,collectiondate as [Collection Date],fine as Fine from tbl_tuitionfee", d.con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            dgv_tuition.DataSource = ds.Tables[0];
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            cmbstd.Text = "";
            cmbsyll.Text = "";
            cmbdte.Text = "";
            txtamt.Text = "";
            txtfine.Text = "";
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (cmbstd.Text == "" || cmbstd.Text == null)
            {
                MessageBox.Show("Enter standard ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbsyll.Text == "" || cmbsyll.Text == null)
            {
                MessageBox.Show("Enter Syllabus", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtamt.Text == "" || txtamt.Text == null)
            {
                MessageBox.Show("Enter amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbdte.Text == "" || cmbdte.Text == null)
            {
                MessageBox.Show("Enter collection date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtfine.Text == "" || txtfine.Text == null)
            {
                MessageBox.Show("Enter fine", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                SqlDataAdapter ad1 = new SqlDataAdapter("select cstandard,Newsyll from tbl_tuitionfee where cstandard='" + cmbstd.Text + "' and Newsyll='" + cmbsyll.Text + "'", d.con);
                DataSet ds1 = new DataSet();
                ad1.Fill(ds1);
                if (ds1.Tables[0].Rows.Count >= 1)
                {
                    MessageBox.Show("standard and syllabus already exist", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    cmbstd.Text = "";
                    cmbsyll.Text = "";
                    cmbdte.Text = "";
                    txtamt.Text = "";
                    txtfine.Text = "";

                }

                else
                {
                    d.con_open();

                    SqlCommand cmd2 = new SqlCommand("upd_tuitionfee", d.con);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@feeno", feeno);
                    cmd2.Parameters.AddWithValue("@cstandard", cmbstd.Text);
                    cmd2.Parameters.AddWithValue("@Newsyll", cmbsyll.Text);
                    cmd2.Parameters.AddWithValue("@amount", txtamt.Text);
                    cmd2.Parameters.AddWithValue("@collectiondate", cmbdte.Text);
                    cmd2.Parameters.AddWithValue("@fine", txtfine.Text);
                    cmd2.ExecuteNonQuery();
                    cmbstd.Text = "";
                    cmbsyll.Text = "";
                    cmbdte.Text = "";
                    txtamt.Text = "";
                    txtfine.Text = "";

                    d.con_close();

                    // To display the edited details in datagridview

                    dgv_tuition.DataSource = null;
                    SqlDataAdapter ad = new SqlDataAdapter("select feeno,cstandard,Newsyll,amount,collectiondate,fine from tbl_tuitionfee ", d.con);
                    DataSet ds = new DataSet();
                    ad.Fill(ds);
                    dgv_tuition.DataSource = ds.Tables[0];
                    MessageBox.Show("Fees edited successfully", "Edited..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void dgv_tuition_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            feeno = dgv_tuition.Rows[e.RowIndex].Cells[0].Value.ToString();
            SqlDataAdapter ad = new SqlDataAdapter("select feeno,cstandard,Newsyll,amount,collectiondate,fine from tbl_tuitionfee where feeno='" + feeno + "'", d.con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dr = ds.Tables[0].Rows[0];
                feeno = dr[0].ToString();
                cmbstd.Text = dr[1].ToString();
                cmbsyll.Text = dr[2].ToString();
                txtamt.Text = dr[3].ToString();
                cmbdte.Text = dr[4].ToString();
                txtfine.Text = dr[5].ToString();
            }
            else
            {
                MessageBox.Show("Data does not exist", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you sure to remove the fees ", "warning..", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                d.con_open();
                SqlCommand cmd = new SqlCommand("delete from tbl_tuitionfee where cstandard='" + cmbstd.Text + "' and Newsyll='" + cmbsyll.Text + "'", d.con);
                cmd.Parameters.AddWithValue("cstandard", cmbstd.Text);
                cmd.Parameters.AddWithValue("Newsyll", cmbsyll.Text);
                cmd.Parameters.AddWithValue("amount", txtamt.Text);
                cmd.Parameters.AddWithValue("collectiondate", cmbdte.Text);
                cmd.Parameters.AddWithValue("fine", txtfine.Text);
                cmd.ExecuteNonQuery();
                d.con_close();

                // Display the remaining details in grid

                dgv_tuition.DataSource = null;
                SqlDataAdapter ad = new SqlDataAdapter("select feeno as [Fee Number],cstandard as Standard,Newsyll as Syllabus,amount as Amount,collectiondate as [Collection Date],fine as Fine from tbl_tuitionfee ", d.con);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                dgv_tuition.DataSource = ds.Tables[0];
                //MessageBox.Show("Fees removed successfully", "Removed..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbstd.Text = "";
                cmbsyll.Text = "";
                cmbdte.Text = "";
                txtamt.Text = "";
                txtfine.Text = "";
            }

        }

        private void txtfine_TextChanged(object sender, EventArgs e)
        {

        }
    }
}