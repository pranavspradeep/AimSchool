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
    public partial class teachviewstd : Form
    {
        DataLayer d=new DataLayer();
        public teachviewstd()
        {
            InitializeComponent();
        }

        private void btn_view_Click(object sender, EventArgs e)
        {
            string s="SELECT s.adno, st.rollno, s.sname, s.address FROM tbl_student AS s INNER JOIN tbl_stddivision AS st ON s.adno = st.adno INNER JOIN tbl_class AS c ON st.classno = c.classno INNER JOIN teacherdet AS t ON t.Empno = c.classteacherno WHERE t.Empno ='"+ SchoolManagement.empno +"'";
            SqlDataAdapter ad= new SqlDataAdapter(s,d.con);
            DataSet ds=new DataSet();
            ad.Fill(ds);
            DataRow dr;
            if(ds.Tables[0].Rows.Count>=1)
            {
                dr = ds.Tables[0].Rows[0]; 
                dgv_list.DataSource = ds.Tables[0]; 
            }
            
        }

        private void dgv_list_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_list_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void teachviewstd_Load(object sender, EventArgs e)
        {

        }
    }
}