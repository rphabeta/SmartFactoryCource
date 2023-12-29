using System;
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
    public partial class LOT_D : Form
    {
        public LOT_D()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; //중간에 오게! 
        }

        private void btn_Check_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
