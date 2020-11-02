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
    // 작   성   자 : 김승일
    // 재 작  성 일 : 2020-10-12
    // 모   듈   명 : 채권관리 보전서류
    // 시 스  템 명 : 채권관리 보전서류
    // 서브시스템명 : 채권관리 보전서류
    // 페 이 지  명 : 채권관리 보전서류
    // 프로젝트  명 : CZ_ME_BOND_DOCU
    // **************************************
    public partial class P_CZ_ME_BOND_DOCU : PageBase
    {
        #region ♥ 멤버필드

        private P_CZ_ME_BOND_DOCU_BIZ _biz = new P_CZ_ME_BOND_DOCU_BIZ();
        bool _타메뉴호출 = false;

        #endregion

        #region ♥ 초기화

        #region -> 생성자

        public P_CZ_ME_BOND_DOCU()
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

            toyear = "20000101";

            dt기간.StartDate = DateTime.ParseExact(toyear, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            dt기간.EndDate = DateTime.ParseExact(today, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);

            //dp조회일자.Text = "";

            Grant.CanAdd = false;
            Grant.CanSave = false;
            Grant.CanDelete = false;
            Grant.CanPrint = false;

            //콤보박스 셋팅
            SetControl set = new SetControl();
            set.SetCombobox(cbo조회구분, MA.GetCode("CZ_ME_C019", true));

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

            _flexM.SetCol("NO_COMPANY", "거래처코드", 100, false);
            _flexM.SetCol("LN_PARTNER", "거래처명", 150, false);

            _flexM.SetCol("DOCU_GUBUN", "종류", 100, false);
            _flexM.SetCol("NO_GUBUN", "번호", 50, false);
            _flexM.SetCol("AM_SET", "설정액", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);

            _flexM.SetCol("DT_SIGN", "체결일", 100, false, typeof(decimal), FormatTpType.YEAR_MONTH_DAY);
            _flexM.SetCol("DT_START", "시작일", 100, false, typeof(decimal), FormatTpType.YEAR_MONTH_DAY);
            _flexM.SetCol("DT_END", "만기일", 100, false, typeof(decimal), FormatTpType.YEAR_MONTH_DAY);
            _flexM.SetCol("DT_LIMIT", "소멸시효", 100, false, typeof(decimal), FormatTpType.YEAR_MONTH_DAY);

            _flexM.SetCol("NM_USERDE2_1", "소유자", 100, false);
            _flexM.SetCol("NM_USERDE1_1", "채무자", 100, false);
            _flexM.SetCol("NM_USERDE3_1", "물건지", 100, false);
            _flexM.SetCol("NM_USERDE4_1", "부동산근저당MEMO", 100, false);
            _flexM.SetCol("NM_USERDE1_2", "종류", 100, false);
            _flexM.SetCol("NM_USERDE2_2", "증서번호", 100, false);
            _flexM.SetCol("NM_USERDE3_2", "발행인1", 100, false);
            _flexM.SetCol("NM_USERDE4_2", "발행인2", 100, false);
            _flexM.SetCol("NM_USERDE5_2", "발행인3", 100, false);
            _flexM.SetCol("NM_USERDE6_2", "공정증서MEMO", 100, false);
            _flexM.SetCol("NM_USERDE1_3", "증권번호", 100, false);
            _flexM.SetCol("NM_USERDE2_3", "보험료", 100, false);
            _flexM.SetCol("NM_USERDE3_3", "주계약내용", 100, false);
            _flexM.SetCol("NM_USERDE4_3", "계약시작일", 100, false, typeof(decimal), FormatTpType.YEAR_MONTH_DAY);
            _flexM.SetCol("NM_USERDE5_3", "계약종료일", 100, false, typeof(decimal), FormatTpType.YEAR_MONTH_DAY);
            _flexM.SetCol("NM_USERDE6_3", "계약체결일", 100, false, typeof(decimal), FormatTpType.YEAR_MONTH_DAY);
            _flexM.SetCol("NM_USERDE7_3", "계약금", 100, false);
            _flexM.SetCol("NM_USERDE8_3", "보험기간개시전발생채무액", 100, false);
            _flexM.SetCol("NM_USERDE9_3", "보증보험MEMO", 100, false);
            _flexM.SetCol("NM_USERDE1_4", "연대보증인1", 100, false);
            _flexM.SetCol("NM_USERDE2_4", "연대보증인2", 100, false);
            _flexM.SetCol("NM_USERDE3_4", "연대보증인3", 100, false);
            _flexM.SetCol("NM_USERDE4_4", "연대보증MEMO", 100, false);
            _flexM.SetCol("NM_USERDE1_5", "제3채1", 100, false);
            _flexM.SetCol("NM_USERDE2_5", "제3채2", 100, false);
            _flexM.SetCol("NM_USERDE3_5", "제3채3", 100, false);
            _flexM.SetCol("NM_USERDE4_5", "채권양도통지서부수건", 100, false);
            _flexM.SetCol("NM_USERDE5_5", "인감증명서", 100, false);
            _flexM.SetCol("NM_USERDE6_5", "부속합의서", 100, false);
            _flexM.SetCol("NM_USERDE7_5", "채권양도MEMO", 100, false);
            _flexM.SetCol("NM_USERDE1_6", "구분(문서명)", 100, false);
            _flexM.SetCol("NM_USERDE2_6", "시작일", 100, false, typeof(decimal), FormatTpType.YEAR_MONTH_DAY);
            _flexM.SetCol("NM_USERDE3_6", "종료일", 100, false, typeof(decimal), FormatTpType.YEAR_MONTH_DAY);
            _flexM.SetCol("NM_USERDE4_6", "분할횟수", 100, false);
            _flexM.SetCol("NM_USERDE5_6", "특이사항", 100, false);
            _flexM.SetCol("NM_USERDE6_6", "상환계획MEMO", 100, false);
            _flexM.SetCol("NM_USERDE1_7", "비고", 100, false);
            _flexM.SetCol("NM_USERDE2_7", "기타MEMO", 100, false);

            _flexM.Cols["NO_COMPANY"].Format = _flexM.Cols["NO_COMPANY"].EditMask = "###-##-#####";
            _flexM.Cols["NO_COMPANY"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.SetStringFormatCol("NO_COMPANY");
            _flexM.SetNoMaskSaveCol("NO_COMPANY");

            _flexM.Cols["DT_SIGN"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["DT_START"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["DT_END"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["DT_LIMIT"].TextAlign = TextAlignEnum.CenterCenter;

            _flexM.Cols["NM_USERDE4_3"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["NM_USERDE5_3"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["NM_USERDE6_3"].TextAlign = TextAlignEnum.CenterCenter;

            _flexM.Cols["NM_USERDE2_6"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["NM_USERDE3_6"].TextAlign = TextAlignEnum.CenterCenter;

         
            _flexM.SettingVersion = "1.0.0.4";// new Random().Next().ToString();
            _flexM.EndSetting(GridStyleEnum.Green, AllowSortingEnum.MultiColumn, SumPositionEnum.None);
            _flexM.HelpClick += new EventHandler(_flexM_HelpClick);
            //_flexM.SetCodeHelpCol("CD_DEPT", HelpID.P_MA_DEPT_SUB, ShowHelpEnum.Always, new string[] { "CD_DEPT", "NM_DEPT" }, new string[] { "CD_DEPT", "NM_DEPT" }, ResultMode.FastMode);
            //_flexM.SetCodeHelpCol("AY_AGENCYNO", HelpID.P_MA_PARTNER_SUB, ShowHelpEnum.Always, new string[] { "AY_AGENCYNO", "AY_AGENCYID", "AY_AGENCYNM" }, new string[] { "NO_COMPANY", "CD_PARTNER", "LN_PARTNER" }, ResultMode.FastMode);
        }

        #endregion

        #region -> InitPaint

        protected override void InitPaint()
        {
            base.InitPaint();

            UGrant grant = new UGrant();

            try
            {
                _flexM.SetDataMap("DOCU_GUBUN", MA.GetCode("CZ_ME_C019"), "CODE", "NAME");

                SetControl set = new SetControl();
                //set.SetCombobox(cbo조회구분, MA.GetCodeUser(new string[] { "", "1", "0" }, new string[] { DD("전체"), DD("마감"), DD("미마감") }));
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
                object[] Params = new object[6];
                Params[0] = LoginInfo.CompanyCode;
                Params[1] = dt기간.StartDate.ToString().Substring(0, 10).Replace("-", "");
                Params[2] = dt기간.EndDate.ToString().Substring(0, 10).Replace("-", "");
                Params[3] = dp조회일자.Text; //조회일자
                Params[4] = MULTI_CD_CORP.QueryWhereIn_Pipe.Replace("|", "");
                Params[5] = cbo조회구분.SelectedValue;
               
                
                DataSet ds = _biz.Search_M(Params);

                _flexM.Binding = ds.Tables[0];
                //_flexM.AcceptChanges();
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
        #endregion

        #endregion

        #region ♥ 기타 Property
        string ServerKey { get { return Global.MainFrame.ServerKeyCommon.ToUpper(); } }
        #endregion

        void _flexM_HelpClick(object sender, EventArgs e)
        {
            if (_flexM.Cols[_flexM.Col].Name == "AM_SET")
            {
                string 거래처코드 = D.GetString(_flexM["NO_COMPANY"]);
                string 거래처명 = D.GetString(_flexM["LN_PARTNER"]);
                string 종류 = D.GetString(_flexM["DOCU_GUBUN"]);
                string 번호 = D.GetString(_flexM["NO_GUBUN"]);

                object[] Args = { 거래처코드, 거래처명, 종류, 번호 };
                CallOtherPageMethod("P_CZ_ME_BOND_INFO", "채권보전서류등록(" + PageName + ")", Grant, Args);
            }
           
            else
            {
                return;
            }
        }
    }
}