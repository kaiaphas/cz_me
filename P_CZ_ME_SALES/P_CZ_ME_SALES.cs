﻿using System;
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
    public partial class P_CZ_ME_SALES : PageBase
    {
        #region ♥ 멤버필드

        private P_CZ_ME_SALES_BIZ _biz = new P_CZ_ME_SALES_BIZ();
        bool _타메뉴호출 = false;
        string dt_Syncday = "";
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
            toyear = today.Substring(0, 8);

            dpYear.ShowUpDown = true;
            dpYear.Format = DateTimePickerFormat.Custom;
            dpYear.CustomFormat = "yyyy";
            dpYear.Value = new DateTime(int.Parse(DateTime.Now.ToString("yyyy")), int.Parse(DateTime.Now.ToString("MM")), 1);

            dpMonthFr.ShowUpDown = true;
            dpMonthFr.Format = DateTimePickerFormat.Custom;
            dpMonthFr.CustomFormat = "MM";
            dpMonthFr.Value = new DateTime(int.Parse(DateTime.Now.ToString("yyyy")), int.Parse(DateTime.Now.ToString("MM")), 1);

            dpMonthTo.ShowUpDown = true;
            dpMonthTo.Format = DateTimePickerFormat.Custom;
            dpMonthTo.CustomFormat = "MM";
            dpMonthTo.Value = new DateTime(int.Parse(DateTime.Now.ToString("yyyy")), int.Parse(DateTime.Now.ToString("MM")), 1);

            dp대행사FROM.Text = "";
            dp대행사TO.Text = "";
            dp매체월FROM.Text = "";
            dp매체월TO.Text = "";

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
            //HEADER
            _flexM.BeginSetting(1, 1, false);

            _flexM.SetCol("S", "S", 35, true, CheckTypeEnum.Y_N);

            _flexM.SetCol("tp_sales", "TP_SALES", 0, false);

            _flexM.SetCol("ay_year", "매출월", 60, false, typeof(string), FormatTpType.YEAR_MONTH);
            _flexM.SetCol("cd_acct", "계정과목", 130, true);
            _flexM.SetCol("cpid", "캠페인ID", 0, false);
            _flexM.SetCol("cpname", "캠페인명", 130, false);
            _flexM.SetCol("req_no", "고유번호", 0, false);
            _flexM.SetCol("seq", "매체순번", 0, false);

            _flexM.SetCol("cp_agentno", "광고주사업자번호", 110, false);
            _flexM.SetCol("cp_agentid", "광고주ID", 0, false);
            _flexM.SetCol("cp_agentnm", "광고주", 130, false);

            //대행사
            _flexM.SetCol("ay_year_month", "월", 60, false, typeof(string), FormatTpType.YEAR_MONTH);
            _flexM.SetCol("ay_trade_type", "기준", 40, false);
            _flexM.SetCol("ay_agencyno", "사업자번호", 90, false);
            _flexM.SetCol("ay_agencyid", "ID", 0, false);
            _flexM.SetCol("ay_agencynm", "명칭", 130, false);

            //매체
            _flexM.SetCol("me_year_month", "월", 60, false, typeof(string), FormatTpType.YEAR_MONTH);
            _flexM.SetCol("me_trade_type", "기준", 40, false);
            _flexM.SetCol("me_corpno", "사업자번호", 90, false);
            _flexM.SetCol("me_corpid", "ID", 0, false);
            _flexM.SetCol("me_corpnm", "명칭", 130, false);
            _flexM.SetCol("nm_mediagr", "구분", 60, false);

            _flexM.SetCol("me_teamid", "팀ID", 0, false);
            _flexM.SetCol("me_teamnm", "팀", 100, false);
            _flexM.SetCol("am_budget", "광고수주액", 100, false, typeof(decimal), FormatTpType.MONEY);
            _flexM.SetCol("am_agy_price", "대행사수수료", 100, false, typeof(decimal), FormatTpType.MONEY);
            _flexM.SetCol("am_income", "영업수익(매출)", 100, false, typeof(decimal), FormatTpType.MONEY); //내수액임, 전체금액 확인
            _flexM.SetCol("am_media_price", "매체수익", 100, false, typeof(decimal), FormatTpType.MONEY);
            _flexM.SetCol("am_fee_all", "수익", 0, false, typeof(decimal), FormatTpType.MONEY);

            _flexM.SetCol("me_sumcode", "합산매체", 0, false);
            //_flexM.SetCol("sales_etc", "수정일시", 0, false); //DT_UPDATE로 수정

            //_flexM.SetCol("closed", "마감구분", 60, false); 
            //_flexM.SetCol("status", "수정구분", 60, false);

            //대행사 전표정보
            _flexM.SetCol("S1", "S1", 35, true, CheckTypeEnum.Y_N);
            _flexM.SetCol("no_docu_m", "전표번호", 100, false);
            _flexM.SetCol("sales_tax_m", "세금계산서", 100, false);

            //매체 전표정보
            _flexM.SetCol("S2", "S2", 35, true, CheckTypeEnum.Y_N);
            _flexM.SetCol("no_docu_d", "전표번호", 100, false);
            _flexM.SetCol("sales_tax_d", "세금계산서", 100, false);

            //비고
            _flexM.SetCol("nm_note", "내용", 200, true);

            //원대행사
            //_flexM.SetCol("ay_agencyid_ori", "원대행사", 0, false);
            _flexM.SetCol("ay_agencynm_ori", "원대행사", 120, false);
            _flexM.SetCol("req_no_idx", "이월구분", 60, false);

            //정렬
            _flexM.Cols["ay_year"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["cd_acct"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["cpid"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["cpname"].TextAlign = TextAlignEnum.LeftCenter;
            _flexM.Cols["req_no"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["cp_agentno"].TextAlign = TextAlignEnum.CenterCenter;

            _flexM.Cols["ay_year_month"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["ay_trade_type"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["ay_agencyno"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["ay_agencyid"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["ay_agencynm"].TextAlign = TextAlignEnum.LeftCenter;

            _flexM.Cols["me_year_month"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["me_trade_type"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["me_corpno"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["me_corpid"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["me_corpnm"].TextAlign = TextAlignEnum.LeftCenter;
            _flexM.Cols["nm_mediagr"].TextAlign = TextAlignEnum.CenterCenter;

            _flexM.Cols["me_teamid"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["me_teamnm"].TextAlign = TextAlignEnum.LeftCenter;

            _flexM.Cols["am_budget"].TextAlign = TextAlignEnum.RightCenter;
            _flexM.Cols["am_budget"].Format = "###,###,###,##0;(###,###,###,##0)";

            _flexM.Cols["am_agy_price"].TextAlign = TextAlignEnum.RightCenter;
            _flexM.Cols["am_agy_price"].Format = "###,###,###,##0;(###,###,###,##0)";

            _flexM.Cols["am_income"].TextAlign = TextAlignEnum.RightCenter;
            _flexM.Cols["am_income"].Format = "###,###,###,##0;(###,###,###,##0)";

            _flexM.Cols["am_media_price"].TextAlign = TextAlignEnum.RightCenter;
            _flexM.Cols["am_media_price"].Format = "###,###,###,##0;(###,###,###,##0)";

            _flexM.Cols["cp_agentid"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["cp_agentnm"].TextAlign = TextAlignEnum.LeftCenter;
            //_flexM.Cols["sales_etc"].TextAlign = TextAlignEnum.LeftCenter;
            //_flexM.Cols["closed"].TextAlign = TextAlignEnum.CenterCenter;

            _flexM.Cols["no_docu_m"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["no_docu_d"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["sales_tax_m"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["sales_tax_d"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["req_no_idx"].TextAlign = TextAlignEnum.CenterCenter;

            //_flexM.Cols["status"].TextAlign = TextAlignEnum.CenterCenter;

            //_flexM.Cols["DOCU_TYPE_D"].TextAlign = TextAlignEnum.CenterCenter;
            //_flexM.Cols["DOCU_NO_D"].TextAlign = TextAlignEnum.CenterCenter;
            //_flexM.Cols["PUB_YN"].TextAlign = TextAlignEnum.CenterCenter;
            //_flexM.Cols["SALES_TAX_ALL"].TextAlign = TextAlignEnum.CenterCenter;


            //_flexM.Cols["DOCU_TYPE_M"].TextAlign = TextAlignEnum.CenterCenter;
            //_flexM.Cols["DOCU_NO_M"].TextAlign = TextAlignEnum.CenterCenter;

            //_flexM.Cols["SALES_CONTENT"].TextAlign = TextAlignEnum.LeftCenter;
            //_flexM.Cols["ID_UPDATE"].TextAlign = TextAlignEnum.LeftCenter;
            //_flexM.Cols["DT_UPDATE"].TextAlign = TextAlignEnum.CenterCenter;

            ////소계
            //_flexM.SetCol("actyear", "그룹A", true);

            //그리드 셀 병합
            _flexM.Cols["tp_sales"].AllowMerging = false;
            _flexM.Cols["ay_year"].AllowMerging = false;
            _flexM.Cols["cd_acct"].AllowMerging = false;
            _flexM.Cols["cpid"].AllowMerging = false;
            _flexM.Cols["cpname"].AllowMerging = false;
            _flexM.Cols["req_no"].AllowMerging = false;
            _flexM.Cols["seq"].AllowMerging = false;
            _flexM.Cols["cp_agentno"].AllowMerging = false;
            _flexM.Cols["cp_agentid"].AllowMerging = false;
            _flexM.Cols["cp_agentnm"].AllowMerging = false;
            _flexM.Cols["ay_year_month"].AllowMerging = false;
            _flexM.Cols["ay_trade_type"].AllowMerging = false;
            _flexM.Cols["ay_agencyno"].AllowMerging = false;
            _flexM.Cols["ay_agencyid"].AllowMerging = false;
            _flexM.Cols["ay_agencynm"].AllowMerging = false;
            _flexM.Cols["me_year_month"].AllowMerging = false;
            _flexM.Cols["me_trade_type"].AllowMerging = false;
            _flexM.Cols["me_corpno"].AllowMerging = false;
            _flexM.Cols["me_corpid"].AllowMerging = false;
            _flexM.Cols["me_corpnm"].AllowMerging = false;
            _flexM.Cols["nm_mediagr"].AllowMerging = false;
            _flexM.Cols["me_teamid"].AllowMerging = false;
            _flexM.Cols["me_teamnm"].AllowMerging = false;
            _flexM.Cols["am_budget"].AllowMerging = false;
            _flexM.Cols["am_agy_price"].AllowMerging = false;
            _flexM.Cols["am_income"].AllowMerging = false;
            _flexM.Cols["am_media_price"].AllowMerging = false;
            _flexM.Cols["am_fee_all"].AllowMerging = false;
            _flexM.Cols["me_sumcode"].AllowMerging = false;
            _flexM.Cols["no_docu_m"].AllowMerging = false;
            _flexM.Cols["sales_tax_m"].AllowMerging = false;
            _flexM.Cols["no_docu_d"].AllowMerging = false;
            _flexM.Cols["sales_tax_d"].AllowMerging = false;
            _flexM.Cols["nm_note"].AllowMerging = false;
            _flexM.Cols["ay_agencynm_ori"].AllowMerging = false;
            _flexM.Cols["req_no_idx"].AllowMerging = false;

            _flexM.SettingVersion = new Random().Next().ToString();
            _flexM.EndSetting(GridStyleEnum.Green, AllowSortingEnum.MultiColumn, SumPositionEnum.None);
            _flexM.AllowMerging = AllowMergingEnum.RestrictRows;

            //_flexM.SetExceptSumCol("budget");

            _flexM.SetDummyColumn("S");

            //MERGE 처리 대행사
            //_flexM[0, "ay_year_month"] = _flexM[0, "agency"] = "대행사";
            //_flexM[0, "ay_trade_type"] = _flexM[0, "agency"] = "대행사";
            //_flexM[0, "ay_agencyno"] = _flexM[0, "agency"] = "대행사";
            //_flexM[0, "ay_agencyid"] = _flexM[0, "agency"] = "대행사";
            //_flexM[0, "ay_agencynm"] = _flexM[0, "agency"] = "대행사";

            //MERGE 처리 매체
            //_flexM[0, "me_year_month"] = _flexM[0, "agent"] = "매체";
            //_flexM[0, "me_trade_type"] = _flexM[0, "agent"] = "매체";
            //_flexM[0, "me_corpno"] = _flexM[0, "agent"] = "매체";
            //_flexM[0, "me_corpid"] = _flexM[0, "agent"] = "매체";
            //_flexM[0, "me_corpnm"] = _flexM[0, "agent"] = "매체";
            //_flexM[0, "nm_mediagr"] = _flexM[0, "agent"] = "매체";

            //MERGE 대행사 전표정보
            //_flexM[0, "DOCU_TYPE_D"] = _flexM[0, "agency_docu"] = "대행사 전표정보";
            //_flexM[0, "docu_no_d"] = _flexM[0, "agency_docu"] = "대행사 전표정보";
            //_flexM[0, "PUB_YN"] = _flexM[0, "agency_docu"] = "대행사 전표정보";
            //_flexM[0, "SALES_TAX_ALL"] = _flexM[0, "agency_docu"] = "대행사 전표정보";
            //_flexM[0, "sales_tax_d"] = _flexM[0, "agency_docu"] = "대행사 전표정보";

            //MERGE 매체 전표정보
            //_flexM[0, "DOCU_TYPE_M"] = _flexM[0, "agent_docu"] = "매체 전표정보";
            //_flexM[0, "docu_no_m"] = _flexM[0, "agent_docu"] = "매체 전표정보";
            //_flexM[0, "sales_tax_m"] = _flexM[0, "agent_docu"] = "매체 전표정보";

            //비고
            //_flexM[0, "no_note"] = _flexM[0, "sales_etc"] = "비고";
            //_flexM[0, "id_update"] = _flexM[0, "sales_etc"] = "비고";
            //_flexM[0, "dt_update"] = _flexM[0, "sales_etc"] = "비고";

            _flexM.Cols.Frozen = 1;

            _flexM.HelpClick += new EventHandler(_flexM_HelpClick);
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

            UGrant grant = new UGrant();

            grant.GrantButtonVisible(Global.MainFrame.CurrentPageID, "btn전표일괄처리", btn전표일괄처리);
            //grant.GrantButtonVisible(Global.MainFrame.CurrentPageID, "btn전표일괄취소", btn전표일괄취소);
            grant.GrantButtonVisible(Global.MainFrame.CurrentPageID, "btn전표처리", btn전표처리);
            grant.GrantButtonVisible(Global.MainFrame.CurrentPageID, "btn전표취소", btn전표취소);
            grant.GrantButtonVisible(Global.MainFrame.CurrentPageID, "btn동기화", btn동기화);
            grant.GrantButtonVisible(Global.MainFrame.CurrentPageID, "btn삭제반영", btn삭제반영);
            grant.GrantButtonVisible(Global.MainFrame.CurrentPageID, "btn이월반영", btn이월반영);

            btn계정변경.Click += new EventHandler(btn계정변경_Click);
            btn전표일괄처리.Click += new EventHandler(btn전표일괄처리_Click);
            //btn전표일괄취소.Click += new EventHandler(btn전표일괄취소_Click);

            btn전표처리.Click += new EventHandler(btn전표처리_Click);
            btn전표취소.Click += new EventHandler(btn전표취소_Click);
            btn동기화.Click += new EventHandler(btn동기화_Click);
            btn삭제반영.Click += new EventHandler(btn삭제반영_Click);
            btn이월반영.Click += new EventHandler(btn이월반영_Click);
            dpMonthFr.ValueChanged += new EventHandler(dpMonthFr_ValueChanged);
            dpMonthTo.ValueChanged += new EventHandler(dpMonthTo_ValueChanged);
            chk수정구분.CheckedChanged += new EventHandler(chk수정구분_CheckedChanged);
            try
            {
                SetControl set = new SetControl();

                set.SetCombobox(cbo조정구분, MA.GetCodeUser(new string[] { "", "1" }, new string[] { DD("전체"), DD("조정") }));
                set.SetCombobox(cbo수정구분, MA.GetCodeUser(new string[] { "1", "2" }, new string[] { DD("전체"), DD("수정내역조회") }));

                set.SetCombobox(cbo수수료, MA.GetCodeUser(new string[] { "", "초과", "영", "미만" }, new string[] { DD("전체"), DD("0초과"), DD("0(영)"), DD("0미만") }));
                set.SetCombobox(cbo영업수익, MA.GetCodeUser(new string[] { "", "초과", "영", "미만" }, new string[] { DD("전체"), DD("0초과"), DD("0(영)"), DD("0미만") }));
                set.SetCombobox(cbo매체수익, MA.GetCodeUser(new string[] { "", "초과", "영", "미만" }, new string[] { DD("전체"), DD("0초과"), DD("0(영)"), DD("0미만") }));
                set.SetCombobox(cbo수주액, MA.GetCodeUser(new string[] { "", "초과", "영", "미만" }, new string[] { DD("전체"), DD("0초과"), DD("0(영)"), DD("0미만") }));

                // 전액 1 : 순액 2 : 인보이스 3
                set.SetCombobox(cbo대행사기준, MA.GetCodeUser(new string[] { "", "1", "2", "3" }, new string[] { DD("전체"), DD("전액"), DD("순액"), DD("INVOICE") }));
                set.SetCombobox(cbo대행사발행여부, MA.GetCodeUser(new string[] { "", "Y", "N" }, new string[] { DD("전체"), DD("발행"), DD("미발행") }));
                set.SetCombobox(cbo대행사전표처리, MA.GetCodeUser(new string[] { "", "Y", "N", "X" }, new string[] { DD("전체"), DD("처리"), DD("미처리"), DD("N/A") }));

                set.SetCombobox(cbo매체기준, MA.GetCodeUser(new string[] { "", "1", "2", "3" }, new string[] { DD("전체"), DD("전액"), DD("순액"), DD("INVOICE") }));
                set.SetCombobox(cbo매체발행여부, MA.GetCodeUser(new string[] { "", "Y", "N" }, new string[] { DD("전체"), DD("발행"), DD("미발행") }));
                set.SetCombobox(cbo매체전표처리, MA.GetCodeUser(new string[] { "", "Y", "N", "X" }, new string[] { DD("전체"), DD("처리"), DD("미처리"), DD("N/A") }));

                //콤보박스 셋팅
                _flexM.SetDataMap("cd_acct", MA.GetCode("CZ_ME_C008"), "CODE", "NAME");
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

                object[] Params = new object[28];
                Params[0] = LoginInfo.CompanyCode;
                Params[1] = "1"; //tp_sales
                Params[2] = dpYear.Text + dpMonthFr.Text;  //조회연월 FROM
                Params[3] = dpYear.Text + dpMonthTo.Text; //조회연월 TO
                Params[4] = txt캠페인명.Text; //캠페인명
                Params[5] = MULTI_CD_ACCOUNT.QueryWhereIn_Pipe; //계정과목
                Params[6] = MULTI_CD_AGENT.QueryWhereIn_Pipe;   //광고주
                Params[7] = MULTI_CD_AGENCY.QueryWhereIn_Pipe; //대행사ID
                Params[8] = dp대행사FROM.Text; //대행사월FROM
                Params[9] = dp대행사TO.Text; //대행사월TO
                Params[10] = cbo대행사기준.SelectedValue; //대행사기준
                Params[11] = MULTI_CD_DEPT.QueryWhereIn_Pipe; //부서
                Params[12] = MULTI_CD_CORP.QueryWhereIn_Pipe; //매체
                Params[13] = dp매체월FROM.Text; //매체월FROM
                Params[14] = dp매체월TO.Text; //매체월TO
                Params[15] = cbo매체기준.SelectedValue; //매체기준
                Params[16] = MULTI_CD_MEDIAGR.QueryWhereIn_Pipe; //매체구분
                Params[17] = cbo수주액.SelectedValue; //
                Params[18] = cbo수수료.SelectedValue; //
                Params[19] = cbo영업수익.SelectedValue; //
                Params[20] = cbo매체수익.SelectedValue; //
                Params[21] = cbo대행사전표처리.SelectedValue; //대행사전표처리
                Params[22] = cbo매체전표처리.SelectedValue; //매체전표처리
                Params[23] = cbo대행사발행여부.SelectedValue; //대행사세금계산서
                Params[24] = cbo매체발행여부.SelectedValue; //매체세금계산서
                Params[25] = cbo조정구분.SelectedValue; //마감구분
                Params[26] = cbo수정구분.SelectedValue; //수정구분
                Params[27] = MULTI_CD_AGENCY_ORI.QueryWhereIn_Pipe; //매체구분

                DataSet ds = _biz.Search_M(Params);
                DataTable dt = ds.Tables[0];

                string DT_DATE = dpYear.Text + dpMonthTo.Text;

                DataTable dt2 = _biz.Get결산일시(DT_DATE);
                DataTable dt3 = _biz.Get마감여부(dpYear.Text);
                DataTable dt4 = _biz.Get일괄처리여부(DT_DATE);

                lbl결산일시.Text = "동기화시간 : " + dt2.Rows[0]["DT_CLOSING"].ToString();
                lbl마감여부.Text = dt3.Rows[0]["ST_FLAG"].ToString();
                dt_Syncday = dt2.Rows[0]["DT_CLOSING"].ToString();

                if (dt4.Rows.Count != 0 && dt4.Rows[0]["FLAG"].Equals("1"))
                {
                    btn전표일괄처리.Enabled = false;
                }
                else
                {
                    btn전표일괄처리.Enabled = true;
                }

                //dt.AcceptChanges();
                _flexM.Binding = dt;
                //_flexM.Rows.Frozen = 2;
                _flexM.SetDummyColumn(new string[] { "S" });

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

                //_flexM.AcceptChanges();

                //SetToolBarButtonState(true, false, false, true, false);
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

            string Year = dpYear.Text;  //조회연월 FROM

            DataTable dt = _biz.Get마감여부(Year);

            if (dt.Rows[0]["ST_MAGAM"].Equals("1"))
            {
                ShowMessage("이미 마감처리된 기수로 동기화할 수 없습니다.");
                return false;
            }

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
                DataRow[] ldrchk = _flexM.DataTable.Select("S = 'Y'", "", DataViewRowState.CurrentRows);

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

        private void MULTI_CD_AGENCY_QueryBefore(object sender, BpQueryArgs e)
        {
            MULTI_CD_AGENCY.UserParams = "대행사 도움창;H_CZ_ME_AGENCY;" + MULTI_CD_AGENCY.CodeNames + ";";
        }

        private void MULTI_CD_AGENCY_ORI_QueryBefore(object sender, BpQueryArgs e)
        {
            MULTI_CD_AGENCY_ORI.UserParams = "원대행사 도움창;H_CZ_ME_AGENT;" + MULTI_CD_AGENCY_ORI.CodeNames + ";";
        }

        private void MULTI_CD_DEPT_QueryBefore(object sender, BpQueryArgs e)
        {
            MULTI_CD_DEPT.UserParams = "부서 도움창;H_CZ_ME_DEPT;" + MULTI_CD_DEPT.CodeNames + ";";
        }

        private void MULTI_CD_CORP_QueryBefore(object sender, BpQueryArgs e)
        {
            MULTI_CD_CORP.UserParams = "매체 도움창;H_CZ_ME_GR;" + MULTI_CD_CORP.CodeNames + ";";
        }

        private void MULTI_CD_MEDIAGR_QueryBefore(object sender, BpQueryArgs e)
        {
            MULTI_CD_MEDIAGR.UserParams = "매체구분 도움창;H_CZ_ME_MEDIAGR;" + MULTI_CD_MEDIAGR.CodeNames + ";";
        }

        private void MULTI_CD_AGENT_QueryBefore(object sender, BpQueryArgs e)
        {
            MULTI_CD_AGENT.UserParams = "광고주 도움창;H_CZ_ME_AGENT;" + MULTI_CD_AGENT.CodeNames + ";";
        }

        private void MULTI_CD_ACCOUNT_QueryBefore(object sender, BpQueryArgs e)
        {
            MULTI_CD_ACCOUNT.UserParams = "매출분석 계정과목 도움창;H_CZ_ME_ACCOUNT_USERDE1;" + MULTI_CD_ACCOUNT.CodeNames + ";";
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
            if (_flexM.Cols[_flexM.Col].Name == "S")
                return;

            if (_flexM.Cols[_flexM.Col].Name == "S1")
                return;

            if (_flexM.Cols[_flexM.Col].Name == "S2")
                return;

            if (_flexM.Cols[_flexM.Col].Name == "no_docu_m")
            {
                string 대행사 = D.GetString(_flexM["NO_DOCU_M"]);

                if (대행사.Length == 15)
                {
                    object[] Args = { 대행사, "", "", Global.MainFrame.LoginInfo.CompanyCode };
                    CallOtherPageMethod("P_FI_DOCU", "전표입력(" + PageName + ")", Grant, Args);
                }
            }
            else if (_flexM.Cols[_flexM.Col].Name == "no_docu_d")
            {
                string 매체 = D.GetString(_flexM["NO_DOCU_D"]);

                if (매체.Length == 15)
                {
                    object[] Args = { 매체, "", "", Global.MainFrame.LoginInfo.CompanyCode };
                    CallOtherPageMethod("P_FI_DOCU", "전표입력(" + PageName + ")", Grant, Args);
                }
            }
            else
            {
                return;
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

            //if (D.GetString(_flexM[e.Row, "cpname"]) == "조정 전표" || D.GetString(_flexM[e.Row, "cpname"]) == "디지털광고매출" || D.GetString(_flexM[e.Row, "cpname"]) == "네트워크광고매출" || D.GetString(_flexM[e.Row, "cpname"]) == "기타매출" || D.GetString(_flexM[e.Row, "cpname"]) == "총계")
            if (D.GetString(_flexM[e.Row, "IDX"]) != "0")
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

                if (D.GetString(_flexM[e.Row, "cp_agentno"]) != "" && D.GetString(_flexM[e.Row, "cp_cd_partner"]) == "")
                {
                    rg = _flexM.GetCellRange(e.Row, "cp_agentno");
                    rg.StyleNew.BackColor = System.Drawing.Color.FromArgb(((Byte)(255)), ((Byte)(126)), ((Byte)(126)));
                    rg = _flexM.GetCellRange(e.Row, "cp_agentnm");
                    rg.StyleNew.BackColor = System.Drawing.Color.FromArgb(((Byte)(255)), ((Byte)(126)), ((Byte)(126)));
                }

                if (D.GetString(_flexM[e.Row, "ay_agencyno"]) != "" && D.GetString(_flexM[e.Row, "ay_cd_partner"]) == "")
                {
                    rg = _flexM.GetCellRange(e.Row, "ay_agencyno");
                    rg.StyleNew.BackColor = System.Drawing.Color.FromArgb(((Byte)(255)), ((Byte)(126)), ((Byte)(126)));
                    rg = _flexM.GetCellRange(e.Row, "ay_agencynm");
                    rg.StyleNew.BackColor = System.Drawing.Color.FromArgb(((Byte)(255)), ((Byte)(126)), ((Byte)(126)));
                }

                if (D.GetString(_flexM[e.Row, "me_corpno"]) != "" && D.GetString(_flexM[e.Row, "me_cd_partner"]) == "")
                {
                    rg = _flexM.GetCellRange(e.Row, "me_corpno");
                    rg.StyleNew.BackColor = System.Drawing.Color.FromArgb(((Byte)(255)), ((Byte)(126)), ((Byte)(126)));
                    rg = _flexM.GetCellRange(e.Row, "me_corpnm");
                    rg.StyleNew.BackColor = System.Drawing.Color.FromArgb(((Byte)(255)), ((Byte)(126)), ((Byte)(126)));
                }
                //if (D.GetString(_flexM[e.Row, "status"]) == "승인")
                //{
                //    rg = _flexM.GetCellRange(e.Row, "status");
                //    rg.StyleNew.BackColor = System.Drawing.Color.LightYellow;
                //}
                if ((D.GetString(_flexM[e.Row, "confirm_date"]) != "" && dt_Syncday != "") && DateTime.Parse(D.GetString(_flexM[e.Row, "confirm_date"])) > DateTime.Parse(dt_Syncday))
                {
                    csCellstyle.BackColor = System.Drawing.Color.FromArgb(((Byte)(183)), ((Byte)(240)), ((Byte)(177)));
                    _flexM.Rows[e.Row].Style = csCellstyle;
                }

                if ((D.GetString(_flexM[e.Row, "dt_jp"]) != "" && D.GetString(_flexM[e.Row, "confirm_date"]) != "") && DateTime.Parse(D.GetString(_flexM[e.Row, "dt_jp"])) < DateTime.Parse(D.GetString(_flexM[e.Row, "confirm_date"])))
                {
                    csCellstyle.BackColor = System.Drawing.Color.FromArgb(((Byte)(255)), ((Byte)(162)), ((Byte)(162)));
                    _flexM.Rows[e.Row].Style = csCellstyle;
                }
            }

            if (D.GetString(_flexM[e.Row, "IDX"]) == "2")
            {
                csCellstyle.BackColor = System.Drawing.Color.FromArgb(((Byte)(255)), ((Byte)(242)), ((Byte)(230)));
                _flexM.Rows[e.Row].Style = csCellstyle;
            }

            if (D.GetString(_flexM[e.Row, "IDX"]) == "1")
            {
                csCellstyle.BackColor = System.Drawing.Color.FromArgb(((Byte)(255)), ((Byte)(242)), ((Byte)(230)));
                _flexM.Rows[e.Row].Style = csCellstyle;
            }

            /*
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
             */
        }

        private void bpc광고주_QueryBefore(object sender, BpQueryArgs e)
        {
            //bpc광고주.UserParams = "광고주 도움창;H_CZ_ME_AGENT;" + bpc광고주.CodeValue + ";";
        }

        public static class StaticClass
        {
            public static int Count = 0;
        }

        private void btn계정변경_Click(object sender, EventArgs e)
        {
            DataRow[] ldrchk = _flexM.DataTable.Select("S = 'Y'", "", DataViewRowState.CurrentRows);

            if (ldrchk == null || ldrchk.Length == 0)
            {
                ShowMessage(공통메세지.선택된자료가없습니다);
                return;
            }

            try
            {
                P_CZ_ME_SALES_SUB2 sub = new P_CZ_ME_SALES_SUB2();		//WinForm 생성

                if (sub.ShowDialog() == DialogResult.OK)			//WinForm Close시에 DialogResult.OK 이면 추가 설정을 한다
                {
                    for (int i = 1; i < _flexM.Rows.Count; i++)
                    {
                        if (_flexM[i, "S"].ToString().Equals("Y"))
                        {
                            _biz.Update_Acct(_flexM[i, "NO_DOCU_M"].ToString(), _flexM[i, "NO_DOCU_D"].ToString(), sub.strCD_ACCT_J, sub.strCD_ACCT_H);
                        }
                    }
                }

                /*
                P_CZ_ME_SALES_SUB2 sub = new P_CZ_ME_SALES_SUB2(D.GetString(_flexM["NO_DOCU_M"]), D.GetString(_flexM["NO_DOCU_D"]));		//WinForm 생성
                
                if (sub.ShowDialog() != DialogResult.OK)
                    return;
                 * */
            }
            catch (Exception ex)
            {
                this.MsgEnd(ex);
            }
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

        private void P_CZ_ME_SALES_OwerClosed(object sender, EventArgs e)
        {
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm.Name == "P_CZ_ME_SALES_SUB") // 열린 폼의 이름 검사
                {
                    openForm.Close();
                    return;
                }

                if (openForm.Name == "P_CZ_ME_SALES_SUB2") // 열린 폼의 이름 검사
                {
                    openForm.Close();
                    return;
                }
            }
        }

        private void btn전표일괄처리_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_flexM.HasNormalRow)
                    return;

                // 20200720 이미 전표처리된 데이터는 전표발행이 불가능하도록 추가 (DB연동)
                if (!BeforeSaveChk())
                    return;

                if (ShowMessage("선택한 " + dpMonthTo.Text + "월(to기준)의 전표를 일괄처리 하시겠습니까? 처리 후에는 일괄 취소가 불가능합니다.", "QY2") == DialogResult.Yes)
                {
                    string 발행월 = dpYear.Text + dpMonthTo.Text; //조회연월 TO

                    if (_biz.Save_Junpyo_ay_all(발행월))
                    {

                    }

                    if (_biz.Save_Junpyo_me_all(발행월))
                    {

                    }

                    ShowMessage(dpMonthTo.Text + "월의 전표 처리가 완료되었습니다.");
                }
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }

        private void btn전표일괄취소_Click(object sender, EventArgs e)
        {
            try
            {

                if (!_flexM.HasNormalRow)
                    return;

                // 20200720 이미 전표처리된 데이터는 전표발행이 불가능하도록 추가 (DB연동)
                if (!BeforeSaveChk())
                    return;

                if (ShowMessage("선택한 " + dpMonthTo.Text + "월(to기준)의 전표를 전체 취소 하시겠습니까?", "QY2") == DialogResult.Yes)
                {
                    string 발행월 = dpYear.Text + dpMonthTo.Text; //조회연월 TO

                    if (_biz.Delete_Junpyo_all(발행월))
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }

        private void btn전표처리_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_flexM.HasNormalRow)
                    return;

                // 20200720 이미 전표처리된 데이터는 전표발행이 불가능하도록 추가 (DB연동)
                if (!BeforeSaveChk())
                    return;

                if (ShowMessage(" 전표 처리 하시겠습니까? 기 전표처리된 행은 제외하고 처리됩니다.", "QY2") == DialogResult.Yes)
                {
                    for (int i = 1; i < (_flexM.Rows.Count - 2); i++)
                    {
                        if (_flexM[i, "S"].ToString().Equals("Y"))
                        {
                            string 캠페인코드 = _flexM[i, "cpid"].ToString();
                            string 순번 = _flexM[i, "seq"].ToString();
                            string 발행월 = dpYear.Text + dpMonthTo.Text; //조회연월 TO
                            string 대행사기준 = _flexM[i, "ay_trade_type"].ToString();
                            string 매체기준 = _flexM[i, "me_trade_type"].ToString();
                            string 계정과목 = _flexM[i, "cd_acct"].ToString();
                            string 구분 = _flexM[i, "cd_sysdef"].ToString();
                            string 매체아이디 = _flexM[i, "me_corpid"].ToString();
                            string 합산매체 = _flexM[i, "me_sumcode"].ToString();
                            string REQ_NO = _flexM[i, "req_no"].ToString();

                            DataTable dt = _biz.Get대행사전표여부(캠페인코드, 순번);

                            if (dt.Rows.Count != 0 && dt.Rows[0]["NO_DOCU"].Equals("1"))
                            {

                            }
                            else
                            {
                                if (캠페인코드.Length > 0 && _biz.Save_Junpyo_ay(캠페인코드, 순번, 발행월, 대행사기준, 매체기준, 계정과목, 구분, 매체아이디, 합산매체))
                                {

                                }
                            }

                            DataTable dt2 = _biz.Get매체전표여부(캠페인코드, 순번);

                            if (dt2.Rows.Count != 0 && dt2.Rows[0]["NO_DOCU"].Equals("1"))
                            {

                            }
                            else
                            {
                                if (캠페인코드.Length > 0 && _biz.Save_Junpyo_me(캠페인코드, 순번, 발행월, 대행사기준, 매체기준, 계정과목, 구분, 매체아이디, 합산매체, REQ_NO))
                                {

                                }
                            } 
                        }

                        if (_flexM[i, "S1"].ToString().Equals("Y"))
                        {
                            string 캠페인코드 = _flexM[i, "cpid"].ToString();
                            string 순번 = _flexM[i, "seq"].ToString();
                            string 발행월 = dpYear.Text + dpMonthTo.Text; //조회연월 TO
                            string 대행사기준 = _flexM[i, "ay_trade_type"].ToString();
                            string 매체기준 = _flexM[i, "me_trade_type"].ToString();
                            string 계정과목 = _flexM[i, "cd_acct"].ToString();
                            string 구분 = _flexM[i, "cd_sysdef"].ToString();
                            string 매체아이디 = _flexM[i, "me_corpid"].ToString();
                            string 합산매체 = _flexM[i, "me_sumcode"].ToString();
                            string REQ_NO = _flexM[i, "req_no"].ToString();

                            DataTable dt = _biz.Get대행사전표여부(캠페인코드, 순번);

                            if (dt.Rows.Count != 0 && dt.Rows[0]["NO_DOCU"].Equals("1"))
                            {

                            }
                            else
                            {
                                if (캠페인코드.Length > 0 && _biz.Save_Junpyo_ay(캠페인코드, 순번, 발행월, 대행사기준, 매체기준, 계정과목, 구분, 매체아이디, 합산매체))
                                {

                                }
                            }
                        }

                        if (_flexM[i, "S2"].ToString().Equals("Y"))
                        {
                            string 캠페인코드 = _flexM[i, "cpid"].ToString();
                            string 순번 = _flexM[i, "seq"].ToString();
                            string 발행월 = dpYear.Text + dpMonthTo.Text; //조회연월 TO
                            string 대행사기준 = _flexM[i, "ay_trade_type"].ToString();
                            string 매체기준 = _flexM[i, "me_trade_type"].ToString();
                            string 계정과목 = _flexM[i, "cd_acct"].ToString();
                            string 구분 = _flexM[i, "cd_sysdef"].ToString();
                            string 매체아이디 = _flexM[i, "me_corpid"].ToString();
                            string 합산매체 = _flexM[i, "me_sumcode"].ToString();
                            string REQ_NO = _flexM[i, "req_no"].ToString();

                            DataTable dt2 = _biz.Get매체전표여부(캠페인코드, 순번);

                            if (dt2.Rows.Count != 0 && dt2.Rows[0]["NO_DOCU"].Equals("1"))
                            {

                            }
                            else
                            {
                                if (캠페인코드.Length > 0 && _biz.Save_Junpyo_me(캠페인코드, 순번, 발행월, 대행사기준, 매체기준, 계정과목, 구분, 매체아이디, 합산매체, REQ_NO))
                                {

                                }
                            } 
                        }
                    }

                    ShowMessage("전표처리가 완료 되었습니다.");
                    searchNo();
                }
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }

        private void btn전표취소_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_flexM.HasNormalRow)
                    return;

                // 20200720 이미 전표처리된 데이터는 전표발행이 불가능하도록 추가 (DB연동)
                if (!BeforeSaveChk())
                    return;

                if (ShowMessage(" 전표 취소 하시겠습니까?", "QY2") == DialogResult.Yes)
                {
                    for (int i = 1; i < (_flexM.Rows.Count - 2); i++)
                    {
                        if (_flexM[i, "S"].ToString().Equals("Y"))
                        {
                            string 대행사전표번호 = _flexM[i, "no_docu_m"].ToString();
                            string 매체전표번호 = _flexM[i, "no_docu_d"].ToString();
                            string 대행사세금계산서여부 = "0";
                            string 매체세금계산서여부 = "0";

                            if (대행사전표번호.Length.Equals(0) && 매체전표번호.Length.Equals(0))
                            {
                                ShowMessage(i + "행은 전표처리 되지 않은 데이터로 취소할 수 없습니다.");
                                return;
                            }

                            DataTable dt = _biz.Get대행사세금계산서여부(대행사전표번호);

                            if (dt.Rows.Count != 0 && dt.Rows[0]["FINAL_STATUS"].Equals("1"))
                            {
                                ShowMessage(i + "행은 세금계산서 처리된 항목으로 마이너스 처리 됩니다.");
                                대행사세금계산서여부 = "1";
                            }

                            DataTable dt2 = _biz.Get매체세금계산서여부(매체세금계산서여부);

                            if (dt2.Rows.Count != 0 && dt2.Rows[0]["FINAL_STATUS"].Equals("1"))
                            {
                                ShowMessage(i + "행은 세금계산서 처리된 항목으로 마이너스 처리 됩니다.");
                                매체세금계산서여부 = "1";
                            }

                            if (_biz.Delete_Junpyo(대행사전표번호, 매체전표번호, 대행사세금계산서여부, 매체세금계산서여부))
                            {

                            }
                        }

                        if (_flexM[i, "S1"].ToString().Equals("Y"))
                        {
                            string 대행사전표번호 = _flexM[i, "no_docu_m"].ToString();
                            string 매체전표번호 = "";
                            string 대행사세금계산서여부 = "0";
                            string 매체세금계산서여부 = "0";

                            if (대행사전표번호.Length.Equals(0))
                            {
                                ShowMessage(i + "행은 전표처리 되지 않은 데이터로 취소할 수 없습니다.");
                                return;
                            }

                            DataTable dt = _biz.Get대행사세금계산서여부(대행사전표번호);

                            if (dt.Rows.Count != 0 && dt.Rows[0]["FINAL_STATUS"].Equals("1"))
                            {
                                ShowMessage(i + "행은 세금계산서 처리된 항목으로 마이너스 처리 됩니다.");
                                대행사세금계산서여부 = "1";
                            }

                            if (_biz.Delete_Junpyo(대행사전표번호, 매체전표번호, 대행사세금계산서여부, 매체세금계산서여부))
                            {

                            }
                        }

                        if (_flexM[i, "S2"].ToString().Equals("Y"))
                        {
                            string 대행사전표번호 = "";
                            string 매체전표번호 = _flexM[i, "no_docu_d"].ToString();
                            string 대행사세금계산서여부 = "0";
                            string 매체세금계산서여부 = "0";

                            if (매체전표번호.Length.Equals(0))
                            {
                                ShowMessage(i + "행은 전표처리 되지 않은 데이터로 취소할 수 없습니다.");
                                return;
                            }

                            DataTable dt2 = _biz.Get매체세금계산서여부(매체세금계산서여부);

                            if (dt2.Rows.Count != 0 && dt2.Rows[0]["FINAL_STATUS"].Equals("1"))
                            {
                                ShowMessage(i + "행은 세금계산서 처리된 항목으로 마이너스 처리 됩니다.");
                                매체세금계산서여부 = "1";
                            }

                            if (_biz.Delete_Junpyo(대행사전표번호, 매체전표번호, 대행사세금계산서여부, 매체세금계산서여부))
                            {

                            }
                        }
                    }

                    ShowMessage("전표취소가 완료 되었습니다.");
                    searchNo();
                }
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }

        private void btn동기화_Click(object sender, EventArgs e)
        {
            try
            {
                string FROM = dpYear.Text + dpMonthFr.Text;  //조회연월 FROM
                string TO = dpYear.Text + dpMonthTo.Text; //조회연월 TO
                string Year = dpYear.Text;  //조회연월 FROM

                DataTable dt = _biz.Get마감여부(Year);

                if (dt.Rows.Count != 0 && dt.Rows[0]["ST_MAGAM"].Equals("1"))
                {
                    ShowMessage("이미 마감처리된 기수로 동기화할 수 없습니다.");
                    return;
                }

                if (ShowMessage("해당 월에 대한 동기화를 진행하시겠습니까?", "QY2") == DialogResult.Yes)
                {
                    DataSet ds = _biz.Save_Sync(FROM, TO);

                    ShowMessage("동기화 처리가 완료되었습니다.");
                }
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }

        private void btn삭제반영_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow[] ldrchk = _flexM.DataTable.Select("S = 'Y'", "", DataViewRowState.CurrentRows);

                if (ldrchk == null || ldrchk.Length == 0)
                {
                    ShowMessage(공통메세지.선택된자료가없습니다);
                    return;
                }

                string Year = dpYear.Text;  //조회연월 FROM

                DataTable dt = _biz.Get마감여부(Year);

                if (dt.Rows.Count != 0 && dt.Rows[0]["ST_MAGAM"].Equals("1"))
                {
                    ShowMessage("이미 마감처리된 기수로 동기화할 수 없습니다.");
                    return;
                }

                if (ShowMessage(" 삭제하시겠습니까?", "QY2") == DialogResult.Yes)
                {
                    for (int i = 2; i < (_flexM.Rows.Count - 2); i++)
                    {
                        if (_flexM[i, "S"].ToString().Equals("Y"))
                        {
                            string 캠페인코드 = _flexM[i, "cpid"].ToString();
                            string 순번 = _flexM[i, "seq"].ToString();
                            string 구분 = "삭제";

                            if (_biz.Update_Sales(구분, 캠페인코드, 순번))
                            {

                            }
                        }
                    }

                    ShowMessage("삭제가 완료 되었습니다.");
                    searchNo();
                }
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }


        private void btn이월반영_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow[] ldrchk = _flexM.DataTable.Select("S = 'Y'", "", DataViewRowState.CurrentRows);

                if (ldrchk == null || ldrchk.Length == 0)
                {
                    ShowMessage(공통메세지.선택된자료가없습니다);
                    return;
                }

                string Year = dpYear.Text;  //조회연월 FROM

                DataTable dt = _biz.Get마감여부(Year);

                if (dt.Rows.Count != 0 && dt.Rows[0]["ST_MAGAM"].Equals("1"))
                {
                    ShowMessage("이미 마감처리된 기수로 동기화할 수 없습니다.");
                    return;
                }
                if (ShowMessage(" 이월처리하시겠습니까?", "QY2") == DialogResult.Yes)
                {
                    for (int i = 2; i < (_flexM.Rows.Count - 2); i++)
                    {
                        if (_flexM[i, "S"].ToString().Equals("Y"))
                        {
                            string 캠페인코드 = _flexM[i, "cpid"].ToString();
                            string 순번 = _flexM[i, "seq"].ToString();
                            string 구분 = "이월";


                            if (_biz.Update_Sales(구분, 캠페인코드, 순번))
                            {

                            }
                        }
                    }

                    ShowMessage("이월처리가 완료 되었습니다.");
                    searchNo();
                }
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }

        private void dpMonthFr_ValueChanged(object sender, EventArgs e)
        {
            if (dpMonthFr.Value > dpMonthTo.Value)
            {
                dpMonthTo.Value = dpMonthFr.Value;
            }
        }

        private void dpMonthTo_ValueChanged(object sender, EventArgs e)
        {
            if (dpMonthFr.Value > dpMonthTo.Value)
            {
                dpMonthFr.Value = dpMonthTo.Value;
            }

        }

        private void cbo수정구분_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (D.GetString(cbo수정구분.SelectedValue) == "2")
            {
                _flexM.RowFilter = "confirm_date > '" + dt_Syncday + "'";
            }
            else
            {
                _flexM.RowFilter = String.Empty;
                //_flexM.RowFilter = "confirm_date > '" + dt_Syncday + "'";
            }
        }

        private void chk수정구분_CheckedChanged(object sender, EventArgs e)
        {
            if (chk수정구분.Checked.Equals(true))
            {
                _flexM.RowFilter = "confirm_date > '" + dt_Syncday + "'";
            }
            else
            {
                _flexM.RowFilter = String.Empty;
                //_flexM.RowFilter = "confirm_date > '" + dt_Syncday + "'";
            }
        }
    }
}