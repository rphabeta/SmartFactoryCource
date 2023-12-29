using Pharmaceutical_MES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViewPage.작업관리
{
    public partial class 생산계획현황 : Form
    {
        String query = $@"SELECT WOID 작업ID FROM WORKORDER";
        DatabaseManager databaseManager = new DatabaseManager();

        public 생산계획현황()
        {
            InitializeComponent();
            databaseManager.stdSearchData(query, dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Text = string.Empty;
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
        }
    }
}
