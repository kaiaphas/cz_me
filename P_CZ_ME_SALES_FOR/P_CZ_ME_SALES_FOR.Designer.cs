namespace cz
{
    partial class P_CZ_ME_SALES_FOR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(P_CZ_ME_SALES_FOR));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._flexM = new Dass.FlexGrid.FlexGrid(this.components);
            this.panel1 = new Duzon.Common.Controls.PanelExt();
            this.cbo등록구분 = new Duzon.Common.Controls.DropDownComboBox();
            this.txt캠페인명 = new Duzon.Common.Controls.TextBoxExt();
            this.panelExt3 = new Duzon.Common.Controls.PanelExt();
            this.lbl캠페인명 = new Duzon.Common.Controls.LabelExt();
            this.dp년도 = new Duzon.Common.Controls.DatePicker();
            this.panel6 = new Duzon.Common.Controls.PanelExt();
            this.lbl기준년도 = new Duzon.Common.Controls.LabelExt();
            this.panelExt2 = new Duzon.Common.Controls.PanelExt();
            this.lbl등록구분 = new Duzon.Common.Controls.LabelExt();
            this.panRadio1 = new Duzon.Common.Controls.PanelExt();
            this.rdoMts4 = new Duzon.Common.Controls.RadioButtonExt();
            this.rdoMts3 = new Duzon.Common.Controls.RadioButtonExt();
            this.rdoMts2 = new Duzon.Common.Controls.RadioButtonExt();
            this.rdoMts1 = new Duzon.Common.Controls.RadioButtonExt();
            this.btn행복사 = new Duzon.Common.Controls.RoundedButton(this.components);
            this.btn복구처리 = new Duzon.Common.Controls.RoundedButton(this.components);
            this.mDataArea.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._flexM)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelExt3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dp년도)).BeginInit();
            this.panel6.SuspendLayout();
            this.panelExt2.SuspendLayout();
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
            this._flexM.KeyActionLeft = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut;
            this._flexM.KeyActionRight = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut;
            this._flexM.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
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
            this.panel1.Controls.Add(this.cbo등록구분);
            this.panel1.Controls.Add(this.txt캠페인명);
            this.panel1.Controls.Add(this.panelExt3);
            this.panel1.Controls.Add(this.dp년도);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panelExt2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1084, 30);
            this.panel1.TabIndex = 1;
            // 
            // cbo등록구분
            // 
            this.cbo등록구분.AutoDropDown = true;
            this.cbo등록구분.BackColor = System.Drawing.Color.White;
            this.cbo등록구분.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo등록구분.ItemHeight = 12;
            this.cbo등록구분.Location = new System.Drawing.Point(362, 4);
            this.cbo등록구분.Name = "cbo등록구분";
            this.cbo등록구분.Size = new System.Drawing.Size(136, 20);
            this.cbo등록구분.TabIndex = 1963;
            this.cbo등록구분.UseKeyF3 = false;
            this.cbo등록구분.SelectionChangeCommitted += new System.EventHandler(this.cbo등록구분_SelectionChangeCommitted);
            // 
            // txt캠페인명
            // 
            this.txt캠페인명.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(199)))), ((int)(((byte)(217)))));
            this.txt캠페인명.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt캠페인명.Location = new System.Drawing.Point(697, 4);
            this.txt캠페인명.Name = "txt캠페인명";
            this.txt캠페인명.Size = new System.Drawing.Size(127, 21);
            this.txt캠페인명.TabIndex = 1961;
            // 
            // panelExt3
            // 
            this.panelExt3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.panelExt3.Controls.Add(this.lbl캠페인명);
            this.panelExt3.Location = new System.Drawing.Point(573, -1);
            this.panelExt3.Name = "panelExt3";
            this.panelExt3.Size = new System.Drawing.Size(123, 31);
            this.panelExt3.TabIndex = 1962;
            // 
            // lbl캠페인명
            // 
            this.lbl캠페인명.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.lbl캠페인명.Location = new System.Drawing.Point(3, 6);
            this.lbl캠페인명.Name = "lbl캠페인명";
            this.lbl캠페인명.Size = new System.Drawing.Size(117, 18);
            this.lbl캠페인명.TabIndex = 41;
            this.lbl캠페인명.Text = "캠페인명";
            this.lbl캠페인명.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dp년도
            // 
            this.dp년도.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dp년도.Location = new System.Drawing.Point(94, 4);
            this.dp년도.Mask = "####";
            this.dp년도.MaxDate = new System.DateTime(9999, 12, 31, 23, 59, 59, 999);
            this.dp년도.MaximumSize = new System.Drawing.Size(0, 21);
            this.dp년도.MinDate = new System.DateTime(1800, 1, 1, 0, 0, 0, 0);
            this.dp년도.Name = "dp년도";
            this.dp년도.NullCheck = true;
            this.dp년도.ShowUpDown = true;
            this.dp년도.Size = new System.Drawing.Size(86, 21);
            this.dp년도.TabIndex = 1960;
            this.dp년도.Tag = "";
            this.dp년도.Value = new System.DateTime(((long)(0)));
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.panel6.Controls.Add(this.lbl기준년도);
            this.panel6.Location = new System.Drawing.Point(-1, -1);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(91, 29);
            this.panel6.TabIndex = 1959;
            // 
            // lbl기준년도
            // 
            this.lbl기준년도.BackColor = System.Drawing.Color.Transparent;
            this.lbl기준년도.Location = new System.Drawing.Point(27, 6);
            this.lbl기준년도.Name = "lbl기준년도";
            this.lbl기준년도.Size = new System.Drawing.Size(60, 18);
            this.lbl기준년도.TabIndex = 41;
            this.lbl기준년도.Text = "기준년도";
            this.lbl기준년도.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelExt2
            // 
            this.panelExt2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.panelExt2.Controls.Add(this.lbl등록구분);
            this.panelExt2.Location = new System.Drawing.Point(237, -1);
            this.panelExt2.Name = "panelExt2";
            this.panelExt2.Size = new System.Drawing.Size(123, 31);
            this.panelExt2.TabIndex = 1958;
            // 
            // lbl등록구분
            // 
            this.lbl등록구분.BackColor = System.Drawing.Color.Transparent;
            this.lbl등록구분.Location = new System.Drawing.Point(60, 6);
            this.lbl등록구분.Name = "lbl등록구분";
            this.lbl등록구분.Size = new System.Drawing.Size(60, 18);
            this.lbl등록구분.TabIndex = 55;
            this.lbl등록구분.Text = "등록구분";
            this.lbl등록구분.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // btn행복사
            // 
            this.btn행복사.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn행복사.BackColor = System.Drawing.Color.White;
            this.btn행복사.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn행복사.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn행복사.Location = new System.Drawing.Point(1009, 10);
            this.btn행복사.MaximumSize = new System.Drawing.Size(0, 19);
            this.btn행복사.Name = "btn행복사";
            this.btn행복사.Size = new System.Drawing.Size(78, 19);
            this.btn행복사.TabIndex = 4;
            this.btn행복사.TabStop = false;
            this.btn행복사.Text = "행복사";
            this.btn행복사.UseVisualStyleBackColor = false;
            this.btn행복사.Click += new System.EventHandler(this.btn행복사_Click);
            // 
            // btn복구처리
            // 
            this.btn복구처리.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn복구처리.BackColor = System.Drawing.Color.White;
            this.btn복구처리.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn복구처리.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn복구처리.Location = new System.Drawing.Point(930, 10);
            this.btn복구처리.MaximumSize = new System.Drawing.Size(0, 19);
            this.btn복구처리.Name = "btn복구처리";
            this.btn복구처리.Size = new System.Drawing.Size(78, 19);
            this.btn복구처리.TabIndex = 13;
            this.btn복구처리.TabStop = false;
            this.btn복구처리.Text = "복구처리";
            this.btn복구처리.UseVisualStyleBackColor = false;
            // 
            // P_CZ_ME_SALES_FOR
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.btn복구처리);
            this.Controls.Add(this.btn행복사);
            this.Controls.Add(this.panRadio1);
            this.Name = "P_CZ_ME_SALES_FOR";
            this.Size = new System.Drawing.Size(1090, 796);
            this.TitleText = "CUT-OFF및이월자료등록";
            this.Controls.SetChildIndex(this.panRadio1, 0);
            this.Controls.SetChildIndex(this.mDataArea, 0);
            this.Controls.SetChildIndex(this.btn행복사, 0);
            this.Controls.SetChildIndex(this.btn복구처리, 0);
            this.mDataArea.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._flexM)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelExt3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dp년도)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panelExt2.ResumeLayout(false);
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
        private Duzon.Common.Controls.PanelExt panRadio1;
        private Duzon.Common.Controls.RadioButtonExt rdoMts4;
        private Duzon.Common.Controls.RadioButtonExt rdoMts3;
        private Duzon.Common.Controls.RadioButtonExt rdoMts2;
        private Duzon.Common.Controls.RadioButtonExt rdoMts1;
        private Dass.FlexGrid.FlexGrid _flexM;
        private Duzon.Common.Controls.PanelExt panelExt2;
        private Duzon.Common.Controls.LabelExt lbl등록구분;
        private Duzon.Common.Controls.DatePicker dp년도;
        private Duzon.Common.Controls.PanelExt panel6;
        private Duzon.Common.Controls.LabelExt lbl기준년도;
        private Duzon.Common.Controls.TextBoxExt txt캠페인명;
        private Duzon.Common.Controls.PanelExt panelExt3;
        private Duzon.Common.Controls.LabelExt lbl캠페인명;
        private Duzon.Common.Controls.RoundedButton btn행복사;
        private Duzon.Common.Controls.DropDownComboBox cbo등록구분;
        private Duzon.Common.Controls.RoundedButton btn복구처리;

    }
}
