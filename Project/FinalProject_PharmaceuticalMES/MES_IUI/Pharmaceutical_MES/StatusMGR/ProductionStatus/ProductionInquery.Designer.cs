namespace Pharmaceutical_MES
{
    partial class ProductionInquery
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductionInquery));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPROD_ID = new System.Windows.Forms.TextBox();
            this.cbPROC_NAME = new System.Windows.Forms.ComboBox();
            this.dpPROC_START = new System.Windows.Forms.DateTimePicker();
            this.dpPROC_END = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPROD_NAME = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnPROC_SEARCH = new System.Windows.Forms.Button();
            this.bunifuPanel1 = new Bunifu.UI.WinForms.BunifuPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.bunifuPanel2 = new Bunifu.UI.WinForms.BunifuPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.GridView_PRODUCTION = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.bunifuElipse_btnPROC_SEARCH = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse_GridView_PRODUCTION = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuPanel3 = new Bunifu.UI.WinForms.BunifuPanel();
            this.cbGroupOption = new System.Windows.Forms.ComboBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cbPRODSTATS = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gvDefect = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.bunifuElipse_btnSearch = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse_gvDefect = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuPanel1.SuspendLayout();
            this.bunifuPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridView_PRODUCTION)).BeginInit();
            this.bunifuPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDefect)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Noto Sans KR", 9.75F);
            this.label1.Location = new System.Drawing.Point(531, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "제품코드";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Noto Sans KR", 9.75F);
            this.label2.Location = new System.Drawing.Point(755, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "제품명";
            // 
            // txtPROD_ID
            // 
            this.txtPROD_ID.Font = new System.Drawing.Font("Noto Sans KR", 9.75F);
            this.txtPROD_ID.Location = new System.Drawing.Point(592, 13);
            this.txtPROD_ID.Margin = new System.Windows.Forms.Padding(2);
            this.txtPROD_ID.Name = "txtPROD_ID";
            this.txtPROD_ID.Size = new System.Drawing.Size(136, 26);
            this.txtPROD_ID.TabIndex = 2;
            // 
            // cbPROC_NAME
            // 
            this.cbPROC_NAME.Font = new System.Drawing.Font("Noto Sans KR", 9.75F);
            this.cbPROC_NAME.FormattingEnabled = true;
            this.cbPROC_NAME.Items.AddRange(new object[] {
            "전체",
            "과립",
            "타정",
            "포장"});
            this.cbPROC_NAME.Location = new System.Drawing.Point(1469, 12);
            this.cbPROC_NAME.Margin = new System.Windows.Forms.Padding(2);
            this.cbPROC_NAME.Name = "cbPROC_NAME";
            this.cbPROC_NAME.Size = new System.Drawing.Size(83, 27);
            this.cbPROC_NAME.TabIndex = 8;
            this.cbPROC_NAME.Text = "전체";
            // 
            // dpPROC_START
            // 
            this.dpPROC_START.Font = new System.Drawing.Font("Noto Sans KR", 9.75F);
            this.dpPROC_START.Location = new System.Drawing.Point(1034, 13);
            this.dpPROC_START.Margin = new System.Windows.Forms.Padding(2);
            this.dpPROC_START.Name = "dpPROC_START";
            this.dpPROC_START.Size = new System.Drawing.Size(158, 26);
            this.dpPROC_START.TabIndex = 4;
            // 
            // dpPROC_END
            // 
            this.dpPROC_END.Font = new System.Drawing.Font("Noto Sans KR", 9.75F);
            this.dpPROC_END.Location = new System.Drawing.Point(1216, 13);
            this.dpPROC_END.Margin = new System.Windows.Forms.Padding(2);
            this.dpPROC_END.Name = "dpPROC_END";
            this.dpPROC_END.Size = new System.Drawing.Size(158, 26);
            this.dpPROC_END.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Noto Sans KR", 9.75F);
            this.label3.Location = new System.Drawing.Point(1401, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "공정 과정";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Noto Sans KR", 9.75F);
            this.label4.Location = new System.Drawing.Point(970, 16);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "조회기간";
            // 
            // txtPROD_NAME
            // 
            this.txtPROD_NAME.Font = new System.Drawing.Font("Noto Sans KR", 9.75F);
            this.txtPROD_NAME.Location = new System.Drawing.Point(807, 13);
            this.txtPROD_NAME.Margin = new System.Windows.Forms.Padding(2);
            this.txtPROD_NAME.Name = "txtPROD_NAME";
            this.txtPROD_NAME.Size = new System.Drawing.Size(136, 26);
            this.txtPROD_NAME.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Noto Sans KR", 9.75F);
            this.label5.Location = new System.Drawing.Point(1196, 17);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 19);
            this.label5.TabIndex = 10;
            this.label5.Text = "~";
            // 
            // btnPROC_SEARCH
            // 
            this.btnPROC_SEARCH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.btnPROC_SEARCH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPROC_SEARCH.Font = new System.Drawing.Font("Noto Sans KR SemiBold", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnPROC_SEARCH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.btnPROC_SEARCH.Location = new System.Drawing.Point(1568, 8);
            this.btnPROC_SEARCH.Margin = new System.Windows.Forms.Padding(2);
            this.btnPROC_SEARCH.Name = "btnPROC_SEARCH";
            this.btnPROC_SEARCH.Size = new System.Drawing.Size(76, 35);
            this.btnPROC_SEARCH.TabIndex = 11;
            this.btnPROC_SEARCH.Text = "조회";
            this.btnPROC_SEARCH.UseVisualStyleBackColor = false;
            this.btnPROC_SEARCH.Click += new System.EventHandler(this.btnPROC_SEARCH_Click);
            // 
            // bunifuPanel1
            // 
            this.bunifuPanel1.BackgroundColor = System.Drawing.Color.White;
            this.bunifuPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel1.BackgroundImage")));
            this.bunifuPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel1.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuPanel1.BorderRadius = 15;
            this.bunifuPanel1.BorderThickness = 1;
            this.bunifuPanel1.Controls.Add(this.label6);
            this.bunifuPanel1.Location = new System.Drawing.Point(24, 12);
            this.bunifuPanel1.Name = "bunifuPanel1";
            this.bunifuPanel1.ShowBorders = true;
            this.bunifuPanel1.Size = new System.Drawing.Size(1665, 51);
            this.bunifuPanel1.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Noto Sans KR", 15.75F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(23, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 30);
            this.label6.TabIndex = 78;
            this.label6.Text = "생산실적현황";
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
            this.bunifuPanel2.Controls.Add(this.txtPROD_ID);
            this.bunifuPanel2.Controls.Add(this.GridView_PRODUCTION);
            this.bunifuPanel2.Controls.Add(this.label1);
            this.bunifuPanel2.Controls.Add(this.btnPROC_SEARCH);
            this.bunifuPanel2.Controls.Add(this.dpPROC_END);
            this.bunifuPanel2.Controls.Add(this.label2);
            this.bunifuPanel2.Controls.Add(this.dpPROC_START);
            this.bunifuPanel2.Controls.Add(this.label3);
            this.bunifuPanel2.Controls.Add(this.label4);
            this.bunifuPanel2.Controls.Add(this.label5);
            this.bunifuPanel2.Controls.Add(this.txtPROD_NAME);
            this.bunifuPanel2.Controls.Add(this.cbPROC_NAME);
            this.bunifuPanel2.Location = new System.Drawing.Point(24, 69);
            this.bunifuPanel2.Name = "bunifuPanel2";
            this.bunifuPanel2.ShowBorders = true;
            this.bunifuPanel2.Size = new System.Drawing.Size(1665, 372);
            this.bunifuPanel2.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Noto Sans KR", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(24, 13);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 24);
            this.label8.TabIndex = 60;
            this.label8.Text = "생산 실적 목록";
            // 
            // GridView_PRODUCTION
            // 
            this.GridView_PRODUCTION.AllowCustomTheming = true;
            this.GridView_PRODUCTION.AllowUserToResizeColumns = false;
            this.GridView_PRODUCTION.AllowUserToResizeRows = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black;
            this.GridView_PRODUCTION.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.GridView_PRODUCTION.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridView_PRODUCTION.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(225)))), ((int)(((byte)(237)))));
            this.GridView_PRODUCTION.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GridView_PRODUCTION.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.GridView_PRODUCTION.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Noto Sans KR SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridView_PRODUCTION.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.GridView_PRODUCTION.ColumnHeadersHeight = 35;
            this.GridView_PRODUCTION.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.GridView_PRODUCTION.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.GridView_PRODUCTION.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Noto Sans KR SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.GridView_PRODUCTION.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.GridView_PRODUCTION.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.GridView_PRODUCTION.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.GridView_PRODUCTION.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.GridView_PRODUCTION.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.GridView_PRODUCTION.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.LightSteelBlue;
            this.GridView_PRODUCTION.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Noto Sans KR SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.GridView_PRODUCTION.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.GridView_PRODUCTION.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.SteelBlue;
            this.GridView_PRODUCTION.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.GridView_PRODUCTION.CurrentTheme.Name = null;
            this.GridView_PRODUCTION.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.GridView_PRODUCTION.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Noto Sans KR SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.GridView_PRODUCTION.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.GridView_PRODUCTION.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.GridView_PRODUCTION.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Noto Sans KR SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridView_PRODUCTION.DefaultCellStyle = dataGridViewCellStyle15;
            this.GridView_PRODUCTION.EnableHeadersVisualStyles = false;
            this.GridView_PRODUCTION.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.GridView_PRODUCTION.HeaderBackColor = System.Drawing.Color.LightSteelBlue;
            this.GridView_PRODUCTION.HeaderBgColor = System.Drawing.Color.Empty;
            this.GridView_PRODUCTION.HeaderForeColor = System.Drawing.Color.White;
            this.GridView_PRODUCTION.Location = new System.Drawing.Point(21, 49);
            this.GridView_PRODUCTION.Margin = new System.Windows.Forms.Padding(2);
            this.GridView_PRODUCTION.Name = "GridView_PRODUCTION";
            this.GridView_PRODUCTION.RowHeadersVisible = false;
            this.GridView_PRODUCTION.RowHeadersWidth = 62;
            this.GridView_PRODUCTION.RowTemplate.Height = 30;
            this.GridView_PRODUCTION.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridView_PRODUCTION.Size = new System.Drawing.Size(1623, 300);
            this.GridView_PRODUCTION.TabIndex = 37;
            this.GridView_PRODUCTION.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            // 
            // bunifuElipse_btnPROC_SEARCH
            // 
            this.bunifuElipse_btnPROC_SEARCH.ElipseRadius = 6;
            this.bunifuElipse_btnPROC_SEARCH.TargetControl = this.btnPROC_SEARCH;
            // 
            // bunifuElipse_GridView_PRODUCTION
            // 
            this.bunifuElipse_GridView_PRODUCTION.ElipseRadius = 6;
            this.bunifuElipse_GridView_PRODUCTION.TargetControl = this.GridView_PRODUCTION;
            // 
            // bunifuPanel3
            // 
            this.bunifuPanel3.BackgroundColor = System.Drawing.Color.White;
            this.bunifuPanel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel3.BackgroundImage")));
            this.bunifuPanel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel3.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuPanel3.BorderRadius = 15;
            this.bunifuPanel3.BorderThickness = 1;
            this.bunifuPanel3.Controls.Add(this.cbGroupOption);
            this.bunifuPanel3.Controls.Add(this.chart1);
            this.bunifuPanel3.Controls.Add(this.cbPRODSTATS);
            this.bunifuPanel3.Controls.Add(this.label7);
            this.bunifuPanel3.Controls.Add(this.gvDefect);
            this.bunifuPanel3.Controls.Add(this.btnSearch);
            this.bunifuPanel3.Controls.Add(this.label9);
            this.bunifuPanel3.Controls.Add(this.label10);
            this.bunifuPanel3.Location = new System.Drawing.Point(24, 447);
            this.bunifuPanel3.Name = "bunifuPanel3";
            this.bunifuPanel3.ShowBorders = true;
            this.bunifuPanel3.Size = new System.Drawing.Size(1665, 566);
            this.bunifuPanel3.TabIndex = 60;
            // 
            // cbGroupOption
            // 
            this.cbGroupOption.Font = new System.Drawing.Font("Noto Sans KR", 9.75F);
            this.cbGroupOption.FormattingEnabled = true;
            this.cbGroupOption.Location = new System.Drawing.Point(1408, 12);
            this.cbGroupOption.Margin = new System.Windows.Forms.Padding(2);
            this.cbGroupOption.Name = "cbGroupOption";
            this.cbGroupOption.Size = new System.Drawing.Size(136, 27);
            this.cbGroupOption.TabIndex = 58;
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(21, 293);
            this.chart1.Margin = new System.Windows.Forms.Padding(2);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(1623, 271);
            this.chart1.TabIndex = 61;
            this.chart1.Text = "chart1";
            // 
            // cbPRODSTATS
            // 
            this.cbPRODSTATS.Font = new System.Drawing.Font("Noto Sans KR", 9.75F);
            this.cbPRODSTATS.FormattingEnabled = true;
            this.cbPRODSTATS.Location = new System.Drawing.Point(1178, 12);
            this.cbPRODSTATS.Margin = new System.Windows.Forms.Padding(2);
            this.cbPRODSTATS.Name = "cbPRODSTATS";
            this.cbPRODSTATS.Size = new System.Drawing.Size(136, 27);
            this.cbPRODSTATS.TabIndex = 55;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Noto Sans KR", 12F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(24, 13);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 24);
            this.label7.TabIndex = 58;
            this.label7.Text = "불량품 목록";
            // 
            // gvDefect
            // 
            this.gvDefect.AllowCustomTheming = true;
            this.gvDefect.AllowUserToResizeColumns = false;
            this.gvDefect.AllowUserToResizeRows = false;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black;
            this.gvDefect.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle16;
            this.gvDefect.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvDefect.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(225)))), ((int)(((byte)(237)))));
            this.gvDefect.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvDefect.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gvDefect.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Noto Sans KR SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvDefect.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.gvDefect.ColumnHeadersHeight = 40;
            this.gvDefect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gvDefect.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gvDefect.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Noto Sans KR SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gvDefect.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.gvDefect.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.gvDefect.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.gvDefect.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.gvDefect.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.gvDefect.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.LightSteelBlue;
            this.gvDefect.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Noto Sans KR SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gvDefect.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.gvDefect.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.SteelBlue;
            this.gvDefect.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.gvDefect.CurrentTheme.Name = null;
            this.gvDefect.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.gvDefect.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Noto Sans KR SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gvDefect.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.gvDefect.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.gvDefect.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Noto Sans KR SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvDefect.DefaultCellStyle = dataGridViewCellStyle18;
            this.gvDefect.EnableHeadersVisualStyles = false;
            this.gvDefect.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.gvDefect.HeaderBackColor = System.Drawing.Color.LightSteelBlue;
            this.gvDefect.HeaderBgColor = System.Drawing.Color.Empty;
            this.gvDefect.HeaderForeColor = System.Drawing.Color.White;
            this.gvDefect.Location = new System.Drawing.Point(21, 49);
            this.gvDefect.Margin = new System.Windows.Forms.Padding(2);
            this.gvDefect.Name = "gvDefect";
            this.gvDefect.RowHeadersVisible = false;
            this.gvDefect.RowHeadersWidth = 62;
            this.gvDefect.RowTemplate.Height = 40;
            this.gvDefect.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvDefect.Size = new System.Drawing.Size(1623, 240);
            this.gvDefect.TabIndex = 60;
            this.gvDefect.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Noto Sans KR SemiBold", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.btnSearch.Location = new System.Drawing.Point(1568, 8);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(76, 35);
            this.btnSearch.TabIndex = 59;
            this.btnSearch.Text = "조회";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Noto Sans KR", 9.75F);
            this.label9.Location = new System.Drawing.Point(1344, 15);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 19);
            this.label9.TabIndex = 43;
            this.label9.Text = "집계기준";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Noto Sans KR", 9.75F);
            this.label10.Location = new System.Drawing.Point(1110, 15);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 19);
            this.label10.TabIndex = 47;
            this.label10.Text = "제품 상태";
            // 
            // bunifuElipse_btnSearch
            // 
            this.bunifuElipse_btnSearch.ElipseRadius = 6;
            this.bunifuElipse_btnSearch.TargetControl = this.btnSearch;
            // 
            // bunifuElipse_gvDefect
            // 
            this.bunifuElipse_gvDefect.ElipseRadius = 6;
            this.bunifuElipse_gvDefect.TargetControl = this.gvDefect;
            // 
            // ProductionInquery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1750, 1025);
            this.Controls.Add(this.bunifuPanel3);
            this.Controls.Add(this.bunifuPanel2);
            this.Controls.Add(this.bunifuPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ProductionInquery";
            this.Text = "ProductionInquery";
            this.Load += new System.EventHandler(this.ProductionInquery_Load);
            this.bunifuPanel1.ResumeLayout(false);
            this.bunifuPanel1.PerformLayout();
            this.bunifuPanel2.ResumeLayout(false);
            this.bunifuPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridView_PRODUCTION)).EndInit();
            this.bunifuPanel3.ResumeLayout(false);
            this.bunifuPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDefect)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPROD_ID;
        private System.Windows.Forms.ComboBox cbPROC_NAME;
        private System.Windows.Forms.DateTimePicker dpPROC_START;
        private System.Windows.Forms.DateTimePicker dpPROC_END;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPROD_NAME;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnPROC_SEARCH;
        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel1;
        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel2;
        private Bunifu.UI.WinForms.BunifuDataGridView GridView_PRODUCTION;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse_btnPROC_SEARCH;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse_GridView_PRODUCTION;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel3;
        private System.Windows.Forms.ComboBox cbGroupOption;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ComboBox cbPRODSTATS;
        private System.Windows.Forms.Label label7;
        private Bunifu.UI.WinForms.BunifuDataGridView gvDefect;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse_btnSearch;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse_gvDefect;
    }
}