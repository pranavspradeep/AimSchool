using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;

 
namespace SchoolManagement
{
    public partial class frmsale : Form
    {
        #region Declarations

        DataLayer d = new DataLayer();
        string admno = "";
        string Itemid = "";
        string ItemNo = "";
        string itemprice = "0";
        int invoiceno=0;
        double TotalAmnt;
        string purchseditemno = "";
        string itemquantity = "";
        string delitemno = "";
        string sname = "";
        string deleteamnt;
        int newinv = 0;

        #endregion
        public frmsale()
        {
            InitializeComponent();
        }

        private void frmsale_Load(object sender, EventArgs e)
        {
            //display_class();
            txt_discount.Text = "0";
            tbsPreview.Enabled = false;
            tsbPrint.Enabled = false;
            tsbNewInvoice.Enabled = true;
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            groupBox5.Enabled = false;
            
        }
        public void display_class()
        {
            d.con_open();
            SqlCommand cmd1 = new SqlCommand("sel_cstandard", d.con);
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlDataReader r1 = cmd1.ExecuteReader();
            while (r1.Read())
            {
                cmb_class.Items.Add(r1[0].ToString());
            }
            d.con_close();
        }
        public Boolean bill_Validation()
        {
            Boolean r=false ;
            if (invoiceno == 0)
            {
                r = false;
                MessageBox.Show("Please Generate Invoice");
            }
            else
            {
                r = true;
            }
            return r;
        }
        public void display_div()
        {
            cmb_division.Items.Clear();
            SqlDataAdapter DataSet = new SqlDataAdapter("Select distinct division from tbl_stddivision where cstandard='" + cmb_class.Text + "' ORDER BY division ASC", d.con);
            DataSet ds = new DataSet();
            DataSet.Fill(ds);
            DataRow dr;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dr = ds.Tables[0].Rows[i];
                cmb_division.Items.Add(dr[0].ToString());
            }

        }
        private void cmb_class_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* if (bill_Validation() == true)
            {
                cmb_division.Text = "";
                display_div();
            }*/
        }
        public void studentsearch()
        {
            string r = "Select st.adno AS [Admission No],s.sname AS [Name],st.cstandard AS [Class],st.division AS Division from tbl_stddivision AS st INNER JOIN tbl_student AS s ON st.adno = s.adno where st.cstandard='" + cmb_class.Text + "' And st.division='" + cmb_division.Text + "' And s.sname like '%" + txt_student.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(r, d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dgv_Studentlist.DataSource = ds.Tables[0];
        }

        private void txt_student_TextChanged(object sender, EventArgs e)
        {
            studentsearch();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (bill_Validation() == true)
            {
                if (r1.Checked == false && r2.Checked == false && r3.Checked == false)
                {
                    MessageBox.Show("Select option for search", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


                if (r1.Checked == true)
                {
                    txt_Manufact.Text = null;
                    txtCat.Text = null;
                    if (txt_ItemName.Text == "" || txt_ItemName.Text == null)
                    {
                        MessageBox.Show("Enter Item Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        SqlDataAdapter da1 = new SqlDataAdapter("select ITEM_NAME from tbl_Item  where ITEM_NAME like '" + txt_ItemName.Text + "%'  ", d.con);
                        DataSet dt1 = new DataSet();
                        da1.Fill(dt1);
                        if (dt1.Tables[0].Rows.Count == 0)
                        {
                            MessageBox.Show("Search name does not exist", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    SqlDataAdapter ad = new SqlDataAdapter("select ITEM_ID as [Item_Id],ITEM_NAME as Name,ITEM_Category as Category,ITEM_RETAIL_PRICE as Price from tbl_Item where ITEM_NAME like '" + txt_ItemName.Text + "%'", d.con);
                    DataSet ds = new DataSet();
                    ad.Fill(ds);
                    dgv_itemlist.DataSource = ds.Tables[0];


                }
                if (r2.Checked == true)
                {
                    txt_ItemName.Text = null;
                    txt_Manufact.Text = null;

                    if (txtCat.Text == "" || txtCat.Text == null)
                    {
                        MessageBox.Show("Enter Category", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        string r = "select ITEM_NAME from tbl_Item  where ITEM_CATEGORY like '" + txtCat.Text + "%'";
                        SqlDataAdapter da2 = new SqlDataAdapter(r, d.con);
                        DataSet dt2 = new DataSet();
                        da2.Fill(dt2);
                        if (dt2.Tables[0].Rows.Count == 0)
                        {
                            MessageBox.Show("Search Category does not exist", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    SqlDataAdapter ad1 = new SqlDataAdapter("select ITEM_ID as [Item_Id],ITEM_NAME as Name,ITEM_CATEGORY as Category from tbl_Item where ITEM_CATEGORY like '" + txtCat.Text + "%'", d.con);
                    DataSet ds1 = new DataSet();
                    ad1.Fill(ds1);
                    dgv_itemlist.DataSource = ds1.Tables[0];


                }
                if (r3.Checked == true)
                {
                    txt_ItemName.Text = null;
                    txtCat.Text = null;
                    if (txt_Manufact.Text == "" || txt_Manufact.Text == null)
                    {
                        MessageBox.Show("Enter Manufacturer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {

                        SqlDataAdapter da3 = new SqlDataAdapter("select ITEM_NAME from tbl_Item where ITEM_MANUFACTURER like '" + txt_Manufact.Text + "%'", d.con);
                        DataSet dt3 = new DataSet();
                        da3.Fill(dt3);
                        if (dt3.Tables[0].Rows.Count == 0)
                        {
                            MessageBox.Show("Search Manufacturer does not exist", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    SqlDataAdapter ad2 = new SqlDataAdapter("select ITEM_ID as [Item_Id],ITEM_NAME as Name,ITEM_Category as Category from tbl_Item where ITEM_MANUFACTURER like '" + txt_Manufact.Text + "%'", d.con);
                    DataSet ds2 = new DataSet();
                    ad2.Fill(ds2);
                    dgv_itemlist.DataSource = ds2.Tables[0];

                }
            }
        }

        private void dgv_Studentlist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            admno = dgv_Studentlist.Rows[e.RowIndex].Cells["Admission No"].Value.ToString();
            sname = dgv_Studentlist.Rows[e.RowIndex].Cells["Name"].Value.ToString();
            SchoolManagement.rptstd = dgv_Studentlist.Rows[e.RowIndex].Cells["Class"].Value.ToString();
            SchoolManagement.rptdiv = dgv_Studentlist.Rows[e.RowIndex].Cells["Division"].Value.ToString();

            
        }

        private void dgv_itemlist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Itemid = dgv_itemlist.Rows[e.RowIndex].Cells["Item_Id"].Value.ToString();
            itemprice = dgv_itemlist.Rows[e.RowIndex].Cells["Price"].Value.ToString();
        }
        public void purchasegridAmt()
        {
            TotalAmnt = 0;
            for (int i = 0; i < dgv_PurchaseDetails.Rows.Count; i++)
            {
                TotalAmnt = TotalAmnt + Convert.ToDouble(dgv_PurchaseDetails.Rows[i].Cells["Total Amount"].Value);
            }
            txt_Amount.Text = Convert.ToString(TotalAmnt);
        }
        private void btn_Purchase_Click(object sender, EventArgs e)
        {
            //bool flag = true;
          /*  for (int i = 0; i < dgv_PurchaseDetails.Rows.Count; i++)
            {
                string b = dgv_PurchaseDetails.Rows[i].Cells["ITEM_ID"].Value.ToString();
                if (Itemid == dgv_PurchaseDetails.Rows[i].Cells["ITEM_ID"].Value.ToString())
                {
                    flag = false;
                    MessageBox.Show("Already Item Added!!..If you Want Update Item Quantity..Please Remove From Billing And Add Again!!..", "Store");
                    goto final;
                }
            }
        final:
            if (flag == true)
            {*/


            
                //TotalAmnt = TotalAmnt + (Convert.ToDouble(itemprice) * Convert.ToDouble(txt_Quantity.Text));
                purchaseItem();
                Grid_purchaseditem();
                purchasegridAmt();
                TotalAmount();
                
           // }
        }


        public Boolean validate()
        {
            Boolean f = true;
            if (txt_Quantity.Text == "" || txt_Quantity.Text == null)
            {
                f = false;
                MessageBox.Show("Enter Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (admno == "" || admno == null)
            {
                f = false;
                MessageBox.Show("Select Student!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Itemid == "" || Itemid == null)
            {
                f = false;
                MessageBox.Show("Select Item!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return f;
        }
        public void purchaseItem()
        {
            if (validate() == true)
            {
                d.con_open();
                SqlCommand cmd = new SqlCommand("ins_Sales", d.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@billno", invoiceno);
                cmd.Parameters.AddWithValue("@itemno", Itemid);
                cmd.Parameters.AddWithValue("@Quantity", Convert.ToDecimal(txt_Quantity.Text));
                cmd.Parameters.AddWithValue("@totamt", Convert.ToDecimal(itemprice) * Convert.ToDecimal(txt_Quantity.Text));
                cmd.ExecuteNonQuery();
                d.con_close();
                MessageBox.Show("Item Added Successfully", "Added....", MessageBoxButtons.OK, MessageBoxIcon.Information);
                d.con_open();
                cmd = new SqlCommand("UPDATE [tbl_Item] SET ITEM_QTY  = ITEM_QTY - " + Convert.ToDecimal(txt_Quantity.Text) + " WHERE ITEM_ID  = " + Itemid, d.con);
                cmd.ExecuteNonQuery();
                d.con_close();
                txt_Quantity.Text = "1";
            }
        }
        public void Grid_purchaseditem()
        {
            //dgv_PurchaseDetails.ColumnCount = 0;
            dgv_PurchaseDetails.DataSource = "";
            SqlDataAdapter da = new SqlDataAdapter("SELECT tbl_Sales.SlNo, tbl_Sales.BillNo, tbl_Item.ITEM_ID, tbl_Item.ITEM_NAME, tbl_Sales.Quantity, tbl_Sales.TotalAmt AS [Total Amount] FROM  tbl_Item INNER JOIN tbl_Sales ON tbl_Sales.Itemno = tbl_Item.ITEM_ID where BillNo=" + invoiceno, d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dgv_PurchaseDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_PurchaseDetails.AutoResizeColumns();
            dgv_PurchaseDetails.DataSource = ds.Tables[0];
        }


        public void Grid_purchaseditem(string invNo)
        {
            //dgv_PurchaseDetails.ColumnCount = 0;
            dgv_PurchaseDetails.DataSource = "";
            SqlDataAdapter da = new SqlDataAdapter("SELECT tbl_Sales.SlNo, tbl_Sales.BillNo, tbl_Item.ITEM_ID, tbl_Item.ITEM_NAME, tbl_Sales.Quantity, tbl_Sales.TotalAmt AS [Total Amount] FROM  tbl_Item INNER JOIN tbl_Sales ON tbl_Sales.Itemno = tbl_Item.ITEM_ID where BillNo=" + invNo , d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dgv_PurchaseDetails.DataSource = ds.Tables[0];
        }
        public void TotalAmount()
        {
            double dis = 0;
            if (txt_discount.Text == null || txt_discount.Text.Trim() == "")
            {
                dis = 0;
                //txt_discount.Text = "0";
            }
            else
            {
                dis = Convert.ToDouble(txt_discount.Text);
            }
            lbl_billamt.Text = Convert.ToString(TotalAmnt);
            double discountedamt = 0;
            discountedamt = TotalAmnt - Convert.ToDouble(dis);
            txt_Amount.Text = Convert.ToString(discountedamt);
        }
        public void clear()
        {
            txt_student.Text = "";
            cmb_class.Text = "";
            cmb_division.Text = "";
            dgv_Studentlist.DataSource = "";
            dgv_itemlist.DataSource = "";
            dgv_PurchaseDetails.DataSource = "";
            txt_ItemName.Text = "";
            txtCat.Text = "";
            txt_Manufact.Text = "";
            txt_Quantity.Text = "1";
            txt_discount.Text = "0";
            lbl_billamt.Text = "0";
            txt_Amount.Text = "0";
        }
        public void newinvoice()
        {
            d.con_open();
            SqlCommand cmd = new SqlCommand("ins_SalesMaster", d.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("CurrDate", Convert.ToDateTime(DateTime.Now.ToString("dd-MMM-yyyy")));
            cmd.Parameters.AddWithValue("@admno", "");
            cmd.Parameters.AddWithValue("@Discount", "");
            cmd.Parameters.AddWithValue("@Amt", "");
            cmd.ExecuteNonQuery();
            d.con_close();   
            SqlDataAdapter da = new SqlDataAdapter("Select BillNo from tbl_SalesMaster ORDER BY BillNo DESC", d.con);
            DataSet dast = new DataSet();
            da.Fill(dast);
            DataRow dr;
            if (dast.Tables[0].Rows.Count > 0)
            {
                dr = dast.Tables[0].Rows[0];
                invoiceno = Convert.ToInt32(dr[0].ToString());
            }
            else
            {
                invoiceno = 100;
            }
            TotalAmnt = 0;
            
        }
        public void DeleteExisting()
        {

            string s = "Select BillNo from tbl_SalesMaster where BillNo=(Select MAX(BillNo) from tbl_SalesMaster where admno='" + "" + "')";
            SqlDataAdapter da = new SqlDataAdapter(s, d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];
                int Bilnum = Convert.ToInt32(dr[0].ToString());
                d.con_open();
                SqlCommand cmd = new SqlCommand("Delete from tbl_SalesMaster where BillNo=" + Bilnum, d.con);
                cmd.ExecuteNonQuery();
                d.con_close();
            }
        }
        private void tsbNewInvoice_Click(object sender, EventArgs e)
        {

            DeleteExisting();
            clear();
            newinvoice();
            newinv = 1;
            tbsPreview.Enabled = true;
            tsbPrint.Enabled = true;
            tsbNewInvoice.Enabled = false;
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            groupBox3.Enabled = true;
            groupBox4.Enabled = true;
            groupBox5.Enabled = true;


        }
        public void UpdateSalesMaster()
        {
            if (dgv_PurchaseDetails.Rows.Count > 0)
            {
                d.con_open();
                string v = "Update tbl_SalesMaster Set CurrDate='" + DateTime.Now.ToString("dd-MMM-yyyy") + "', admno='" + admno + "', Discount='" + txt_discount.Text + "', Amount= " + TotalAmnt + " where BillNo= " + invoiceno; 
                SqlCommand cmd = new SqlCommand(v, d.con);
                cmd.ExecuteNonQuery();
                d.con_close();
                Preview();
            }
            else
            {
                MessageBox.Show("No Items in Purchased List", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //Printing Section
            //SchoolManagement.salesbillno = invoiceno.ToString();
            //string s = "Select i.Item_Name as [Item],s.Quantity as [Qty],i.ITEM_RETAIL_PRICE as [Price],s.Quantity*i.ITEM_RETAIL_PRICE as [Amount] from tbl_Item i Join tbl_Sales s on i.Item_id=s.Itemno where s.BillNo=" + SchoolManagement.salesbillno;
            //SqlDataAdapter da = new SqlDataAdapter(s, d.con);
            //DataSet ds = new DataSet();
            //da.Fill(ds);


            /*SalesBill sb = new SalesBill();
            sb.SetDataSource(ds.Tables[0]);
            sb.SetParameterValue("BillNo", SchoolManagement.salesbillno);
            sb.SetParameterValue("Admno", SchoolManagement.sladmno);
            sb.SetParameterValue("Name", SchoolManagement.slname);
            sb.SetParameterValue("Discount", SchoolManagement.sldiscount);
            sb.SetParameterValue("TotalAmount", SchoolManagement.sltotal);
            //sb.SetParameterValue("SchoolName", SchoolManagement.SchoolName);
            sb.SetParameterValue("SchoolName", "Nizamia Public School");
            sb.SetParameterValue("DT", DateTime.Now.ToString());
            sb.SetParameterValue("std", SchoolManagement.rptstd);
            sb.SetParameterValue("div", SchoolManagement.rptdiv);
            sb.SetParameterValue("Addr", "Pothencode, Trivandrum");
            sb.SetParameterValue("Phone", "0471-6444002");
            //PrintingCopy();
            //PrintDocument pd = new PrintDocument();
            // Set the page orientation to landscape.
            //pd.PrintPage += new PrintPageEventHandler();
            //pd.DefaultPageSettings.Landscape = true;           
            sb.PrintToPrinter(2, false, 0, 0);   */       
            

           /* SchoolManagement.salesbillno = invoiceno.ToString();
            SchoolManagement.sladmno = admno;
            SchoolManagement.slname = sname;
            SchoolManagement.sldiscount = Convert.ToDouble(txt_discount.Text);
            SchoolManagement.sltotal = Convert.ToDouble(txt_Amount.Text);
            SalesBillPrivew s = new SalesBillPrivew();
            
            s.Show();*/

           
            //MessageBox.Show("Invoice Successfully Generated!!..", "Store");
        }
       
        private void tsbPrint_Click(object sender, EventArgs e)
        {
            newinv = 0;
            UpdateSalesMaster();                        
            
            
        }
        public void Preview()
        {
            SchoolManagement.salesbillno = invoiceno.ToString();
            SchoolManagement.sladmno = admno;
            SchoolManagement.slname = sname;
            SchoolManagement.sldiscount = Convert.ToDouble(txt_discount.Text);
            SchoolManagement.sltotal = Convert.ToDouble(txt_Amount.Text);
            tbsPreview.Enabled = false;
            tsbPrint.Enabled = false;
            tsbNewInvoice.Enabled = true;
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            groupBox5.Enabled = false;
            dgv_PurchaseDetails.DataSource = "";
            dataGridView1.DataSource = "";
            dgv_Studentlist.DataSource = "";
            dgv_itemlist.DataSource = "";
            txt_Amount.Text = "0";
            lbl_billamt.Text = "0";            
            SalesBillPrivew s = new SalesBillPrivew();
            d.con_close();
            s.Show();
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            DialogResult d1 = new DialogResult();
            d1 = MessageBox.Show("Are You Sure to Remove this Item", "Store - Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            if (d1 == DialogResult.Yes)
            {                
                d.con_open();
                SqlCommand cmd = new SqlCommand("DELETE FROM tbl_Sales WHERE SlNo =" + purchseditemno + " And Itemno = " + delitemno, d.con);
                cmd.ExecuteNonQuery();
                d.con_close();

                d.con_open();
                cmd = new SqlCommand("UPDATE [tbl_Item] SET ITEM_QTY  = ITEM_QTY + " + itemquantity + " WHERE ITEM_ID  = " + delitemno, d.con);
                cmd.ExecuteNonQuery();
                d.con_close();
                Grid_purchaseditem();
                purchasegridAmt();
            }
            
        }                
        private void dgv_PurchaseDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            purchseditemno = dgv_PurchaseDetails.Rows[e.RowIndex].Cells["SlNo"].Value.ToString();
            delitemno = dgv_PurchaseDetails.Rows[e.RowIndex].Cells["ITEM_ID"].Value.ToString();
            itemquantity = dgv_PurchaseDetails.Rows[e.RowIndex].Cells["Quantity"].Value.ToString();
            deleteamnt = dgv_PurchaseDetails.Rows[e.RowIndex].Cells["Total Amount"].Value.ToString();

        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            if (newinv == 1)
            {
                SqlDataAdapter da = new SqlDataAdapter("Select MAX(BillNo) from tbl_SalesMaster where admno='" + "" + "' And Amount=0.0000", d.con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataRow dr;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DialogResult r = MessageBox.Show("Are you sure to cancel the Invoice?", "warning..", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        dr = ds.Tables[0].Rows[0];
                        int Bilnum = Convert.ToInt32(dr[0].ToString());
                        d.con_open();
                        SqlCommand cmd = new SqlCommand("Delete from tbl_SalesMaster where BillNo=" + Bilnum, d.con);
                        cmd.ExecuteNonQuery();
                        d.con_close();
                    }
                }
            }
            this.Close();
        }
        private void txt_discount_TextChanged(object sender, EventArgs e)
        {
            if (txt_discount.Text == null)
            {
                txt_discount.Text = "0";
            }
            else
            {
                TotalAmount();
            }
        }

        private void txt_Quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            AimSValidator.AmountChecker(sender, e);
        }

        private void txt_discount_KeyPress(object sender, KeyPressEventArgs e)
        {
            AimSValidator.NumberChecker(e);
        }

        private void txt_Amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            AimSValidator.NumberChecker(e);
        }

        private void frmsale_KeyUp(object sender, KeyEventArgs e)
        {            
            if (e.KeyCode == Keys.F4)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.F2)
            {
                UpdateSalesMaster();
            }
            else if (e.KeyCode == Keys.F1)
            {
                clear();
                newinvoice();
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            groupBox9.Visible = true;
           
          
        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select PurNo,BillNo,PurName from tbl_PurchaseListMaster", d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Visible = true;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SchoolManagement.PurSvName = txtLstName.Text;

            if (SchoolManagement.PurSvName != "")
            {
                d.con_open();

                SqlCommand cmd = new SqlCommand("ins_purchaselstMaster", d.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", SchoolManagement.PurSvName);
                cmd.Parameters.AddWithValue("@BillNo", invoiceno);
                cmd.ExecuteNonQuery();

                /*             for (int i = 0; i < dgv_PurchaseDetails.RowCount; i++)
                                {
                                    SqlCommand cmd1 = new SqlCommand("ins_purchaselst", d.con);
                                    cmd1.CommandType = CommandType.StoredProcedure;
                                    cmd1.Parameters.AddWithValue("@PurNo", pno);
                                    cmd1.Parameters.AddWithValue("@ItemNo", dgv_PurchaseDetails.Rows[i].Cells[2].Value.ToString());
                                    cmd1.ExecuteNonQuery();
                                }*/
                d.con_close();
                groupBox9.Visible = false;

            }
            else
            {
                MessageBox.Show("Please Enter a Name to Save the List");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SchoolManagement.LPurNo = dataGridView1.Rows[e.RowIndex].Cells["BillNo"].Value.ToString();
            
            SqlDataAdapter da = new SqlDataAdapter("Select SlNo from tbl_Sales where BillNo = " + invoiceno, d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if(ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("Purchased List already have some Items. Delete Items if u don't Needed....", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            sale_kit();
            
        }
        public void sale_kit()
        {            
            if (SchoolManagement.LPurNo != "")
            {
                Grid_purchaseditem(SchoolManagement.LPurNo);
                d.con_open();
                for (int i = 0; i < dgv_PurchaseDetails.RowCount - 1; i++)
                {
                    SqlCommand cmd = new SqlCommand("ins_Sales", d.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@billno", invoiceno);
                    cmd.Parameters.AddWithValue("@itemno", dgv_PurchaseDetails.Rows[i].Cells["ITEM_ID"].Value.ToString());
                    cmd.Parameters.AddWithValue("@Quantity", dgv_PurchaseDetails.Rows[i].Cells["Quantity"].Value.ToString());
                    cmd.Parameters.AddWithValue("@totamt", dgv_PurchaseDetails.Rows[i].Cells["Total Amount"].Value.ToString());
                    cmd.ExecuteNonQuery();
                }              
                d.con_close();
                Grid_purchaseditem();
                purchasegridAmt();
                TotalAmount();
            }
            dataGridView1.Visible = false;
        }        
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SchoolManagement.salesbillno = invoiceno.ToString();
            SchoolManagement.sladmno = admno;
            SchoolManagement.slname = sname;
            SchoolManagement.sldiscount = Convert.ToDouble(txt_discount.Text);
            SchoolManagement.sltotal = Convert.ToDouble(txt_Amount.Text);
            SalesBillPrivew s = new SalesBillPrivew();
            d.con_close();
            s.Show();
        }

        private void cmb_class_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }       
            
        }

        private void cmb_division_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}
