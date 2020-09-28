namespace cz
{
    partial class P_CZ_ME_SALES_CONS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(P_CZ_ME_SALES_CONS));
            this.panRadio1 = new Duzon.Common.Controls.PanelExt();
            this.rdoMts4 = new Duzon.Common.Controls.RadioButtonExt();
            this.rdoMts3 = new Duzon.Common.Controls.RadioButtonExt();
            this.rdoMts2 = new Duzon.Common.Controls.RadioButtonExt();
            this.rdoMts1 = new Duzon.Common.Controls.RadioButtonExt();
            this.btn엑셀업로드 = new Duzon.Common.Controls.RoundedButton(this.components);
            this.btn거래처변경 = new Duzon.Common.Controls.RoundedButton(this.components);
            this.panel1 = new Duzon.Common.Controls.PanelExt();
            this.panelExt1 = new Duzon.Common.Controls.PanelExt();
            this.labelExt1 = new Duzon.Common.Controls.LabelExt();
            this.panelExt19 = new Duzon.Common.Controls.PanelExt();
            this.labelExt15 = new Duzon.Common.Controls.LabelExt();
            this.txt명 = new Duzon.Common.Controls.TextBoxExt();
            this.panelExt23 = new Duzon.Common.Controls.PanelExt();
            this.panelExt24 = new Duzon.Common.Controls.PanelExt();
            this.dp년월 = new Duzon.Common.Controls.DatePicker();
            this.lbl엑셀업로드일시 = new Duzon.Common.Controls.LabelExt();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._flexT = new Dass.FlexGrid.FlexGrid(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelExt2 = new Duzon.Common.Controls.LabelExt();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelExt3 = new Duzon.Common.Controls.LabelExt();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._flexM = new Dass.FlexGrid.FlexGrid(this.components);
            this._flexD = new Dass.FlexGrid.FlexGrid(this.components);
            this.mDataArea.SuspendLayout();
            this.panRadio1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdoMts4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoMts3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoMts2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoMts1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelExt1.SuspendLayout();
            this.panelExt19.SuspendLayout();
            this.panelExt23.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dp년월)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._flexT)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._flexM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._flexD)).BeginInit();
            this.SuspendLayout();
            // 
            // mDataArea
            // 
            this.mDataArea.Controls.Add(this.tableLayoutPanel1);
            this.mDataArea.Size = new System.Drawing.Size(1090, 756);
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
            // btn엑셀업로드
            // 
            this.btn엑셀업로드.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn엑셀업로드.BackColor = System.Drawing.Color.White;
            this.btn엑셀업로드.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn엑셀업로드.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn엑셀업로드.Location = new System.Drawing.Point(922, 10);
            this.btn엑셀업로드.MaximumSize = new System.Drawing.Size(0, 19);
            this.btn엑셀업로드.Name = "btn엑셀업로드";
            this.btn엑셀업로드.Size = new System.Drawing.Size(80, 19);
            this.btn엑셀업로드.TabIndex = 8;
            this.btn엑셀업로드.TabStop = false;
            this.btn엑셀업로드.Text = "엑셀업로드";
            this.btn엑셀업로드.UseVisualStyleBackColor = false;
            // 
            // btn거래처변경
            // 
            this.btn거래처변경.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn거래처변경.BackColor = System.Drawing.Color.White;
            this.btn거래처변경.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn거래처변경.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn거래처변경.Location = new System.Drawing.Point(1008, 10);
            this.btn거래처변경.MaximumSize = new System.Drawing.Size(0, 19);
            this.btn거래처변경.Name = "btn거래처변경";
            this.btn거래처변경.Size = new System.Drawing.Size(80, 19);
            this.btn거래처변경.TabIndex = 9;
            this.btn거래처변경.TabStop = false;
            this.btn거래처변경.Text = "거래처변경";
            this.btn거래처변경.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panelExt1);
            this.panel1.Controls.Add(this.panelExt19);
            this.panel1.Controls.Add(this.lbl엑셀업로드일시);
            this.panel1.Controls.Add(this.txt명);
            this.panel1.Controls.Add(this.panelExt23);
            this.panel1.Controls.Add(this.dp년월);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1084, 32);
            this.panel1.TabIndex = 2;
            // 
            // panelExt1
            // 
            this.panelExt1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.panelExt1.Controls.Add(this.labelExt1);
            this.panelExt1.Location = new System.Drawing.Point(229, 2);
            this.panelExt1.Name = "panelExt1";
            this.panelExt1.Size = new System.Drawing.Size(70, 27);
            this.panelExt1.TabIndex = 1977;
            // 
            // labelExt1
            // 
            this.labelExt1.BackColor = System.Drawing.Color.Transparent;
            this.labelExt1.Location = new System.Drawing.Point(4, 4);
            this.labelExt1.Name = "labelExt1";
            this.labelExt1.Size = new System.Drawing.Size(60, 18);
            this.labelExt1.TabIndex = 55;
            this.labelExt1.Text = "검색";
            this.labelExt1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelExt19
            // 
            this.panelExt19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.panelExt19.Controls.Add(this.labelExt15);
            this.panelExt19.Location = new System.Drawing.Point(-1, 2);
            this.panelExt19.Name = "panelExt19";
            this.panelExt19.Size = new System.Drawing.Size(70, 27);
            this.panelExt19.TabIndex = 1976;
            // 
            // labelExt15
            // 
            this.labelExt15.BackColor = System.Drawing.Color.Transparent;
            this.labelExt15.Location = new System.Drawing.Point(4, 4);
            this.labelExt15.Name = "labelExt15";
            this.labelExt15.Size = new System.Drawing.Size(60, 18);
            this.labelExt15.TabIndex = 55;
            this.labelExt15.Text = "발행월";
            this.labelExt15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt명
            // 
            this.txt명.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(199)))), ((int)(((byte)(217)))));
            this.txt명.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt명.Location = new System.Drawing.Point(301, 5);
            this.txt명.Name = "txt명";
            this.txt명.Size = new System.Drawing.Size(200, 25);
            this.txt명.TabIndex = 1974;
            // 
            // panelExt23
            // 
            this.panelExt23.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelExt23.BackColor = System.Drawing.Color.Transparent;
            this.panelExt23.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelExt23.BackgroundImage")));
            this.panelExt23.Controls.Add(this.panelExt24);
            this.panelExt23.Font = new System.Drawing.Font("굴림", 9F);
            this.panelExt23.Location = new System.Drawing.Point(1, 30);
            this.panelExt23.Name = "panelExt23";
            this.panelExt23.Size = new System.Drawing.Size(1080, 1);
            this.panelExt23.TabIndex = 1973;
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
            this.panelExt24.Size = new System.Drawing.Size(1080, 1);
            this.panelExt24.TabIndex = 155;
            // 
            // dp년월
            // 
            this.dp년월.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dp년월.Location = new System.Drawing.Point(71, 6);
            this.dp년월.Mask = "####/##";
            this.dp년월.MaxDate = new System.DateTime(9999, 12, 31, 23, 59, 59, 999);
            this.dp년월.MaximumSize = new System.Drawing.Size(0, 21);
            this.dp년월.MinDate = new System.DateTime(1800, 1, 1, 0, 0, 0, 0);
            this.dp년월.Name = "dp년월";
            this.dp년월.ShowUpDown = true;
            this.dp년월.Size = new System.Drawing.Size(86, 21);
            this.dp년월.TabIndex = 1970;
            this.dp년월.Tag = "";
            this.dp년월.Value = new System.DateTime(((long)(0)));
            // 
            // lbl엑셀업로드일시
            // 
            this.lbl엑셀업로드일시.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbl엑셀업로드일시.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl엑셀업로드일시.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl엑셀업로드일시.Location = new System.Drawing.Point(568, 8);
            this.lbl엑셀업로드일시.Name = "lbl엑셀업로드일시";
            this.lbl엑셀업로드일시.Size = new System.Drawing.Size(248, 18);
            this.lbl엑셀업로드일시.TabIndex = 1975;
            this.lbl엑셀업로드일시.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this._flexT, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1090, 756);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // _flexT
            // 
            this._flexT.AllowFreezing = C1.Win.C1FlexGrid.AllowFreezingEnum.Both;
            this._flexT.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Both;
            this._flexT.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.MultiColumn;
            this._flexT.AutoResize = false;
            this._flexT.ColumnInfo = "1,1,0,0,0,90,Columns:0{TextAlign:CenterCenter;TextAlignFixed:CenterCenter;}\t";
            this._flexT.Dock = System.Windows.Forms.DockStyle.Fill;
            this._flexT.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw;
            this._flexT.EnabledHeaderCheck = true;
            this._flexT.Font = new System.Drawing.Font("굴림", 9F);
            this._flexT.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this._flexT.KeyActionLeft = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut;
            this._flexT.KeyActionRight = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcrossOut;
            this._flexT.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this._flexT.Location = new System.Drawing.Point(3, 555);
            this._flexT.Name = "_flexT";
            this._flexT.Rows.Count = 1;
            this._flexT.Rows.DefaultSize = 18;
            this._flexT.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this._flexT.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always;
            this._flexT.ShowSort = false;
            this._flexT.Size = new System.Drawing.Size(1084, 198);
            this._flexT.StyleInfo = resources.GetString("_flexT.StyleInfo");
            this._flexT.TabIndex = 174;
            this._flexT.UseGridCalculator = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.labelExt2);
            this.panel4.Location = new System.Drawing.Point(3, 535);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1084, 14);
            this.panel4.TabIndex = 173;
            // 
            // labelExt2
            // 
            this.labelExt2.BackColor = System.Drawing.Color.Transparent;
            this.labelExt2.Font = new System.Drawing.Font("굴림", 9F);
            this.labelExt2.Location = new System.Drawing.Point(4, 0);
            this.labelExt2.Name = "labelExt2";
            this.labelExt2.Size = new System.Drawing.Size(223, 18);
            this.labelExt2.TabIndex = 47;
            this.labelExt2.Text = "▶ 매출분석";
            this.labelExt2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelExt3);
            this.panel2.Location = new System.Drawing.Point(3, 41);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1084, 14);
            this.panel2.TabIndex = 170;
            // 
            // labelExt3
            // 
            this.labelExt3.BackColor = System.Drawing.Color.Transparent;
            this.labelExt3.Font = new System.Drawing.Font("굴림", 9F);
            this.labelExt3.Location = new System.Drawing.Point(4, 0);
            this.labelExt3.Name = "labelExt3";
            this.labelExt3.Size = new System.Drawing.Size(1080, 18);
            this.labelExt3.TabIndex = 47;
            this.labelExt3.Text = "▶ 국세청정보                                                                          " +
    "                                      ▶ 더존정보       ";
            this.labelExt3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 61);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this._flexM);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this._flexD);
            this.splitContainer1.Size = new System.Drawing.Size(1084, 468);
            this.splitContainer1.SplitterDistance = 741;
            this.splitContainer1.TabIndex = 171;
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
            this._flexM.Location = new System.Drawing.Point(0, 0);
            this._flexM.Name = "_flexM";
            this._flexM.Rows.Count = 1;
            this._flexM.Rows.DefaultSize = 18;
            this._flexM.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this._flexM.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always;
            this._flexM.ShowSort = false;
            this._flexM.Size = new System.Drawing.Size(741, 468);
            this._flexM.StyleInfo = resources.GetString("_flexM.StyleInfo");
            this._flexM.TabIndex = 157;
            this._flexM.UseGridCalculator = true;
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
            this._flexD.Location = new System.Drawing.Point(0, 0);
            this._flexD.Name = "_flexD";
            this._flexD.Rows.Count = 1;
            this._flexD.Rows.DefaultSize = 18;
            this._flexD.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this._flexD.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always;
            this._flexD.ShowSort = false;
            this._flexD.Size = new System.Drawing.Size(339, 468);
            this._flexD.StyleInfo = resources.GetString("_flexD.StyleInfo");
            this._flexD.TabIndex = 157;
            this._flexD.UseGridCalculator = true;
            // 
            // P_CZ_ME_SALES_CONS
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.btn거래처변경);
            this.Controls.Add(this.btn엑셀업로드);
            this.Controls.Add(this.panRadio1);
            this.Name = "P_CZ_ME_SALES_CONS";
            this.Size = new System.Drawing.Size(1090, 796);
            this.TitleText = "위수탁 세금계산서 거래처 변경";
            this.Controls.SetChildIndex(this.panRadio1, 0);
            this.Controls.SetChildIndex(this.btn엑셀업로드, 0);
            this.Controls.SetChildIndex(this.btn거래처변경, 0);
            this.Controls.SetChildIndex(this.mDataArea, 0);
            this.mDataArea.ResumeLayout(false);
            this.panRadio1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rdoMts4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoMts3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoMts2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoMts1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelExt1.ResumeLayout(false);
            this.panelExt19.ResumeLayout(false);
            this.panelExt23.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dp년월)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._flexT)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._flexM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._flexD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Duzon.Common.Controls.PanelExt panRadio1;
        private Duzon.Common.Controls.RadioButtonExt rdoMts4;
        private Duzon.Common.Controls.RadioButtonExt rdoMts3;
        private Duzon.Common.Controls.RadioButtonExt rdoMts2;
        private Duzon.Common.Controls.RadioButtonExt rdoMts1;
        private Duzon.Common.Controls.RoundedButton btn엑셀업로드;
        private Duzon.Common.Controls.RoundedButton btn거래처변경;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Duzon.Common.Controls.PanelExt panel1;
        private Duzon.Common.Controls.TextBoxExt txt명;
        private Duzon.Common.Controls.PanelExt panelExt23;
        private Duzon.Common.Controls.PanelExt panelExt24;
        private Duzon.Common.Controls.DatePicker dp년월;
        private Dass.FlexGrid.FlexGrid _flexT;
        private System.Windows.Forms.Panel panel4;
        private Duzon.Common.Controls.LabelExt labelExt2;
        private System.Windows.Forms.Panel panel2;
        private Duzon.Common.Controls.LabelExt labelExt3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Dass.FlexGrid.FlexGrid _flexM;
        private Dass.FlexGrid.FlexGrid _flexD;
        private Duzon.Common.Controls.LabelExt lbl엑셀업로드일시;
        private Duzon.Common.Controls.PanelExt panelExt1;
        private Duzon.Common.Controls.LabelExt labelExt1;
        private Duzon.Common.Controls.PanelExt panelExt19;
        private Duzon.Common.Controls.LabelExt labelExt15;

    }
}
