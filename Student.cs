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
    public partial class Student : Form
    {
        public Student()
        {
            InitializeComponent();
        }

        private void butNew_Click(object sender, EventArgs e)
        {
            NewStudent newstd = new NewStudent();
            newstd.Show();
        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            Student_view searchstd = new Student_view();
            searchstd.Show();
        }

        private void butEdit_Click(object sender, EventArgs e)
        {
            Student_view searchstd = new Student_view();
            searchstd.Show();
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            DeleteStudent deletestd = new DeleteStudent();
            deletestd.Show();
        }
    }
}