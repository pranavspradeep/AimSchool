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
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Addteacher Add = new Addteacher();
            Add.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Teacher_view View = new Teacher_view();
            View.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Teacher_view Edit = new Teacher_view();
            Edit.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DeleteEmp delEmp = new DeleteEmp();
            delEmp.Show();
        }
    }
}