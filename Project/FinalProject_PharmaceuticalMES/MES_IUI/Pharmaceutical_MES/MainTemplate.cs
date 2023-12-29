using Pharmaceutical_MES.DefectStatus;
using Pharmaceutical_MES.Monitoring;
using Pharmaceutical_MES.OrderMGR.ORDER_MGR;
using Pharmaceutical_MES.OrderMGR.SALES_MGR;
using Pharmaceutical_MES.ProcessMGR.BOMMGR;
using Pharmaceutical_MES.ProcessMGR.ProcessMGR;
using Pharmaceutical_MES.StandardInfoMGR.UserSTD;
using Pharmaceutical_MES.StatusManagement.InputStatus;
using Pharmaceutical_MES.StatusMGR.EquipmentStatus;
using Pharmaceutical_MES.StatusMGR.MaterialStatus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewPage;

namespace Pharmaceutical_MES
{
    public partial class MainTemplate : Form, ISideBar
    {
        private int LeftWidth;
        public MainTemplate()
        {
            InitializeComponent();

            LeftWidth = paneSideMenu.Width;

            initializeUI();
        }

        public void initializeUI()
        {
            // 크기 화면 지정 (해상도) 
            //Size = new System.Drawing.Size(2256, 1504);

            // 화면 최대화 세팅
            this.WindowState = FormWindowState.Maximized;

            // 서브메뉴 숨기기
            //hideSubMenu();

            // 메인화면 설정
            openChildForm(new MainPage.MainPage());

        }


        //서브 메뉴 가리기
        public void hideSubMenu()
        {
            if (panelStdInfoSubMenu.Visible == true)
                panelStdInfoSubMenu.Visible = false;
            if(panelPrcMgrSubMenu.Visible == true)
                panelPrcMgrSubMenu.Visible = false;
        }

        // 서브메뉴 열고 닫기
        public void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {   
                //hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        
        


        // 패널 영역 내에 원하는 childForm 삽입
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false; // 보조적인 창으로 활용 위함.
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            childForm.Tag = childForm;
            childForm.BringToFront(); // form 배치 앞으로.
            childForm.Show();
        }


     
        //private void buttonColor()
        //{
        //    btnMonitoringProduction.BackColor = Color.FromArgb(225, 229, 239);
        //    btnUserMGR.BackColor = Color.FromArgb(225, 229, 239);
        //    btnProcProdMGR.BackColor = Color.FromArgb(225, 229, 239);
        //    btnProcProcMGR.BackColor = Color.FromArgb(225, 229, 239);
        //    btnProcBomMGR.BackColor = Color.FromArgb(225, 229, 239);
        //    btnOrderSalesMgr.BackColor = Color.FromArgb(225, 229, 239);
        //    btnOrderOrderMGR.BackColor = Color.FromArgb(225, 229, 239);
        //    btnProductuonWorkOrder.BackColor = Color.FromArgb(225, 229, 239);
        //    btnStatusInventory.BackColor = Color.FromArgb(225, 229, 239);
        //    btnStatusInput.BackColor = Color.FromArgb(225, 229, 239);
        //    btnStatusDefect.BackColor = Color.FromArgb(225, 229, 239);
        //    btnStatusProduction.BackColor = Color.FromArgb(225, 229, 239);
        //    btnHome.BackColor = Color.FromArgb(225, 229, 239);
        //}
     


        
        
        


        // 메인 메뉴 클릭 -> 서브메뉴 열기 닫기
        private void btnMonitoring_Click(object sender, EventArgs e)
        {
            showSubMenu(panelMonitoringSubMenu);
        }

        private void btnRefInfo_Click(object sender, EventArgs e)
        {
            showSubMenu(panelStdInfoSubMenu);
        }

        private void btnProdRelation_Click(object sender, EventArgs e)
        {
            showSubMenu(panelPrcMgrSubMenu);
        }

        private void btnOrderMgr_Click(object sender, EventArgs e)
        {
            showSubMenu(panelOrderMgrSubMenu);
        }

        private void btnProductionMGR_Click(object sender, EventArgs e)
        {
            showSubMenu(panelProductionMgrSubMenu);
        }

        private void btnStatusMGR_Click(object sender, EventArgs e)
        {
            showSubMenu(panelStatusMgrSubMenu);
        }

        private void btnMainHome_Click(object sender, EventArgs e)
        {
            showSubMenu(panelMainSubMenu);
        }


        //---------------------------------------
        // 버튼 클릭시 색깔 변경


        


        //---------------------------------------


        private void btnMonitoringProduction_Click(object sender, EventArgs e)
        {
            openChildForm(new ProductionMonitoring());
            // 선택된 버튼 사각형 색깔지정 -> 후에 폼 안에 윤곽으로 그려진 버튼을 넣고, 버튼만 색깔 이와 같이 바꾸는 방식으로 수정.
            btnMonitoringProduction.BackColor = Color.FromArgb(167, 183, 220);

            btnUserMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnProcProdMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnProcProcMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnProcBomMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnOrderSalesMgr.BackColor = Color.FromArgb(225, 229, 239);
            btnOrderOrderMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnProductuonWorkOrder.BackColor = Color.FromArgb(225, 229, 239);
            btnStatusInventory.BackColor = Color.FromArgb(225, 229, 239);
            btnStatusInput.BackColor = Color.FromArgb(225, 229, 239);
            btnStatusDefect.BackColor = Color.FromArgb(225, 229, 239);
            btnStatusProduction.BackColor = Color.FromArgb(225, 229, 239);
            btnHome.BackColor = Color.FromArgb(225, 229, 239);
        }

        private void btnUserMGR_Click(object sender, EventArgs e)
        {

            openChildForm(new UserInfo());
            // 선택된 버튼 사각형 색깔지정 -> 후에 폼 안에 윤곽으로 그려진 버튼을 넣고, 버튼만 색깔 이와 같이 바꾸는 방식으로 수정.
            btnUserMGR.BackColor = Color.FromArgb(167, 183, 220);

            btnMonitoringProduction.BackColor = Color.FromArgb(225, 229, 239);
            btnProcProdMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnProcProcMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnProcBomMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnOrderSalesMgr.BackColor = Color.FromArgb(225, 229, 239);
            btnOrderOrderMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnProductuonWorkOrder.BackColor = Color.FromArgb(225, 229, 239);
            btnStatusInventory.BackColor = Color.FromArgb(225, 229, 239);
            btnStatusInput.BackColor = Color.FromArgb(225, 229, 239);
            btnStatusDefect.BackColor = Color.FromArgb(225, 229, 239);
            btnStatusProduction.BackColor = Color.FromArgb(225, 229, 239);
            btnHome.BackColor = Color.FromArgb(225, 229, 239);
        }

        private void btnProcProdMGR_Click(object sender, EventArgs e)
        {
            openChildForm(new ProudctMgr());
            btnProcProdMGR.BackColor = Color.FromArgb(167, 183, 220);

            btnMonitoringProduction.BackColor = Color.FromArgb(225, 229, 239);
            btnUserMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnProcProcMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnProcBomMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnOrderSalesMgr.BackColor = Color.FromArgb(225, 229, 239);
            btnOrderOrderMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnProductuonWorkOrder.BackColor = Color.FromArgb(225, 229, 239);
            btnStatusInventory.BackColor = Color.FromArgb(225, 229, 239);
            btnStatusInput.BackColor = Color.FromArgb(225, 229, 239);
            btnStatusDefect.BackColor = Color.FromArgb(225, 229, 239);
            btnStatusProduction.BackColor = Color.FromArgb(225, 229, 239);
            btnHome.BackColor = Color.FromArgb(225, 229, 239);
        }

        private void btnProcProcMGR_Click(object sender, EventArgs e)
        {
            openChildForm(new ProcessMgr());
            btnProcProcMGR.BackColor = Color.FromArgb(167, 183, 220);

            btnMonitoringProduction.BackColor = Color.FromArgb(225, 229, 239);
            btnUserMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnProcProdMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnProcBomMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnOrderSalesMgr.BackColor = Color.FromArgb(225, 229, 239);
            btnOrderOrderMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnProductuonWorkOrder.BackColor = Color.FromArgb(225, 229, 239);
            btnStatusInventory.BackColor = Color.FromArgb(225, 229, 239);
            btnStatusInput.BackColor = Color.FromArgb(225, 229, 239);
            btnStatusDefect.BackColor = Color.FromArgb(225, 229, 239);
            btnStatusProduction.BackColor = Color.FromArgb(225, 229, 239);
            btnHome.BackColor = Color.FromArgb(225, 229, 239);
        }

        private void btnProcBomMGR_Click(object sender, EventArgs e)
        {
            openChildForm(new BOMMGR());
            btnProcBomMGR.BackColor = Color.FromArgb(167, 183, 220);

            btnMonitoringProduction.BackColor = Color.FromArgb(225, 229, 239);
            btnUserMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnProcProdMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnProcProcMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnOrderSalesMgr.BackColor = Color.FromArgb(225, 229, 239);
            btnOrderOrderMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnProductuonWorkOrder.BackColor = Color.FromArgb(225, 229, 239);
            btnStatusInventory.BackColor = Color.FromArgb(225, 229, 239);
            btnStatusInput.BackColor = Color.FromArgb(225, 229, 239);
            btnStatusDefect.BackColor = Color.FromArgb(225, 229, 239);
            btnStatusProduction.BackColor = Color.FromArgb(225, 229, 239);
            btnHome.BackColor = Color.FromArgb(225, 229, 239);
        }

        private void btnOrderSalesMgr_Click(object sender, EventArgs e)
        {
            openChildForm(new SALES_MGR());
            btnOrderSalesMgr.BackColor = Color.FromArgb(167, 183, 220);

            btnMonitoringProduction.BackColor = Color.FromArgb(225, 229, 239);
            btnUserMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnProcProdMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnProcProcMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnProcBomMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnOrderOrderMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnProductuonWorkOrder.BackColor = Color.FromArgb(225, 229, 239);
            btnStatusInventory.BackColor = Color.FromArgb(225, 229, 239);
            btnStatusInput.BackColor = Color.FromArgb(225, 229, 239);
            btnStatusDefect.BackColor = Color.FromArgb(225, 229, 239);
            btnStatusProduction.BackColor = Color.FromArgb(225, 229, 239);
            btnHome.BackColor = Color.FromArgb(225, 229, 239);
        }

        private void btnOrderOrderMGR_Click(object sender, EventArgs e)
        {
            openChildForm(new ORDER_MGR());
            btnOrderOrderMGR.BackColor = Color.FromArgb(167, 183, 220);

            btnMonitoringProduction.BackColor = Color.FromArgb(225, 229, 239);
            btnUserMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnProcProdMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnProcProcMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnProcBomMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnOrderSalesMgr.BackColor = Color.FromArgb(225, 229, 239);
            btnProductuonWorkOrder.BackColor = Color.FromArgb(225, 229, 239);
            btnStatusInventory.BackColor = Color.FromArgb(225, 229, 239);
            btnStatusInput.BackColor = Color.FromArgb(225, 229, 239);
            btnStatusDefect.BackColor = Color.FromArgb(225, 229, 239);
            btnStatusProduction.BackColor = Color.FromArgb(225, 229, 239);
            btnHome.BackColor = Color.FromArgb(225, 229, 239);
        }

        private void btnProductuonWorkOrder_Click(object sender, EventArgs e)
        {
            openChildForm(new 작업지시());
            btnProductuonWorkOrder.BackColor = Color.FromArgb(167, 183, 220);

            btnMonitoringProduction.BackColor = Color.FromArgb(225, 229, 239);
            btnUserMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnProcProdMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnProcProcMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnProcBomMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnOrderSalesMgr.BackColor = Color.FromArgb(225, 229, 239);
            btnOrderOrderMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnStatusInventory.BackColor = Color.FromArgb(225, 229, 239);
            btnStatusInput.BackColor = Color.FromArgb(225, 229, 239);
            btnStatusDefect.BackColor = Color.FromArgb(225, 229, 239);
            btnStatusProduction.BackColor = Color.FromArgb(225, 229, 239);
            btnHome.BackColor = Color.FromArgb(225, 229, 239);
        }

        private void btnStatusInventory_Click(object sender, EventArgs e)
        {
            openChildForm(new InventoryStatus());
            btnStatusInventory.BackColor = Color.FromArgb(167, 183, 220);

            btnMonitoringProduction.BackColor = Color.FromArgb(225, 229, 239);
            btnUserMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnProcProdMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnProcProcMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnProcBomMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnOrderSalesMgr.BackColor = Color.FromArgb(225, 229, 239);
            btnOrderOrderMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnProductuonWorkOrder.BackColor = Color.FromArgb(225, 229, 239);
            btnStatusInput.BackColor = Color.FromArgb(225, 229, 239);
            btnStatusDefect.BackColor = Color.FromArgb(225, 229, 239);
            btnStatusProduction.BackColor = Color.FromArgb(225, 229, 239);
            btnHome.BackColor = Color.FromArgb(225, 229, 239);
        }

        private void btnStatusInput_Click(object sender, EventArgs e)
        {
            openChildForm(new InputStatus());
            btnStatusInput.BackColor = Color.FromArgb(167, 183, 220);

            btnMonitoringProduction.BackColor = Color.FromArgb(225, 229, 239);
            btnUserMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnProcProdMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnProcProcMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnProcBomMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnOrderSalesMgr.BackColor = Color.FromArgb(225, 229, 239);
            btnOrderOrderMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnProductuonWorkOrder.BackColor = Color.FromArgb(225, 229, 239);
            btnStatusInventory.BackColor = Color.FromArgb(225, 229, 239);
            btnStatusDefect.BackColor = Color.FromArgb(225, 229, 239);
            btnStatusProduction.BackColor = Color.FromArgb(225, 229, 239);
            btnHome.BackColor = Color.FromArgb(225, 229, 239);
        }

        private void btnStatusDefect_Click(object sender, EventArgs e)
        {
            openChildForm(new EquipmentStatus());
            btnStatusDefect.BackColor = Color.FromArgb(167, 183, 220);

            btnMonitoringProduction.BackColor = Color.FromArgb(225, 229, 239);
            btnUserMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnProcProdMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnProcProcMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnProcBomMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnOrderSalesMgr.BackColor = Color.FromArgb(225, 229, 239);
            btnOrderOrderMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnProductuonWorkOrder.BackColor = Color.FromArgb(225, 229, 239);
            btnStatusInventory.BackColor = Color.FromArgb(225, 229, 239);
            btnStatusInput.BackColor = Color.FromArgb(225, 229, 239);
            btnStatusProduction.BackColor = Color.FromArgb(225, 229, 239);
            btnHome.BackColor = Color.FromArgb(225, 229, 239);
        }

        private void btnStatusProduction_Click(object sender, EventArgs e)
        {
            openChildForm(new ProductionInquery());
            btnStatusProduction.BackColor = Color.FromArgb(167, 183, 220);

            btnMonitoringProduction.BackColor = Color.FromArgb(225, 229, 239);
            btnUserMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnProcProdMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnProcProcMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnProcBomMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnOrderSalesMgr.BackColor = Color.FromArgb(225, 229, 239);
            btnOrderOrderMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnProductuonWorkOrder.BackColor = Color.FromArgb(225, 229, 239);
            btnStatusInventory.BackColor = Color.FromArgb(225, 229, 239);
            btnStatusInput.BackColor = Color.FromArgb(225, 229, 239);
            btnStatusDefect.BackColor = Color.FromArgb(225, 229, 239);
            btnHome.BackColor = Color.FromArgb(225, 229, 239);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            openChildForm(new MainPage.MainPage());
            btnHome.BackColor = Color.FromArgb(167, 183, 220);

            btnMonitoringProduction.BackColor = Color.FromArgb(225, 229, 239);
            btnUserMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnProcProdMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnProcProcMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnProcBomMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnOrderSalesMgr.BackColor = Color.FromArgb(225, 229, 239);
            btnOrderOrderMGR.BackColor = Color.FromArgb(225, 229, 239);
            btnProductuonWorkOrder.BackColor = Color.FromArgb(225, 229, 239);
            btnStatusInventory.BackColor = Color.FromArgb(225, 229, 239);
            btnStatusInput.BackColor = Color.FromArgb(225, 229, 239);
            btnStatusDefect.BackColor = Color.FromArgb(225, 229, 239);
            btnStatusProduction.BackColor = Color.FromArgb(225, 229, 239);
        }

        private void MainTemplate_Load(object sender, EventArgs e)
        {
            initializeUI();
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            int width = 0;

            if (sender == btnHide)
            {
                width = this.LeftWidth;

                for (int i = 0; i < LeftWidth; i++)
                {
                    width -= 1;

                    if (i % 5 == 1)
                        paneSideMenu.Width = width;
                }
                paneSideMenu.Width = width;
            }

            if (sender == btnShow)
            {
                for (int i = 0; i < LeftWidth; i++)
                {
                    width += 1;

                    if (i % 5 == 1)
                        paneSideMenu.Width = width;
                }
                paneSideMenu.Width = width;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }







        //-------------------------- 클릭 시 자식 폼 생성--------------------------





        // 재고현황









    }
}
