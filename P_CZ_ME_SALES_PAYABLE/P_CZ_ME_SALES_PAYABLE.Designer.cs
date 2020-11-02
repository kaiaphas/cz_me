namespace cz
{
    partial class P_CZ_ME_SALES_PAYABLE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(P_CZ_ME_SALES_PAYABLE));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._flexM = new Dass.FlexGrid.FlexGrid(this.components);
            this.panel1 = new Duzon.Common.Controls.PanelExt();
            this.MULTI_CD_CORP = new Duzon.Common.BpControls.BpComboBox();
            this.cbo사용여부 = new Duzon.Common.Controls.DropDownComboBox();
            this.panelExt26 = new Duzon.Common.Controls.PanelExt();
            this.labelExt21 = new Duzon.Common.Controls.LabelExt();
            this.panelExt23 = new Duzon.Common.Controls.PanelExt();
            this.panelExt24 = new Duzon.Common.Controls.PanelExt();
            this.panelExt9 = new Duzon.Common.Controls.PanelExt();
            this.labelExt6 = new Duzon.Common.Controls.LabelExt();
            this.mDataArea.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._flexM)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.panel1.Controls.Add(this.MULTI_CD_CORP);
            this.panel1.Controls.Add(this.cbo사용여부);
            this.panel1.Controls.Add(this.panelExt26);
            this.panel1.Controls.Add(this.panelExt23);
            this.panel1.Controls.Add(this.panelExt9);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1340, 32);
            this.panel1.TabIndex = 20;
            // 
            // MULTI_CD_CORP
            // 
            this.MULTI_CD_CORP.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MULTI_CD_CORP.HelpID = Duzon.Common.Forms.Help.HelpID.P_USER;
            this.MULTI_CD_CORP.Location = new System.Drawing.Point(71, 5);
            this.MULTI_CD_CORP.Name = "MULTI_CD_CORP";
            this.MULTI_CD_CORP.Size = new System.Drawing.Size(150, 21);
            this.MULTI_CD_CORP.TabIndex = 1973;
            this.MULTI_CD_CORP.TabStop = false;
            this.MULTI_CD_CORP.UserCodeName = "biz_name";
            this.MULTI_CD_CORP.UserCodeValue = "CD_PARTNER";
            this.MULTI_CD_CORP.UserHelpID = "H_CZ_HELP02";
            this.MULTI_CD_CORP.QueryBefore += new Duzon.Common.BpControls.BpQueryHandler(this.MULTI_CD_CORP_QueryBefore);
            // 
            // cbo사용여부
            // 
            this.cbo사용여부.AutoDropDown = true;
            this.cbo사용여부.BackColor = System.Drawing.Color.White;
            this.cbo사용여부.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo사용여부.ItemHeight = 15;
            this.cbo사용여부.Location = new System.Drawing.Point(534, 4);
            this.cbo사용여부.Name = "cbo사용여부";
            this.cbo사용여부.Size = new System.Drawing.Size(120, 23);
            this.cbo사용여부.TabIndex = 296;
            this.cbo사용여부.UseKeyF3 = false;
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
            this.labelExt21.Text = "사용여부";
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
            // panelExt9
            // 
            this.panelExt9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.panelExt9.Controls.Add(this.labelExt6);
            this.panelExt9.Location = new System.Drawing.Point(0, 1);
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
            // P_CZ_ME_SALES_PAYABLE
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Name = "P_CZ_ME_SALES_PAYABLE";
            this.Size = new System.Drawing.Size(1346, 796);
            this.TitleText = "지급계좌 관리";
            this.mDataArea.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._flexM)).EndInit();
            this.panel1.ResumeLayout(false);
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
        private Duzon.Common.Controls.LabelExt labelExt21;
        private Duzon.Common.Controls.PanelExt panelExt24;
        private Duzon.Common.Controls.DropDownComboBox cbo사용여부;
        private Duzon.Common.BpControls.BpComboBox MULTI_CD_CORP;

    }
}
