﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sweee
{
    public partial class Form5 : Form
    {
        CrystalReport4 cr1;
        public Form5()
        {
           
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = cr1;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            cr1 = new CrystalReport4();
        }
    }
}
