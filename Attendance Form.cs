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
    public partial class Attendance_Form : Form
    {
        DataLayer d = new DataLayer();
        string Empno = "";
        SqlDataAdapter ad = new SqlDataAdapter();
        public Attendance_Form()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Attendance_Form_Load(object sender, EventArgs e)
        {
            d.con_open();
            SqlCommand cmd = new SqlCommand("sel_empname", d.con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {               
                cmbteacher.Items.Add(r[0].ToString());
            }
            d.con_close();
            
                

        }

        private void cmbteacher_SelectedIndexChanged(object sender, EventArgs e)
        {   
            //to select the empnum from table

            string s = "select Empno from teacherdet where EmpName ='" + cmbteacher.Text.Trim() + "'";
            SqlDataAdapter ad1 = new SqlDataAdapter(s, d.con);
            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);
            DataRow dr1;
            if (ds1.Tables[0].Rows.Count >= 1)
            {
                dr1 = ds1.Tables[0].Rows[0];
                Empno = dr1[0].ToString();
            }
            // to display the details in gridview

            string a = "SELECT stdiv.rollno [Roll No], s.adno as [Admission No], s.sname as [Student Name], s.sfname as [Father Name], s.cstandard as Standard,att.status as Status FROM  tbl_student AS s INNER JOIN tbl_stddivision AS stdiv ON s.adno = stdiv.adno INNER JOIN tbl_class AS cls ON stdiv.classno = cls.classno INNER JOIN tbl_attendance att  ON att.adno=s.adno and att.classno=cls.classno and  cls.classteacherno = '"+ Empno +"' ";
            SqlDataAdapter ad=new SqlDataAdapter(a, d.con);
            DataSet ds=new DataSet();
            ad.Fill(ds);
            dgvattendance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvattendance.AutoResizeColumns();
            dgvattendance.DataSource=ds.Tables[0];
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ad.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count;i++ )
            {
                
            }

        }
    }
}