namespace ViewPage
{
    partial class 작업지시
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(작업지시));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label3 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbProductName = new System.Windows.Forms.TextBox();
            this.tbProductID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbWorkID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbProcess = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.bunifuPanel1 = new Bunifu.UI.WinForms.BunifuPanel();
            this.WorkGrid = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.bunifuPanel2 = new Bunifu.UI.WinForms.BunifuPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.bunifuElipse_WorkGrid = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse_btnAdd = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse_btnDelete = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse_btnReset = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse_btnSearch = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WorkGrid)).BeginInit();
            this.bunifuPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Noto Sans KR", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(23, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 24);
            this.label3.TabIndex = 20;
            this.label3.Text = "작업지시 목록";
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Noto Sans KR SemiBold", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.btnReset.Location = new System.Drawing.Point(1567, 46);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(76, 35);
            this.btnReset.TabIndex = 27;
            this.btnReset.Text = "리셋";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Noto Sans KR SemiBold", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.btnSearch.Location = new System.Drawing.Point(1567, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(76, 35);
            this.btnSearch.TabIndex = 25;
            this.btnSearch.Text = "조회";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbProductName
            // 
            this.tbProductName.Font = new System.Drawing.Font("Noto Sans KR", 9.75F);
            this.tbProductName.Location = new System.Drawing.Point(982, 49);
            this.tbProductName.Name = "tbProductName";
            this.tbProductName.Size = new System.Drawing.Size(136, 26);
            this.tbProductName.TabIndex = 19;
            // 
            // tbProductID
            // 
            this.tbProductID.Font = new System.Drawing.Font("Noto Sans KR", 9.75F);
            this.tbProductID.Location = new System.Drawing.Point(982, 12);
            this.tbProductID.Name = "tbProductID";
            this.tbProductID.Size = new System.Drawing.Size(136, 26);
            this.tbProductID.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Noto Sans KR", 9.75F);
            this.label2.Location = new System.Drawing.Point(931, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 19);
            this.label2.TabIndex = 15;
            this.label2.Text = "제품명";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Noto Sans KR", 9.75F);
            this.label1.Location = new System.Drawing.Point(919, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 19);
            this.label1.TabIndex = 14;
            this.label1.Text = "제품코드";
            // 
            // tbWorkID
            // 
            this.tbWorkID.Font = new System.Drawing.Font("Noto Sans KR", 9.75F);
            this.tbWorkID.Location = new System.Drawing.Point(1233, 49);
            this.tbWorkID.Name = "tbWorkID";
            this.tbWorkID.Size = new System.Drawing.Size(136, 26);
            this.tbWorkID.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Noto Sans KR", 9.75F);
            this.label4.Location = new System.Drawing.Point(1146, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 19);
            this.label4.TabIndex = 21;
            this.label4.Text = "작업지시코드";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Noto Sans KR", 9.75F);
            this.label5.Location = new System.Drawing.Point(1415, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 19);
            this.label5.TabIndex = 23;
            this.label5.Text = "공정";
            // 
            // cbProcess
            // 
            this.cbProcess.Font = new System.Drawing.Font("Noto Sans KR", 9.75F);
            this.cbProcess.FormattingEnabled = true;
            this.cbProcess.Location = new System.Drawing.Point(1470, 49);
            this.cbProcess.Name = "cbProcess";
            this.cbProcess.Size = new System.Drawing.Size(83, 27);
            this.cbProcess.TabIndex = 24;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Noto Sans KR SemiBold", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.btnAdd.Location = new System.Drawing.Point(1481, 8);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(76, 35);
            this.btnAdd.TabIndex = 28;
            this.btnAdd.Text = "추가";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Noto Sans KR SemiBold", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.btnDelete.Location = new System.Drawing.Point(1567, 8);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(76, 35);
            this.btnDelete.TabIndex = 29;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Noto Sans KR", 9.75F);
            this.dateTimePicker1.Location = new System.Drawing.Point(1213, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(156, 26);
            this.dateTimePicker1.TabIndex = 17;
            this.dateTimePicker1.Value = new System.DateTime(2023, 11, 9, 0, 0, 0, 0);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Font = new System.Drawing.Font("Noto Sans KR", 9.75F);
            this.dateTimePicker2.Location = new System.Drawing.Point(1397, 12);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(156, 26);
            this.dateTimePicker2.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Noto Sans KR", 9.75F);
            this.label6.Location = new System.Drawing.Point(1150, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 19);
            this.label6.TabIndex = 30;
            this.label6.Text = "조회기간";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Noto Sans KR", 9.75F);
            this.label7.Location = new System.Drawing.Point(1375, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 19);
            this.label7.TabIndex = 31;
            this.label7.Text = "~";
            // 
            // bunifuPanel1
            // 
            this.bunifuPanel1.BackgroundColor = System.Drawing.Color.White;
            this.bunifuPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel1.BackgroundImage")));
            this.bunifuPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel1.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuPanel1.BorderRadius = 15;
            this.bunifuPanel1.BorderThickness = 1;
            this.bunifuPanel1.Controls.Add(this.WorkGrid);
            this.bunifuPanel1.Controls.Add(this.btnDelete);
            this.bunifuPanel1.Controls.Add(this.label3);
            this.bunifuPanel1.Controls.Add(this.btnAdd);
            this.bunifuPanel1.Location = new System.Drawing.Point(24, 106);
            this.bunifuPanel1.Name = "bunifuPanel1";
            this.bunifuPanel1.ShowBorders = true;
            this.bunifuPanel1.Size = new System.Drawing.Size(1665, 907);
            this.bunifuPanel1.TabIndex = 32;
            // 
            // WorkGrid
            // 
            this.WorkGrid.AllowCustomTheming = true;
            this.WorkGrid.AllowUserToResizeColumns = false;
            this.WorkGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.WorkGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.WorkGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.WorkGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(225)))), ((int)(((byte)(237)))));
            this.WorkGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.WorkGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.WorkGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Noto Sans KR SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.WorkGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.WorkGrid.ColumnHeadersHeight = 35;
            this.WorkGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.WorkGrid.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.WorkGrid.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Noto Sans KR SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WorkGrid.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.WorkGrid.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.WorkGrid.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.WorkGrid.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.WorkGrid.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.WorkGrid.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.LightSteelBlue;
            this.WorkGrid.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Noto Sans KR SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.WorkGrid.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.WorkGrid.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.SteelBlue;
            this.WorkGrid.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.WorkGrid.CurrentTheme.Name = null;
            this.WorkGrid.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.WorkGrid.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Noto Sans KR SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.WorkGrid.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.WorkGrid.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.WorkGrid.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Noto Sans KR SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.WorkGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.WorkGrid.EnableHeadersVisualStyles = false;
            this.WorkGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.WorkGrid.HeaderBackColor = System.Drawing.Color.LightSteelBlue;
            this.WorkGrid.HeaderBgColor = System.Drawing.Color.Empty;
            this.WorkGrid.HeaderForeColor = System.Drawing.Color.White;
            this.WorkGrid.Location = new System.Drawing.Point(20, 49);
            this.WorkGrid.Name = "WorkGrid";
            this.WorkGrid.RowHeadersVisible = false;
            this.WorkGrid.RowHeadersWidth = 62;
            this.WorkGrid.RowTemplate.Height = 30;
            this.WorkGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.WorkGrid.Size = new System.Drawing.Size(1623, 835);
            this.WorkGrid.TabIndex = 34;
            this.WorkGrid.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            // 
            // bunifuPanel2
            // 
            this.bunifuPanel2.BackgroundColor = System.Drawing.Color.White;
            this.bunifuPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel2.BackgroundImage")));
            this.bunifuPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel2.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuPanel2.BorderRadius = 15;
            this.bunifuPanel2.BorderThickness = 1;
            this.bunifuPanel2.Controls.Add(this.label8);
            this.bunifuPanel2.Controls.Add(this.btnSearch);
            this.bunifuPanel2.Controls.Add(this.btnReset);
            this.bunifuPanel2.Controls.Add(this.label7);
            this.bunifuPanel2.Controls.Add(this.tbProductID);
            this.bunifuPanel2.Controls.Add(this.label6);
            this.bunifuPanel2.Controls.Add(this.label1);
            this.bunifuPanel2.Controls.Add(this.dateTimePicker2);
            this.bunifuPanel2.Controls.Add(this.label2);
            this.bunifuPanel2.Controls.Add(this.dateTimePicker1);
            this.bunifuPanel2.Controls.Add(this.tbProductName);
            this.bunifuPanel2.Controls.Add(this.cbProcess);
            this.bunifuPanel2.Controls.Add(this.label5);
            this.bunifuPanel2.Controls.Add(this.label4);
            this.bunifuPanel2.Controls.Add(this.tbWorkID);
            this.bunifuPanel2.Location = new System.Drawing.Point(24, 12);
            this.bunifuPanel2.Name = "bunifuPanel2";
            this.bunifuPanel2.ShowBorders = true;
            this.bunifuPanel2.Size = new System.Drawing.Size(1665, 88);
            this.bunifuPanel2.TabIndex = 33;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Noto Sans KR", 15.75F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(22, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 30);
            this.label8.TabIndex = 34;
            this.label8.Text = "작업지시";
            // 
            // bunifuElipse_WorkGrid
            // 
            this.bunifuElipse_WorkGrid.ElipseRadius = 6;
            this.bunifuElipse_WorkGrid.TargetControl = this.WorkGrid;
            // 
            // bunifuElipse_btnAdd
            // 
            this.bunifuElipse_btnAdd.ElipseRadius = 6;
            this.bunifuElipse_btnAdd.TargetControl = this.btnAdd;
            // 
            // bunifuElipse_btnDelete
            // 
            this.bunifuElipse_btnDelete.ElipseRadius = 6;
            this.bunifuElipse_btnDelete.TargetControl = this.btnDelete;
            // 
            // bunifuElipse_btnReset
            // 
            this.bunifuElipse_btnReset.ElipseRadius = 6;
            this.bunifuElipse_btnReset.TargetControl = this.btnReset;
            // 
            // bunifuElipse_btnSearch
            // 
            this.bunifuElipse_btnSearch.ElipseRadius = 6;
            this.bunifuElipse_btnSearch.TargetControl = this.btnSearch;
            // 
            // 작업지시
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.ClientSize = new System.Drawing.Size(1750, 1025);
            this.Controls.Add(this.bunifuPanel2);
            this.Controls.Add(this.bunifuPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "작업지시";
            this.Text = "작업지시";
            this.Load += new System.EventHandler(this.작업지시_Load);
            this.bunifuPanel1.ResumeLayout(false);
            this.bunifuPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WorkGrid)).EndInit();
            this.bunifuPanel2.ResumeLayout(false);
            this.bunifuPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbProductName;
        private System.Windows.Forms.TextBox tbProductID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbWorkID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbProcess;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel1;
        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel2;
        private Bunifu.UI.WinForms.BunifuDataGridView WorkGrid;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse_WorkGrid;
        private System.Windows.Forms.Label label8;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse_btnAdd;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse_btnDelete;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse_btnReset;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse_btnSearch;
    }
}

