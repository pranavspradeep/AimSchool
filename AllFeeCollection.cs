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
    public partial class dgv_PayHistory : DevComponents.DotNetBar.Office2007Form
    {
        DataLayer d = new DataLayer();
        int strdiff = 0;
        string mt = "";
        string mf = "";
        string diff = "";
        string preamnt = "";
        string prefine = "";
        string gmth = "";
        double fine = 0.00;
        string year = "";
        string cdate = "";
        string r = "";
        int ptnum=0;
        Boolean fdpaid = false;
        double ttfee = 0;
        double ttfine = 0;
        int rcptno = 0;
        SchoolManagement sm = new SchoolManagement();

       
        public dgv_PayHistory()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AllFeeCollection_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            //select the student details from table

            string s1 = "select sname AS [Student Name] ,sfname AS [Father Name] ,cstandard AS [Standard] ,Address ,email AS [E-mail] from tbl_student where adno='" + SchoolManagement.rno + "'";

            SqlDataAdapter ad = new SqlDataAdapter(s1, d.con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dr = ds.Tables[0].Rows[0];
                txtsname.Text = dr[0].ToString();
                txtfname.Text = dr[1].ToString();
                txtstd.Text = dr[2].ToString();
                txtadrs.Text = dr[3].ToString();
                txtmail.Text = dr[4].ToString();
            }

            // get date of transaction and maximum receiptnumber

            string dtrans = "";
            string gdte = "";

            string gyr = "";
            string s = "select dateftrans from tbl_tutionfeepayment where adno='" + SchoolManagement.rno + "' and receiptno=(Select MAX(receiptno) from tbl_tutionfeepayment where adno='" + SchoolManagement.rno + "')";
            SqlDataAdapter ad1 = new SqlDataAdapter(s, d.con);
            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);
            DataRow dr1;
            if (ds1.Tables[0].Rows.Count >= 1)
            {
                dr1 = ds1.Tables[0].Rows[0];
                dtrans = DateTime.Parse(dr1[0].ToString()).ToString("dd-MMM-yy");
                gdte = DateTime.Parse(dtrans).ToString("dd");
                gmth = DateTime.Parse(dtrans).ToString("MM");
                gyr = DateTime.Parse(dtrans).ToString("yy");
            }

            // To get the difference between  months

            string ss = "select datediff(month,dateftrans,getdate())from tbl_tutionfeepayment where (receiptno=(select MAX(receiptno)from tbl_tutionfeepayment where adno='" + SchoolManagement.rno + "'))";
            SqlDataAdapter ad2 = new SqlDataAdapter(ss, d.con);
            DataSet ds2 = new DataSet();
            ad2.Fill(ds2);
            DataRow dr2;
            if (ds2.Tables[0].Rows.Count >= 1)
            {
                dr2 = ds2.Tables[0].Rows[0];

                diff = dr2[0].ToString();
                strdiff = int.Parse(diff);

            }

            // select collection date from table tuitionfee

            string st = "select collectiondate from tbl_tuitionfee where cstandard='" + SchoolManagement.standard + "'";
            SqlDataAdapter ad4 = new SqlDataAdapter(st, d.con);
            DataSet ds4 = new DataSet();
            ad4.Fill(ds4);
            DataRow dr4;
            if (ds4.Tables[0].Rows.Count >= 1)
            {
                dr4 = ds4.Tables[0].Rows[0];
                cdate = dr4[0].ToString();

            }

            //select amount and fine from table 
            //need to change
            double amount = 0.00;
            double fine = 0.00;
            string amnt = "select amount,fine,collectiondate from tbl_tuitionfee where cstandard= '" + SchoolManagement.standard + "'";
            SqlDataAdapter ad3 = new SqlDataAdapter(amnt, d.con);
            DataSet ds3 = new DataSet();
            ad3.Fill(ds3);
            DataRow dr3;
            if (ds3.Tables[0].Rows.Count >= 1)
            {
                dr3 = ds3.Tables[0].Rows[0];

                preamnt = dr3[0].ToString();
                prefine = dr3[1].ToString();
                txtamnt.Text = preamnt;
                txtfine.Text = prefine;
            }
            if (strdiff >= 1)
            {
                amount = Convert.ToDouble(diff) * Convert.ToDouble(preamnt);
                fine = Convert.ToDouble(diff) * Convert.ToDouble(prefine);
                txtamnt.Text = amount.ToString();
                txtfine.Text = fine.ToString();
                //need to change here no month/year chking
                if (Int32.Parse(DateTime.Now.ToString("dd")) < Int32.Parse(cdate))
                {
                    txtfine.Text = Convert.ToString(Double.Parse(txtfine.Text) - Double.Parse(prefine));
                }

            }
            else
            {
                txtamnt.Text = preamnt.ToString();
                // txtfine.Text = "0.00";
            }

            //if (int.Parse( cdate >= dtrans)
            //{
            //    amount = Convert.ToDouble(preamnt);
            //    fine = 0.0;
            //}

            // To display the last transaction details in datagridview

            string tp = "select top 4 s.sname as Name,s.cstandard as Standard,p.receiptno as ReceiptNumber,p.dateftrans as DateofTrans,p.month as Month,p.year as Year,p.amount as Amount,p.fine as Fine from tbl_student s  inner join tbl_tutionfeepayment p on s.adno=p.adno and  p.adno= '" + SchoolManagement.rno + "' ORDER BY p.receiptno desc";
            SqlDataAdapter ad5 = new SqlDataAdapter(tp, d.con);
            DataSet ds5 = new DataSet();
            ad5.Fill(ds5);
            DataRow dr5;
            if (ds5.Tables[0].Rows.Count >= 1)
            {
                dr5 = ds5.Tables[0].Rows[0];
               // dgv_feepayment.DataSource = ds5.Tables[0];
            }
           //display bus route and fee
            dispbusfee();
            // For other fee

            //Set receipt number
             rcptno=sm.rtv_receiptno();
            // Select feetype from table using stored procedure
            d.con_open();
            SqlCommand cmd = new SqlCommand("sel_feetype", d.con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                cmbtype.Items.Add(r[0].ToString());
            }
            d.con_close();

        }
        private void dispbusfee()
        {
            string s = "Select rp.rfrom,rp.rto,rp.fare,rp.ptnum from tbl_routepoint rp inner join tbl_assignroute ar on rp.ptnum=ar.ptnum and ar.adno='" + SchoolManagement.rno + "'";
            SqlDataAdapter da = new SqlDataAdapter(s, d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dr = ds.Tables[0].Rows[0];
                txtBusRoute.Text  = dr[0].ToString() + "-" + dr[1].ToString();
                txtFare.Text = dr[2].ToString();
                ptnum=Convert.ToInt32(dr[3].ToString());
            }
        }

        private void txtamnt_Leave(object sender, EventArgs e)
        {
            

        }
      
        private void ins_dailytrans(int trno,string type,string desc,double amt)
        {
            d.con_open();
            SqlCommand cmd = new SqlCommand("ins_dailytrans", d.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@trano",trno));
            cmd.Parameters.Add(new SqlParameter("@type",type));
            cmd.Parameters.Add(new SqlParameter("@desc", desc));
            cmd.Parameters.Add(new SqlParameter("@amt",amt));
            cmd.ExecuteNonQuery();
            d.con_close();

        }
        public Boolean Validate_Data()
        {
            Boolean b = true;
            if (cmbfrom.Text == "" || cmbfrom.Text == null)
            {
                b = false;
                MessageBox.Show("Select which month from the fee to be paid!", " Warning....", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
            }
            else if (cmbto.Text == "" || cmbto.Text == null)
            {
                b = false;
                MessageBox.Show("Select which month to the fee to be paid!", " Warning....", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
            }
            return b;
        }

        private void btn_Fee_Click(object sender, EventArgs e)
        {
            if (Validate_Data() == true)
            {
                fdpaid = true;
                string s = "";
                double camount;
                double cfine;
                double a = double.Parse(txtamnt.Text);
                s = Convert.ToDateTime("1-" + cmbfrom.Text + "-" + System.DateTime.Now.Year).ToString("MM");
                string t = Convert.ToDateTime("1-" + cmbto.Text + "-" + System.DateTime.Now.Year).ToString("MM");
                string pdate = DateTime.Parse(dtppaiddate.Text).ToString("dd");
                string pdtp = DateTime.Parse(dtppaiddate.Text).ToString("dd-MMM-yy");
                string pmnth = DateTime.Parse(dtppaiddate.Text).ToString("MM");
                year = DateTime.Parse(dtpyear.Text).ToString("dd-MMM-yy");

                // to select max month from table

                string dbmonth = "";
                string s1 = "select Max(month) from tbl_tutionfeepayment where (receiptno=(select MAX(receiptno)from tbl_tutionfeepayment where adno='" + SchoolManagement.rno + "'))";
                SqlDataAdapter ad1 = new SqlDataAdapter(s1, d.con);
                DataSet ds1 = new DataSet();
                ad1.Fill(ds1);
                DataRow dr4;
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    dr4 = ds1.Tables[0].Rows[0];
                    dbmonth = dr4[0].ToString();
                    if (dbmonth == "" || dbmonth == null)
                    {
                        dbmonth = "0";
                    }

                }

                if ((Convert.ToInt32(dbmonth) - Convert.ToInt32(s)) == 0)
                {

                    MessageBox.Show("Fees already paid for this month", "warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

                else if ((Convert.ToInt32(dbmonth) - Convert.ToInt32(s)) >= 1)
                {
                    MessageBox.Show("Fees already paid for this month", "warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if ((Convert.ToInt32(s) - Convert.ToInt32(dbmonth)) > 1 && cmbfrom.Text != "JUNE")
                {
                    MessageBox.Show("Fees not paid for the previous month", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Increment receipt number in database

                    /*  SqlDataAdapter ad = new SqlDataAdapter("select Max(receiptno) from tbl_tutionfeepayment", d.con);
                      DataSet ds = new DataSet();
                      ad.Fill(ds);
                      DataRow dr1;
                      receiptno = 0;
                      if (ds.Tables[0].Rows.Count > 0)
                      {
                          dr1 = ds.Tables[0].Rows[0];
                          r = dr1[0].ToString();
                          if (r == "" || r == null)
                          {
                              r = "0";
                          }
                          receiptno = int.Parse(r.ToString()) + 1;
                      }*/
                    if (Convert.ToDouble(cdate) >= Convert.ToDouble(pdate))
                    {
                        camount = (Convert.ToDouble(strdiff) * a);
                        cfine = fine - Convert.ToDouble(txtfine.Text);
                    }


                    int si = Convert.ToInt32(s);
                    int ti = Convert.ToInt32(t);

                    for (int i = si; si <= ti; si++)
                    {
                        d.con_open();
                        SqlCommand cmd = new SqlCommand("ins_feepay", d.con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@receiptno", rcptno);
                        cmd.Parameters.AddWithValue("@adno", SchoolManagement.rno);
                        cmd.Parameters.AddWithValue("@dateftrans", pdtp);
                        cmd.Parameters.AddWithValue("@month", si);
                        cmd.Parameters.AddWithValue("@year", year);
                        cmd.Parameters.AddWithValue("@amount", txtamnt.Text);
                        cmd.Parameters.AddWithValue("@fine", txtfine.Text);
                        cmd.ExecuteNonQuery();
                        d.con_close();
                        ttfee = ttfee + Convert.ToDouble(txtamnt.Text);
                        ttfine = ttfine + Convert.ToDouble(txtfine.Text);
                        // Inserting for daily trans
                        ins_dailytrans(rcptno, "CR", "Tution Fee", Convert.ToDouble(txtamnt.Text) + Convert.ToDouble(txtfine.Text));
                        txtfine.Text = "0";
                        // dgv_feepayment.DataSource = null;
                        string tp = "select top 4 s.sname AS [Student Name],s.cstandard AS [Standard],p.receiptno AS [Receipt No],p.dateftrans AS [Date Of Transaction],p.month AS Month,p.year AS Year,p.amount AS Amount,p.fine AS Fine from tbl_student s  inner join tbl_tutionfeepayment p on s.adno=p.adno and  p.adno= '" + SchoolManagement.rno + "' ORDER BY  p.receiptno desc";
                        SqlDataAdapter ad5 = new SqlDataAdapter(tp, d.con);
                        DataSet ds5 = new DataSet();
                        ad5.Fill(ds5);
                        DataRow dr5;
                        if (ds5.Tables[0].Rows.Count >= 1)
                        {
                            dr5 = ds5.Tables[0].Rows[0];
                            //dgv_feepayment.DataSource = ds5.Tables[0];
                        }
                        txtTotalFee.Text = Convert.ToString(Convert.ToDouble(txtTotalFee.Text) + Convert.ToDouble(txtamnt.Text));

                    }
                    MessageBox.Show("Fee saved successfully", "Saved..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //txtamnt.Text = "";
                    //txtfine.Text = "";
                    //txtadrs.Text = "";
                    //txtsname.Text = "";
                    //txtstd.Text = "";
                    //txtfname.Text = "";
                    //txtmail.Text = "";
                    //cmbfrom.Text = "";
                    //cmbto.Text = "";
                }

            }    
        }

        private void btn_AddthrFee_Click(object sender, EventArgs e)
        {
            string fine = "";
            string id = "";
            SqlDataAdapter ad = new SqlDataAdapter("select feeid,fine from tbl_fee where feetype='" + cmbtype.Text + "'and cstandard='" + txtstd.Text + "'", d.con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dr = ds.Tables[0].Rows[0];
                id = dr[0].ToString();
                fine = dr[1].ToString();

            }

            if (Convert.ToInt32(txtdate.Text) <= Convert.ToInt32(DateTime.Parse(dtppaiddate.Text.ToString()).ToString("dd")))
            {
                txtofine.Text = fine;
            }
            else
            {
                txtofine.Text = "";
            }

            //to validate 

            //if (mnyr ==DateTime.Parse(dtppaiddate.Text.ToString()).ToString("dd-MM-yy"))   
            //{
            //    MessageBox.Show("xx");
            //}
            //else
            //{
            d.con_open();
            SqlCommand cmd = new SqlCommand("ins_addothrfeecollect", d.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@rcptno", rcptno);
            cmd.Parameters.AddWithValue("@feeid", id);
            cmd.Parameters.AddWithValue("@adno", SchoolManagement.rno);
            cmd.Parameters.AddWithValue("@datefpay", DateTime.Parse(dtppaiddate.Text.ToString()).ToString("dd-MMM-yy"));
            cmd.Parameters.AddWithValue("@amount", txtamt.Text);
            cmd.Parameters.AddWithValue("@fine", txtofine.Text);
            cmd.ExecuteNonQuery();
            d.con_close();
            //ins_dailytrans(rcptno, "CR", "Other Fee" + cmbtype.Text, Convert.ToDouble(txtamnt.Text) + Convert.ToDouble(txtofine.Text));
            MessageBox.Show("Fee saved successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtTotalFee.Text = Convert.ToString(Convert.ToDouble(txtTotalFee.Text) + (Convert.ToDouble(txtamt.Text)+Convert.ToDouble(txtofine.Text)));
            //txtfine.Text = "";
            //txtadrs.Text = "";
            //txtamt.Text = "";
            //txtdate.Text = "";
            //txtfname.Text = "";
            //txtmail.Text = "";
            //txtsname.Text = "";
            //txtstd.Text = "";
            //cmbtype.Text = "";
            //dtppaiddate.Text = "";

            
            //dgv_feeview.DataSource = null;

            SqlDataAdapter ad2 = new SqlDataAdapter("SELECT stud.sname as Name,stud.cstandard as Standard,other.datefpay as Date,other.amount as Amount,other.fine as Fine FROM tbl_othrfeecollect AS other INNER JOIN tbl_student AS stud ON other.adno = stud.adno where other.adno='" + SchoolManagement.rno + "'", d.con);
            DataSet ds2 = new DataSet();
            ad2.Fill(ds2);
            if (ds2.Tables[0].Rows.Count >= 1)
            {
                //dgv_feeview.DataSource = ds2.Tables[0];
            }
            // }
        }

        private void cmbtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter ad = new SqlDataAdapter("select collection,amount from tbl_fee where feetype='" + cmbtype.Text + "'and cstandard='" + txtstd.Text + "'", d.con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dr = ds.Tables[0].Rows[0];
                txtdate.Text = DateTime.Parse(dr[0].ToString()).ToString("dd");
                txtamt.Text = dr[1].ToString();
            }
        }
        private void btnFeeSave_Click(object sender, EventArgs e)
        {
            //To Check whether fee paid or not
            string fee = "0";
            string feefine = "0";
            if (fdpaid == true)
            {
                fee = ttfee.ToString();
                feefine = ttfine.ToString();
            }
            //d.con_open();
            //SqlCommand cmd = new SqlCommand("ins_TotalFee", d.con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add(new SqlParameter("@ReceiptNo", rcptno));
            //cmd.Parameters.Add(new SqlParameter("@TutionFee", fee));
            //cmd.Parameters.Add(new SqlParameter("@TutionFine", feefine));
            //cmd.Parameters.Add(new SqlParameter("@OtherFee", txtamt.Text));
            //cmd.Parameters.Add(new SqlParameter("@OtherFine", txtofine.Text));
            //cmd.Parameters.Add(new SqlParameter("@BusFee", txtFare.Text));
            //cmd.Parameters.Add(new SqlParameter("@BusFine", txtBusFareFine.Text));
            //cmd.Parameters.Add(new SqlParameter("@Total", txtTotalFee.Text));
            //cmd.ExecuteNonQuery();
            //d.con_close();
            Save_Receipt();
            fdpaid = false;
            MessageBox.Show("Fee Paid Successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnFeeSave.Enabled = false;
            button1.Enabled = true;
        }

        private void btnAddBusFee_Click(object sender, EventArgs e)
        {
            int di = 0;
           di= DateTime.Compare(Convert.ToDateTime(Dt2.Text), Convert.ToDateTime(Dt1.Text));
           txtTotalBusFee.Text = Convert.ToString((Convert.ToDouble (txtFare.Text) * di) + Convert.ToDouble(txtBusFareFine.Text));

           d.con_open();
           SqlCommand cmd = new SqlCommand("ins_busfare", d.con);
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.Add(new SqlParameter("@rcptno", rcptno));
           cmd.Parameters.Add(new SqlParameter("@ptnum", ptnum));
           cmd.Parameters.Add(new SqlParameter("@adno", SchoolManagement.rno));
           cmd.Parameters.Add(new SqlParameter("@frmdate", Convert.ToDateTime(Dt1.Text)));
           cmd.Parameters.Add(new SqlParameter("@todate", Convert.ToDateTime(Dt2.Text)));
           cmd.Parameters.Add(new SqlParameter("@amt", txtTotalBusFee.Text));
           cmd.Parameters.Add(new SqlParameter("@fine", txtfine.Text));
           cmd.Parameters.Add(new SqlParameter("@tdate", System.DateTime.Now.ToString("dd-MMM-yyyy")));
           cmd.ExecuteNonQuery();
           txtTotalFee.Text = Convert.ToString(Convert.ToDouble(txtTotalFee.Text) + Convert.ToDouble(txtTotalBusFee.Text));

           d.con_close();

           ins_dailytrans(rcptno, "CR", "Bus Fee", Convert.ToDouble(txtTotalBusFee.Text));

        }
        /// <summary>
        /// Save Last Receipt No
        /// </summary>
        private void Save_Receipt()
        {
            d.con_open();
            SqlCommand cmd = new SqlCommand("ins_trans", d.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@trno", rcptno);
            cmd.Parameters.Add(new SqlParameter("@tdate", System.DateTime.Now.ToString("dd-MMM-yyyy")));
            cmd.ExecuteNonQuery();
         
            //receiptno = 100;
            d.con_close();
            SchoolManagement.Feettl = Convert.ToDouble(txtTotalFee.Text);

        }
        private void button1_Click(object sender, EventArgs e)
        {
           //For Receipt
            //SqlDataAdapter da = new SqlDataAdapter("Select TrNo,TType as FeeType,TDesc as Description,Amount as Amount from tbl_dailytransaction where TrNo=(Select isnull(max(TrNo),0) from tbl_dailytransaction)", d.con);
            //DataSet ds = new DataSet();
            //da.Fill(ds);
            //FeeCrystalReport1 fc = new FeeCrystalReport1();
            //fc.SetDataSource(ds.Tables[0]);
            FeeCollectionReprt fr = new FeeCollectionReprt();             
            fr.Show(); 
           
            //Do balance coding

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {

        }       
        private Boolean finechk()
        {
            string mn1="";
            string mn2="";

            mn1=dateTimePicker1.Value.ToString("dd-MMM-yy").Substring(3,3);
            mn2 = Convert.ToString(System.DateTime.Now.ToString("dd-MMM-yy")).Substring(3, 3);
            if (mn1 == mn2)
            {

            }
            return true;
        }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            string amnt = "select amount,fine,collectiondate from tbl_tuitionfee where cstandard= '" + SchoolManagement.standard + "'";
            SqlDataAdapter da = new SqlDataAdapter(amnt, d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dr = ds.Tables[0].Rows[0];
                txtamnt.Text = dr[0].ToString();
            }
           
        }

        private void btn_History_Click(object sender, EventArgs e)
        {         

            // to select Payment History from table to grid
           
            string s1 = "Select TOP 10 receiptno as [Receipt No],dateftrans as [Date of Payment] from tbl_tutionfeepayment where adno='" + SchoolManagement.rno + "' ORDER BY receiptno DESC";
            SqlDataAdapter ad1 = new SqlDataAdapter(s1, d.con);
            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);
            dgv_PaymentHistory.DataSource = ds1.Tables[0];
            groupBox1.Visible = true;
        }
    }       
    
}