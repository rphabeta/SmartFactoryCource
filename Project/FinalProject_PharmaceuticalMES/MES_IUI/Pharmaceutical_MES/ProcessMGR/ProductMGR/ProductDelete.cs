using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmaceutical_MES.ProcessMGR.ProcessMgr
{
    public partial class ProductDelete : Form
    {
        public ProductDelete()
        {
            InitializeComponent();
        }
       

        private void btnPROD_DELETE_N_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void btnPROD_DELETE_Y_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("삭제 되었습니다.");
            DialogResult = DialogResult.Yes;
            Close();
        }
    }
}
