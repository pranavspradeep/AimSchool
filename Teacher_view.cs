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
    public partial class Teacher_view : Form
    {
        DataLayer d = new DataLayer();
        string Empno = "";
           
        
        public Teacher_view()
        {
            InitializeComponent();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            
             if (r1.Checked == false && r2.Checked == false && r3.Checked == false)
            {
                MessageBox.Show("Select option for search", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            if (r1.Checked == true)
            {
                txtecode.Text = null;
                txtclass.Text = null;
                if (txtname.Text == "" || txtname.Text == null)
                {
                    MessageBox.Show("Enter Name", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("select EmpName from teacherdet  where EmpName like '" + txtname.Text + "%'  ", d.con);
                    DataSet dt1 = new DataSet();
                    da1.Fill(dt1);
                    if (dt1.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("Search name does not exist", "warning...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }


                }

                SqlDataAdapter da2 = new SqlDataAdapter("select Empno,EmpName,Qualification,Phonenum,Address,Sex,Salary from teacherdet where EmpName like '" + txtname.Text + "%'", d.con);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                dgvteacher.DataSource = ds2.Tables[0];


            }

            if (r2.Checked == true)

            {
                txtname.Text = null;
                txtclass.Text = null;
               

                if (txtecode.Text == "" || txtecode.Text == null)
                {
                    MessageBox.Show("Enter Employee Number", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    SqlDataAdapter da3 = new SqlDataAdapter("select Empno from teacherdet  where Empno= '" + txtecode.Text + "'  ", d.con);
                    DataSet dt3 = new DataSet();
                    da3.Fill(dt3);
                    if (dt3.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("Search Employee number does not exist", "warning...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                SqlDataAdapter da2 = new SqlDataAdapter("select Empno,EmpName,Qualification,Phonenum,Address,Sex,Salary from teacherdet where Empno like '" + txtecode.Text + "%'", d.con);
                        DataSet ds2 = new DataSet();
                        da2.Fill(ds2);
                        dgvteacher.DataSource = ds2.Tables[0];
                
                

            }
            if (r3.Checked == true)
            {
                txtname.Text = null;
                txtecode.Text = null;
                if ( txtclass.Text == "" ||  txtclass.Text == null)
                {
                    MessageBox.Show("Enter Class", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    SqlDataAdapter da5 = new SqlDataAdapter("select cstandard from tbl_optques where cstandard ='" + txtclass.Text + "'", d.con);
                    DataSet dt5 = new DataSet();
                    da5.Fill(dt5);
                    if (dt5.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("Search class  does not exist", "warning...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                SqlDataAdapter da2 = new SqlDataAdapter("select s.Empno,s.EmpName,s.Qualification,s.Phonenum,s.Address,s.Sex,s.Salary,p.cstandard from teacherdet s INNER JOIN tbl_optques p ON s.Empno=p.Empno where p.cstandard = '" + txtclass.Text + "'", d.con);
                        DataSet ds2 = new DataSet();
                        da2.Fill(ds2);
                        dgvteacher.DataSource = ds2.Tables[0];
                

            }

        }
            
        


        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            txtname.Text = "";
            txtecode.Text = "";
            txtclass.Text = "";
            
           
        }

        private void dgvteacher_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Empno = dgvteacher.Rows[e.RowIndex].Cells[0].Value.ToString();
             SqlDataAdapter ad = new SqlDataAdapter("select Empno from teacherdet where Empno='" + Empno + "'", d.con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Data does not exist", "warning...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SchoolManagement.empno = Empno;
            }
        }



        

        private void Teacher_view_Load(object sender, EventArgs e)
        {
            //SqlDataAdapter da2 = new SqlDataAdapter("select s.Empno,s.EmpName,s.Qualification,s.Phonenum,s.Address,s.Sex,s.Salary,p.cstandard from teacherdet s INNER JOIN tbl_optques p ON s.Empno=p.Empno", d.con);
            SqlDataAdapter da2 = new SqlDataAdapter("select Empno,EmpName,Qualification,Phonenum,Emailid,Address,DOB,Mobnum,DOJ,Sex,Salary from teacherdet", d.con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            dgvteacher.DataSource = ds2.Tables[0];

            
                  
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            string k = "select Empno,EmpName,Qualification,Phonenum,Emailid,Address,DOB,Mobnum,DOJ,Sex,Salary from teacherdet";
            SqlDataAdapter ca = new SqlDataAdapter(k, d.con);
            DataSet ds2 = new DataSet();
            ca.Fill(ds2);
            dgvteacher.DataSource = ds2.Tables[0];
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (Empno == "" || Empno == null)
            {
                MessageBox.Show("Please select one Employee", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
               
                Edit_teacher tea = new Edit_teacher();
                tea.Show();
                this.Hide();
            }
        }
        }
    }
