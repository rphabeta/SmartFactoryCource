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
    public partial class Defect_Completion : Form
    {
        public Defect_Completion()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; //중간에 오게! 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_Check_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Defct_Completion_Load(object sender, EventArgs e)
        {

        }
    }
}
