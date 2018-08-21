using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SchoolManagement
{
    public partial class frmSupplier : Form
    {
        DataLayer dl = new DataLayer();
        DataView dv;
        string SupplierId = "";
        public static bool supp = true;
        public frmSupplier()
        {
            InitializeComponent();
        }
        public frmSupplier(bool Supplier)
        {
            supp = Supplier;
            InitializeComponent();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (cmdSave.Text == "Save")
                insSupplier();
            else if (cmdSave.Text == "Update")
            {
                if (SupplierId != "")
                    UpdateSupplier();
            }
        }
        private void fill_Supplier()
        {
            txtName.AutoCompleteCustomSource.Clear();
            string s = "SELECT DISTINCT SUPPLIER_NAME FROM tbl_Supplier where SUPPLIER_FLAG='" + rbSupplier.Checked.ToString() + "' ORDER BY SUPPLIER_NAME ASC";
            SqlDataAdapter da = new SqlDataAdapter(s, dl.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count >= 1)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dr = ds.Tables[0].Rows[i];
                    txtName.AutoCompleteCustomSource.Add(dr[0].ToString().Trim());
                }

            }
        }

        private void fill_ListGrid()
        {
            dgvList.DataSource = null;
            dgvList.Rows.Clear();
            dgvList.Columns.Clear();
            string s = @"SELECT SUPPLIER_NO,SUPPLIER_NAME as Name,SUPPLIER_ADDRESS as Address,SUPPLIER_CONTACTNO_1 as [Contact No 1],";
            s = s + " SUPPLIER_CONTACTNO_2 as [Contact No 2],SUPPLIER_FAX as Fax,SUPPLIER_EMAIL as [E-Mail],SUPPLIER_TIN_NO as [Tin No],SUPPLIER_ACCOUNTNO as AccNo,";
            s = s + " SUPPLIER_BANK as Bank,SUPPLIER_BRANCH as Branch,SUPPLIER_IFSC_CODE as [IFSC Code],SUPPLIER_WEBSITE as Website";
            s = s + " FROM tbl_Supplier where SUPPLIER_FLAG='" + rbSupplier.Checked.ToString() + "' ORDER BY SUPPLIER_NAME ASC";

            SqlDataAdapter da = new SqlDataAdapter(s, dl.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dv = ds.Tables[0].DefaultView;
            dgvList.DataSource = dv;
            dgvList.Columns[0].Visible = false;
           // dgvList.Columns[2].Frozen = true;
            dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvList.AutoResizeColumns();
        }

        private void loadSupplier(string id)
        {
            string s = @"SELECT SUPPLIER_NAME as Name,SUPPLIER_ADDRESS as Address,SUPPLIER_CONTACTNO_1 as [Contact No 1],";
            s = s + " SUPPLIER_CONTACTNO_2 as [Contact No 2],SUPPLIER_FAX as Fax,SUPPLIER_EMAIL as [E-Mail],SUPPLIER_TIN_NO as [Tin No],SUPPLIER_ACCOUNTNO as [Account No],";
            s = s + " SUPPLIER_BANK as Bank,SUPPLIER_BRANCH as Branch,SUPPLIER_IFSC_CODE as [IFSC Code],SUPPLIER_WEBSITE as Website";
            s = s + " FROM tbl_Supplier where SUPPLIER_NO=" + id + "AND SUPPLIER_FLAG='" + rbSupplier.Checked.ToString() + "' ORDER BY SUPPLIER_NAME ASC";

            SqlDataAdapter da = new SqlDataAdapter(s, dl.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count >= 1)
            {
                SupplierId = id;
                txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                txtContact1.Text = ds.Tables[0].Rows[0]["Contact No 1"].ToString();
                txtContact2.Text = ds.Tables[0].Rows[0]["Contact No 2"].ToString();
                txtFax.Text = ds.Tables[0].Rows[0]["Fax"].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0]["E-Mail"].ToString();
                txtTin.Text = ds.Tables[0].Rows[0]["Tin No"].ToString();
                txtWebsite.Text = ds.Tables[0].Rows[0]["Website"].ToString();
                txtAccountNo.Text = ds.Tables[0].Rows[0]["Account No"].ToString();
                txtBank.Text = ds.Tables[0].Rows[0]["Bank"].ToString();
                txtBranch.Text = ds.Tables[0].Rows[0]["Branch"].ToString();
                txtIFSCCode.Text = ds.Tables[0].Rows[0]["IFSC Code"].ToString();
                cmdSave.Text = "Update";
            }

        }

        private void clear()
        {
            SupplierId = "";
            txtName.Text = "";
            txtAddress.Text = "";
            txtContact1.Text = "";
            txtContact2.Text = "";
            txtFax.Text = "";
            txtEmail.Text = "";
            txtTin.Text = "";
            txtWebsite.Text = "";
            txtAccountNo.Text = "";
            txtBank.Text = "";
            txtBranch.Text = "";
            txtIFSCCode.Text = "";
            fill_ListGrid();
            cmdSave.Text = "Save";
        }

        private bool Validatefrm()
        {
            bool flag = true;
            string msg = "";

            if (txtName.Text == "")
            {
                flag = false;
                msg = "Enter Name!!..";
                goto EndValidation;
            }
            if (txtAddress.Text == "")
            {
                flag = false;
                msg = "Enter Address!!..";
                goto EndValidation;
            }

        EndValidation:
            if (msg != "")
            {
                MessageBox.Show(msg, "Store", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flag;
        }

        private void insSupplier()
        {
            if (Validatefrm())
            {
                dl.con_open();
                SqlCommand cmd = new SqlCommand("InsSupplier", dl.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@SUPPLIER_NAME", txtName.Text));
                cmd.Parameters.Add(new SqlParameter("@SUPPLIER_ADDRESS", txtAddress.Text));
                cmd.Parameters.Add(new SqlParameter("@SUPPLIER_CONTACTNO_1", txtContact1.Text));
                cmd.Parameters.Add(new SqlParameter("@SUPPLIER_CONTACTNO_2", txtContact2.Text));
                cmd.Parameters.Add(new SqlParameter("@SUPPLIER_FAX", txtFax.Text));
                cmd.Parameters.Add(new SqlParameter("@SUPPLIER_EMAIL", txtEmail.Text));
                cmd.Parameters.Add(new SqlParameter("@SUPPLIER_WEBSITE", txtWebsite.Text));
                cmd.Parameters.Add(new SqlParameter("@SUPPLIER_TIN_NO", txtTin.Text));
                cmd.Parameters.Add(new SqlParameter("@SUPPLIER_ACCOUNTNO", txtAccountNo.Text));
                cmd.Parameters.Add(new SqlParameter("@SUPPLIER_BANK", txtBank.Text));
                cmd.Parameters.Add(new SqlParameter("@SUPPLIER_BRANCH", txtBranch.Text));
                cmd.Parameters.Add(new SqlParameter("@SUPPLIER_IFSC_CODE", txtIFSCCode.Text));
                cmd.Parameters.Add(new SqlParameter("@SUPPLIER_FLAG", rbSupplier.Checked.ToString()));

                cmd.ExecuteNonQuery();
                dl.con_close();
                fill_ListGrid();
                clear();
                MessageBox.Show("Item Successfully Saved!!", "Store");

            }
        }

        private void UpdateSupplier()
        {
            if (Validatefrm())
            {
                dl.con_open();
                SqlCommand cmd = new SqlCommand("UpdateSupplier", dl.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@SUPPLIER_NAME", txtName.Text));
                cmd.Parameters.Add(new SqlParameter("@SUPPLIER_ADDRESS", txtAddress.Text));
                cmd.Parameters.Add(new SqlParameter("@SUPPLIER_CONTACTNO_1", txtContact1.Text));
                cmd.Parameters.Add(new SqlParameter("@SUPPLIER_CONTACTNO_2", txtContact2.Text));
                cmd.Parameters.Add(new SqlParameter("@SUPPLIER_FAX", txtFax.Text));
                cmd.Parameters.Add(new SqlParameter("@SUPPLIER_EMAIL", txtEmail.Text));
                cmd.Parameters.Add(new SqlParameter("@SUPPLIER_WEBSITE", txtWebsite.Text));
                cmd.Parameters.Add(new SqlParameter("@SUPPLIER_TIN_NO", txtTin.Text));
                cmd.Parameters.Add(new SqlParameter("@SUPPLIER_ACCOUNTNO", txtAccountNo.Text));
                cmd.Parameters.Add(new SqlParameter("@SUPPLIER_BANK", txtBank.Text));
                cmd.Parameters.Add(new SqlParameter("@SUPPLIER_BRANCH", txtBranch.Text));
                cmd.Parameters.Add(new SqlParameter("@SUPPLIER_IFSC_CODE", txtIFSCCode.Text));
                cmd.Parameters.Add(new SqlParameter("@SUPPLIER_FLAG", rbSupplier.Checked.ToString()));
                cmd.Parameters.Add(new SqlParameter("@SUPPLIER_NO", SupplierId));

                cmd.ExecuteNonQuery();
                dl.con_close();
                fill_ListGrid();
                MessageBox.Show("Item Successfully Updated!!", "Store");

            }
        }

        private void frmSupplier_Load(object sender, EventArgs e)
        {
            if (supp == true)
            {
                rbSupplier.Checked = true;
            }
            else
            {
                rbCustomer.Checked = true;
            }
            fill_Supplier();
            fill_ListGrid();
        }

        private void rbCustomer_CheckedChanged(object sender, EventArgs e)
        {
            clear();
            fill_ListGrid();
            fill_Supplier();
        }

        private void rbSupplier_CheckedChanged(object sender, EventArgs e)
        {
            clear();
            fill_ListGrid();
            fill_Supplier();
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string str;
            if (e.RowIndex >= 0)
            {
                str = dgvList.Rows[e.RowIndex].Cells[0].Value.ToString();
                loadSupplier(str);
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text.Length == 0)
                {
                    dv.RowFilter = "";
                    dgvList.DataSource = dv;
                }
                else
                {
                    string str = @"Name like '%" + txtName.Text + "%'";
                    dv.RowFilter = str;
                    dgvList.DataSource = dv;

                }
            }
            catch (Exception)
            { }
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (SupplierId != "")
                {
                    DialogResult d1 = new DialogResult();
                    d1 = MessageBox.Show("Are You Sure to Remove this Record", "Store - Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                    if (d1 == DialogResult.Yes)
                    {
                        dl.con_open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM tbl_Supplier WHERE SUPPLIER_NO=" + SupplierId, dl.con);
                        cmd.ExecuteNonQuery();
                        dl.con_close();
                        clear();

                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Some Error Occured!!!..Try After Some Time!!..", "Store");
            }
        }
    }
}
