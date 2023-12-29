namespace Pharmaceutical_MES.ProcessMGR.ProcessMGR
{
    partial class ProcessDelete
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
            this.btnPROC_DELETE_Y = new System.Windows.Forms.Button();
            this.btnPROC_DELETE_N = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.Elipse_btnPROC_DELETE_Y = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.Elipse_btnPROC_DELETE_N = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse_Form = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.SuspendLayout();
            // 
            // btnPROC_DELETE_Y
            // 
            this.btnPROC_DELETE_Y.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.btnPROC_DELETE_Y.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.btnPROC_DELETE_Y.FlatAppearance.BorderSize = 0;
            this.btnPROC_DELETE_Y.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPROC_DELETE_Y.Font = new System.Drawing.Font("Noto Sans KR SemiBold", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnPROC_DELETE_Y.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.btnPROC_DELETE_Y.Location = new System.Drawing.Point(65, 100);
            this.btnPROC_DELETE_Y.Margin = new System.Windows.Forms.Padding(0);
            this.btnPROC_DELETE_Y.Name = "btnPROC_DELETE_Y";
            this.btnPROC_DELETE_Y.Size = new System.Drawing.Size(71, 30);
            this.btnPROC_DELETE_Y.TabIndex = 76;
            this.btnPROC_DELETE_Y.Text = "삭제";
            this.btnPROC_DELETE_Y.UseVisualStyleBackColor = false;
            this.btnPROC_DELETE_Y.Click += new System.EventHandler(this.btnPROC_DELETE_Y_Click);
            // 
            // btnPROC_DELETE_N
            // 
            this.btnPROC_DELETE_N.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.btnPROC_DELETE_N.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(109)))), ((int)(((byte)(156)))));
            this.btnPROC_DELETE_N.FlatAppearance.BorderSize = 0;
            this.btnPROC_DELETE_N.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPROC_DELETE_N.Font = new System.Drawing.Font("Noto Sans KR SemiBold", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnPROC_DELETE_N.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.btnPROC_DELETE_N.Location = new System.Drawing.Point(197, 100);
            this.btnPROC_DELETE_N.Margin = new System.Windows.Forms.Padding(0);
            this.btnPROC_DELETE_N.Name = "btnPROC_DELETE_N";
            this.btnPROC_DELETE_N.Size = new System.Drawing.Size(71, 30);
            this.btnPROC_DELETE_N.TabIndex = 75;
            this.btnPROC_DELETE_N.Text = "취소";
            this.btnPROC_DELETE_N.UseVisualStyleBackColor = false;
            this.btnPROC_DELETE_N.Click += new System.EventHandler(this.btnPROC_DELETE_N_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Noto Sans KR", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label7.Location = new System.Drawing.Point(68, 44);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(202, 24);
            this.label7.TabIndex = 63;
            this.label7.Text = "데이터를 삭제하시겠습니까?";
            // 
            // Elipse_btnPROC_DELETE_Y
            // 
            this.Elipse_btnPROC_DELETE_Y.ElipseRadius = 6;
            this.Elipse_btnPROC_DELETE_Y.TargetControl = this.btnPROC_DELETE_Y;
            // 
            // Elipse_btnPROC_DELETE_N
            // 
            this.Elipse_btnPROC_DELETE_N.ElipseRadius = 6;
            this.Elipse_btnPROC_DELETE_N.TargetControl = this.btnPROC_DELETE_N;
            // 
            // bunifuElipse_Form
            // 
            this.bunifuElipse_Form.ElipseRadius = 6;
            this.bunifuElipse_Form.TargetControl = this;
            // 
            // ProcessDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(330, 166);
            this.Controls.Add(this.btnPROC_DELETE_Y);
            this.Controls.Add(this.btnPROC_DELETE_N);
            this.Controls.Add(this.label7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ProcessDelete";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ProcessDelete";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnPROC_DELETE_Y;
        private System.Windows.Forms.Button btnPROC_DELETE_N;
        private System.Windows.Forms.Label label7;
        private Bunifu.Framework.UI.BunifuElipse Elipse_btnPROC_DELETE_Y;
        private Bunifu.Framework.UI.BunifuElipse Elipse_btnPROC_DELETE_N;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse_Form;
    }
}