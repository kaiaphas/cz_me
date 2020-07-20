namespace cz
{
    partial class P_CZ_ME_SALES
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(P_CZ_ME_SALES));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._flexM = new Dass.FlexGrid.FlexGrid(this.components);
            this.panel1 = new Duzon.Common.Controls.PanelExt();
            this.panelExt9 = new Duzon.Common.Controls.PanelExt();
            this.panelExt11 = new Duzon.Common.Controls.PanelExt();
            this.btn상세검색 = new Duzon.Common.Controls.RoundedButton(this.components);
            this.roundedButton1 = new Duzon.Common.Controls.RoundedButton(this.components);
            this.roundedButton2 = new Duzon.Common.Controls.RoundedButton(this.components);
            this.mDataArea.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._flexM)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelExt9.SuspendLayout();
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1090, 756);
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
            this._flexM.Location = new System.Drawing.Point(3, 10);
            this._flexM.Name = "_flexM";
            this._flexM.Rows.Count = 1;
            this._flexM.Rows.DefaultSize = 20;
            this._flexM.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this._flexM.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always;
            this._flexM.ShowSort = false;
            this._flexM.Size = new System.Drawing.Size(1084, 743);
            this._flexM.StyleInfo = resources.GetString("_flexM.StyleInfo");
            this._flexM.TabIndex = 17;
            this._flexM.UseGridCalculator = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panelExt9);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1084, 1);
            this.panel1.TabIndex = 1;
            // 
            // panelExt9
            // 
            this.panelExt9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelExt9.BackColor = System.Drawing.Color.Transparent;
            this.panelExt9.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelExt9.BackgroundImage")));
            this.panelExt9.Controls.Add(this.panelExt11);
            this.panelExt9.Font = new System.Drawing.Font("굴림", 9F);
            this.panelExt9.Location = new System.Drawing.Point(4, 29);
            this.panelExt9.Name = "panelExt9";
            this.panelExt9.Size = new System.Drawing.Size(1074, 1);
            this.panelExt9.TabIndex = 185;
            // 
            // panelExt11
            // 
            this.panelExt11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelExt11.BackColor = System.Drawing.Color.Transparent;
            this.panelExt11.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelExt11.BackgroundImage")));
            this.panelExt11.Font = new System.Drawing.Font("굴림", 9F);
            this.panelExt11.Location = new System.Drawing.Point(0, 24);
            this.panelExt11.Name = "panelExt11";
            this.panelExt11.Size = new System.Drawing.Size(1074, 1);
            this.panelExt11.TabIndex = 155;
            // 
            // btn상세검색
            // 
            this.btn상세검색.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn상세검색.BackColor = System.Drawing.Color.White;
            this.btn상세검색.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn상세검색.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn상세검색.Location = new System.Drawing.Point(1012, 14);
            this.btn상세검색.MaximumSize = new System.Drawing.Size(0, 19);
            this.btn상세검색.Name = "btn상세검색";
            this.btn상세검색.Size = new System.Drawing.Size(78, 19);
            this.btn상세검색.TabIndex = 4;
            this.btn상세검색.TabStop = false;
            this.btn상세검색.Text = "상세검색";
            this.btn상세검색.UseVisualStyleBackColor = false;
            this.btn상세검색.Click += new System.EventHandler(this.btn상세검색_Click_1);
            // 
            // roundedButton1
            // 
            this.roundedButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.roundedButton1.BackColor = System.Drawing.Color.White;
            this.roundedButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.roundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButton1.Location = new System.Drawing.Point(846, 14);
            this.roundedButton1.MaximumSize = new System.Drawing.Size(0, 19);
            this.roundedButton1.Name = "roundedButton1";
            this.roundedButton1.Size = new System.Drawing.Size(78, 19);
            this.roundedButton1.TabIndex = 5;
            this.roundedButton1.TabStop = false;
            this.roundedButton1.Text = "전표처리";
            this.roundedButton1.UseVisualStyleBackColor = false;
            // 
            // roundedButton2
            // 
            this.roundedButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.roundedButton2.BackColor = System.Drawing.Color.White;
            this.roundedButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.roundedButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButton2.Location = new System.Drawing.Point(929, 14);
            this.roundedButton2.MaximumSize = new System.Drawing.Size(0, 19);
            this.roundedButton2.Name = "roundedButton2";
            this.roundedButton2.Size = new System.Drawing.Size(78, 19);
            this.roundedButton2.TabIndex = 6;
            this.roundedButton2.TabStop = false;
            this.roundedButton2.Text = "전표취소";
            this.roundedButton2.UseVisualStyleBackColor = false;
            // 
            // P_CZ_ME_SALES
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.roundedButton2);
            this.Controls.Add(this.roundedButton1);
            this.Controls.Add(this.btn상세검색);
            this.Name = "P_CZ_ME_SALES";
            this.Size = new System.Drawing.Size(1090, 796);
            this.TitleText = "매출분석";
            this.OwerClosed += new System.EventHandler(this.P_CZ_ME_SALES_OwerClosed);
            this.Controls.SetChildIndex(this.btn상세검색, 0);
            this.Controls.SetChildIndex(this.mDataArea, 0);
            this.Controls.SetChildIndex(this.roundedButton1, 0);
            this.Controls.SetChildIndex(this.roundedButton2, 0);
            this.mDataArea.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._flexM)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panelExt9.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Duzon.Common.Controls.PanelExt panel1;
        private Duzon.Common.Controls.PanelExt panelExt9;
        private Duzon.Common.Controls.PanelExt panelExt11;
        private Dass.FlexGrid.FlexGrid _flexM;
        private Duzon.Common.Controls.RoundedButton btn상세검색;
        private Duzon.Common.Controls.RoundedButton roundedButton1;
        private Duzon.Common.Controls.RoundedButton roundedButton2;

    }
}
