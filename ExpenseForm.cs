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
    public partial class ExpenseForm : Form
    {
        DataLayer d = new DataLayer();
        string Expenseno = "";
        
        public ExpenseForm()
        {
            InitializeComponent();
        }
        public Boolean valid()
        {
            Boolean f = true;
            if (txtdate.Text == "" || txtdate.Text == null)
            {
                f = false;
                MessageBox.Show("Please enter Date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (txtinvoicenumber.Text == "" || txtinvoicenumber.Text == null)
            {
                f = false;
                MessageBox.Show("Please enter Invoice number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (txtamount.Text == "" || txtamount.Text == null)
            {
                f = false;
                MessageBox.Show("Please enter Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            else if (txtemployeename.Text == "" || txtemployeename.Text == null)
            {
                f = false;
                MessageBox.Show("Please enter EmployeeName", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (txtexpdetls.Text == "" || txtexpdetls.Text == null)
            {
                f = false;
                MessageBox.Show("Please enter Expense Details", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return f;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (valid() == true)
            {
                d.con_open();
                
                    SqlCommand cmd = new SqlCommand("ins_tbl_expense", d.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Date", DateTime.Parse(txtdate.Text.ToString()).ToString("dd-MMM-yy"));
                    cmd.Parameters.AddWithValue("@EspDetails", txtexpdetls.Text);
                    cmd.Parameters.AddWithValue("@Invoiceno", txtinvoicenumber.Text);
                    cmd.Parameters.AddWithValue("@Amount", txtamount.Text);
                    cmd.Parameters.AddWithValue("@EmpName", txtemployeename.Text);
                    cmd.Parameters.AddWithValue("@Expsource",cmbexpense.Text);
                    MessageBox.Show("Expense details saved successfully", "Saved..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtdate.Text = "";
                    txtexpdetls.Text = "";
                    txtinvoicenumber.Text = "";
                    txtamount.Text = "";
                    txtemployeename.Text = "";
                    cmbexpense.Text = "";
                    cmd.ExecuteNonQuery();
                    txtemployeename.Focus();
                    gdv_expense.DataSource = null;

                    //Display the saved details in datagridview

                    SqlDataAdapter ad = new SqlDataAdapter("select Expenseno as [Expense Number],Date as [Expense Date],Invoiceno as [Invoiceno],Amount as [Amount],EmpName as [EmpName] from tbl_expense", d.con);
                    DataSet ds1 = new DataSet();
                    ad.Fill(ds1);
                    gdv_expense.DataSource = ds1.Tables[0];

                    d.con_close();
                }
            }
        
    

        private void gdv_expense_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Expenseno = gdv_expense.Rows[e.RowIndex].Cells[0].Value.ToString();

            SqlDataAdapter ad = new SqlDataAdapter("select Date,EspDetails,Invoiceno,Amount,EmpName from tbl_expense where Expenseno='" + Expenseno + "'", d.con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dr = ds.Tables[0].Rows[0];
                txtdate.Text = dr[0].ToString();
                txtexpdetls.Text = dr[1].ToString();
                txtinvoicenumber.Text = dr[2].ToString();
                txtamount.Text = dr[3].ToString();
                txtemployeename.Text = dr[4].ToString();

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

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            txtdate.Text = "";
            txtexpdetls.Text = "";
            txtinvoicenumber.Text = "";
            txtamount.Text = "";
            txtemployeename.Text = "";
            cmbexpense.Text = "";
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (valid() == true)
            {
                d.con_open();

                SqlDataAdapter da = new SqlDataAdapter("select AccountBalance,Bankaccno  from tbl_account where Bankaccno='" + cmbaccount.Text + "'", d.con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataRow dr;
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    double amtno;
                    dr = ds.Tables[0].Rows[0];
                    amtno = Convert.ToDouble(dr[0].ToString());
                    amtno = (Convert.ToDouble(dr[0].ToString())) - (Convert.ToDouble(txtamount.Text));
                   // amtno = (Convert.ToDouble(txtamount.Text)) - (Convert.ToDouble(dr[0].ToString()));

                    SqlCommand cmd = new SqlCommand("edit_tbl_expense", d.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Expenseno", Expenseno);
                    cmd.Parameters.AddWithValue("@Date", DateTime.Parse(txtdate.Text.ToString()).ToString("dd-MMM-yy"));
                    cmd.Parameters.AddWithValue("@EspDetails", txtexpdetls.Text);
                    cmd.Parameters.AddWithValue("@Invoiceno", txtinvoicenumber.Text);
                    cmd.Parameters.AddWithValue("@Amount", amtno);
                    cmd.Parameters.AddWithValue("@EmpName", txtemployeename.Text);
                    cmd.Parameters.AddWithValue("@Expsource", cmbexpense.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Data edited successfully", "Edited..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtdate.Text = "";
                    txtexpdetls.Text = "";
                    txtinvoicenumber.Text = "";
                    txtamount.Text = "";
                    txtemployeename.Text = "";
                    d.con_close();


                    // Display the edited teachers details in datagridview

                    SqlDataAdapter ad = new SqlDataAdapter("select Expenseno as [Expense Number],Date as [Expense Date],Invoiceno as [Invoiceno],Amount as [Amount],EmpName as [EmpName] from tbl_expense", d.con);
                    DataSet ds1 = new DataSet();
                    ad.Fill(ds1);
                    gdv_expense.DataSource = ds1.Tables[0];
                }
                

            }

        }
        private void ExpenseForm_Load(object sender, EventArgs e)
        {
            d.con_open();
            SqlDataAdapter ad = new SqlDataAdapter("select Expenseno as [Expense Number],Date as [Expense Date],Invoiceno as [Invoiceno],Amount as [Amount],EmpName as [EmpName] from tbl_expense", d.con);
            DataSet ds1 = new DataSet();
            ad.Fill(ds1);
            gdv_expense.DataSource = ds1.Tables[0];

            //To select Bankaccno from table

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


            d.con_close();
        }

        private void cmbaccount_SelectedIndexChanged(object sender, EventArgs e)
        {

           

        }

        private void cmbexpense_SelectedValueChanged(object sender, EventArgs e)
        {
           
            if (cmbexpense.Text == "By Hand")
            {
                cmbaccount.Visible = false;
                bankacc.Visible = false;
                

            }
            if (cmbexpense.Text == "From Bank")
            {
               
                
                cmbaccount.Visible = true;
                bankacc.Visible = true;
                txtamount.Visible = true;
                Amount.Visible = true;
               
                SqlDataAdapter ad4 = new SqlDataAdapter("select Bankaccno,BankName,AccountBalance from tbl_account", d.con);
                DataSet ds4 = new DataSet();
                ad4.Fill(ds4);
                gdv_expense.DataSource = ds4.Tables[0];

               
            }
            

        }

        private void txtamount_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void cmbexpense_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}


