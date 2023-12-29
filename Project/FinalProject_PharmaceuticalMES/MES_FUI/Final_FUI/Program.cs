using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_FUI
{
    internal static class Program
    {
        // 프로그램 시작 시 한번만 실행됨
        [STAThread]
        static void Main()
         {
            Application.EnableVisualStyles();
             Application.SetCompatibleTextRenderingDefault(false);

            // 프로그램 시작 시 DB 연결
            DatabaseManager.GetConnection();
            Application.ApplicationExit += Application_ApplicationExit; // 프로그램 종료 시 DB 연결 해제 이벤트 추가
            //Application.Run(new Form1());
            Application.Run(new 로그인());
        }
        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            // 프로그램 종료 시 DB 연결 해제
            DatabaseManager.Disconnect();
        }
    }
}
