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
    public partial class frmBankBalance : Form
    {
        DataLayer d = new DataLayer();
        public string b;
        double f = 0.0;
        public int c;
        public Boolean h;
        public frmBankBalance()
        {
            InitializeComponent();
        }

        private void cmbAccNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s="select BankName,IFSCCode from tbl_Bankadrs where AccountNumber='" + cmbAccNo.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(s,d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataRow dr;
            if(ds.Tables[0].Rows.Count>0)
            {
                dr = ds.Tables[0].Rows[0];
                txtbankname.Text=dr[0].ToString();
                txtIFSCcode.Text=dr[1].ToString();
            }
            
            
        }

        private void frmBankBalance_Load(object sender, EventArgs e)
        {
            
            d.con_open();
            SqlCommand cmd = new SqlCommand("select AccountNumber from tbl_Bankadrs", d.con);
            SqlDataReader rd = cmd.ExecuteReader();
            cmbAccNo.Items.Clear();
            while (rd.Read())
            {
                cmbAccNo.Items.Add(rd[0].ToString());
            }
            d.con_close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string s1 = "Select AccountNumber from tbl_BankAdrs where AccountNumber='" + cmbAccNo.Text + "'";
            SqlDataAdapter da1 = new SqlDataAdapter(s1, d.con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                if (valid() == true)
                {
                    string s = "SELECT TOP (1) TransactionNo,Balance FROM  tbl_BankTran WHERE BankAccNo = '" + cmbAccNo.Text + "'ORDER BY TransactionNo DESC";
                    SqlDataAdapter da = new SqlDataAdapter(s, d.con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    DataRow dr;
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dr = ds.Tables[0].Rows[0];
                        f = Convert.ToDouble(dr[1].ToString());

                        if (cmbtype.Text == "Credit")
                        {
                            f = f - Convert.ToDouble(txtamount.Text);
                            trnssave();
                        }
                        else if (cmbtype.Text == "Debit")
                        {
                            f = f + Convert.ToDouble(txtamount.Text);
                            trnssave();
                        }

                    }
                    else
                    {
                        if (cmbtype.Text == "Credit")
                        {
                            f = 0 - Convert.ToDouble(txtamount.Text);
                            trnssave();
                        }
                        else if (cmbtype.Text == "Debit")
                        {
                            f = 0 + Convert.ToDouble(txtamount.Text);
                            trnssave();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid Account No", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void trnssave()
        {

            d.con_open();
            SqlCommand cmd1 = new SqlCommand("ins_banktrans", d.con);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@accno", cmbAccNo.Text);
            cmd1.Parameters.AddWithValue("@amount",txtamount.Text);
            cmd1.Parameters.AddWithValue("@type", cmbtype.Text);
            cmd1.Parameters.AddWithValue("@transdate", DateTime.Now.ToString("dd/MMM/yy"));
            cmd1.Parameters.AddWithValue("@balnc",f);
            cmd1.ExecuteNonQuery();
            MessageBox.Show("Successfully added", "message...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            d.con_close();
            clear();
        }
        private Boolean valid()
        {
            h = true;
            if (cmbAccNo.Text == "" || cmbAccNo.Text == null)
            {
                h = false;
                MessageBox.Show("Please select your AccountNo", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(txtamount.Text==""||txtamount.Text==null)
            {
                 h = false;
                 MessageBox.Show("Please Enter Amount", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cmbtype.Text == "" || cmbtype == null)
            {
                h = false;
                MessageBox.Show("Please Enter Amount", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return h;
        }
        private void clear()
        {
            cmbAccNo.Text = "";
            cmbtype.Text = "";
            txtamount.Text = "";
            txtbankname.Text = "";
            txtIFSCcode.Text = "";
        }
 

        
       
    }
}