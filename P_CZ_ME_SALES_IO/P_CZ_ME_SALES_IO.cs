using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;
using Dass.FlexGrid;
using Duzon.Common.BpControls;
using Duzon.Common.Forms;
using Duzon.ERPU;
using Duzon.Common.Forms.Help;
using Duzon.Common.Util;
using Duzon.ERPU.MF;
using Duzon.ERPU.MF.Common;
using Duzon.Windows.Print;
using System.ComponentModel;
using Duzon.Common.Controls;
using DzControlLib;


namespace cz
{
    // **************************************
    // 작성자 : 김승일
    // 작성일 : 2020-07-28
    // 모듈명 : IO대사
    // 페이지 : P_CZ_ME_SALES_IO
    // **************************************

    public partial class P_CZ_ME_SALES_IO : PageBase
    {
        #region ♥ 멤버필드

        private P_CZ_ME_SALES_IO_BIZ _biz = new P_CZ_ME_SALES_IO_BIZ();
        bool _타메뉴호출 = false;
        int show_cell = 0;

        #endregion

        #region ♥ 초기화

        #region -> 생성자

        public P_CZ_ME_SALES_IO()
        {
            InitializeComponent();

            MainGrids = new FlexGrid[] { _flexM };
            _flexM.DetailGrids = new FlexGrid[] { _flexD };
        }

        #endregion

        #region -> InitLoad

        protected override void InitLoad()
        {
            base.InitLoad();

            // 그리드 생성
            InitGrid();
        }

        #endregion

        #region -> InitGrid

        private void InitGrid()
        {
            //_flexM 메인그리드
            //merge 기능을 위해서 row 2 설정
            _flexM.BeginSetting(1, 1, false);

            _flexM.SetCol("S", "S", 35, true, CheckTypeEnum.Y_N);           

            _flexM.SetCol("CPID", "CPID", 0, false);
            
            _flexM.SetCol("CD_COMPANY", "CD_COMPANY", 0, false);

            _flexM.SetCol("REG_DATE", "요청일시", 150, false);
            _flexM.SetCol("STATE", "IO 상태", 100, false);
            _flexM.SetCol("DUZON_STAT", "발행상태", 70, false);
            _flexM.SetCol("ST_IO", "상태값변경", 70, true);
            _flexM.SetCol("NM_USERDE1", "사유", 200, true);
            _flexM.SetCol("SEND_DATE", "발행/반려일", 100, false, typeof(string), FormatTpType.YEAR_MONTH_DAY);
            _flexM.SetCol("NO_DOCU_LINE", "전표번호", 120, true);
            _flexM.SetCol("NO_DOCU", "전표번호", 0, false);
            _flexM.SetCol("NO_DOLINE", "라인번호", 0, false);
            _flexM.SetCol("FINAL_STATUS", "세금계산서발행", 0, false);
            _flexM.SetCol("FINAL_STATUS_NM", "세금계산서발행", 100, false);
            _flexM.SetCol("ETAX_STATUS", "MTS반영", 0, false);
            _flexM.SetCol("ETAX_STATUS_NM", "MTS반영", 70, false);
            _flexM.SetCol("ETAX_STATDT", "MTS반영일시", 0, false);

            _flexM.SetCol("DUZON_NOTE", "비고", 0, false);
            _flexM.SetCol("MONTH", "월", 30, false);
            _flexM.SetCol("TEAMNAME", "팀", 120, false);
            _flexM.SetCol("CPNAME", "캠페인", 200, false);
            _flexM.SetCol("PERIOD", "기간", 0, false);
            //_flexM.SetCol("MEZZO_AE_NAME", "담당자", 70, false);
            _flexM.SetCol("AGENCY_AE_NAME", "담당자", 70, false);
            _flexM.SetCol("BUDGET", "수주액", 0, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
          
            _flexM.SetCol("INCOME", "내수액", 0, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("AGENTNAME", "광고주", 0, false);
            _flexM.SetCol("BIZ_NAME", "대행사", 0, false);
            _flexM.SetCol("AGENCY_AE_NAME", "대행사담당자", 0, false);
            
            _flexM.SetCol("AGENTNAME2", "광고주명", 150, false);
            _flexM.SetCol("CPNAME2", "캠페인명", 200, false);

            _flexM.SetCol("BIZ_NAME2", "신청인", 150, false);
            _flexM.SetCol("AGENCY_AE_NAME2", "담당자", 0, false);
            _flexM.SetCol("AGE_MGR", "대표", 0, false);
            _flexM.SetCol("AGE_PHONE", "전화번호", 0, false);
            _flexM.SetCol("AGE_FAX", "팩스번호", 0, false);
            _flexM.SetCol("BIZ_NO", "사업자번호", 100, false);
            _flexM.SetCol("AGENCY_AE_EMAIL", "이메일", 0, false);
            _flexM.SetCol("ADDRESS", "주소", 0, false);
            _flexM.SetCol("BIZ_TYPE", "업종", 0, false);
            _flexM.SetCol("AGE_OUTDATE_TXT", "계산서발행일", 100, false);
            
            _flexM.SetCol("PERIOD2", "계약기간", 150, false);
            _flexM.SetCol("ACNAME", "결제조건", 120, false);
            _flexM.SetCol("AGE_BUDGET", "금액", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("AGY_PRICE", "수수료 금액", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("AGE_FEE", "수수료율", 70, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("AGE_ACDATE_TXT", "입금일", 120, false);

            _flexM.Cols["DUZON_STAT"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["ST_IO"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["SEND_DATE"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["NO_DOCU_LINE"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["NO_DOCU"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["NO_DOLINE"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["FINAL_STATUS_NM"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["ETAX_STATUS_NM"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["MONTH"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["BIZ_NO"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["PERIOD"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["AGE_PHONE"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["AGE_FAX"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["AGE_OUTDATE_TXT"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["PERIOD2"].TextAlign = TextAlignEnum.CenterCenter;

            ////MERGE 처리
            //_flexM[0, "REG_DATE"] = _flexM[0, "TAX"] = "세금계산서 정보";
            //_flexM[0, "STATE"] = _flexM[0, "TAX"] = "세금계산서 정보";
            //_flexM[0, "DUZON_STAT"] = _flexM[0, "TAX"] = "세금계산서 정보";
            //_flexM[0, "ST_IO"] = _flexM[0, "TAX"] = "세금계산서 정보";
            //_flexM[0, "NM_USERDE1"] = _flexM[0, "TAX"] = "세금계산서 정보";
            //_flexM[0, "SEND_DATE"] = _flexM[0, "TAX"] = "세금계산서 정보";
            //_flexM[0, "NO_DOCU"] = _flexM[0, "TAX"] = "세금계산서 정보";
            //_flexM[0, "NO_DOLINE"] = _flexM[0, "TAX"] = "세금계산서 정보";
            //_flexM[0, "FINAL_STATUS"] = _flexM[0, "TAX"] = "세금계산서 정보";
            //_flexM[0, "ETAX_STATUS"] = _flexM[0, "TAX"] = "세금계산서 정보";
            //_flexM[0, "ETAX_STATUS_NM"] = _flexM[0, "TAX"] = "세금계산서 정보";
            //_flexM[0, "ETAX_STATDT"] = _flexM[0, "TAX"] = "세금계산서 정보";
            //
            //_flexM[0, "MONTH"] = _flexM[0, "IOL"] = "IO";
            //_flexM[0, "TEAMNAME"] = _flexM[0, "IOL"] = "IO";
            //_flexM[0, "CPNAME"] = _flexM[0, "IOL"] = "IO";
            //_flexM[0, "PERIOD"] = _flexM[0, "IOL"] = "IO";
            //_flexM[0, "MEZZO_AE_NAME"] = _flexM[0, "IOL"] = "IO";
            //_flexM[0, "BUDGET"] = _flexM[0, "IOL"] = "IO";
            //_flexM[0, "INCOME"] = _flexM[0, "IOL"] = "IO";
            //_flexM[0, "AGENTNAME"] = _flexM[0, "IOL"] = "IO";
            //_flexM[0, "BIZ_NAME"] = _flexM[0, "IOL"] = "IO";
            //_flexM[0, "AGENCY_AE_NAME"] = _flexM[0, "IOL"] = "IO";
            //
            //_flexM[0, "AGENTNAME2"] = _flexM[0, "CAM"] = "Campaign";
            //_flexM[0, "CPNAME2"] = _flexM[0, "CAM"] = "Campaign";
            //
            //_flexM[0, "BIZ_NAME2"] = _flexM[0, "AGE"] = "Agency";
            //_flexM[0, "AGENCY_AE_NAME2"] = _flexM[0, "AGE"] = "Agency";
            //_flexM[0, "AGE_MGR"] = _flexM[0, "AGE"] = "Agency";
            //_flexM[0, "AGE_PHONE"] = _flexM[0, "AGE"] = "Agency";
            //_flexM[0, "AGE_FAX"] = _flexM[0, "AGE"] = "Agency";
            //_flexM[0, "BIZ_NO"] = _flexM[0, "AGE"] = "Agency";
            //_flexM[0, "AGENCY_AE_EMAIL"] = _flexM[0, "AGE"] = "Agency";
            //_flexM[0, "ADDRESS"] = _flexM[0, "AGE"] = "Agency";
            //_flexM[0, "BIZ_TYPE"] = _flexM[0, "AGE"] = "Agency";
            //_flexM[0, "AGE_OUTDATE_TXT"] = _flexM[0, "AGE"] = "Agency";
            //_flexM[0, "PERIOD2"] = _flexM[0, "AGE"] = "Agency";
            //_flexM[0, "ACNAME"] = _flexM[0, "AGE"] = "Agency";
            //_flexM[0, "AGE_BUDGET"] = _flexM[0, "AGE"] = "Agency";
            //_flexM[0, "AGY_PRICE"] = _flexM[0, "AGE"] = "Agency";
            //_flexM[0, "AGE_FEE"] = _flexM[0, "AGE"] = "Agency";
            //_flexM[0, "AGE_ACDATE_TXT"] = _flexM[0, "AGE"] = "Agency";
            
            _flexM.SetDummyColumn("S");

            //_flexM.Cols.Frozen = 1;
            //_flexM.Cols.Frozen = _flexM.Cols["REG_DATE"].Index;
            //_flexM.Cols.Frozen = _flexM.Cols["STATE"].Index;
            //_flexM.Cols.Frozen = _flexM.Cols["DUZON_STAT"].Index;
            //_flexM.Cols.Frozen = _flexM.Cols["ST_IO"].Index;
            //_flexM.Cols.Frozen = _flexM.Cols["NM_USERDE1"].Index;
            //_flexM.Cols.Frozen = _flexM.Cols["SEND_DATE"].Index;
            //_flexM.Cols.Frozen = _flexM.Cols["NO_DOCU"].Index;
            //_flexM.Cols.Frozen = _flexM.Cols["FINAL_STATUS"].Index;

            _flexM.SettingVersion = new Random().Next().ToString();
            _flexM.EndSetting(GridStyleEnum.Green, AllowSortingEnum.MultiColumn, SumPositionEnum.None);

            _flexM.AfterRowChange += new RangeEventHandler(_flexM_AfterRowChange);

            //_flexD 하단그리드
            _flexD.BeginSetting(1, 1, false);

            _flexD.SetCol("CD_ACCT", "계정코드", 70, false);
            _flexD.SetCol("NM_ACCT", "계정명", 120, false);
            _flexD.SetCol("NM_NOTE", "적요", 200, false);
            _flexD.SetCol("AM_DR", "차변", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexD.SetCol("AM_CR", "대변", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexD.SetCol("CD_MNGD1", "관리항목코드1", 0, false);
            _flexD.SetCol("NM_MNGD1", "관리항목1", 150, false);
            _flexD.SetCol("CD_MNGD2", "관리항목코드2", 0, false);
            _flexD.SetCol("NM_MNGD2", "관리항목2", 150, false);
            _flexD.SetCol("CD_MNGD3", "관리항목코드3", 0, false);
            _flexD.SetCol("NM_MNGD3", "관리항목3", 150, false);
            _flexD.SetCol("CD_MNGD4", "관리항목코드4", 0, false);
            _flexD.SetCol("NM_MNGD4", "관리항목4", 150, false);
            _flexD.SetCol("CD_MNGD5", "관리항목코드5", 0, false);
            _flexD.SetCol("NM_MNGD5", "관리항목5", 150, false);
            _flexD.SetCol("CD_MNGD6", "관리항목코드6", 0, false);
            _flexD.SetCol("NM_MNGD6", "관리항목6", 150, false);
            _flexD.SetCol("CD_MNGD7", "관리항목코드7", 0, false);
            _flexD.SetCol("NM_MNGD7", "관리항목7", 150, false);
            _flexD.SetCol("CD_MNGD8", "관리항목코드8", 0, false);
            _flexD.SetCol("NM_MNGD8", "관리항목8", 150, false);

           
            _flexD.Cols["CD_ACCT"].TextAlign = TextAlignEnum.CenterCenter;
            
            _flexD.Cols["CD_MNGD1"].TextAlign = TextAlignEnum.CenterCenter;
            _flexD.Cols["CD_MNGD1"].Format = _flexD.Cols["CD_MNGD1"].EditMask = "###-##-#####";
            _flexD.SetStringFormatCol("CD_MNGD1");
            _flexD.SetNoMaskSaveCol("CD_MNGD1");

            _flexD.SettingVersion = new Random().Next().ToString();
            _flexD.EndSetting(GridStyleEnum.Green, AllowSortingEnum.MultiColumn, SumPositionEnum.None);

            _flexM.SetCodeHelpCol("NO_DOCU", "H_CZ_TAX_SUB", ShowHelpEnum.Always, new string[] { "NO_DOCU", "NO_DOLINE" }, new string[] { "NO_DOCU", "NO_DOLINE" });
            _flexM.SetCodeHelpCol("NO_DOCU_LINE", "H_CZ_TAX_SUB", ShowHelpEnum.Always, new string[] { "NO_DOCU", "NO_DOLINE" }, new string[] { "NO_DOCU", "NO_DOLINE" });
            _flexM.BeforeCodeHelp += new BeforeCodeHelpEventHandler(_flexM_BeforeCodeHelp);
            _flexM.AfterCodeHelp += new AfterCodeHelpEventHandler(_flexM_AfterCodeHelp);
            _flexM.StartEdit += new RowColEventHandler(_flexM_StartEdit);
            //_flexM.HelpClick += new EventHandler(_flexM_HelpClick);
        }
        #endregion

        #region -> InitPaint

        protected override void InitPaint()
        {
            base.InitPaint();

            //btn변경.Click += new EventHandler(btn변경_Click);
            btn전자세금계산서반영.Click += new EventHandler(btn전자세금계산서반영_Click);
            btn전자세금계산서36524.Click += new EventHandler(btn전자세금계산서36524_Click);
            btnMTS반영.Click += new EventHandler(btnMTS반영_Click);
            //btn상태값변경MTS반영.Click += new EventHandler(btn상태값변경MTS반영_Click);

            //Grant.CanSave = false;
            Grant.CanDelete = false;
            Grant.CanAdd = false;
            Grant.CanPrint = false;

            string longtoday = "";

            longtoday = DateTime.Now.ToString("yyyMMddHHmmss");

            dp년월.Text = longtoday.Substring(0, 6);

            DateTime time = Global.MainFrame.GetDateTimeToday();
            
            //btn전표처리.Click += new EventHandler(btn전표처리_Click);          

            _flexM.SetDataMap("STATE", MA.GetCode("CZ_ME_C010"), "CODE", "NAME");
            _flexM.SetDataMap("ST_IO", MA.GetCode("CZ_ME_C011"), "CODE", "NAME");
            _flexM.SetDataMap("DUZON_STAT", MA.GetCode("CZ_ME_C009"), "CODE", "NAME");


            //콤보박스 셋팅

            SetControl set = new SetControl();
            
            set.SetCombobox(cboIO상태, MA.GetCode("CZ_ME_C010", false));
            set.SetCombobox(cbo세금계산서발행상태, MA.GetCode("CZ_ME_C009", false));
            //set.SetCombobox(cboIO상태값변경, MA.GetCode("CZ_ME_C011", false));

            cboIO상태.SelectedIndex = 5;
            cbo세금계산서발행상태.SelectedIndex = 2;

        }

        #endregion

        #endregion

        #region ♥ 메인버튼 클릭

        #region -> 조회버튼클릭

        public override void OnToolBarSearchButtonClicked(object sender, EventArgs e)
        {
            try
            {
                object[] Params = new object[5];
                Params[0] = LoginInfo.CompanyCode;
                Params[1] = "SELECT";
                Params[2] = dp년월.Text;
                Params[3] = cboIO상태.SelectedValue;
                Params[4] = cbo세금계산서발행상태.SelectedValue;

                DataSet ds = _biz.Search_M(Params);

                _flexM.Binding = ds.Tables[0];

            }
            catch (Exception ex)
            {
                this.MsgEnd(ex);
            }
        }

        #endregion

        #region -> 저장버튼클릭

        public override void OnToolBarSaveButtonClicked(object sender, EventArgs e)
        {
            try
            {
                if (!BeforeSaveChk())
                    return;

                if (SaveData())
                {
                    ShowMessage(PageResultMode.SaveGood);
                    {
                        show_cell = _flexM.Row;

                        object[] Params = new object[5];
                        Params[0] = LoginInfo.CompanyCode;
                        Params[1] = "SELECT";
                        Params[2] = dp년월.Text;
                        Params[3] = cboIO상태.SelectedValue;
                        Params[4] = cbo세금계산서발행상태.SelectedValue;

                        DataSet ds = _biz.Search_M(Params);

                        _flexM.Binding = ds.Tables[0];

                        if (show_cell > 1)
                        {
                            _flexM.ShowCell(show_cell, 1);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //MsgEnd(ex);
                ShowMessage(PageResultMode.SaveGood);
                
                show_cell = _flexM.Row;

                object[] Params = new object[5];
                Params[0] = LoginInfo.CompanyCode;
                Params[1] = "SELECT";
                Params[2] = dp년월.Text;
                Params[3] = cboIO상태.SelectedValue;
                Params[4] = cbo세금계산서발행상태.SelectedValue;

                DataSet ds = _biz.Search_M(Params);

                _flexM.Binding = ds.Tables[0];

                if (show_cell > 1)
                {
                    _flexM.ShowCell(show_cell, 1);
                }
            }
        }

        // 실제 저장 기능
        protected override bool SaveData()
        {
            object obj = null;

            if (_flexM.HasNormalRow)
            {
                obj = _biz.Save(_flexM.GetChanges(), _타메뉴호출);
            }

            ResultData[] result = (ResultData[])obj;

            return true;
        }

        // 저장 전 체크 사항
        protected bool BeforeSaveChk()
        {

            //string DUZON_STAT = D.GetString(_flexM.GetData(e.Row, e.Col));//수정 전에 입력되어있던 값
            //string ST_IO = e.Result.CodeValue;//수정한 값
            //
            //if (oldValue == newValue) return false;
            //
            return true;
        }
        #endregion

        #region -> 삭제버튼클릭

        public override void OnToolBarDeleteButtonClicked(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }
        #endregion

        #region -> 추가버튼클릭

        public override void OnToolBarAddButtonClicked(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }

        }

        #endregion

        #endregion

        #region ♥ 기타 이벤트

        /*
        private void btn변경_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_flexM.HasNormalRow)
                    return;
        
                if (!BeforeSaveChk())
                    return;
        
                DataRow[] ldrchk = _flexM.DataTable.Select("S = 'Y'", "", DataViewRowState.CurrentRows);
        
                if (ldrchk == null || ldrchk.Length == 0)
                {
                    ShowMessage(공통메세지.선택된자료가없습니다);
                    return;
                }
        
                if (ShowMessage("선택한 데이터의 IO 상태값을 변경 하시겠습니까?", "QY2") == DialogResult.Yes)
                {
                    for (int i = 2; i < _flexM.Rows.Count; i++)
                    {
                        string 캠페인코드 = _flexM[i, "CPID"].ToString();
                        string 상태값변경 = "";
                        string 상태값변경2 = _flexM[i, "ST_IO"].ToString();

                        if (_flexM[i, "S"].ToString().Equals("Y"))
                        {
                            //string 사유 = _flexM[i, "NM_USERDE1"].ToString();
                            if (_flexM[i, "ST_IO"].ToString().Equals("0"))
                            {
                                ShowMessage("상태값 변경을 한 경우에만 변경이 가능합니다.");
                                return;
                            }

                            if (_flexM[i, "ST_IO"].ToString().Equals("4") || _flexM[i, "ST_IO"].ToString().Equals("41") || _flexM[i, "ST_IO"].ToString().Equals("42"))
                            {
                                상태값변경 = "4";
                            }
                            else if (_flexM[i, "ST_IO"].ToString().Equals("5"))
                            {
                                상태값변경 = "5";
                            }

                            if (_biz.Update_Status(캠페인코드, 상태값변경, 상태값변경2))
                            {
                            
                            }
                        }
                    }

                    ShowMessage("변경이 완료 되었습니다.");

                    object[] Params = new object[5];
                    Params[0] = LoginInfo.CompanyCode;
                    Params[1] = "SELECT";
                    Params[2] = dp년월.Text;
                    Params[3] = cboIO상태.SelectedValue;
                    Params[4] = cbo세금계산서발행상태.SelectedValue;

                    DataSet ds = _biz.Search_M(Params);

                    _flexM.Binding = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                //MsgEnd(ex);
                ShowMessage("변경이 완료 되었습니다.");
                
                object[] Params = new object[5];
                Params[0] = LoginInfo.CompanyCode;
                Params[1] = "SELECT";
                Params[2] = dp년월.Text;
                Params[3] = cboIO상태.SelectedValue;
                Params[4] = cbo세금계산서발행상태.SelectedValue;
                
                DataSet ds = _biz.Search_M(Params);
                
                _flexM.Binding = ds.Tables[0];
                return;
            }
        }
        */

        private void btn전자세금계산서반영_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_flexM.HasNormalRow)
                    return;

                if (!BeforeSaveChk())
                    return;

                DataRow[] ldrchk = _flexM.DataTable.Select("S = 'Y'", "", DataViewRowState.CurrentRows);

                if (ldrchk == null || ldrchk.Length == 0)
                {
                    ShowMessage(공통메세지.선택된자료가없습니다);
                    return;
                }

                if (ShowMessage("선택한 데이터의 전자세금계산서를 반영 하시겠습니까?", "QY2") == DialogResult.Yes)
                {
                    for (int i = 1; i < _flexM.Rows.Count; i++)
                    {
                        if (_flexM[i, "S"].ToString().Equals("Y"))
                        {
                            show_cell = _flexM.Row;

                            string IO상태 = _flexM[i, "STATE"].ToString();
                            string 발행상태 = _flexM[i, "DUZON_STAT"].ToString();
                            string 전표번호 = _flexM[i, "NO_DOCU"].ToString();
                            string 전표라인번호 = _flexM[i, "NO_DOLINE"].ToString();
                            string 사유 = _flexM[i, "NM_USERDE1"].ToString();
                            string 캠페인코드 = _flexM[i, "CPID"].ToString();
                            string 상태값변경 = _flexM[i, "ST_IO"].ToString();

                            if (_flexM[i, "FINAL_STATUS_NM"].ToString() != "미반영")
                            {
                                ShowMessage("이미 세금계산서 반영이 완료된 데이터 입니다.");
                                return;
                            }

                            if (_flexM[i, "STATE"].ToString() != "5" || (_flexM[i, "DUZON_STAT"].ToString() != "2" && _flexM[i, "DUZON_STAT"].ToString() != "3") || _flexM[i, "NO_DOCU"].ToString() == "")
                            {
                                ShowMessage("IO상태가 승인완료, 발행상태가 발행요청 또는 수정발행요청, 전표번호가 있는경우에만 전자세금계산서 반영이 가능합니다.");
                                return;                    
                            }
                            else
                            {
                                if (_biz.Update_Status_Tax(전표번호, 전표라인번호))
                                {

                                }     

                                if (_biz.Insert_IO(캠페인코드, 전표번호, 전표라인번호, 상태값변경, 발행상태, 사유))
                                {

                                }                                   
                            }       
                        }
                    }

                    ShowMessage("반영이 완료 되었습니다.");

                    object[] Params = new object[5];
                    Params[0] = LoginInfo.CompanyCode;
                    Params[1] = "SELECT";
                    Params[2] = dp년월.Text;
                    Params[3] = cboIO상태.SelectedValue;
                    Params[4] = cbo세금계산서발행상태.SelectedValue;

                    DataSet ds = _biz.Search_M(Params);

                    _flexM.Binding = ds.Tables[0];

                    if (show_cell > 1)
                    {
                        _flexM.ShowCell(show_cell, 1);
                    }
                }
            }
            catch (Exception ex)
            {
                //MsgEnd(ex);

                ShowMessage("반영이 완료 되었습니다.");

                object[] Params = new object[5];
                Params[0] = LoginInfo.CompanyCode;
                Params[1] = "SELECT";
                Params[2] = dp년월.Text;
                Params[3] = cboIO상태.SelectedValue;
                Params[4] = cbo세금계산서발행상태.SelectedValue;

                DataSet ds = _biz.Search_M(Params);

                _flexM.Binding = ds.Tables[0];

                if (show_cell > 1)
                {
                    _flexM.ShowCell(show_cell, 1);
                }
            }
        }

        private void btn전자세금계산서36524_Click(object sender, EventArgs e)
        {
            try
            {
                object[] Args = { null, null };
                CallOtherPageMethod("P_FI_ETAX_36524", "전자세금계산서발행(36524)(" + PageName + ")", Grant, Args);
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }

        private void btnMTS반영_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_flexM.HasNormalRow)
                    return;

                if (!BeforeSaveChk())
                    return;

                DataRow[] ldrchk = _flexM.DataTable.Select("S = 'Y'", "", DataViewRowState.CurrentRows);

                if (ldrchk == null || ldrchk.Length == 0)
                {
                    ShowMessage(공통메세지.선택된자료가없습니다);
                    return;
                }
               
                if (ShowMessage("선택한 데이터를 MTS반영 하시겠습니까?", "QY2") == DialogResult.Yes)
                {

                    for (int i = 1; i < _flexM.Rows.Count; i++)
                    {
                        if (_flexM[i, "S"].ToString().Equals("Y"))
                        {
                            show_cell = _flexM.Row;

                            string 캠페인코드 = _flexM[i, "CPID"].ToString();
                            string 세금계산서상태 = _flexM[i, "ETAX_STATUS"].ToString();
                            string 세금계산서일시 = _flexM[i, "ETAX_STATDT"].ToString();
                            string 세금계산서발행 = _flexM[i, "FINAL_STATUS"].ToString();

                            string 전표번호 = _flexM[i, "NO_DOCU"].ToString();
                            string 전표라인번호 = _flexM[i, "NO_DOLINE"].ToString();
                            string 상태값변경 = _flexM[i, "ST_IO"].ToString();
                            string 발행상태 = _flexM[i, "DUZON_STAT"].ToString();
                            string 사유 = _flexM[i, "NM_USERDE1"].ToString();

                            //세금계산서 발행이 1,2인것만 (발행 및 상태확인완료된것) , 발행상태이 발행요청 or 수정발행요청 or 취소인것
                            if ((세금계산서발행 == "1" || 세금계산서발행 == "2") && (발행상태.Equals("2") || 발행상태.Equals("3") || 발행상태.Equals("7")))
                            {
                                if (_biz.Update_Status(캠페인코드, 세금계산서상태, 세금계산서일시, 사유))
                                {

                                }
                            }

                            else
                            {
                                if (_biz.Insert_IO(캠페인코드, 전표번호, 전표라인번호, 상태값변경, 발행상태, 사유))
                                {

                                }    
                            }
                        }
                    }

                    ShowMessage("반영이 완료 되었습니다.");

                    object[] Params = new object[5];
                    Params[0] = LoginInfo.CompanyCode;
                    Params[1] = "SELECT";
                    Params[2] = dp년월.Text;
                    Params[3] = cboIO상태.SelectedValue;
                    Params[4] = cbo세금계산서발행상태.SelectedValue;

                    DataSet ds = _biz.Search_M(Params);

                    _flexM.Binding = ds.Tables[0];

                    if (show_cell > 1)
                    {
                        _flexM.ShowCell(show_cell, 1);
                    }
                } 
            }
            catch (Exception ex)
            {
                //MsgEnd(ex);
                ShowMessage("반영이 완료 되었습니다.");

                show_cell = _flexM.Row;

                object[] Params = new object[5];
                Params[0] = LoginInfo.CompanyCode;
                Params[1] = "SELECT";
                Params[2] = dp년월.Text;
                Params[3] = cboIO상태.SelectedValue;
                Params[4] = cbo세금계산서발행상태.SelectedValue;

                DataSet ds = _biz.Search_M(Params);

                _flexM.Binding = ds.Tables[0];

                if (show_cell > 1)
                {
                    _flexM.ShowCell(show_cell, 1);
                }
                return;
            }
        }

        /*
        private void btn상태값변경MTS반영_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_flexM.HasNormalRow)
                    return;

                if (!BeforeSaveChk())
                    return;

                DataRow[] ldrchk = _flexM.DataTable.Select("S = 'Y'", "", DataViewRowState.CurrentRows);

                if (ldrchk == null || ldrchk.Length == 0)
                {
                    ShowMessage(공통메세지.선택된자료가없습니다);
                    return;
                }

                if (ShowMessage("선택한 데이터를 상태값변경 MTS반영 하시겠습니까?", "QY2") == DialogResult.Yes)
                {

                    for (int i = 1; i < _flexM.Rows.Count; i++)
                    {
                        if (_flexM[i, "S"].ToString().Equals("Y"))
                        {
                            show_cell = _flexM.Row;

                            string 캠페인코드 = _flexM[i, "CPID"].ToString();
                            string 전표번호 = _flexM[i, "NO_DOCU"].ToString();
                            string 전표라인번호 = _flexM[i, "NO_DOLINE"].ToString();
                            string 상태값변경 = _flexM[i, "ST_IO"].ToString();
                            string 발행상태 = _flexM[i, "DUZON_STAT"].ToString();
                            string 사유 = _flexM[i, "NM_USERDE1"].ToString();

                            if (_biz.Insert_IO(캠페인코드, 전표번호, 전표라인번호, 상태값변경, 발행상태, 사유))
                            {

                            }    
                        }
                    }

                    ShowMessage("반영이 완료 되었습니다.");

                    object[] Params = new object[5];
                    Params[0] = LoginInfo.CompanyCode;
                    Params[1] = "SELECT";
                    Params[2] = dp년월.Text;
                    Params[3] = cboIO상태.SelectedValue;
                    Params[4] = cbo세금계산서발행상태.SelectedValue;

                    DataSet ds = _biz.Search_M(Params);

                    _flexM.Binding = ds.Tables[0];

                    _flexM.ShowCell(show_cell, 1);
                }
            }
            catch (Exception ex)
            {
                //MsgEnd(ex);
                ShowMessage("반영이 완료 되었습니다.");

                show_cell = _flexM.Row;

                object[] Params = new object[5];
                Params[0] = LoginInfo.CompanyCode;
                Params[1] = "SELECT";
                Params[2] = dp년월.Text;
                Params[3] = cboIO상태.SelectedValue;
                Params[4] = cbo세금계산서발행상태.SelectedValue;

                DataSet ds = _biz.Search_M(Params);

                _flexM.Binding = ds.Tables[0];

                _flexM.ShowCell(show_cell, 1);
                return;
            }
        }
        */

        /*
        private void btn전표삭제_Click(object sender, EventArgs e)
        {
            try
            {
                if (_flexM.Row.ToString() == null || _flexM.Row.ToString() == "" || _flexM.Rows.Count == 2)
                    return;

                string Year = dp년월.Text.Substring(0, 4);  //조회연월 FROM

                DataTable dt = _biz.Get마감여부(Year);

                if (dt.Rows.Count != 0 && dt.Rows[0]["ST_MAGAM"].Equals("1"))
                {
                    ShowMessage("이미 마감처리된 기수로 동기화할 수 없습니다.");
                    return;
                }

                if (ShowMessage(" 삭제하시겠습니까?", "QY2") == DialogResult.Yes)
                {

                    string 캠페인코드 = _flexM[_flexM.Row, "CPID"].ToString();
                    string 상태값변경 = _flexM[_flexM.Row, "ST_IO"].ToString();
                    string MTS반영 = _flexM[_flexM.Row, "ETAX_STATUS"].ToString();

                    if (상태값변경 != "0" || MTS반영 != null || MTS반영 != "")
                    {
                        ShowMessage((_flexM.Row-1) + "행은 상태 값 변경, MTS 반영이 처리된 항목으로, 삭제할 수 없습니다.");
                        return;
                    }

                    if (_biz.Delete_IO(캠페인코드))
                    {

                    }
                      
                    ShowMessage("삭제가 완료 되었습니다.");
                    
                    object[] Params = new object[5];
                    Params[0] = LoginInfo.CompanyCode;
                    Params[1] = "SELECT";
                    Params[2] = dp년월.Text;
                    Params[3] = cboIO상태.SelectedValue;
                    Params[4] = cbo세금계산서발행상태.SelectedValue;

                    DataSet ds = _biz.Search_M(Params);

                    _flexM.Binding = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }
        */

        #endregion

        #region ♥ 그리드 이벤트

        //_flexD 하단그리드
        void _flexM_AfterRowChange(object sender, RangeEventArgs e)
        {
            try
            {
                object[] Params = new object[5];
                Params[0] = "*";
                Params[1] = LoginInfo.CompanyCode;
                Params[2] = Global.MainFrame.LoginInfo.CdPc;
                Params[3] = D.GetString(_flexM["NO_DOCU"]);
                //Params[3] = "NO202004300089";
                Params[4] = "L0";

                DataSet ds = _biz.Search_D(Params);

                _flexD.Binding = ds.Tables[0];
            }
            catch (Exception ex)
            {
                this.MsgEnd(ex);
            }
        }

        void _flexM_BeforeCodeHelp(object sender, BeforeCodeHelpEventArgs e)
        {
            try
            {
                string 전표번호 = D.GetString(_flexM["NO_DOCU"]);
                string 전표번호2 = "";
                if (전표번호.Length > 0)
                {
                    전표번호2 = 전표번호.Substring(0, 2);
                }

                if (전표번호 != "" && 전표번호2 != "FI")
                {
                    e.Cancel = true;
                }
                else
                {
                    switch (_flexM.Cols[e.Col].Name)
                    {
                        //case "NO_DOCU":
                        case "NO_DOCU_LINE":

                            e.Parameter.UserParams = "전표 도움창;H_CZ_TAX_SUB;";
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }    
        }

        void _flexM_AfterCodeHelp(object sender, AfterCodeHelpEventArgs e)
        {
            try
            {
                DataTable dt = e.Result.DataTable;        //멀티 or 단일 도움창에서 선택된 데이터들을 Table형태로 가져온다
                //설정   

                string oldValue = D.GetString(_flexM.GetData(e.Row, e.Col));//수정 전에 입력되어있던 값
                string newValue = e.Result.CodeValue;//수정한 값
                string newValue_2 = e.Result.CodeName;
                if (oldValue == newValue) return;

                switch (_flexM.Cols[e.Col].Name)
                {
                    case "NO_DOCU":
                         break;
                    case "NO_DOCU_LINE":
                         _flexM[e.Row, "NO_DOCU_LINE"] = newValue + "-" + newValue_2;
                        break;
                }
            }
            catch (Exception ex)
            {
                this.MsgEnd(ex);
            }
        }

        void _flexM_StartEdit(object sender, RowColEventArgs e)
        {
            if (_flexM.Cols[e.Col].Name == "S")
            {
                /*
                if ((_flexM[e.Row, "DUZON_STAT"].ToString() != "2" && _flexM[e.Row, "DUZON_STAT"].ToString() != "3"))
                {
                    e.Cancel = true;
                }
                
    
                if (_flexM[e.Row, "DUZON_STAT"].ToString().Equals("0") || _flexM[e.Row, "DUZON_STAT"].ToString().Equals("1") || _flexM[e.Row, "DUZON_STAT"].ToString().Equals("5"))
                {
                    if ((_flexM[e.Row, "STATE"].ToString().Equals("5") && _flexM[e.Row, "DUZON_STAT"].ToString().Equals("4")))
                    {
                        return;
                    }   

                    e.Cancel = true;
                }
                */
            }

            if (_flexM.Cols[e.Col].Name == "NO_DOCU")
            {
                string NO_DOCU = _flexM.GetData(e.Row, e.Col).ToString() == "" ? "0": "1";

                if (NO_DOCU != "0")
                {
                    e.Cancel = true;
                }       
            }

            if (_flexM.Cols[e.Col].Name == "NO_DOLINE")
            {
                string NO_DOLINE = _flexM.GetData(e.Row, e.Col).ToString() == "" ? "0" : "1";

                if (NO_DOLINE != "0")
                {
                    e.Cancel = true;
                }
            }

            if (_flexM.Cols[e.Col].Name == "NO_DOCU_LINE")
            {
                string NO_DOCU_LINE = _flexM.GetData(e.Row, e.Col).ToString() == "" ? "0" : "1";
                string FI_CHK = "";
               
                if( NO_DOCU_LINE.Equals("1"))
                {
                     FI_CHK = _flexM.GetData(e.Row, e.Col).ToString().Substring(0, 2);
                }
                
                if (NO_DOCU_LINE != "0" && FI_CHK != "FI")
                {
                    e.Cancel = true;
                }
            }
        }

        void _flexM_HelpClick(object sender, EventArgs e)
        {
            try
            {
                string 전표번호 = D.GetString(_flexM["NO_DOCU"]);
                string 전표번호2 = "";
                
                if (전표번호.Length > 0)
                {
                    전표번호2 = 전표번호.Substring(0, 2);
                }

                if (전표번호 == "" || 전표번호2 == "FI")
                    return;

                switch (_flexM.Cols[_flexM.Col].Name)
                {
                    case "NO_DOCU":

                        object[] Args = { 전표번호, "", "", Duzon.Common.Forms.Global.MainFrame.LoginInfo.CompanyCode };
                        CallOtherPageMethod("P_FI_DOCU", "전표입력(" + PageName + ")", Grant, Args);

                        break;
                }
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }

        #endregion

        #region ♥ 기타 Property
        string ServerKey { get { return Global.MainFrame.ServerKeyCommon.ToUpper(); } }
        #endregion            
    }
}