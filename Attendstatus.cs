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
    public partial class Attendstatus : Form
    {
        DataLayer d = new DataLayer();
        ExcelFormatter.IExcelFormatter ef;
        string clsno = "";
        bool status=true;        
       
        public Attendstatus()
        {
            InitializeComponent();
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            string adn = "";
            string dte="";
            int c = Convert.ToInt32(dgv_view.Rows.Count);
            for (int i = 0; i < c - 1; i++)
            {
                status = Convert.ToBoolean(dgv_view.Rows[i].Cells[5].Value.ToString());
                adn = dgv_view.Rows[i].Cells[1].Value.ToString();
                dte = dgv_view.Rows[i].Cells[0].Value.ToString();

                d.con_open();

                SqlCommand cmd = new SqlCommand("upd_assignstatus", d.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@adno", adn);
                cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(dte));
                cmd.ExecuteNonQuery();

                d.con_close();
            }

            MessageBox.Show("Attendance submitted successfully!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
         }
        private void Attendstatus_Load(object sender, EventArgs e)
        {
            // to select class number from table            
            //SqlDataAdapter ad1 = new SqlDataAdapter("select class.classno from tbl_class class inner join teacherdet t on class.classteacherno=t.Empno where Empno='" + SchoolManagement.empno + "'", d.con);
            string s = "select class.classno from tbl_class class inner join teacherdet t on class.classteacherno=t.Empno where t.Empno=" + SchoolManagement.empno;
            SqlDataAdapter ad1 = new SqlDataAdapter(s , d.con);
            DataSet ds1 = new DataSet();
            ad1.Fill(ds1);
            DataRow dr1;
            if(ds1.Tables[0].Rows.Count>=1)
            {
                dr1=ds1.Tables[0].Rows[0];
                clsno = dr1[0].ToString();
            }
           
            d.con_open();

            SqlCommand cmd = new SqlCommand("ins_attend", d.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empno", SchoolManagement.empno);
            cmd.Parameters.AddWithValue("@classno", clsno);
            cmd.ExecuteNonQuery();

            d.con_close();

            // to display the details from gridview

           // SqlDataAdapter ad = new SqlDataAdapter("select a.date as Date,a.adno as [AdmissionNumber],a.rollno as [RollNumber],a.classno as [ClassNumber] ,a.status as Status from tbl_attendance a inner join tbl_class c on a.classno=c.classno where c.classteacherno='" + SchoolManagement.empno + "' and (CONVERT(varchar(8), date, 3)=CONVERT(varchar(8), GETDATE(), 3))", d.con);
           string q="select a.date as Date,a.adno as [AdmissionNumber],a.rollno as [RollNumber],tbl_student.sname as [Student Name],a.classno as [ClassNumber] ,a.status as Status from tbl_attendance a inner join tbl_class c on a.classno=c.classno INNER JOIN tbl_student ON a.adno = tbl_student.adno where c.classteacherno=" + SchoolManagement.empno + "  and (CONVERT(varchar(8), date, 3)=CONVERT(varchar(8), GETDATE(), 3))";
            SqlDataAdapter ad = new SqlDataAdapter(q, d.con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dgv_view.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv_view.AutoResizeColumns();
                dgv_view.DataSource = ds.Tables[0];
            }

        }
        private void dgv_view_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void dgv_view_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //dgv_view.Rows[e.RowIndex].Cells[3].Selected = true;
            //s = Convert.ToString(status);
            //SchoolManagement.admno = dgv_view.Rows[e.RowIndex].Cells[1].Value.ToString();
         
        }
        private void dgv_view_MultiSelectChanged(object sender, EventArgs e)
        {
           
        }
        private void btn_print_Click(object sender, EventArgs e)
        {
           // ef = new ExcelFormatter.ExcelFormatter();
            d.con_open();           
            SqlCommand cmd = new SqlCommand("SELECT a.date as date, sd.sname AS Name, s.cstandard AS Standard, s.division AS Division, a.status AS Status FROM tbl_attendance AS a INNER JOIN tbl_student AS sd ON a.adno = sd.adno INNER JOIN tbl_stddivision AS s ON sd.adno = s.adno  inner join tbl_class c on c.classno=s.classno WHERE(CONVERT(varchar(8), a.date, 3) = CONVERT(varchar(8), GETDATE(), 3))and c.classteacherno='"+SchoolManagement.empno+"' ", d.con);
            SqlDataReader dr = cmd.ExecuteReader();
            int ExcelRowIdx = 3;
            int COLS = dr.FieldCount;
           
            object[] ROW = new object[COLS];
            if (dr.HasRows == true)
            {
                while (dr.Read())
                {
                 
                    //ef.SetHeaderCell(1,"date",11 );

                    //ROW[0] = dr.GetValue(0).ToString();
                    
                    //ef.SetHeaderCell(1,"date", 2);

                    ROW[1] = dr.GetValue(1).ToString();
                    ROW[2] = dr.GetValue(2).ToString();
                    ROW[3] = dr.GetValue(3).ToString();
                    ROW[4] = dr.GetValue(4).ToString();
                    ef.AssignRowValue(ExcelRowIdx, 1, ROW);

                    ExcelRowIdx++;
                }
               
                WriteHeader(dr);
                SaveOutPutFile("D:\\Report\\attendance" + System.DateTime.Now.ToString("dd-MMM-yy") + ".xls");
                MessageBox.Show("Data printed", "print", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            }
            dr.Close();
            d.con_close();
        }
        public void WriteHeader(SqlDataReader dr)
        {
            int Ncols = dr.FieldCount;
            int cl = 0;
            ef.SetRowFont(1, Ncols, "Arial", 16, true);

            for (int i = 0; i < Ncols; i++)
            {
                ef.AssignCellValue(1, cl + 1, dr.GetName(i));
                ef.SetColumnAutofit(cl + 1);
                cl = cl + 1;
            }
        }
        public void SaveOutPutFile(string FilePath)
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
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void txt_SerachStud_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter ad = new SqlDataAdapter("select a.date as Date,a.adno as [AdmissionNumber],a.rollno as [RollNumber],tbl_student.sname as [Student Name],a.classno as [ClassNumber] ,a.status as Status from tbl_attendance a inner join tbl_class c on a.classno=c.classno INNER JOIN tbl_student ON a.adno = tbl_student.adno where c.classteacherno=" + SchoolManagement.empno + " and (CONVERT(varchar(8), date, 3)=CONVERT(varchar(8), GETDATE(), 3)) And tbl_student.sname Like '" + txt_SerachStud.Text + "%'", d.con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            if (ds.Tables[0].Rows.Count >= 1)
            {
                dgv_view.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv_view.AutoResizeColumns();
                dgv_view.DataSource = ds.Tables[0];
            }
        }

        

        

    }
}