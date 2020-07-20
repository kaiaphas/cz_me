﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;
using Dass.FlexGrid;
using Duzon.Common.BpControls;
using Duzon.Common.Forms;
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
    public partial class P_CZ_ME_SALES : PageBase
    {
        #region ♥ 멤버필드

        private P_CZ_ME_SALES_BIZ _biz = new P_CZ_ME_SALES_BIZ();
        

        #endregion

        #region ♥ 초기화

        #region -> 생성자

        public P_CZ_ME_SALES()
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
            toyear = today.Substring(0, 6);

            Grant.CanAdd = false;
            Grant.CanSearch = false;
            Grant.CanPrint = false;

            this.DataChanged += new EventHandler(Page_DataChanged);

            InitGrid();
        }

        #endregion

        #region -> InitGrid

        private void InitGrid()
        {
            //HEADER
            _flexM.BeginSetting(2, 1, false);

            _flexM.SetCol("S", "S", 35, true, CheckTypeEnum.Y_N);

            _flexM.SetCol("actyear", "매출월", 60, true);
            _flexM.SetCol("CD_ACCT", "계정과목", 130, true);
            _flexM.SetCol("cpid", "캠페인ID", 0, false);
            _flexM.SetCol("cpname", "캠페인명", 130, false);
            _flexM.SetCol("req_no", "고유번호", 0, false);

            //대행사
            _flexM.SetCol("yearmonth", "월", 60, false);
            _flexM.SetCol("trade_type_d", "기준", 40, false); 
            _flexM.SetCol("biz_no_d", "사업자번호", 90, false);
            _flexM.SetCol("agencyid", "ID", 0, false);
            _flexM.SetCol("corpname_d", "명칭", 130, false); 
            
            //매체
            _flexM.SetCol("yearmonth2", "월", 60, false);
            _flexM.SetCol("trade_type_m", "기준", 40, false); 
            _flexM.SetCol("biz_no_m", "사업자번호", 90, false);
            _flexM.SetCol("corpid", "ID", 0, false);
            _flexM.SetCol("corpname_m", "명칭", 130, false); 
            _flexM.SetCol("NM_MEDIAGR", "구분", 60, false);

            _flexM.SetCol("teamid", "팀ID", 0, false);
            _flexM.SetCol("teamname", "팀", 100, false);
            _flexM.SetCol("budget", "광고수주액", 100, false, typeof(decimal), FormatTpType.MONEY);
            _flexM.SetCol("agy_price", "대행사수수료", 100, false, typeof(decimal), FormatTpType.FOREIGN_UNIT_COST);
            _flexM.SetCol("income", "영업수익(매출)", 100, false, typeof(decimal), FormatTpType.EXCHANGE_RATE); //내수액임, 전체금액 확인
            _flexM.SetCol("corp_amt", "매체수익", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY); 
            _flexM.SetCol("agentid", "광고주ID", 0, false);
            _flexM.SetCol("agentname", "광고주", 80, false);
            _flexM.SetCol("sales_etc", "수정일시", 0, false); //DT_UPDATE로 수정
             
            _flexM.SetCol("closed", "마감구분", 60, false); 
            _flexM.SetCol("status", "수정구분", 60, false);

            //대행사 전표정보
            _flexM.SetCol("S1", "S", 35, true, CheckTypeEnum.Y_N);
            _flexM.SetCol("DOCU_TYPE_D", "전표유형", 0, false);
            _flexM.SetCol("DOCU_NO_D", "전표번호", 100, false);
            _flexM.SetCol("PUB_YN", "", 0, false);
            _flexM.SetCol("SALES_TAX_ALL", "", 0, false);
            _flexM.SetCol("SALES_TAX_D", "세금계산서", 100, false);

            //매체 전표정보
            _flexM.SetCol("S2", "S", 35, true, CheckTypeEnum.Y_N);
            _flexM.SetCol("DOCU_TYPE_M", "전표유형", 0, false);
            _flexM.SetCol("DOCU_NO_M", "전표번호", 100, false);
            _flexM.SetCol("SALES_TAX_M", "세금계산서", 100, false);

            //비고
            _flexM.SetCol("SALES_CONTENT", "내용", 200, false);
            _flexM.SetCol("ID_UPDATE", "등록(수정)자", 0, false);
            _flexM.SetCol("DT_UPDATE", "등록(수정)일시", 0, false);
            
            //정렬
            _flexM.Cols["actyear"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["CD_ACCT"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["cpid"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["cpname"].TextAlign = TextAlignEnum.LeftCenter;
            _flexM.Cols["req_no"].TextAlign = TextAlignEnum.CenterCenter;

            _flexM.Cols["yearmonth"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["trade_type_d"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["biz_no_d"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["agencyid"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["corpname_d"].TextAlign = TextAlignEnum.LeftCenter;

            _flexM.Cols["yearmonth2"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["trade_type_m"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["biz_no_m"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["corpid"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["corpname_m"].TextAlign = TextAlignEnum.LeftCenter;
            _flexM.Cols["NM_MEDIAGR"].TextAlign = TextAlignEnum.CenterCenter;

            _flexM.Cols["teamid"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["teamname"].TextAlign = TextAlignEnum.LeftCenter;

            _flexM.Cols["budget"].TextAlign = TextAlignEnum.RightCenter;
            _flexM.Cols["budget"].Format = "###,###,###,##0;(###,###,###,##0)";

            _flexM.Cols["agy_price"].TextAlign = TextAlignEnum.RightCenter;
            _flexM.Cols["agy_price"].Format = "###,###,###,##0;(###,###,###,##0)";

            _flexM.Cols["income"].TextAlign = TextAlignEnum.RightCenter;
            _flexM.Cols["income"].Format = "###,###,###,##0;(###,###,###,##0)";

            _flexM.Cols["corp_amt"].TextAlign = TextAlignEnum.RightCenter;
            _flexM.Cols["corp_amt"].Format = "###,###,###,##0;(###,###,###,##0)";

            _flexM.Cols["agentid"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["agentname"].TextAlign = TextAlignEnum.LeftCenter;
            _flexM.Cols["sales_etc"].TextAlign = TextAlignEnum.LeftCenter;
            _flexM.Cols["closed"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["status"].TextAlign = TextAlignEnum.CenterCenter;

            _flexM.Cols["DOCU_TYPE_D"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["DOCU_NO_D"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["PUB_YN"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["SALES_TAX_ALL"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["SALES_TAX_D"].TextAlign = TextAlignEnum.CenterCenter;

            _flexM.Cols["DOCU_TYPE_M"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["DOCU_NO_M"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["SALES_TAX_M"].TextAlign = TextAlignEnum.CenterCenter;

            _flexM.Cols["SALES_CONTENT"].TextAlign = TextAlignEnum.LeftCenter;
            _flexM.Cols["ID_UPDATE"].TextAlign = TextAlignEnum.LeftCenter;
            _flexM.Cols["DT_UPDATE"].TextAlign = TextAlignEnum.CenterCenter;

            ////소계
            //_flexM.SetCol("actyear", "그룹A", true);

            _flexM.SettingVersion = new Random().Next().ToString();
            _flexM.EndSetting(GridStyleEnum.Green, AllowSortingEnum.MultiColumn, SumPositionEnum.None);
            
            //_flexM.SetExceptSumCol("budget");

            _flexM.SetDummyColumn("S");

            //MERGE 처리 대행사
            _flexM[0, "yearmonth"] = _flexM[0, "agency"] = "대행사";
            _flexM[0, "trade_type_d"] = _flexM[0, "agency"] = "대행사";
            _flexM[0, "biz_no_d"] = _flexM[0, "agency"] = "대행사";
            _flexM[0, "agencyid"] = _flexM[0, "agency"] = "대행사";
            _flexM[0, "corpname_d"] = _flexM[0, "agency"] = "대행사";

            //MERGE 처리 매체
            _flexM[0, "yearmonth2"] = _flexM[0, "agent"] = "매체";
            _flexM[0, "trade_type_m"] = _flexM[0, "agent"] = "매체";
            _flexM[0, "biz_no_m"] = _flexM[0, "agent"] = "매체";
            _flexM[0, "corpid"] = _flexM[0, "agent"] = "매체";
            _flexM[0, "corpname_m"] = _flexM[0, "agent"] = "매체";
            _flexM[0, "NM_MEDIAGR"] = _flexM[0, "agent"] = "매체";

            //MERGE 대행사 전표정보
            _flexM[0, "DOCU_TYPE_D"] = _flexM[0, "agency_docu"] = "대행사 전표정보";
            _flexM[0, "DOCU_NO_D"] = _flexM[0, "agency_docu"] = "대행사 전표정보";
            _flexM[0, "PUB_YN"] = _flexM[0, "agency_docu"] = "대행사 전표정보";
            _flexM[0, "SALES_TAX_ALL"] = _flexM[0, "agency_docu"] = "대행사 전표정보";
            _flexM[0, "SALES_TAX_D"] = _flexM[0, "agency_docu"] = "대행사 전표정보";

            //MERGE 매체 전표정보
            _flexM[0, "DOCU_TYPE_M"] = _flexM[0, "agent_docu"] = "매체 전표정보";
            _flexM[0, "DOCU_NO_M"] = _flexM[0, "agent_docu"] = "매체 전표정보";
            _flexM[0, "SALES_TAX_M"] = _flexM[0, "agent_docu"] = "매체 전표정보";

            //비고
            _flexM[0, "SALES_CONTENT"] = _flexM[0, "sales_etc"] = "비고";
            _flexM[0, "ID_UPDATE"] = _flexM[0, "sales_etc"] = "비고";
            _flexM[0, "DT_UPDATE"] = _flexM[0, "sales_etc"] = "비고";
            
            _flexM.Cols.Frozen = 1;

            _flexM.OwnerDrawCell += new OwnerDrawCellEventHandler(_flexM_OwnerDrawCell);
            
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

            try
            {
                //콤보박스 셋팅
                _flexM.SetDataMap("CD_ACCT", MA.GetCode("CZ_ME_C008"), "CODE", "NAME");

                //상세검색창 
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

        #endregion

        #endregion

        #region ♥ 메인버튼 클릭

        #region -> 조회버튼클릭

        public void searchNo(string strSearchFrom, string strSearchTo, string strCampaign, string strAgent, string strAccount, string strAgency, string strAgencyMonthFrom, string strAgencyMonthTo, string strdoAgency, string strDept, string strCorp, string strCorpMonthFrom, string strCorpMonthTo, string strdoCorp, string strCorpGubun, string strAgent_Amt_From, string strAgent_Amt_To, string strAgency_Amt_From, string strAgency_Amt_To, string strMezzo_Amt_From, string strMezzo_Amt_To, string strCorp_Amt_From, string strCorp_Amt_To, string strAgencyDoc, string strMediaDoc, string strAgencyTax, string strMediaTax, string strClosed, string strStatus)
        {
            try
            {
                string strDz = "";  //회계기준

                if (_flexM.DataTable != null)
                    _flexM.DataTable.Rows.Clear();

                object[] Params = new object[31];
                Params[0] = LoginInfo.CompanyCode;
                Params[1] = strDz;
                Params[2] = strSearchFrom;  //조회연월 FROM
                Params[3] = strSearchTo;    //조회연월 TO
                Params[4] = strCampaign;    //캠페인명
                Params[5] = strAccount; //계정과목
                Params[6] = strAgent;   //광고주
                Params[7] = strAgency; //대행사ID
                Params[8] = strAgencyMonthFrom; //대행사월FROM
                Params[9] = strAgencyMonthTo; //대행사월TO
                Params[10] = strdoAgency; //대행사기준
                Params[11] = strDept; //부서
                Params[12] = strCorp; //매체
                Params[13] = strCorpMonthFrom; //매체월FROM
                Params[14] = strCorpMonthTo; //매체월TO
                Params[15] = strdoCorp; //매체기준
                Params[16] = strCorpGubun; //매체구분
                Params[17] = strAgent_Amt_From; //광고수주액FROM
                Params[18] = strAgent_Amt_To; //광고수주액TO
                Params[19] = strAgency_Amt_From; //대행사수수료FROM
                Params[20] = strAgency_Amt_To; //대행사수수료TO
                Params[21] = strMezzo_Amt_From; //영업이익FROM
                Params[22] = strMezzo_Amt_To; //영업이익TO
                Params[23] = strCorp_Amt_From; //매체수익FROM
                Params[24] = strCorp_Amt_To; //매체수익TO
                Params[25] = strAgencyDoc; //대행사전표처리
                Params[26] = strMediaDoc; //매체전표처리
                Params[27] = strAgencyTax; //대행사세금계산서
                Params[28] = strMediaTax; //매체세금계산서
                Params[29] = strClosed; //마감구분
                Params[30] = strStatus; //수정구분

                DataSet ds = _biz.Search_M(Params);
                DataTable dt = ds.Tables[0];

                //dt.AcceptChanges();
                _flexM.Binding = dt;
                _flexM.Rows.Frozen = 2;
                _flexM.SetDummyColumn(new string[] { "S"});

                //디지털광고매출
                decimal decBudget_dig = 0;decimal decAgy_price_dig = 0;decimal decIncome_dig = 0;decimal decMedia_price_dig = 0;
                //네트워크광고매출
                decimal decBudget_net = 0; decimal decAgy_price_net = 0; decimal decIncome_net = 0; decimal decMedia_price_net = 0;
                //기타매출
                decimal decBudget_etc = 0; decimal decAgy_price_etc = 0; decimal decIncome_etc = 0; decimal decMedia_price_etc = 0;
                for (int i = _flexM.Rows.Fixed + 2; i < _flexM.Rows.Count; i++)
                {
                    if (_flexM[i, "CD_ACCT"].ToString() == "1")
                    {   decBudget_dig = decBudget_dig + D.GetDecimal(_flexM[i, "budget"]);
                        decAgy_price_dig = decAgy_price_dig + D.GetDecimal(_flexM[i, "agy_price"]);
                        decIncome_dig = decIncome_dig + D.GetDecimal(_flexM[i, "income"]);
                        decMedia_price_dig = decMedia_price_dig + D.GetDecimal(_flexM[i, "corp_amt"]);}
                    if (_flexM[i, "CD_ACCT"].ToString() == "2")
                    {   decBudget_net = decBudget_net + D.GetDecimal(_flexM[i, "budget"]);
                        decAgy_price_net = decAgy_price_net + D.GetDecimal(_flexM[i, "agy_price"]);
                        decIncome_net = decIncome_net + D.GetDecimal(_flexM[i, "income"]);
                        decMedia_price_net = decMedia_price_net + D.GetDecimal(_flexM[i, "corp_amt"]);}
                    if (_flexM[i, "CD_ACCT"].ToString() == "3")
                    {   decBudget_etc = decBudget_etc + D.GetDecimal(_flexM[i, "budget"]);
                        decAgy_price_etc = decAgy_price_etc + D.GetDecimal(_flexM[i, "agy_price"]);
                        decIncome_etc = decIncome_etc + D.GetDecimal(_flexM[i, "income"]);
                        decMedia_price_etc = decMedia_price_etc + D.GetDecimal(_flexM[i, "corp_amt"]);}

                }

                if (_flexM.Rows.Count >= 4)
                {
                    _flexM.Rows[2].AllowEditing = false;
                    _flexM.Rows[3].AllowEditing = false;

                    _flexM.Rows[_flexM.Rows.Count - 1].AllowEditing = false;
                    _flexM.Rows[_flexM.Rows.Count - 2].AllowEditing = false;
                    _flexM.Rows[_flexM.Rows.Count - 3].AllowEditing = false;
                    _flexM.Rows[_flexM.Rows.Count - 4].AllowEditing = false;

                    //디지털광고매출
                    _flexM[_flexM.Rows.Count - 4, "budget"] = decBudget_dig;
                    _flexM[_flexM.Rows.Count - 4, "agy_price"] = decAgy_price_dig;
                    _flexM[_flexM.Rows.Count - 4, "income"] = decIncome_dig;
                    _flexM[_flexM.Rows.Count - 4, "corp_amt"] = decMedia_price_dig;
                    //네트워크광고매출
                    _flexM[_flexM.Rows.Count - 3, "budget"] = decBudget_net;
                    _flexM[_flexM.Rows.Count - 3, "agy_price"] = decAgy_price_net;
                    _flexM[_flexM.Rows.Count - 3, "income"] = decIncome_net;
                    _flexM[_flexM.Rows.Count - 3, "corp_amt"] = decMedia_price_net;

                     //기타매출
                    _flexM[_flexM.Rows.Count - 2, "budget"] = decBudget_etc;
                    _flexM[_flexM.Rows.Count - 2, "agy_price"] = decAgy_price_etc;
                    _flexM[_flexM.Rows.Count - 2, "income"] = decIncome_etc;
                    _flexM[_flexM.Rows.Count - 2, "corp_amt"] = decMedia_price_etc;

                    //총계
                    _flexM[_flexM.Rows.Count - 1, "budget"] = D.GetDecimal(_flexM[_flexM.Rows.Count - 4, "budget"]) + D.GetDecimal(_flexM[_flexM.Rows.Count - 3, "budget"]) + D.GetDecimal(_flexM[_flexM.Rows.Count - 2, "budget"]);
                    _flexM[_flexM.Rows.Count - 1, "agy_price"] = D.GetDecimal(_flexM[_flexM.Rows.Count - 4, "agy_price"]) + D.GetDecimal(_flexM[_flexM.Rows.Count - 3, "agy_price"]) + D.GetDecimal(_flexM[_flexM.Rows.Count - 2, "agy_price"]);
                    _flexM[_flexM.Rows.Count - 1, "income"] = D.GetDecimal(_flexM[_flexM.Rows.Count - 4, "income"]) + D.GetDecimal(_flexM[_flexM.Rows.Count - 3, "income"]) + D.GetDecimal(_flexM[_flexM.Rows.Count - 2, "income"]);
                    _flexM[_flexM.Rows.Count - 1, "corp_amt"] = D.GetDecimal(_flexM[_flexM.Rows.Count - 4, "corp_amt"]) + D.GetDecimal(_flexM[_flexM.Rows.Count - 3, "corp_amt"]) + D.GetDecimal(_flexM[_flexM.Rows.Count - 2, "corp_amt"]);
                }

                if (_flexM.Rows.Count == 8) { _flexM.RemoveViewAll(); }

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
            string strSearchFrom = ""; string strSearchTo = ""; string strCampaign = ""; string strAgent = ""; string strAccount = "";
            string strAgency = "";string strAgencyMonthFrom = "";string strAgencyMonthTo = "";string strdoAgency = "";
            string strDept = "";string strCorp = "";string strCorpMonthFrom = "";string strCorpMonthTo = "";
            string strdoCorp = "";string strCorpGubun = "";
            string strAgent_Amt_From = "";string strAgent_Amt_To = "";
            string strAgency_Amt_From = "";string strAgency_Amt_To = "";
            string strMezzo_Amt_From = "";string strMezzo_Amt_To = "";
            string strCorp_Amt_From = "";string strCorp_Amt_To = "";
            string strAgencyDoc = "";string strMediaDoc = "";string strAgencyTax = "";
            string strMediaTax = "";string strClosed = "";string strStatus = "";

            searchNo(strSearchFrom, strSearchTo, strCampaign, strAgent, strAccount, strAgency, strAgencyMonthFrom, strAgencyMonthTo, strdoAgency, strDept, strCorp, strCorpMonthFrom, strCorpMonthTo, strdoCorp, strCorpGubun, strAgent_Amt_From, strAgent_Amt_To, strAgency_Amt_From, strAgency_Amt_To, strMezzo_Amt_From, strMezzo_Amt_To, strCorp_Amt_From, strCorp_Amt_To, strAgencyDoc, strMediaDoc, strAgencyTax, strMediaTax, strClosed, strStatus);

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

            //if (!_flexD.HasNormalRow)
            //    return false;

            //if (!_flexD.Verify())
            //    return false;
         
            return true;
        }

        #endregion

        protected override bool SaveData()
        {

            object obj = null;

            if (_flexM.HasNormalRow)
            {
                obj = _biz.Save(_flexM.GetChanges());
            }

            return false;
        }

        #region -> 저장버튼클릭

        public override void OnToolBarSaveButtonClicked(object sender, EventArgs e)
        {

            try
            {

                if (!BeforeSaveChk())
                    return;

                
                if (ShowMessage("사원 반영 작업을 진행하시겠습니까?","QY2") == DialogResult.Yes)
                {
                    if (SaveData())
                    {
                        ShowMessage(PageResultMode.SaveGood);
                        {
                            ShowMessage("저장하였습니다.");
                            //_flexM.AllowEditing = true;
                        }
                    }
                    OnToolBarSearchButtonClicked(sender, e);
                    return;
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

        private void _flexM_OwnerDrawCell(object sender, OwnerDrawCellEventArgs e)
        {
            CellRange rg;
            CellStyle csCellstyle = _flexM.Styles.Add("CellStyle");
   
            if (!_flexM.HasNormalRow)
                return;

            if (e.Row < _flexM.Rows.Fixed || e.Col < _flexM.Cols.Fixed)
                return;

            if (D.GetString(_flexM[e.Row, "cpname"]) == "조정 전표" || D.GetString(_flexM[e.Row, "cpname"]) == "디지털광고매출" || D.GetString(_flexM[e.Row, "cpname"]) == "네트워크광고매출" || D.GetString(_flexM[e.Row, "cpname"]) == "기타매출" || D.GetString(_flexM[e.Row, "cpname"]) == "총계")
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
                if (D.GetString(_flexM[e.Row, "actyear"]) != D.GetString(_flexM[e.Row, "yearmonth"]))
                {
                    rg = _flexM.GetCellRange(e.Row, "yearmonth");
                    rg.StyleNew.ForeColor = System.Drawing.Color.Red;
                }

                if (D.GetString(_flexM[e.Row, "actyear"]) != D.GetString(_flexM[e.Row, "yearmonth2"]))
                {
                    rg = _flexM.GetCellRange(e.Row, "yearmonth2");
                    rg.StyleNew.ForeColor = System.Drawing.Color.Red;
                }

                if (D.GetString(_flexM[e.Row, "trade_type_d"]) == "순액")
                {
                    rg = _flexM.GetCellRange(e.Row, "trade_type_d");
                    rg.StyleNew.ForeColor = System.Drawing.Color.Red;
                }

                if (D.GetString(_flexM[e.Row, "trade_type_m"]) == "순액")
                {
                    rg = _flexM.GetCellRange(e.Row, "trade_type_m");
                    rg.StyleNew.ForeColor = System.Drawing.Color.Red;
                }

                if (D.GetDecimal(_flexM[e.Row, "budget"]) < 0)
                {
                    rg = _flexM.GetCellRange(e.Row, "budget");
                    rg.StyleNew.ForeColor = System.Drawing.Color.Red;
                }

                if (D.GetDecimal(_flexM[e.Row, "agy_price"]) < 0)
                {
                    rg = _flexM.GetCellRange(e.Row, "agy_price");
                    rg.StyleNew.ForeColor = System.Drawing.Color.Red;
                }

                if (D.GetDecimal(_flexM[e.Row, "income"]) < 0)
                {
                    rg = _flexM.GetCellRange(e.Row, "income");
                    rg.StyleNew.ForeColor = System.Drawing.Color.Red;
                }

                if (D.GetDecimal(_flexM[e.Row, "corp_amt"]) < 0)
                {
                    rg = _flexM.GetCellRange(e.Row, "corp_amt");
                    rg.StyleNew.ForeColor = System.Drawing.Color.Red;
                }

                if (D.GetString(_flexM[e.Row, "closed"]) == "마감")
                {
                    rg = _flexM.GetCellRange(e.Row, "closed");
                    rg.StyleNew.BackColor = System.Drawing.Color.LightYellow;
                }

                if (D.GetString(_flexM[e.Row, "status"]) == "승인")
                {
                    rg = _flexM.GetCellRange(e.Row, "status");
                    rg.StyleNew.BackColor = System.Drawing.Color.LightYellow;
                }

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

        private void bpc광고주_QueryBefore(object sender, BpQueryArgs e)
        {
            //bpc광고주.UserParams = "광고주 도움창;H_CZ_ME_AGENT;" + bpc광고주.CodeValue + ";";
        }

        public static class StaticClass
        {
            public static int Count = 0;
        }

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

        private void P_CZ_ME_SALES_OwerClosed(object sender, EventArgs e)
        {
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm.Name == "P_CZ_ME_SALES_SUB") // 열린 폼의 이름 검사
                {
                    openForm.Close();
                    return;
                }
            }
        }

    }
}