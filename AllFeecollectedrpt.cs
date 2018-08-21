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
    public partial class AllFeecollectedrpt : Form
    {
        DataLayer d = new DataLayer();
        double Amount;
        string feetype = "";
        double Total;
        int Rcptno;
        public AllFeecollectedrpt()
        {
            InitializeComponent();
        }
        private void FillBills(string BillDt)
        {
            string SQL = "";
            if (BillDt == "Nil")
            {
                SQL = "Select TrNo from tbl_Transaction";
            }
            else
            {
                SQL = "Select TrNo from tbl_Transaction where Convert(Varchar(10),CurrDate,101)='" + Convert.ToDateTime(dateTimePicker1.Value.ToString()).ToString("MM/dd/yyyy") + "'";

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

        private void AllFeecollectedrpt_Load(object sender, EventArgs e)
        {
            FillBills("Nil");
            d.con_open();
            SqlCommand cmd = new SqlCommand("Delete from tbl_feeTemp", d.con);
            cmd.ExecuteNonQuery();
            d.con_close();
        }
        private void Load_Report()
        {
            d.con_open();
            SqlCommand cmd = new SqlCommand("Delete from tbl_feeTemp", d.con);
            cmd.ExecuteNonQuery();
            d.con_close();

            data();

            SqlDataAdapter da = new SqlDataAdapter("Select feetype as FeeType,Amount from tbl_feeTemp ORDER BY FeeType ASC", d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);

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

            string n = "SELECT tbl_student.sname, tbl_stddivision.cstandard, tbl_stddivision.division, tbl_School.SchoolName, tbl_School.SchoolAddress, tbl_School.Phone FROM tbl_student INNER JOIN tbl_stddivision ON tbl_student.adno = tbl_stddivision.adno CROSS JOIN tbl_School where tbl_student.adno='" + SchoolManagement.rno + "'" ;
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

        private void lslBills_SelectedIndexChanged(object sender, EventArgs e)
        {
            Rcptno = Convert.ToInt32(lslBills.Text.Trim());
            Load_Report();

        }
        public void store()
        {
            d.con_open();
            SqlCommand cmd = new SqlCommand("ins_feeTemp", d.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@feetype", feetype);
            cmd.Parameters.AddWithValue("@Amount", Amount);
            cmd.ExecuteNonQuery();
            d.con_close();
        }
        public void data()
        {
            // To add tution fee from tutionfeepayment table


            SqlDataAdapter da = new SqlDataAdapter("SELECT amount, adno FROM tbl_tutionfeepayment WHERE receiptno=" + Rcptno, d.con);
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
                    SchoolManagement.rno = dr[1].ToString();
                }
                
            }
            else
            {
                dr = ds.Tables[0].Rows[0];
                SchoolManagement.rno = dr[1].ToString();
                Amount = 0;
                feetype = "Tutionfee";
            }

            store();
            
            //To Add Otherfee from otherfeecollect table

            SqlDataAdapter da1 = new SqlDataAdapter("SELECT tbl_othrfeecollect.amount, tbl_fee.feetype FROM tbl_othrfeecollect INNER JOIN tbl_fee ON tbl_othrfeecollect.feeid = tbl_fee.feeid WHERE tbl_othrfeecollect.ReceiptNo =" + Rcptno, d.con);
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
                  
                }

            }

            SqlDataAdapter da2 = new SqlDataAdapter("SELECT Amount FROM tbl_buspayment WHERE busrcptno = " + Rcptno, d.con);
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
    }
}
