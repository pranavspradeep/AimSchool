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
    public partial class frmaccountdetails : Form
    {
        DataLayer d = new DataLayer();
        public frmaccountdetails()
        {
            InitializeComponent();
        }

        private void btnshow_Click(object sender, EventArgs e)
        {
            if (dtp1.Value <= dtp2.Value)
            {

                string s = "SELECT  t.Admno AS [Admission No], s.sname AS Name,st.cstandard AS Standard, st.division AS Division, t.Type ,t.Ammount, t.Fine, t.Ammount + t.Fine AS Total , t.Todate AS Date FROM   tbl_TempAccount AS t INNER JOIN tbl_student AS s ON t.Admno = s.adno INNER JOIN  tbl_stddivision AS st ON s.adno = st.adno WHERE t.Todate >='" + dtp1.Value + "'AND t.Todate <='" + dtp2.Value + "'ORDER BY t.Todate DESC ";
                SqlDataAdapter da = new SqlDataAdapter(s,d.con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count >= 1) 
                {
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    MessageBox.Show("NoTransaction Avialable between these two date", "Warning....", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("To date shoul be greater than that of from date", "Warning....", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
          
               
               SchoolManagement.dtp1 = Convert.ToString(dtp1.Value);
               SchoolManagement.dtp2 = Convert.ToString(dtp2.Value);
               formaccouncrstl fac = new formaccouncrstl();
               fac.Show();            
            
      
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void frmaccountdetails_Load(object sender, EventArgs e)
        {

            string s = "SELECT  t.Admno AS [Admission No], s.sname AS Name,st.cstandard AS Standard, st.division AS Division, t.Type ,t.Ammount, t.Fine, t.Ammount + t.Fine AS Total , t.Todate AS Date FROM   tbl_TempAccount AS t INNER JOIN tbl_student AS s ON t.Admno = s.adno INNER JOIN  tbl_stddivision AS st ON s.adno = st.adno ORDER BY t.Todate DESC ";
            SqlDataAdapter da = new SqlDataAdapter(s, d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
        }
    }
}
