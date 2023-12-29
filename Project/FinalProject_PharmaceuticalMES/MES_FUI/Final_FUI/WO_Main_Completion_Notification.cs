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
    public partial class WO_Main_Completion_Notification : Form
    {
        public WO_Main_Completion_Notification()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; //중간에 오게! 
        }

        private void btn_Check_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
