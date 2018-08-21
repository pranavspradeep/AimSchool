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
    public partial class NewStudent : DevComponents.DotNetBar.Office2007Form
    {
        DataLayer d = new DataLayer();
        public NewStudent()
        {
            InitializeComponent();
        }
        public Boolean valid()
        {
            Boolean f = true;
            if (txtname.Text == "" || txtname.Text == null)
            {
                f = false;
                MessageBox.Show("Please enter name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbsex.Text == "" || cmbsex.Text == null)
            {
                f = false;
                MessageBox.Show("Please enter sex", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (dtpDOB.Text == "" || dtpDOB.Text == null)
            {
                f = false;
                MessageBox.Show("Please enter date of birth", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //else if (txtrgon.Text == "" || txtrgon.Text == null)
            //{
            //    f = false;
            //    MessageBox.Show("Please enter religion", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            else if (txtnatnalty.Text == "" || txtnatnalty.Text == null)
            {
                f = false;
                MessageBox.Show("Please enter nationality", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbsyll.Text == "" || cmbsyll.Text == null)
            {
                f = false;
                MessageBox.Show("Please enter syllabus", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtaddrs.Text == "" || txtaddrs.Text == null)
            {
                f = false;
                MessageBox.Show("Please enter address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtfname.Text == "" || txtfname.Text == null)
            {
                f = false;
                MessageBox.Show("Please enter father's name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txt_Adno.Text == "" || txt_Adno.Text == null)
            {
                f = false;
                MessageBox.Show("Please enter Admission Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //else if (txtMname.Text == "" || txtMname.Text == null)
            //{
            //    f = false;
            //    MessageBox.Show("Please enter mother's name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else if (txtmail.Text == "" || txtmail.Text == null)
            //{
            //    f = false;
            //    MessageBox.Show("Please enter E-mail", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else if (txtphno.Text == "" || txtphno.Text == null)
            //{
            //    f = false;
            //    MessageBox.Show("Please enter landphone number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else if (txtmno.Text == "" || txtmno.Text == null)
            //{
            //    f = false;
            //    MessageBox.Show("Please enter mobile number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}

            //else if (txtocpton.Text == "" || txtocpton.Text == null)
            //{
            //    f = false;
            //    MessageBox.Show("Please enter occupation", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}

            //else if (txtpresc.Text == "" || txtpresc.Text == null)
            //{
            //    f = false;
            //    MessageBox.Show("Please enter previous school", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else if (cmbpstd.Text == "" || cmbpstd.Text == null)
            //{
            //    f = false;
            //    MessageBox.Show("Please enter standard", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else if (dtpofadmin.Text == "" || dtpofadmin.Text == null)
            //{
            //    f = false;
            //    MessageBox.Show("Please enter date of admission", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else if (txttcno.Text == "" || txttcno.Text == null)
            //{
            //    f = false;
            //    MessageBox.Show("Please enter T.C Number & Date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}

            //else if (txtrem.Text == "" || txtrem.Text == null)
            //{
            //    f = false;
            //    MessageBox.Show("Please enter remarks", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            else if (cmbcstd.Text == "" || cmbcstd.Text == null)
            {
                f = false;
                MessageBox.Show("Please enter current standard", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //else if (dtpdoflve.Text == "" || dtpdoflve.Text == null)
            //{
            //    f = false;
            //    MessageBox.Show("Please enter date of leave", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            return f;
        }


        private void btn_Add_Click(object sender, EventArgs e)
        {
           
           
            if(valid()==true)
            {

                d.con_open();
                SqlCommand cmd = new SqlCommand("ins_stud", d.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@adno", txt_Adno.Text);
                cmd.Parameters.AddWithValue("@sname", txtname.Text);
                cmd.Parameters.AddWithValue("@sfname", txtfname.Text);
                cmd.Parameters.AddWithValue("@pnum", txtphno.Text);
                cmd.Parameters.AddWithValue("@email", txtmail.Text);
                cmd.Parameters.AddWithValue("@religion", cmb_Religion.Text);
                cmd.Parameters.AddWithValue("@caste", txt_caste.Text);
                cmd.Parameters.AddWithValue("@occupation", txtocpton.Text);
                cmd.Parameters.AddWithValue("@nation", txtnatnalty.Text);
                cmd.Parameters.AddWithValue("@sex", cmbsex.Text);
                cmd.Parameters.AddWithValue("@dob",DateTime.Parse(dtpDOB.Text.ToString()).ToString("dd-MMM-yy"));
                cmd.Parameters.AddWithValue("@smname", txtMname.Text);
                cmd.Parameters.AddWithValue("@mnum", txtmno.Text);
                cmd.Parameters.AddWithValue("@address", txtaddrs.Text);
                cmd.Parameters.AddWithValue("@photo", "");
                cmd.Parameters.AddWithValue("@preschool", txtpresc.Text);
                cmd.Parameters.AddWithValue("@standard", cmbpstd.Text);
                cmd.Parameters.AddWithValue("@dofleave", DateTime.Parse(dtpdoflve.Text.ToString()).ToString("dd-MMM-yy"));
                cmd.Parameters.AddWithValue("@tcnodate", txttcno.Text);
                cmd.Parameters.AddWithValue("@remarks", txtrem.Text);
                cmd.Parameters.AddWithValue("@cstandard", cmbcstd.Text);
                cmd.Parameters.AddWithValue("@dofadmin", DateTime.Parse(dtpofadmin.Text.ToString()).ToString("dd-MMM-yy"));
                cmd.Parameters.AddWithValue("@Newsyll", cmbsyll.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Data Saved successfully", "Saved..", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtname.Text = "";
                txtfname.Text = "";
                txtphno.Text = "";
                txtmail.Text = "";
                cmb_Religion.Text = "";
                txtocpton.Text = "";
                txtnatnalty.Text = "";
                cmbsex.Text = "";
                dtpDOB.Text = "";
                txtMname.Text = "";
                txtmno.Text = "";
                txtaddrs.Text = "";
                txtpresc.Text = "";
                cmbpstd.Text = "";
                dtpofadmin.Text = "";
                txttcno.Text = "";
                txtrem.Text = "";
                cmbcstd.Text = "";
                dtpofadmin.Text = "";
                cmbsyll.Text = "";
                d.con_close();
            }

        }

        private void NewStudent_Load(object sender, EventArgs e)
        {
            d.con_open();
            SqlCommand cmd = new SqlCommand("sel_syllabus", d.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmbsyll.Items.Clear();
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                cmbsyll.Items.Add(r[0].ToString());
            }
            d.con_close();
            cmbpstd.Text = "";
            cmbcstd.Text = "";
            cmbsex.Text = "";
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            txtname.Text = "";
            txtfname.Text = "";
            txtMname.Text = "";
            txtmno.Text = "";
            txtnatnalty.Text = "";
            txtocpton.Text = "";
            txtphno.Text = "";
            txtpresc.Text = "";
            txtrem.Text = "";
            cmb_Religion.Text = "";
            txttcno.Text = "";
            cmbcstd.Text = "";
            cmbpstd.Text = "";
            cmbsex.Text = "";
            cmbsyll.Text = "";
            txtmail.Text = "";
            txtaddrs.Text = "";
            
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txt_Adno_Leave(object sender, EventArgs e)
        {
            String s = "Select adno from tbl_student where adno='" + txt_Adno.Text + "'";
            SqlDataAdapter da10 = new SqlDataAdapter(s, d.con);
            DataSet ds10 = new DataSet();
            da10.Fill(ds10);
            if (ds10.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("Admission No Already Exist....", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Adno.Text = "";
            }
        }

        private void txtmno_KeyPress(object sender, KeyPressEventArgs e)
        {
            AimSValidator.NumberChecker(e);
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtphno_KeyPress(object sender, KeyPressEventArgs e)
        {
            AimSValidator.NumberChecker(e);
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void lnklbl_religionadd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            groupBox1.Visible = true;

            
        }

        private void btn_Cncl_Click(object sender, EventArgs e)
        {
            txtrelgn.Text = "";
            groupBox1.Visible = false;
        }

        private void txtname_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dtpDOB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cmb_Religion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtnatnalty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txt_caste_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cmbsyll_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtfname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtMname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtocpton_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtaddrs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtaddrs.Text == "" || txtaddrs.Text == null)
            {
                if (e.KeyChar == (char)13)
                {
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }
            }
        }

        private void txtrelgn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtpresc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cmbpstd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void dtpdoflve_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtrem_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (txtrem.Text == "" || txtrem.Text == null)
            {
                if (e.KeyChar == (char)13)
                {
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }
            }
        }

        private void cmbcstd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void dtpofadmin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txt_Adno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        

    }
}

    
    
