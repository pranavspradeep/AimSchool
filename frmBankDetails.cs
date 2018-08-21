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
    public partial class frmBankDetails : Form
    {
        DataLayer d = new DataLayer();
        public Boolean f;

        public frmBankDetails()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (valid() == true)
            {
                d.con_open();
                SqlCommand cmd = new SqlCommand("ins_bankadrs", d.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@acn", txtAccuntno.Text);
                cmd.Parameters.AddWithValue("bankname", txtbankname.Text);
                cmd.Parameters.AddWithValue("@ifsc", txtIFSCcode.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Bank details saved successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                d.con_close();
                clear();
            }


        }
        private Boolean valid()
        {
            f = true;
            if(txtAccuntno.Text == ""||txtAccuntno.Text ==null)
            {
                f = false;
                MessageBox.Show("Plese enter your Bank account number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (txtbankname.Text == "" || txtbankname.Text == null)
            {
                f = false;
                MessageBox.Show("Plese enter your Bank name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtIFSCcode.Text == "" || txtIFSCcode.Text == null)
            {
                f = false;
                MessageBox.Show("Plese enter IFSC code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            return f;
        }
        private void clear()
        {
            txtAccuntno.Text = "";
            txtIFSCcode.Text = "";
            txtbankname.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmCrstBankTrns frm = new frmCrstBankTrns();
            frm.Show();

        }
    }
}