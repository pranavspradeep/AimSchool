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
    public partial class frmCrstBankTrns : Form
    {
        DataLayer d = new DataLayer();
        public frmCrstBankTrns()
        {
            InitializeComponent();
        }

        private void btnshow_Click(object sender, EventArgs e)
        {
            if (dtpb1.Value <= dtpb2.Value)
            {

                string s = "SELECT     ba.AccountNumber, ba.BankName,bt.Amount, bt.Balance, bt.Type,bt.TransactionDate FROM tbl_Bankadrs AS ba INNER JOIN tbl_BankTran AS bt ON ba.AccountNumber = bt.BankAccNo WHERE TransactionDate >='" + dtpb1.Value + "'AND bt.TransactionDate <='" + dtpb2.Value + "'AND ba.AccountNumber='" + cmbAccNo.Text + "'  ORDER BY bt.TransactionDate DESC ";
                SqlDataAdapter da = new SqlDataAdapter(s, d.con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    MessageBox.Show("NoTransaction Avialable between these two date", "Warning....", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("To date shoul be greater than that of from date", "Warning....", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbAccNo.Text == "" || cmbAccNo.Text == null)
            {
                MessageBox.Show("Please select Account Number", "Error..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SchoolManagement.accno = cmbAccNo.Text;
                SchoolManagement.dtpb1 = Convert.ToString(dtpb1.Value);
                SchoolManagement.dtpb2 = Convert.ToString(dtpb2.Value);
                string s = "SELECT * FROM tbl_Bankadrs AS ba INNER JOIN tbl_BankTran AS bt ON ba.AccountNumber = bt.BankAccNo WHERE TransactionDate >='" + SchoolManagement.dtpb1 + "'AND bt.TransactionDate <='" + SchoolManagement.dtpb2 + "'AND bt.BankAccNo='" + SchoolManagement.accno + "' ORDER BY bt.TransactionDate DESC ";
                SqlDataAdapter da = new SqlDataAdapter(s, d.con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    
                    Crstlbanktrans fbt = new Crstlbanktrans();
                    fbt.Show();
                }
                else
                {
                    MessageBox.Show("No transaction avialable between these two days", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
        }

        private void frmCrstBankTrns_Load(object sender, EventArgs e)
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


            string s = "SELECT     ba.AccountNumber, ba.BankName, ba.IFSCCode, bt.Amount, bt.Balance, bt.Type, bt.TransactionDate FROM tbl_Bankadrs AS ba INNER JOIN tbl_BankTran AS bt ON ba.AccountNumber = bt.BankAccNo ORDER BY bt.TransactionDate DESC ";
            SqlDataAdapter da = new SqlDataAdapter(s, d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void cmbAccNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = "SELECT     ba.AccountNumber, ba.BankName,bt.Amount, bt.Balance, bt.Type,bt.TransactionDate FROM tbl_Bankadrs AS ba INNER JOIN tbl_BankTran AS bt ON ba.AccountNumber = bt.BankAccNo where ba.AccountNumber='" + cmbAccNo.Text + "'ORDER BY bt.TransactionDate DESC ";
            //WHERE TransactionDate >='" + dtpb1.Value + "'AND bt.TransactionDate <='" + dtpb2.Value + "'AND ba.AccountNumber='"+cmbAccNo.Text +"' 
            SqlDataAdapter da = new SqlDataAdapter(s, d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                dataGridView1.DataSource = "";
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          string a = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
           cmbAccNo.Text = a;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}