using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SchoolManagement
{
    public partial class Student_Promotion : Form
    {
        DataLayer d = new DataLayer();
        string std;
        public Student_Promotion()
        {
            InitializeComponent();
        }
        public Boolean valid()
        {
            Boolean b = true;
            if (cmb_Standard.Text == "" || cmb_Standard.Text == null)
            {
                b = false;
                MessageBox.Show("Select Standard!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmb_Div.Text == "" || cmb_Div.Text == null)
            {
                b = false;
                MessageBox.Show("Select Division!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return b;
        }
        public void Students_list()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT tbl_stddivision.adno as [Admission No], tbl_student.sname as [Student Name], tbl_stddivision.cstandard as Standard, tbl_stddivision.division as Division FROM tbl_stddivision INNER JOIN tbl_student ON tbl_stddivision.adno = tbl_student.adno where tbl_stddivision.cstandard='" + cmb_Standard.Text + "' And tbl_stddivision.division='" + cmb_Div.Text + "' ORDER BY tbl_student.sname ASC", d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dr = ds.Tables[0].Rows[i];
                    lstbx_Students.Items.Add(dr[1].ToString());                    
                }
            }
        }
        private void btn_Srch_Click(object sender, EventArgs e)
        {
            lstbx_Students.Items.Clear();
            if (valid() == true)
            {
                Students_list();
            }
        }

        private void cmb_Standard_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cmb_Div_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }       
        public void standard()
        {
            if(cmb_Standard.Text == "LKG")
            {
                std = "UKG";
            }
            else if(cmb_Standard.Text == "UKG")
            {
                std = "I";
            }
            else if(cmb_Standard.Text == "I")
            {
                std = "II";
            }
            else if(cmb_Standard.Text == "II")
            {
                std = "III";
            }
            else if(cmb_Standard.Text == "III")
            {
                std = "IV";
            }
            else if(cmb_Standard.Text == "IV")
            {
                std = "V";
            }
            else if(cmb_Standard.Text == "V")
            {
                std = "VI";
            }
            else if(cmb_Standard.Text == "VI")
            {
                std = "VII";
            }
            else if(cmb_Standard.Text == "VII")
            {
                std = "VIII";
            }
            else if(cmb_Standard.Text == "VIII")
            {
                std = "IX";
            }
            else if(cmb_Standard.Text == "IX")
            {
                std = "X";
            }
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you sure to promote selected student(s) to next class?", "warning..", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                try
                {
                    standard();
                    d.con_open();
                    for (int i = 0; i < lstbx_Students.SelectedItems.Count; i++)
                    {
                        string studt = lstbx_Students.SelectedItems[i].ToString();
                        string s = "SELECT tbl_student.adno FROM tbl_stddivision INNER JOIN tbl_student ON tbl_stddivision.adno = tbl_student.adno where tbl_stddivision.cstandard='" + cmb_Standard.Text + "' and tbl_stddivision.division='" + cmb_Div.Text + "' And tbl_student.sname='" + studt + "'";
                        SqlDataAdapter da = new SqlDataAdapter(s, d.con);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        DataRow dr;
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            dr = ds.Tables[0].Rows[0];
                            string adno = dr[0].ToString();
                            SqlCommand cmd = new SqlCommand("Update tbl_stddivision set cstandard='" + std + "' where adno='" + adno + "'", d.con);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    d.con_close();
                    MessageBox.Show("Selected Student(s) promoted Successfully!");
                    lstbx_Students.Items.Clear();
                    Students_list();
                }
                catch
                {
                }
            }
        }

        private void lstbx_Students_KeyPress(object sender, KeyPressEventArgs e)
        {            
            if (Char.IsControl(e.KeyChar) && e.KeyChar == ((char)Keys.A & (char)Keys.ControlKey))
            {
                for (int i = 0; i < lstbx_Students.Items.Count; i++)
                {
                    lstbx_Students.SetSelected(i, true);
                }
            }
        }

        private void btn_canselection_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstbx_Students.Items.Count; i++)
            {
                lstbx_Students.SetSelected(i, false);
            }
        }

        private void txt_Searchstud_TextChanged(object sender, EventArgs e)
        {
            lstbx_Students.Items.Clear();
            SqlDataAdapter da = new SqlDataAdapter("SELECT tbl_stddivision.adno as [Admission No], tbl_student.sname as [Student Name], tbl_stddivision.cstandard as Standard, tbl_stddivision.division as Division FROM tbl_stddivision INNER JOIN tbl_student ON tbl_stddivision.adno = tbl_student.adno where tbl_stddivision.cstandard='" + cmb_Standard.Text + "' And tbl_stddivision.division='" + cmb_Div.Text + "' And tbl_student.sname LIKE '" + txt_Searchstud.Text + "%' ORDER BY tbl_student.sname ASC", d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dr = ds.Tables[0].Rows[i];
                    lstbx_Students.Items.Add(dr[1].ToString());
                }
            }
        }

        private void txt_Searchstud_Enter(object sender, EventArgs e)
        {
            if (valid() == false)
            {
                cmb_Standard.Focus();
            }
        }        
                
    }
}
