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
    // 작   성   자 : 이표
    // 재 작  성 일 : 2020-06-16
    // 모   듈   명 : 매출분석
    // 시 스  템 명 : 매출분석
    // 서브시스템명 : 매출분석
    // 페 이 지  명 : 매출분석
    // 프로젝트  명 : CZ_ME_SALES
    // **************************************
    public partial class P_CZ_ME_BOND_CONTENT : PageBase
    {
        #region ♥ 멤버필드

        private P_CZ_ME_BOND_CONTENT_BIZ _biz = new P_CZ_ME_BOND_CONTENT_BIZ();
        bool _타메뉴호출 = false;

        #endregion

        #region ♥ 초기화

        #region -> 생성자

        public P_CZ_ME_BOND_CONTENT()
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
            //Grant.CanSave = false;
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

            //_flexM.SetCol("S", "선택", 35, true, CheckTypeEnum.Y_N);

            _flexM.SetCol("ME_YEAR_MONTH", "날짜", 60, false, typeof(string), FormatTpType.YEAR_MONTH_DAY);
            _flexM.SetCol("CORPID", "거래처코드", 80, false);
            _flexM.SetCol("CORPNM", "거래처명", 150, false);
            _flexM.SetCol("CORPNO", "사업자번호", 100, false);
            _flexM.SetCol("CPID", "캠페인코드", 80, false);
            _flexM.SetCol("CPNM", "캠페인명", 150, false);

            _flexM.SetCol("AM_PRE", "시작일", 100, false, typeof(string), FormatTpType.YEAR_MONTH_DAY);
            _flexM.SetCol("AM_PRE", "종료일", 100, false, typeof(string), FormatTpType.YEAR_MONTH_DAY);

            _flexM.SetCol("AM_BUDGET", "매출액", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("AM_AGY_PRICE", "수금액", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("AM_MEDIA_PRICE", "잔액", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);

            _flexM.SetCol("TP_SALES", "여신코드", 0, false);
            _flexM.SetCol("ME_TRADE_TYPE", "여신기일", 70, false);

            _flexM.SetCol("TP_INDEX", "결제예정일", 60, false, typeof(string), FormatTpType.YEAR_MONTH_DAY);
            _flexM.SetCol("ME_SEQ", "종결여부", 100, false);

            _flexM.SetCol("ME_SEQ", "연체일", 100, false);
            _flexM.SetCol("ME_SEQ", "부서코드", 0, false);
            _flexM.SetCol("ME_SEQ", "부서명", 100, false);

            _flexM.SetCol("ME_SEQ", "전표번호", 100, false);
            _flexM.SetCol("ME_SEQ", "전표라인", 120, false);

            _flexM.SetCol("ME_SEQ", "AGING코드", 0, false);
            _flexM.SetCol("ME_SEQ", "AGING", 100, false);

            _flexM.SetCol("ME_SEQ", "연체코드", 0, false);
            _flexM.SetCol("ME_SEQ", "연체개월", 100, false);


            _flexM.Cols["TP_INDEX"].TextAlign = TextAlignEnum.CenterCenter;

            _flexM.Cols["CORPNO"].Format = _flexM.Cols["CORPNO"].EditMask = "###-##-#####";
            _flexM.Cols["CORPNO"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.SetStringFormatCol("CORPNO");
            _flexM.SetNoMaskSaveCol("CORPNO");

            //_flexM.Cols["NO_DOCU"].TextAlign = TextAlignEnum.CenterCenter;

            //_flexM.Cols.Frozen = 1;

            _flexM.SettingVersion = "1.0.0.1";// new Random().Next().ToString();
            _flexM.EndSetting(GridStyleEnum.Green, AllowSortingEnum.MultiColumn, SumPositionEnum.Top);

            //_flexM.SetCodeHelpCol("CD_DEPT", HelpID.P_MA_DEPT_SUB, ShowHelpEnum.Always, new string[] { "CD_DEPT", "NM_DEPT" }, new string[] { "CD_DEPT", "NM_DEPT" }, ResultMode.FastMode);
            //_flexM.SetCodeHelpCol("AY_AGENCYNO", HelpID.P_MA_PARTNER_SUB, ShowHelpEnum.Always, new string[] { "AY_AGENCYNO", "AY_AGENCYID", "AY_AGENCYNM" }, new string[] { "NO_COMPANY", "CD_PARTNER", "LN_PARTNER" }, ResultMode.FastMode);

            //_flexM.StartEdit += new RowColEventHandler(_flexM_StartEdit);
            //_flexM.OwnerDrawCell += new OwnerDrawCellEventHandler(_flexM_OwnerDrawCell);
            //_flexM.HelpClick += new EventHandler(_flexM_HelpClick);
            //_flexM.AfterEdit += new RowColEventHandler(_flexM_AfterEdit);
            //_flexM.BeforeCodeHelp += new BeforeCodeHelpEventHandler(_flexM_BeforeCodeHelp);
            //_flexM.OwnerDrawCell += new OwnerDrawCellEventHandler(_flexM_OwnerDrawCell);
        }

        #endregion


        private void ExecSubTotal()
        {
            // 그룹우선순위기준:A가 더큰 범위이다
            // DB 정렬은 A,B ASC
            // InitGrid는 A,B 순서
            // flex.Unbinding = dt;
            // ExecSubTotal 은 B(XXSUB2),A(XXSUB1)
            // 컬럼명[UserData]
            // 소계: XXSUB1 누계:XXACC1 총계 :XXGRA0

            _flexM.Redraw = false;
            // 금액을 나타낼 컬럼지정

            List<string> sumList = new List<string>();
            sumList.Add("AM_1");// sumList.Add("AM_2");
            SubTotals sts = new SubTotals();
            sts.FirstRow = _flexM.Rows.Fixed+2; //첫 행은 제외하기 위해
            SubTotal st = null;
           
            //소계
            st = sts.NewTotal();
            st.Type = TotalEnum.SubTotal;
            st.GroupCol = _flexM.Cols["actyear"].Index;
            st.TotalColName = sumList.ToArray();
            sts.Add(st);
           
            _flexM.DoSubTotal(sts);
            for (int i = _flexM.Rows.Fixed+2; i < _flexM.Rows.Count; i++)
            {
                //그룹화된 행여부가져오기. true이면 그룹화된 행이다
                if (_flexM.Rows[i].IsNode)
                {
                    //UserData 컬럼에 해당 그룹행 명칭이 지정된다.
                    switch (D.GetString(_flexM.Rows[i].UserData).Substring(0, 6))
                    {
                        case "XXSUB1": 
                            _flexM[i, "actyear"] = "소계월"; 
                        break;
                    }
                }
            }
        }

        #region -> InitPaint

        protected override void InitPaint()
        {
            base.InitPaint();

            UGrant grant = new UGrant();

            //grant.GrantButtonVisible(Global.MainFrame.CurrentPageID, "btn전표일괄처리", btn전표일괄처리);
            try
            {
                SetControl set = new SetControl();

                set.SetCombobox(cbo조회구분, MA.GetCodeUser(new string[] { "", "1", "0" }, new string[] { DD("전체"), DD("마감"), DD("미마감") }));
                //set.SetCombobox(cbo거래처합산, MA.GetCodeUser(new string[] { "", "1", "0" }, new string[] { DD("전체"), DD("합산"), DD("미합산") }));

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

        public void searchNo()
        {
            try
            {
                string strDz = "";  //회계기준

                if (_flexM.DataTable != null)
                    _flexM.DataTable.Rows.Clear();

                object[] Params = new object[1];
                Params[0] = LoginInfo.CompanyCode;

                DataSet ds = _biz.Search_M(Params);

                _flexM.Binding = ds.Tables[0];

                /*
                //디지털광고매출
                decimal decBudget_dig = 0; decimal decAgy_price_dig = 0; decimal decIncome_dig = 0; decimal decMedia_price_dig = 0;
                //네트워크광고매출
                decimal decBudget_net = 0; decimal decAgy_price_net = 0; decimal decIncome_net = 0; decimal decMedia_price_net = 0;
                //기타매출
                decimal decBudget_etc = 0; decimal decAgy_price_etc = 0; decimal decIncome_etc = 0; decimal decMedia_price_etc = 0;

                for (int i = _flexM.Rows.Fixed + 2; i < _flexM.Rows.Count; i++)
                {
                    if (_flexM[i, "cd_acct"].ToString() == "1")
                    {   
                        decBudget_dig = decBudget_dig + D.GetDecimal(_flexM[i, "am_budget"]);
                        decAgy_price_dig = decAgy_price_dig + D.GetDecimal(_flexM[i, "am_agy_price"]);
                        decIncome_dig = decIncome_dig + D.GetDecimal(_flexM[i, "am_income"]);
                        decMedia_price_dig = decMedia_price_dig + D.GetDecimal(_flexM[i, "am_media_price"]);
                    }
                    if (_flexM[i, "cd_acct"].ToString() == "2")
                    {
                        decBudget_net = decBudget_net + D.GetDecimal(_flexM[i, "am_budget"]);
                        decAgy_price_net = decAgy_price_net + D.GetDecimal(_flexM[i, "am_agy_price"]);
                        decIncome_net = decIncome_net + D.GetDecimal(_flexM[i, "am_income"]);
                        decMedia_price_net = decMedia_price_net + D.GetDecimal(_flexM[i, "am_media_price"]);
                    }
                    if (_flexM[i, "cd_acct"].ToString() == "3")
                    {
                        decBudget_etc = decBudget_etc + D.GetDecimal(_flexM[i, "am_budget"]);
                        decAgy_price_etc = decAgy_price_etc + D.GetDecimal(_flexM[i, "am_agy_price"]);
                        decIncome_etc = decIncome_etc + D.GetDecimal(_flexM[i, "am_income"]);
                        decMedia_price_etc = decMedia_price_etc + D.GetDecimal(_flexM[i, "am_media_price"]);
                    }

                }
                */
                /*
                if (_flexM.Rows.Count >= 4)
                {
                    //_flexM.Rows[2].AllowEditing = false;
                    //_flexM.Rows[3].AllowEditing = false;

                    _flexM.Rows[_flexM.Rows.Count - 1].AllowEditing = false;
                    _flexM.Rows[_flexM.Rows.Count - 2].AllowEditing = false;
                    _flexM.Rows[_flexM.Rows.Count - 3].AllowEditing = false;
                    _flexM.Rows[_flexM.Rows.Count - 4].AllowEditing = false;

                    //디지털광고매출
                    _flexM[_flexM.Rows.Count - 4, "am_budget"] = decBudget_dig;
                    _flexM[_flexM.Rows.Count - 4, "am_agy_price"] = decAgy_price_dig;
                    _flexM[_flexM.Rows.Count - 4, "am_income"] = decIncome_dig;
                    _flexM[_flexM.Rows.Count - 4, "am_media_price"] = decMedia_price_dig;
                    //네트워크광고매출
                    _flexM[_flexM.Rows.Count - 3, "am_budget"] = decBudget_net;
                    _flexM[_flexM.Rows.Count - 3, "am_agy_price"] = decAgy_price_net;
                    _flexM[_flexM.Rows.Count - 3, "am_income"] = decIncome_net;
                    _flexM[_flexM.Rows.Count - 3, "am_media_price"] = decMedia_price_net;

                     //기타매출
                    _flexM[_flexM.Rows.Count - 2, "am_budget"] = decBudget_etc;
                    _flexM[_flexM.Rows.Count - 2, "am_agy_price"] = decAgy_price_etc;
                    _flexM[_flexM.Rows.Count - 2, "am_income"] = decIncome_etc;
                    _flexM[_flexM.Rows.Count - 2, "am_media_price"] = decMedia_price_etc;

                    //총계
                    _flexM[_flexM.Rows.Count - 1, "am_budget"] = D.GetDecimal(_flexM[_flexM.Rows.Count - 4, "am_budget"]) + D.GetDecimal(_flexM[_flexM.Rows.Count - 3, "am_budget"]) + D.GetDecimal(_flexM[_flexM.Rows.Count - 2, "am_budget"]);
                    _flexM[_flexM.Rows.Count - 1, "am_agy_price"] = D.GetDecimal(_flexM[_flexM.Rows.Count - 4, "am_agy_price"]) + D.GetDecimal(_flexM[_flexM.Rows.Count - 3, "am_agy_price"]) + D.GetDecimal(_flexM[_flexM.Rows.Count - 2, "am_agy_price"]);
                    _flexM[_flexM.Rows.Count - 1, "am_income"] = D.GetDecimal(_flexM[_flexM.Rows.Count - 4, "am_income"]) + D.GetDecimal(_flexM[_flexM.Rows.Count - 3, "am_income"]) + D.GetDecimal(_flexM[_flexM.Rows.Count - 2, "am_income"]);
                    _flexM[_flexM.Rows.Count - 1, "am_media_price"] = D.GetDecimal(_flexM[_flexM.Rows.Count - 4, "am_media_price"]) + D.GetDecimal(_flexM[_flexM.Rows.Count - 3, "am_media_price"]) + D.GetDecimal(_flexM[_flexM.Rows.Count - 2, "am_media_price"]);
                }
                */
                //if (_flexM.Rows.Count == 8) { _flexM.RemoveViewAll(); }

                //ExecSubTotal();

                _flexM.AcceptChanges();

                SetToolBarButtonState(true, false, false, true, false);
            }
            catch (Exception ex)
            {
                this.MsgEnd(ex);
            }
        }

        public override void OnToolBarSearchButtonClicked(object sender, EventArgs e)
        {
            searchNo();
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

        #endregion

        #endregion

        #region ♥ 기타 Property
        string ServerKey { get { return Global.MainFrame.ServerKeyCommon.ToUpper(); } }
        #endregion

        void Page_DataChanged(object sender, EventArgs e)
        {
            try
            {
                SetToolBarButtonState(true, false, false, true, false);
            }
            catch (Exception ex)
            {
                MsgControl.CloseMsg();
                MsgEnd(ex);
            }
        }

        void _flexM_HelpClick(object sender, EventArgs e)
        {

        }

        private void _flexM_OwnerDrawCell(object sender, OwnerDrawCellEventArgs e)
        {
            CellRange rg;
            CellStyle csCellstyle = _flexM.Styles.Add("CellStyle");
   
            if (!_flexM.HasNormalRow)
                return;

            if (e.Row < _flexM.Rows.Fixed || e.Col < _flexM.Cols.Fixed)
                return;

            //if (D.GetString(_flexM[e.Row, "cpname"]) == "조정 전표" || D.GetString(_flexM[e.Row, "cpname"]) == "디지털광고매출" || D.GetString(_flexM[e.Row, "cpname"]) == "네트워크광고매출" || D.GetString(_flexM[e.Row, "cpname"]) == "기타매출" || D.GetString(_flexM[e.Row, "cpname"]) == "총계")
            if (D.GetString(_flexM[e.Row, "cpname"]) == "조정 전표")
            {
                _flexM[e.Row, 0] = ""; //상단 고정그리드 숫자 지우기

                rg = _flexM.GetCellRange(e.Row, "S");
                rg.StyleNew.Display = DisplayEnum.None;

                rg = _flexM.GetCellRange(e.Row, "S1");
                rg.StyleNew.Display = DisplayEnum.None;

                rg = _flexM.GetCellRange(e.Row, "S2");
                rg.StyleNew.Display = DisplayEnum.None;
            }
            else
            {
                if (D.GetString(_flexM[e.Row, "ay_year"]) != D.GetString(_flexM[e.Row, "ay_year_month"]))
                {
                    rg = _flexM.GetCellRange(e.Row, "ay_year_month");
                    rg.StyleNew.ForeColor = System.Drawing.Color.Red;
                }

                if (D.GetString(_flexM[e.Row, "ay_year"]) != D.GetString(_flexM[e.Row, "me_year_month"]))
                {
                    rg = _flexM.GetCellRange(e.Row, "me_year_month");
                    rg.StyleNew.ForeColor = System.Drawing.Color.Red;
                }

                if (D.GetString(_flexM[e.Row, "ay_trade_type"]) == "순액")
                {
                    rg = _flexM.GetCellRange(e.Row, "ay_trade_type");
                    rg.StyleNew.ForeColor = System.Drawing.Color.Red;
                }

                if (D.GetString(_flexM[e.Row, "me_trade_type"]) == "순액")
                {
                    rg = _flexM.GetCellRange(e.Row, "me_trade_type");
                    rg.StyleNew.ForeColor = System.Drawing.Color.Red;
                }

                if (D.GetDecimal(_flexM[e.Row, "am_budget"]) < 0)
                {
                    rg = _flexM.GetCellRange(e.Row, "am_budget");
                    rg.StyleNew.ForeColor = System.Drawing.Color.Red;
                }

                if (D.GetDecimal(_flexM[e.Row, "am_agy_price"]) < 0)
                {
                    rg = _flexM.GetCellRange(e.Row, "am_agy_price");
                    rg.StyleNew.ForeColor = System.Drawing.Color.Red;
                }

                if (D.GetDecimal(_flexM[e.Row, "am_income"]) < 0)
                {
                    rg = _flexM.GetCellRange(e.Row, "am_income");
                    rg.StyleNew.ForeColor = System.Drawing.Color.Red;
                }

                if (D.GetDecimal(_flexM[e.Row, "am_media_price"]) < 0)
                {
                    rg = _flexM.GetCellRange(e.Row, "am_media_price");
                    rg.StyleNew.ForeColor = System.Drawing.Color.Red;
                }

                if (D.GetString(_flexM[e.Row, "closed"]) == "마감")
                {
                    rg = _flexM.GetCellRange(e.Row, "closed");
                    rg.StyleNew.BackColor = System.Drawing.Color.LightYellow;
                }

                //if (D.GetString(_flexM[e.Row, "status"]) == "승인")
                //{
                //    rg = _flexM.GetCellRange(e.Row, "status");
                //    rg.StyleNew.BackColor = System.Drawing.Color.LightYellow;
                //}

            }

            if (D.GetString(_flexM[e.Row, "cpname"]) == "디지털광고매출")
            {
                csCellstyle.BackColor = System.Drawing.Color.FromArgb(((Byte)(250)), ((Byte)(191)), ((Byte)(143)));
                _flexM.Rows[e.Row].Style = csCellstyle;
            }

            if (D.GetString(_flexM[e.Row, "cpname"]) == "네트워크광고매출")
            {
                csCellstyle.BackColor = System.Drawing.Color.FromArgb(((Byte)(149)), ((Byte)(179)), ((Byte)(215)));
                _flexM.Rows[e.Row].Style = csCellstyle;
            }

            if (D.GetString(_flexM[e.Row, "cpname"]) == "기타매출")
            {
                csCellstyle.BackColor = System.Drawing.Color.FromArgb(((Byte)(177)), ((Byte)(160)), ((Byte)(199)));
                _flexM.Rows[e.Row].Style = csCellstyle;
            }

            if (D.GetString(_flexM[e.Row, "cpname"]) == "총계" )
            {
                csCellstyle.BackColor = System.Drawing.Color.FromArgb(((Byte)(196)), ((Byte)(215)), ((Byte)(155)));
                _flexM.Rows[e.Row].Style = csCellstyle;
            }

            if (D.GetString(_flexM[e.Row, "cpname"]) == "조정 전표")
            {
                csCellstyle.BackColor = System.Drawing.Color.FromArgb(((Byte)(255)), ((Byte)(230)), ((Byte)(230)));
                _flexM.Rows[e.Row].Style = csCellstyle;
            }
        }

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