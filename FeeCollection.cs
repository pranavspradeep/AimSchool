using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace SchoolManagement
{
    public partial class FeeCollection : DevComponents.DotNetBar.Office2007Form
    {
        DataLayer d = new DataLayer();
        ExcelFormatter.IExcelFormatter ef;
        string adno = "";
        string stdno = "";
        public FeeCollection()
        {
            InitializeComponent();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (r1.Checked == false && r2.Checked == false && r3.Checked == false)
            {
                MessageBox.Show("Please select one option for search", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            if (r1.Checked == true)
            {
                txtcls.Text = null;
                txtrol.Text = null;
                if (txt_Cname.Text == "" || txt_Cname.Text == null)
                {
                    MessageBox.Show("Enter Name", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("select sname from tbl_student  where sname like '" + txt_Cname.Text + "%'  ", d.con);
                    DataSet dt1 = new DataSet();
                    da1.Fill(dt1);
                    if (dt1.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("Search name does not exist", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                // to display the student detail in grid by name

                SqlDataAdapter ad = new SqlDataAdapter("select adno as [Admission No],sname as [Student Name],Sex,cstandard as Standard from tbl_student where sname like '" + txt_Cname.Text + "%'", d.con);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    dgvsview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvsview.AutoResizeColumns();                    
                    dgvsview.DataSource = ds.Tables[0];
                }


            }

            if (r2.Checked == true)
            {
                txt_Cname.Text = null;
                txtcls.Text = null;

                if (txtrol.Text == "" || txtrol.Text == null)
                {
                    MessageBox.Show("Enter Roll Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    SqlDataAdapter da2 = new SqlDataAdapter("select adno from tbl_student where adno='" + txtrol.Text + "' ", d.con);
                    DataSet dt2 = new DataSet();
                    da2.Fill(dt2);
                    if (dt2.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("Search roll number does not exist", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                // to display the student detail in grid by roll number

                SqlDataAdapter ad1 = new SqlDataAdapter("select adno as [Admission No],sname as [Student Name],Sex,cstandard as Standard from tbl_student where adno='" + txtrol.Text + "'", d.con);
                DataSet ds1 = new DataSet();
                ad1.Fill(ds1);
                dgvsview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvsview.AutoResizeColumns();
                dgvsview.DataSource = ds1.Tables[0];


            }
            if (r3.Checked == true)
            {
                txt_Cname.Text = null;
                txtrol.Text = null;
                if (txtcls.Text == "" || txtcls.Text == null)
                {
                    MessageBox.Show("Enter Class", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {


                    SqlDataAdapter da3 = new SqlDataAdapter("select cstandard from tbl_student where cstandard='" + txtcls.Text + "'", d.con);
                    DataSet dt3 = new DataSet();
                    da3.Fill(dt3);
                    if (dt3.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("Search class  does not exist", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                // to display the student detail in grid by standard 

                SqlDataAdapter ad2 = new SqlDataAdapter("select adno as [Admission No],sname as [Student Name],Sex,cstandard as Standard from tbl_student where cstandard='" + txtcls.Text + "'", d.con);
                DataSet ds2 = new DataSet();
                ad2.Fill(ds2);
                dgvsview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvsview.AutoResizeColumns();
                dgvsview.DataSource = ds2.Tables[0];

            }
        }



        private void dgvsview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                adno = dgvsview.Rows[e.RowIndex].Cells[0].Value.ToString();
                stdno = dgvsview.Rows[e.RowIndex].Cells[3].Value.ToString();
                SqlDataAdapter ad = new SqlDataAdapter("select adno from tbl_student where adno='" + adno + "'", d.con);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("Data does not exist", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                ////else
                ////{
                ////    SchoolManagement.rno = adno;
                ////    studentdetails sd = new studentdetails();
                ////    sd.Show();
                ////}
            }
            catch
            {

            }

        }
        

        private void FeeCollection_Load(object sender, EventArgs e)
        {
            //ef = new ExcelFormatter.ExcelFormatter();

            string s="select adno as [Admission No],sname as [Student Name],Sex,cstandard as Standard from tbl_student";
            SqlDataAdapter ad = new SqlDataAdapter(s, d.con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dgvsview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvsview.AutoResizeColumns();
                dgvsview.DataSource = ds.Tables[0];
            }
        }

        private void butPayFee_Click(object sender, EventArgs e)
        {
            string newadno = "";
            string newstdno = "";
            string s = "Select adno,cstandard from tbl_student where adno='" + adno + "' and cstandard='" + stdno + "'";
            SqlDataAdapter da = new SqlDataAdapter(s, d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dr = ds.Tables[0].Rows[0];
                newadno = dr[0].ToString();
                newstdno = dr[1].ToString();
                //feepayment feepay = new feepayment();
                dgv_PayHistory fee = new dgv_PayHistory();
                SchoolManagement.rno = newadno;
                SchoolManagement.standard = newstdno;
                fee.Show();
            }
            else
            {
                MessageBox.Show("Please select any one of the student", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
 
        }

        private void butOtherFee_Click(object sender, EventArgs e)
        {
            string newadno = "";
            string newstdno = "";
            SqlDataAdapter da = new SqlDataAdapter("Select adno,cstandard from tbl_student where adno='" + adno + "' and cstandard='" + stdno + "'", d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dr = ds.Tables[0].Rows[0];
                newadno = dr[0].ToString();
                newstdno = dr[1].ToString();
                Addothrfeecollect payotherfee = new Addothrfeecollect();
                SchoolManagement.rno = newadno;
                SchoolManagement.standard = newstdno;
                payotherfee.Show();

            }
            else
            {
                MessageBox.Show("Please select any one of the student", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void butBusFee_Click(object sender, EventArgs e)
        {
            string newadno = "";
            string newstdno = "";
            SqlDataAdapter da = new SqlDataAdapter("Select adno,cstandard from tbl_student where adno='" + adno + "' and cstandard='" + stdno + "'", d.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataRow dr;
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dr = ds.Tables[0].Rows[0];
                newadno = dr[0].ToString();
                newstdno = dr[1].ToString();                
                Buspayment busfair = new Buspayment();
                SchoolManagement.rno = newadno;
                SchoolManagement.standard = newstdno;
                busfair.Show();
            }
            else
            {
                MessageBox.Show("Please select any one of the student", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void butReceipt_Click(object sender, EventArgs e)
        {

            d.con_open();
            
                if (adno == "" || adno == null)
                {
                    MessageBox.Show("Please select any one of the student", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                   
                    string s1 = "Select sname AS [Student Name],Sex,sfname AS [Father Name],Email from tbl_student where adno='" + adno + "' AND cstandard='" + stdno + "'";
                    SqlDataAdapter da = new SqlDataAdapter(s1, d.con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    DataRow dr = ds.Tables[0].Rows[0];
                    string Name = dr[0].ToString().Trim();
                    string Sex = dr[1].ToString().Trim();
                    string SFname = dr[2].ToString().Trim();
                    string Email = dr[3].ToString().Trim();

                    string s = "Select t.adno AS [Adminsion No],t.amount AS [Tution Fee],t.fine AS [Tution Fine],o.amount AS [Other Fee],o.fine AS [Other Fine],r.fare AS [Bus Fee] from tbl_tutionfeepayment t LEFT JOIN tbl_othrfeecollect o ON t.adno=o.adno LEFT JOIN tbl_buspayment b ON b.adno=o.adno AND b.adno=t.adno LEFT JOIN tbl_routepoint r ON r.ptnum=b.ptnum where t.adno='" + adno + "'";
                    SqlCommand cmd = new SqlCommand(s, d.con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    int ExcelRowIdx = 7;
                    int Cols = reader.FieldCount;
                    object[] row = new object[Cols];

                    //ef = new ExcelFormatter();
                    ef.AddNewWorkBook();
                    ef.AddWorkSheet("Sheet1");

                   // ef.AddNewWorkBook();
                    ef.AssignCellValue(2, 1, "Student Name        :" + Name);
                    ef.AssignCellValue(3, 1, "Sex                 :" + Sex);
                    ef.AssignCellValue(4, 1, "Student Father Name :" + SFname);
                    ef.AssignCellValue(5, 1, "Email id            :" + Email);

                    if (reader.HasRows == true)
                    {
                        while (reader.Read())
                        {
                            row[0] = reader.GetValue(0).ToString();
                            row[1] = reader.GetValue(1).ToString();
                            row[2] = reader.GetValue(2).ToString();
                            row[3] = reader.GetValue(3).ToString();
                            row[4] = reader.GetValue(4).ToString();
                            row[5] = reader.GetValue(5).ToString();

                            ef.AssignRowValue(ExcelRowIdx + 1, 1, row);
                            ExcelRowIdx++;
                        }
                        WriteHeader(reader);
                        string date = "D:\\Student Details" + DateTime.Now.ToString("dd-MMM-yy") + ".xls";
                        SaveOutputFile(date);
                    }
                    d.con_close();
                }
            }

        
        private void WriteHeader(SqlDataReader reader)
        {
            int NCols = reader.FieldCount;

            int cl = 0;
            ef.SetRowFont(6, NCols, "Arial", 12, true);
            for (int i = 0; i < NCols; i++)
            {
                ef.AssignCellValue(6, cl + 1, reader.GetName(i));
                ef.SetColumnAutofit(cl + 1);
                cl = cl + 1;
            }


        }
        private void SaveOutputFile(string FilePath)
        {
            try
            {
                ef.SaveExcel(FilePath);
                ef.CloseCurrentWorkbook();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
        }

        private void dgvsview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}