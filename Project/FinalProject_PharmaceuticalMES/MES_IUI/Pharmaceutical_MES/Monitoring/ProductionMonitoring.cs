using Bunifu.UI.WinForms;
using LiveCharts.Wpf.Charts.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Pharmaceutical_MES.Monitoring
{
    public partial class ProductionMonitoring : Form
    {

        private Timer timer;
        private List<string> timeDuration = new List<string>()
        {
            "주간",
            "월간",
            "분기"
        };

        public ProductionMonitoring()
        {
            InitializeComponent();
            makePRODQTYDonut();
            SearchPRODQty();
        }

        private void ProductionMonitoring_Load(object sender, EventArgs e)
        {
            SearchData();
           

            // 1초 타이머 설정
            timer = new Timer();
            timer.Interval = 1000; // 1초마다 이벤트 발생.
            timer.Tick += Timer_Tick; // 타이머 이벤트 핸들러 등록
            timer.Start();

            // 긴 시간 타이머
            timer2 = new Timer();
            timer2.Interval = 100000; 
            timer2.Tick += Timer_Tick; // 타이머 이벤트 핸들러 등록
            timer2.Start();
            // 콤보박스 설정
            LoadCombo(timeDuration, cbPROD_Duration);
            cbPROD_Duration.SelectedIndex = 0;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            SearchData();
        }

        private void Timer_Tick2(object sender, EventArgs e)
        {
            //makePRODQTYDonut();
            //SearchPRODQty();
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
            else System.Windows.Forms.MessageBox.Show($"비어있는 리스트입니다.");
        }




        public async void SearchData()
        {
            // 전체 누적 생성, 불량
            string totalQuery = $@"SELECT LT.EQPTID                                                                 설비코드                                                
                                         ,NVL(SUM(LT.LOTCRQTY), 0)                                                  생성제품수량                                                                         
                                         ,NVL(SUM(DL.DEFECT_QTY), 0)                                                불량LOT수량                                                                 
                                         ,DECODE(NVL(SUM(LT.LOTQTY), 0), 0, 0, TRUNC(NVL(SUM(DL.DEFECT_QTY), 0) 
                                                / NVL(SUM(LT.LOTQTY), 0), 3)*100)                                   불량율
                                   FROM LOT LT                                                                               
                                   LEFT JOIN DEFECTLOT DL                                                                    
                                        ON(LT.LOTID = DL.DEFECT_LOTID)                                                                                                              
                                   -- AND LT.EQPTID = 'GR001'                                                                 
                                   GROUP BY LT.EQPTID  
                                   ORDER BY
                                         CASE
                                            WHEN LT.EQPTID LIKE '%GR%' THEN 1
                                            WHEN LT.EQPTID LIKE '%CP%' THEN 2
                                            WHEN LT.EQPTID LIKE '%BX%' THEN 3
                                         ELSE 4
                                         END
                                         , LT.EQPTID "; // row 단위 누적량 구해짐.

            // 주간 생성, 불량
            string weekQuery = $@"SELECT LT.EQPTID                                                                  설비코드
                                         ,NVL(SUM(LT.LOTCRQTY), 0)                                                  생성제품수량                                                                         
                                         ,NVL(SUM(DL.DEFECT_QTY), 0)                                                불량LOT수량                                                                 
                                         ,DECODE(NVL(SUM(LT.LOTQTY), 0), 0, 0, TRUNC(NVL(SUM(DL.DEFECT_QTY), 0) 
                                                / NVL(SUM(LT.LOTQTY), 0), 3)*100)                                   불량율
                                   FROM LOT LT                         
                                   LEFT JOIN DEFECTLOT DL                                                                    
                                        ON LT.LOTID = DL.DEFECT_LOTID 
                                   WHERE LT.LOTSTDTTM >= TO_DATE(SYSDATE) - 6                                                  
                                   GROUP BY LT.EQPTID  
                                   ORDER BY
                                         CASE
                                            WHEN LT.EQPTID LIKE '%GR%' THEN 1
                                            WHEN LT.EQPTID LIKE '%CP%' THEN 2
                                            WHEN LT.EQPTID LIKE '%BX%' THEN 3
                                         ELSE 4
                                         END
                                         , LT.EQPTID   ";
            // 금일 생성, 불량
            string todayQuery = $@"SELECT LT.EQPTID                                                                  설비코드
                                         ,NVL(SUM(LT.LOTCRQTY), 0)                                                  생성제품수량                                                                         
                                         ,NVL(SUM(DL.DEFECT_QTY), 0)                                                불량LOT수량                                                                 
                                         ,DECODE(NVL(SUM(LT.LOTQTY), 0), 0, 0, TRUNC(NVL(SUM(DL.DEFECT_QTY), 0) 
                                                / NVL(SUM(LT.LOTQTY), 0), 3)*100)                                   불량율
                                   FROM LOT LT                         
                                   LEFT JOIN DEFECTLOT DL                                                                    
                                        ON LT.LOTID = DL.DEFECT_LOTID 
                                   WHERE LT.LOTSTDTTM >= TO_DATE(SYSDATE) - 1                                                   
                                   GROUP BY LT.EQPTID  
                                   ORDER BY
                                         CASE
                                            WHEN LT.EQPTID LIKE '%GR%' THEN 1
                                            WHEN LT.EQPTID LIKE '%CP%' THEN 2
                                            WHEN LT.EQPTID LIKE '%BX%' THEN 3
                                         ELSE 4
                                         END
                                         , LT.EQPTID   ";

            // 설비 가동여부에 따른 현 설비 등록정보
            string runEQUIPMENT = $@"SELECT 
                                        EP.EQPTID                                          AS 설비코드,
                                        EP.EQPTNAME                                        AS 설비명,
                                        EP.EQPTSTATS                                       AS 가동상태,
                                        SS.STORID                                          AS 호퍼코드,
                                        ROUND((NVL(SS.CURRQTY, 0) / SS.MAXLEVEL) * 100, 2) AS 적재율,                      -- 반올림 자릿수 추가
                                        (SUM(LT.LOTQTY) + NVL(SUM(DL.DEFECT_QTY), 0))      AS 생산수량, 
                                        SUM(LT.LOTQTY)                                     AS 양품수량,
                                        SUM(DL.DEFECT_QTY)                                 AS 불량수량,
                                        ROUND((NVL(SUM(DL.DEFECT_QTY), 0) / NULLIF(SUM(LT.LOTQTY), 0)) * 100, 2) AS 불량률 -- 반올림 자릿수 추가, 0으로 나누는 경우 방지
                                    FROM 
                                        EQUIPMENT EP
                                    LEFT JOIN 
                                        STORE_STORAGE SS ON EP.EQPTID = SS.EQPTID
                                    LEFT JOIN 
                                        LOT LT ON EP.EQPTID = LT.EQPTID AND LT.WOID IN (SELECT WOID 
                                                                                          FROM LOT 
                                                                                         WHERE LOTID IN (SELECT MAX(LOTID) FROM LOT GROUP BY EQPTID)) 
                                    LEFT JOIN 
                                        DEFECTLOT DL ON LT.LOTID = DL.DEFECT_LOTID
                                    WHERE  1=1
                                        AND EP.EQPTSTATS = 'RUN'
                                    GROUP BY 
                                        EP.EQPTID,
                                        EP.EQPTNAME,
                                        EP.EQPTSTATS,
                                        SS.CURRQTY,
                                        SS.MAXLEVEL,
                                        SS.STORID
                                    ";

            // 설비 가동여부에 따른 현 설비 등록정보
            string DownEQUIPMENT = $@"
                                     SELECT 
                                        EQPTID        설비코드
                                    FROM EQUIPMENT
                                    WHERE EQPTSTATS = 'DOWN'
                                    ";




            DataTable total_infomation  = DatabaseManager.DB_Inquiry(totalQuery);
            DataTable week_infomation   = DatabaseManager.DB_Inquiry(weekQuery);
            DataTable today_information = DatabaseManager.DB_Inquiry(todayQuery);
            DataTable run_information   = DatabaseManager.DB_Inquiry(runEQUIPMENT);
            DataTable down_information  = DatabaseManager.DB_Inquiry(DownEQUIPMENT);



            // 전체 누적 정보 
            if (total_infomation.Rows.Count > 0)
            {
                for (int i = 0; i < total_infomation.Rows.Count; i++)
                {
                    int totalDFT_1000 = Convert.ToInt32(Math.Round(double.Parse(total_infomation.Rows[i]["불량LOT수량"].ToString())
                                        / double.Parse(total_infomation.Rows[i]["생성제품수량"].ToString()) * 1000));
                    double totalDFT_100 = Math.Round(double.Parse(total_infomation.Rows[i]["불량LOT수량"].ToString())
                                        / double.Parse(total_infomation.Rows[i]["생성제품수량"].ToString()) * 100, 1);
                    if (total_infomation.Rows[i]["설비코드"].ToString() == "GR001")
                    {
                        lbGR001_TotalPROD.Text = total_infomation.Rows[i]["생성제품수량"].ToString() + " 개";
                        pbGR001_TotalDFT.Value = Convert.ToInt32(totalDFT_1000);
                        lbGR001_TotalDFT.Text = totalDFT_100.ToString() + "%";
                    }
                    else if (total_infomation.Rows[i]["설비코드"].ToString() == "GR002")
                    {
                        lbGR002_TotalPROD.Text = total_infomation.Rows[i]["생성제품수량"].ToString() + " 개";
                        pbGR002_TotalDFT.Value = Convert.ToInt32(totalDFT_1000);
                        lbGR002_TotalDFT.Text = totalDFT_100.ToString() + "%";
                    }
                    else if (total_infomation.Rows[i]["설비코드"].ToString() == "CP001")
                    {
                        lbCP001_TotalPROD.Text = total_infomation.Rows[i]["생성제품수량"].ToString() + " 개";
                        pbCP001_TotalDFT.Value = Convert.ToInt32(totalDFT_1000);
                        lbCP001_TotalDFT.Text = totalDFT_100.ToString() + "%";
                    }
                    else if (total_infomation.Rows[i]["설비코드"].ToString() == "CP002")
                    {
                        lbCP002_TotalPROD.Text = total_infomation.Rows[i]["생성제품수량"].ToString() + " 개";
                        pbCP002_TotalDFT.Value = Convert.ToInt32(totalDFT_1000);
                        lbCP002_TotalDFT.Text = totalDFT_100.ToString() + "%";
                    }
                    else if (total_infomation.Rows[i]["설비코드"].ToString() == "BX001")
                    {
                        lbBX001_TotalPROD.Text = total_infomation.Rows[i]["생성제품수량"].ToString() + " 개";
                        pbBX001_TotalDFT.Value = Convert.ToInt32(totalDFT_1000);
                        lbBX001_TotalDFT.Text = totalDFT_100.ToString() + "%";
                    }
                }
            }

            // 주간 누적 정보 
            if (week_infomation.Rows.Count > 0)
            {
                for (int i = 0; i < week_infomation.Rows.Count; i++)
                {
                    int weekDFT_1000 = Convert.ToInt32(Math.Round(double.Parse(week_infomation.Rows[i]["불량LOT수량"].ToString())
                                    / double.Parse(week_infomation.Rows[i]["생성제품수량"].ToString()) * 1000));
                    double weekDFT_100 = Math.Round(double.Parse(week_infomation.Rows[i]["불량LOT수량"].ToString())
                                        / double.Parse(week_infomation.Rows[i]["생성제품수량"].ToString()) * 100, 1);
                    if (week_infomation.Rows[i]["설비코드"].ToString() == "GR001")
                    {
                        lbGR001_WeekPROD.Text = week_infomation.Rows[i]["생성제품수량"].ToString() + " 개";
                        pbGR001_WeekDFT.Value = Convert.ToInt32(weekDFT_1000);
                        lbGR001_WeekDFT.Text = weekDFT_100.ToString() + "%";
                    }
                    else if (week_infomation.Rows[i]["설비코드"].ToString() == "GR002")
                    {
                        lbGR002_WeekPROD.Text = week_infomation.Rows[i]["생성제품수량"].ToString() + " 개";
                        pbGR002_WeekDFT.Value = Convert.ToInt32(weekDFT_1000);
                        lbGR002_WeekDFT.Text = weekDFT_100.ToString() + "%";
                    }
                    else if (week_infomation.Rows[i]["설비코드"].ToString() == "CP001")
                    {
                        lbCP001_WeekPROD.Text = week_infomation.Rows[i]["생성제품수량"].ToString() + " 개";
                        pbCP001_WeekDFT.Value = Convert.ToInt32(weekDFT_1000);
                        lbCP001_WeekDFT.Text = weekDFT_100.ToString() + "%";
                    }
                    else if (week_infomation.Rows[i]["설비코드"].ToString() == "CP002")
                    {
                        lbCP002_WeekPROD.Text = week_infomation.Rows[i]["생성제품수량"].ToString() + " 개";
                        pbCP002_WeekDFT.Value = Convert.ToInt32(weekDFT_1000);
                        lbCP002_WeekDFT.Text = weekDFT_100.ToString() + "%";
                    }
                    else if (week_infomation.Rows[i]["설비코드"].ToString() == "BX001")
                    {
                        lbBX001_WeekPROD.Text = week_infomation.Rows[i]["생성제품수량"].ToString() + " 개";
                        pbBX001_WeekDFT.Value = Convert.ToInt32(weekDFT_1000);
                        lbBX001_WeekDFT.Text = weekDFT_100.ToString() + "%";
                    }
                }
            }

            // 금일 누적 정보 
            if (today_information.Rows.Count > 0)
            {
                for (int i = 0; i < today_information.Rows.Count; i++)
                {
                    int weekDFT_1000 = Convert.ToInt32(Math.Round(double.Parse(today_information.Rows[i]["불량LOT수량"].ToString())
                                    / double.Parse(today_information.Rows[i]["생성제품수량"].ToString()) * 1000));
                    double weekDFT_100 = Math.Round(double.Parse(today_information.Rows[i]["불량LOT수량"].ToString())
                                        / double.Parse(today_information.Rows[i]["생성제품수량"].ToString()) * 100, 1);
                    if (today_information.Rows[i]["설비코드"].ToString() == "GR001")
                    {
                        lbGR001_TodayPROD.Text = today_information.Rows[i]["생성제품수량"].ToString() + " 개";
                    }
                    else if (today_information.Rows[i]["설비코드"].ToString() == "GR002")
                    {
                        lbGR002_TodayPROD.Text = today_information.Rows[i]["생성제품수량"].ToString() + " 개";
                    }
                    else if (today_information.Rows[i]["설비코드"].ToString() == "CP001")
                    {
                        lbCP001_TodayPROD.Text = today_information.Rows[i]["생성제품수량"].ToString() + " 개";
                    }
                    else if (today_information.Rows[i]["설비코드"].ToString() == "CP002")
                    {
                        lbCP002_TodayPROD.Text = today_information.Rows[i]["생성제품수량"].ToString() + " 개";
                    }
                    else if (today_information.Rows[i]["설비코드"].ToString() == "BX001")
                    {
                        lbBX001_TodayPROD.Text = today_information.Rows[i]["생성제품수량"].ToString() + " 개";
                    }
                }
            }

            // 가동중 설비 정보
            if (run_information.Rows.Count > 0)
            {
                for (int i = 0; i < run_information.Rows.Count; i++)
                {
                 
                    if (run_information.Rows[i]["설비코드"].ToString() == "GR001" )
                    {
                        
                        lbGR001_STAT.Text = "진행";
                        pnGR001_ACTIVATE.BackColor = Color.Green;
                        lbGR001_GoalPROD.Text = run_information.Rows[i]["생산수량"].ToString() + " 개";
                        lbGR001_SYSPROD.Text  = run_information.Rows[i]["양품수량"].ToString() + " 개";
                        lbGR001_DFTQTY.Text   = run_information.Rows[i]["불량수량"].ToString() + " 개";
                        lbGR001_DFTPER.Text   = run_information.Rows[i]["불량률"].ToString()   + " %"; 


                        pnGR001_1.BackColor = Color.Green;
                        pnGR001_2.BackColor = Color.Green;
                        pnGR001_3.BackColor = Color.Green;
                        pnGR001_4.BackColor = Color.Green;
                        pnGR001_5.BackColor = Color.Green;



                        lbGR001_ConSTORE.Text = "연결호퍼(" + run_information.Rows[i]["호퍼코드"].ToString() + ")";
                        lbGR001_STORELoad.Text = run_information.Rows[i]["적재율"].ToString();

                        // 20초 동안 대기
                        //await Task.Delay(20000);


                    }
                    else if (run_information.Rows[i]["설비코드"].ToString() == "GR002")
                    {
                       
                        lbGR002_STAT.Text = "진행";
                        pnGR002_ACTIVATE.BackColor = Color.Green;
                            
                        lbGR002_GoalPROD.Text = run_information.Rows[i]["생산수량"].ToString()   + " 개";
                        lbGR002_SYSPROD.Text  = run_information.Rows[i]["양품수량"].ToString()   + " 개";
                        lbGR002_DFTQTY.Text   = run_information.Rows[i]["불량수량"].ToString()   + " 개";
                        lbGR001_DFTPER.Text   = run_information.Rows[i]["불량률"].ToString()     + " %";

                        pnGR002_1.BackColor = Color.Green;
                        pnGR002_2.BackColor = Color.Green;
                        pnGR002_3.BackColor = Color.Green;
                        pnGR002_4.BackColor = Color.Green;
                        pnGR002_5.BackColor = Color.Green;

                        lbGR002_ConSTORE.Text = "연결호퍼(" + run_information.Rows[i]["호퍼코드"].ToString() + ")";
                        lbGR002_STORELoad.Text = run_information.Rows[i]["적재율"].ToString();

                        // 20초 동안 대기
                        //await Task.Delay(20000);

                    }
                    else if (run_information.Rows[i]["설비코드"].ToString() == "CP001")
                    {
                      
                        lbCP001_STAT.Text = "진행";
                        pnCP001_ACTIVATE.BackColor = Color.Green;

                        lbCP001_GoalPROD.Text = run_information.Rows[i]["생산수량"].ToString()   + " 개";
                        lbCP001_SYSPROD.Text  = run_information.Rows[i]["양품수량"].ToString()   + " 개";
                        lbCP001_DFTQTY.Text   = run_information.Rows[i]["불량수량"].ToString()   + " 개";
                        lbCP001_DFTPER.Text   = run_information.Rows[i]["불량률"].ToString()     + " %";

                        pnCP001_1.BackColor = Color.Green;
                        pnCP001_2.BackColor = Color.Green;
                        pnCP001_3.BackColor = Color.Green;
                        pnCP001_4.BackColor = Color.Green;
                        pnCP001_5.BackColor = Color.Green;

                        lbCP001_ConSTORE.Text = "연결호퍼(" + run_information.Rows[i]["호퍼코드"].ToString() + ")";
                        lbCP001_STORELoad.Text = run_information.Rows[i]["적재율"].ToString();

                        // 20초 동안 대기
                        //await Task.Delay(20000);
                    }
                    else if (run_information.Rows[i]["설비코드"].ToString() == "CP002")
                    {
                        
                        lbCP002_STAT.Text = "진행";
                        pnCP002_ACTIVATE.BackColor = Color.Green;
                            
                        lbCP002_GoalPROD.Text = run_information.Rows[i]["생산수량"].ToString() + " 개";
                        lbCP002_SYSPROD.Text  = run_information.Rows[i]["양품수량"].ToString() + " 개";
                        lbCP002_DFTQTY.Text   = run_information.Rows[i]["불량수량"].ToString() + " 개";
                        lbCP002_DFTPER.Text   = run_information.Rows[i]["불량률"].ToString()   + " %";

                        pnCP002_1.BackColor = Color.Green;
                        pnCP002_2.BackColor = Color.Green;
                        pnCP002_3.BackColor = Color.Green;
                        pnCP002_4.BackColor = Color.Green;
                        pnCP002_5.BackColor = Color.Green;


                        lbCP002_ConSTORE.Text = "연결호퍼(" + run_information.Rows[i]["호퍼코드"].ToString() + ")";
                        lbCP002_STORELoad.Text = run_information.Rows[i]["적재율"].ToString();
                        
                        // 20초 동안 대기
                        //await Task.Delay(20000);

                    }
                    else if (run_information.Rows[i]["설비코드"].ToString() == "BX001")
                    {
                        
                        lbBX001_STAT.Text = "진행";
                        pnBX001_ACTIVATE.BackColor = Color.Green;
                            

                        lbBX001_GoalPROD.Text = run_information.Rows[i]["생산수량"].ToString() + " 개";
                        lbBX001_SYSPROD.Text  = run_information.Rows[i]["양품수량"].ToString() + " 개";
                        lbBX001_DFTQTY.Text   = run_information.Rows[i]["불량수량"].ToString() + " 개";
                        lbBX001_DFTPER.Text   = run_information.Rows[i]["불량률"].ToString()   + " %";

                        pnBX001_1.BackColor = Color.Green;
                        pnBX001_2.BackColor = Color.Green;
                        pnBX001_3.BackColor = Color.Green;

                        lbBX001_ConSTORE.Text = "연결호퍼(" + run_information.Rows[i]["호퍼코드"].ToString() + ")";
                        lbBX001_STORELoad.Text = run_information.Rows[i]["적재율"].ToString();

                        // 20초 동안 대기
                        //await Task.Delay(20000);
                    }
                }
            }


            // 가동중 중지 설비
            if (down_information.Rows.Count > 0)
            {
                for (int i = 0; i < down_information.Rows.Count; i++)
                {
                    if (down_information.Rows[i]["설비코드"].ToString() == "GR001")
                    {
                        lbGR001_STAT.Text = "정지";
                        pnGR001_ACTIVATE.BackColor = Color.Red;
                        lbGR001_GoalPROD.Text = "0 개";
                        lbGR001_SYSPROD.Text = "0 개";
                        lbGR001_DFTQTY.Text = "0 개";
                        lbGR001_DFTPER.Text = "0 %";

                        pnGR001_1.BackColor = Color.Red;
                        pnGR001_2.BackColor = Color.Red;
                        pnGR001_3.BackColor = Color.Red;
                        pnGR001_4.BackColor = Color.Red;
                        pnGR001_5.BackColor = Color.Red;


                        lbGR001_ConSTORE.Text = "연결호퍼";
                        lbGR001_STORELoad.Text = "0%";
                        
                    }
                    else if (down_information.Rows[i]["설비코드"].ToString() == "GR002")
                    {
                        lbGR002_STAT.Text = "정지";
                        pnGR002_ACTIVATE.BackColor = Color.Red;
                        lbGR002_GoalPROD.Text = "0 개";
                        lbGR002_SYSPROD.Text = "0 개";
                        lbGR002_DFTQTY.Text = "0 개";
                        lbGR001_DFTPER.Text = "0 %";

                        pnGR002_1.BackColor = Color.Red;
                        pnGR002_2.BackColor = Color.Red;
                        pnGR002_3.BackColor = Color.Red;
                        pnGR002_4.BackColor = Color.Red;
                        pnGR002_5.BackColor = Color.Red;


                        lbGR002_ConSTORE.Text = "연결호퍼";
                        lbGR002_STORELoad.Text = "0%";
                        
                    }
                    else if (down_information.Rows[i]["설비코드"].ToString() == "CP001")
                    {
                        
                        lbCP001_STAT.Text = "정지";
                        pnCP001_ACTIVATE.BackColor = Color.Red;

                        lbCP001_GoalPROD.Text = "0 개";
                        lbCP001_SYSPROD.Text = "0 개";
                        lbCP001_DFTQTY.Text = "0 개";
                        lbCP001_DFTPER.Text = "0 %";

                        pnCP001_1.BackColor = Color.Red;
                        pnCP001_2.BackColor = Color.Red;
                        pnCP001_3.BackColor = Color.Red;
                        pnCP001_4.BackColor = Color.Red;
                        pnCP001_5.BackColor = Color.Red;


                        lbCP001_ConSTORE.Text = "연결호퍼";
                        lbCP001_STORELoad.Text = "0%";
                        
                    }
                    else if (down_information.Rows[i]["설비코드"].ToString() == "CP002")
                    {
                        
                        lbCP002_STAT.Text = "정지";
                        pnCP002_ACTIVATE.BackColor = Color.Red;

                        lbCP002_GoalPROD.Text = "0 개";
                        lbCP002_SYSPROD.Text = "0 개";
                        lbCP002_DFTQTY.Text = "0 개";
                        lbCP002_DFTPER.Text = "0 %";

                        pnCP002_1.BackColor = Color.Red;
                        pnCP002_2.BackColor = Color.Red;
                        pnCP002_3.BackColor = Color.Red;
                        pnCP002_4.BackColor = Color.Red;
                        pnCP002_5.BackColor = Color.Red;

                        lbCP002_ConSTORE.Text = "연결호퍼";
                        lbCP002_STORELoad.Text = "0%";
                        
                    }
                    else if (down_information.Rows[i]["설비코드"].ToString() == "BX001")
                    {
                        
                        lbBX001_STAT.Text = "정지";
                        pnBX001_ACTIVATE.BackColor = Color.Red;

                        lbBX001_GoalPROD.Text = "0 개";
                        lbBX001_SYSPROD.Text = "0 개";
                        lbBX001_DFTQTY.Text = "0 개";
                        lbBX001_DFTPER.Text = "0 %";

                        pnBX001_1.BackColor = Color.Red;
                        pnBX001_2.BackColor = Color.Red;
                        pnBX001_3.BackColor = Color.Red;

                        lbBX001_ConSTORE.Text = "연결호퍼";
                        lbBX001_STORELoad.Text = "0%";
                        
                    }
                }
            }

            // 전체 평균 - 현재 평균 => - 증가 더 작아짐.
            // 점검 필요 유무 판단 및 안내
            // 긴급점검이 필요한 경우 빨강

            // 5이상의 차이
            if (ExtractNumber(lbGR001_TotalDFT.Text) - ExtractNumber(lbGR001_WeekDFT.Text) <= -5)
            {
                pnGR001_EQPTCHECK.BackColor = Color.Red;
                lbGR001_EQPTCHECK.Text = "점검권고";
            }
            else if(ExtractNumber(lbGR001_TotalDFT.Text) - ExtractNumber(lbGR001_WeekDFT.Text) <= -3)
            {
                pnGR001_EQPTCHECK.BackColor = Color.Orange;
                lbGR001_EQPTCHECK.Text = "점검권장";
            }
            else
            {
                pnGR001_EQPTCHECK.BackColor = Color.Green;
                lbGR001_EQPTCHECK.Text = "정상";
            }

            if (ExtractNumber(lbGR002_TotalDFT.Text) - ExtractNumber(lbGR002_WeekDFT.Text) <= -5)
            {
                pnGR002_EQPTCHECK.BackColor = Color.Red;
                lbGR002_EQPTCHECK.Text = "점검권고";
            }
            else if (ExtractNumber(lbGR002_TotalDFT.Text) - ExtractNumber(lbGR002_WeekDFT.Text) <= -3)
            {
                pnGR002_EQPTCHECK.BackColor = Color.Orange;
                lbGR002_EQPTCHECK.Text = "점검권장";
            }
            else
            {
                pnGR002_EQPTCHECK.BackColor = Color.Green;
                lbGR002_EQPTCHECK.Text = "정상";
            }

            if (ExtractNumber(lbCP001_TotalDFT.Text) - ExtractNumber(lbCP001_WeekDFT.Text) <= -5)
            {
                pnCP001_EQPTCHECK.BackColor = Color.Red;
                lbCP001_EQPTCHECK.Text = "점검권고";
            }
            else if (ExtractNumber(lbCP001_TotalDFT.Text) - ExtractNumber(lbCP001_WeekDFT.Text) <= -3)
            {
                pnCP001_EQPTCHECK.BackColor = Color.Orange;
                lbCP001_EQPTCHECK.Text = "점검권장";
            }
            else
            {
                pnCP001_EQPTCHECK.BackColor = Color.Green;
                lbCP001_EQPTCHECK.Text = "정상";
            }

            if (ExtractNumber(lbCP002_TotalDFT.Text) - ExtractNumber(lbCP002_WeekDFT.Text) <= -5)
            {
                pnCP002_EQPTCHECK.BackColor = Color.Red;
                lbCP002_EQPTCHECK.Text = "점검권고";
            }
            else if (ExtractNumber(lbCP002_TotalDFT.Text) - ExtractNumber(lbCP002_WeekDFT.Text) <= -3)
            {
                pnCP002_EQPTCHECK.BackColor = Color.Orange;
                lbCP002_EQPTCHECK.Text = "점검권장";
            }
            else
            {
                pnCP002_EQPTCHECK.BackColor = Color.Green;
                lbCP002_EQPTCHECK.Text = "정상";
            }

            if (ExtractNumber(lbBX001_TotalDFT.Text) - ExtractNumber(lbBX001_WeekDFT.Text) <= -5)
            {
                pnBX001_EQPTCHECK.BackColor = Color.Red;
                lbBX001_EQPTCHECK.Text = "점검권고";
            }
            else if (ExtractNumber(lbBX001_TotalDFT.Text) - ExtractNumber(lbBX001_WeekDFT.Text) <= -3)
            {
                pnBX001_EQPTCHECK.BackColor = Color.Orange;
                lbBX001_EQPTCHECK.Text = "점검권장";
            }
            else
            {
                pnBX001_EQPTCHECK.BackColor = Color.Green;
                lbBX001_EQPTCHECK.Text = "정상";
            }
        }



        //-------------------------------
        //생산점유율 도넛
        private void SearchPRODQty()
        {
            {
                string PROD_QTY = $@"SELECT 
                                         PD.PRODID AS 제품코드,
                                         PD.PRODNAME AS 제품명,
                                         NVL(SUM(LT.LOTQTY), 0) AS 생산총량
                                     FROM 
                                         PRODUCT PD
                                     LEFT JOIN 
                                         WORKORDER WO ON PD.PRODID = WO.PRODID
                                     LEFT JOIN 
                                         LOT LT ON WO.WOID = LT.WOID 
                                         AND LT.EQPTID     = 'BX001' 
                                         AND LT.LOTSTAT    = 'E' 
                                         AND LT.LOTSTDTTM >= TO_DATE(SYSDATE) - DECODE('주간', 
                                                                                       '주간', 6, 
                                                                                       '월간', 30, 
                                                                                       '분기', 120)
                                     GROUP BY 
                                         PD.PRODID, PD.PRODNAME
                                     ORDER BY 
                                         NVL(SUM(LT.LOTQTY), 0) DESC

                                     ";

                string PROD_ValueSELECT = $@"SELECT WO.PRODID                   제품코드
                                                    , PD.PRODNAME               제품명
                                                    , SUM(LT.LOTQTY)            생산총량
                                             FROM LOT LT
                                               LEFT JOIN WORKORDER WO
                                                    ON LT.WOID = WO.WOID
                                               LEFT JOIN PRODUCT PD
                                                    ON WO.PRODID = PD.PRODID
                                             WHERE LT.EQPTID = 'BX001'
                                                   AND LT.LOTSTAT = 'E'
                                                   AND PD.PRODID IS NOT NULL
                                                   AND LT.LOTSTDTTM >= TO_DATE(SYSDATE) - DECODE(':duration_',
                                                                                         '주간', 6,
                                                                                         '월간', 30,
                                                                                         '분기', 120) -- 조회조건 : 주간 6, 월간 30, 분기 120  
                                             GROUP BY WO.PRODID, PD.PRODNAME
                                             ORDER BY SUM(LT.LOTQTY) DESC
                                            ";

                // :duration_
                string duration = cbPROD_Duration.Text;
                PROD_ValueSELECT = PROD_ValueSELECT.Replace(":duration_", duration);
                PROD_QTY = PROD_QTY.Replace(":duration_", duration);

                using (DataTable data_Table2 = DatabaseManager.DB_Inquiry(PROD_ValueSELECT))
                {
                    // 텍스트 및 값 삽입
                    switch (data_Table2.Rows.Count)
                    {
                        case 1:
                            lbPRODNAME_1.Text = data_Table2.Rows[0][1].ToString();
                            lbPRODQTY_1.Text = data_Table2.Rows[0][2].ToString() + " 개";
                            break;

                        case 2:
                            lbPRODNAME_1.Text = data_Table2.Rows[0][1].ToString();
                            lbPRODNAME_2.Text = data_Table2.Rows[1][1].ToString();

                            lbPRODQTY_1.Text = data_Table2.Rows[0][2].ToString() + " 개";
                            lbPRODQTY_2.Text = data_Table2.Rows[1][2].ToString() + " 개";
                            break;

                        case 3:
                            lbPRODNAME_1.Text = data_Table2.Rows[0][1].ToString();
                            lbPRODNAME_2.Text = data_Table2.Rows[1][1].ToString();
                            lbPRODNAME_3.Text = data_Table2.Rows[2][1].ToString();

                            lbPRODQTY_1.Text = data_Table2.Rows[0][2].ToString() + " 개";
                            lbPRODQTY_2.Text = data_Table2.Rows[1][2].ToString() + " 개";
                            lbPRODQTY_3.Text = data_Table2.Rows[2][2].ToString() + " 개";
                            break;
                        case 4:
                            lbPRODNAME_1.Text = data_Table2.Rows[0][1].ToString();
                            lbPRODNAME_2.Text = data_Table2.Rows[1][1].ToString();
                            lbPRODNAME_3.Text = data_Table2.Rows[2][1].ToString();
                            lbPRODNAME_4.Text = data_Table2.Rows[3][1].ToString();

                            lbPRODQTY_1.Text = data_Table2.Rows[0][2].ToString() + " 개";
                            lbPRODQTY_2.Text = data_Table2.Rows[1][2].ToString() + " 개";
                            lbPRODQTY_3.Text = data_Table2.Rows[2][2].ToString() + " 개";
                            lbPRODQTY_4.Text = data_Table2.Rows[3][2].ToString() + " 개";
                            break;
                        default:
                            // 다른 경우에 대한 처리
                            break;
                    };
                }




                using (DataTable data_Table = DatabaseManager.DB_Inquiry(PROD_QTY))
                {
                    // 도넛 삽입
                    if (data_Table.Rows.Count > 0)
                    {
                        double TylenolQTY = double.Parse(data_Table.Rows[0][2].ToString());
                        double AmodipineQTY = double.Parse(data_Table.Rows[1][2].ToString());
                        double Suspen8QTY = double.Parse(data_Table.Rows[2][2].ToString());
                        double SpeedPenQTY = double.Parse(data_Table.Rows[3][2].ToString());


                        // 차트 옵션 설정
                        donut_QtrProdQTY.Series.Clear();
                        donut_QtrProdQTY.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                        donut_QtrProdQTY.ChartAreas[0].AxisX.MajorGrid.Enabled = false;


                        // 데이터 추가 및 색깔 설정 
                        Series series = new Series("donut_QtrProdQTY");
                        series.ChartType = SeriesChartType.Doughnut;

                        DataPoint dataPoint1 = new DataPoint();
                        dataPoint1.YValues = new double[] { TylenolQTY };
                        dataPoint1.Color = System.Drawing.Color.FromArgb(255, 126, 133, 154); // 잿빛 파랑 (126, 133, 154)

                        DataPoint dataPoint2 = new DataPoint();
                        dataPoint2.YValues = new double[] { AmodipineQTY };
                        dataPoint2.Color = System.Drawing.Color.FromArgb(255, 248, 204, 124); // 노랑 (248, 204, 124)

                        DataPoint dataPoint3 = new DataPoint();
                        dataPoint3.YValues = new double[] { Suspen8QTY };
                        dataPoint3.Color = System.Drawing.Color.FromArgb(255, 73, 163, 156); // 녹색 (73, 163, 156)

                        DataPoint dataPoint4 = new DataPoint();
                        dataPoint4.YValues = new double[] { SpeedPenQTY };
                        dataPoint4.Color = System.Drawing.Color.FromArgb(255, 9, 24, 71); // 남색 (9, 24, 71)



                        // 도넛 차트의 각 부분에 해당하는 데이터 포인트 추가
                        series.Points.Add(dataPoint1);
                        series.Points.Add(dataPoint2);
                        series.Points.Add(dataPoint3);
                        series.Points.Add(dataPoint4);


                        // 차트에 시리즈 추가
                        donut_QtrProdQTY.Series.Add(series);
                    }
                };

            }
        }




        private void makePRODQTYDonut()
        {
            {
                // 수량 기준 정렬
                string PRODQTYDonut_Query = $@"SELECT 
                                                       PD.PRODNAME                      PRODNAME
                                                       , SUM(STP.PRODQTY)               PRODQTY
                                                FROM STORAGEPRODUCT STP
                                                  LEFT JOIN PRODUCT PD ON STP.PRODID = PD.PRODID
                                                  LEFT JOIN STORE_STORAGE ST ON STP.STORID = ST.STORID
                                                WHERE 1=1
                                                GROUP BY PD.PRODNAME
                                                ORDER BY PRODQTY DESC
                                            ";

                string PRODQTYDonut_Query_T = $@"
                                                SELECT 
                                                       PD.PRODNAME                      PRODNAME
                                                       , SUM(STP.PRODQTY)               PRODQTY
                                                FROM STORAGEPRODUCT STP
                                                  LEFT JOIN PRODUCT PD ON STP.PRODID = PD.PRODID
                                                  LEFT JOIN STORE_STORAGE ST ON STP.STORID = ST.STORID
                                                WHERE 1=1
                                                GROUP BY PD.PRODNAME
                                                ORDER BY 
                                                   CASE 
                                                       WHEN PD.PRODNAME LIKE '타이레놀' THEN 1
                                                       WHEN PD.PRODNAME LIKE '아모디핀' THEN 2
                                                       WHEN PD.PRODNAME LIKE '써스펜8' THEN 3
                                                       WHEN PD.PRODNAME LIKE '스피드펜' THEN 4
                                                       ELSE 5
                                                   END, PD.PRODNAME 
                                                ";


                

                using (DataTable data_Table2 = DatabaseManager.DB_Inquiry(PRODQTYDonut_Query_T))
                {
                    
                    //텍스트 삽입
                    if (data_Table2.Rows.Count > 0)
                    {
                        // 텍스트 및 값 삽입
                        switch (data_Table2.Rows.Count)
                        {
                            case 1:
                                lbPROD_Name1.Text = data_Table2.Rows[0][0].ToString();
                                lbPROD_QTY1.Text  = data_Table2.Rows[1][0].ToString() + " 개";
                                break;

                            case 2:
                                lbPROD_Name1.Text = data_Table2.Rows[0][0].ToString();
                                lbPROD_Name2.Text = data_Table2.Rows[1][0].ToString();
                                
                                lbPROD_QTY1.Text = data_Table2.Rows[0][1].ToString() + " 개";
                                lbPROD_QTY2.Text = data_Table2.Rows[1][1].ToString() + " 개";
                                break;

                            case 3:
                                lbPROD_Name1.Text = data_Table2.Rows[0][0].ToString();
                                lbPROD_Name2.Text = data_Table2.Rows[1][0].ToString();
                                lbPROD_Name3.Text = data_Table2.Rows[2][0].ToString();

                                lbPROD_QTY1.Text = data_Table2.Rows[0][1].ToString() + " 개";
                                lbPROD_QTY2.Text = data_Table2.Rows[1][1].ToString() + " 개";
                                lbPROD_QTY3.Text = data_Table2.Rows[2][1].ToString() + " 개";
                                break;
                            case 4:
                                lbPROD_Name1.Text = data_Table2.Rows[0][0].ToString();
                                lbPROD_Name2.Text = data_Table2.Rows[1][0].ToString();
                                lbPROD_Name3.Text = data_Table2.Rows[2][0].ToString();
                                lbPROD_Name4.Text = data_Table2.Rows[3][0].ToString();

                                lbPROD_QTY1.Text = data_Table2.Rows[0][1].ToString() + " 개";
                                lbPROD_QTY2.Text = data_Table2.Rows[1][1].ToString() + " 개";
                                lbPROD_QTY3.Text = data_Table2.Rows[2][1].ToString() + " 개";
                                lbPROD_QTY4.Text = data_Table2.Rows[3][1].ToString() + " 개";
                                break;
                            default:
                                // 다른 경우에 대한 처리
                                break;
                        };
                    }

                }

                using (DataTable data_Table = DatabaseManager.DB_Inquiry(PRODQTYDonut_Query))
                {
                    // 도넛 차트 적용
                    if (data_Table.Rows.Count > 0)
                    {
                        double TylenolQTY;
                        double AmodipineQTY;
                        double Suspen8QTY;
                        double SpeedPenQTY;
                        
                        Series series;
                        DataPoint dataPoint1;
                        DataPoint dataPoint2;
                        DataPoint dataPoint3;
                        DataPoint dataPoint4;

                        // 텍스트 및 값 삽입
                        switch (data_Table.Rows.Count)
                        {
                            case 1:
                                TylenolQTY = double.Parse(data_Table.Rows[0][1].ToString());

                                // 차트 옵션 설정
                                DChartTDayDefect.Series.Clear();
                                DChartTDayDefect.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                                DChartTDayDefect.ChartAreas[0].AxisX.MajorGrid.Enabled = false;


                                // 데이터 추가 및 색깔 설정 
                                series = new Series("donut_PROD_QTY");
                                series.ChartType = SeriesChartType.Doughnut;

                                dataPoint1 = new DataPoint();
                                dataPoint1.YValues = new double[] { TylenolQTY };
                                dataPoint1.Color = System.Drawing.Color.FromArgb(255, 126, 133, 154); // 잿빛 파랑 (126, 133, 154)

                                // 도넛 차트의 각 부분에 해당하는 데이터 포인트 추가
                                series.Points.Add(dataPoint1);

                                // 차트에 시리즈 추가
                                DChartTDayDefect.Series.Add(series);

                                break;

                            case 2:
                                TylenolQTY = double.Parse(data_Table.Rows[0][1].ToString());
                                AmodipineQTY = double.Parse(data_Table.Rows[1][1].ToString());

                                // 차트 옵션 설정
                                DChartTDayDefect.Series.Clear();
                                DChartTDayDefect.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                                DChartTDayDefect.ChartAreas[0].AxisX.MajorGrid.Enabled = false;


                                // 데이터 추가 및 색깔 설정 
                                series = new Series("donut_PROD_QTY");
                                series.ChartType = SeriesChartType.Doughnut;

                                dataPoint1 = new DataPoint();
                                dataPoint1.YValues = new double[] { TylenolQTY };
                                dataPoint1.Color = System.Drawing.Color.FromArgb(255, 126, 133, 154); // 잿빛 파랑 (126, 133, 154)

                                dataPoint2 = new DataPoint();
                                dataPoint2.YValues = new double[] { AmodipineQTY };
                                dataPoint2.Color = System.Drawing.Color.FromArgb(255, 248, 204, 124); // 노랑 (248, 204, 124)

                                // 도넛 차트의 각 부분에 해당하는 데이터 포인트 추가
                                series.Points.Add(dataPoint1);
                                series.Points.Add(dataPoint2);

                                // 차트에 시리즈 추가
                                DChartTDayDefect.Series.Add(series);
                                break;

                            case 3:
                                TylenolQTY = double.Parse(data_Table.Rows[0][1].ToString());
                                AmodipineQTY = double.Parse(data_Table.Rows[1][1].ToString());
                                Suspen8QTY = double.Parse(data_Table.Rows[2][1].ToString());

                                // 차트 옵션 설정
                                DChartTDayDefect.Series.Clear();
                                DChartTDayDefect.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                                DChartTDayDefect.ChartAreas[0].AxisX.MajorGrid.Enabled = false;


                                // 데이터 추가 및 색깔 설정 
                                series = new Series("donut_PROD_QTY");
                                series.ChartType = SeriesChartType.Doughnut;

                                dataPoint1 = new DataPoint();
                                dataPoint1.YValues = new double[] { TylenolQTY };
                                dataPoint1.Color = System.Drawing.Color.FromArgb(255, 126, 133, 154); // 잿빛 파랑 (126, 133, 154)

                                dataPoint2 = new DataPoint();
                                dataPoint2.YValues = new double[] { AmodipineQTY };
                                dataPoint2.Color = System.Drawing.Color.FromArgb(255, 248, 204, 124); // 노랑 (248, 204, 124)

                                dataPoint3 = new DataPoint();
                                dataPoint3.YValues = new double[] { Suspen8QTY };
                                dataPoint3.Color = System.Drawing.Color.FromArgb(255, 73, 163, 156); // 녹색 (73, 163, 156)

                                // 도넛 차트의 각 부분에 해당하는 데이터 포인트 추가
                                series.Points.Add(dataPoint1);
                                series.Points.Add(dataPoint2);
                                series.Points.Add(dataPoint3);

                                // 차트에 시리즈 추가
                                DChartTDayDefect.Series.Add(series);
                                break;
                            case 4:
                                TylenolQTY = double.Parse(data_Table.Rows[0][1].ToString());
                                AmodipineQTY = double.Parse(data_Table.Rows[1][1].ToString());
                                Suspen8QTY = double.Parse(data_Table.Rows[2][1].ToString());
                                SpeedPenQTY = double.Parse(data_Table.Rows[3][1].ToString());

                                // 차트 옵션 설정
                                DChartTDayDefect.Series.Clear();
                                DChartTDayDefect.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                                DChartTDayDefect.ChartAreas[0].AxisX.MajorGrid.Enabled = false;


                                // 데이터 추가 및 색깔 설정 
                                series = new Series("donut_PROD_QTY");
                                series.ChartType = SeriesChartType.Doughnut;

                                dataPoint1 = new DataPoint();
                                dataPoint1.YValues = new double[] { TylenolQTY };
                                dataPoint1.Color = System.Drawing.Color.FromArgb(255, 126, 133, 154); // 잿빛 파랑 (126, 133, 154)

                                dataPoint2 = new DataPoint();
                                dataPoint2.YValues = new double[] { AmodipineQTY };
                                dataPoint2.Color = System.Drawing.Color.FromArgb(255, 248, 204, 124); // 노랑 (248, 204, 124)

                                dataPoint3 = new DataPoint();
                                dataPoint3.YValues = new double[] { Suspen8QTY };
                                dataPoint3.Color = System.Drawing.Color.FromArgb(255, 73, 163, 156); // 녹색 (73, 163, 156)

                                dataPoint4 = new DataPoint();
                                dataPoint4.YValues = new double[] { SpeedPenQTY };
                                dataPoint4.Color = System.Drawing.Color.FromArgb(255, 9, 24, 71);    // 남색 (9, 24, 71)

                                // 도넛 차트의 각 부분에 해당하는 데이터 포인트 추가
                                series.Points.Add(dataPoint1);
                                series.Points.Add(dataPoint2);
                                series.Points.Add(dataPoint3);
                                series.Points.Add(dataPoint4);

                                // 차트에 시리즈 추가
                                DChartTDayDefect.Series.Add(series);
                                break;
                            default:
                                // 다른 경우에 대한 처리
                                break;
                        };
                       

                        

                        

                       

                    };
                }
            }
        }


        public int ExtractNumber(string input)
        {
            // 정규식을 사용하여 숫자만 추출
            string numberString = Regex.Match(input, @"\d+").Value;

            // 추출된 문자열을 정수로 변환
            if (int.TryParse(numberString, out int result))
            {
                return result;
            }
            else
            {
                // 변환 실패 시 기본값 반환 또는 예외 처리
                return 0; // 또는 throw new Exception("숫자 추출 실패");
            }
        }


        public string RemoveSubstring(string original, string substringToRemove)
        {
            // 제거할 부분 문자열이 원본 문자열에 포함되어 있다면 제거
            if (original.Contains(substringToRemove))
            {
                return original.Replace(substringToRemove, string.Empty);
            }

            // 제거할 부분 문자열이 원본 문자열에 포함되어 있지 않다면 그대로 반환
            return original;
        }

     

        private void cbPROD_RATE_Duration_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchPRODQty();
        }

       
    }

}
