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
    public partial class Parentdetails : Form
    {
        DataLayer d = new DataLayer();
        public Parentdetails()
        {
            InitializeComponent();
        }

        private void Parentdetails_Load(object sender, EventArgs e)
        {
            txtfirstname.Focus();
            //select the student details from table

            SqlDataAdapter ad = new SqlDataAdapter("select s.sname,s.cstandard ,s.address ,s.sex,d.division from tbl_student s inner join tbl_stddivision d on s.adno=d.adno where s.adno='" + SchoolManagement.rno + "'", d.con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dr = ds.Tables[0].Rows[0];
                txtsname.Text = dr[0].ToString();
                txtstd.Text = dr[1].ToString();
                txtadrs.Text = dr[2].ToString();
                txtsex.Text = dr[3].ToString();
                txtdiv.Text = dr[4].ToString();
                
            }
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {


        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            SqlDataAdapter ad = new SqlDataAdapter("select adno from tbl_parentdet where adno='"+SchoolManagement.rno+"'",d.con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            //DataRow dr;
            if (ds.Tables[0].Rows.Count >= 1)
            {
                MessageBox.Show("Parent details already added","warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                d.con_open();
                SqlCommand cmd = new SqlCommand("ins_parentdet", d.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@firstname", txtfirstname.Text);
                cmd.Parameters.AddWithValue("@lastname", txtlstname.Text);
                cmd.Parameters.AddWithValue("@relation", cmbrelat.Text);
                cmd.Parameters.AddWithValue("@landnum", txtlnum.Text);
                cmd.Parameters.AddWithValue("@mobnum", txtmnum.Text);
                cmd.Parameters.AddWithValue("@mail", txtmail.Text);
                cmd.Parameters.AddWithValue("@username", txtuser.Text);
                cmd.Parameters.AddWithValue("@password", txtpaswd.Text);
                cmd.Parameters.AddWithValue("@adno", SchoolManagement.rno);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Parent details added", "added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                d.con_close();
               
            }

            txtfirstname.Text = "";
            txtlstname.Text = "";
            cmbrelat.Text = "";
            txtlnum.Text = "";
            txtmnum.Text = "";
            txtmail.Text = "";
            txtuser.Text = "";
            txtpaswd.Text = "";

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            txtfirstname.Text = "";
            txtlstname.Text = "";
            cmbrelat.Text = "";
            txtlnum.Text = "";
            txtmnum.Text = "";
            txtmail.Text = "";
            txtuser.Text = "";
            txtpaswd.Text = "";
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}