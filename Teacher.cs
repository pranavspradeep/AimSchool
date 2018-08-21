using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SchoolManagement
{
    public partial class Teacher : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public Teacher()
        {
            InitializeComponent();
        }

        private void Teacher_Load(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            //Attendstatus at = new Attendstatus();
            //at.Show();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            AddMarkUI am = new AddMarkUI();
            am.Show();
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
