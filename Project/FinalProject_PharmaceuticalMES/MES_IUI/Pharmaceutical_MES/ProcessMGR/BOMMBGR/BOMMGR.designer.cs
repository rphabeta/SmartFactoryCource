namespace Pharmaceutical_MES.ProcessMGR.BOMMGR
{
    partial class BOMMGR
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
            this.gvPRODUCT = new System.Windows.Forms.DataGridView();
            this.gvBOM = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cbPROD_TYPE = new System.Windows.Forms.ComboBox();
            this.tbPROD_ID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPROD_NAME = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbPROD_DEL_YN = new System.Windows.Forms.ComboBox();
            this.btnPROD_INSERT = new System.Windows.Forms.Button();
            this.btnPROD_MODIFY = new System.Windows.Forms.Button();
            this.btnPROD_DELETE = new System.Windows.Forms.Button();
            this.btnPROD_SEARCH = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvPRODUCT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBOM)).BeginInit();
            this.SuspendLayout();
            // 
            // gvPRODUCT
            // 
            this.gvPRODUCT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPRODUCT.Location = new System.Drawing.Point(120, 189);
            this.gvPRODUCT.Name = "gvPRODUCT";
            this.gvPRODUCT.RowHeadersWidth = 62;
            this.gvPRODUCT.RowTemplate.Height = 30;
            this.gvPRODUCT.Size = new System.Drawing.Size(1381, 228);
            this.gvPRODUCT.TabIndex = 0;
            
            // 
            // gvBOM
            // 
            this.gvBOM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvBOM.Location = new System.Drawing.Point(120, 470);
            this.gvBOM.Name = "gvBOM";
            this.gvBOM.RowHeadersWidth = 62;
            this.gvBOM.RowTemplate.Height = 30;
            this.gvBOM.Size = new System.Drawing.Size(1381, 228);
            this.gvBOM.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(117, 440);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "BOM정보";
            // 
            // cbPROD_TYPE
            // 
            this.cbPROD_TYPE.FormattingEnabled = true;
            this.cbPROD_TYPE.Location = new System.Drawing.Point(205, 80);
            this.cbPROD_TYPE.Name = "cbPROD_TYPE";
            this.cbPROD_TYPE.Size = new System.Drawing.Size(121, 26);
            this.cbPROD_TYPE.TabIndex = 3;
            // 
            // tbPROD_ID
            // 
            this.tbPROD_ID.Location = new System.Drawing.Point(433, 80);
            this.tbPROD_ID.Name = "tbPROD_ID";
            this.tbPROD_ID.Size = new System.Drawing.Size(100, 28);
            this.tbPROD_ID.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(117, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "품목목록";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(119, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "품목분류";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(366, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "품목";
            // 
            // tbPROD_NAME
            // 
            this.tbPROD_NAME.Location = new System.Drawing.Point(549, 80);
            this.tbPROD_NAME.Name = "tbPROD_NAME";
            this.tbPROD_NAME.Size = new System.Drawing.Size(100, 28);
            this.tbPROD_NAME.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(684, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "삭제여부";
            // 
            // cbPROD_DEL_YN
            // 
            this.cbPROD_DEL_YN.FormattingEnabled = true;
            this.cbPROD_DEL_YN.Items.AddRange(new object[] {
            "Y",
            "N"});
            this.cbPROD_DEL_YN.Location = new System.Drawing.Point(780, 82);
            this.cbPROD_DEL_YN.Name = "cbPROD_DEL_YN";
            this.cbPROD_DEL_YN.Size = new System.Drawing.Size(121, 26);
            this.cbPROD_DEL_YN.TabIndex = 10;
            // 
            // btnPROD_INSERT
            // 
            this.btnPROD_INSERT.Location = new System.Drawing.Point(1336, 53);
            this.btnPROD_INSERT.Name = "btnPROD_INSERT";
            this.btnPROD_INSERT.Size = new System.Drawing.Size(75, 23);
            this.btnPROD_INSERT.TabIndex = 11;
            this.btnPROD_INSERT.Text = "등록";
            this.btnPROD_INSERT.UseVisualStyleBackColor = true;
            this.btnPROD_INSERT.Click += new System.EventHandler(this.btnPROD_INSERT_Click);
            // 
            // btnPROD_MODIFY
            // 
            this.btnPROD_MODIFY.Location = new System.Drawing.Point(1174, 53);
            this.btnPROD_MODIFY.Name = "btnPROD_MODIFY";
            this.btnPROD_MODIFY.Size = new System.Drawing.Size(75, 23);
            this.btnPROD_MODIFY.TabIndex = 12;
            this.btnPROD_MODIFY.Text = "수정";
            this.btnPROD_MODIFY.UseVisualStyleBackColor = true;
            // 
            // btnPROD_DELETE
            // 
            this.btnPROD_DELETE.Location = new System.Drawing.Point(1255, 54);
            this.btnPROD_DELETE.Name = "btnPROD_DELETE";
            this.btnPROD_DELETE.Size = new System.Drawing.Size(75, 23);
            this.btnPROD_DELETE.TabIndex = 13;
            this.btnPROD_DELETE.Text = "삭제";
            this.btnPROD_DELETE.UseVisualStyleBackColor = true;
            // 
            // btnPROD_SEARCH
            // 
            this.btnPROD_SEARCH.Location = new System.Drawing.Point(1417, 54);
            this.btnPROD_SEARCH.Name = "btnPROD_SEARCH";
            this.btnPROD_SEARCH.Size = new System.Drawing.Size(75, 23);
            this.btnPROD_SEARCH.TabIndex = 14;
            this.btnPROD_SEARCH.Text = "조회";
            this.btnPROD_SEARCH.UseVisualStyleBackColor = true;
            this.btnPROD_SEARCH.Click += new System.EventHandler(this.btnPROD_SEARCH_Click);
            // 
            // BOMMGR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1610, 802);
            this.Controls.Add(this.btnPROD_SEARCH);
            this.Controls.Add(this.btnPROD_DELETE);
            this.Controls.Add(this.btnPROD_MODIFY);
            this.Controls.Add(this.btnPROD_INSERT);
            this.Controls.Add(this.cbPROD_DEL_YN);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbPROD_NAME);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbPROD_ID);
            this.Controls.Add(this.cbPROD_TYPE);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gvBOM);
            this.Controls.Add(this.gvPRODUCT);
            this.Name = "BOMMGR";
            this.Text = "BOMMGR";
            this.Load += new System.EventHandler(this.BOMMGR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvPRODUCT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBOM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvPRODUCT;
        private System.Windows.Forms.DataGridView gvBOM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPROD_TYPE;
        private System.Windows.Forms.TextBox tbPROD_ID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPROD_NAME;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbPROD_DEL_YN;
        private System.Windows.Forms.Button btnPROD_INSERT;
        private System.Windows.Forms.Button btnPROD_MODIFY;
        private System.Windows.Forms.Button btnPROD_DELETE;
        private System.Windows.Forms.Button btnPROD_SEARCH;
    }
}