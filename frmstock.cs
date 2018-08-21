using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SchoolManagement
{
    public partial class frmstock : Form
    {
        #region  User Declarations

        DataLayer dl = new DataLayer();
        DataView dv, dv1, dv2;
        string SupplierNo = "";
        string PurchaseNo = "";

        string itemno = "";
        string category = "";
        string delItemPur_no = "";
        string delItemID = "";
        string delUpdatedStock = "";

        #endregion

        public frmstock()
        {
            InitializeComponent();
        }

        #region Public User Defined Functions

        public void clear()
        {
            PurchaseNo = "";
            SupplierNo = "";
            txtSupplier.Text = "";
            txtAddr.Text = "";
            txtPurchaseAmount.Text = "";
            txtInvoiceNo.Text = "";
            txtVehicleNo.Text = "";
            txtFilterName.Text = "";
            txtFilterCategory.Text = "";
            txtFilterManufacturer.Text = "";
            dtpPurchaseDate.Text = DateTime.Today.ToShortDateString();
            cmdSaveItem.Text = "Save";
            delItemID = "";
            delItemPur_no = "";
            delUpdatedStock = "";

            dgvItemList.DataSource = null;
            dgvItemList.Rows.Clear();
            dgvItemList.Columns.Clear();

            dgvPurchasedItem.DataSource = null;
            dgvPurchasedItem.Rows.Clear();
            dgvPurchasedItem.Columns.Clear();


        }

        private void fill_Supplier()
        {
            txtSupplier.AutoCompleteCustomSource.Clear();
            string s = "SELECT DISTINCT SUPPLIER_NAME FROM tbl_Supplier where SUPPLIER_FLAG='True' ORDER BY SUPPLIER_NAME ASC";
            SqlDataAdapter da = new SqlDataAdapter(s, dl.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count >= 1)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dr = ds.Tables[0].Rows[i];
                    txtSupplier.AutoCompleteCustomSource.Add(dr[0].ToString().Trim());
                }

            }
        }

        private void fill_ItemGrid()
        {
            try
            {
                dgvItemList.DataSource = null;
                dgvItemList.Rows.Clear();
                dgvItemList.Columns.Clear();
                string s = @"SELECT DISTINCT ITEM_ID,ITEM_NAME as Item,ITEM_CATEGORY as Category,ITEM_MANUFACTURER as Manufacturer,ITEM_QTY as Qty,ITEM_PURCHASE_AMOUNT as [Purchase Amount],ITEM_RETAIL_PRICE as [Retail Price] FROM tbl_Item ORDER BY ITEM_NAME ASC";
                SqlDataAdapter da = new SqlDataAdapter(s, dl.con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dv = ds.Tables[0].DefaultView;
                dgvItemList.DataSource = dv;
                dgvItemList.Columns[0].Visible = false;
                dgvItemList.Columns[2].Frozen = true;
                dgvItemList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvItemList.AutoResizeColumns();
            }
            catch (Exception)
            { }
        }

        private void fill_PurchaseItems()
        {
            try
            {
                dgvPurchasedItem.DataSource = null;
                dgvPurchasedItem.Rows.Clear();
                dgvPurchasedItem.Columns.Clear();
                string s = @"SELECT DISTINCT PURCHASE_ID,ITEM_ID,ITEM_NAME as [Item Name],ITEM_CATEGORY as Category,";
                s = s + " ITEM_QTY as [Total Stock],ITEM_QUANTITY as [Updated Stock]";
                s = s + "  FROM tbl_Item i,tbl_Purchase p";
                s = s + "  where i.ITEM_ID=p.ITEM_NO and PURCHASE_NO=" + PurchaseNo + "ORDER BY ITEM_NAME ASC";
                SqlDataAdapter da = new SqlDataAdapter(s, dl.con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dv2 = ds.Tables[0].DefaultView;
                dgvPurchasedItem.DataSource = dv2;
                dgvPurchasedItem.Columns[0].Visible = false;
                dgvPurchasedItem.Columns[1].Visible = false;
                dgvPurchasedItem.Columns[2].Frozen = true;
                dgvPurchasedItem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvPurchasedItem.AutoResizeColumns();
            }
            catch (Exception)
            { }
        }

        private void fill_PurchaseGrid()
        {
            try
            {
                dgvPurchase.DataSource = null;
                dgvPurchase.Rows.Clear();
                dgvPurchase.Columns.Clear();
                string s = @"SELECT DISTINCT PURCHASE_NO,P.SUPPLIER_NO,INVOICE_NO,SUPPLIER_NAME,SUPPLIER_ADDRESS,PURCHASE_AMOUNT,PURCHASE_DATE,PURCHASE_VEHICLE_NO FROM tbl_PurchaseMaster P,tbl_Supplier S where P.SUPPLIER_NO=S.SUPPLIER_NO ORDER BY PURCHASE_DATE ASC";
                SqlDataAdapter da = new SqlDataAdapter(s, dl.con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dv1 = ds.Tables[0].DefaultView;
                dgvPurchase.DataSource = dv1;
                dgvPurchase.Columns[0].Visible = false;
                dgvPurchase.Columns[1].Visible = false;
                dgvPurchase.Columns[3].Frozen = true;
                dgvPurchase.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvPurchase.AutoResizeColumns();
            }
            catch (Exception)
            { }
        }

        private bool Validatefrm()
        {
            bool flag = true;
            string msg = "";

            if (txtInvoiceNo.Text == "")
            {
                flag = false;
                msg = "Enter Invoice Number!!..";
                goto EndValidation;
            }
            if (txtPurchaseAmount.Text == "")
            {
                flag = false;
                msg = "Enter Purchase Amount!!..";
                goto EndValidation;
            }

        EndValidation:
            if (msg != "")
            {
                MessageBox.Show(msg, "Store", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flag;
        }

        private void UpdatePurchase()
        {
            if (Validatefrm())
            {
                try
                {
                    dl.con_open();
                    SqlCommand cmd = new SqlCommand("UpdatePurchase", dl.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@SUPPLIER_NO", SupplierNo));
                    cmd.Parameters.Add(new SqlParameter("@INVOICE_NO", txtInvoiceNo.Text));
                    cmd.Parameters.Add(new SqlParameter("@PURCHASE_AMOUNT", txtPurchaseAmount.Text));
                    cmd.Parameters.Add(new SqlParameter("@PURCHASE_DATE", dtpPurchaseDate.Value.ToLongDateString()));
                    cmd.Parameters.Add(new SqlParameter("@PURCHASE_VEHICLE_NO", txtVehicleNo.Text));
                    cmd.Parameters.Add(new SqlParameter("@PURCHASE_NO", PurchaseNo));

                    cmd.ExecuteNonQuery();
                    dl.con_close();
                    MessageBox.Show("Item Successfully Updated!!", "Store");
                }
                catch (Exception)
                { }
            }

        }

        private void insPurchase()
        {
            if (Validatefrm())
            {
                try
                {
                    dl.con_open();
                    SqlCommand cmd = new SqlCommand("InsPurchase", dl.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@SUPPLIER_NO", SupplierNo));
                    cmd.Parameters.Add(new SqlParameter("@INVOICE_NO", txtInvoiceNo.Text));
                    cmd.Parameters.Add(new SqlParameter("@PURCHASE_AMOUNT", txtPurchaseAmount.Text));
                    cmd.Parameters.Add(new SqlParameter("@PURCHASE_DATE", SqlDbType.DateTime));
                    cmd.Parameters["@PURCHASE_DATE"].Value = Convert.ToDateTime(dtpPurchaseDate.Value.ToString("dd-MMM-yyyy"));

                    cmd.Parameters.Add(new SqlParameter("@PURCHASE_VEHICLE_NO", txtVehicleNo.Text));
                    cmd.Parameters.Add("@PURCHASE_NO", SqlDbType.Int);

                    cmd.Parameters["@PURCHASE_NO"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                    int ID = (int)cmd.Parameters["@PURCHASE_NO"].Value;
                    PurchaseNo = ID.ToString();
                    dl.con_close();
                    MessageBox.Show("Item Successfully Saved!!", "Store");
                }
                catch (SqlException ex)
                {
                    string s = ex.Message;
                }
            }
        }

        private void loadSupplier(string name)
        {
            string s = @"SELECT SUPPLIER_NO,SUPPLIER_NAME as Name,SUPPLIER_ADDRESS as Address ";
            s = s + " FROM tbl_Supplier where SUPPLIER_NAME='" + name + "' AND SUPPLIER_FLAG='True'";

            SqlDataAdapter da = new SqlDataAdapter(s, dl.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count >= 1)
            {
                SupplierNo = ds.Tables[0].Rows[0]["SUPPLIER_NO"].ToString();
                txtAddr.Text = ds.Tables[0].Rows[0]["Address"].ToString();
            }

        }

        private void loadPurchase(string id)
        {
            string s = @"SELECT DISTINCT PURCHASE_NO,P.SUPPLIER_NO,INVOICE_NO,SUPPLIER_NAME,SUPPLIER_ADDRESS,PURCHASE_AMOUNT,";
            s = s + "PURCHASE_DATE,PURCHASE_VEHICLE_NO FROM tbl_PurchaseMaster P,tbl_Supplier S where P.SUPPLIER_NO=S.SUPPLIER_NO";
            s = s + " AND PURCHASE_NO=" + id + " ORDER BY INVOICE_NO ASC";

            //string s = @"SELECT DISTINCT ITEM_NAME as Item,ITEM_CATEGORY as Category,ITEM_MANUFACTURER as Manufacturer,ITEM_QTY as Qty,ITEM_UNIT as Unit,ITEM_PURCHASE_AMOUNT as ";
            //s = s + "[Purchase Amount],ITEM_WHOLESALE_PRICE as [WholeSale Price],ITEM_RETAIL_PRICE as [Retail Price],ITEM_TAX as Tax,ITEM_DESC";
            //s = s + " FROM tbl_Item Where ITEM_ID =" + id + "ORDER BY ITEM_NAME ASC";

            SqlDataAdapter da = new SqlDataAdapter(s, dl.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count >= 1)
            {
                PurchaseNo = id;
                txtSupplier.Text = ds.Tables[0].Rows[0]["SUPPLIER_NAME"].ToString();
                txtAddr.Text = ds.Tables[0].Rows[0]["SUPPLIER_ADDRESS"].ToString();
                txtInvoiceNo.Text = ds.Tables[0].Rows[0]["INVOICE_NO"].ToString();
                txtPurchaseAmount.Text = ds.Tables[0].Rows[0]["PURCHASE_AMOUNT"].ToString();
                txtVehicleNo.Text = ds.Tables[0].Rows[0]["PURCHASE_VEHICLE_NO"].ToString();
                dtpPurchaseDate.Text = ds.Tables[0].Rows[0]["PURCHASE_DATE"].ToString();
            }


        }

        public void Filter()
        {
            string str = "";

            try
            {
                if (txtFilterName.Text.Length == 0)
                {
                    //if (str != "")
                    //    str = str + " And ";

                    str = str + "";

                }
                else
                {
                    if (str != "")
                        str = str + " And ";

                    str = str + @"Item like '%" + txtFilterName.Text + "%'";

                }
                if (txtFilterCategory.Text.Length == 0)
                {
                    //if (str != "")
                    //    str = str + " And ";

                    //str = str + "";

                }
                else
                {
                    if (str != "")
                        str = str + " And ";

                    str = str + @"Category like '%" + txtFilterCategory.Text + "%'";

                }
                if (txtFilterManufacturer.Text.Length == 0)
                {
                    //if (str!="")
                    //    str=str+" And ";

                    //str = str + "";

                }
                else
                {
                    if (str != "")
                        str = str + " And ";

                    str = str + @"Manufacturer like '%" + txtFilterManufacturer.Text + "%'";

                }

                dv.RowFilter = str;
                dgvItemList.DataSource = dv;
            }
            catch (Exception)
            { }

        }

        private void UpdateStock()
        {
            if (Validatefrm())
            {
                try
                {
                    if (PurchaseNo != "")
                    {
                        dl.con_open();
                        SqlCommand cmd = new SqlCommand("InsPurchaseItems", dl.con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@PURCHASE_NO", PurchaseNo));
                        cmd.Parameters.Add(new SqlParameter("@ITEM_NO", itemno));
                        cmd.Parameters.Add(new SqlParameter("@CATEGORY", category));
                        cmd.Parameters.Add(new SqlParameter("@ITEM_QUANTITY", txtNewStock.Text));

                        cmd.ExecuteNonQuery();
                        dl.con_close();
                        fill_ItemGrid();
                    }
                    else
                        MessageBox.Show("Purchase Not Saved!!..Save It First..Then Update Item!!..", "Store");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error in Updating Stock!!..", "Store");
                }
            }
        }

        #endregion

        #region Control Events

        private void cmdNewSupplier_Click(object sender, EventArgs e)
        {
            frmSupplier supplier = new frmSupplier();
            supplier.ShowDialog();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmstock_Load(object sender, EventArgs e)
        {
            this.Width = 600;
            gbPurchase.Visible = false;
            fill_Supplier();
        }

        private void txtSupplier_Leave(object sender, EventArgs e)
        {
            try
            {
                loadSupplier(txtSupplier.Text);
            }
            catch (Exception)
            {

            }
        }

        private void txtSupplier_TextChanged(object sender, EventArgs e)
        {
            try
            {
                loadSupplier(txtSupplier.Text);
            }
            catch (Exception)
            {

            }
        }

        private void cmdSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (PurchaseNo == "")
                {
                    insPurchase();
                }
                else
                {
                    UpdatePurchase();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdLoadItems_Click(object sender, EventArgs e)
        {
            if ((txtSupplier.Text != "") && (txtInvoiceNo.Text != ""))
            {
                fill_ItemGrid();
                fill_PurchaseItems();
            }
            else
                MessageBox.Show("Load Supplier and Invoice First!!", "Store");
        }

        private void cmdLoad_Click(object sender, EventArgs e)
        {
            gbPurchase.Visible = false;
            if (this.Width == 600)
            {
                for (int i = 600; i <= 1090; i++)
                {
                    this.Width = i;
                }
            }

            fill_PurchaseGrid();
            gbPurchase.Visible = true;
        }

        private void dgvPurchase_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string str;
                gbPurchase.Visible = false;
                this.Width = 600;
                str = dgvPurchase.Rows[e.RowIndex].Cells[0].Value.ToString();
                clear();
                loadPurchase(str);
                cmdSaveItem.Text = "Update";
            }
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void txtFilterName_TextChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void txtFilterCategory_TextChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void txtFilterManufacturer_TextChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void dgvItemList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtCurrentStock.Text = dgvItemList.Rows[e.RowIndex].Cells["Qty"].Value.ToString();
                itemno = dgvItemList.Rows[e.RowIndex].Cells["Item_Id"].Value.ToString();
                category = dgvItemList.Rows[e.RowIndex].Cells["Category"].Value.ToString();
            }
        }

        private void cmdUpdateStock_Click(object sender, EventArgs e)
        {
            UpdateStock();
            txtNewStock.Text = "";
            txtCurrentStock.Text = "";
            fill_PurchaseItems();
        }

        private void cmdDeletePurchasedItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (delItemPur_no != "")
                {
                    DialogResult d1 = new DialogResult();
                    d1 = MessageBox.Show("Are You Sure to Remove this Record", "Store - Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                    if (d1 == DialogResult.Yes)
                    {
                        dl.con_open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM tbl_Purchase WHERE PURCHASE_ID=" + delItemPur_no, dl.con);
                        cmd.ExecuteNonQuery();
                        dl.con_close();


                        dl.con_open();
                        cmd = new SqlCommand("UPDATE [tbl_Item] SET ITEM_QTY  = ITEM_QTY - " + delUpdatedStock + " WHERE ITEM_ID  = " + delItemID, dl.con);
                        cmd.ExecuteNonQuery();
                        dl.con_close();


                        dgvItemList.DataSource = null;
                        dgvItemList.Rows.Clear();
                        dgvItemList.Columns.Clear();

                        dgvPurchasedItem.DataSource = null;
                        dgvPurchasedItem.Rows.Clear();
                        dgvPurchasedItem.Columns.Clear();

                        fill_ItemGrid();
                        fill_PurchaseItems();
                    }
                }
                else
                    MessageBox.Show("Please Select One Item To Delete", "Store");
            }
            catch (Exception)
            {
                MessageBox.Show("Some Error Occured!!!..Try After Some Time!!..", "Store");
            }
        }

        private void dgvPurchasedItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                delItemPur_no = dgvPurchasedItem.Rows[e.RowIndex].Cells["PURCHASE_ID"].Value.ToString();
                delItemID = dgvPurchasedItem.Rows[e.RowIndex].Cells["ITEM_ID"].Value.ToString();
                delUpdatedStock = dgvPurchasedItem.Rows[e.RowIndex].Cells["Updated Stock"].Value.ToString();

            }
        }

        private void cmdClosePurchase_Click(object sender, EventArgs e)
        {
            if (this.Width == 1090)
            {
                for (int i = 1090; i >= 600; i--)
                {
                    this.Width = i;
                }
            }
        }
        #endregion

        private void txtPurchaseAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            AimSValidator.AmountChecker(sender, e);
        }

        private void txtNewStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            AimSValidator.NumberChecker(e);
        }

    }
}
