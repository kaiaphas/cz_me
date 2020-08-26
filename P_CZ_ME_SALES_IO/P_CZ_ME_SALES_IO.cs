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

        string today = "";
        string toyear = "";
        string rdo_idx = "";

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
            _flexM.BeginSetting(2, 1, false);

            _flexM.SetCol("S", "선택", 35, true, CheckTypeEnum.Y_N);           

            _flexM.SetCol("CPID", "CPID", 50, false);
            
            _flexM.SetCol("CD_COMPANY", "CD_COMPANY", 0, false);

            _flexM.SetCol("REG_DATE", "요청일시", 150, false);
            _flexM.SetCol("STATE", "IO 상태", 100, false);
            _flexM.SetCol("DUZON_STAT", "발행상태", 100, false);
            _flexM.SetCol("ST_IO", "상태값 변경", 100, true);
            _flexM.SetCol("ST_IO_2", "상태값 변경", 0, true);
            _flexM.SetCol("NM_USERDE1", "사유", 200, true);
            _flexM.SetCol("SEND_DATE", "발행(반려)일자", 100, false, typeof(string), FormatTpType.YEAR_MONTH_DAY);
            _flexM.SetCol("NO_DOCU", "전표번호", 100, true);
            _flexM.SetCol("FINAL_STATUS", "세금계산서 발행", 100, false);

            _flexM.SetCol("DUZON_NOTE", "비고", 0, false);
            _flexM.SetCol("MONTH", "월", 50, false);
            _flexM.SetCol("TEAMNAME", "팀", 100, false);
            _flexM.SetCol("CPNAME", "캠페인", 200, false);
            _flexM.SetCol("PERIOD", "기간", 0, false);
            _flexM.SetCol("MEZZO_AE_NAME", "담당자", 100, false);
            _flexM.SetCol("BUDGET", "수주액", 0, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
          
            _flexM.SetCol("INCOME", "내수액", 0, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("AGENTNAME", "광고주", 0, false);
            _flexM.SetCol("BIZ_NAME", "대행사", 0, false);
            _flexM.SetCol("AGENCY_AE_NAME", "대행사담당자", 0, false);
            
            _flexM.SetCol("AGENTNAME2", "광고주명", 120, false);
            _flexM.SetCol("CPNAME2", "캠페인명", 200, false);

            _flexM.SetCol("BIZ_NAME2", "신청인(대행사)", 120, false);
            _flexM.SetCol("AGENCY_AE_NAME2", "담당자", 0, false);
            _flexM.SetCol("AGE_MGR", "대표", 0, false);
            _flexM.SetCol("AGE_PHONE", "전화번호", 0, false);
            _flexM.SetCol("AGE_FAX", "팩스번호", 0, false);
            _flexM.SetCol("BIZ_NO", "사업자번호", 100, false);
            _flexM.SetCol("AGENCY_AE_EMAIL", "이메일", 0, false);
            _flexM.SetCol("ADDRESS", "주소", 0, false);
            _flexM.SetCol("BIZ_TYPE", "업종", 0, false);
            _flexM.SetCol("AGE_OUTDATE_TXT", "계산서 발행일", 100, false);
            
            _flexM.SetCol("PERIOD2", "계약기간", 200, false);
            _flexM.SetCol("ACNAME", "결제조건", 180, false);
            _flexM.SetCol("AGE_BUDGET", "금액", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("AGY_PRICE", "수수료 금액", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("AGE_FEE", "수수료율", 120, false);
            _flexM.SetCol("AGE_ACDATE_TXT", "입금일", 100, false);


            _flexM.Cols["REG_DATE"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["STATE"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["DUZON_STAT"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["ST_IO"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["SEND_DATE"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["NO_DOCU"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["FINAL_STATUS"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["MONTH"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["BIZ_NO"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["PERIOD"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["AGE_PHONE"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["AGE_FAX"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["AGE_OUTDATE_TXT"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["PERIOD2"].TextAlign = TextAlignEnum.CenterCenter;

            //MERGE 처리
            _flexM[0, "REG_DATE"] = _flexM[0, "TAX"] = "세금계산서 정보";
            _flexM[0, "STATE"] = _flexM[0, "TAX"] = "세금계산서 정보";
            _flexM[0, "DUZON_STAT"] = _flexM[0, "TAX"] = "세금계산서 정보";
            _flexM[0, "ST_IO"] = _flexM[0, "TAX"] = "세금계산서 정보";
            _flexM[0, "NM_USERDE1"] = _flexM[0, "TAX"] = "세금계산서 정보";
            _flexM[0, "SEND_DATE"] = _flexM[0, "TAX"] = "세금계산서 정보";
            _flexM[0, "NO_DOCU"] = _flexM[0, "TAX"] = "세금계산서 정보";
            _flexM[0, "FINAL_STATUS"] = _flexM[0, "TAX"] = "세금계산서 정보";

            _flexM[0, "MONTH"] = _flexM[0, "IOL"] = "IO";
            _flexM[0, "TEAMNAME"] = _flexM[0, "IOL"] = "IO";
            _flexM[0, "CPNAME"] = _flexM[0, "IOL"] = "IO";
            _flexM[0, "PERIOD"] = _flexM[0, "IOL"] = "IO";
            _flexM[0, "MEZZO_AE_NAME"] = _flexM[0, "IOL"] = "IO";
            _flexM[0, "BUDGET"] = _flexM[0, "IOL"] = "IO";
            _flexM[0, "INCOME"] = _flexM[0, "IOL"] = "IO";
            _flexM[0, "AGENTNAME"] = _flexM[0, "IOL"] = "IO";
            _flexM[0, "BIZ_NAME"] = _flexM[0, "IOL"] = "IO";
            _flexM[0, "AGENCY_AE_NAME"] = _flexM[0, "IOL"] = "IO";
           
            _flexM[0, "AGENTNAME2"] = _flexM[0, "CAM"] = "Campaign";
            _flexM[0, "CPNAME2"] = _flexM[0, "CAM"] = "Campaign";
            
            _flexM[0, "BIZ_NAME2"] = _flexM[0, "AGE"] = "Agency";
            _flexM[0, "AGENCY_AE_NAME2"] = _flexM[0, "AGE"] = "Agency";
            _flexM[0, "AGE_MGR"] = _flexM[0, "AGE"] = "Agency";
            _flexM[0, "AGE_PHONE"] = _flexM[0, "AGE"] = "Agency";
            _flexM[0, "AGE_FAX"] = _flexM[0, "AGE"] = "Agency";
            _flexM[0, "BIZ_NO"] = _flexM[0, "AGE"] = "Agency";
            _flexM[0, "AGENCY_AE_EMAIL"] = _flexM[0, "AGE"] = "Agency";
            _flexM[0, "ADDRESS"] = _flexM[0, "AGE"] = "Agency";
            _flexM[0, "BIZ_TYPE"] = _flexM[0, "AGE"] = "Agency";
            _flexM[0, "AGE_OUTDATE_TXT"] = _flexM[0, "AGE"] = "Agency";
            _flexM[0, "PERIOD2"] = _flexM[0, "AGE"] = "Agency";
            _flexM[0, "ACNAME"] = _flexM[0, "AGE"] = "Agency";
            _flexM[0, "AGE_BUDGET"] = _flexM[0, "AGE"] = "Agency";
            _flexM[0, "AGY_PRICE"] = _flexM[0, "AGE"] = "Agency";
            _flexM[0, "AGE_FEE"] = _flexM[0, "AGE"] = "Agency";
            _flexM[0, "AGE_ACDATE_TXT"] = _flexM[0, "AGE"] = "Agency";
            
            _flexM.SetDummyColumn("S");

            _flexM.Cols.Frozen = 1;
            _flexM.Cols.Frozen = _flexM.Cols["REG_DATE"].Index;
            _flexM.Cols.Frozen = _flexM.Cols["STATE"].Index;
            _flexM.Cols.Frozen = _flexM.Cols["DUZON_STAT"].Index;
            _flexM.Cols.Frozen = _flexM.Cols["ST_IO"].Index;
            _flexM.Cols.Frozen = _flexM.Cols["NM_USERDE1"].Index;
            _flexM.Cols.Frozen = _flexM.Cols["SEND_DATE"].Index;
            _flexM.Cols.Frozen = _flexM.Cols["NO_DOCU"].Index;
            _flexM.Cols.Frozen = _flexM.Cols["FINAL_STATUS"].Index;

            _flexM.SettingVersion = new Random().Next().ToString();
            _flexM.EndSetting(GridStyleEnum.Green, AllowSortingEnum.MultiColumn, SumPositionEnum.None);

            _flexM.AfterRowChange += new RangeEventHandler(_flexM_AfterRowChange);

            //_flexD 하단그리드
            _flexD.BeginSetting(1, 1, false);

            _flexD.SetCol("CD_ACCT", "계정코드", 80, false);
            _flexD.SetCol("NM_ACCT", "계정명", 120, false);
            _flexD.SetCol("NM_NOTE", "적요", 150, false);
            _flexD.SetCol("AM_DR", "차변", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexD.SetCol("AM_CR", "대변", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexD.SetCol("CD_PARTNER", "거래처코드", 100, false);        
            _flexD.SetCol("LN_PARTNER", "거래처명", 120, false);
            _flexD.SetCol("CD_MNGD1", "사업자등록번호", 100, false);
            _flexD.SetCol("CD_MNGD2", "코드", 100, false);
            _flexD.SetCol("NM_MNGD2", "코스트센터명", 120, false);

           
            _flexD.Cols["CD_ACCT"].TextAlign = TextAlignEnum.CenterCenter;
            _flexD.Cols["CD_PARTNER"].TextAlign = TextAlignEnum.CenterCenter;
            
            _flexD.Cols["CD_MNGD1"].TextAlign = TextAlignEnum.CenterCenter;
            _flexD.Cols["CD_MNGD1"].Format = _flexD.Cols["CD_MNGD1"].EditMask = "###-##-#####";
            _flexD.SetStringFormatCol("CD_MNGD1");
            _flexD.SetNoMaskSaveCol("CD_MNGD1");

            _flexD.SettingVersion = new Random().Next().ToString();
            _flexD.EndSetting(GridStyleEnum.Green, AllowSortingEnum.MultiColumn, SumPositionEnum.None);

            _flexM.SetCodeHelpCol("NO_DOCU", "H_CZ_TAX_SUB", ShowHelpEnum.Always, new string[] { "NO_DOCU", "NO_DOCU" }, new string[] { "NO_DOCU", "NO_DOCU" });
            _flexM.BeforeCodeHelp += new BeforeCodeHelpEventHandler(_flexM_BeforeCodeHelp);
            _flexM.AfterCodeHelp += new AfterCodeHelpEventHandler(_flexM_AfterCodeHelp);
            _flexM.StartEdit += new RowColEventHandler(_flexM_StartEdit);
        }
        #endregion

        #region -> InitPaint

        protected override void InitPaint()
        {
            base.InitPaint();

            //btn변경.Click += new EventHandler(btn변경_Click);
            btn전자세금계산서반영.Click += new EventHandler(btn전자세금계산서반영_Click);
            
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
            }
            catch (Exception ex)
            {
                //MsgEnd(ex);
                ShowMessage(PageResultMode.SaveGood);

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
                    for (int i = 2; i < _flexM.Rows.Count; i++)
                    {
                        if (_flexM[i, "S"].ToString().Equals("Y"))
                        {
                            string IO상태 = _flexM[i, "STATE"].ToString();
                            string 발행상태 = _flexM[i, "DUZON_STAT"].ToString();
                            string 전표번호 = _flexM[i, "NO_DOCU"].ToString();


                            if (_flexM[i, "FINAL_STATUS"].ToString() == "반영")
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
                                if (_biz.Update_Status_Tax(전표번호))
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
                }
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }

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
               
                if (전표번호 != "")
                {
                    e.Cancel = true;
                }

                switch (_flexM.Cols[e.Col].Name)
                {
                    case "NO_DOCU":

                        e.Parameter.UserParams = "전표 도움창;H_CZ_TAX_SUB;";
                        break;    
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

                if (oldValue == newValue) return;

                switch (_flexM.Cols[e.Col].Name)
                {
                    case "NO_DOCU":
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
                if (_flexM[e.Row, "DUZON_STAT"].ToString() != "2" && _flexM[e.Row, "DUZON_STAT"].ToString() != "3")
                {
                    e.Cancel = true;
                }   
            }

            if (_flexM.Cols[e.Col].Name == "NO_DOCU")
            {
                string NO_DOCU = _flexM.GetData(e.Row, e.Col).ToString() == "" ? "0": "1";

                if (NO_DOCU != "0")
                {
                    e.Cancel = true;
                }       
            }

        }

        #endregion

        #region ♥ 기타 Property
        string ServerKey { get { return Global.MainFrame.ServerKeyCommon.ToUpper(); } }
        #endregion            
    }
}