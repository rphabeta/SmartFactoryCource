using Final_FUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Pharmaceutical_MES.OrderMGR.SALES_MGR
{
    public partial class SALES_INSERT : Form
    {
        
        public SALES_INSERT()
        {
            InitializeComponent();

            List<string> Product_List = new List<string>()
            {
                "타이레놀",
                "아모디핀",
                "써스펜8",
                "스피드펜"
            };

            // comboBox 초기화
            LoadCombo(Product_List, cbPRD_Name);
        }

        private void LoadCombo(List<string> list, ComboBox comboBox)
        {
            if (list.Count >= 0)
            {
                foreach (string item in list)
                {
                    comboBox.Items.Add(item);
                }
            }
            else MessageBox.Show($"비어있는 리스트입니다.");
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            string ProdID = string.Empty;

            string prodname = cbPRD_Name.Text;

            switch (prodname)
            {
                case "타이레놀":
                    ProdID = "P0001";
                    break;
                case "아모디핀":
                    ProdID = "P0002";
                    break;
                case "써스펜8":
                    ProdID = "P0003";
                    break;
                case "스피드펜":
                    ProdID = "P0004";
                    break;
                default:
                    break;
            }

            // DateTimePicker로부터 날짜 받아오기
            DateTime selectedDate = dtpSALES_DUEDATE.Value;

            // 날짜 형식 지정
            string formattedDate = selectedDate.ToString("yyyy/MM/dd HH:mm:ss");


            string insertSALES = $@"INSERT INTO SALES(SOID, SOSTAT, SOFIRM, SOQTY, SODUEDATE, PRODID, INSUSER, INSDTTM, DEL_YN) 
                                    VALUES (
                                                ('S' || TO_CHAR(SYSDATE, 'YYYYMMDD') || LPAD(salesorder_seq.NEXTVAL, 3, '0'))
                                                  , 'M'
                                                  , '{tbSALES_SOFIRM.Text}'
                                                  , '{int.Parse(tbPROD_QTY.Text)}'
                                                  , '{formattedDate}'
                                                  , '{ProdID}'
                                                  , '{로그인.userid}'  
                                                  , TO_CHAR(SYSDATE, 'YYYYMMDD HH24:MI:SS')
                                                  , 'N')";

            DatabaseManager.DB_Inquiry(insertSALES);
            Close(); 


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
