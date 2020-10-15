using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;
using Dass.FlexGrid;
using Duzon.Common.BpControls;
using Duzon.Common.Forms;
using Duzon.ERPU.Grant;
using Duzon.ERPU;
using Duzon.ERPU.MF;
using Duzon.ERPU.MF.Common;
using Duzon.Windows.Print;
using Duzon.Common.Forms.Help;

namespace cz
{
    // **************************************
    // 작   성   자 : 박승한
    // 재 작  성 일 : 2020-10-05
    // 페 이 지  명 : 매출채권 잔액
    // 프로젝트  명 : CZ_ME_BOND_BALANCE
    // **************************************
    public partial class P_CZ_ME_BOND_BALANCE : PageBase
    {
        #region ♥ 멤버필드

        private P_CZ_ME_BOND_BALANCE_BIZ _biz = new P_CZ_ME_BOND_BALANCE_BIZ();
        bool _타메뉴호출 = false;

        #endregion

        #region ♥ 초기화

        #region -> 생성자

        public P_CZ_ME_BOND_BALANCE()
        {
            InitializeComponent();
            MainGrids = new FlexGrid[] { _flexM };    //그리드 자동 저장 기능 필요시 주석 해제
            //_flexM.DetailGrids = new FlexGrid[] { _flexD }; 
        }

        #endregion

        #region -> InitLoad

        protected override void InitLoad()
        {
            base.InitLoad();
            string today = "";
            string toyear = "";

            DateTime time = this.MainFrameInterface.GetDateTimeToday(); // 오늘 날짜

            today = time.ToString("yyyMMdd");
            toyear = today.Substring(0, 8);

            toyear = time.ToString("yyyy") + "0101";

            dt기간.StartDate = DateTime.ParseExact(toyear, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            dt기간.EndDate = DateTime.ParseExact(toyear, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);

            dp조회일자.Text = "";

            Grant.CanAdd = false;
            Grant.CanSave = false;
            Grant.CanDelete = false;
            Grant.CanPrint = false;

            //this.DataChanged += new EventHandler(Page_DataChanged);

            InitGrid();
        }

        #endregion

        #region -> InitGrid

        private void InitGrid()
        {
            //DETAIL
            //merge 기능을 위해서 row 2 설정
            _flexM.BeginSetting(1, 1, false);
            _flexD.BeginSetting(1, 1, false);

            //_flexM.SxetCol("S", "선택", 35, true, CheckTypeEnum.Y_N);

            _flexM.SetCol("CD_PARTNER", "거래처코드", 80, false);
            _flexM.SetCol("LN_PARTNER", "거래처명", 150, false);
            _flexM.SetCol("NO_COMPANY", "사업자번호", 100, false);
            //_flexM.SetCol("AM_DOCU_PRE", "전기(월)이월", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("AM_DOCU", "매출액", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("AM_BAN", "수금액", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("AM_REMAIN", "잔액", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);

            _flexM.SetCol("CD_DEPT", "부서코드", 60, false);
            _flexM.SetCol("NM_DEPT", "부서명", 100, false);
            _flexM.SetCol("TP_INDEX", "연체여부", 60, false);

            _flexM.SetCol("NO_DOCU", "전표번호", 0, false);
            _flexM.SetCol("NO_DOLINE", "라인번호", 0, false);

            _flexM.SetCol("AM_SET1", "근저당", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("AM_SET2", "공정증서", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("AM_SET3", "이행보증보험", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("AM_SET4", "연대보증", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("AM_SET5", "채권양도", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("AM_SET6", "상환계획서(합의서)", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("AM_SET7", "기타", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);

            _flexM.Cols["CD_PARTNER"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["CD_DEPT"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["CD_PARTNER"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["CD_DEPT"].TextAlign = TextAlignEnum.CenterCenter;

            _flexM.Cols["NO_COMPANY"].Format = _flexM.Cols["NO_COMPANY"].EditMask = "###-##-#####";
            _flexM.Cols["NO_COMPANY"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.SetStringFormatCol("NO_COMPANY");
            _flexM.SetNoMaskSaveCol("NO_COMPANY");

            //_flexM.Cols["NO_DOCU"].TextAlign = TextAlignEnum.CenterCenter;
            //_flexM.Cols.Frozen = 1;

            _flexM.SettingVersion = "1.0.1.3";// new Random().Next().ToString();
            _flexM.EndSetting(GridStyleEnum.Green, AllowSortingEnum.MultiColumn, SumPositionEnum.Top);

            //_flexM.SetCodeHelpCol("CD_DEPT", HelpID.P_MA_DEPT_SUB, ShowHelpEnum.Always, new string[] { "CD_DEPT", "NM_DEPT" }, new string[] { "CD_DEPT", "NM_DEPT" }, ResultMode.FastMode);
            //_flexM.SetCodeHelpCol("AY_AGENCYNO", HelpID.P_MA_PARTNER_SUB, ShowHelpEnum.Always, new string[] { "AY_AGENCYNO", "AY_AGENCYID", "AY_AGENCYNM" }, new string[] { "NO_COMPANY", "CD_PARTNER", "LN_PARTNER" }, ResultMode.FastMode);

            //_flexM.StartEdit += new RowColEventHandler(_flexM_StartEdit);
            _flexM.AfterRowChange += new RangeEventHandler(_flexM_AfterRowChange);
            //_flexM.HelpClick += new EventHandler(_flexM_HelpClick);
            //_flexM.AfterEdit += new RowColEventHandler(_flexM_AfterEdit);
            //_flexM.BeforeCodeHelp += new BeforeCodeHelpEventHandler(_flexM_BeforeCodeHelp);
            //_flexM.OwnerDrawCell += new OwnerDrawCellEventHandler(_flexM_OwnerDrawCell);

            _flexD.SetCol("NO_DOCU", "전표번호", 120, false);
            _flexD.SetCol("NO_DOLINE", "라인번호", 60, false);
            _flexD.SetCol("DT_BANACCT", "일자", 100, false, typeof(string), FormatTpType.YEAR_MONTH_DAY);
            _flexD.SetCol("AM_BAN", "반제액", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);

            _flexD.Cols["NO_DOCU"].TextAlign = TextAlignEnum.CenterCenter;
            _flexD.Cols["NO_DOLINE"].TextAlign = TextAlignEnum.CenterCenter;
            _flexD.Cols["DT_BANACCT"].TextAlign = TextAlignEnum.CenterCenter;

            _flexD.SettingVersion = "1.0.1.3";// new Random().Next().ToString();
            _flexD.EndSetting(GridStyleEnum.Green, AllowSortingEnum.MultiColumn, SumPositionEnum.Top);
        }

        #endregion

        #region -> InitPaint

        protected override void InitPaint()
        {
            base.InitPaint();

            UGrant grant = new UGrant();

            //grant.GrantButtonVisible(Global.MainFrame.CurrentPageID, "btn전표일괄처리", btn전표일괄처리);
            try
            {
                SetControl set = new SetControl();

                set.SetCombobox(cbo조회구분, MA.GetCodeUser(new string[] { "", "1", "2" }, new string[] { DD("전체"), DD("미결"), DD("연체") }));
                set.SetCombobox(cbo거래처합산, MA.GetCodeUser(new string[] { "", "1" }, new string[] { DD("미합산"), DD("합산") }));

                //콤보박스 셋팅
                //_flexM.SetDataMap("cd_acct", MA.GetCode("CZ_ME_C008"), "CODE", "NAME");
            }
            catch (Exception ex)
            {
                this.MsgEnd(ex);
            }
        }

        #endregion

        #endregion

        #region ♥ 메인버튼 클릭

        #region -> 조회버튼클릭

        public void searchNo_M()
        {
            try
            {
                string strDz = "";  //회계기준

                if (_flexM.DataTable != null)
                    _flexM.DataTable.Rows.Clear();

                object[] Params = new object[9];
                Params[0] = LoginInfo.CompanyCode;
                Params[1] = "BALANCE_M";
                Params[2] = dt기간.StartDate.ToString("yyyyMMdd");  //조회연월 FROM
                Params[3] = dt기간.EndDate.ToString("yyyyMMdd"); //조회연월 TO
                Params[4] = dp조회일자.Text; //조회일자
                Params[5] = MULTI_CD_CORP.QueryWhereIn_Pipe; //거래처
                Params[6] = MULTI_CD_DEPT.QueryWhereIn_Pipe;   //부서
                Params[7] = cbo조회구분.SelectedValue; //cbo조회구분
                Params[8] = cbo거래처합산.SelectedValue; //cbo거래처합산ID

                DataSet ds = _biz.Search_M(Params);

                _flexM.Binding = ds.Tables[0];
                _flexM.AcceptChanges();
            }
            catch (Exception ex)
            {
                this.MsgEnd(ex);
            }
        }

        public void searchNo_D()
        {
            try
            {
                string strDz = "";  //회계기준

                if (_flexD.DataTable != null)
                    _flexD.DataTable.Rows.Clear();

                object[] Params = new object[11];
                Params[0] = LoginInfo.CompanyCode;
                Params[1] = "BALANCE_D";
                Params[2] = dt기간.StartDate.ToString("yyyyMMdd");  //조회연월 FROM
                Params[3] = dt기간.EndDate.ToString("yyyyMMdd"); //조회연월 TO
                Params[4] = dp조회일자.Text; //조회일자
                Params[5] = MULTI_CD_CORP.QueryWhereIn_Pipe; //거래처
                Params[6] = MULTI_CD_DEPT.QueryWhereIn_Pipe;   //부서
                Params[7] = cbo조회구분.SelectedValue; //cbo조회구분
                Params[8] = cbo거래처합산.SelectedValue; //cbo거래처합산ID
                Params[9] = _flexM[_flexM.Row, "NO_DOCU"].ToString(); 
                Params[10] = _flexM[_flexM.Row, "NO_DOLINE"].ToString(); 

                DataSet ds1 = _biz.Search_M(Params);

                _flexD.Binding = ds1.Tables[0];
                _flexD.AcceptChanges();
            }
            catch (Exception ex)
            {
                this.MsgEnd(ex);
            }
        }

        public override void OnToolBarSearchButtonClicked(object sender, EventArgs e)
        {
            searchNo_M();
            //searchNo_D();
        }

        #endregion

        protected bool BeforeSaveChk()
        {
            if (!_flexM.HasNormalRow)
            {
                ShowMessage("저장할 내용이 없습니다.");
                return false;
            }

            if (!_flexM.Verify())
                return false;

            return true;
        }

        #endregion

        protected override bool SaveData()
        {
            object obj = null;

            if (_flexM.HasNormalRow)
            {
                //DataRow[] ldrchk = _flexM.DataTable.Select("S = 'Y'", "", DataViewRowState.CurrentRows);

                DataTable dt = _flexM.DataTable;

                if (ShowMessage("저장 하시겠습니까?", "QY2") == DialogResult.Yes)
                {
                    obj = _biz.Save(dt, _타메뉴호출);
                }
            }

            return true;
        }

        #region -> 저장버튼클릭

        public override void OnToolBarSaveButtonClicked(object sender, EventArgs e)
        {
            try
            {
                if (!BeforeSaveChk())
                    return;

                _타메뉴호출 = false;

                if (SaveData())
                {
                    ShowMessage(PageResultMode.SaveGood);
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }

        }

        #endregion

        #region ♥ 기타 이벤트

        #region -> Control_QueryBefore

        private void Control_QueryBefore(object sender, Duzon.Common.BpControls.BpQueryArgs e)
        {
            BpCodeTextBox bp_Control = sender as BpCodeTextBox;
            try
            {
                switch (e.ControlName)
                {
                    case "ctxMEDIAGR":  //매체
                        e.HelpParam.IsRequireSearchKey = true;
                        break;

                    case "ctxPARTNER":   //사업자
                        e.HelpParam.IsRequireSearchKey = true;
                        break;

                }
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }

        private void MULTI_CD_CORP_QueryBefore(object sender, BpQueryArgs e)
        {
            MULTI_CD_CORP.UserParams = "매체 도움창;H_CZ_ME_GR;" + MULTI_CD_CORP.CodeNames + ";";
        }

        private void MULTI_CD_DEPT_QueryBefore(object sender, BpQueryArgs e)
        {
            MULTI_CD_DEPT.UserParams = "부서 도움창;H_CZ_ME_DEPT;" + MULTI_CD_DEPT.CodeNames + ";";
        }

        void _flexM_AfterRowChange(object sender, RangeEventArgs e)
        {
            try 
            {
                string 전표번호 = D.GetString(_flexM["NO_DOCU"]);
                string 라인번호 = D.GetString(_flexM["NO_DOLINE"]);

                if (_flexD.DataTable != null)
                    _flexD.DataTable.Rows.Clear();

                if (cbo거래처합산.SelectedValue.Equals("1"))
                    return;

                object[] Params = new object[11];
                Params[0] = LoginInfo.CompanyCode;
                Params[1] = "BALANCE_D";
                Params[2] = dt기간.StartDate.ToString("yyyyMMdd");  //조회연월 FROM
                Params[3] = dt기간.EndDate.ToString("yyyyMMdd"); //조회연월 TO
                Params[4] = dp조회일자.Text; //조회일자
                Params[5] = MULTI_CD_CORP.QueryWhereIn_Pipe; //거래처
                Params[6] = MULTI_CD_DEPT.QueryWhereIn_Pipe;   //부서
                Params[7] = cbo조회구분.SelectedValue; //cbo조회구분
                Params[8] = cbo거래처합산.SelectedValue; //cbo거래처합산ID
                Params[9] = 전표번호;
                Params[10] = 라인번호;

                DataSet ds1 = _biz.Search_M(Params);

                _flexD.Binding = ds1.Tables[0];
            } 
            catch (Exception ex)
            {
                this.MsgEnd(ex);
            }
        }

        #endregion

        #endregion

        #region ♥ 기타 Property
        string ServerKey { get { return Global.MainFrame.ServerKeyCommon.ToUpper(); } }
        #endregion

        public static class StaticClass
        {
            public static int Count = 0;
        }

        /*
        private void btn상세검색_Click_1(object sender, EventArgs e)
        {
            try
            {
                foreach (Form openForm in Application.OpenForms)
                {
                    if (openForm.Name == "P_CZ_ME_SALES_SUB") // 열린 폼의 이름 검사
                    {
                        openForm.Activate();
                        return;
                    }
                }

                P_CZ_ME_SALES_SUB sub = new P_CZ_ME_SALES_SUB();		//WinForm 생성
                sub.TextSendEvent += new P_CZ_ME_SALES_SUB.Form2_EventHandler(frm2_getTextEvent);
                sub.Show();
            }
            catch (Exception ex)
            {
                this.MsgEnd(ex);
            }
        }
        */
        /*
        void frm2_getTextEvent(string strSearchFrom, string strSearchTo, string strCampaign, string strAgent, string strAccount, string strAgency, string strAgencyMonthFrom, string strAgencyMonthTo, string strdoAgency, string strDept, string strCorp, string strCorpMonthFrom, string strCorpMonthTo, string strdoCorp, string strCorpGubun, string strAgent_Amt_From, string strAgent_Amt_To, string strAgency_Amt_From, string strAgency_Amt_To, string strMezzo_Amt_From, string strMezzo_Amt_To, string strCorp_Amt_From, string strCorp_Amt_To, string strAgencyDoc, string strMediaDoc, string strAgencyTax, string strMediaTax, string strClosed, string strStatus)
        {
            // 값을 넘겨 받아서 실제 처리할 함수
            //string CurrentData = strAgency; // Form2 에서 넘겨받는 값
            searchNo(strSearchFrom, strSearchTo, strCampaign, strAgent, strAccount, strAgency, strAgencyMonthFrom, strAgencyMonthTo, strdoAgency, strDept, strCorp, strCorpMonthFrom, strCorpMonthTo, strdoCorp, strCorpGubun, strAgent_Amt_From, strAgent_Amt_To, strAgency_Amt_From, strAgency_Amt_To, strMezzo_Amt_From, strMezzo_Amt_To, strCorp_Amt_From, strCorp_Amt_To, strAgencyDoc, strMediaDoc, strAgencyTax, strMediaTax, strClosed, strStatus);

            //숫자정렬
            int j = 1;
            for (int i = _flexM.Rows.Fixed + 2; i < _flexM.Rows.Count; i++)
            {
                _flexM[i, 0] = j;
                j++;
            }
        }
        */
    }
}