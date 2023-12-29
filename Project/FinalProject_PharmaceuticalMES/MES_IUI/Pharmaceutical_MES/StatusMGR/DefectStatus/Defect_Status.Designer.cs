namespace Pharmaceutical_MES.DefectStatus
{
    partial class Defect_Status
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Defect_Status));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.bunifuElipse_btnChart = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse_Search = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.btnSearch = new System.Windows.Forms.Button();
            this.bunifuElipse_gvDefect = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.gvDefect = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.bunifuPanel2 = new Bunifu.UI.WinForms.BunifuPanel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label8 = new System.Windows.Forms.Label();
            this.bunifuPanel1 = new Bunifu.UI.WinForms.BunifuPanel();
            this.cbGroupOption = new System.Windows.Forms.ComboBox();
            this.cbPRODSTATS = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvDefect)).BeginInit();
            this.bunifuPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.bunifuPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse_btnChart
            // 
            this.bunifuElipse_btnChart.ElipseRadius = 6;
            this.bunifuElipse_btnChart.TargetControl = this;
            // 
            // bunifuElipse_Search
            // 
            this.bunifuElipse_Search.ElipseRadius = 6;
            this.bunifuElipse_Search.TargetControl = this.btnSearch;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Noto Sans KR SemiBold", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.btnSearch.Location = new System.Drawing.Point(1568, 8);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(76, 35);
            this.btnSearch.TabIndex = 55;
            this.btnSearch.Text = "조회";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // bunifuElipse_gvDefect
            // 
            this.bunifuElipse_gvDefect.ElipseRadius = 6;
            this.bunifuElipse_gvDefect.TargetControl = this.gvDefect;
            // 
            // gvDefect
            // 
            this.gvDefect.AllowCustomTheming = true;
            this.gvDefect.AllowUserToResizeColumns = false;
            this.gvDefect.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.gvDefect.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvDefect.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvDefect.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(225)))), ((int)(((byte)(237)))));
            this.gvDefect.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvDefect.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gvDefect.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Noto Sans KR SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvDefect.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Noto Sans KR SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvDefect.DefaultCellStyle = dataGridViewCellStyle3;
            this.gvDefect.EnableHeadersVisualStyles = false;
            this.gvDefect.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.gvDefect.HeaderBackColor = System.Drawing.Color.LightSteelBlue;
            this.gvDefect.HeaderBgColor = System.Drawing.Color.Empty;
            this.gvDefect.HeaderForeColor = System.Drawing.Color.White;
            this.gvDefect.Location = new System.Drawing.Point(21, 49);
            this.gvDefect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gvDefect.Name = "gvDefect";
            this.gvDefect.RowHeadersVisible = false;
            this.gvDefect.RowHeadersWidth = 62;
            this.gvDefect.RowTemplate.Height = 40;
            this.gvDefect.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvDefect.Size = new System.Drawing.Size(1623, 278);
            this.gvDefect.TabIndex = 60;
            this.gvDefect.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            // 
            // bunifuPanel2
            // 
            this.bunifuPanel2.BackgroundColor = System.Drawing.Color.White;
            this.bunifuPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel2.BackgroundImage")));
            this.bunifuPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel2.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuPanel2.BorderRadius = 15;
            this.bunifuPanel2.BorderThickness = 1;
            this.bunifuPanel2.Controls.Add(this.chart1);
            this.bunifuPanel2.Controls.Add(this.label8);
            this.bunifuPanel2.Controls.Add(this.gvDefect);
            this.bunifuPanel2.Location = new System.Drawing.Point(24, 73);
            this.bunifuPanel2.Name = "bunifuPanel2";
            this.bunifuPanel2.ShowBorders = true;
            this.bunifuPanel2.Size = new System.Drawing.Size(1665, 939);
            this.bunifuPanel2.TabIndex = 59;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(21, 331);
            this.chart1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1623, 586);
            this.chart1.TabIndex = 61;
            this.chart1.Text = "chart1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Noto Sans KR", 12F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(24, 12);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 24);
            this.label8.TabIndex = 58;
            this.label8.Text = "불량품 목록";
            // 
            // bunifuPanel1
            // 
            this.bunifuPanel1.BackgroundColor = System.Drawing.Color.White;
            this.bunifuPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel1.BackgroundImage")));
            this.bunifuPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel1.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuPanel1.BorderRadius = 15;
            this.bunifuPanel1.BorderThickness = 1;
            this.bunifuPanel1.Controls.Add(this.cbGroupOption);
            this.bunifuPanel1.Controls.Add(this.cbPRODSTATS);
            this.bunifuPanel1.Controls.Add(this.label7);
            this.bunifuPanel1.Controls.Add(this.btnSearch);
            this.bunifuPanel1.Controls.Add(this.label1);
            this.bunifuPanel1.Controls.Add(this.label3);
            this.bunifuPanel1.Location = new System.Drawing.Point(24, 12);
            this.bunifuPanel1.Name = "bunifuPanel1";
            this.bunifuPanel1.ShowBorders = true;
            this.bunifuPanel1.Size = new System.Drawing.Size(1665, 51);
            this.bunifuPanel1.TabIndex = 58;
            // 
            // cbGroupOption
            // 
            this.cbGroupOption.Font = new System.Drawing.Font("Noto Sans KR", 9.75F);
            this.cbGroupOption.FormattingEnabled = true;
            this.cbGroupOption.Location = new System.Drawing.Point(1408, 12);
            this.cbGroupOption.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbGroupOption.Name = "cbGroupOption";
            this.cbGroupOption.Size = new System.Drawing.Size(136, 27);
            this.cbGroupOption.TabIndex = 59;
            // 
            // cbPRODSTATS
            // 
            this.cbPRODSTATS.Font = new System.Drawing.Font("Noto Sans KR", 9.75F);
            this.cbPRODSTATS.FormattingEnabled = true;
            this.cbPRODSTATS.Location = new System.Drawing.Point(1178, 12);
            this.cbPRODSTATS.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbPRODSTATS.Name = "cbPRODSTATS";
            this.cbPRODSTATS.Size = new System.Drawing.Size(136, 27);
            this.cbPRODSTATS.TabIndex = 58;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Noto Sans KR", 15.75F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(23, 10);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 30);
            this.label7.TabIndex = 57;
            this.label7.Text = "종합현황";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Noto Sans KR", 9.75F);
            this.label1.Location = new System.Drawing.Point(1344, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 19);
            this.label1.TabIndex = 43;
            this.label1.Text = "집계기준";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Noto Sans KR", 9.75F);
            this.label3.Location = new System.Drawing.Point(1110, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 19);
            this.label3.TabIndex = 47;
            this.label3.Text = "제품 상태";
            // 
            // Defect_Status
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1750, 1040);
            this.Controls.Add(this.bunifuPanel2);
            this.Controls.Add(this.bunifuPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Defect_Status";
            this.Text = "DefectStatus";
            this.Load += new System.EventHandler(this.DefectStatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvDefect)).EndInit();
            this.bunifuPanel2.ResumeLayout(false);
            this.bunifuPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.bunifuPanel1.ResumeLayout(false);
            this.bunifuPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel1;
        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel2;
        private Bunifu.UI.WinForms.BunifuDataGridView gvDefect;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse_btnChart;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse_Search;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse_gvDefect;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbPRODSTATS;
        private System.Windows.Forms.ComboBox cbGroupOption;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}