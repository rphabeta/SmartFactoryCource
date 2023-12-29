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
    public partial class Deletion_completed : Form
    {
        public Deletion_completed()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; //중간에 오게! 
        }

        private void btn_Check_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Deletion_completed_Load(object sender, EventArgs e)
        {

        }
    }
}
