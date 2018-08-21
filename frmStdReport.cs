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
    public partial class frmStdReport : Form
    {
        DataLayer d = new DataLayer();
        public frmStdReport()
        {
            InitializeComponent();
        }
        private void frmStdReport_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            d.con_open();
            SqlDataAdapter ad = new SqlDataAdapter("select ", d.con);                  
                       
        }
    }
}