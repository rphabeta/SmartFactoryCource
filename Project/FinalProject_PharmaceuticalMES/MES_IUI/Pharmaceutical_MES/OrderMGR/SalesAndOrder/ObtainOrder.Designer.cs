namespace Pharmaceutical_MES
{
    partial class ObtainOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cbOrderCode = new System.Windows.Forms.ComboBox();
            this.dtpOrderStart = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpOrderEnd = new System.Windows.Forms.DateTimePicker();
            this.btnEnquire = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.tbProductName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvOrderInfo = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.cbProductName = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnInstructionAdd = new System.Windows.Forms.Button();
            this.tbProductQTY = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbSaleCode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpSaleDeadLine = new System.Windows.Forms.DateTimePicker();
            this.tbSaleQty = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbSoFirm = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbRegistOrderQTY = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dgvMaterialRegist = new System.Windows.Forms.DataGridView();
            this.label15 = new System.Windows.Forms.Label();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnEnquireAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterialRegist)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "수주관리";
            // 
            // cbOrderCode
            // 
            this.cbOrderCode.FormattingEnabled = true;
            this.cbOrderCode.Location = new System.Drawing.Point(198, 101);
            this.cbOrderCode.Name = "cbOrderCode";
            this.cbOrderCode.Size = new System.Drawing.Size(121, 26);
            this.cbOrderCode.TabIndex = 1;
            // 
            // dtpOrderStart
            // 
            this.dtpOrderStart.Location = new System.Drawing.Point(437, 101);
            this.dtpOrderStart.Name = "dtpOrderStart";
            this.dtpOrderStart.Size = new System.Drawing.Size(200, 28);
            this.dtpOrderStart.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "수주번호(Code)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(351, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "수주일자";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(898, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "제품명";
            // 
            // dtpOrderEnd
            // 
            this.dtpOrderEnd.Location = new System.Drawing.Point(658, 101);
            this.dtpOrderEnd.Name = "dtpOrderEnd";
            this.dtpOrderEnd.Size = new System.Drawing.Size(200, 28);
            this.dtpOrderEnd.TabIndex = 6;
            // 
            // btnEnquire
            // 
            this.btnEnquire.Location = new System.Drawing.Point(1245, 102);
            this.btnEnquire.Name = "btnEnquire";
            this.btnEnquire.Size = new System.Drawing.Size(75, 23);
            this.btnEnquire.TabIndex = 7;
            this.btnEnquire.Text = "조회";
            this.btnEnquire.UseVisualStyleBackColor = true;
            this.btnEnquire.Click += new System.EventHandler(this.btnEnquire_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(1326, 102);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "초기화";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // tbProductName
            // 
            this.tbProductName.Location = new System.Drawing.Point(1001, 101);
            this.tbProductName.Name = "tbProductName";
            this.tbProductName.Size = new System.Drawing.Size(100, 28);
            this.tbProductName.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 18);
            this.label5.TabIndex = 10;
            this.label5.Text = "수주정보목록";
            // 
            // dgvOrderInfo
            // 
            this.dgvOrderInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderInfo.Location = new System.Drawing.Point(60, 236);
            this.dgvOrderInfo.Name = "dgvOrderInfo";
            this.dgvOrderInfo.RowHeadersWidth = 62;
            this.dgvOrderInfo.RowTemplate.Height = 30;
            this.dgvOrderInfo.Size = new System.Drawing.Size(1304, 150);
            this.dgvOrderInfo.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(57, 488);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 18);
            this.label6.TabIndex = 13;
            this.label6.Text = "제품명";
            // 
            // cbProductName
            // 
            this.cbProductName.FormattingEnabled = true;
            this.cbProductName.Location = new System.Drawing.Point(153, 480);
            this.cbProductName.Name = "cbProductName";
            this.cbProductName.Size = new System.Drawing.Size(121, 26);
            this.cbProductName.TabIndex = 12;
            this.cbProductName.SelectedIndexChanged += new System.EventHandler(this.cbProductName_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(57, 429);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 18);
            this.label7.TabIndex = 14;
            this.label7.Text = "수주등록";
            // 
            // btnInstructionAdd
            // 
            this.btnInstructionAdd.Location = new System.Drawing.Point(467, 429);
            this.btnInstructionAdd.Name = "btnInstructionAdd";
            this.btnInstructionAdd.Size = new System.Drawing.Size(172, 23);
            this.btnInstructionAdd.TabIndex = 15;
            this.btnInstructionAdd.Text = "작업지시 목록 추가";
            this.btnInstructionAdd.UseVisualStyleBackColor = true;
            this.btnInstructionAdd.Click += new System.EventHandler(this.btnInstructionAdd_Click);
            // 
            // tbProductQTY
            // 
            this.tbProductQTY.Location = new System.Drawing.Point(153, 521);
            this.tbProductQTY.Name = "tbProductQTY";
            this.tbProductQTY.Size = new System.Drawing.Size(100, 28);
            this.tbProductQTY.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(56, 532);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 18);
            this.label8.TabIndex = 16;
            this.label8.Text = "현재재고";
            // 
            // tbSaleCode
            // 
            this.tbSaleCode.Location = new System.Drawing.Point(153, 573);
            this.tbSaleCode.Name = "tbSaleCode";
            this.tbSaleCode.Size = new System.Drawing.Size(100, 28);
            this.tbSaleCode.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(56, 583);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 18);
            this.label9.TabIndex = 18;
            this.label9.Text = "수주번호";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(52, 628);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 18);
            this.label10.TabIndex = 21;
            this.label10.Text = "납기일자";
            // 
            // dtpSaleDeadLine
            // 
            this.dtpSaleDeadLine.Location = new System.Drawing.Point(144, 627);
            this.dtpSaleDeadLine.Name = "dtpSaleDeadLine";
            this.dtpSaleDeadLine.Size = new System.Drawing.Size(200, 28);
            this.dtpSaleDeadLine.TabIndex = 20;
            // 
            // tbSaleQty
            // 
            this.tbSaleQty.Location = new System.Drawing.Point(539, 522);
            this.tbSaleQty.Name = "tbSaleQty";
            this.tbSaleQty.Size = new System.Drawing.Size(100, 28);
            this.tbSaleQty.TabIndex = 23;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(369, 532);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 18);
            this.label11.TabIndex = 22;
            this.label11.Text = "수주량";
            // 
            // tbSoFirm
            // 
            this.tbSoFirm.Location = new System.Drawing.Point(539, 556);
            this.tbSoFirm.Name = "tbSoFirm";
            this.tbSoFirm.Size = new System.Drawing.Size(100, 28);
            this.tbSoFirm.TabIndex = 25;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(369, 566);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 18);
            this.label12.TabIndex = 24;
            this.label12.Text = "수주처";
            // 
            // tbRegistOrderQTY
            // 
            this.tbRegistOrderQTY.Location = new System.Drawing.Point(539, 592);
            this.tbRegistOrderQTY.Name = "tbRegistOrderQTY";
            this.tbRegistOrderQTY.Size = new System.Drawing.Size(100, 28);
            this.tbRegistOrderQTY.TabIndex = 29;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(369, 596);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(164, 18);
            this.label14.TabIndex = 28;
            this.label14.Text = "작업지시 등록 수량";
            // 
            // dgvMaterialRegist
            // 
            this.dgvMaterialRegist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaterialRegist.Location = new System.Drawing.Point(678, 504);
            this.dgvMaterialRegist.Name = "dgvMaterialRegist";
            this.dgvMaterialRegist.RowHeadersWidth = 62;
            this.dgvMaterialRegist.RowTemplate.Height = 30;
            this.dgvMaterialRegist.Size = new System.Drawing.Size(713, 150);
            this.dgvMaterialRegist.TabIndex = 31;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(675, 472);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(98, 18);
            this.label15.TabIndex = 30;
            this.label15.Text = "원재료정보";
            // 
            // btnOrder
            // 
            this.btnOrder.Location = new System.Drawing.Point(1301, 467);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(90, 23);
            this.btnOrder.TabIndex = 32;
            this.btnOrder.Text = "발주등록";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnEnquireAll
            // 
            this.btnEnquireAll.Location = new System.Drawing.Point(1144, 101);
            this.btnEnquireAll.Name = "btnEnquireAll";
            this.btnEnquireAll.Size = new System.Drawing.Size(95, 23);
            this.btnEnquireAll.TabIndex = 33;
            this.btnEnquireAll.Text = "전체조회";
            this.btnEnquireAll.UseVisualStyleBackColor = true;
            this.btnEnquireAll.Click += new System.EventHandler(this.btnEnquireAll_Click);
            // 
            // ObtainOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1459, 710);
            this.Controls.Add(this.btnEnquireAll);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.dgvMaterialRegist);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tbRegistOrderQTY);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.tbSoFirm);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tbSaleQty);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dtpSaleDeadLine);
            this.Controls.Add(this.tbSaleCode);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbProductQTY);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnInstructionAdd);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbProductName);
            this.Controls.Add(this.dgvOrderInfo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbProductName);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnEnquire);
            this.Controls.Add(this.dtpOrderEnd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpOrderStart);
            this.Controls.Add(this.cbOrderCode);
            this.Controls.Add(this.label1);
            this.Name = "ObtainOrder";
            this.Text = "ObtainOrder";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterialRegist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbOrderCode;
        private System.Windows.Forms.DateTimePicker dtpOrderStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpOrderEnd;
        private System.Windows.Forms.Button btnEnquire;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox tbProductName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvOrderInfo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbProductName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnInstructionAdd;
        private System.Windows.Forms.TextBox tbProductQTY;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbSaleCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpSaleDeadLine;
        private System.Windows.Forms.TextBox tbSaleQty;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbSoFirm;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbRegistOrderQTY;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView dgvMaterialRegist;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnEnquireAll;
    }
}