using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace school
{
    public partial class transferstudent : DevComponents.DotNetBar.Office2007Form
    {
        DataLayer d = new DataLayer();
        string a;
        string b;
        int c;

        public transferstudent()
        {
            InitializeComponent();
        }
        private void exe()
        {
            d.con_open();
            SqlCommand cmd = new SqlCommand("upd_transfer", d.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@std", b);
            cmd.Parameters.AddWithValue("@ad",c);
            cmd.Parameters.AddWithValue("@year", cmbbox1.Text);
            cmd.ExecuteNonQuery();
            d.con_close();
            grid();
            
        }
        private void grid()
        {
            string s = "select * from tbl_stddivision";
            SqlDataAdapter da = new SqlDataAdapter(s, d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            Dgv1.DataSource = ds.Tables[0];       
   
        }

        private void transferstudent_Load(object sender, EventArgs e)
        {
            grid();
            int b = DateTime.Now.Year;
            int a=0;
            for (int i =0;i<39; i++)
            {
                a = b + i;
                cmbbox1.Items.Add(a);
            }
            
        }
        private Boolean valid()
        {
            Boolean f = true;
            if (cmbbox1.Text == "" || cmbbox1.Text == null)
            {
                f = false;
                MessageBox.Show("Please select Academic Year", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Convert.ToInt32(cmbbox1.Text) !=  DateTime.Now.Year)
            {
                f = false;
                MessageBox.Show("Please select current Academic Year", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            return f;
        }

        private void insprevious()
        {
            string s = "Select adno,rollno,cstandard,classno,division,currentyear from tbl_stddivision where adno=" + c + " ";
            SqlDataAdapter da1 = new SqlDataAdapter(s, d.con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            DataRow dr;
            if (ds1.Tables[0].Rows.Count > 0)
            {
                dr = ds1.Tables[0].Rows[0];
                int ad=Convert.ToInt32(dr[0].ToString()); 
          
               
                
                d.con_open();
                SqlCommand cmd1 = new SqlCommand("ins_previous",d.con);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@adno",ad);
                cmd1.Parameters.AddWithValue("@rollno", Convert.ToInt32(dr[1].ToString()));
                cmd1.Parameters.AddWithValue("@cstandard", dr[2].ToString());
                cmd1.Parameters.AddWithValue("@classno",c);
                cmd1.Parameters.AddWithValue("@division",dr[4].ToString());
                cmd1.Parameters.AddWithValue("@year", dr[5].ToString());
                cmd1.ExecuteNonQuery();
                d.con_close();
                grid();

            }

        }
        private void delete()
        {
            d.con_open();
            string s3 = "DELETE FROM tbl_stddivision WHERE adno=" + c + "";
            SqlCommand cmd2 = new SqlCommand(s3, d.con);
            cmd2.ExecuteNonQuery();
            d.con_close();
            grid();

        }
        private void btntransfer_Click(object sender, EventArgs e)
        {
          if(valid()==true)
          {
            int i;      
            string s = "SELECT adno,rollno,cstandard,classno,division,currentyear FROM tbl_stddivision where currentyear=" +( Convert.ToInt32(cmbbox1.Text)-1) + "";
            SqlDataAdapter da = new SqlDataAdapter(s, d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];
                for (i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    dr = ds.Tables[0].Rows[i];
                    c = Convert.ToInt32(dr[0].ToString());

                    a = dr[2].ToString();
                    switch (a)
                    {
                        case "LKG":
                            b = "UKG";
                            exe();
                            break;
                        case "UKG":
                            b = "I";
                            exe();
                            break;
                        case "I":
                            b = "II";

                            exe();
                            break;

                        case "II":
                            b = "III";
                            exe();
                            break;
                        case "III":
                            b = "IV";
                            exe();
                            break;
                        case "IV":
                            b = "V";
                            exe();
                            break;
                        case "V":
                            b = "VI";
                            exe();
                            break;
                        case "VI":
                            b = "VII";
                            exe();
                            break;
                        case "VII":
                            b = "VIII";
                            exe();
                            break;
                        case "VIII":
                            b = "IX";
                            exe();
                            break;
                        case "IX":
                            b = "X";
                            exe();
                            break;
                        case "X":
                            b = "XI";
                            exe();
                            break;
                        case "XI":
                            b = "XII";
                            exe();
                            break;
                        case "XII":
                            b = "XII";
                            insprevious();
                            delete();
                            grid();
                            break;                           
                        default:
                            MessageBox.Show("INVALID ENTRY FOUND", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
                MessageBox.Show(" Successfully Completed", "Message.......", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            
            else
            {
                MessageBox.Show("Nothing to transfer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
          }
            else 
          {
             // MessageBox.Show("Please select Curent academic year", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }

        }

        private void cmbbox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Selected academic year is " + cmbbox1.Text + " -"+( Convert.ToInt32(cmbbox1.Text)+1)+",  Are you sure want to Continue......", "Message...", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        }

    }
}