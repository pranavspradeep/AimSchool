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
    public partial class Addteacher : DevComponents.DotNetBar.Office2007Form
    {
        DataLayer d = new DataLayer();
        string Empno = "";
        public Addteacher()
        {
            InitializeComponent();
        }

        public Boolean valid()
        {
            Boolean f = true;
            if (txtname.Text == "" || txtname.Text == null)
            {
                f = false;
                MessageBox.Show("Please enter name", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //else if (txtmb.Text == "" || txtmb.Text == null)
            //{
            //    f = false;
            //    MessageBox.Show("Please enter mobile number", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            else if (cmbsex.Text == "" || cmbsex.Text == null)
            {
                f = false;
                MessageBox.Show("Please enter Sex", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //else if (txtph.Text == "" || txtph.Text == null)
            //{
            //    f = false;
            //    MessageBox.Show("Please enter phone number", "Warning ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}

            else if (cmbsex.Text == "" || cmbsex.Text == null)
            {
                f = false;
                MessageBox.Show("Please enter Sex", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtqua.Text == "" || txtqua.Text == null)
            {
                f = false;
                MessageBox.Show("Please enter Qualification", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtsal.Text == "" || txtsal.Text == null)
            {
                f = false;
                MessageBox.Show("Please enter salary", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmb_type.Text == "" || cmb_type.Text == null)
            {
                f = false;
                MessageBox.Show("Please enter Status", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtaddrs.Text == "" || txtaddrs.Text == null)
            {
                f = false;
                MessageBox.Show("Please enter Address", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtem.Text == "" || txtem.Text == null)
            {
                f = false;
                MessageBox.Show("Please enter Email ID", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtUserName.Text == "" || txtUserName.Text == null)
            {
                f = false;
                MessageBox.Show("Please enter UserName", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtPassword.Text == "" || txtPassword.Text == null)
            {
                f = false;
                MessageBox.Show("Please enter Password", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return f;
        }





        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (valid() == true)
            {
                d.con_open();

                SqlCommand cmd = new SqlCommand("ins_teach", d.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpName", txtname.Text);
                cmd.Parameters.AddWithValue("@Qualification", txtqua.Text);
                cmd.Parameters.AddWithValue("@Phonenum", txtph.Text);
                cmd.Parameters.AddWithValue("@Emailid", txtem.Text);
                cmd.Parameters.AddWithValue("@Address", txtaddrs.Text);
                cmd.Parameters.AddWithValue("@DOB", DateTime.Parse(dtpdate.Text.ToString()).ToString("dd-MMM-yy"));
                cmd.Parameters.AddWithValue("@Mobnum", txtmb.Text);
                cmd.Parameters.AddWithValue("@DOJ", DateTime.Parse(dtpjoin.Text.ToString()).ToString("dd-MMM-yy"));
                cmd.Parameters.AddWithValue("@Sex", cmbsex.Text);
                cmd.Parameters.AddWithValue("@Salary", txtsal.Text);                
                cmd.Parameters.AddWithValue("@EmpType", cmb_type.Text);
                cmd.Parameters.AddWithValue("@Photo", "");
                cmd.Parameters.AddWithValue("@username", txtUserName.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Employee Added Successfully!", "Added..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtname.Focus();
                dgv_teacher.DataSource = null;

                //Display the saved details in datagridview

                SqlDataAdapter ad = new SqlDataAdapter("select Empno as [Employ Number],EmpName as [Employ Name],Qualification,Phonenum as [Phone Number],Emailid as [Email Id],Address,DOB,Mobnum as [Mobile Number],DOJ as [Date of Join],Sex,Salary,EmpType as [Employee Type],Status from teacherdet", d.con);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                dgv_teacher.DataSource = ds.Tables[0];
                
                txtname.Text = "";
                txtqua.Text = "";
                txtph.Text = "";
                txtem.Text = "";
                txtaddrs.Text = "";
                txtmb.Text = "";
                cmbsex.Text = "";
                txtsal.Text = "";
                cmb_type.Text = "";
                txtUserName.Text = "";
                txtPassword.Text = "";

                d.con_close();
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            txtname.Text = "";
            txtqua.Text = "";
            txtph.Text = "";
            txtem.Text = "";
            txtaddrs.Text = "";
            txtmb.Text = "";
            cmbsex.Text = "";
            txtsal.Text = "";
            cmb_type.Text = "";
        }

        private void Addteacher_Load(object sender, EventArgs e)
        {
            // Display Teachers details 

            SqlDataAdapter ad = new SqlDataAdapter("select Empno as [Employ Number],EmpName as [Employ Name],Qualification,Phonenum as [Phone Number],Emailid as [Email Id],Address,DOB,Mobnum as [Mobile Number],DOJ as [Date of Join] ,Sex,Salary,EmpType as [Employee Type],Status from teacherdet", d.con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            dgv_teacher.DataSource = ds.Tables[0];
        }

        private void dgv_teacher_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Empno = dgv_teacher.Rows[e.RowIndex].Cells[0].Value.ToString();

            SqlDataAdapter ad = new SqlDataAdapter("select EmpName,Qualification,Phonenum,Emailid,Address,DOB,Mobnum,DOJ,Sex,Salary,EmpType,Status from teacherdet where Empno='" + Empno + "'", d.con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dr = ds.Tables[0].Rows[0];
                txtname.Text = dr[0].ToString();
                txtqua.Text = dr[1].ToString();
                txtph.Text = dr[2].ToString();
                txtem.Text = dr[3].ToString();
                txtaddrs.Text = dr[4].ToString();
                dtpdate.Text = dr[5].ToString();
                txtmb.Text = dr[6].ToString();
                dtpjoin.Text = dr[7].ToString();
                cmbsex.SelectedText = dr[8].ToString();
                txtsal.Text = dr[9].ToString();
                cmb_type.SelectedItem = dr[10].ToString();
            }
            else
            {
                MessageBox.Show("Data does not exist", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            //if (valid() == true)
            //{
               d.con_open();

                SqlCommand cmd = new SqlCommand("edit_teacher", d.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Empno", Empno);
                cmd.Parameters.AddWithValue("@EmpName", txtname.Text);
                cmd.Parameters.AddWithValue("@Qualification", txtqua.Text);
                cmd.Parameters.AddWithValue("@Phonenum", txtph.Text);
                cmd.Parameters.AddWithValue("@Emailid", txtem.Text);
                cmd.Parameters.AddWithValue("@Address", txtaddrs.Text);
                cmd.Parameters.AddWithValue("@DOB", DateTime.Parse(dtpdate.Text.ToString()).ToString("dd-MMM-yy"));
                cmd.Parameters.AddWithValue("@Mobnum", txtmb.Text);
                cmd.Parameters.AddWithValue("@DOJ", DateTime.Parse(dtpjoin.Text.ToString()).ToString("dd-MMM-yy"));
                cmd.Parameters.AddWithValue("@Sex", cmbsex.Text);
                cmd.Parameters.AddWithValue("@Salary", txtsal.Text);
                cmd.Parameters.AddWithValue("@Photo", "");
                cmd.Parameters.AddWithValue("@EmpType", cmb_type.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data edited successfully", "Edited..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtname.Text = "";
                txtqua.Text = "";
                txtph.Text = "";
                txtem.Text = "";
                txtaddrs.Text = "";
                txtmb.Text = "";
                cmbsex.Text = "";
                txtsal.Text = "";
                cmb_type.Text = "";

                d.con_close();

                // Display the edited teachers details in datagridview

                SqlDataAdapter ad = new SqlDataAdapter("select Empno as [Employ Number],EmpName as [Employ Name],Qualification,Phonenum as [Phone Number],Emailid as [Email Id],Address,DOB,Mobnum as [Mobile Number],DOJ as [Date of Join],Sex,Salary,Status from teacherdet", d.con);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                dgv_teacher.DataSource = ds.Tables[0];
            }
        

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }     

        private void txtph_KeyPress(object sender, KeyPressEventArgs e)
        {
            AimSValidator.NumberChecker(e);
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtmb_KeyPress(object sender, KeyPressEventArgs e)
        {
            AimSValidator.NumberChecker(e);
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtsal_KeyPress(object sender, KeyPressEventArgs e)
        {
            AimSValidator.AmountChecker(sender, e);
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void dtpdate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cmbsex_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtqua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void dtpjoin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cmb_type_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtaddrs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtaddrs.Text == null || txtaddrs.Text == "")
            {
                if (e.KeyChar == (char)13)
                {
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }
            }
        }
    }
}