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
    public partial class frmItem : Form
    {
        DataLayer dl = new DataLayer();
        DataView dv;
        string Itemid = "";
        public frmItem()
        {
            InitializeComponent();
        }
        private void fill_Item()
        {
            try
            {
                string s = "SELECT DISTINCT ITEM_NAME FROM tbl_Item ORDER BY ITEM_NAME ASC";
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
            catch (Exception)
            { }
        }

        private void fill_ItemGrid()
        {
            dgvItem.DataSource = null;
            dgvItem.Rows.Clear();
            dgvItem.Columns.Clear();
            string s = @"SELECT DISTINCT ITEM_ID,ITEM_NAME as Item,ITEM_CATEGORY as Category,ITEM_MANUFACTURER as Manufacturer,ITEM_QTY as Qty,ITEM_PURCHASE_AMOUNT as [Purchase Amount],ITEM_RETAIL_PRICE as [Retail Price] FROM tbl_Item ORDER BY ITEM_NAME ASC";
            SqlDataAdapter da = new SqlDataAdapter(s, dl.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dv = ds.Tables[0].DefaultView;
            dgvItem.DataSource = dv;
            //dgvItem.Columns[0].Visible = false;
            dgvItem.Columns[2].Frozen = true;
            dgvItem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvItem.AutoResizeColumns();
            
        }

        private void clear()
        {
            Itemid = "";
            txtName.Text = "";
            txtCategory.Text = "";
            txtManufacturer.Text = "";
            txtQty.Text = "0";
            txtPurchaseAmount.Text = "";
            txtSalePrice.Text = "";
            fill_ItemGrid();
        }

        private bool Validatefrm()
        {
            bool flag = true;
            string msg = "";

            if (txtName.Text == "")
            {
                flag = false;
                msg = "Enter Item Name!!..";
                goto EndValidation;
            }
            if (txtCategory.Text == "")
            {
                flag = false;
                msg = "Enter Item Category to Identify Future Stock Updations!!..";
                goto EndValidation;
            }

            if (txtPurchaseAmount.Text == "")
            {
                flag = false;
                msg = "Enter Purchase Amount!!..";
                goto EndValidation;
            }
            if (txtSalePrice.Text == "")
            {
                flag = false;
                msg = "Enter Retail Price!!..";
                goto EndValidation;
            }
            

        EndValidation:
            if (msg != "")
            {
                MessageBox.Show(msg, "Store", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flag;
        }

        private void insItem()
        {
            try
            {
                if (Validatefrm())
                {
                    dl.con_open();
                    SqlCommand cmd = new SqlCommand("InsItem", dl.con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@ITEM_NAME", txtName.Text));
                    cmd.Parameters.Add(new SqlParameter("@ITEM_MANUFACTURER", txtManufacturer.Text));
                    cmd.Parameters.Add(new SqlParameter("@ITEM_CATEGORY", txtCategory.Text));
                    cmd.Parameters.Add(new SqlParameter("@ITEM_QTY", "0"));
                    cmd.Parameters.Add(new SqlParameter("@ITEM_UNIT", txtUnit.Text));
                    cmd.Parameters.Add(new SqlParameter("@ITEM_PURCHASE_AMOUNT", txtPurchaseAmount.Text));                   
                    cmd.Parameters.Add(new SqlParameter("@ITEM_RETAIL_PRICE", txtSalePrice.Text));                    
                    cmd.ExecuteNonQuery();
                    dl.con_close();
                    MessageBox.Show("Item Successfully Saved!!", "Store");
                    MessageBox.Show("Item Quantity Can later Be Updated On Stock!!", "Store");

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Item Already Exists!!..Change The Category And Save Again!!..", "Store");
            }
            finally
            {
                dl.con_close();
                fill_ItemGrid();
            }
        }

        private void loadItem(string id)
        {
            try
            {
                string s = @"SELECT DISTINCT ITEM_NAME as Item,ITEM_CATEGORY as Category,ITEM_MANUFACTURER as Manufacturer,ITEM_QTY as Qty,ITEM_UNIT as Unit,ITEM_PURCHASE_AMOUNT as ";
                s = s + "[Purchase Amount],ITEM_RETAIL_PRICE as [Retail Price]";
                s = s + " FROM tbl_Item Where ITEM_ID =" + id + "ORDER BY ITEM_NAME ASC";

                SqlDataAdapter da = new SqlDataAdapter(s, dl.con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    Itemid = id;
                    txtName.Text = ds.Tables[0].Rows[0]["Item"].ToString();
                    txtCategory.Text = ds.Tables[0].Rows[0]["Category"].ToString();
                    txtManufacturer.Text = ds.Tables[0].Rows[0]["Manufacturer"].ToString();
                    txtQty.Text = ds.Tables[0].Rows[0]["Qty"].ToString();
                    txtUnit.Text = ds.Tables[0].Rows[0]["Unit"].ToString();
                    txtPurchaseAmount.Text = ds.Tables[0].Rows[0]["Purchase Amount"].ToString();                    
                    txtSalePrice.Text = ds.Tables[0].Rows[0]["Retail Price"].ToString();                  
                    
                }
            }
            catch (Exception)
            { }

        }      

        private void frmItem_Load(object sender, EventArgs e)
        {
            fill_Item();
            fill_ItemGrid();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text.Length == 0)
                {
                    dv.RowFilter = "";
                    dgvItem.DataSource = dv;
                }
                else
                {
                    string str = @"Item like '%" + txtName.Text + "%'";
                    dv.RowFilter = str;
                    dgvItem.DataSource = dv;

                }
            }
            catch (Exception)
            { }
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void dgvItem_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string str;
            if (e.RowIndex >= 0)
            {
                str = dgvItem.Rows[e.RowIndex].Cells[0].Value.ToString();
                Itemid = str;
                //loadItem(str);
            }
        }     

        private void txtPurchaseAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            AimSValidator.AmountChecker(sender, e);
        }

        private void txtSalePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            AimSValidator.AmountChecker(sender, e);
        }
        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            AimSValidator.AmountChecker(sender, e);
        }

        private void dgvItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string str;
            if (e.RowIndex >= 0)
            {
                str = dgvItem.Rows[e.RowIndex].Cells[0].Value.ToString();
                loadItem(str);
            }
        }

        private void cmdSave_Click_1(object sender, EventArgs e)
        {
            insItem();
        }

        private void cmdDelete_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (Itemid != "")
                {
                    DialogResult d1 = new DialogResult();
                    d1 = MessageBox.Show("Are You Sure to Remove this Record", "Store - Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                    if (d1 == DialogResult.Yes)
                    {
                        dl.con_open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM tbl_Item WHERE ITEM_ID=" + Itemid, dl.con);
                        //SqlCommand cmd = new SqlCommand("Update tbl_Item Set Del_Flag='D' WHERE ITEM_ID=" + Itemid, dl.con);
                        cmd.ExecuteNonQuery();
                        dl.con_close();
                        clear();

                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("This Item Cannot be Deleted!!..Its been Linked in Stock Or In Sale!!..", "Store");
            }
            finally
            {
                dl.con_close();
            }
        }

        private void dgvItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
