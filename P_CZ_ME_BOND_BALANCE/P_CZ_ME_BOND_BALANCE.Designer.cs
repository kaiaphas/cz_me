namespace cz
{
    partial class P_CZ_ME_BOND_BALANCE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(P_CZ_ME_BOND_BALANCE));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._flexM = new Dass.FlexGrid.FlexGrid(this.components);
            this.panel1 = new Duzon.Common.Controls.PanelExt();
            this.dt기간 = new Duzon.Common.Controls.PeriodPicker();
            this.cbo거래처합산 = new Duzon.Common.Controls.DropDownComboBox();
            this.cbo조회구분 = new Duzon.Common.Controls.DropDownComboBox();
            this.panelExt13 = new Duzon.Common.Controls.PanelExt();
            this.labelExt10 = new Duzon.Common.Controls.LabelExt();
            this.dp조회일자 = new Duzon.Common.Controls.DatePicker();
            this.panelExt29 = new Duzon.Common.Controls.PanelExt();
            this.labelExt24 = new Duzon.Common.Controls.LabelExt();
            this.panelExt26 = new Duzon.Common.Controls.PanelExt();
            this.labelExt21 = new Duzon.Common.Controls.LabelExt();
            this.panelExt23 = new Duzon.Common.Controls.PanelExt();
            this.panelExt24 = new Duzon.Common.Controls.PanelExt();
            this.panel7 = new Duzon.Common.Controls.PanelExt();
            this.labelExt5 = new Duzon.Common.Controls.LabelExt();
            this.panelExt27 = new Duzon.Common.Controls.PanelExt();
            this.labelExt25 = new Duzon.Common.Controls.LabelExt();
            this.MULTI_CD_DEPT = new Duzon.Common.BpControls.BpComboBox();
            this.panelExt9 = new Duzon.Common.Controls.PanelExt();
            this.labelExt6 = new Duzon.Common.Controls.LabelExt();
            this.MULTI_CD_CORP = new Duzon.Common.BpControls.BpComboBox();
            this.mDataArea.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._flexM)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelExt13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dp조회일자)).BeginInit();
            this.panelExt29.SuspendLayout();
            this.panelExt26.SuspendLayout();
            this.panelExt23.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panelExt27.SuspendLayout();
            this.panelExt9.SuspendLayout();
            this.SuspendLayout();
            // 
            // mDataArea
            // 
            this.mDataArea.Controls.Add(this.tableLayoutPanel1);
            this.mDataArea.Size = new System.Drawing.Size(1346, 756);
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 470F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1346, 756);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // _flexM
            // 
            this._flexM.AllowFreezing = C1.Win.C1FlexGrid.AllowFreezingEnum.Both;
            this._flexM.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Both;
            this._flexM.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this._flexM.AutoResize = false;
            this._flexM.ColumnInfo = "1,1,0,0,0,90,Columns:0{TextAlign:CenterCenter;TextAlignFixed:CenterCenter;}\t";
            this._flexM.Dock = System.Windows.Forms.DockStyle.Fill;
            this._flexM.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw;
            this._flexM.EnabledHeaderCheck = true;
            this._flexM.Font = new System.Drawing.Font("굴림", 9F);
            this._flexM.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this._flexM.KeyActionLeft = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut;
            this._flexM.KeyActionRight = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut;
            this._flexM.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this._flexM.Location = new System.Drawing.Point(3, 41);
            this._flexM.Name = "_flexM";
            this._flexM.Rows.Count = 1;
            this._flexM.Rows.DefaultSize = 20;
            this._flexM.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this._flexM.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always;
            this._flexM.ShowSort = false;
            this._flexM.Size = new System.Drawing.Size(1340, 712);
            this._flexM.StyleInfo = resources.GetString("_flexM.StyleInfo");
            this._flexM.TabIndex = 21;
            this._flexM.UseGridCalculator = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.MULTI_CD_CORP);
            this.panel1.Controls.Add(this.dt기간);
            this.panel1.Controls.Add(this.cbo거래처합산);
            this.panel1.Controls.Add(this.cbo조회구분);
            this.panel1.Controls.Add(this.panelExt13);
            this.panel1.Controls.Add(this.dp조회일자);
            this.panel1.Controls.Add(this.panelExt29);
            this.panel1.Controls.Add(this.panelExt26);
            this.panel1.Controls.Add(this.panelExt23);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panelExt27);
            this.panel1.Controls.Add(this.MULTI_CD_DEPT);
            this.panel1.Controls.Add(this.panelExt9);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1340, 32);
            this.panel1.TabIndex = 20;
            // 
            // dt기간
            // 
            this.dt기간.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dt기간.Location = new System.Drawing.Point(72, 4);
            this.dt기간.MaximumSize = new System.Drawing.Size(185, 21);
            this.dt기간.MinimumSize = new System.Drawing.Size(185, 21);
            this.dt기간.Name = "dt기간";
            this.dt기간.Size = new System.Drawing.Size(185, 21);
            this.dt기간.TabIndex = 1972;
            // 
            // cbo거래처합산
            // 
            this.cbo거래처합산.AutoDropDown = true;
            this.cbo거래처합산.BackColor = System.Drawing.Color.White;
            this.cbo거래처합산.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo거래처합산.ItemHeight = 12;
            this.cbo거래처합산.Location = new System.Drawing.Point(722, 4);
            this.cbo거래처합산.Name = "cbo거래처합산";
            this.cbo거래처합산.Size = new System.Drawing.Size(89, 20);
            this.cbo거래처합산.TabIndex = 298;
            this.cbo거래처합산.UseKeyF3 = false;
            // 
            // cbo조회구분
            // 
            this.cbo조회구분.AutoDropDown = true;
            this.cbo조회구분.BackColor = System.Drawing.Color.White;
            this.cbo조회구분.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo조회구분.ItemHeight = 12;
            this.cbo조회구분.Location = new System.Drawing.Point(534, 4);
            this.cbo조회구분.Name = "cbo조회구분";
            this.cbo조회구분.Size = new System.Drawing.Size(90, 20);
            this.cbo조회구분.TabIndex = 296;
            this.cbo조회구분.UseKeyF3 = false;
            // 
            // panelExt13
            // 
            this.panelExt13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.panelExt13.Controls.Add(this.labelExt10);
            this.panelExt13.Location = new System.Drawing.Point(277, 1);
            this.panelExt13.Name = "panelExt13";
            this.panelExt13.Size = new System.Drawing.Size(70, 27);
            this.panelExt13.TabIndex = 263;
            // 
            // labelExt10
            // 
            this.labelExt10.BackColor = System.Drawing.Color.Transparent;
            this.labelExt10.Location = new System.Drawing.Point(4, 4);
            this.labelExt10.Name = "labelExt10";
            this.labelExt10.Size = new System.Drawing.Size(60, 18);
            this.labelExt10.TabIndex = 55;
            this.labelExt10.Text = "조회일자";
            this.labelExt10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dp조회일자
            // 
            this.dp조회일자.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dp조회일자.Location = new System.Drawing.Point(349, 4);
            this.dp조회일자.Mask = "####/##";
            this.dp조회일자.MaxDate = new System.DateTime(9999, 12, 31, 23, 59, 59, 999);
            this.dp조회일자.MaximumSize = new System.Drawing.Size(0, 21);
            this.dp조회일자.MinDate = new System.DateTime(1800, 1, 1, 0, 0, 0, 0);
            this.dp조회일자.Name = "dp조회일자";
            this.dp조회일자.ShowUpDown = true;
            this.dp조회일자.Size = new System.Drawing.Size(86, 21);
            this.dp조회일자.TabIndex = 270;
            this.dp조회일자.Tag = "";
            this.dp조회일자.Value = new System.DateTime(((long)(0)));
            // 
            // panelExt29
            // 
            this.panelExt29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.panelExt29.Controls.Add(this.labelExt24);
            this.panelExt29.Location = new System.Drawing.Point(637, 1);
            this.panelExt29.Name = "panelExt29";
            this.panelExt29.Size = new System.Drawing.Size(84, 27);
            this.panelExt29.TabIndex = 264;
            // 
            // labelExt24
            // 
            this.labelExt24.BackColor = System.Drawing.Color.Transparent;
            this.labelExt24.Location = new System.Drawing.Point(1, 4);
            this.labelExt24.Name = "labelExt24";
            this.labelExt24.Size = new System.Drawing.Size(80, 18);
            this.labelExt24.TabIndex = 55;
            this.labelExt24.Text = "거래처합산";
            this.labelExt24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelExt26
            // 
            this.panelExt26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.panelExt26.Controls.Add(this.labelExt21);
            this.panelExt26.Location = new System.Drawing.Point(452, 1);
            this.panelExt26.Name = "panelExt26";
            this.panelExt26.Size = new System.Drawing.Size(81, 27);
            this.panelExt26.TabIndex = 263;
            // 
            // labelExt21
            // 
            this.labelExt21.BackColor = System.Drawing.Color.Transparent;
            this.labelExt21.Location = new System.Drawing.Point(1, 5);
            this.labelExt21.Name = "labelExt21";
            this.labelExt21.Size = new System.Drawing.Size(79, 18);
            this.labelExt21.TabIndex = 55;
            this.labelExt21.Text = "조회구분";
            this.labelExt21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelExt23
            // 
            this.panelExt23.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelExt23.BackColor = System.Drawing.Color.Transparent;
            this.panelExt23.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelExt23.BackgroundImage")));
            this.panelExt23.Controls.Add(this.panelExt24);
            this.panelExt23.Font = new System.Drawing.Font("굴림", 9F);
            this.panelExt23.Location = new System.Drawing.Point(-78, 30);
            this.panelExt23.Name = "panelExt23";
            this.panelExt23.Size = new System.Drawing.Size(1494, 1);
            this.panelExt23.TabIndex = 253;
            // 
            // panelExt24
            // 
            this.panelExt24.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelExt24.BackColor = System.Drawing.Color.Transparent;
            this.panelExt24.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelExt24.BackgroundImage")));
            this.panelExt24.Font = new System.Drawing.Font("굴림", 9F);
            this.panelExt24.Location = new System.Drawing.Point(0, 24);
            this.panelExt24.Name = "panelExt24";
            this.panelExt24.Size = new System.Drawing.Size(1494, 1);
            this.panelExt24.TabIndex = 155;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.panel7.Controls.Add(this.labelExt5);
            this.panel7.Location = new System.Drawing.Point(1, 1);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(70, 27);
            this.panel7.TabIndex = 251;
            // 
            // labelExt5
            // 
            this.labelExt5.BackColor = System.Drawing.Color.Transparent;
            this.labelExt5.Location = new System.Drawing.Point(4, 4);
            this.labelExt5.Name = "labelExt5";
            this.labelExt5.Size = new System.Drawing.Size(60, 18);
            this.labelExt5.TabIndex = 55;
            this.labelExt5.Text = "기간";
            this.labelExt5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelExt27
            // 
            this.panelExt27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.panelExt27.Controls.Add(this.labelExt25);
            this.panelExt27.Location = new System.Drawing.Point(1059, 1);
            this.panelExt27.Name = "panelExt27";
            this.panelExt27.Size = new System.Drawing.Size(70, 27);
            this.panelExt27.TabIndex = 293;
            // 
            // labelExt25
            // 
            this.labelExt25.BackColor = System.Drawing.Color.Transparent;
            this.labelExt25.Location = new System.Drawing.Point(3, 5);
            this.labelExt25.Name = "labelExt25";
            this.labelExt25.Size = new System.Drawing.Size(64, 18);
            this.labelExt25.TabIndex = 55;
            this.labelExt25.Text = "부서";
            this.labelExt25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MULTI_CD_DEPT
            // 
            this.MULTI_CD_DEPT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MULTI_CD_DEPT.HelpID = Duzon.Common.Forms.Help.HelpID.P_USER;
            this.MULTI_CD_DEPT.Location = new System.Drawing.Point(1130, 4);
            this.MULTI_CD_DEPT.Name = "MULTI_CD_DEPT";
            this.MULTI_CD_DEPT.Size = new System.Drawing.Size(150, 21);
            this.MULTI_CD_DEPT.TabIndex = 292;
            this.MULTI_CD_DEPT.TabStop = false;
            this.MULTI_CD_DEPT.UserCodeName = "NM_DEPT";
            this.MULTI_CD_DEPT.UserCodeValue = "CD_DEPT";
            this.MULTI_CD_DEPT.UserHelpID = "H_CZ_HELP02";
            this.MULTI_CD_DEPT.QueryBefore += new Duzon.Common.BpControls.BpQueryHandler(this.MULTI_CD_DEPT_QueryBefore);
            // 
            // panelExt9
            // 
            this.panelExt9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.panelExt9.Controls.Add(this.labelExt6);
            this.panelExt9.Location = new System.Drawing.Point(822, 1);
            this.panelExt9.Name = "panelExt9";
            this.panelExt9.Size = new System.Drawing.Size(70, 27);
            this.panelExt9.TabIndex = 262;
            // 
            // labelExt6
            // 
            this.labelExt6.BackColor = System.Drawing.Color.Transparent;
            this.labelExt6.Location = new System.Drawing.Point(4, 4);
            this.labelExt6.Name = "labelExt6";
            this.labelExt6.Size = new System.Drawing.Size(60, 18);
            this.labelExt6.TabIndex = 55;
            this.labelExt6.Text = "거래처명";
            this.labelExt6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MULTI_CD_CORP
            // 
            this.MULTI_CD_CORP.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MULTI_CD_CORP.HelpID = Duzon.Common.Forms.Help.HelpID.P_USER;
            this.MULTI_CD_CORP.Location = new System.Drawing.Point(893, 5);
            this.MULTI_CD_CORP.Name = "MULTI_CD_CORP";
            this.MULTI_CD_CORP.Size = new System.Drawing.Size(150, 21);
            this.MULTI_CD_CORP.TabIndex = 1974;
            this.MULTI_CD_CORP.TabStop = false;
            this.MULTI_CD_CORP.UserCodeName = "biz_name";
            this.MULTI_CD_CORP.UserCodeValue = "CD_PARTNER";
            this.MULTI_CD_CORP.UserHelpID = "H_CZ_HELP02";
            this.MULTI_CD_CORP.QueryBefore += new Duzon.Common.BpControls.BpQueryHandler(this.MULTI_CD_CORP_QueryBefore);
            // 
            // P_CZ_ME_BOND_BALANCE
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Name = "P_CZ_ME_BOND_BALANCE";
            this.Size = new System.Drawing.Size(1346, 796);
            this.TitleText = "채권관리잔액";
            this.mDataArea.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._flexM)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panelExt13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dp조회일자)).EndInit();
            this.panelExt29.ResumeLayout(false);
            this.panelExt26.ResumeLayout(false);
            this.panelExt23.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panelExt27.ResumeLayout(false);
            this.panelExt9.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Dass.FlexGrid.FlexGrid _flexM;
        private Duzon.Common.Controls.PanelExt panel1;
        private Duzon.Common.Controls.PanelExt panel7;
        private Duzon.Common.Controls.LabelExt labelExt5;
        private Duzon.Common.Controls.PanelExt panelExt23;
        private Duzon.Common.Controls.PanelExt panelExt9;
        private Duzon.Common.Controls.LabelExt labelExt6;
        private Duzon.Common.Controls.PanelExt panelExt29;
        private Duzon.Common.Controls.LabelExt labelExt24;
        private Duzon.Common.Controls.PanelExt panelExt26;
        private Duzon.Common.Controls.LabelExt labelExt21;
        private Duzon.Common.Controls.PanelExt panelExt24;
        private Duzon.Common.Controls.PanelExt panelExt13;
        private Duzon.Common.Controls.LabelExt labelExt10;
        private Duzon.Common.Controls.DatePicker dp조회일자;
        private Duzon.Common.Controls.PanelExt panelExt27;
        private Duzon.Common.Controls.LabelExt labelExt25;
        private Duzon.Common.BpControls.BpComboBox MULTI_CD_DEPT;
        private Duzon.Common.Controls.DropDownComboBox cbo거래처합산;
        private Duzon.Common.Controls.DropDownComboBox cbo조회구분;
        private Duzon.Common.Controls.PeriodPicker dt기간;
        private Duzon.Common.BpControls.BpComboBox MULTI_CD_CORP;

    }
}
