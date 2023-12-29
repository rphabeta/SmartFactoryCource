namespace Final_FUI
{
    partial class LOT추가
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOT추가));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            this.label1 = new System.Windows.Forms.Label();
            this.cboEqptid = new System.Windows.Forms.ComboBox();
            this.btnLOTAdd = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Noto Sans KR", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(50, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 46);
            this.label1.TabIndex = 2;
            this.label1.Text = "설비명";
            // 
            // cboEqptid
            // 
            this.cboEqptid.Font = new System.Drawing.Font("Noto Sans KR", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboEqptid.FormattingEnabled = true;
            this.cboEqptid.Items.AddRange(new object[] {
            "과립1호",
            "과립2호",
            "타정1호",
            "타정2호",
            "포장1호"});
            this.cboEqptid.Location = new System.Drawing.Point(183, 81);
            this.cboEqptid.Name = "cboEqptid";
            this.cboEqptid.Size = new System.Drawing.Size(298, 54);
            this.cboEqptid.TabIndex = 4;
            this.cboEqptid.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnLOTAdd
            // 
            this.btnLOTAdd.AllowAnimations = true;
            this.btnLOTAdd.AllowMouseEffects = true;
            this.btnLOTAdd.AllowToggling = false;
            this.btnLOTAdd.AnimationSpeed = 200;
            this.btnLOTAdd.AutoGenerateColors = false;
            this.btnLOTAdd.AutoRoundBorders = false;
            this.btnLOTAdd.AutoSizeLeftIcon = true;
            this.btnLOTAdd.AutoSizeRightIcon = true;
            this.btnLOTAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnLOTAdd.BackColor1 = System.Drawing.Color.DarkBlue;
            this.btnLOTAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLOTAdd.BackgroundImage")));
            this.btnLOTAdd.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnLOTAdd.ButtonText = "확인";
            this.btnLOTAdd.ButtonTextMarginLeft = 0;
            this.btnLOTAdd.ColorContrastOnClick = 45;
            this.btnLOTAdd.ColorContrastOnHover = 45;
            this.btnLOTAdd.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnLOTAdd.CustomizableEdges = borderEdges1;
            this.btnLOTAdd.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnLOTAdd.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnLOTAdd.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnLOTAdd.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnLOTAdd.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btnLOTAdd.Font = new System.Drawing.Font("Noto Sans KR", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLOTAdd.ForeColor = System.Drawing.Color.White;
            this.btnLOTAdd.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLOTAdd.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnLOTAdd.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnLOTAdd.IconMarginLeft = 11;
            this.btnLOTAdd.IconPadding = 10;
            this.btnLOTAdd.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLOTAdd.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnLOTAdd.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnLOTAdd.IconSize = 25;
            this.btnLOTAdd.IdleBorderColor = System.Drawing.Color.DarkBlue;
            this.btnLOTAdd.IdleBorderRadius = 40;
            this.btnLOTAdd.IdleBorderThickness = 1;
            this.btnLOTAdd.IdleFillColor = System.Drawing.Color.DarkBlue;
            this.btnLOTAdd.IdleIconLeftImage = null;
            this.btnLOTAdd.IdleIconRightImage = null;
            this.btnLOTAdd.IndicateFocus = false;
            this.btnLOTAdd.Location = new System.Drawing.Point(133, 173);
            this.btnLOTAdd.Name = "btnLOTAdd";
            this.btnLOTAdd.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnLOTAdd.OnDisabledState.BorderRadius = 40;
            this.btnLOTAdd.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnLOTAdd.OnDisabledState.BorderThickness = 1;
            this.btnLOTAdd.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnLOTAdd.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnLOTAdd.OnDisabledState.IconLeftImage = null;
            this.btnLOTAdd.OnDisabledState.IconRightImage = null;
            this.btnLOTAdd.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnLOTAdd.onHoverState.BorderRadius = 40;
            this.btnLOTAdd.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnLOTAdd.onHoverState.BorderThickness = 1;
            this.btnLOTAdd.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnLOTAdd.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnLOTAdd.onHoverState.IconLeftImage = null;
            this.btnLOTAdd.onHoverState.IconRightImage = null;
            this.btnLOTAdd.OnIdleState.BorderColor = System.Drawing.Color.DarkBlue;
            this.btnLOTAdd.OnIdleState.BorderRadius = 40;
            this.btnLOTAdd.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnLOTAdd.OnIdleState.BorderThickness = 1;
            this.btnLOTAdd.OnIdleState.FillColor = System.Drawing.Color.DarkBlue;
            this.btnLOTAdd.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnLOTAdd.OnIdleState.IconLeftImage = null;
            this.btnLOTAdd.OnIdleState.IconRightImage = null;
            this.btnLOTAdd.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnLOTAdd.OnPressedState.BorderRadius = 40;
            this.btnLOTAdd.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnLOTAdd.OnPressedState.BorderThickness = 1;
            this.btnLOTAdd.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnLOTAdd.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnLOTAdd.OnPressedState.IconLeftImage = null;
            this.btnLOTAdd.OnPressedState.IconRightImage = null;
            this.btnLOTAdd.Size = new System.Drawing.Size(269, 46);
            this.btnLOTAdd.TabIndex = 8;
            this.btnLOTAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLOTAdd.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnLOTAdd.TextMarginLeft = 0;
            this.btnLOTAdd.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnLOTAdd.UseDefaultRadiusAndThickness = true;
            this.btnLOTAdd.Click += new System.EventHandler(this.btnLOTAdd_Click);
            // 
            // LOT추가
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(534, 270);
            this.Controls.Add(this.btnLOTAdd);
            this.Controls.Add(this.cboEqptid);
            this.Controls.Add(this.label1);
            this.Name = "LOT추가";
            this.Text = "LOT추가";
            this.Load += new System.EventHandler(this.LOT추가_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboEqptid;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnLOTAdd;
    }
}