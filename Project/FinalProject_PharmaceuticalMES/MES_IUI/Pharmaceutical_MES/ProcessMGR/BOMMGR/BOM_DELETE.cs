﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmaceutical_MES.ProcessMGR.BOMMGR
{
    public partial class BOM_DELETE : Form
    {
        public BOM_DELETE()
        {
            InitializeComponent();
        }

        private void btnPROC_DELETE_Y_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Close();
        }

        private void btnPROC_DELETE_N_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }
    }
}
