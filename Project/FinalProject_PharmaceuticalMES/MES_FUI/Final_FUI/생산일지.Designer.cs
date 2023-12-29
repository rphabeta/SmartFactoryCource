namespace Final_FUI
{
    partial class 생산일지
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(생산일지));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.WO_Grid = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.DEF_LOT_Grid = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.btn_Main = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.Search_WO_Grid = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.bunifuPanel1 = new Bunifu.UI.WinForms.BunifuPanel();
            this.bunifuPanel2 = new Bunifu.UI.WinForms.BunifuPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.WO_Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEF_LOT_Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Noto Sans KR", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dateTimePicker1.Font = new System.Drawing.Font("Noto Sans KR", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dateTimePicker1.Location = new System.Drawing.Point(300, 116);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(293, 38);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CalendarFont = new System.Drawing.Font("Noto Sans KR", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dateTimePicker2.Font = new System.Drawing.Font("Noto Sans KR", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dateTimePicker2.Location = new System.Drawing.Point(654, 116);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(293, 38);
            this.dateTimePicker2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("나눔고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(612, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "~";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(61, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 19);
            this.label4.TabIndex = 16;
            // 
            // WO_Grid
            // 
            this.WO_Grid.AllowCustomTheming = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Noto Sans KR", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.WO_Grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.WO_Grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.WO_Grid.BackgroundColor = System.Drawing.Color.White;
            this.WO_Grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.WO_Grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.WO_Grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Noto Sans KR", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.WO_Grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.WO_Grid.ColumnHeadersHeight = 40;
            this.WO_Grid.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.WO_Grid.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.WO_Grid.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.WO_Grid.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.WO_Grid.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.WO_Grid.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.WO_Grid.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.WO_Grid.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.SteelBlue;
            this.WO_Grid.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Noto Sans KR", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.WO_Grid.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.WO_Grid.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.DarkBlue;
            this.WO_Grid.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.WO_Grid.CurrentTheme.Name = null;
            this.WO_Grid.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.WO_Grid.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.WO_Grid.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.WO_Grid.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.WO_Grid.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.WO_Grid.DefaultCellStyle = dataGridViewCellStyle3;
            this.WO_Grid.EnableHeadersVisualStyles = false;
            this.WO_Grid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.WO_Grid.HeaderBackColor = System.Drawing.Color.SteelBlue;
            this.WO_Grid.HeaderBgColor = System.Drawing.Color.Empty;
            this.WO_Grid.HeaderForeColor = System.Drawing.Color.White;
            this.WO_Grid.Location = new System.Drawing.Point(54, 203);
            this.WO_Grid.Name = "WO_Grid";
            this.WO_Grid.ReadOnly = true;
            this.WO_Grid.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Noto Sans KR", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.WO_Grid.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.WO_Grid.RowTemplate.Height = 40;
            this.WO_Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.WO_Grid.Size = new System.Drawing.Size(1801, 359);
            this.WO_Grid.TabIndex = 20;
            this.WO_Grid.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            this.WO_Grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.WO_Grid_CellClick);
            // 
            // DEF_LOT_Grid
            // 
            this.DEF_LOT_Grid.AllowCustomTheming = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Noto Sans KR", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.DEF_LOT_Grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DEF_LOT_Grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DEF_LOT_Grid.BackgroundColor = System.Drawing.Color.White;
            this.DEF_LOT_Grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DEF_LOT_Grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DEF_LOT_Grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Noto Sans KR", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DEF_LOT_Grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.DEF_LOT_Grid.ColumnHeadersHeight = 40;
            this.DEF_LOT_Grid.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.DEF_LOT_Grid.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.DEF_LOT_Grid.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.DEF_LOT_Grid.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.DEF_LOT_Grid.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.DEF_LOT_Grid.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.DEF_LOT_Grid.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.DEF_LOT_Grid.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.SteelBlue;
            this.DEF_LOT_Grid.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Noto Sans KR", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.DEF_LOT_Grid.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DEF_LOT_Grid.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.MidnightBlue;
            this.DEF_LOT_Grid.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.DEF_LOT_Grid.CurrentTheme.Name = null;
            this.DEF_LOT_Grid.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DEF_LOT_Grid.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.DEF_LOT_Grid.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.DEF_LOT_Grid.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.DEF_LOT_Grid.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DEF_LOT_Grid.DefaultCellStyle = dataGridViewCellStyle7;
            this.DEF_LOT_Grid.EnableHeadersVisualStyles = false;
            this.DEF_LOT_Grid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.DEF_LOT_Grid.HeaderBackColor = System.Drawing.Color.SteelBlue;
            this.DEF_LOT_Grid.HeaderBgColor = System.Drawing.Color.Empty;
            this.DEF_LOT_Grid.HeaderForeColor = System.Drawing.Color.White;
            this.DEF_LOT_Grid.Location = new System.Drawing.Point(54, 624);
            this.DEF_LOT_Grid.Name = "DEF_LOT_Grid";
            this.DEF_LOT_Grid.ReadOnly = true;
            this.DEF_LOT_Grid.RowHeadersVisible = false;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Noto Sans KR", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.DEF_LOT_Grid.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.DEF_LOT_Grid.RowTemplate.Height = 40;
            this.DEF_LOT_Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DEF_LOT_Grid.Size = new System.Drawing.Size(1801, 358);
            this.DEF_LOT_Grid.TabIndex = 21;
            this.DEF_LOT_Grid.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            // 
            // btn_Main
            // 
            this.btn_Main.AllowAnimations = true;
            this.btn_Main.AllowMouseEffects = true;
            this.btn_Main.AllowToggling = false;
            this.btn_Main.AnimationSpeed = 200;
            this.btn_Main.AutoGenerateColors = false;
            this.btn_Main.AutoRoundBorders = false;
            this.btn_Main.AutoSizeLeftIcon = true;
            this.btn_Main.AutoSizeRightIcon = true;
            this.btn_Main.BackColor = System.Drawing.Color.Transparent;
            this.btn_Main.BackColor1 = System.Drawing.Color.DarkBlue;
            this.btn_Main.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Main.BackgroundImage")));
            this.btn_Main.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btn_Main.ButtonText = "메인화면";
            this.btn_Main.ButtonTextMarginLeft = 0;
            this.btn_Main.ColorContrastOnClick = 45;
            this.btn_Main.ColorContrastOnHover = 45;
            this.btn_Main.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btn_Main.CustomizableEdges = borderEdges1;
            this.btn_Main.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_Main.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btn_Main.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btn_Main.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btn_Main.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btn_Main.Font = new System.Drawing.Font("Noto Sans KR", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Main.ForeColor = System.Drawing.Color.White;
            this.btn_Main.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Main.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btn_Main.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btn_Main.IconMarginLeft = 11;
            this.btn_Main.IconPadding = 10;
            this.btn_Main.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Main.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btn_Main.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btn_Main.IconSize = 25;
            this.btn_Main.IdleBorderColor = System.Drawing.Color.DarkBlue;
            this.btn_Main.IdleBorderRadius = 20;
            this.btn_Main.IdleBorderThickness = 1;
            this.btn_Main.IdleFillColor = System.Drawing.Color.DarkBlue;
            this.btn_Main.IdleIconLeftImage = null;
            this.btn_Main.IdleIconRightImage = null;
            this.btn_Main.IndicateFocus = false;
            this.btn_Main.Location = new System.Drawing.Point(1640, 93);
            this.btn_Main.Name = "btn_Main";
            this.btn_Main.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btn_Main.OnDisabledState.BorderRadius = 20;
            this.btn_Main.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btn_Main.OnDisabledState.BorderThickness = 1;
            this.btn_Main.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btn_Main.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btn_Main.OnDisabledState.IconLeftImage = null;
            this.btn_Main.OnDisabledState.IconRightImage = null;
            this.btn_Main.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btn_Main.onHoverState.BorderRadius = 20;
            this.btn_Main.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btn_Main.onHoverState.BorderThickness = 1;
            this.btn_Main.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btn_Main.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btn_Main.onHoverState.IconLeftImage = null;
            this.btn_Main.onHoverState.IconRightImage = null;
            this.btn_Main.OnIdleState.BorderColor = System.Drawing.Color.DarkBlue;
            this.btn_Main.OnIdleState.BorderRadius = 20;
            this.btn_Main.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btn_Main.OnIdleState.BorderThickness = 1;
            this.btn_Main.OnIdleState.FillColor = System.Drawing.Color.DarkBlue;
            this.btn_Main.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btn_Main.OnIdleState.IconLeftImage = null;
            this.btn_Main.OnIdleState.IconRightImage = null;
            this.btn_Main.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btn_Main.OnPressedState.BorderRadius = 20;
            this.btn_Main.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btn_Main.OnPressedState.BorderThickness = 1;
            this.btn_Main.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btn_Main.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btn_Main.OnPressedState.IconLeftImage = null;
            this.btn_Main.OnPressedState.IconRightImage = null;
            this.btn_Main.Size = new System.Drawing.Size(238, 61);
            this.btn_Main.TabIndex = 41;
            this.btn_Main.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Main.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_Main.TextMarginLeft = 0;
            this.btn_Main.TextPadding = new System.Windows.Forms.Padding(0);
            this.btn_Main.UseDefaultRadiusAndThickness = true;
            this.btn_Main.Click += new System.EventHandler(this.btn_Main_Click);
            // 
            // Search_WO_Grid
            // 
            this.Search_WO_Grid.AllowAnimations = true;
            this.Search_WO_Grid.AllowMouseEffects = true;
            this.Search_WO_Grid.AllowToggling = false;
            this.Search_WO_Grid.AnimationSpeed = 200;
            this.Search_WO_Grid.AutoGenerateColors = false;
            this.Search_WO_Grid.AutoRoundBorders = false;
            this.Search_WO_Grid.AutoSizeLeftIcon = true;
            this.Search_WO_Grid.AutoSizeRightIcon = true;
            this.Search_WO_Grid.BackColor = System.Drawing.Color.Transparent;
            this.Search_WO_Grid.BackColor1 = System.Drawing.Color.SteelBlue;
            this.Search_WO_Grid.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Search_WO_Grid.BackgroundImage")));
            this.Search_WO_Grid.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.Search_WO_Grid.ButtonText = "조회";
            this.Search_WO_Grid.ButtonTextMarginLeft = 0;
            this.Search_WO_Grid.ColorContrastOnClick = 45;
            this.Search_WO_Grid.ColorContrastOnHover = 45;
            this.Search_WO_Grid.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.Search_WO_Grid.CustomizableEdges = borderEdges2;
            this.Search_WO_Grid.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Search_WO_Grid.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.Search_WO_Grid.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.Search_WO_Grid.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.Search_WO_Grid.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.Search_WO_Grid.Font = new System.Drawing.Font("Noto Sans KR", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Search_WO_Grid.ForeColor = System.Drawing.Color.White;
            this.Search_WO_Grid.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Search_WO_Grid.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.Search_WO_Grid.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.Search_WO_Grid.IconMarginLeft = 11;
            this.Search_WO_Grid.IconPadding = 10;
            this.Search_WO_Grid.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Search_WO_Grid.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.Search_WO_Grid.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.Search_WO_Grid.IconSize = 25;
            this.Search_WO_Grid.IdleBorderColor = System.Drawing.Color.SteelBlue;
            this.Search_WO_Grid.IdleBorderRadius = 20;
            this.Search_WO_Grid.IdleBorderThickness = 1;
            this.Search_WO_Grid.IdleFillColor = System.Drawing.Color.SteelBlue;
            this.Search_WO_Grid.IdleIconLeftImage = null;
            this.Search_WO_Grid.IdleIconRightImage = null;
            this.Search_WO_Grid.IndicateFocus = false;
            this.Search_WO_Grid.Location = new System.Drawing.Point(980, 108);
            this.Search_WO_Grid.Name = "Search_WO_Grid";
            this.Search_WO_Grid.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.Search_WO_Grid.OnDisabledState.BorderRadius = 20;
            this.Search_WO_Grid.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.Search_WO_Grid.OnDisabledState.BorderThickness = 1;
            this.Search_WO_Grid.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.Search_WO_Grid.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.Search_WO_Grid.OnDisabledState.IconLeftImage = null;
            this.Search_WO_Grid.OnDisabledState.IconRightImage = null;
            this.Search_WO_Grid.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.Search_WO_Grid.onHoverState.BorderRadius = 20;
            this.Search_WO_Grid.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.Search_WO_Grid.onHoverState.BorderThickness = 1;
            this.Search_WO_Grid.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.Search_WO_Grid.onHoverState.ForeColor = System.Drawing.Color.White;
            this.Search_WO_Grid.onHoverState.IconLeftImage = null;
            this.Search_WO_Grid.onHoverState.IconRightImage = null;
            this.Search_WO_Grid.OnIdleState.BorderColor = System.Drawing.Color.SteelBlue;
            this.Search_WO_Grid.OnIdleState.BorderRadius = 20;
            this.Search_WO_Grid.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.Search_WO_Grid.OnIdleState.BorderThickness = 1;
            this.Search_WO_Grid.OnIdleState.FillColor = System.Drawing.Color.SteelBlue;
            this.Search_WO_Grid.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.Search_WO_Grid.OnIdleState.IconLeftImage = null;
            this.Search_WO_Grid.OnIdleState.IconRightImage = null;
            this.Search_WO_Grid.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.Search_WO_Grid.OnPressedState.BorderRadius = 20;
            this.Search_WO_Grid.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.Search_WO_Grid.OnPressedState.BorderThickness = 1;
            this.Search_WO_Grid.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.Search_WO_Grid.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.Search_WO_Grid.OnPressedState.IconLeftImage = null;
            this.Search_WO_Grid.OnPressedState.IconRightImage = null;
            this.Search_WO_Grid.Size = new System.Drawing.Size(77, 46);
            this.Search_WO_Grid.TabIndex = 38;
            this.Search_WO_Grid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Search_WO_Grid.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Search_WO_Grid.TextMarginLeft = 0;
            this.Search_WO_Grid.TextPadding = new System.Windows.Forms.Padding(0);
            this.Search_WO_Grid.UseDefaultRadiusAndThickness = true;
            this.Search_WO_Grid.Click += new System.EventHandler(this.Search_WO_Grid_Click);
            // 
            // bunifuPanel1
            // 
            this.bunifuPanel1.BackgroundColor = System.Drawing.Color.White;
            this.bunifuPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel1.BackgroundImage")));
            this.bunifuPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel1.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuPanel1.BorderRadius = 30;
            this.bunifuPanel1.BorderThickness = 1;
            this.bunifuPanel1.Location = new System.Drawing.Point(34, 184);
            this.bunifuPanel1.Name = "bunifuPanel1";
            this.bunifuPanel1.ShowBorders = true;
            this.bunifuPanel1.Size = new System.Drawing.Size(1844, 398);
            this.bunifuPanel1.TabIndex = 39;
            // 
            // bunifuPanel2
            // 
            this.bunifuPanel2.BackgroundColor = System.Drawing.Color.White;
            this.bunifuPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel2.BackgroundImage")));
            this.bunifuPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel2.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuPanel2.BorderRadius = 30;
            this.bunifuPanel2.BorderThickness = 1;
            this.bunifuPanel2.Location = new System.Drawing.Point(34, 608);
            this.bunifuPanel2.Name = "bunifuPanel2";
            this.bunifuPanel2.ShowBorders = true;
            this.bunifuPanel2.Size = new System.Drawing.Size(1844, 390);
            this.bunifuPanel2.TabIndex = 40;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(34, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(245, 157);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // 생산일지
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(1924, 1061);
            this.Controls.Add(this.btn_Main);
            this.Controls.Add(this.Search_WO_Grid);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.WO_Grid);
            this.Controls.Add(this.DEF_LOT_Grid);
            this.Controls.Add(this.bunifuPanel1);
            this.Controls.Add(this.bunifuPanel2);
            this.Name = "생산일지";
            this.Load += new System.EventHandler(this.생산일지_Load);
            ((System.ComponentModel.ISupportInitialize)(this.WO_Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEF_LOT_Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Bunifu.UI.WinForms.BunifuDataGridView WO_Grid;
        private Bunifu.UI.WinForms.BunifuDataGridView DEF_LOT_Grid;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 Search_WO_Grid;
        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel1;
        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel2;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btn_Main;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}