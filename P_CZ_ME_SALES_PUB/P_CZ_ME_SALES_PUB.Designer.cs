namespace cz
{
    partial class P_CZ_ME_SALES_PUB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(P_CZ_ME_SALES_PUB));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._flexM = new Dass.FlexGrid.FlexGrid(this.components);
            this.panel1 = new Duzon.Common.Controls.PanelExt();
            this.panelExt2 = new Duzon.Common.Controls.PanelExt();
            this.lbl구분 = new Duzon.Common.Controls.LabelExt();
            this.dt일자 = new Duzon.Common.Controls.PeriodPicker();
            this.txt명 = new Duzon.Common.Controls.TextBoxExt();
            this.panelExt3 = new Duzon.Common.Controls.PanelExt();
            this.lbl명 = new Duzon.Common.Controls.LabelExt();
            this.panel6 = new Duzon.Common.Controls.PanelExt();
            this.lbl발행월 = new Duzon.Common.Controls.LabelExt();
            this.panRadio1 = new Duzon.Common.Controls.PanelExt();
            this.rdoMts4 = new Duzon.Common.Controls.RadioButtonExt();
            this.rdoMts3 = new Duzon.Common.Controls.RadioButtonExt();
            this.rdoMts2 = new Duzon.Common.Controls.RadioButtonExt();
            this.rdoMts1 = new Duzon.Common.Controls.RadioButtonExt();
            this.btn전표처리 = new Duzon.Common.Controls.RoundedButton(this.components);
            this.btn전표삭제 = new Duzon.Common.Controls.RoundedButton(this.components);
            this.cbo상태구분 = new Duzon.Common.Controls.DropDownComboBox();
            this.cbo기준 = new Duzon.Common.Controls.DropDownComboBox();
            this.panelExt1 = new Duzon.Common.Controls.PanelExt();
            this.labelExt1 = new Duzon.Common.Controls.LabelExt();
            this.mDataArea.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._flexM)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelExt2.SuspendLayout();
            this.panelExt3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panRadio1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdoMts4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoMts3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoMts2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoMts1)).BeginInit();
            this.panelExt1.SuspendLayout();
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
            this.panel1.Controls.Add(this.cbo기준);
            this.panel1.Controls.Add(this.panelExt1);
            this.panel1.Controls.Add(this.cbo상태구분);
            this.panel1.Controls.Add(this.panelExt2);
            this.panel1.Controls.Add(this.dt일자);
            this.panel1.Controls.Add(this.txt명);
            this.panel1.Controls.Add(this.panelExt3);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1084, 30);
            this.panel1.TabIndex = 1;
            // 
            // panelExt2
            // 
            this.panelExt2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.panelExt2.Controls.Add(this.lbl구분);
            this.panelExt2.Location = new System.Drawing.Point(487, -1);
            this.panelExt2.Name = "panelExt2";
            this.panelExt2.Size = new System.Drawing.Size(91, 31);
            this.panelExt2.TabIndex = 1964;
            // 
            // lbl구분
            // 
            this.lbl구분.BackColor = System.Drawing.Color.Transparent;
            this.lbl구분.Location = new System.Drawing.Point(28, 6);
            this.lbl구분.Name = "lbl구분";
            this.lbl구분.Size = new System.Drawing.Size(60, 18);
            this.lbl구분.TabIndex = 55;
            this.lbl구분.Text = "처리구분";
            this.lbl구분.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dt일자
            // 
            this.dt일자.CalendarPeriodType = Duzon.Common.Controls.PeriodType.YearMonth;
            this.dt일자.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dt일자.Location = new System.Drawing.Point(92, 3);
            this.dt일자.Mask = "####/##";
            this.dt일자.MaximumSize = new System.Drawing.Size(185, 21);
            this.dt일자.MinimumSize = new System.Drawing.Size(185, 21);
            this.dt일자.Name = "dt일자";
            this.dt일자.Size = new System.Drawing.Size(185, 21);
            this.dt일자.TabIndex = 99;
            // 
            // txt명
            // 
            this.txt명.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(199)))), ((int)(((byte)(217)))));
            this.txt명.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt명.Location = new System.Drawing.Point(375, 4);
            this.txt명.Name = "txt명";
            this.txt명.Size = new System.Drawing.Size(107, 25);
            this.txt명.TabIndex = 1961;
            // 
            // panelExt3
            // 
            this.panelExt3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.panelExt3.Controls.Add(this.lbl명);
            this.panelExt3.Location = new System.Drawing.Point(282, -1);
            this.panelExt3.Name = "panelExt3";
            this.panelExt3.Size = new System.Drawing.Size(91, 31);
            this.panelExt3.TabIndex = 1962;
            // 
            // lbl명
            // 
            this.lbl명.BackColor = System.Drawing.Color.Transparent;
            this.lbl명.Location = new System.Drawing.Point(3, 6);
            this.lbl명.Name = "lbl명";
            this.lbl명.Size = new System.Drawing.Size(85, 18);
            this.lbl명.TabIndex = 41;
            this.lbl명.Text = "사업자명/번호";
            this.lbl명.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.panel6.Controls.Add(this.lbl발행월);
            this.panel6.Location = new System.Drawing.Point(-1, -1);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(91, 29);
            this.panel6.TabIndex = 1959;
            // 
            // lbl발행월
            // 
            this.lbl발행월.BackColor = System.Drawing.Color.Transparent;
            this.lbl발행월.Location = new System.Drawing.Point(27, 6);
            this.lbl발행월.Name = "lbl발행월";
            this.lbl발행월.Size = new System.Drawing.Size(60, 18);
            this.lbl발행월.TabIndex = 41;
            this.lbl발행월.Text = "발행월";
            this.lbl발행월.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // btn전표처리
            // 
            this.btn전표처리.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn전표처리.BackColor = System.Drawing.Color.White;
            this.btn전표처리.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn전표처리.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn전표처리.Location = new System.Drawing.Point(933, 10);
            this.btn전표처리.MaximumSize = new System.Drawing.Size(0, 19);
            this.btn전표처리.Name = "btn전표처리";
            this.btn전표처리.Size = new System.Drawing.Size(78, 19);
            this.btn전표처리.TabIndex = 4;
            this.btn전표처리.TabStop = false;
            this.btn전표처리.Text = "전표처리";
            this.btn전표처리.UseVisualStyleBackColor = false;
            // 
            // btn전표삭제
            // 
            this.btn전표삭제.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn전표삭제.BackColor = System.Drawing.Color.White;
            this.btn전표삭제.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn전표삭제.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn전표삭제.Location = new System.Drawing.Point(1012, 10);
            this.btn전표삭제.MaximumSize = new System.Drawing.Size(0, 19);
            this.btn전표삭제.Name = "btn전표삭제";
            this.btn전표삭제.Size = new System.Drawing.Size(78, 19);
            this.btn전표삭제.TabIndex = 5;
            this.btn전표삭제.TabStop = false;
            this.btn전표삭제.Text = "전표삭제";
            this.btn전표삭제.UseVisualStyleBackColor = false;
            // 
            // cbo상태구분
            // 
            this.cbo상태구분.AutoDropDown = true;
            this.cbo상태구분.BackColor = System.Drawing.Color.White;
            this.cbo상태구분.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo상태구분.ItemHeight = 15;
            this.cbo상태구분.Location = new System.Drawing.Point(580, 4);
            this.cbo상태구분.Name = "cbo상태구분";
            this.cbo상태구분.Size = new System.Drawing.Size(80, 23);
            this.cbo상태구분.TabIndex = 1972;
            this.cbo상태구분.UseKeyF3 = false;
            // 
            // cbo기준
            // 
            this.cbo기준.AutoDropDown = true;
            this.cbo기준.BackColor = System.Drawing.Color.White;
            this.cbo기준.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo기준.ItemHeight = 15;
            this.cbo기준.Location = new System.Drawing.Point(760, 4);
            this.cbo기준.Name = "cbo기준";
            this.cbo기준.Size = new System.Drawing.Size(80, 23);
            this.cbo기준.TabIndex = 1974;
            this.cbo기준.UseKeyF3 = false;
            // 
            // panelExt1
            // 
            this.panelExt1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.panelExt1.Controls.Add(this.labelExt1);
            this.panelExt1.Location = new System.Drawing.Point(667, -1);
            this.panelExt1.Name = "panelExt1";
            this.panelExt1.Size = new System.Drawing.Size(91, 31);
            this.panelExt1.TabIndex = 1973;
            // 
            // labelExt1
            // 
            this.labelExt1.BackColor = System.Drawing.Color.Transparent;
            this.labelExt1.Location = new System.Drawing.Point(28, 6);
            this.labelExt1.Name = "labelExt1";
            this.labelExt1.Size = new System.Drawing.Size(60, 18);
            this.labelExt1.TabIndex = 55;
            this.labelExt1.Text = "기준";
            this.labelExt1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // P_CZ_ME_SALES_PUB
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.btn전표삭제);
            this.Controls.Add(this.btn전표처리);
            this.Controls.Add(this.panRadio1);
            this.Name = "P_CZ_ME_SALES_PUB";
            this.Size = new System.Drawing.Size(1090, 796);
            this.TitleText = "퍼블리셔정산";
            this.Controls.SetChildIndex(this.panRadio1, 0);
            this.Controls.SetChildIndex(this.btn전표처리, 0);
            this.Controls.SetChildIndex(this.btn전표삭제, 0);
            this.Controls.SetChildIndex(this.mDataArea, 0);
            this.mDataArea.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._flexM)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelExt2.ResumeLayout(false);
            this.panelExt3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panRadio1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rdoMts4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoMts3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoMts2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoMts1)).EndInit();
            this.panelExt1.ResumeLayout(false);
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
        private Duzon.Common.Controls.PanelExt panel6;
        private Duzon.Common.Controls.LabelExt lbl발행월;
        private Duzon.Common.Controls.TextBoxExt txt명;
        private Duzon.Common.Controls.PanelExt panelExt3;
        private Duzon.Common.Controls.LabelExt lbl명;
        private Duzon.Common.Controls.PeriodPicker dt일자;
        private Duzon.Common.Controls.RoundedButton btn전표처리;
        private Duzon.Common.Controls.RoundedButton btn전표삭제;
        private Duzon.Common.Controls.PanelExt panelExt2;
        private Duzon.Common.Controls.LabelExt lbl구분;
        private Duzon.Common.Controls.DropDownComboBox cbo상태구분;
        private Duzon.Common.Controls.DropDownComboBox cbo기준;
        private Duzon.Common.Controls.PanelExt panelExt1;
        private Duzon.Common.Controls.LabelExt labelExt1;

    }
}
