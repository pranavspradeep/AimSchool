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
    public partial class FeeCollectionReprt : DevComponents.DotNetBar.Office2007Form
    {
        DataLayer d = new DataLayer();
        int trnno;
        double Amount;
        string feetype = "";
        double Total;
        DataTable dt = new DataTable();
        SchoolManagement sm = new SchoolManagement();
        String Amtwords = "";
        public FeeCollectionReprt()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
           
         /*   string s1 = "SELECT        Amount, BillNo, Feetype, Description, TranDate FROM tbl_FeesCollection where TranDate>='" +SchoolManagement.dtp3 + "'AND TranDate<= '" + SchoolManagement.dtp4 + "' ";
            SqlDataAdapter da1 = new SqlDataAdapter(s1, d.con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            if (ds1.Tables[0].Rows.Count >0)
            {
                string s = "SELECT        Amount, BillNo, Feetype, Description, TranDate FROM tbl_FeesCollection where TranDate>='" +SchoolManagement.dtp3 + "'AND TranDate<= '" + SchoolManagement.dtp4 + "'ORDER BY TranDate DESC ";
                SqlDataAdapter da = new SqlDataAdapter(s, d.con);
                DataSet ds = new DataSet();
                DataRow dr;
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    dr = ds.Tables[0].Rows[0];
                    FeeCrystalReport1 frp = new FeeCrystalReport1();
                    frp.SetDataSource(ds.Tables[0]);
                    crystalReportViewer1.ReportSource = frp;
                    frp.SetParameterValue("startdate", SchoolManagement.dtp3);
                    frp.SetParameterValue("enddate", SchoolManagement.dtp4);
                    crystalReportViewer1.Refresh();

                }
            }*/
            
        }

        public void store()
        {
            d.con_open();
            SqlCommand cmd = new SqlCommand("ins_feeTemp",d.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@feetype", feetype);
            cmd.Parameters.AddWithValue("@Amount", Amount);
            cmd.ExecuteNonQuery();
            d.con_close();
        }
        
        public void data()
        {
            // To add tution fee from tutionfeepayment table
      
            
            SqlDataAdapter da = new SqlDataAdapter("SELECT amount FROM tbl_tutionfeepayment WHERE receiptno=" + trnno, d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataRow dr;
            double tutionfee = 0;
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dr = ds.Tables[0].Rows[0];
                    tutionfee = Convert.ToDouble(dr[0].ToString());
                    feetype = "TutionFee";
                    Amount = tutionfee + Amount;
                }
                
            }
            else
            {
                Amount = 0;
                feetype = "Tutionfee";
            }

            store();
            
            //DataRow fee = dt.NewRow();
            //fee["Feetype"] = feetype;
            //fee["Amount"] = Amount;

            //dt.Rows.Add(fee);

            //To Add Otherfee from otherfeecollect table

            SqlDataAdapter da1 = new SqlDataAdapter("SELECT tbl_othrfeecollect.amount, tbl_fee.feetype FROM tbl_othrfeecollect LEFT JOIN tbl_fee ON tbl_othrfeecollect.feeid = tbl_fee.feeid WHERE tbl_othrfeecollect.ReceiptNo =" + trnno,d.con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            DataRow dr1;
            if (ds1.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    dr1 = ds1.Tables[0].Rows[i];
                    Amount = Convert.ToDouble(dr1[0].ToString());
                    feetype = dr1[1].ToString();
                    store();
                    
                    //DataRow otherfee = dt.NewRow();
                    //otherfee["Feetype"] = feetype;
                    //otherfee["Amount"] = Amount;

                    //dt.Rows.Add(otherfee);
                }
                
            }

            SqlDataAdapter da2 = new SqlDataAdapter("SELECT Amount FROM tbl_buspayment WHERE busrcptno = " + trnno, d.con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            DataRow dr2;
            double busfare = 0;
            if (ds2.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                {
                    dr2 = ds2.Tables[0].Rows[i];
                    busfare = Convert.ToDouble(dr2[0].ToString());
                    feetype = "BusFee";
                    Amount = busfare + Amount;
                }
                
            }
            else
            {
                Amount = 0;
                feetype = "BusFee";
            }
            store();
        }
        public void Numbertotext()
        {
            
        }
        private void FeeCollectionReprt_Load(object sender, EventArgs e)
        {
            //SqlDataAdapter da = new SqlDataAdapter("Select TrNo as TransNo,TType as FeeType,TDesc as Description,Amount as Amount from tbl_dailytransaction where TrNo=(Select isnull(max(TrNo),0) from tbl_dailytransaction)", d.con);
            //DataSet ds = new DataSet();
            //da.Fill(ds);

            //FeeCrystalReport1 fc = new FeeCrystalReport1();
            //fc.SetDataSource(ds.Tables[0]);
            //fc.SetParameterValue("TDate", DateTime.Now.ToString());
            //fc.SetParameterValue("SchoolName", SchoolManagement.SchoolName);
            //fc.SetParameterValue("[Total Amount]", SchoolManagement.Feettl.ToString());
            //crystalReportViewer1.ReportSource = fc;
            //SqlDataAdapter da = new SqlDataAdapter("Select TrNo as TransNo,TDesc as FeeType,isnull(Amount,0) as Amount from tbl_dailytransaction where TrNo=(Select isnull(max(TrNo),0) from tbl_dailytransaction)", d.con);
            d.con_open();
            SqlCommand cmd = new SqlCommand("Delete from tbl_feeTemp",d.con);
            cmd.ExecuteNonQuery();
            d.con_close();
            trnno = SchoolManagement.receiptno;              
 
            data();            
            //Amtwords = sm.

            //string st = "SELECT tbl_Transaction.TrNo, tbl_tutionfeepayment.amount, tbl_othrfeecollect.amount AS Expr1, tbl_buspayment.Amount AS Expr2 FROM tbl_tutionfeepayment INNER JOIN tbl_Transaction ON tbl_tutionfeepayment.receiptno = tbl_Transaction.TrNo INNER JOIN tbl_othrfeecollect ON tbl_Transaction.TrNo = tbl_othrfeecollect.ReceiptNo INNER JOIN tbl_buspayment ON tbl_Transaction.TrNo = tbl_buspayment.busrcptno where tbl_Transaction.TrNo=" + trnno;
            SqlDataAdapter da = new SqlDataAdapter("Select feetype as FeeType,Amount from tbl_feeTemp ORDER BY FeeType ASC", d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            //SchoolManagement.Feettl = 0;
            //DataRow dr;
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    dr = ds.Tables[0].Rows[i];
            //    SchoolManagement.Feettl = SchoolManagement.Feettl + Convert.ToDouble(dr[3].ToString());
            //}           
            FeeCrystalReport1 fc = new FeeCrystalReport1();
            fc.SetDataSource(ds.Tables[0]);

            SqlDataAdapter da2 = new SqlDataAdapter("select Sum(Amount) from tbl_feeTemp", d.con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            DataRow dr2;
            if (ds2.Tables[0].Rows.Count > 0)
            {
                dr2 = ds2.Tables[0].Rows[0];
                Total = Convert.ToDouble(dr2[0].ToString());
            }

            string n = "SELECT tbl_student.sname, tbl_stddivision.cstandard, tbl_stddivision.division, tbl_School.SchoolName, tbl_School.SchoolAddress, tbl_School.Phone FROM tbl_student LEFT JOIN tbl_stddivision ON tbl_student.adno = tbl_stddivision.adno CROSS JOIN tbl_School where tbl_student.adno='" + SchoolManagement.rno + "'" ;
            SqlDataAdapter da1 = new SqlDataAdapter(n, d.con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            DataRow dr1;            
            if (ds1.Tables[0].Rows.Count > 0)
            {
                dr1 = ds1.Tables[0].Rows[0];
                fc.SetParameterValue("StudName", dr1[0].ToString());
                fc.SetParameterValue("Std", dr1[1].ToString());
                fc.SetParameterValue("Division", dr1[2].ToString());
                fc.SetParameterValue("Addr", dr1[4].ToString());
                fc.SetParameterValue("SchoolPhno", dr1[5].ToString());
                //fc.SetParameterValue("Totinwords", "None");
                fc.SetParameterValue("TDate", DateTime.Now.ToString());
               fc.SetParameterValue("SchoolName", SchoolManagement.SchoolName);
                fc.SetParameterValue("TotalFee", Total);
                
            }
            crystalReportViewer1.ReportSource = fc;
        }
    }
}