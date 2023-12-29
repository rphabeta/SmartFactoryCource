namespace Final_FUI
{
    partial class User__performance
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(User__performance));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnSearh = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.WOID_LOT_Grid = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.bunifuPanel1 = new Bunifu.UI.WinForms.BunifuPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtWorkerInfo = new Bunifu.UI.WinForms.BunifuTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WOID_LOT_Grid)).BeginInit();
            this.bunifuPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Noto Sans KR Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "작업자 실적 일별",
            "작업자 실적 월별"});
            this.comboBox1.Location = new System.Drawing.Point(546, 74);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(287, 32);
            this.comboBox1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Noto Sans KR Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(359, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "작업자 실적 월별 / 일별\r\n";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Noto Sans KR", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dateTimePicker1.Font = new System.Drawing.Font("Noto Sans KR", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dateTimePicker1.Location = new System.Drawing.Point(839, 74);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(239, 31);
            this.dateTimePicker1.TabIndex = 4;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CalendarFont = new System.Drawing.Font("Noto Sans KR", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dateTimePicker2.Font = new System.Drawing.Font("Noto Sans KR", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dateTimePicker2.Location = new System.Drawing.Point(839, 114);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(239, 31);
            this.dateTimePicker2.TabIndex = 5;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(907, 22);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.XValueMember = "10";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(901, 802);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // btnSearh
            // 
            this.btnSearh.AllowAnimations = true;
            this.btnSearh.AllowMouseEffects = true;
            this.btnSearh.AllowToggling = false;
            this.btnSearh.AnimationSpeed = 200;
            this.btnSearh.AutoGenerateColors = false;
            this.btnSearh.AutoRoundBorders = false;
            this.btnSearh.AutoSizeLeftIcon = true;
            this.btnSearh.AutoSizeRightIcon = true;
            this.btnSearh.BackColor = System.Drawing.Color.Transparent;
            this.btnSearh.BackColor1 = System.Drawing.Color.SteelBlue;
            this.btnSearh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearh.BackgroundImage")));
            this.btnSearh.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnSearh.ButtonText = "조회";
            this.btnSearh.ButtonTextMarginLeft = 0;
            this.btnSearh.ColorContrastOnClick = 45;
            this.btnSearh.ColorContrastOnHover = 45;
            this.btnSearh.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnSearh.CustomizableEdges = borderEdges1;
            this.btnSearh.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSearh.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnSearh.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnSearh.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnSearh.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btnSearh.Font = new System.Drawing.Font("Noto Sans KR", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSearh.ForeColor = System.Drawing.Color.White;
            this.btnSearh.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearh.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnSearh.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnSearh.IconMarginLeft = 11;
            this.btnSearh.IconPadding = 10;
            this.btnSearh.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearh.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnSearh.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnSearh.IconSize = 25;
            this.btnSearh.IdleBorderColor = System.Drawing.Color.SteelBlue;
            this.btnSearh.IdleBorderRadius = 20;
            this.btnSearh.IdleBorderThickness = 1;
            this.btnSearh.IdleFillColor = System.Drawing.Color.SteelBlue;
            this.btnSearh.IdleIconLeftImage = null;
            this.btnSearh.IdleIconRightImage = null;
            this.btnSearh.IndicateFocus = false;
            this.btnSearh.Location = new System.Drawing.Point(1156, 77);
            this.btnSearh.Name = "btnSearh";
            this.btnSearh.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnSearh.OnDisabledState.BorderRadius = 20;
            this.btnSearh.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnSearh.OnDisabledState.BorderThickness = 1;
            this.btnSearh.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnSearh.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnSearh.OnDisabledState.IconLeftImage = null;
            this.btnSearh.OnDisabledState.IconRightImage = null;
            this.btnSearh.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnSearh.onHoverState.BorderRadius = 20;
            this.btnSearh.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnSearh.onHoverState.BorderThickness = 1;
            this.btnSearh.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnSearh.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnSearh.onHoverState.IconLeftImage = null;
            this.btnSearh.onHoverState.IconRightImage = null;
            this.btnSearh.OnIdleState.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnSearh.OnIdleState.BorderRadius = 20;
            this.btnSearh.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnSearh.OnIdleState.BorderThickness = 1;
            this.btnSearh.OnIdleState.FillColor = System.Drawing.Color.SteelBlue;
            this.btnSearh.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnSearh.OnIdleState.IconLeftImage = null;
            this.btnSearh.OnIdleState.IconRightImage = null;
            this.btnSearh.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnSearh.OnPressedState.BorderRadius = 20;
            this.btnSearh.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnSearh.OnPressedState.BorderThickness = 1;
            this.btnSearh.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnSearh.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnSearh.OnPressedState.IconLeftImage = null;
            this.btnSearh.OnPressedState.IconRightImage = null;
            this.btnSearh.Size = new System.Drawing.Size(108, 68);
            this.btnSearh.TabIndex = 38;
            this.btnSearh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSearh.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnSearh.TextMarginLeft = 0;
            this.btnSearh.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnSearh.UseDefaultRadiusAndThickness = true;
            this.btnSearh.Click += new System.EventHandler(this.btnSearh_Click);
            // 
            // WOID_LOT_Grid
            // 
            this.WOID_LOT_Grid.AllowCustomTheming = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Noto Sans KR", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.WOID_LOT_Grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.WOID_LOT_Grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.WOID_LOT_Grid.BackgroundColor = System.Drawing.Color.White;
            this.WOID_LOT_Grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.WOID_LOT_Grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.WOID_LOT_Grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Noto Sans KR", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.WOID_LOT_Grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.WOID_LOT_Grid.ColumnHeadersHeight = 40;
            this.WOID_LOT_Grid.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.WOID_LOT_Grid.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.WOID_LOT_Grid.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.WOID_LOT_Grid.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.WOID_LOT_Grid.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.WOID_LOT_Grid.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.WOID_LOT_Grid.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.WOID_LOT_Grid.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.SteelBlue;
            this.WOID_LOT_Grid.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Noto Sans KR", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.WOID_LOT_Grid.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.WOID_LOT_Grid.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.MidnightBlue;
            this.WOID_LOT_Grid.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.WOID_LOT_Grid.CurrentTheme.Name = null;
            this.WOID_LOT_Grid.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.WOID_LOT_Grid.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.WOID_LOT_Grid.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.WOID_LOT_Grid.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.WOID_LOT_Grid.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.WOID_LOT_Grid.DefaultCellStyle = dataGridViewCellStyle3;
            this.WOID_LOT_Grid.EnableHeadersVisualStyles = false;
            this.WOID_LOT_Grid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.WOID_LOT_Grid.HeaderBackColor = System.Drawing.Color.SteelBlue;
            this.WOID_LOT_Grid.HeaderBgColor = System.Drawing.Color.Empty;
            this.WOID_LOT_Grid.HeaderForeColor = System.Drawing.Color.White;
            this.WOID_LOT_Grid.Location = new System.Drawing.Point(46, 37);
            this.WOID_LOT_Grid.Name = "WOID_LOT_Grid";
            this.WOID_LOT_Grid.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.WOID_LOT_Grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.WOID_LOT_Grid.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Noto Sans KR", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.WOID_LOT_Grid.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.WOID_LOT_Grid.RowTemplate.Height = 40;
            this.WOID_LOT_Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.WOID_LOT_Grid.Size = new System.Drawing.Size(799, 751);
            this.WOID_LOT_Grid.TabIndex = 40;
            this.WOID_LOT_Grid.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            // 
            // bunifuPanel1
            // 
            this.bunifuPanel1.BackgroundColor = System.Drawing.Color.White;
            this.bunifuPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel1.BackgroundImage")));
            this.bunifuPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel1.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuPanel1.BorderRadius = 30;
            this.bunifuPanel1.BorderThickness = 1;
            this.bunifuPanel1.Controls.Add(this.WOID_LOT_Grid);
            this.bunifuPanel1.Controls.Add(this.chart1);
            this.bunifuPanel1.Location = new System.Drawing.Point(53, 168);
            this.bunifuPanel1.Name = "bunifuPanel1";
            this.bunifuPanel1.ShowBorders = true;
            this.bunifuPanel1.Size = new System.Drawing.Size(1811, 830);
            this.bunifuPanel1.TabIndex = 41;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(53, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(228, 150);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 42;
            this.pictureBox1.TabStop = false;
            // 
            // txtWorkerInfo
            // 
            this.txtWorkerInfo.AcceptsReturn = false;
            this.txtWorkerInfo.AcceptsTab = false;
            this.txtWorkerInfo.AnimationSpeed = 200;
            this.txtWorkerInfo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtWorkerInfo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtWorkerInfo.AutoSizeHeight = true;
            this.txtWorkerInfo.BackColor = System.Drawing.Color.Snow;
            this.txtWorkerInfo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtWorkerInfo.BackgroundImage")));
            this.txtWorkerInfo.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.txtWorkerInfo.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtWorkerInfo.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.txtWorkerInfo.BorderColorIdle = System.Drawing.Color.SlateBlue;
            this.txtWorkerInfo.BorderRadius = 10;
            this.txtWorkerInfo.BorderThickness = 1;
            this.txtWorkerInfo.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
            this.txtWorkerInfo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtWorkerInfo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtWorkerInfo.DefaultFont = new System.Drawing.Font("Noto Sans KR Medium", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtWorkerInfo.DefaultText = "mosubin님 전월 동기간 대비 생산실적이 120% 증가하였습니다";
            this.txtWorkerInfo.Enabled = false;
            this.txtWorkerInfo.FillColor = System.Drawing.SystemColors.HighlightText;
            this.txtWorkerInfo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtWorkerInfo.HideSelection = true;
            this.txtWorkerInfo.IconLeft = null;
            this.txtWorkerInfo.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtWorkerInfo.IconPadding = 10;
            this.txtWorkerInfo.IconRight = null;
            this.txtWorkerInfo.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtWorkerInfo.Lines = new string[] {
        "mosubin님 전월 동기간 대비 생산실적이 120% 증가하였습니다"};
            this.txtWorkerInfo.Location = new System.Drawing.Point(666, 12);
            this.txtWorkerInfo.MaxLength = 32767;
            this.txtWorkerInfo.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtWorkerInfo.Modified = false;
            this.txtWorkerInfo.Multiline = false;
            this.txtWorkerInfo.Name = "txtWorkerInfo";
            stateProperties1.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtWorkerInfo.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtWorkerInfo.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtWorkerInfo.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.SlateBlue;
            stateProperties4.FillColor = System.Drawing.SystemColors.HighlightText;
            stateProperties4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtWorkerInfo.OnIdleState = stateProperties4;
            this.txtWorkerInfo.Padding = new System.Windows.Forms.Padding(3);
            this.txtWorkerInfo.PasswordChar = '\0';
            this.txtWorkerInfo.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtWorkerInfo.PlaceholderText = "Enter text";
            this.txtWorkerInfo.ReadOnly = true;
            this.txtWorkerInfo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtWorkerInfo.SelectedText = "";
            this.txtWorkerInfo.SelectionLength = 0;
            this.txtWorkerInfo.SelectionStart = 0;
            this.txtWorkerInfo.ShortcutsEnabled = true;
            this.txtWorkerInfo.Size = new System.Drawing.Size(598, 48);
            this.txtWorkerInfo.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.txtWorkerInfo.TabIndex = 43;
            this.txtWorkerInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtWorkerInfo.TextMarginBottom = 0;
            this.txtWorkerInfo.TextMarginLeft = 3;
            this.txtWorkerInfo.TextMarginTop = 1;
            this.txtWorkerInfo.TextPlaceholder = "Enter text";
            this.txtWorkerInfo.UseSystemPasswordChar = false;
            this.txtWorkerInfo.WordWrap = true;
            // 
            // User__performance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(1924, 1061);
            this.Controls.Add(this.txtWorkerInfo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSearh);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.bunifuPanel1);
            this.Name = "User__performance";
            this.Load += new System.EventHandler(this.User__performance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WOID_LOT_Grid)).EndInit();
            this.bunifuPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnSearh;
        private Bunifu.UI.WinForms.BunifuDataGridView WOID_LOT_Grid;
        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.UI.WinForms.BunifuTextBox txtWorkerInfo;
    }
}