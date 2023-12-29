using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_FUI
{
    public partial class LOT추가 : Form
    {
        public static string eqptname { get; set; }
        public static string procid { get; set; }
        public static string prodid { get; set; }
        public static string eqptid { get; set; }

        public static string hpid { get; set; }
        public static string woid { get; set; }

        public LOT추가(string EQPTID = "", string PROCID = "", string PRODID = "", string HPID = "", string WOID = "")
        {
            InitializeComponent();
            LOT추가.eqptid = EQPTID;
            LOT추가.procid = PROCID;
            LOT추가.prodid = PRODID;
            LOT추가.hpid = HPID;
            LOT추가.woid = WOID;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string selectedProid = 과립.Selected_procid;

            //// 콤보박스 초기화
            //cboEqptid.Items.Clear();

            //// 선택된 proid에 따라 콤보박스에 항목 추가
            //if (selectedProid == "PC001")
            //{
            //    cboEqptid.Items.AddRange(new string[] { "GR001", "GR002" });
            //}
            //else if (selectedProid == "PC002")
            //{
            //    cboEqptid.Items.AddRange(new string[] { "CP001", "CP002" });
            //}
            string selectedProcid = LOT추가.procid;
            if (selectedProcid == "PC001")
            {
                if (cboEqptid.SelectedIndex == 0)
                    LOT추가.eqptid = "GR001";
                else
                    LOT추가.eqptid = "GR002";
            }
            else if (selectedProcid == "PC002")
            {
                if (cboEqptid.SelectedIndex == 0)
                    LOT추가.eqptid = "CP001";
                else
                    LOT추가.eqptid = "CP002";
            }
            else
                LOT추가.eqptid = "BX001";
        }


        private void LOT추가_Load(object sender, EventArgs e)
        {
            cboEqptid.Items.Clear();


            string selectedProcid = LOT추가.procid;
            // 선택된 proid에 따라 보여줄 아이템 선택
            if (selectedProcid == "PC001")
            {
                cboEqptid.Items.AddRange(new string[] { "과립1호기", "과립2호기" });
            }
            else if (selectedProcid == "PC002")
            {
                cboEqptid.Items.AddRange(new string[] { "타정1호기", "타정2호기" });
            }
            else
            {
                cboEqptid.Items.AddRange(new string[] { "포장1호기" });
            }
        }

        private void btnLOTAdd_Click(object sender, EventArgs e)
        {
            this.Close();
            LOT호퍼추가 LOT호퍼추가 = new LOT호퍼추가(LOT추가.hpid, LOT추가.eqptid, LOT추가.procid, LOT추가.prodid, LOT추가.woid);
            LOT호퍼추가.Show();

           
        }

    }
}
