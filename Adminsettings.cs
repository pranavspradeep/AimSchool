using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace SchoolManagement
{
    public partial class Adminsettings : Form
    {
        DataLayer d = new DataLayer();
        string userid;        
        public Adminsettings()
        {
            InitializeComponent();
        }
        public void employee()
        {
            d.con_open();
            SqlCommand cmd = new SqlCommand("sel_empname", d.con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {

                cmb_User.Items.Add(r[0].ToString());
            }
            d.con_close();
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (valid() == true)
            {
                d.con_open();
                SqlCommand cmd = new SqlCommand("ins_user", d.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empno", SchoolManagement.empnoad);
                cmd.Parameters.AddWithValue("@privilage", cmbPrivilage.Text);
                cmd.Parameters.AddWithValue("@sts", "1");
                cmd.ExecuteNonQuery();
                d.con_close();

                if (ckb1.Checked == true)
                {
                    frmprv(userid.ToString(), "1");
                }
                if (ckb2.Checked == true)
                {
                    frmprv(userid.ToString(), "2");
                }
                if (ckb3.Checked == true)
                {
                    frmprv(userid.ToString(), "3");
                }
                if (ckb4.Checked == true)
                {
                    frmprv(userid.ToString(), "4");
                }
                if (ckb5.Checked == true)
                {
                    frmprv(userid.ToString(), "5");
                }
                if (ckb6.Checked == true)
                {
                    frmprv(userid.ToString(), "6");
                }
                if (ckb7.Checked == true)
                {
                    frmprv(userid.ToString(), "7");
                }
                if (ckb8.Checked == true)
                {
                    frmprv(userid.ToString(), "8");
                }
                if (ckb9.Checked == true)
                {
                    frmprv(userid.ToString(), "9");
                }
                if (ckb10.Checked == true)
                {
                    frmprv(userid.ToString(), "10");
                }
                if (ckb11.Checked == true)
                {
                    frmprv(userid.ToString(), "11");
                }
                if (ckb12.Checked == true)
                {
                    frmprv(userid.ToString(), "12");
                }
                if (ckb13.Checked == true)
                {
                    frmprv(userid.ToString(), "13");
                }
                if (ckb14.Checked == true)
                {
                    frmprv(userid.ToString(), "14");
                }
                //if (ckb11.Checked == true)
                //{
                //    frmprv(userid.ToString(), "15");
                //}
                if (cmbPrivilage.Text != "" || cmbPrivilage.Text != null)
                {
                    MessageBox.Show("" + cmbPrivilage.Text + " Settings saved successfully", "Saved..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                cmb_User.Text = "";
                txtpassword.Text = "";
                cmbPrivilage.Text = "";
            }

        }
        private void frmprv(string userid, string fno)
        {
            d.con_open();
            SqlCommand cmd = new SqlCommand("ins_Privilege", d.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UsrNo", SchoolManagement.empnoad);
            cmd.Parameters.AddWithValue("@FrmNo", fno);
            cmd.ExecuteNonQuery();
            d.con_close();
        }


        private Boolean valid()
        {
            Boolean f = true;
            if (cmb_User.Text == "" || cmb_User.Text == null)
            {
                f = false;
                MessageBox.Show("Username Should not be blank", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtpassword.Text == "" || txtpassword == null)
            {
                f = false;
                MessageBox.Show("Password Should not be blank", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbPrivilage.Text == "" || cmbPrivilage.Text == null)
            {
                f = false;
                MessageBox.Show("Privilege Should not be blank", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (ckb1.Checked == false && ckb2.Checked == false && ckb3.Checked == false && ckb4.Checked == false && ckb5.Checked == false && ckb6.Checked == false && ckb7.Checked == false &&
            ckb8.Checked == false && ckb9.Checked == false && ckb10.Checked == false && ckb11.Checked == false && ckb12.Checked == false && ckb13.Checked == false && ckb14.Checked == false)
            {
                f = false;
                MessageBox.Show("Plese select atleast one user permision", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }             
            return f;
        }
        private void ckb1_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void ckb20_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb20.Checked == true)
            {
                ckb1.Checked = true;
                ckb2.Checked = true;
                ckb3.Checked = true;
                ckb4.Checked = true;
                ckb6.Checked = true;
                ckb5.Checked = true;
                ckb7.Checked = true;
                ckb8.Checked = true;
                ckb9.Checked = true;
                ckb10.Checked = true;
                ckb11.Checked = true;
                ckb12.Checked = true;
                ckb13.Checked = true;
                ckb14.Checked = true;              

            }

            else
            {
                ckb1.Checked = false;
                ckb2.Checked = false;
                ckb3.Checked = false;
                ckb4.Checked = false;
                ckb6.Checked = false;
                ckb5.Checked = false;
                ckb7.Checked = false;
                ckb8.Checked = false;
                ckb9.Checked = false;
                ckb10.Checked = false;
                ckb11.Checked = false;
                ckb12.Checked = true;
                ckb13.Checked = true;
                ckb14.Checked = true;
            }

        }

        private void Adminsettings_Load(object sender, EventArgs e)
        {
            employee();
        }

        private void ckb7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cmb_User_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select Empno,username,password from teacherdet where EmpName='" + cmb_User.Text + "'", d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];
                txtusername.Text = dr[1].ToString();
                txtpassword.Text = dr[2].ToString();
                SchoolManagement.empnoad = dr[0].ToString();
                userid = SchoolManagement.empnoad;
            }
        }
    }
}
