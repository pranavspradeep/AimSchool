using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace SchoolManagement
{
    public partial class PreviousBills : Form
    {
        DataLayer d = new DataLayer();
        public PreviousBills()
        {
            InitializeComponent();
        }
        private void FillBills(string BillDt)
        {
            string SQL = "";
            if (BillDt == "Nil")
            {
                SQL = "Select BillNo from tbl_SalesMaster";
            }
            else
            {
                SQL = "Select BillNo from tbl_SalesMaster where Convert(Varchar(10),CurrDate,101)='" + Convert.ToDateTime(dateTimePicker1.Value.ToString()).ToString("MM/dd/yyyy") + "'";

            }
            lslBills.DataSource = null;

            SqlDataAdapter da = new SqlDataAdapter(SQL, d.con);
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            lslBills.Items.Clear();
            DataRow dr;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dr = ds.Tables[0].Rows[i];
                lslBills.Items.Add(dr[0].ToString());
            }
            
            
        }
        private void PreviousBills_Load(object sender, EventArgs e)
        {
            FillBills("Nil");

        }
        private void Load_Report(string BillNo)
        {
            string s = "Select i.Item_Name as [Item],s.Quantity as [Qty],i.ITEM_RETAIL_PRICE as [Price],s.Quantity*i.ITEM_RETAIL_PRICE as [Amount] from tbl_Item i Join tbl_Sales s on i.Item_id=s.Itemno where s.BillNo=" + BillNo;
            SqlDataAdapter da1 = new SqlDataAdapter(s, d.con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);


            SalesBill sb = new SalesBill();
            sb.SetDataSource(ds1.Tables[0]);

            string SQL = "Select sm.admno,s.sname,sm.Discount,sm.Amount,Convert(varchar(20),sm.CurrDate,101),s.cstandard,std.division from tbl_SalesMaster sm inner join tbl_student s on s.adno=sm.admno inner join tbl_stddivision std on std.adno=s.adno where sm.BillNo=" + BillNo;
            SqlDataAdapter da = new SqlDataAdapter(SQL, d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dr = ds.Tables[0].Rows[0];
                sb.SetParameterValue("BillNo", BillNo);
                sb.SetParameterValue("Admno", dr[0].ToString());
                sb.SetParameterValue("Name", dr[1].ToString());
                sb.SetParameterValue("Discount", dr[2].ToString());
                sb.SetParameterValue("TotalAmount", dr[3].ToString());
                sb.SetParameterValue("SchoolName", "Nizamia Public School");
                sb.SetParameterValue("DT", dr[4].ToString());
                sb.SetParameterValue("std", dr[5].ToString());
                sb.SetParameterValue("div", dr[6].ToString());
                sb.SetParameterValue("Addr", "Pothencode, Trivandrum");
                sb.SetParameterValue("Phone", "0471-6444002");
                crystalReportViewer1.ReportSource = sb;
                

            }


            /*sb.SetParameterValue("BillNo", SchoolManagement.salesbillno);
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
            crystalReportViewer1.ReportSource = sb;*/

        }

        private void button1_Click(object sender, EventArgs e)
        {
            lslBills.DataSource = null;
            FillBills(dateTimePicker1.Value.ToString());
        }

        private void lslBills_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Report(lslBills.Text.Trim());
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string BillNo = "";
            BillNo = lslBills.Text.Trim();
            DialogResult r = new DialogResult();
            if (BillNo.Trim() != "")
            {
                r = MessageBox.Show("Are you sure to remove this Bill", "Warning", MessageBoxButtons.YesNoCancel);
                if (r == DialogResult.Yes)
                {
                    d.con_open();
                    SqlCommand cmd = new SqlCommand("Delete from tbl_sales where BillNo=" + BillNo,d.con);
                    cmd.ExecuteNonQuery();

                    SqlCommand cmd1 = new SqlCommand("Delete from tbl_SalesMaster where BillNo=" + BillNo,d.con);
                    cmd1.ExecuteNonQuery();
                    FillBills("Nil");
                    crystalReportViewer1.ReportSource = null;
                    d.con_close();
                }
            }
            else
            {
                MessageBox.Show("Please select BillNo first");
            }
        }
    }
}
