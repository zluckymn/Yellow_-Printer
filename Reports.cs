using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Yellow__Printer
{
    public partial class Reports : Form
    {
        public DataSet1 DS; 
        public Reports()
        {
            InitializeComponent();
            DS = new DataSet1(); 
        }
        public Reports(DataSet1 dataset)
        {
            InitializeComponent();
            DS = dataset; 
        }
        LeastYellowReport reporter1 = new LeastYellowReport();//实例化报表学
        private void Reports_Load(object sender, EventArgs e)
        {
　　　　　　reporter1.SetDataSource(DS);
            
            crystalReportViewer1.ReportSource = reporter1;
           
        }

     
    }
}