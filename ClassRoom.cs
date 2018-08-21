using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SchoolManagement
{
    public partial class ClassRoom : Form
    {
        public ClassRoom()
        {
            InitializeComponent();
        }

        private void ClassRoom_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            classes cls = new classes();
            cls.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            classes cls = new classes();
            cls.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Assignteachertoclass at = new Assignteachertoclass();
            at.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            stddivision st = new stddivision();
            st.Show();
        }
    }
}