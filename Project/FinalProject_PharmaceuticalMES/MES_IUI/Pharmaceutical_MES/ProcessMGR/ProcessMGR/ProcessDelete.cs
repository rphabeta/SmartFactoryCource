using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmaceutical_MES.ProcessMGR.ProcessMGR
{
    public partial class ProcessDelete : Form
    {
        public ProcessDelete()
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
