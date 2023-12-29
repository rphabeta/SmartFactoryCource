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

namespace Pharmaceutical_MES.StatusManagement.InputStatus
{
    public partial class InputStatus : Form
    {
        public InputStatus()
        {
            InitializeComponent();
        }

        private void btnMTR_SEARCH_Click(object sender, EventArgs e)
        {
            DataSearch();
        }


        private void DataSearch()
        {
            // LOT에대한 정보가 없어서 ML.MTRLID, MT.MTRLNAME 공백.

            string DBmaterial2 = $@"SELECT WO.WOID
                                         , WO.PRODID 
                                         , PD.PRODNAME 
                                         , ML.MTRLID 
                                         , MT.MTRLNAME 
                                         , SUM(LM.INPUTQTY)
                                    FROM WORKORDER                 WO 
                                         INNER JOIN PRODUCT        PD    ON   (WO.PRODID = PD.PRODID) 
                                         LEFT  JOIN LOT            LT    ON   (WO.WOID = LT.WOID)  
                                         LEFT  JOIN LOTMATERIAL    LM    ON   (LT.LOTID = LM.LOTID) 
                                         LEFT  JOIN MATERIALLOT    ML    ON   (LM.MLOTID = ML.MLOTID)
                                         LEFT  JOIN MATERIAL       MT    ON   (ML.MTRLID = MT.MTRLID) 
                                    WHERE 1=1 ";

            // 제품명에 따른 조회
            if (!string.IsNullOrEmpty(txtPRODNAME.Text))
            {
                string PRODNAME = txtPRODNAME.Text;
                DBmaterial2 += $" AND PD.PRODNAME LIKE '%{PRODNAME}%' \n";
            }

            if (!string.IsNullOrEmpty(txtMTRLID.Text))
            {
                string MTRLID = txtMTRLID.Text;
                DBmaterial2 += $" AND ML.MTRLID LIKE '%{MTRLID.ToUpper()}%' \n";
            }

            if (!string.IsNullOrEmpty(txtMTRLNAME.Text))
            {
                string MTRLNAME = txtMTRLNAME.Text;
                DBmaterial2 += $" AND MT.MTRLNAME LIKE '%{MTRLNAME}%' \n";
            }

            DBmaterial2 += $@" GROUP BY WO.WOID 
                                     , WO.PRODID  
                                     , PD.PRODNAME 
                                     , ML.MTRLID 
                                     , MT.MTRLNAME";

            DatabaseManager.DB_Inquiry(DBmaterial2, gvMATERIAL1);

            string[] HeaderName = new string[] { "    작업지시코드", "    제품코드", "    제품명", "    원재료 코드", "    원재료명", "    총 투입량" };


            if (gvMATERIAL1.Rows.Count > 0)
            {
                for (int i = 0; i < HeaderName.Length; i++)
                {
                    gvMATERIAL1.Columns[i].HeaderText = $"{HeaderName[i]}";
                    gvMATERIAL1.Columns[i].ReadOnly = true;
                    gvMATERIAL1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                // 빈 레코드 표시 안함
                gvMATERIAL1.AllowUserToAddRows = false;

                // 헤더 위치 정렬(가운데)
                gvMATERIAL1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }
        }

        private void MATERIAL_INPUTQTY_Load(object sender, EventArgs e)
        {
            //GridDesign1.SetGridDesign(gvMATERIAL1);
            //GridDesign1.SetGridDesign(gvMATERIAL2);
            DataSearch();
        }

        private void GridView_MATERIAL1_CC(object sender, DataGridViewCellEventArgs e)
        {
            string ID = gvMATERIAL1.Rows[e.RowIndex].Cells[0].Value.ToString();

            string DBmaterial2 = $@"SELECT WO.WOID 
                                         , LM.MLOTID 
                                         , LM.INPUTQTY
                                         , LM.INSDTTM 
                                    FROM WORKORDER                    WO
                                           INNER  JOIN PRODUCT        PD    ON   (WO.PRODID = PD.PRODID)
                                           INNER  JOIN LOT            LT    ON   (WO.WOID = LT.WOID) 
                                           INNER  JOIN LOTMATERIAL    LM    ON   (LT.LOTID = LM.LOTID) 
                                           INNER  JOIN MATERIALLOT    ML    ON   (LM.MLOTID = ML.MLOTID)
                                           INNER  JOIN MATERIAL       MT    ON   (ML.MTRLID = MT.MTRLID)
                                    WHERE (((WO.WOID)='" + ID + "'))";


            DBmaterial2 += $"ORDER BY ML.INSDTTM DESC \n";

            DatabaseManager.DB_Inquiry(DBmaterial2, gvMATERIAL2);

            string[] HeaderName = new string[] { "    작업지시코드", "    원재료 LOT ID", "    투입량", "    투입일시" };

            if (gvMATERIAL2.Rows.Count > 0)
            {
                for (int i = 0; i < HeaderName.Length; i++)
                {
                    gvMATERIAL2.Columns[i].HeaderText = $"{HeaderName[i]}";
                    gvMATERIAL2.Columns[i].ReadOnly = true;
                    gvMATERIAL2.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                // 빈 레코드 표시 안함
                gvMATERIAL2.AllowUserToAddRows = false;

                // 헤더 위치 정렬(가운데)
                gvMATERIAL2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }
        }

        private void InputStatus_Load(object sender, EventArgs e)
        {
            // 이벤트 등록
            gvMATERIAL1.CellClick += GridView_MATERIAL1_CC;
            // 검색
            DataSearch();
        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }
    }
}
