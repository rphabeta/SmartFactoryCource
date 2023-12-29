namespace Pharmaceutical_MES.ProcessMGR.BOMMGR
{
    partial class BOM_MODIFY
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
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
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
            this.btnPROC_DELETE_Y.Location = new System.Drawing.Point(93, 150);
            this.btnPROC_DELETE_Y.Margin = new System.Windows.Forms.Padding(0);
            this.btnPROC_DELETE_Y.Name = "btnPROC_DELETE_Y";
            this.btnPROC_DELETE_Y.Size = new System.Drawing.Size(101, 45);
            this.btnPROC_DELETE_Y.TabIndex = 79;
            this.btnPROC_DELETE_Y.Text = "수정";
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
            this.btnPROC_DELETE_N.Location = new System.Drawing.Point(281, 150);
            this.btnPROC_DELETE_N.Margin = new System.Windows.Forms.Padding(0);
            this.btnPROC_DELETE_N.Name = "btnPROC_DELETE_N";
            this.btnPROC_DELETE_N.Size = new System.Drawing.Size(101, 45);
            this.btnPROC_DELETE_N.TabIndex = 78;
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
            this.label7.Location = new System.Drawing.Point(97, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(298, 35);
            this.label7.TabIndex = 77;
            this.label7.Text = "데이터를 수정하시겠습니까?";
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // BOM_MODIFY
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(471, 249);
            this.Controls.Add(this.btnPROC_DELETE_Y);
            this.Controls.Add(this.btnPROC_DELETE_N);
            this.Controls.Add(this.label7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BOM_MODIFY";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BOM_MODIFY";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPROC_DELETE_Y;
        private System.Windows.Forms.Button btnPROC_DELETE_N;
        private System.Windows.Forms.Label label7;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
    }
}