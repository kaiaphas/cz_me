namespace cz
{
    partial class P_CZ_ME_MAP_DEPT
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(P_CZ_ME_MAP_DEPT));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._flexM = new Dass.FlexGrid.FlexGrid(this.components);
            this.panel1 = new Duzon.Common.Controls.PanelExt();
            this.panelExt1 = new Duzon.Common.Controls.PanelExt();
            this.rdoYn3 = new Duzon.Common.Controls.RadioButtonExt();
            this.rdoYn2 = new Duzon.Common.Controls.RadioButtonExt();
            this.rdoYn1 = new Duzon.Common.Controls.RadioButtonExt();
            this.panRadio2 = new Duzon.Common.Controls.PanelExt();
            this.rdoDz3 = new Duzon.Common.Controls.RadioButtonExt();
            this.rdoDz2 = new Duzon.Common.Controls.RadioButtonExt();
            this.rdoDz1 = new Duzon.Common.Controls.RadioButtonExt();
            this.panelExt2 = new Duzon.Common.Controls.PanelExt();
            this.labelExt1 = new Duzon.Common.Controls.LabelExt();
            this.panel7 = new Duzon.Common.Controls.PanelExt();
            this.lbl구분 = new Duzon.Common.Controls.LabelExt();
            this.btnMts연동 = new Duzon.Common.Controls.RoundedButton(this.components);
            this.panRadio1 = new Duzon.Common.Controls.PanelExt();
            this.rdoMts4 = new Duzon.Common.Controls.RadioButtonExt();
            this.rdoMts3 = new Duzon.Common.Controls.RadioButtonExt();
            this.rdoMts2 = new Duzon.Common.Controls.RadioButtonExt();
            this.rdoMts1 = new Duzon.Common.Controls.RadioButtonExt();
            this.mDataArea.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._flexM)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelExt1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdoYn3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoYn2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoYn1)).BeginInit();
            this.panRadio2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdoDz3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoDz2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoDz1)).BeginInit();
            this.panelExt2.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panRadio1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdoMts4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoMts3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoMts2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoMts1)).BeginInit();
            this.SuspendLayout();
            // 
            // mDataArea
            // 
            this.mDataArea.Controls.Add(this.tableLayoutPanel1);
            this.mDataArea.Size = new System.Drawing.Size(1090, 756);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this._flexM, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1090, 756);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // _flexM
            // 
            this._flexM.AllowFreezing = C1.Win.C1FlexGrid.AllowFreezingEnum.Both;
            this._flexM.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Both;
            this._flexM.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.MultiColumn;
            this._flexM.AutoResize = false;
            this._flexM.ColumnInfo = "1,1,0,0,0,90,Columns:0{TextAlign:CenterCenter;TextAlignFixed:CenterCenter;}\t";
            this._flexM.Dock = System.Windows.Forms.DockStyle.Fill;
            this._flexM.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw;
            this._flexM.EnabledHeaderCheck = true;
            this._flexM.Font = new System.Drawing.Font("굴림", 9F);
            this._flexM.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this._flexM.Location = new System.Drawing.Point(3, 39);
            this._flexM.Name = "_flexM";
            this._flexM.Rows.Count = 1;
            this._flexM.Rows.DefaultSize = 18;
            this._flexM.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this._flexM.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always;
            this._flexM.ShowSort = false;
            this._flexM.Size = new System.Drawing.Size(1084, 714);
            this._flexM.StyleInfo = resources.GetString("_flexM.StyleInfo");
            this._flexM.TabIndex = 156;
            this._flexM.UseGridCalculator = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panelExt1);
            this.panel1.Controls.Add(this.panRadio2);
            this.panel1.Controls.Add(this.panelExt2);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1084, 30);
            this.panel1.TabIndex = 1;
            // 
            // panelExt1
            // 
            this.panelExt1.Controls.Add(this.rdoYn3);
            this.panelExt1.Controls.Add(this.rdoYn2);
            this.panelExt1.Controls.Add(this.rdoYn1);
            this.panelExt1.Location = new System.Drawing.Point(497, 4);
            this.panelExt1.Name = "panelExt1";
            this.panelExt1.Size = new System.Drawing.Size(208, 21);
            this.panelExt1.TabIndex = 1957;
            // 
            // rdoYn3
            // 
            this.rdoYn3.Location = new System.Drawing.Point(122, 2);
            this.rdoYn3.Name = "rdoYn3";
            this.rdoYn3.Size = new System.Drawing.Size(78, 18);
            this.rdoYn3.TabIndex = 192;
            this.rdoYn3.Text = "미사용";
            this.rdoYn3.TextDD = null;
            this.rdoYn3.UseKeyEnter = true;
            this.rdoYn3.UseVisualStyleBackColor = true;
            // 
            // rdoYn2
            // 
            this.rdoYn2.Checked = true;
            this.rdoYn2.Location = new System.Drawing.Point(60, 2);
            this.rdoYn2.Name = "rdoYn2";
            this.rdoYn2.Size = new System.Drawing.Size(59, 18);
            this.rdoYn2.TabIndex = 191;
            this.rdoYn2.TabStop = true;
            this.rdoYn2.Text = "사용";
            this.rdoYn2.TextDD = null;
            this.rdoYn2.UseKeyEnter = true;
            this.rdoYn2.UseVisualStyleBackColor = true;
            // 
            // rdoYn1
            // 
            this.rdoYn1.Location = new System.Drawing.Point(3, 2);
            this.rdoYn1.Name = "rdoYn1";
            this.rdoYn1.Size = new System.Drawing.Size(51, 18);
            this.rdoYn1.TabIndex = 190;
            this.rdoYn1.Text = "전체";
            this.rdoYn1.TextDD = null;
            this.rdoYn1.UseKeyEnter = true;
            this.rdoYn1.UseVisualStyleBackColor = true;
            // 
            // panRadio2
            // 
            this.panRadio2.Controls.Add(this.rdoDz3);
            this.panRadio2.Controls.Add(this.rdoDz2);
            this.panRadio2.Controls.Add(this.rdoDz1);
            this.panRadio2.Location = new System.Drawing.Point(124, 4);
            this.panRadio2.Name = "panRadio2";
            this.panRadio2.Size = new System.Drawing.Size(208, 21);
            this.panRadio2.TabIndex = 1955;
            // 
            // rdoDz3
            // 
            this.rdoDz3.Location = new System.Drawing.Point(122, 2);
            this.rdoDz3.Name = "rdoDz3";
            this.rdoDz3.Size = new System.Drawing.Size(78, 18);
            this.rdoDz3.TabIndex = 192;
            this.rdoDz3.TabStop = true;
            this.rdoDz3.Text = "미반영";
            this.rdoDz3.TextDD = null;
            this.rdoDz3.UseKeyEnter = true;
            this.rdoDz3.UseVisualStyleBackColor = true;
            // 
            // rdoDz2
            // 
            this.rdoDz2.Location = new System.Drawing.Point(60, 2);
            this.rdoDz2.Name = "rdoDz2";
            this.rdoDz2.Size = new System.Drawing.Size(59, 18);
            this.rdoDz2.TabIndex = 191;
            this.rdoDz2.TabStop = true;
            this.rdoDz2.Text = "반영";
            this.rdoDz2.TextDD = null;
            this.rdoDz2.UseKeyEnter = true;
            this.rdoDz2.UseVisualStyleBackColor = true;
            // 
            // rdoDz1
            // 
            this.rdoDz1.Checked = true;
            this.rdoDz1.Location = new System.Drawing.Point(3, 2);
            this.rdoDz1.Name = "rdoDz1";
            this.rdoDz1.Size = new System.Drawing.Size(51, 18);
            this.rdoDz1.TabIndex = 190;
            this.rdoDz1.TabStop = true;
            this.rdoDz1.Text = "전체";
            this.rdoDz1.TextDD = null;
            this.rdoDz1.UseKeyEnter = true;
            this.rdoDz1.UseVisualStyleBackColor = true;
            // 
            // panelExt2
            // 
            this.panelExt2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.panelExt2.Controls.Add(this.labelExt1);
            this.panelExt2.Location = new System.Drawing.Point(372, -1);
            this.panelExt2.Name = "panelExt2";
            this.panelExt2.Size = new System.Drawing.Size(123, 31);
            this.panelExt2.TabIndex = 1958;
            // 
            // labelExt1
            // 
            this.labelExt1.BackColor = System.Drawing.Color.Transparent;
            this.labelExt1.Location = new System.Drawing.Point(23, 6);
            this.labelExt1.Name = "labelExt1";
            this.labelExt1.Size = new System.Drawing.Size(97, 18);
            this.labelExt1.TabIndex = 55;
            this.labelExt1.Text = "MTS사용유무";
            this.labelExt1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.panel7.Controls.Add(this.lbl구분);
            this.panel7.Location = new System.Drawing.Point(-1, -1);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(123, 31);
            this.panel7.TabIndex = 1956;
            // 
            // lbl구분
            // 
            this.lbl구분.BackColor = System.Drawing.Color.Transparent;
            this.lbl구분.Location = new System.Drawing.Point(60, 6);
            this.lbl구분.Name = "lbl구분";
            this.lbl구분.Size = new System.Drawing.Size(60, 18);
            this.lbl구분.TabIndex = 55;
            this.lbl구분.Text = "더존구분";
            this.lbl구분.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnMts연동
            // 
            this.btnMts연동.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMts연동.BackColor = System.Drawing.Color.White;
            this.btnMts연동.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMts연동.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMts연동.Location = new System.Drawing.Point(1012, 10);
            this.btnMts연동.MaximumSize = new System.Drawing.Size(0, 19);
            this.btnMts연동.Name = "btnMts연동";
            this.btnMts연동.Size = new System.Drawing.Size(78, 19);
            this.btnMts연동.TabIndex = 3;
            this.btnMts연동.TabStop = false;
            this.btnMts연동.Text = "체크반영";
            this.btnMts연동.UseVisualStyleBackColor = false;
            this.btnMts연동.Click += new System.EventHandler(this.btnMts연동_Click);
            // 
            // panRadio1
            // 
            this.panRadio1.Controls.Add(this.rdoMts4);
            this.panRadio1.Controls.Add(this.rdoMts3);
            this.panRadio1.Controls.Add(this.rdoMts2);
            this.panRadio1.Controls.Add(this.rdoMts1);
            this.panRadio1.Location = new System.Drawing.Point(98, 49);
            this.panRadio1.Name = "panRadio1";
            this.panRadio1.Size = new System.Drawing.Size(270, 21);
            this.panRadio1.TabIndex = 1;
            // 
            // rdoMts4
            // 
            this.rdoMts4.Location = new System.Drawing.Point(201, -1);
            this.rdoMts4.Name = "rdoMts4";
            this.rdoMts4.Size = new System.Drawing.Size(61, 24);
            this.rdoMts4.TabIndex = 193;
            this.rdoMts4.TabStop = true;
            this.rdoMts4.Text = "종료";
            this.rdoMts4.TextDD = null;
            this.rdoMts4.UseKeyEnter = true;
            this.rdoMts4.UseVisualStyleBackColor = true;
            // 
            // rdoMts3
            // 
            this.rdoMts3.Location = new System.Drawing.Point(134, 0);
            this.rdoMts3.Name = "rdoMts3";
            this.rdoMts3.Size = new System.Drawing.Size(61, 24);
            this.rdoMts3.TabIndex = 192;
            this.rdoMts3.TabStop = true;
            this.rdoMts3.Text = "수정";
            this.rdoMts3.TextDD = null;
            this.rdoMts3.UseKeyEnter = true;
            this.rdoMts3.UseVisualStyleBackColor = true;
            // 
            // rdoMts2
            // 
            this.rdoMts2.Location = new System.Drawing.Point(68, -1);
            this.rdoMts2.Name = "rdoMts2";
            this.rdoMts2.Size = new System.Drawing.Size(61, 24);
            this.rdoMts2.TabIndex = 191;
            this.rdoMts2.TabStop = true;
            this.rdoMts2.Text = "신규";
            this.rdoMts2.TextDD = null;
            this.rdoMts2.UseKeyEnter = true;
            this.rdoMts2.UseVisualStyleBackColor = true;
            // 
            // rdoMts1
            // 
            this.rdoMts1.Location = new System.Drawing.Point(6, -1);
            this.rdoMts1.Name = "rdoMts1";
            this.rdoMts1.Size = new System.Drawing.Size(64, 24);
            this.rdoMts1.TabIndex = 190;
            this.rdoMts1.TabStop = true;
            this.rdoMts1.Text = "전체";
            this.rdoMts1.TextDD = null;
            this.rdoMts1.UseKeyEnter = true;
            this.rdoMts1.UseVisualStyleBackColor = true;
            // 
            // P_CZ_ME_MAP_DEPT
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.btnMts연동);
            this.Controls.Add(this.panRadio1);
            this.Name = "P_CZ_ME_MAP_DEPT";
            this.Size = new System.Drawing.Size(1090, 796);
            this.TitleText = "MTS연동-부서";
            this.Controls.SetChildIndex(this.panRadio1, 0);
            this.Controls.SetChildIndex(this.btnMts연동, 0);
            this.Controls.SetChildIndex(this.mDataArea, 0);
            this.mDataArea.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._flexM)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panelExt1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rdoYn3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoYn2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoYn1)).EndInit();
            this.panRadio2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rdoDz3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoDz2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoDz1)).EndInit();
            this.panelExt2.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panRadio1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rdoMts4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoMts3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoMts2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoMts1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Duzon.Common.Controls.PanelExt panel1;
        private Duzon.Common.Controls.RoundedButton btnMts연동;
        private Duzon.Common.Controls.PanelExt panRadio1;
        private Duzon.Common.Controls.RadioButtonExt rdoMts4;
        private Duzon.Common.Controls.RadioButtonExt rdoMts3;
        private Duzon.Common.Controls.RadioButtonExt rdoMts2;
        private Duzon.Common.Controls.RadioButtonExt rdoMts1;
        private Dass.FlexGrid.FlexGrid _flexM;
        private Duzon.Common.Controls.PanelExt panelExt1;
        private Duzon.Common.Controls.RadioButtonExt rdoYn3;
        private Duzon.Common.Controls.RadioButtonExt rdoYn2;
        private Duzon.Common.Controls.RadioButtonExt rdoYn1;
        private Duzon.Common.Controls.PanelExt panRadio2;
        private Duzon.Common.Controls.RadioButtonExt rdoDz3;
        private Duzon.Common.Controls.RadioButtonExt rdoDz2;
        private Duzon.Common.Controls.RadioButtonExt rdoDz1;
        private Duzon.Common.Controls.PanelExt panelExt2;
        private Duzon.Common.Controls.LabelExt labelExt1;
        private Duzon.Common.Controls.PanelExt panel7;
        private Duzon.Common.Controls.LabelExt lbl구분;

    }
}
