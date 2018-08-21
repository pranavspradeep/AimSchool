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
    public partial class stddivision : Form
    {
        DataLayer d = new DataLayer();
        string adno = "";
        int rollno;
        string   std="";
        string  r="";
       int classno;
        string c = "";
        public stddivision()
        {
            InitializeComponent();
        }

        private void stddivision_Load(object sender, EventArgs e)
        {
            SqlDataAdapter ad = new SqlDataAdapter("select s.adno as [Admission No],s.sname as Name,s.cstandard as Standard,c.division as Division from tbl_student s INNER JOIN  tbl_stddivision c ON s.adno=c.adno",d.con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            dgvstddiv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvstddiv.AutoResizeColumns();
            dgvstddiv.DataSource = ds.Tables[0];

        }
        private void cmbstd_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Display student details according to the standard

            string s = "SELECT DISTINCT s.adno AS [Admission No],s.sname AS Name, s.cstandard AS Standard, p.division AS Division FROM tbl_student AS s LEFT OUTER JOIN  tbl_stddivision AS p ON s.adno = p.adno WHERE s.cstandard ='" + cmbstd.Text + "'";
            SqlDataAdapter ad = new SqlDataAdapter(s, d.con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            dgvstddiv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvstddiv.AutoResizeColumns();
            dgvstddiv.DataSource = ds.Tables[0];
         
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            // select maximum rollnum from database

            SqlDataAdapter ad = new SqlDataAdapter("select isnull(Max(rollno),0) from tbl_stddivision", d.con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            DataRow dr1;
            rollno = 0;
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dr1 = ds.Tables[0].Rows[0];
                r = dr1[0].ToString();
                rollno = int.Parse(r.ToString()) + 1;
            }

            // select classno from database according to the standard & division

            string s4="select classno from tbl_class where cstandard='" + cmbstd.Text + "' and division='" + cmbdiv.Text + "'";
            SqlDataAdapter ad2 = new SqlDataAdapter(s4,d.con);
            DataSet ds2 = new DataSet();
            ad2.Fill(ds2);
            DataRow dr2;
            if (ds2.Tables[0].Rows.Count >= 1)
            {
                dr2 = ds2.Tables[0].Rows[0];
                c = dr2[0].ToString();
                classno = int.Parse(c.ToString());              

            }


            //select standard from database
            SqlDataAdapter ad4 = new SqlDataAdapter("select cstandard from tbl_stddivision where cstandard='" + cmbstd.Text + "'", d.con);
            DataSet ds4 = new DataSet();
            ad4.Fill(ds4);
            DataRow dr4;
            if (ds4.Tables[0].Rows.Count >= 1)
            {
                dr4 = ds4.Tables[0].Rows[0];
                std = dr4[0].ToString();
                //cstandard = Convert.ToInt32(std.ToString()) + 1;
                //cstandard = int.Parse(std.ToString()) + 1;
            }

            // standard and division already exists 


            string p = "select adno,cstandard,division  from tbl_stddivision where adno='" + adno + "' AND division= '"+cmbdiv.Text +"'"; 
            SqlDataAdapter da1 = new SqlDataAdapter(p, d.con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            if (ds1.Tables[0].Rows.Count >= 1)
            {
                MessageBox.Show("student standard and division already Exist", "Saved..", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {



                if (cmbstd.Text == "" || cmbstd.Text == null)
                {
                    MessageBox.Show("Please select Standard", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

                else if (cmbdiv.Text == "" || cmbdiv.Text == null)
                {
                    MessageBox.Show("Please select Division", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else if (adno == "" || adno == null)
                {
                    MessageBox.Show("Select student from gridview", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    SqlDataAdapter da10 = new SqlDataAdapter("Select adno from tbl_stddivision where adno='" + adno + "'", d.con);
                    DataSet ds10 = new DataSet();
                    da10.Fill(ds10);
                    if (ds10.Tables[0].Rows.Count > 0)
                    {
                        d.con_open();
                        SqlCommand cmd3 = new SqlCommand("Update tbl_stddivision set division='" + cmbdiv.Text + "' where adno='" + adno + "'",d.con);
                        cmd3.ExecuteNonQuery();
                        d.con_close();
                    }
                    else
                    {
                        d.con_open();
                        SqlCommand cmd1 = new SqlCommand("ins_stddivision", d.con);
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.AddWithValue("@adno", adno);
                        cmd1.Parameters.AddWithValue("@rollno", rollno);
                        cmd1.Parameters.AddWithValue("@cstandard", cmbstd.Text);
                        cmd1.Parameters.AddWithValue("@classno", classno);
                        cmd1.Parameters.AddWithValue("@division", cmbdiv.Text);
                        cmd1.ExecuteNonQuery();
                        d.con_close();
                    }
                    MessageBox.Show("Student moved to the division", "Moved..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbdiv.Text = "";
                    cmbstd.Text = "";
                    dgvstddiv.DataSource = null;

                    string s = "select distinct s.adno as [Admission No],s.sname as Name,s.cstandard as Standard,p.division AS Division from tbl_student AS s RIGHT OUTER JOIN tbl_stddivision AS p on s.adno not in(select adno from tbl_stddivision )";
                    // string s = "select s.adno,s.sname,s.cstandard,c.division from tbl_student s INNER JOIN  tbl_stddivision c ON s.adno=c.adno";
                    SqlDataAdapter ad3 = new SqlDataAdapter(s, d.con);
                    DataSet ds3 = new DataSet();
                    ad3.Fill(ds3);
                    dgvstddiv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvstddiv.AutoResizeColumns();
                    dgvstddiv.DataSource = ds3.Tables[0];
                }
            }
        }

        private void dgvstddiv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           adno = dgvstddiv.Rows[e.RowIndex].Cells[0].Value.ToString();
        //    string s = "select cstandard from tbl_student where adno='" + adno + "'";

        //    SqlDataAdapter ad = new SqlDataAdapter(s, d.con);
        //    DataSet ds = new DataSet();
        //    ad.Fill(ds);
        //    DataRow dr;
        //    if (ds.Tables[0].Rows.Count >= 1)
        //    {
        //        dr = ds.Tables[0].Rows[0];
        //        cmbstd.Text = dr[0].ToString();
        //        dgvstddiv.DataSource = ds.Tables[0];


        //    }
        //    else
        //    {
        //        SchoolManagement.adno = adno;
        //    }
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            cmbdiv.Text = "";
            cmbstd.Text = "";
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cmbdiv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvstddiv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

       
    }
}