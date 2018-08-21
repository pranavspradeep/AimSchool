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
    public partial class feepayment : Form
    {
        DataLayer d = new DataLayer();
        int strdiff=0;    
        string mt = "";
        string mf = "";
        string diff="";
        string preamnt = "";
        string prefine = "";
        string gmth = "";
        double fine = 0.00;
        string year = "";
        string cdate = "";
        string r = "";
        int receiptno;

        public feepayment()
        {
            InitializeComponent();
        }

        private void feepayment_Load(object sender, EventArgs e)
        {
          
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
            string s="select dateftrans from tbl_tutionfeepayment where adno='" + SchoolManagement.rno + "' and receiptno=(Select MAX(receiptno) from tbl_tutionfeepayment where adno='" + SchoolManagement.rno + "')";
            SqlDataAdapter ad1 = new SqlDataAdapter(s, d.con);
            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);
            DataRow dr1;
            if (ds1.Tables[0].Rows.Count >= 1)
            {
                dr1 = ds1.Tables[0].Rows[0];
                dtrans =DateTime.Parse(dr1[0].ToString()).ToString("dd-MMM-yy");
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

            string st = "select collectiondate from tbl_tuitionfee where cstandard='"+SchoolManagement.standard+"'";
            SqlDataAdapter ad4=new SqlDataAdapter(st,d.con);
            DataSet ds4=new DataSet();
            ad4.Fill(ds4);
            DataRow dr4;
            if(ds4.Tables[0].Rows.Count>=1)
            {
                dr4=ds4.Tables[0].Rows[0];
                cdate=dr4[0].ToString();
                
            }

            //select amount and fine from table 
            //need to change
            double amount = 0.00;
            double fine = 0.00;
            string amnt="select amount,fine,collectiondate from tbl_tuitionfee where cstandard= '" +SchoolManagement.standard+ "'";
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

            string tp = "select top 4 s.sname as Name,s.cstandard as Standard,p.receiptno as ReceiptNumber,p.dateftrans as DateofTrans,p.month as Month,p.year as Year,p.amount as Amount,p.fine as Fine from tbl_student s  inner join tbl_tutionfeepayment p on s.adno=p.adno and  p.adno= "+ SchoolManagement.rno +" ORDER BY p.receiptno desc" ;
            SqlDataAdapter ad5 = new SqlDataAdapter(tp, d.con);
            DataSet ds5 = new DataSet();
            ad5.Fill(ds5);
            DataRow dr5;
            if (ds5.Tables[0].Rows.Count >= 1)
            {
                dr5 = ds5.Tables[0].Rows[0];
                dgv_feepayment.DataSource = ds5.Tables[0];
            }
           

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
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
                string s1="select Max(month) from tbl_tutionfeepayment where (receiptno=(select MAX(receiptno)from tbl_tutionfeepayment where adno='" + SchoolManagement.rno + "'))";
                SqlDataAdapter ad1 = new SqlDataAdapter(s1, d.con);
                DataSet ds1 = new DataSet();
                ad1.Fill(ds1);
                DataRow dr4;
                if (ds1.Tables[0].Rows.Count >0)
                {
                    dr4 = ds1.Tables[0].Rows[0];
                    dbmonth = dr4[0].ToString();
                    if (dbmonth == "" || dbmonth == null)
                    {
                        dbmonth = "0";
                    }

                }
               
                if((Convert.ToInt32(dbmonth)-Convert.ToInt32(s))==0)
                {
                     
                    MessageBox.Show("Fees already paid for this month", "warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                                                       
                }

                else if ((Convert.ToInt32(dbmonth) - Convert.ToInt32(s)) >= 1)
                {
                       MessageBox.Show("Fees already paid for this month", "warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if ((Convert.ToInt32(s) - Convert.ToInt32(dbmonth)) > 1 && cmbfrom.Text!="JUNE")
                {
                  MessageBox.Show("Fees not paid for the previous month", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                   else
                   {
                       // Increment receipt number in database

                       SqlDataAdapter ad = new SqlDataAdapter("select Max(receiptno) from tbl_tutionfeepayment", d.con);
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
                       }
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
                           cmd.Parameters.AddWithValue("@receiptno", receiptno);
                           cmd.Parameters.AddWithValue("@adno", SchoolManagement.rno);
                           cmd.Parameters.AddWithValue("@dateftrans", pdtp);
                           cmd.Parameters.AddWithValue("@month", si);
                           cmd.Parameters.AddWithValue("@year", year);
                           cmd.Parameters.AddWithValue("@amount", txtamnt.Text);
                           cmd.Parameters.AddWithValue("@fine", txtfine.Text);
                           cmd.ExecuteNonQuery();
                           d.con_close();
                           txtfine.Text = "0";
                           dgv_feepayment.DataSource = null;
                           string tp = "select top 4 s.sname AS [Student Name],s.cstandard AS [Standard],p.receiptno AS [Receipt No],p.dateftrans AS [Date Of Transaction],p.month AS Month,p.year AS Year,p.amount AS Amount,p.fine AS Fine from tbl_student s  inner join tbl_tutionfeepayment p on s.adno=p.adno and  p.adno= " + SchoolManagement.rno + " ORDER BY  p.receiptno desc";
                           SqlDataAdapter ad5 = new SqlDataAdapter(tp, d.con);
                           DataSet ds5 = new DataSet();
                           ad5.Fill(ds5);
                           DataRow dr5;
                           if (ds5.Tables[0].Rows.Count >= 1)
                           {
                               dr5 = ds5.Tables[0].Rows[0];
                               dgv_feepayment.DataSource = ds5.Tables[0];
                           }

                       }
                       MessageBox.Show("Fee saved successfully", "Saved..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       txtamnt.Text = "";
                       txtfine.Text = "";
                       txtadrs.Text = "";
                       txtsname.Text = "";
                       txtstd.Text = "";
                       txtfname.Text = "";
                       txtmail.Text = "";
                       cmbfrom.Text = "";
                       cmbto.Text = "";

                   }      
        }
        

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dtppaiddate_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbfrm_SelectedIndexChanged(object sender, EventArgs e)
        {

           
        }

        private void cmbto_SelectedIndexChanged(object sender, EventArgs e)
        {
            mt = cmbto.SelectedItem.ToString();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            txtsname.Text = "";
            txtfname.Text = "";
            txtstd.Text = "";
            txtmail.Text = "";
            txtadrs.Text = "";
            txtamnt.Text = "";
            txtfine.Text = "";

        }

        private void cmbfrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            mf = cmbfrom.SelectedItem.ToString();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_feepayment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}