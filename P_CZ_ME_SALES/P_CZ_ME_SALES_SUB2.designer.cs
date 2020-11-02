namespace cz
{
    partial class P_CZ_ME_SALES_SUB2
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbo후계정 = new Duzon.Common.Controls.DropDownComboBox();
            this.labelExt1 = new Duzon.Common.Controls.LabelExt();
            this.btn변경 = new System.Windows.Forms.Button();
            this.cbo전계정 = new Duzon.Common.Controls.DropDownComboBox();
            this.labelExt3 = new Duzon.Common.Controls.LabelExt();
            this.btn종료 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.closeButton)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cbo후계정);
            this.panel1.Controls.Add(this.labelExt1);
            this.panel1.Controls.Add(this.btn종료);
            this.panel1.Controls.Add(this.btn변경);
            this.panel1.Controls.Add(this.cbo전계정);
            this.panel1.Controls.Add(this.labelExt3);
            this.panel1.Location = new System.Drawing.Point(4, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(304, 103);
            this.panel1.TabIndex = 31;
            // 
            // cbo후계정
            // 
            this.cbo후계정.AutoDropDown = true;
            this.cbo후계정.BackColor = System.Drawing.Color.White;
            this.cbo후계정.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo후계정.ItemHeight = 12;
            this.cbo후계정.Location = new System.Drawing.Point(91, 61);
            this.cbo후계정.Name = "cbo후계정";
            this.cbo후계정.Size = new System.Drawing.Size(134, 20);
            this.cbo후계정.TabIndex = 301;
            this.cbo후계정.UseKeyF3 = false;
            // 
            // labelExt1
            // 
            this.labelExt1.BackColor = System.Drawing.Color.Transparent;
            this.labelExt1.Location = new System.Drawing.Point(7, 63);
            this.labelExt1.Name = "labelExt1";
            this.labelExt1.Size = new System.Drawing.Size(78, 18);
            this.labelExt1.TabIndex = 300;
            this.labelExt1.Text = "변경 후 계정";
            this.labelExt1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn변경
            // 
            this.btn변경.BackColor = System.Drawing.Color.SteelBlue;
            this.btn변경.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn변경.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn변경.Font = new System.Drawing.Font("굴림체", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn변경.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn변경.Location = new System.Drawing.Point(231, 3);
            this.btn변경.Name = "btn변경";
            this.btn변경.Size = new System.Drawing.Size(68, 45);
            this.btn변경.TabIndex = 298;
            this.btn변경.Text = "변경";
            this.btn변경.UseVisualStyleBackColor = false;
            // 
            // cbo전계정
            // 
            this.cbo전계정.AutoDropDown = true;
            this.cbo전계정.BackColor = System.Drawing.Color.White;
            this.cbo전계정.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo전계정.ItemHeight = 12;
            this.cbo전계정.Location = new System.Drawing.Point(91, 19);
            this.cbo전계정.Name = "cbo전계정";
            this.cbo전계정.Size = new System.Drawing.Size(134, 20);
            this.cbo전계정.TabIndex = 297;
            this.cbo전계정.UseKeyF3 = false;
            // 
            // labelExt3
            // 
            this.labelExt3.BackColor = System.Drawing.Color.Transparent;
            this.labelExt3.Location = new System.Drawing.Point(7, 21);
            this.labelExt3.Name = "labelExt3";
            this.labelExt3.Size = new System.Drawing.Size(78, 18);
            this.labelExt3.TabIndex = 55;
            this.labelExt3.Text = "변경 전 계정";
            this.labelExt3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn종료
            // 
            this.btn종료.BackColor = System.Drawing.Color.SteelBlue;
            this.btn종료.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn종료.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn종료.Font = new System.Drawing.Font("굴림체", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn종료.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn종료.Location = new System.Drawing.Point(231, 50);
            this.btn종료.Name = "btn종료";
            this.btn종료.Size = new System.Drawing.Size(68, 45);
            this.btn종료.TabIndex = 299;
            this.btn종료.Text = "취소";
            this.btn종료.UseVisualStyleBackColor = false;
            this.btn종료.Visible = false;
            // 
            // P_CZ_ME_SALES_SUB2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(312, 107);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "P_CZ_ME_SALES_SUB2";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ERP iU";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.closeButton)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Duzon.Common.Controls.LabelExt labelExt3;
        private Duzon.Common.Controls.DropDownComboBox cbo전계정;
        private Duzon.Common.Controls.DropDownComboBox cbo후계정;
        private Duzon.Common.Controls.LabelExt labelExt1;
        private System.Windows.Forms.Button btn변경;
        private System.Windows.Forms.Button btn종료;
    }
}