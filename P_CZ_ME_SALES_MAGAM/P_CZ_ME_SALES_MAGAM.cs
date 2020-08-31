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


namespace cz
{
    // **************************************
    // 작성자 : 박승한
    // 작성일 : 2020-08-28
    // 모듈명 : 마감처리
    // 페이지 : P_CZ_ME_SALES_CLOSE
    // **************************************

    public partial class P_CZ_ME_SALES_MAGAM : PageBase
    {
        #region ♥ 멤버필드

        private P_CZ_ME_SALES_MAGAM_BIZ _biz = new P_CZ_ME_SALES_MAGAM_BIZ();
        bool _타메뉴호출 = false;
        string today = "";
        string toyear = "";

        #endregion

        #region ♥ 초기화

        #region -> 생성자

        public P_CZ_ME_SALES_MAGAM()
        {
            InitializeComponent();

            MainGrids = new FlexGrid[] { _flexM, _flexD };
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
            //DETAIL
            //merge 기능을 위해서 row 2 설정
            _flexM.BeginSetting(1, 1, false);
            _flexD.BeginSetting(1, 1, false);

            _flexM.SetCol("NO_ACCSEQ", "회계기수", 60, false);
            _flexM.SetCol("DT_FROM", "시작년월일", 120, false, typeof(string), FormatTpType.YEAR_MONTH_DAY);
            _flexM.SetCol("DT_TO", "종료년월일", 120, false, typeof(string), FormatTpType.YEAR_MONTH_DAY);

            _flexD.SetCol("DT_YEAR", "연월", 0, false);
            _flexD.SetCol("CD_INDEX", "구분", 80, false);
            _flexD.SetCol("ST_MAGAM", "처리구분", 80, false);
            _flexD.SetCol("DT_MAGAM", "일시", 150, false);
            _flexD.SetCol("ID_INSERT", "동기화작업자ID", 120, false);
            _flexD.SetCol("NM_INSERT", "동기화작업자명", 120, false);

            _flexM.Cols["DT_FROM"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["DT_TO"].TextAlign = TextAlignEnum.CenterCenter;

            _flexD.Cols["CD_INDEX"].TextAlign = TextAlignEnum.CenterCenter;
            //_flexD.Cols["ID_INSERT"].TextAlign = TextAlignEnum.CenterCenter;
            _flexD.Cols["ST_MAGAM"].TextAlign = TextAlignEnum.CenterCenter;

            _flexD.Cols["DT_MAGAM"].Format = _flexD.Cols["DT_MAGAM"].EditMask = "####/##/## ##:##:##";
            _flexD.Cols["DT_MAGAM"].TextAlign = TextAlignEnum.CenterCenter;
            _flexD.SetStringFormatCol("DT_MAGAM");
            _flexD.SetNoMaskSaveCol("DT_MAGAM");

            _flexM.SettingVersion = "1.0.0.5";// new Random().Next().ToString();
            _flexM.EndSetting(GridStyleEnum.Green, AllowSortingEnum.MultiColumn, SumPositionEnum.None);

            _flexD.SettingVersion = "1.0.0.5";// new Random().Next().ToString();
            _flexD.EndSetting(GridStyleEnum.Green, AllowSortingEnum.MultiColumn, SumPositionEnum.None);

            //_flexM.SetCodeHelpCol("CD_DEPT", HelpID.P_MA_DEPT_SUB, ShowHelpEnum.Always, new string[] { "CD_DEPT", "NM_DEPT" }, new string[] { "CD_DEPT", "NM_DEPT" }, ResultMode.FastMode);
            //_flexM.SetCodeHelpCol("ay_agencyno", HelpID.P_MA_PARTNER_SUB, ShowHelpEnum.Always, new string[] { "ay_agencyno", "ay_agencyid", "ay_agencynm" }, new string[] { "no_company", "cd_partner", "ln_partner" }, ResultMode.FastMode);
            //_flexM.SetCodeHelpCol("me_corpno", HelpID.P_MA_PARTNER_SUB, ShowHelpEnum.Always, new string[] { "me_corpno", "me_corpid", "me_corpnm" }, new string[] { "no_company", "cd_partner", "ln_partner" }, ResultMode.FastMode);
            //_flexM.SetCodeHelpCol("me_teamnm", HelpID.P_MA_DEPT_SUB, ShowHelpEnum.Always, new string[] { "me_teamid", "me_teamnm" }, new string[] { "cd_dept", "nm_dept" }, ResultMode.FastMode);
            //_flexM.SetCodeHelpCol("cpname", "H_CZ_CP_SUB", ShowHelpEnum.Always, new string[] { "cpid", "cpname" }, new string[] { "cpid", "cpname" });

            //rdo컷.CheckedChanged += new EventHandler(rdo컷_CheckedChanged);
            _flexM.AfterRowChange += new RangeEventHandler(_flexM_AfterRowChange);
            //_flexM.AfterEdit += new RowColEventHandler(_flexM_AfterEdit);
            //_flexM.BeforeCodeHelp += new BeforeCodeHelpEventHandler(_flexM_BeforeCodeHelp);
            //_flexM.OwnerDrawCell += new OwnerDrawCellEventHandler(_flexM_OwnerDrawCell);

            //20200720 Null Check 임시추가
            //_flexM.VerifyNotNull = new string[] { "cpid", "ay_year_month", "ay_trade_type", "ay_agencyid", "me_corpid", "me_teamid", "am_budget", "am_agy_price", "am_income", "am_media_price" };
            //_flexM.VerifyNotNull = new string[] { "CD_COMPANY", "TP_SALES", "MER_REQ_NO", "cpid", "NM_CPID", "ME_SEQ", "AY_YEAR_MONTH", "AY_TRADE_TYPE", "AY_AGENCYID", "AY_TRADE_TYPE", "ME_CORPID", "ME_YEAR_MONTH", "ME_TRADE_TYPE", "ME_TEAMID", "CD_ACCT", "AM_BUDGET", "AM_AGY_PRICE", "AM_INCOME", "AM_MEDIA_PRICE", "CP_AGENTID" };
        }

        #endregion

        #region -> InitPaint

        protected override void InitPaint()
        {
            base.InitPaint();

            Grant.CanDelete = false;
            Grant.CanAdd = false;
            Grant.CanPrint = false;
            Grant.CanSave = false;
            Grant.CanSearch = false;

            btn마감.Click += new EventHandler(btn마감_Click);
            btn마감해제.Click += new EventHandler(btn마감해제_Click);

            //SetControl set = new SetControl();
            //set.SetCombobox(cbo등록구분, MA.GetCodeUser(new string[] { "2", "9" }, new string[] { DD("전기이월수정"), DD("삭제내역") }));

            //콤보박스 셋팅
            //DataTable dt계정코드 = _biz.Get계정코드();
            //_flexM.SetDataMap("CD_ACCT", dt계정코드.Copy(), "CODE", "NAME");

            //페이지 로드 시 첫번 컷오프이므로 해당 컬럼 들 editing false 설정
            //_flexM.Cols["cpname"].AllowEditing = false;

            //페이지 오픈 시 조회할 수 있도록 처리
            object[] Params = new object[1];
            Params[0] = LoginInfo.CompanyCode;

            DataSet ds = _biz.Search_M(Params);
            _flexM.Binding = ds.Tables[0];
        }

        #endregion

        #endregion

        #region ♥ 메인버튼 클릭

        #region -> 조회버튼클릭

        public override void OnToolBarSearchButtonClicked(object sender, EventArgs e)
        {
            try
            {
                //_flexM.Binding = _biz.GetLineTable();
                object[] Params = new object[1];
                Params[0] = LoginInfo.CompanyCode;

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

        }

        // 저장 전 체크 사항
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

        #region -> 삭제버튼클릭

        public override void OnToolBarDeleteButtonClicked(object sender, EventArgs e)
        {

        }
        #endregion

        #region -> 추가버튼클릭

        public override void OnToolBarAddButtonClicked(object sender, EventArgs e)
        {

        }

        #endregion

        #endregion

        #region ♥ 기타 이벤트

        private void btn마감_Click(object sender, EventArgs e)
        {
            try
            {
                if (ShowMessage(" 마감 하시겠습니까?", "QY2") == DialogResult.Yes)
                {
                    string 연월 = D.GetString(_flexM["DT_FROM"]);
                    string 구분 = "마감";

                    DataTable dt = _biz.Get마감여부(연월, 구분);

                    if (dt.Rows[0]["ST_MAGAM"].Equals("1"))
                    {
                        ShowMessage("이미 마감처리 된 기수입니다.");
                        return;
                    }

                    if (_biz.Update_Magam(구분, 연월))
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }

        private void btn마감해제_Click(object sender, EventArgs e)
        {
            try
            {
                if (ShowMessage(" 마감해제 하시겠습니까?", "QY2") == DialogResult.Yes)
                {
                    string 연월 = D.GetString(_flexM["DT_FROM"]);
                    string 구분 = "마감해제";

                    DataTable dt = _biz.Get마감여부(연월, 구분);

                    if (dt.Rows[0]["ST_MAGAM"].Equals("0"))
                    {
                        ShowMessage("마감 처리 되지 않은 기수입니다.");
                        return;
                    }

                    if (_biz.Update_Magam(구분, 연월))
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

        #region ♥ 그리드 이벤트

        void _flexM_AfterRowChange(object sender, RangeEventArgs e)
        {
            try 
            {
                string 연월 = D.GetString(_flexM["DT_FROM"]);
                string 구분 = ""; //D.GetString(_flexM["CD_INDEX"]);

                object[] Params = new object[4];
                Params[0] = LoginInfo.CompanyCode;
                Params[1] = "SELECT";
                Params[2] = 연월;
                Params[3] = 구분;

                DataSet ds = _biz.Search_D(Params);
                _flexD.Binding = ds.Tables[0];
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