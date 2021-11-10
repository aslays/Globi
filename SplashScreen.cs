﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Globi
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
            timer1.Enabled = true;
            timer1.Interval = 2800;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
