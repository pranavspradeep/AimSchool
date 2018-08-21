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
    public partial class AmountFromBank : DevComponents.DotNetBar.Office2007Form
    {
        DataLayer d = new DataLayer();
        double balnc=0;
        double total=0;
        double dailybalnc=0;
        double dailytotal=0;
        string str;
        int rcptno = 0;
        SchoolManagement sm = new SchoolManagement();
        public AmountFromBank()
        {
            InitializeComponent();
        }

        private void AmountFromBank_Load(object sender, EventArgs e)
        {
            string s = "select Bankaccno from tbl_account";
            SqlDataAdapter da = new SqlDataAdapter(s, d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count >= 1)
            {

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dr = ds.Tables[0].Rows[i];
                    cmbaccount.Items.Add(dr[0].ToString());
                }
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
           
            if (valid() == true)
            {
                //getbalnc();
               // getdailybalnc();

                d.con_open();
               /* SqlCommand cmd2 = new SqlCommand("ins_trans", d.con);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@tdate", System.DateTime.Now.ToShortDateString());
                SqlParameter trano = new SqlParameter("@trno", SqlDbType.Int);
                trano.Direction = ParameterDirection.Output;
                cmd2.Parameters.Add(trano);
                cmd2.ExecuteNonQuery();*/


                SqlCommand cmd = new SqlCommand("ins_banktrans", d.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@accno",cmbaccount.Text);
                cmd.Parameters.AddWithValue("@amount", txtamount.Text);
                cmd.Parameters.AddWithValue("@type",cmbtype.Text );
                //cmd.Parameters.AddWithValue("@balnc",total);
               // cmd.Parameters.AddWithValue("@transdate",System.DateTime.Now.ToShortDateString());
                
            
                SqlCommand cmd1 = new SqlCommand("ins_dailytrans", d.con);
                cmd1.CommandType = CommandType.StoredProcedure;
                //cmd1.Parameters.AddWithValue("@trno", trano.Value.ToString());
               // cmd1.Parameters.AddWithValue("@date", System.DateTime.Now.ToShortDateString());
                rcptno = sm.rtv_receiptno();
                cmd1.Parameters.AddWithValue("@trano", rcptno);              
                cmd1.Parameters.AddWithValue("@type",cmbtype.Text);
                cmd1.Parameters.AddWithValue("@desc", txtdescr.Text);
                cmd1.Parameters.AddWithValue("@amt", txtamount.Text);
               // cmd1.Parameters.AddWithValue("@balc", dailytotal);
                
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();

                
                MessageBox.Show("Amount "+txtamount.Text+" is successfully "+cmbtype.Text+" to your "+cmbaccount.Text+ " bank account ","Message..",MessageBoxButtons.OK,MessageBoxIcon.Information);
                clear();
                d.con_close();
            }
        }
        private void clear()
        {
            cmbtype.Text = "";
            cmbaccount.Text = "";
            txtamount.Text = "";
            txtdescr.Text = "";
        }
        private void getdailybalnc()
        {
            //for daily transaction balance update
            SqlDataAdapter da = new SqlDataAdapter("select top(1) SlNo,Balance from tbl_dailytrans ORDER BY SlNo DESC", d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];
                dailybalnc = Convert.ToDouble(dr[1].ToString());
                if (cmbtype.Text == "Credit")
                {
                    dailytotal = dailybalnc - Convert.ToDouble(txtamount.Text);
                }
                else if (cmbtype.Text == "Debit")
                {
                    dailytotal = dailybalnc + Convert.ToDouble(txtamount.Text);
                }
            }
            else
            {
                    dailybalnc=0;
                    if (cmbtype.Text == "Credit")
                    {
                       dailytotal = dailybalnc - Convert.ToDouble(txtamount.Text);
                    }
                    else if (cmbtype.Text == "Debit")
                    {
                        dailytotal = dailybalnc + Convert.ToDouble(txtamount.Text);
                    }
            }
        }
        private void getbalnc()
        {
            //for bank transaction balance update
            SqlDataAdapter da = new SqlDataAdapter("select top(1) TransactionNo,Balance from tbl_Banktran Where Bankname='"+cmbaccount.Text +"' ORDER BY TransactionNo DESC ", d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];
                balnc = Convert.ToDouble(dr[1].ToString());
                if (cmbtype.Text == "Credit")
                {
                    total = balnc + Convert.ToDouble(txtamount.Text);
                }
                else if (cmbtype.Text == "Debit")
                {
                    total = balnc - Convert.ToDouble(txtamount.Text);
                }
            }
            else
            {
                string s1 = "select top(1) AccountBalance from tbl_account Where BankName='" + cmbaccount.Text + "'";
                SqlDataAdapter da1 = new SqlDataAdapter(s1, d.con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                DataRow dr1;
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    dr1 = ds1.Tables[0].Rows[0];
                    balnc = Convert.ToDouble(dr1[0].ToString());
                    if (cmbtype.Text == "Credit")
                    {
                        total = balnc + Convert.ToDouble(txtamount.Text);
                    }
                    else if (cmbtype.Text == "Debit")
                    {
                        total = balnc - Convert.ToDouble(txtamount.Text);
                    }
                }

            }
           
        }
        private Boolean valid()
        {
            Boolean f = true;
            if (cmbaccount.Text == "" || cmbaccount.Text == null)
            {
                f = false;
                MessageBox.Show("Please select your bank", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (txtamount.Text == "" || txtamount.Text == null)
            {
                f = false;
                MessageBox.Show("Please enter an amount", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (txtdescr.Text == "" || txtdescr.Text == null)
            {
                f = false;
                MessageBox.Show("Please enter description", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return f;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void cmbaccount_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}