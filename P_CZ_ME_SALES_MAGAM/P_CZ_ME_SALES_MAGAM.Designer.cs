namespace cz
{
    partial class P_CZ_ME_SALES_MAGAM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(P_CZ_ME_SALES_MAGAM));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._flexD = new Dass.FlexGrid.FlexGrid(this.components);
            this._flexM = new Dass.FlexGrid.FlexGrid(this.components);
            this.panRadio1 = new Duzon.Common.Controls.PanelExt();
            this.rdoMts4 = new Duzon.Common.Controls.RadioButtonExt();
            this.rdoMts3 = new Duzon.Common.Controls.RadioButtonExt();
            this.rdoMts2 = new Duzon.Common.Controls.RadioButtonExt();
            this.rdoMts1 = new Duzon.Common.Controls.RadioButtonExt();
            this.btn마감해제 = new Duzon.Common.Controls.RoundedButton(this.components);
            this.btn마감 = new Duzon.Common.Controls.RoundedButton(this.components);
            this.mDataArea.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._flexD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._flexM)).BeginInit();
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
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 846F));
            this.tableLayoutPanel1.Controls.Add(this._flexD, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this._flexM, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1090, 756);
            this.tableLayoutPanel1.TabIndex = 6;
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
            this._flexD.Location = new System.Drawing.Point(247, 3);
            this._flexD.Name = "_flexD";
            this._flexD.Rows.Count = 1;
            this._flexD.Rows.DefaultSize = 18;
            this._flexD.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this._flexD.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always;
            this._flexD.ShowSort = false;
            this._flexD.Size = new System.Drawing.Size(840, 750);
            this._flexD.StyleInfo = resources.GetString("_flexD.StyleInfo");
            this._flexD.TabIndex = 160;
            this._flexD.UseGridCalculator = true;
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
            this._flexM.Location = new System.Drawing.Point(3, 3);
            this._flexM.Name = "_flexM";
            this._flexM.Rows.Count = 1;
            this._flexM.Rows.DefaultSize = 18;
            this._flexM.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this._flexM.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always;
            this._flexM.ShowSort = false;
            this._flexM.Size = new System.Drawing.Size(238, 750);
            this._flexM.StyleInfo = resources.GetString("_flexM.StyleInfo");
            this._flexM.TabIndex = 159;
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
            // btn마감해제
            // 
            this.btn마감해제.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn마감해제.BackColor = System.Drawing.Color.White;
            this.btn마감해제.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn마감해제.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn마감해제.Location = new System.Drawing.Point(1009, 10);
            this.btn마감해제.MaximumSize = new System.Drawing.Size(0, 19);
            this.btn마감해제.Name = "btn마감해제";
            this.btn마감해제.Size = new System.Drawing.Size(78, 19);
            this.btn마감해제.TabIndex = 4;
            this.btn마감해제.TabStop = false;
            this.btn마감해제.Text = "마감해제";
            this.btn마감해제.UseVisualStyleBackColor = false;
            // 
            // btn마감
            // 
            this.btn마감.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn마감.BackColor = System.Drawing.Color.White;
            this.btn마감.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn마감.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn마감.Location = new System.Drawing.Point(930, 10);
            this.btn마감.MaximumSize = new System.Drawing.Size(0, 19);
            this.btn마감.Name = "btn마감";
            this.btn마감.Size = new System.Drawing.Size(78, 19);
            this.btn마감.TabIndex = 13;
            this.btn마감.TabStop = false;
            this.btn마감.Text = "마감";
            this.btn마감.UseVisualStyleBackColor = false;
            // 
            // P_CZ_ME_SALES_MAGAM
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.btn마감);
            this.Controls.Add(this.btn마감해제);
            this.Controls.Add(this.panRadio1);
            this.Name = "P_CZ_ME_SALES_MAGAM";
            this.Size = new System.Drawing.Size(1090, 796);
            this.TitleText = "매출마감";
            this.Controls.SetChildIndex(this.panRadio1, 0);
            this.Controls.SetChildIndex(this.btn마감해제, 0);
            this.Controls.SetChildIndex(this.btn마감, 0);
            this.Controls.SetChildIndex(this.mDataArea, 0);
            this.mDataArea.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._flexD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._flexM)).EndInit();
            this.panRadio1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rdoMts4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoMts3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoMts2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoMts1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Duzon.Common.Controls.PanelExt panRadio1;
        private Duzon.Common.Controls.RadioButtonExt rdoMts4;
        private Duzon.Common.Controls.RadioButtonExt rdoMts3;
        private Duzon.Common.Controls.RadioButtonExt rdoMts2;
        private Duzon.Common.Controls.RadioButtonExt rdoMts1;
        private Duzon.Common.Controls.RoundedButton btn마감해제;
        private Duzon.Common.Controls.RoundedButton btn마감;
        private Dass.FlexGrid.FlexGrid _flexD;
        private Dass.FlexGrid.FlexGrid _flexM;

    }
}
