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
    public partial class SalesBillPrivew : Form
    {
        DataLayer d = new DataLayer();
        public SalesBillPrivew()
        {
            InitializeComponent();
        }

        private void SalesBillPrivew_Load(object sender, EventArgs e)
        {
           
            string s="Select i.Item_Name as [Item],s.Quantity as [Qty],i.ITEM_RETAIL_PRICE as [Price],s.Quantity*i.ITEM_RETAIL_PRICE as [Amount] from tbl_Item i Join tbl_Sales s on i.Item_id=s.Itemno where s.BillNo=" + SchoolManagement.salesbillno;
            SqlDataAdapter da = new SqlDataAdapter(s, d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            
            SalesBill sb = new SalesBill();
            sb.SetDataSource(ds.Tables[0]);
            sb.SetParameterValue("BillNo",SchoolManagement.salesbillno);
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
            crystalReportViewer1.ReportSource = sb;
            
            
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
