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
    public partial class AccountBalanceForm : DevComponents.DotNetBar.Office2007Form
    {
        DataLayer d = new DataLayer();
        
        public AccountBalanceForm()
        {
            InitializeComponent();
        }
        public Boolean valid()
        {
            Boolean f = true;
            if (txtbankacno.Text == "" || txtbankacno.Text  == null)
            {
                f = false;
                MessageBox.Show("Please enter account number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtbank.Text  == "" || txtbank.Text  == null)
            {
                f = false;
                MessageBox.Show("Please enter Bank", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtaccount.Text  == "" || txtaccount.Text  == null)
            {
                f = false;
                MessageBox.Show("Please enter Account Details", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return f;
        }


        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AccountBalanceForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (valid() == true)
            {
                
                //Account Number Already Exists

               // SqlDataAdapter da1 = new SqlDataAdapter("select BankName from tbl_account where BankName='" +txtbank.Text + "'", d.con);
                string p = "SELECT  Bankaccno,AccountBalance, BankName FROM  tbl_account where BankName='" + txtbank.Text + "' AND Bankaccno= '" + txtbankacno.Text.Trim() + "'";
                SqlDataAdapter da1 = new SqlDataAdapter(p, d.con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                if (ds1.Tables[0].Rows.Count >= 1)
                {
                    MessageBox.Show("Account Number Already Exist", "Saved..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                else
                {

                    d.con_open();
                    SqlCommand cmd = new SqlCommand("ins_tbl_account", d.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Bankaccno", txtbankacno.Text);
                    cmd.Parameters.AddWithValue("@BankName", txtbank.Text);
                    cmd.Parameters.AddWithValue("@AccountBalance",txtaccount.Text);
                    MessageBox.Show("Account details saved successfully", "Saved..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtbankacno.Text = "";
                    txtbank.Text = "";
                    txtaccount.Text = "";
                    cmd.ExecuteNonQuery();
                    d.con_close();
                }
            }
        }
            
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        }
    }
