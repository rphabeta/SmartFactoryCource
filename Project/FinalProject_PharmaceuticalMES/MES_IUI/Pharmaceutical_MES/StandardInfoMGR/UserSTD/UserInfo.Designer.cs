namespace Pharmaceutical_MES.StandardInfoMGR.UserSTD
{
    partial class UserInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserInfo));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.oracleCommand1 = new Oracle.ManagedDataAccess.Client.OracleCommand();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUSER_ID = new System.Windows.Forms.TextBox();
            this.txtUSER_NAME = new System.Windows.Forms.TextBox();
            this.btnEnquire = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.bunifuPanel1 = new Bunifu.UI.WinForms.BunifuPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvUserData = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.bunifuElipse_btnAdd = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse_btnModify = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse_btnDel = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse_btnEnquire = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse_btnReset = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuPanel2 = new Bunifu.UI.WinForms.BunifuPanel();
            this.bunifuElipse_dgvUserData = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserData)).BeginInit();
            this.bunifuPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // oracleCommand1
            // 
            this.oracleCommand1.Transaction = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Noto Sans KR", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(1107, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Noto Sans KR", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(1295, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "이름";
            // 
            // txtUSER_ID
            // 
            this.txtUSER_ID.Font = new System.Drawing.Font("Noto Sans KR", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtUSER_ID.Location = new System.Drawing.Point(1135, 13);
            this.txtUSER_ID.Name = "txtUSER_ID";
            this.txtUSER_ID.Size = new System.Drawing.Size(136, 25);
            this.txtUSER_ID.TabIndex = 4;
            // 
            // txtUSER_NAME
            // 
            this.txtUSER_NAME.Font = new System.Drawing.Font("Noto Sans KR", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtUSER_NAME.Location = new System.Drawing.Point(1336, 13);
            this.txtUSER_NAME.Name = "txtUSER_NAME";
            this.txtUSER_NAME.Size = new System.Drawing.Size(136, 25);
            this.txtUSER_NAME.TabIndex = 5;
            // 
            // btnEnquire
            // 
            this.btnEnquire.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.btnEnquire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnquire.Font = new System.Drawing.Font("Noto Sans KR SemiBold", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnEnquire.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.btnEnquire.Location = new System.Drawing.Point(1482, 8);
            this.btnEnquire.Name = "btnEnquire";
            this.btnEnquire.Size = new System.Drawing.Size(76, 35);
            this.btnEnquire.TabIndex = 6;
            this.btnEnquire.Text = "조회";
            this.btnEnquire.UseVisualStyleBackColor = false;
            this.btnEnquire.Click += new System.EventHandler(this.btnEnquire_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Noto Sans KR SemiBold", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.btnReset.Location = new System.Drawing.Point(1568, 8);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(76, 35);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "리셋";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnDel
            // 
            this.btnDel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.Font = new System.Drawing.Font("Noto Sans KR SemiBold", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnDel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.btnDel.Location = new System.Drawing.Point(1568, 8);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(76, 35);
            this.btnDel.TabIndex = 8;
            this.btnDel.Text = "삭제";
            this.btnDel.UseVisualStyleBackColor = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Noto Sans KR SemiBold", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.btnAdd.Location = new System.Drawing.Point(1396, 8);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(76, 35);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "추가";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnModify
            // 
            this.btnModify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.btnModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModify.Font = new System.Drawing.Font("Noto Sans KR SemiBold", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnModify.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.btnModify.Location = new System.Drawing.Point(1482, 8);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(76, 35);
            this.btnModify.TabIndex = 10;
            this.btnModify.Text = "수정";
            this.btnModify.UseVisualStyleBackColor = false;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // bunifuPanel1
            // 
            this.bunifuPanel1.BackgroundColor = System.Drawing.Color.White;
            this.bunifuPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel1.BackgroundImage")));
            this.bunifuPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel1.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuPanel1.BorderRadius = 15;
            this.bunifuPanel1.BorderThickness = 1;
            this.bunifuPanel1.Controls.Add(this.label8);
            this.bunifuPanel1.Controls.Add(this.dgvUserData);
            this.bunifuPanel1.Controls.Add(this.btnModify);
            this.bunifuPanel1.Controls.Add(this.btnAdd);
            this.bunifuPanel1.Controls.Add(this.btnDel);
            this.bunifuPanel1.Location = new System.Drawing.Point(24, 69);
            this.bunifuPanel1.Name = "bunifuPanel1";
            this.bunifuPanel1.ShowBorders = true;
            this.bunifuPanel1.Size = new System.Drawing.Size(1665, 944);
            this.bunifuPanel1.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Noto Sans KR", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(24, 13);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 24);
            this.label8.TabIndex = 59;
            this.label8.Text = "사용자 목록";
            // 
            // dgvUserData
            // 
            this.dgvUserData.AllowCustomTheming = true;
            this.dgvUserData.AllowUserToResizeColumns = false;
            this.dgvUserData.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgvUserData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUserData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUserData.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(225)))), ((int)(((byte)(237)))));
            this.dgvUserData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUserData.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvUserData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Noto Sans KR", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUserData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUserData.ColumnHeadersHeight = 40;
            this.dgvUserData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUserData.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.dgvUserData.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Noto Sans KR", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dgvUserData.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvUserData.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dgvUserData.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvUserData.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.dgvUserData.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dgvUserData.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.LightSteelBlue;
            this.dgvUserData.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Noto Sans KR", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dgvUserData.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvUserData.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.SteelBlue;
            this.dgvUserData.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvUserData.CurrentTheme.Name = null;
            this.dgvUserData.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvUserData.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Noto Sans KR", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dgvUserData.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvUserData.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dgvUserData.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Noto Sans KR", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUserData.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUserData.EnableHeadersVisualStyles = false;
            this.dgvUserData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dgvUserData.HeaderBackColor = System.Drawing.Color.LightSteelBlue;
            this.dgvUserData.HeaderBgColor = System.Drawing.Color.Empty;
            this.dgvUserData.HeaderForeColor = System.Drawing.Color.White;
            this.dgvUserData.Location = new System.Drawing.Point(21, 49);
            this.dgvUserData.Name = "dgvUserData";
            this.dgvUserData.RowHeadersVisible = false;
            this.dgvUserData.RowHeadersWidth = 62;
            this.dgvUserData.RowTemplate.Height = 40;
            this.dgvUserData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUserData.Size = new System.Drawing.Size(1623, 876);
            this.dgvUserData.TabIndex = 0;
            this.dgvUserData.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Noto Sans KR", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(23, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 30);
            this.label3.TabIndex = 13;
            this.label3.Text = "사용자 정보";
            // 
            // bunifuElipse_btnAdd
            // 
            this.bunifuElipse_btnAdd.ElipseRadius = 10;
            this.bunifuElipse_btnAdd.TargetControl = this.btnAdd;
            // 
            // bunifuElipse_btnModify
            // 
            this.bunifuElipse_btnModify.ElipseRadius = 6;
            this.bunifuElipse_btnModify.TargetControl = this.btnModify;
            // 
            // bunifuElipse_btnDel
            // 
            this.bunifuElipse_btnDel.ElipseRadius = 6;
            this.bunifuElipse_btnDel.TargetControl = this.btnDel;
            // 
            // bunifuElipse_btnEnquire
            // 
            this.bunifuElipse_btnEnquire.ElipseRadius = 6;
            this.bunifuElipse_btnEnquire.TargetControl = this.btnEnquire;
            // 
            // bunifuElipse_btnReset
            // 
            this.bunifuElipse_btnReset.ElipseRadius = 6;
            this.bunifuElipse_btnReset.TargetControl = this.btnReset;
            // 
            // bunifuPanel2
            // 
            this.bunifuPanel2.BackgroundColor = System.Drawing.Color.White;
            this.bunifuPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel2.BackgroundImage")));
            this.bunifuPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel2.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuPanel2.BorderRadius = 15;
            this.bunifuPanel2.BorderThickness = 1;
            this.bunifuPanel2.Controls.Add(this.label3);
            this.bunifuPanel2.Controls.Add(this.btnReset);
            this.bunifuPanel2.Controls.Add(this.btnEnquire);
            this.bunifuPanel2.Controls.Add(this.txtUSER_ID);
            this.bunifuPanel2.Controls.Add(this.label1);
            this.bunifuPanel2.Controls.Add(this.label2);
            this.bunifuPanel2.Controls.Add(this.txtUSER_NAME);
            this.bunifuPanel2.Location = new System.Drawing.Point(24, 12);
            this.bunifuPanel2.Name = "bunifuPanel2";
            this.bunifuPanel2.ShowBorders = true;
            this.bunifuPanel2.Size = new System.Drawing.Size(1665, 51);
            this.bunifuPanel2.TabIndex = 12;
            // 
            // bunifuElipse_dgvUserData
            // 
            this.bunifuElipse_dgvUserData.ElipseRadius = 6;
            this.bunifuElipse_dgvUserData.TargetControl = this.dgvUserData;
            // 
            // UserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.ClientSize = new System.Drawing.Size(1750, 1025);
            this.Controls.Add(this.bunifuPanel2);
            this.Controls.Add(this.bunifuPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserInfo";
            this.Text = "UserInfo";
            this.bunifuPanel1.ResumeLayout(false);
            this.bunifuPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserData)).EndInit();
            this.bunifuPanel2.ResumeLayout(false);
            this.bunifuPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Oracle.ManagedDataAccess.Client.OracleCommand oracleCommand1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUSER_ID;
        private System.Windows.Forms.TextBox txtUSER_NAME;
        private System.Windows.Forms.Button btnEnquire;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnModify;
        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse_btnAdd;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse_btnModify;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse_btnDel;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse_btnEnquire;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse_btnReset;
        private Bunifu.UI.WinForms.BunifuDataGridView dgvUserData;
        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel2;
        private System.Windows.Forms.Label label3;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse_dgvUserData;
        private System.Windows.Forms.Label label8;
    }
}