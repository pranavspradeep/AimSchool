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
    public partial class Buspayment : Form
    {
        DataLayer d = new DataLayer();
        string adno = "";
        string ddate = "";
        //string myr = "";
        
        int i;

        public Buspayment()
        {
            InitializeComponent();
        }

        private void Buspayment_Load(object sender, EventArgs e)
        {
            //To get the student details 
            SqlDataAdapter ad = new SqlDataAdapter("select s.sname as Name,s.cstandard as Standard,r.fare as Fare from tbl_student s inner join tbl_assignroute a on s.adno=a.adno inner join tbl_routepoint r on a.ptnum=r.ptnum where s.adno='"+ SchoolManagement.rno +"'", d.con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            DataRow dr;
            
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dr = ds.Tables[0].Rows[0];
                txtname.Text = dr[0].ToString();
                txtstd.Text = dr[1].ToString();
                txtfare.Text = dr[2].ToString();
            }

            // select adno from table

            SqlDataAdapter ad2=new SqlDataAdapter("select adno from tbl_student where sname='"+txtname.Text+"'",d.con);
            DataSet ds2=new DataSet();
            ad2.Fill(ds2);
            DataRow dr2;
            if(ds2.Tables[0].Rows.Count>=1)
            {
                dr2=ds2.Tables[0].Rows[0];
                adno=dr2[0].ToString();
                
            }

            SqlDataAdapter ad1 = new SqlDataAdapter("select s.sname as Name,s.cstandard as Standard,r.fare as Fare,b.date as [Collection Date] from tbl_student s inner join tbl_assignroute a on s.adno=a.adno inner join tbl_routepoint r on a.ptnum=r.ptnum inner join tbl_buspayment b on r.ptnum=b.ptnum where s.adno='" + adno + "'", d.con);
            DataSet ds1 = new DataSet();
             ad1.Fill(ds1);
            if (ds1.Tables[0].Rows.Count >= 1)
            {
                dgv_bus.DataSource = ds1.Tables[0];
            }
              
        }
        
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
     
        
        private void btn_Add_Click(object sender, EventArgs e)
        {
            string a = DateTime.Parse(dtpcollect.Text.ToString()).ToString("MM-yy");

            // To select the month and year from database

            string s = "select date from tbl_buspayment where adno='"+ adno +"'";
            SqlDataAdapter ad3 = new SqlDataAdapter(s, d.con);
            DataSet ds3 = new DataSet();
            ad3.Fill(ds3);
            DataRow dr3;
            Boolean f = false;
            for (i = 0; i < ds3.Tables[0].Rows.Count; i++)
            {
               dr3 = ds3.Tables[0].Rows[i];
               ddate = DateTime.Parse(dr3[0].ToString()).ToString("MM-yy");
               if (ddate == a)
                {
                 f = true;
                }
            }
            if (f == true)
            {
                MessageBox.Show("Month already added","Warning...",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                d.con_open();

                SqlCommand cmd = new SqlCommand("ins_busfare", d.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ptnum", SchoolManagement.ptnum);
                cmd.Parameters.AddWithValue("@adno", SchoolManagement.rno);
                cmd.Parameters.AddWithValue("@date", DateTime.Parse(dtpcollect.Text.ToString()).ToString("dd-MMM-yy"));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Bus fare added successfully", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information);

                d.con_close();

                // to display the details in gridview

                dgv_bus.DataSource = null;
                SqlDataAdapter ad2 = new SqlDataAdapter("select s.sname as Name,s.cstandard as Standard,r.fare as Fare,b.date as [Collection Date] from tbl_student s inner join tbl_assignroute a on s.adno=a.adno inner join tbl_routepoint r on a.ptnum=r.ptnum inner join tbl_buspayment b on r.ptnum=b.ptnum where s.adno='" + adno + "'", d.con);
                DataSet ds2 = new DataSet();
                ad2.Fill(ds2);
                if (ds2.Tables[0].Rows.Count >= 1)
                {
                  dgv_bus.DataSource = ds2.Tables[0];
                }
            }
          
          
        }
       
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            txtname.Text = "";
            txtstd.Text = "";
            txtfare.Text = "";

        }
    }
}


