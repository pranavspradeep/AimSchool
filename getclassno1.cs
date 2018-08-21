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
    public partial class getclassno1 : Form
    {
        DataLayer d = new DataLayer();
        public getclassno1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void getclassno1_Load(object sender, EventArgs e)
        {
            string s = " select b.adno from tbl_class a inner join tbl_student b on  classteacherno= '" + SchoolManagement.empno + "'";
            SqlDataAdapter da = new SqlDataAdapter(s, d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count > 1)
            {
                dr = ds.Tables[0].Rows[0];
                SchoolManagement.adno = dr[1].ToString();
                dgv1.DataSource = ds.Tables[0];


            }
        }


    }
}