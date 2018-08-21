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
    public partial class Edit_teacher : DevComponents.DotNetBar.Office2007Form
    {
        DataLayer d = new DataLayer();
        string Empno = "";
        public Edit_teacher()
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
            else if (dtpdob.Text == "" || dtpdob.Text == null)
            {
                f = false;
                MessageBox.Show("Please enter Date Of Birth", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbsex.Text == "" || cmbsex.Text == null)
            {
                f = false;
                MessageBox.Show("Please enter sex", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtpnum.Text == "" || txtpnum.Text == null)
            {
                f = false;
                MessageBox.Show("Please enter Phone Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtmnum.Text == "" || txtmnum.Text == null)
            {
                f = false;
                MessageBox.Show("Please enter Mobile Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtmail.Text == "" || txtmail.Text == null)
            {
                f = false;
                MessageBox.Show("Please enter Mail ID", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtqual.Text == "" || txtqual.Text == null)
            {
                f = false;
                MessageBox.Show("Please enter Qualification", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (dtpjoin.Text == "" || dtpjoin.Text == null)
            {
                f = false;
                MessageBox.Show("Please enter Date Of Joining", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtsalary.Text == "" || txtsalary.Text == null)
            {
                f = false;
                MessageBox.Show("Please enter Salary", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmb_type.Text == "" || cmb_type.Text == null)
            {
                f = false;
                MessageBox.Show("Please Select Employee Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtaddrs.Text == "" || txtaddrs.Text == null)
            {
                f = false;
                MessageBox.Show("Please enter Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
            return f;
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void Edit_teacher_Load(object sender, EventArgs e)
        {
            d.con_open();
            SqlDataAdapter da11 = new SqlDataAdapter("select EmpName,Qualification,Phonenum,Emailid,Address,DOB,Mobnum,DOJ,Sex,Salary,EmpType from teacherdet where Empno='" + SchoolManagement.empno + "'", d.con);
            DataSet ds11 = new DataSet();
            da11.Fill(ds11);
            DataRow dr11;
            if (ds11.Tables[0].Rows.Count >= 1)
            {
                dr11 = ds11.Tables[0].Rows[0];
                txtname.Text = dr11[0].ToString();
                txtqual.Text = dr11[1].ToString();
                txtpnum.Text = dr11[2].ToString();
                txtmail.Text = dr11[3].ToString();
                txtaddrs.Text = dr11[4].ToString();
                dtpdob.Text = dr11[5].ToString();
                txtmnum.Text = dr11[6].ToString();
                dtpjoin.Text = dr11[7].ToString();
                cmbsex.Text = dr11[8].ToString();
                cmb_type.Text = dr11[10].ToString();
                txtsalary.Text = dr11[9].ToString();
            }


            d.con_close();
               

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (valid() == true)
            {
                d.con_open();

                SqlCommand cmd = new SqlCommand("edit_teacher", d.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Empno", SchoolManagement.empno);
                cmd.Parameters.AddWithValue("@EmpName", txtname.Text);
                cmd.Parameters.AddWithValue("@Qualification", txtqual.Text);
                cmd.Parameters.AddWithValue("@Phonenum", txtpnum.Text);
                cmd.Parameters.AddWithValue("@Emailid", txtmail.Text);
                cmd.Parameters.AddWithValue("@Address", txtaddrs.Text);
                cmd.Parameters.AddWithValue("@DOB", DateTime.Parse(dtpdob.Text.ToString()).ToString("dd-MMM-yy"));
                cmd.Parameters.AddWithValue("@Mobnum", txtmnum.Text);
                cmd.Parameters.AddWithValue("@DOJ ", DateTime.Parse(dtpjoin.Text.ToString()).ToString("dd-MMM-yy"));
                cmd.Parameters.AddWithValue("@Sex ", cmbsex.Text);
                cmd.Parameters.AddWithValue("@Salary ", txtsalary.Text);
                cmd.Parameters.AddWithValue("@Photo", "");
                cmd.Parameters.AddWithValue("@EmpType", cmb_type.Text);
               // cmd.Parameters.AddWithValue("@Status", '1');
                cmd.ExecuteNonQuery();
                MessageBox.Show("Employees details Updated successfully ", "Updated..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtname.Focus();
                gdv_teach.DataSource = null;

                //Display the saved details in datagridview

                SqlDataAdapter ad = new SqlDataAdapter("select Empno as [Employ Number],EmpName as [Employ Name],Qualification,Phonenum as [Phone Number],Emailid as [Email Id],Address,DOB,Mobnum as [Mobile Number],DOJ as [Date of Join],Sex,Salary,EmpType as [Employee Type],Status from teacherdet where Empno='" + SchoolManagement.empno + "'", d.con);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                gdv_teach.DataSource = ds.Tables[0];

                txtname.Text = "";
                txtqual.Text = "";
                txtpnum.Text = "";
                txtmail.Text = "";
                txtaddrs.Text = "";
                dtpdob.Text = "";
                txtmnum.Text = "";
                dtpjoin.Text = "";
                cmbsex.Text = "";
                cmb_type.Text = "";
                txtsalary.Text = "";
                d.con_close();
            }
        }
        private void btn_Refresh_Click(object sender, EventArgs e)
        {

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            txtname.Text = "";
            txtqual.Text = "";
            txtpnum.Text = "";
            txtmail.Text = "";
            txtaddrs.Text = "";
            dtpdob.Text = "";
            txtmnum.Text = "";
            dtpjoin.Text = "";
            cmbsex.Text = "";
            cmb_type.Text = "";
            txtsalary.Text = "";
            

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gdv_teach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Empno = gdv_teach.Rows[e.RowIndex].Cells[0].Value.ToString();
            SqlDataAdapter da11 = new SqlDataAdapter("select EmpName,Qualification,Phonenum,Emailid,Address,DOB,Mobnum,DOJ,Sex,Salary,EmpType from teacherdet where Empno='" + SchoolManagement.empno + "'", d.con);
            DataSet ds11 = new DataSet();
            da11.Fill(ds11);
            DataRow dr11;
            if (ds11.Tables[0].Rows.Count >= 1)
            {
                dr11 = ds11.Tables[0].Rows[0];
                txtname.Text = dr11[0].ToString();
                txtqual.Text = dr11[1].ToString();
                txtpnum.Text = dr11[2].ToString();
                txtmail.Text = dr11[3].ToString();
                txtaddrs.Text = dr11[4].ToString();
                dtpdob.Text = dr11[5].ToString();
                txtmnum.Text = dr11[6].ToString();
                dtpjoin.Text = dr11[7].ToString();
                cmbsex.Text = dr11[8].ToString();
                cmb_type.Text = dr11[10].ToString();
                txtsalary.Text = dr11[9].ToString();

            }
             else
            {
                MessageBox.Show("Data does not exist", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        

        }
    }
