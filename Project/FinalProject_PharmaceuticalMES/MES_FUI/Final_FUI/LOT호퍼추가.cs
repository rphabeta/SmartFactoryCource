using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Media.Media3D;
using System.Xml.Serialization;

namespace Final_FUI
{
    public partial class LOT호퍼추가 : Form
    {
        public static string hpid;   //저장소 아이디 
        public static string woid;
        public static string eqptid;
        public static string procid;
        public static string prodid;
        public static bool start;
        //public static string eqpt_id; //설비 아이디
        public int nextId;

        public static string lotId;
        public static string mlotId;
        public static string lastLotIdQuery;
        public static int currqty = 0;
        public static string selectedEquipment { get; set; }

        public Random num = new Random();

        public LOT호퍼추가(string HPID = "", string EQPTID = "", string PROCID = "", string PRODID = "", string WOID = "", bool START = false)
        {
            LOT호퍼추가.hpid = HPID;
            LOT호퍼추가.eqptid = EQPTID;
            LOT호퍼추가.procid = PROCID;
            LOT호퍼추가.prodid = PRODID;
            LOT호퍼추가.woid = WOID;
            LOT호퍼추가.start = START;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Hp_Update()
        {
            using (var conn = DatabaseManager.GetConnection())
            {
                //수정 필요함
                // 현재 날짜를 가져옴
                string currentDate = DateTime.Now.ToString("yyyyMMdd");
                // MLOTID의 마지막 값 추출, 만약 오늘 첫 데이터라면 0으로 설정
                lastLotIdQuery = $@"SELECT 'L'  || TO_CHAR(SYSDATE, 'YYYYMMDD') || NVL(TO_CHAR(MAX(SUBSTR(LOTID, 10, 3)) + 1, 'FM000'), '001') 
                            FROM LOT WHERE LOTID LIKE 'L' || TO_CHAR(SYSDATE, 'YYYYMMDD') || '%'";

                using (var cmd = new OracleCommand(lastLotIdQuery, conn))
                {
                    object result = cmd.ExecuteScalar();
                    lotId = Convert.ToString(result);
                    mlotId = "M" + lotId;
                    string selectCurrqty = $"SELECT CURRQTY FROM STORE_STORAGE WHERE STORID = '{LOT호퍼추가.hpid}'";
                    using (var cmd2 = new OracleCommand(selectCurrqty, conn))
                    {
                        currqty = Convert.ToInt32(cmd2.ExecuteScalar());
                    }

                    using (var transaction = conn.BeginTransaction()) // 트랜잭션 시작
                    {
                        try
                        {
                            //STORE_STORAGE 수정
                            //과립, 타정은 수량이 그대로, 포장일때는 수량이 0
                            string updateSql = $@"UPDATE STORE_STORAGE SET CURRQTY = (DECODE( '{LOT호퍼추가.eqptid}', (SELECT EQPTID FROM EQUIPMENT WHERE EQPTGRID = 'BX000'), 0, {currqty}))
                        , EQPTID = (DECODE( '{LOT호퍼추가.eqptid}', (SELECT EQPTID FROM EQUIPMENT WHERE EQPTGRID = 'BX000'), NULL, '{LOT호퍼추가.eqptid}'))
                          WHERE STORID = '{LOT호퍼추가.hpid}'";

                            string insertStorage = $@"INSERT INTO STORAGEMATERIALLOT(STORID
                                                                                , MLOTID
                                                                                , MLOTQTY
                                                                                , MLOTUNIT
                                                                                , INSUSER
                                                                                , INSDTTM
                                                                                 ) VALUES (
                                                                                  '{LOT호퍼추가.hpid}'
                                                                                , '{mlotId}'
                                                                                , {currqty}
                                                                                , 'KG'
                                                                                , '{로그인.userid}'
                                                                                , SYSDATE
                                                                                )";

                            string insertLot = $@"
                    INSERT INTO LOT(
                        LOTID,
                        LOTSTAT,
                        LOTCRDTTM,
                        LOTSTDTTM,
                        LOTEDDTTM,
                        WOID,
                        LOTCRQTY,
                        LOTQTY,
                        EQPTID,
                        WORKERID,
                        INSUSER,
                        INSDTTM
                    )
                    VALUES (
                        '{lotId}',
                        'E',　
                        TO_CHAR(SYSDATE, 'YY/MM/DD HH24:MI:SS'),
                        TO_CHAR(SYSDATE, 'YY/MM/DD HH24:MI:SS'),
                        TO_CHAR(SYSDATE + INTERVAL '1' MINUTE, 'YY/MM/DD HH24:MI:SS'),
                        '{LOT호퍼추가.woid}',
                        {currqty},
                        {currqty},
                        '{LOT호퍼추가.eqptid}',
                        '{로그인.userid}',
                        '{로그인.userid}',
                        SYSDATE
                    )";

                            string insert_LotMt = $@"INSERT INTO LOTMATERIAL (LOTID, MLOTID, INPUTQTY, PROCID, INSDTTM) 
                            VALUES ('{lotId}', '{mlotId}', {currqty}, '{WO_Main.Selected_procid}', TO_CHAR(SYSDATE, 'YYYYMMDD'))";

                            using (var cmd2 = new OracleCommand())
                            {
                                cmd2.Connection = conn;
                                cmd2.Transaction = transaction; // 트랜잭션 설정

                                // 데이터베이스 업데이트 쿼리 실행
                                cmd2.CommandText = updateSql;
                                cmd2.ExecuteNonQuery();
                                cmd2.CommandText = insertStorage;
                                cmd2.ExecuteNonQuery();
                                cmd2.CommandText = insertLot;
                                cmd2.ExecuteNonQuery();
                                cmd2.CommandText = insert_LotMt;
                                cmd2.ExecuteNonQuery();

                                transaction.Commit(); // 모든 쿼리가 성공하면 트랜잭션 커밋
                                materialLot_add(currqty); // materialLot 추가 (LOT에 들어갈 원재료LOT)
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback(); // 하나라도 실패하면 롤백
                            MessageBox.Show($"오류 발생: {ex.Message}");
                        }
                    }
                }
            }
        }
        private void materialLot_add(int currqty)
        {
            List<(string mtrId, double mtrQty)> mtrList = new List<(string mtrId, double mtrQty)>();

            using (var conn = DatabaseManager.GetConnection())
            {
                string select_mtrl = $"SELECT MTRLID, RATE FROM BOM WHERE PRODID = '{LOT호퍼추가.prodid}'";

                using (var cmd = new OracleCommand(select_mtrl, conn))
                {
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            string mtrId = rdr["MTRLID"].ToString();
                            double rate = Convert.ToDouble(rdr["RATE"]);
                            double mtrQty = rate * currqty;

                            mtrList.Add((mtrId, mtrQty));
                        }
                    }
                }

                using (var transaction = conn.BeginTransaction()) // 트랜잭션 시작
                {
                    try
                    {
                        foreach (var item in mtrList)
                        {
                            string materiallot_add = $@"
                        INSERT INTO MATERIALLOT
                        (MLOTID, MTRLID, C_QTY, ACTDATE, INSDTTM, WORKERID)
                        VALUES (
                            '{mlotId}',
                            '{item.mtrId}',
                            {item.mtrQty},
                            TO_TIMESTAMP(TO_CHAR(SYSDATE, 'YY/MM/DD HH24:MI:SS '), 'YY/MM/DD HH24:MI:SS '),
                            TO_TIMESTAMP(TO_CHAR(SYSDATE, 'YY/MM/DD HH24:MI:SS '), 'YY/MM/DD HH24:MI:SS '),
                            '{로그인.userid}'
                        )";
                            using (var cmdInsert = new OracleCommand(materiallot_add, conn))
                            {
                                cmdInsert.Transaction = transaction; // 트랜잭션 설정

                                try
                                {
                                    // 데이터베이스 업데이트 쿼리 실행
                                    cmdInsert.ExecuteNonQuery();
                                }
                                catch (OracleException ex)
                                {
                                    if (ex.Number == 1)
                                    {
                                        // 이미 해당 MLOTID와 MTRLID가 존재하므로, 여기서 필요한 예외 처리를 수행하거나 무시
                                        MessageBox.Show("이미 중복된 데이터가 존재합니다.");
                                    }
                                    else
                                    {
                                        // 다른 오류는 다시 throw
                                        throw;
                                    }
                                }
                            }
                        }

                        transaction.Commit(); // 모든 쿼리가 성공하면 트랜잭션 커밋
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback(); // 하나라도 실패하면 롤백
                        MessageBox.Show($"오류 발생: {ex.Message}");
                    }
                }
            }
        }


        private void LOT호퍼추가_Load(object sender, EventArgs e)
        {
            string selectCurrqty = $"SELECT CURRQTY FROM STORE_STORAGE WHERE STORID = '{LOT호퍼추가.hpid}'";
            using (var conn = DatabaseManager.GetConnection())
            {
                using (var cmd = new OracleCommand(selectCurrqty, conn))
                {
                    currqty = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            textBox1.Text = currqty.ToString();
            textBox1.ReadOnly = true;
        }

        private void ProQtyUpdate()
        {
            string updateSql = $"UPDATE WORKORDER SET PRODQTY = NVL(PRODQTY,0) + {LOT호퍼추가.currqty} WHERE WOID = '{LOT호퍼추가.woid}'";
            using (var conn = DatabaseManager.GetConnection())
            {
                using (var transaction = conn.BeginTransaction()) // 트랜잭션 시작
                {
                    using (var cmd = new OracleCommand(updateSql, conn))
                    {
                        cmd.Transaction = transaction;
                        cmd.ExecuteNonQuery();
                        cmd.Transaction.Commit();
                    }
                }
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            과립 existingForm = Application.OpenForms.OfType<과립>().FirstOrDefault(); // 현재 열린 공정 폼
            this.Close();
            if (existingForm != null) // 과립 폼이 열려있으면
            {
                if (LOT호퍼추가.start) // 1호기, 2호기 시작 눌렀을때만 
                {
                    await existingForm.Eqpt_Start(LOT호퍼추가.eqptid); // 애니메이션 동작
                }
            }
            // LOT, LOTMATERIAL(LOT에 들어갈 원재료LOT), MATERIALLOT(원재료LOT 질량) 추가
            // STORAGE_MATERIALLOT(호퍼별 원재료LOT) 추가 
            Hp_Update();
            EqptDataUpdate(); // 설비 수집 데이터 업데이트
            ProQtyUpdate(); // lot추가에 따른 생산수량 증가
            
            // LOT호퍼추가.procid 값으로 원재료조회 창을 찾기
            원재료조회 조회 = Application.OpenForms.OfType<원재료조회>()
                                                   .FirstOrDefault();
            if (!string.IsNullOrEmpty(LOT호퍼추가.procid)) // 호퍼 리로드
            {
                // 조회된 창이 null이 아닌 경우에 Store_Check 메서드 호출
                if (조회 != null)
                {
                    //원재료조회.eqptid = LOT호퍼추가.eqptid;
                    //원재료조회.prodid = LOT호퍼추가.prodid;
                    //원재료조회.procid = LOT호퍼추가.procid;
                    조회.Store_Check();
                }
            }
            if(existingForm != null)
            {
                existingForm.RefreshAllGridViews(); // 현재 열린 공정 폼 리로드    
            }
            WO_Main existingMainForm = Application.OpenForms.OfType<WO_Main>().FirstOrDefault();    
            if (existingMainForm != null) // 메인 폼이 열려있으면
            {
                existingMainForm.ReLoad(); 
            }
            //조회.Close();
            
        }

        private void EqptDataUpdate()
        {
            using (var conn = DatabaseManager.GetConnection())
            {
                using (var transaction = conn.BeginTransaction()) // 트랜잭션 시작
                {
                    try
                    {
                        int[] randomValues = { num.Next(60, 67), num.Next(30, 35), 1 + (1 + num.Next(13, 17) / 100), num.Next(20, 23), num.Next(200, 214), num.Next(450, 470) };

                        int randomValue = 0;
                        string[] sqlStatements = new string[]
                        {
                $"INSERT INTO EQPTDATACOLLECT(LOTID, EQPTITEMID, EQPTITEMVALUE, EQPTITEMDTTM) VALUES('{lotId}', 'ITM001', {randomValues[0]}, SYSDATE)",
                $"INSERT INTO EQPTDATACOLLECT(LOTID, EQPTITEMID, EQPTITEMVALUE, EQPTITEMDTTM) VALUES('{lotId}', 'ITM002', {randomValues[1]}, SYSDATE)",
                $"INSERT INTO EQPTDATACOLLECT(LOTID, EQPTITEMID, EQPTITEMVALUE, EQPTITEMDTTM) VALUES('{lotId}', 'ITM003', {randomValues[2]}, SYSDATE)",
                $"INSERT INTO EQPTDATACOLLECT(LOTID, EQPTITEMID, EQPTITEMVALUE, EQPTITEMDTTM) VALUES('{lotId}', 'ITM004', {randomValues[3]}, SYSDATE)",
                $"INSERT INTO EQPTDATACOLLECT(LOTID, EQPTITEMID, EQPTITEMVALUE, EQPTITEMDTTM) VALUES('{lotId}', 'ITM005', {randomValues[4]}, SYSDATE)",
                $"INSERT INTO EQPTDATACOLLECT(LOTID, EQPTITEMID, EQPTITEMVALUE, EQPTITEMDTTM) VALUES('{lotId}', 'ITM006', {randomValues[5]}, SYSDATE)"
                        };
                        string sqlStatement = "";
                        for (int i = 0; i < sqlStatements.Length; i++)
                        {
                            sqlStatement = sqlStatements[i];
                            randomValue = randomValues[i];

                            using (var cmd = new OracleCommand(sqlStatement, conn))
                            {
                                cmd.Transaction = transaction; // 커맨드에 트랜잭션 설정
                                cmd.ExecuteNonQuery();
                            }
                        }
                        // 다른 작업이 필요하면 여기에 추가

                        transaction.Commit(); // 트랜잭션 커밋
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback(); // 예외 발생 시 롤백
                        MessageBox.Show($"오류 발생: {ex.Message}");
                    }
                }
            }

        }
    }
}

