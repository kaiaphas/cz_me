namespace cz
{
    partial class P_CZ_ME_SALES_PAYABLELIST
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(P_CZ_ME_SALES_PAYABLELIST));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._flexM = new Dass.FlexGrid.FlexGrid(this.components);
            this.panel1 = new Duzon.Common.Controls.PanelExt();
            this.bp_CD_ACCT = new Duzon.Common.BpControls.BpCodeTextBox();
            this.dt회계일자 = new Duzon.Common.Controls.PeriodPicker();
            this.panel7 = new Duzon.Common.Controls.PanelExt();
            this.labelExt5 = new Duzon.Common.Controls.LabelExt();
            this.MULTI_CD_CORP = new Duzon.Common.BpControls.BpComboBox();
            this.panelExt26 = new Duzon.Common.Controls.PanelExt();
            this.lb_NM_ACCT = new Duzon.Common.Controls.LabelExt();
            this.panelExt23 = new Duzon.Common.Controls.PanelExt();
            this.panelExt24 = new Duzon.Common.Controls.PanelExt();
            this.panelExt9 = new Duzon.Common.Controls.PanelExt();
            this.labelExt6 = new Duzon.Common.Controls.LabelExt();
            this.btn전표반영 = new Duzon.Common.Controls.RoundedButton(this.components);
            this.btn이체내역관리 = new Duzon.Common.Controls.RoundedButton(this.components);
            this.mDataArea.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._flexM)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panelExt26.SuspendLayout();
            this.panelExt23.SuspendLayout();
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
            this.panel1.Controls.Add(this.bp_CD_ACCT);
            this.panel1.Controls.Add(this.dt회계일자);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.MULTI_CD_CORP);
            this.panel1.Controls.Add(this.panelExt26);
            this.panel1.Controls.Add(this.panelExt23);
            this.panel1.Controls.Add(this.panelExt9);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1340, 32);
            this.panel1.TabIndex = 20;
            // 
            // bp_CD_ACCT
            // 
            this.bp_CD_ACCT.HelpID = Duzon.Common.Forms.Help.HelpID.P_FI_BANK_SENDACCT_SUB;
            this.bp_CD_ACCT.ItemBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.bp_CD_ACCT.Location = new System.Drawing.Point(513, 4);
            this.bp_CD_ACCT.Name = "bp_CD_ACCT";
            this.bp_CD_ACCT.Size = new System.Drawing.Size(150, 21);
            this.bp_CD_ACCT.TabIndex = 1977;
            this.bp_CD_ACCT.TabStop = false;
            // 
            // dt회계일자
            // 
            this.dt회계일자.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dt회계일자.Location = new System.Drawing.Point(72, 5);
            this.dt회계일자.MaximumSize = new System.Drawing.Size(185, 21);
            this.dt회계일자.MinimumSize = new System.Drawing.Size(185, 21);
            this.dt회계일자.Name = "dt회계일자";
            this.dt회계일자.Size = new System.Drawing.Size(185, 21);
            this.dt회계일자.TabIndex = 1975;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.panel7.Controls.Add(this.labelExt5);
            this.panel7.Location = new System.Drawing.Point(1, 2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(70, 27);
            this.panel7.TabIndex = 1974;
            // 
            // labelExt5
            // 
            this.labelExt5.BackColor = System.Drawing.Color.Transparent;
            this.labelExt5.Location = new System.Drawing.Point(4, 4);
            this.labelExt5.Name = "labelExt5";
            this.labelExt5.Size = new System.Drawing.Size(60, 18);
            this.labelExt5.TabIndex = 55;
            this.labelExt5.Text = "회계일자";
            this.labelExt5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MULTI_CD_CORP
            // 
            this.MULTI_CD_CORP.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MULTI_CD_CORP.HelpID = Duzon.Common.Forms.Help.HelpID.P_USER;
            this.MULTI_CD_CORP.Location = new System.Drawing.Point(901, 4);
            this.MULTI_CD_CORP.Name = "MULTI_CD_CORP";
            this.MULTI_CD_CORP.Size = new System.Drawing.Size(150, 21);
            this.MULTI_CD_CORP.TabIndex = 1973;
            this.MULTI_CD_CORP.TabStop = false;
            this.MULTI_CD_CORP.UserCodeName = "biz_name";
            this.MULTI_CD_CORP.UserCodeValue = "CD_PARTNER";
            this.MULTI_CD_CORP.UserHelpID = "H_CZ_HELP02";
            this.MULTI_CD_CORP.QueryBefore += new Duzon.Common.BpControls.BpQueryHandler(this.MULTI_CD_CORP_QueryBefore);
            // 
            // panelExt26
            // 
            this.panelExt26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.panelExt26.Controls.Add(this.lb_NM_ACCT);
            this.panelExt26.Location = new System.Drawing.Point(431, 0);
            this.panelExt26.Name = "panelExt26";
            this.panelExt26.Size = new System.Drawing.Size(81, 27);
            this.panelExt26.TabIndex = 263;
            // 
            // lb_NM_ACCT
            // 
            this.lb_NM_ACCT.BackColor = System.Drawing.Color.Transparent;
            this.lb_NM_ACCT.Location = new System.Drawing.Point(1, 5);
            this.lb_NM_ACCT.Name = "lb_NM_ACCT";
            this.lb_NM_ACCT.Size = new System.Drawing.Size(79, 18);
            this.lb_NM_ACCT.TabIndex = 55;
            this.lb_NM_ACCT.Text = "계정코드";
            this.lb_NM_ACCT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelExt23
            // 
            this.panelExt23.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelExt23.BackColor = System.Drawing.Color.Transparent;
            this.panelExt23.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelExt23.BackgroundImage")));
            this.panelExt23.Controls.Add(this.panelExt24);
            this.panelExt23.Font = new System.Drawing.Font("굴림", 9F);
            this.panelExt23.Location = new System.Drawing.Point(-386, 27);
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
            // panelExt9
            // 
            this.panelExt9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.panelExt9.Controls.Add(this.labelExt6);
            this.panelExt9.Location = new System.Drawing.Point(830, 1);
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
            // btn전표반영
            // 
            this.btn전표반영.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn전표반영.BackColor = System.Drawing.Color.White;
            this.btn전표반영.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn전표반영.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn전표반영.Location = new System.Drawing.Point(1139, 12);
            this.btn전표반영.MaximumSize = new System.Drawing.Size(0, 19);
            this.btn전표반영.Name = "btn전표반영";
            this.btn전표반영.Size = new System.Drawing.Size(70, 19);
            this.btn전표반영.TabIndex = 8;
            this.btn전표반영.TabStop = false;
            this.btn전표반영.Text = "전표반영";
            this.btn전표반영.UseVisualStyleBackColor = false;
            // 
            // btn이체내역관리
            // 
            this.btn이체내역관리.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn이체내역관리.BackColor = System.Drawing.Color.White;
            this.btn이체내역관리.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn이체내역관리.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn이체내역관리.Location = new System.Drawing.Point(1215, 12);
            this.btn이체내역관리.MaximumSize = new System.Drawing.Size(0, 19);
            this.btn이체내역관리.Name = "btn이체내역관리";
            this.btn이체내역관리.Size = new System.Drawing.Size(128, 19);
            this.btn이체내역관리.TabIndex = 9;
            this.btn이체내역관리.TabStop = false;
            this.btn이체내역관리.Text = "이체내역관리(반제)";
            this.btn이체내역관리.UseVisualStyleBackColor = false;
            // 
            // P_CZ_ME_SALES_PAYABLELIST
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.btn이체내역관리);
            this.Controls.Add(this.btn전표반영);
            this.Name = "P_CZ_ME_SALES_PAYABLELIST";
            this.Size = new System.Drawing.Size(1346, 796);
            this.TitleText = "지급리스트";
            this.Controls.SetChildIndex(this.mDataArea, 0);
            this.Controls.SetChildIndex(this.btn전표반영, 0);
            this.Controls.SetChildIndex(this.btn이체내역관리, 0);
            this.mDataArea.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._flexM)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panelExt26.ResumeLayout(false);
            this.panelExt23.ResumeLayout(false);
            this.panelExt9.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Dass.FlexGrid.FlexGrid _flexM;
        private Duzon.Common.Controls.PanelExt panel1;
        private Duzon.Common.Controls.PanelExt panelExt23;
        private Duzon.Common.Controls.PanelExt panelExt9;
        private Duzon.Common.Controls.LabelExt labelExt6;
        private Duzon.Common.Controls.PanelExt panelExt26;
        private Duzon.Common.Controls.LabelExt lb_NM_ACCT;
        private Duzon.Common.Controls.PanelExt panelExt24;
        private Duzon.Common.BpControls.BpComboBox MULTI_CD_CORP;
        private Duzon.Common.Controls.PeriodPicker dt회계일자;
        private Duzon.Common.Controls.PanelExt panel7;
        private Duzon.Common.Controls.LabelExt labelExt5;
        private Duzon.Common.Controls.RoundedButton btn전표반영;
        private Duzon.Common.BpControls.BpCodeTextBox bp_CD_ACCT;
        private Duzon.Common.Controls.RoundedButton btn이체내역관리;

    }
}
