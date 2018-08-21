using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SchoolManagement
{
    public partial class BusForm : Form
    {
        public BusForm()
        {
            InitializeComponent();
        }

        private void butExam_Click(object sender, EventArgs e)
        {

            route rt = new route();
            //rt.MdiParent = this;
            rt.Show();
        }

        private void butQstnPrpsn_Click(object sender, EventArgs e)
        {
            Routepoint rp = new Routepoint();
            //rp.MdiParent = this;
            rp.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Assignroutetostud art = new Assignroutetostud();
           // art.MdiParent = this;
            art.Show();
        }
    }
}