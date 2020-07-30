namespace cz
{
    partial class P_CZ_ME_SALES_IO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(P_CZ_ME_SALES_IO));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new Duzon.Common.Controls.PanelExt();
            this.cbo계산서발행상태 = new Duzon.Common.Controls.DropDownComboBox();
            this.cbo선택자료상태값변경 = new Duzon.Common.Controls.DropDownComboBox();
            this.cboIO상태값 = new Duzon.Common.Controls.DropDownComboBox();
            this.panelExt2 = new Duzon.Common.Controls.PanelExt();
            this.lbl선택자료상태값변경 = new Duzon.Common.Controls.LabelExt();
            this.dt일자 = new Duzon.Common.Controls.PeriodPicker();
            this.panelExt1 = new Duzon.Common.Controls.PanelExt();
            this.lbl계산서발행상태 = new Duzon.Common.Controls.LabelExt();
            this.panelExt3 = new Duzon.Common.Controls.PanelExt();
            this.lblIO상태값 = new Duzon.Common.Controls.LabelExt();
            this.panel6 = new Duzon.Common.Controls.PanelExt();
            this.lbl조회일 = new Duzon.Common.Controls.LabelExt();
            this._flexM = new Dass.FlexGrid.FlexGrid(this.components);
            this.panRadio1 = new Duzon.Common.Controls.PanelExt();
            this.rdoMts4 = new Duzon.Common.Controls.RadioButtonExt();
            this.rdoMts3 = new Duzon.Common.Controls.RadioButtonExt();
            this.rdoMts2 = new Duzon.Common.Controls.RadioButtonExt();
            this.rdoMts1 = new Duzon.Common.Controls.RadioButtonExt();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelExt3 = new Duzon.Common.Controls.LabelExt();
            this._flexD = new Dass.FlexGrid.FlexGrid(this.components);
            this.mDataArea.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelExt2.SuspendLayout();
            this.panelExt1.SuspendLayout();
            this.panelExt3.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._flexM)).BeginInit();
            this.panRadio1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdoMts4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoMts3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoMts2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoMts1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._flexD)).BeginInit();
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
            this.tableLayoutPanel1.Controls.Add(this._flexD, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this._flexM, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 257F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1090, 756);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cbo계산서발행상태);
            this.panel1.Controls.Add(this.cbo선택자료상태값변경);
            this.panel1.Controls.Add(this.cboIO상태값);
            this.panel1.Controls.Add(this.panelExt2);
            this.panel1.Controls.Add(this.dt일자);
            this.panel1.Controls.Add(this.panelExt1);
            this.panel1.Controls.Add(this.panelExt3);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1084, 62);
            this.panel1.TabIndex = 1;
            // 
            // cbo계산서발행상태
            // 
            this.cbo계산서발행상태.AutoDropDown = true;
            this.cbo계산서발행상태.BackColor = System.Drawing.Color.White;
            this.cbo계산서발행상태.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo계산서발행상태.ItemHeight = 15;
            this.cbo계산서발행상태.Location = new System.Drawing.Point(533, 5);
            this.cbo계산서발행상태.Name = "cbo계산서발행상태";
            this.cbo계산서발행상태.Size = new System.Drawing.Size(107, 23);
            this.cbo계산서발행상태.TabIndex = 1969;
            this.cbo계산서발행상태.UseKeyF3 = false;
            // 
            // cbo선택자료상태값변경
            // 
            this.cbo선택자료상태값변경.AutoDropDown = true;
            this.cbo선택자료상태값변경.BackColor = System.Drawing.Color.White;
            this.cbo선택자료상태값변경.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo선택자료상태값변경.ItemHeight = 15;
            this.cbo선택자료상태값변경.Location = new System.Drawing.Point(162, 35);
            this.cbo선택자료상태값변경.Name = "cbo선택자료상태값변경";
            this.cbo선택자료상태값변경.Size = new System.Drawing.Size(107, 23);
            this.cbo선택자료상태값변경.TabIndex = 1968;
            this.cbo선택자료상태값변경.UseKeyF3 = false;
            // 
            // cboIO상태값
            // 
            this.cboIO상태값.AutoDropDown = true;
            this.cboIO상태값.BackColor = System.Drawing.Color.White;
            this.cboIO상태값.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIO상태값.ItemHeight = 15;
            this.cboIO상태값.Location = new System.Drawing.Point(162, 6);
            this.cboIO상태값.Name = "cboIO상태값";
            this.cboIO상태값.Size = new System.Drawing.Size(107, 23);
            this.cboIO상태값.TabIndex = 1967;
            this.cboIO상태값.UseKeyF3 = false;
            // 
            // panelExt2
            // 
            this.panelExt2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.panelExt2.Controls.Add(this.lbl선택자료상태값변경);
            this.panelExt2.Location = new System.Drawing.Point(0, 32);
            this.panelExt2.Name = "panelExt2";
            this.panelExt2.Size = new System.Drawing.Size(160, 31);
            this.panelExt2.TabIndex = 1966;
            // 
            // lbl선택자료상태값변경
            // 
            this.lbl선택자료상태값변경.BackColor = System.Drawing.Color.Transparent;
            this.lbl선택자료상태값변경.Location = new System.Drawing.Point(-2, 5);
            this.lbl선택자료상태값변경.Name = "lbl선택자료상태값변경";
            this.lbl선택자료상태값변경.Size = new System.Drawing.Size(159, 18);
            this.lbl선택자료상태값변경.TabIndex = 41;
            this.lbl선택자료상태값변경.Text = "선택자료 상태값 변경";
            this.lbl선택자료상태값변경.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dt일자
            // 
            this.dt일자.CalendarPeriodType = Duzon.Common.Controls.PeriodType.YearMonth;
            this.dt일자.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dt일자.Location = new System.Drawing.Point(892, 4);
            this.dt일자.Mask = "####/##";
            this.dt일자.MaximumSize = new System.Drawing.Size(185, 21);
            this.dt일자.MinimumSize = new System.Drawing.Size(185, 21);
            this.dt일자.Name = "dt일자";
            this.dt일자.Size = new System.Drawing.Size(185, 21);
            this.dt일자.TabIndex = 99;
            // 
            // panelExt1
            // 
            this.panelExt1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.panelExt1.Controls.Add(this.lbl계산서발행상태);
            this.panelExt1.Location = new System.Drawing.Point(371, -1);
            this.panelExt1.Name = "panelExt1";
            this.panelExt1.Size = new System.Drawing.Size(160, 31);
            this.panelExt1.TabIndex = 1964;
            // 
            // lbl계산서발행상태
            // 
            this.lbl계산서발행상태.BackColor = System.Drawing.Color.Transparent;
            this.lbl계산서발행상태.Location = new System.Drawing.Point(23, 7);
            this.lbl계산서발행상태.Name = "lbl계산서발행상태";
            this.lbl계산서발행상태.Size = new System.Drawing.Size(134, 18);
            this.lbl계산서발행상태.TabIndex = 41;
            this.lbl계산서발행상태.Text = "계산서발행 상태";
            this.lbl계산서발행상태.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelExt3
            // 
            this.panelExt3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.panelExt3.Controls.Add(this.lblIO상태값);
            this.panelExt3.Location = new System.Drawing.Point(0, 1);
            this.panelExt3.Name = "panelExt3";
            this.panelExt3.Size = new System.Drawing.Size(160, 31);
            this.panelExt3.TabIndex = 1962;
            // 
            // lblIO상태값
            // 
            this.lblIO상태값.BackColor = System.Drawing.Color.Transparent;
            this.lblIO상태값.Location = new System.Drawing.Point(64, 6);
            this.lblIO상태값.Name = "lblIO상태값";
            this.lblIO상태값.Size = new System.Drawing.Size(93, 18);
            this.lblIO상태값.TabIndex = 41;
            this.lblIO상태값.Text = "IO 상태값";
            this.lblIO상태값.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.panel6.Controls.Add(this.lbl조회일);
            this.panel6.Location = new System.Drawing.Point(730, 1);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(160, 29);
            this.panel6.TabIndex = 1959;
            // 
            // lbl조회일
            // 
            this.lbl조회일.BackColor = System.Drawing.Color.Transparent;
            this.lbl조회일.Location = new System.Drawing.Point(93, 5);
            this.lbl조회일.Name = "lbl조회일";
            this.lbl조회일.Size = new System.Drawing.Size(64, 18);
            this.lbl조회일.TabIndex = 41;
            this.lbl조회일.Text = "조회 일";
            this.lbl조회일.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this._flexM.Location = new System.Drawing.Point(3, 71);
            this._flexM.Name = "_flexM";
            this._flexM.Rows.Count = 1;
            this._flexM.Rows.DefaultSize = 18;
            this._flexM.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this._flexM.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always;
            this._flexM.ShowSort = false;
            this._flexM.Size = new System.Drawing.Size(1084, 397);
            this._flexM.StyleInfo = resources.GetString("_flexM.StyleInfo");
            this._flexM.TabIndex = 156;
            this._flexM.UseGridCalculator = true;
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
            // panel2
            // 
            this.panel2.Controls.Add(this.labelExt3);
            this.panel2.Location = new System.Drawing.Point(3, 474);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1084, 22);
            this.panel2.TabIndex = 169;
            // 
            // labelExt3
            // 
            this.labelExt3.BackColor = System.Drawing.Color.Transparent;
            this.labelExt3.Font = new System.Drawing.Font("굴림", 9F);
            this.labelExt3.Location = new System.Drawing.Point(2, 2);
            this.labelExt3.Name = "labelExt3";
            this.labelExt3.Size = new System.Drawing.Size(223, 18);
            this.labelExt3.TabIndex = 47;
            this.labelExt3.Text = "▶ 전표정보";
            this.labelExt3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _flexD
            // 
            this._flexD.AllowFreezing = C1.Win.C1FlexGrid.AllowFreezingEnum.Both;
            this._flexD.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Both;
            this._flexD.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.MultiColumn;
            this._flexD.AutoResize = false;
            this._flexD.ColumnInfo = "1,1,0,0,0,90,Columns:0{TextAlign:CenterCenter;TextAlignFixed:CenterCenter;}\t";
            this._flexD.Dock = System.Windows.Forms.DockStyle.Fill;
            this._flexD.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw;
            this._flexD.EnabledHeaderCheck = true;
            this._flexD.Font = new System.Drawing.Font("굴림", 9F);
            this._flexD.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this._flexD.KeyActionLeft = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut;
            this._flexD.KeyActionRight = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut;
            this._flexD.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this._flexD.Location = new System.Drawing.Point(3, 502);
            this._flexD.Name = "_flexD";
            this._flexD.Rows.Count = 1;
            this._flexD.Rows.DefaultSize = 18;
            this._flexD.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this._flexD.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always;
            this._flexD.ShowSort = false;
            this._flexD.Size = new System.Drawing.Size(1084, 251);
            this._flexD.StyleInfo = resources.GetString("_flexD.StyleInfo");
            this._flexD.TabIndex = 170;
            this._flexD.UseGridCalculator = true;
            // 
            // P_CZ_ME_SALES_IO
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.panRadio1);
            this.Name = "P_CZ_ME_SALES_IO";
            this.Size = new System.Drawing.Size(1090, 796);
            this.TitleText = "퍼블리셔정산";
            this.Controls.SetChildIndex(this.panRadio1, 0);
            this.Controls.SetChildIndex(this.mDataArea, 0);
            this.mDataArea.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelExt2.ResumeLayout(false);
            this.panelExt1.ResumeLayout(false);
            this.panelExt3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._flexM)).EndInit();
            this.panRadio1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rdoMts4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoMts3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoMts2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoMts1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._flexD)).EndInit();
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
        private Duzon.Common.Controls.LabelExt lbl조회일;
        private Duzon.Common.Controls.PanelExt panelExt3;
        private Duzon.Common.Controls.LabelExt lblIO상태값;
        private Duzon.Common.Controls.PeriodPicker dt일자;
        private Duzon.Common.Controls.PanelExt panelExt1;
        private Duzon.Common.Controls.LabelExt lbl계산서발행상태;
        private Duzon.Common.Controls.PanelExt panelExt2;
        private Duzon.Common.Controls.LabelExt lbl선택자료상태값변경;
        private Duzon.Common.Controls.DropDownComboBox cbo계산서발행상태;
        private Duzon.Common.Controls.DropDownComboBox cbo선택자료상태값변경;
        private Duzon.Common.Controls.DropDownComboBox cboIO상태값;
        private Dass.FlexGrid.FlexGrid _flexD;
        private System.Windows.Forms.Panel panel2;
        private Duzon.Common.Controls.LabelExt labelExt3;

    }
}
