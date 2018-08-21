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
    public partial class Fee : DevComponents.DotNetBar.Office2007Form
    {
        DataLayer d = new DataLayer();
        DataSet ds1 = new DataSet();
        DataRow dr;
        string feeid = "";
        string feeno = "";
        
       
        public Fee()
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
                    SqlDataAdapter ad = new SqlDataAdapter("select feeno as [FeeNumber],cstandard as Standard,Newsyll as Syllabus,amount as Amount,collectiondate as [CollectionDate],fine as Fine from tbl_tuitionfee ", d.con);
                    DataSet ds = new DataSet();
                    ad.Fill(ds);
                    dgv_tuition.DataSource = ds.Tables[0];
                    MessageBox.Show("Fees edited successfully", "Edited..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }


        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            cmbstd.Text = "";
            cmbsyll.Text = "";
            cmbdte.Text = "";
            txtamt.Text = "";
            txtfine.Text = "";
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {

            if (cmbstd.Text == "" || cmbstd.Text == null)
            {
                MessageBox.Show("Enter standard or Select the Details From the List Below", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbsyll.Text == "" || cmbsyll.Text == null)
            {
                MessageBox.Show("Enter Syllabus or Select the Details From the List Below", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                DialogResult r = MessageBox.Show("Are you sure to remove the fee details ", "warning..", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                    cmbstd.Text = "";
                    cmbsyll.Text = "";
                    cmbdte.Text = "";
                    txtamt.Text = "";
                    txtfine.Text = "";
                }
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Fee_Load(object sender, EventArgs e)
        {

            //select syllabus from table

            d.con_open();

            SqlCommand cmd1 = new SqlCommand("sel_syllabus", d.con);
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlDataReader rd = cmd1.ExecuteReader();
            cmbsy.Items.Clear();
            while (rd.Read())
            {
                cmbsy.Items.Add(rd[0].ToString());
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

            SqlDataAdapter ad = new SqlDataAdapter("select feeid as [Fee Id],feetype as [Fee Type],cstandard as Standard,Newsyll as Syllabus,amount as Amount,collection as [Collection Date],fine as Fine from tbl_fee", d.con);
            ad.Fill(ds1);
            
            if (ds1.Tables[0].Rows.Count >= 1)
            {
                dr = ds1.Tables[0].Rows[0];
                dgv_fees.DataSource = ds1.Tables[0];
                dgv_fees.Columns["Fee Id"].Visible = false;
            }


            //To select syllabus from table

            d.con_open();

            SqlCommand cmd3 = new SqlCommand("sel_syllabus", d.con);
            cmd3.CommandType = CommandType.StoredProcedure;
            SqlDataReader rd3 = cmd3.ExecuteReader();
            cmbsyll.Items.Clear();
            while (rd3.Read())
            {
                cmbsyll.Items.Add(rd3[0].ToString());
            }

            d.con_close();

            // display details in datagridview

            SqlDataAdapter ad1 = new SqlDataAdapter("select feeno as [Fee Number],cstandard as Standard,Newsyll as Syllabus,amount as Amount,collectiondate as [Collection Date],fine as Fine from tbl_tuitionfee", d.con);
            DataSet ds3 = new DataSet();
            ad1.Fill(ds3);
            if (ds1.Tables[0].Rows.Count >= 1)
            {
                dgv_tuition.DataSource = ds3.Tables[0];
                dgv_tuition.Columns["Fee Number"].Visible = false;
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
        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void Save_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {

        }

        private void btn_c_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_cl_Click(object sender, EventArgs e)
        {
            
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
                cmbs.Text = dr2[1].ToString();
                cmbsy.Text = dr2[2].ToString();
                txtamount.Text = dr2[3].ToString();
                dtpcollect.Text = dr2[4].ToString().Trim();
                txtf.Text = dr2[5].ToString();
            }
            else
            {
                MessageBox.Show("Data does not exist", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btn_ed_Click(object sender, EventArgs e)
        {
            if (txtamount.Text == "" || txtamount.Text == null)
            {
                MessageBox.Show("Enter Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmboth.Text == "" || cmboth.Text == null)
            {
                MessageBox.Show("Enter Feetype ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbs.Text == "" || cmbs.Text == null)
            {
                MessageBox.Show("Enter Standard", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbsy.Text == "" || cmbsy.Text == null)
            {
                MessageBox.Show("Enter Syllabus", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                d.con_open();

                SqlCommand cmnd = new SqlCommand("upd_fee", d.con);
                cmnd.CommandType = CommandType.StoredProcedure;
                cmnd.Parameters.AddWithValue("@feeid", feeid);
                cmnd.Parameters.AddWithValue("@feetype", cmboth.Text);
                cmnd.Parameters.AddWithValue("@cstandard", cmbs.Text);
                cmnd.Parameters.AddWithValue("@Newsyll", cmbsy.Text);
                cmnd.Parameters.AddWithValue("@amount", txtamount.Text);
                cmnd.Parameters.AddWithValue("@collection", DateTime.Parse(dtpcollect.Text.ToString()).ToString("dd-MMM-yy"));
                cmnd.Parameters.AddWithValue("@fine", txtf.Text);
                cmnd.ExecuteNonQuery();

                cmbs.Text = "";
                cmbsy.Text = "";
                txtamount.Text = "";
                dtpcollect.Text = "";
                txtf.Text = "";
                cmboth.Text = "";

                d.con_close();

                // Display edited fees in datagridview

                dgv_fees.DataSource = null;
                SqlDataAdapter ads = new SqlDataAdapter("select  feeid as [FeeId],feetype as [FeeType],cstandard as Standard,Newsyll as Syllabus,amount as Amount,collection as [CollectionDate],fine as Fine from tbl_fee ", d.con);
                DataSet dsa = new DataSet();
                ads.Fill(dsa);
                dgv_fees.DataSource = dsa.Tables[0];
                MessageBox.Show("Fees Edited Successfully", "Edited...", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btn_can_Click(object sender, EventArgs e)
        {
            cmboth.Text = "";
            cmbs.Text = "";
            cmbsy.Text = "";
            txtamount.Text = "";
            txtf.Text = "";
        }

        private void btn_rem_Click(object sender, EventArgs e)
        {
            if (txtamount.Text == "" || txtamount.Text == null)
            {
                MessageBox.Show("Enter Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmboth.Text == "" || cmboth.Text == null)
            {
                MessageBox.Show("Enter Feetype ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbs.Text == "" || cmbs.Text == null)
            {
                MessageBox.Show("Enter Standard", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbsy.Text == "" || cmbsy.Text == null)
            {
                MessageBox.Show("Enter Syllabus", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                DialogResult r = MessageBox.Show("Are you sure to remove the fees", "warning..", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {

                    d.con_open();
                    SqlCommand cmd = new SqlCommand("delete from tbl_fee where feeid='" + feeid + "'", d.con);
                    cmd.Parameters.AddWithValue("feetype", cmboth.Text);
                    cmd.Parameters.AddWithValue("cstandard", cmbs.Text);
                    cmd.Parameters.AddWithValue("Newsyll", cmbsy.Text);
                    cmd.Parameters.AddWithValue("amount", txtamount.Text);
                    cmd.Parameters.AddWithValue("collection", DateTime.Parse(dtpcollect.Text.ToString()).ToString("dd-MMM-yy"));
                    cmd.Parameters.AddWithValue("fine", txtf.Text);
                    cmd.ExecuteNonQuery();
                    d.con_close();
                    // Display the remaining fees in datagridview

                    dgv_fees.DataSource = null;
                    SqlDataAdapter ads = new SqlDataAdapter("select  feeid as [FeeId],feetype as [FeeType],cstandard as Standard,Newsyll as Syllabus,amount as Amount,collection as [CollectionDate],fine as Fine from tbl_fee ", d.con);
                    DataSet dsa = new DataSet();
                    ads.Fill(dsa);
                    dgv_fees.DataSource = dsa.Tables[0];
                    cmbs.Text = "";
                    cmbsy.Text = "";
                    txtamount.Text = "";
                    dtpcollect.Text = "";
                    txtf.Text = "";
                    cmboth.Text = "";
                }
            }


        }

        private void btn_Save_Click_1(object sender, EventArgs e)
        {
            if (cmboth.Text == "" || cmboth.Text == null)
            {
                MessageBox.Show("Enter Feetype ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbs.Text == "" || cmbs.Text == null)
            {
                MessageBox.Show("Enter Standard", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbs.Text == "" || cmbsy.Text == null)
            {
                MessageBox.Show("Enter Syllabus", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtamount.Text == "" || txtamount.Text == null)
            {
                MessageBox.Show("Enter Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlDataAdapter ad1 = new SqlDataAdapter("select feetype,cstandard,Newsyll from tbl_fee where cstandard='" + cmbs.Text + "'and Newsyll='" + cmbsy.Text + "'and feetype='" + cmboth.Text + "' ", d.con);
                DataSet ds1 = new DataSet();
                ad1.Fill(ds1);
                if (ds1.Tables[0].Rows.Count >= 1)
                {
                    MessageBox.Show("Fees already exist", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbs.Text = "";
                    cmbsy.Text = "";
                    txtamount.Text = "";
                    dtpcollect.Text = "";
                    txtf.Text = "";
                    cmboth.Text = "";
                }

                else
                {
                    d.con_open();

                    SqlCommand cmd = new SqlCommand("ins_fee", d.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@feetype", cmboth.Text);
                    cmd.Parameters.AddWithValue("@cstandard", cmbs.Text);
                    cmd.Parameters.AddWithValue("@Newsyll", cmbsy.Text);
                    cmd.Parameters.AddWithValue("@amount", txtamount.Text);
                    cmd.Parameters.AddWithValue("@collection", DateTime.Parse(dtpcollect.Text.ToString()).ToString("dd-MMM-yy"));
                    cmd.Parameters.AddWithValue("@fine", txtf.Text);
                    cmd.ExecuteNonQuery();
                    cmbs.Text = "";
                    cmbsy.Text = "";
                    txtamount.Text = "";
                    dtpcollect.Text = "";
                    txtf.Text = "";
                    cmboth.Text = "";
                    d.con_close();

                    // Display added fee details in datagridview

                    dgv_fees.DataSource = null;
                    DataSet ds2 = new DataSet();
                    SqlDataAdapter ad = new SqlDataAdapter("select feeid as [FeeId],feetype as [FeeType],cstandard as Standard,Newsyll as Sllabus,amount as Amount,collection as [CollectionDate],fine as Fine from tbl_fee", d.con);
                    ad.Fill(ds2);
                    dr = ds2.Tables[0].Rows[0];
                    dgv_fees.DataSource = ds2.Tables[0];
                    MessageBox.Show("Data added successfully", "Added..", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
            }
        }

        private void btn_cl_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}