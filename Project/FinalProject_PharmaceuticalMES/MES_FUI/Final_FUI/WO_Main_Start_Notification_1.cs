﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_FUI
{
    public partial class WO_Main_Start_Notification_1 : Form
    {
        public WO_Main_Start_Notification_1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; //중간에 오게! 
        }

        private void btn_Check_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void WO_Main_Start_Notification_1_Load(object sender, EventArgs e)
        {

        }
    }
}
