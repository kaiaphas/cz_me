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
    // 작성일 : 2020-06-23
    // 모듈명 : CUT-OFF 및 이월자료 등록
    // 페이지 : P_CZ_ME_SALES_FOR
    // **************************************

    public partial class P_CZ_ME_SALES_FOR : PageBase
    {
        #region ♥ 멤버필드

        private P_CZ_ME_SALES_FOR_BIZ _biz = new P_CZ_ME_SALES_FOR_BIZ();
        bool _타메뉴호출 = false;
        string today = "";
        string toyear = "";

        #endregion

        #region ♥ 초기화

        #region -> 생성자

        public P_CZ_ME_SALES_FOR()
        {
            InitializeComponent();

            MainGrids = new FlexGrid[] { _flexM };
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
            _flexM.BeginSetting(2, 1, false);

            _flexM.SetCol("S", "선택", 35, true, CheckTypeEnum.Y_N);

            _flexM.SetCol("tp_sales", "구분", 60, false);
            _flexM.SetCol("cd_acct", "계정과목", 120, true);
            _flexM.SetCol("cpid", "캠페인", 60, false);
            _flexM.SetCol("cpname", "캠페인명", 160, true);

            _flexM.SetCol("ay_year_month", "월", 60, true, typeof(string), FormatTpType.YEAR_MONTH);
            _flexM.SetCol("ay_trade_type", "기준", 60, true);
            _flexM.SetCol("ay_agencyno", "사업자등록번호", 100, true);
            _flexM.SetCol("ay_agencyid", "대행사코드", 0, false);
            _flexM.SetCol("ay_agencynm", "대행사명", 120, false);

            _flexM.SetCol("me_year_month", "월", 60, true, typeof(string), FormatTpType.YEAR_MONTH);
            _flexM.SetCol("me_trade_type", "기준", 60, true);
            _flexM.SetCol("me_corpno", "사업자등록번호", 120, true);
            _flexM.SetCol("me_corpid", "매체코드", 0, false);
            _flexM.SetCol("me_corpnm", "매체명", 120, false);
            _flexM.SetCol("nm_mediagr", "구분", 60, false);

            _flexM.SetCol("me_teamid", "팀코드", 0, false);
            _flexM.SetCol("me_teamnm", "팀명", 120, true);
            _flexM.SetCol("am_budget", "광고수주액", 100, true, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("am_agy_price", "대행사수수료", 100, true, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("am_income", "영업수익(매출)", 100, true, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("am_media_price", "매체수익", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);

            _flexM.SetCol("ay_year", "년", 0, false);

            _flexM.Cols["tp_sales"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["cd_acct"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["ay_year_month"].TextAlign = TextAlignEnum.LeftCenter;
            _flexM.Cols["ay_trade_type"].TextAlign = TextAlignEnum.CenterCenter;

            _flexM.Cols["ay_agencyno"].Format = _flexM.Cols["ay_agencyno"].EditMask = "###-##-#####";
            _flexM.Cols["ay_agencyno"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.SetStringFormatCol("ay_agencyno");
            _flexM.SetNoMaskSaveCol("ay_agencyno");

            _flexM.Cols["me_year_month"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["me_trade_type"].TextAlign = TextAlignEnum.CenterCenter;

            _flexM.Cols["me_corpno"].Format = _flexM.Cols["me_corpno"].EditMask = "###-##-#####";
            _flexM.Cols["me_corpno"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.SetStringFormatCol("me_corpno");
            _flexM.SetNoMaskSaveCol("me_corpno");

            _flexM.Cols["nm_mediagr"].TextAlign = TextAlignEnum.LeftCenter;

            _flexM.SetDummyColumn("S");
            _flexM.Cols.Frozen = 1;

            //MERGE 처리
            _flexM[0, "ay_year_month"] = _flexM[0, "AGE"] = "대행사";
            _flexM[0, "me_trade_type"] = _flexM[0, "AGE"] = "대행사";
            _flexM[0, "ay_agencyno"] = _flexM[0, "AGE"] = "대행사";
            _flexM[0, "ay_agencyid"] = _flexM[0, "AGE"] = "대행사";
            _flexM[0, "ay_agencynm"] = _flexM[0, "AGE"] = "대행사";

            //MERGE 처리
            _flexM[0, "me_year_month"] = _flexM[0, "MED"] = "매체";
            _flexM[0, "me_trade_type"] = _flexM[0, "MED"] = "매체";
            _flexM[0, "me_corpno"] = _flexM[0, "MED"] = "매체";
            _flexM[0, "me_corpid"] = _flexM[0, "MED"] = "매체";
            _flexM[0, "me_corpnm"] = _flexM[0, "MED"] = "매체";
            _flexM[0, "nm_mediagr"] = _flexM[0, "MED"] = "매체";

            _flexM.SettingVersion = "1.0.1.8";// new Random().Next().ToString();
            _flexM.EndSetting(GridStyleEnum.Green, AllowSortingEnum.MultiColumn, SumPositionEnum.Top);

            //_flexM.SetCodeHelpCol("CD_DEPT", HelpID.P_MA_DEPT_SUB, ShowHelpEnum.Always, new string[] { "CD_DEPT", "NM_DEPT" }, new string[] { "CD_DEPT", "NM_DEPT" }, ResultMode.FastMode);
            _flexM.SetCodeHelpCol("ay_agencyno", HelpID.P_MA_PARTNER_SUB, ShowHelpEnum.Always, new string[] { "ay_agencyno", "ay_agencyid", "ay_agencynm" }, new string[] { "no_company", "cd_partner", "ln_partner" }, ResultMode.FastMode);
            _flexM.SetCodeHelpCol("me_corpno", HelpID.P_MA_PARTNER_SUB, ShowHelpEnum.Always, new string[] { "me_corpno", "me_corpid", "me_corpnm" }, new string[] { "no_company", "cd_partner", "ln_partner" }, ResultMode.FastMode);
            _flexM.SetCodeHelpCol("me_teamnm", HelpID.P_MA_DEPT_SUB, ShowHelpEnum.Always, new string[] { "me_teamid", "me_teamnm" }, new string[] { "cd_dept", "nm_dept" }, ResultMode.FastMode);
            _flexM.SetCodeHelpCol("cpname", "H_CZ_CP_SUB", ShowHelpEnum.Always, new string[] { "cpid", "cpname" }, new string[] { "cpid", "cpname" });

            //rdo컷.CheckedChanged += new EventHandler(rdo컷_CheckedChanged);
            //_flexM.StartEdit += new RowColEventHandler(_flexM_StartEdit);
            _flexM.AfterEdit += new RowColEventHandler(_flexM_AfterEdit);
            _flexM.BeforeCodeHelp += new BeforeCodeHelpEventHandler(_flexM_BeforeCodeHelp);
            //_flexM.OwnerDrawCell += new OwnerDrawCellEventHandler(_flexM_OwnerDrawCell);

            //20200720 Null Check 임시추가
            _flexM.VerifyNotNull = new string[] { "cpid", "ay_year_month", "ay_trade_type", "ay_agencyid", "me_corpid", "me_teamid", "am_budget", "am_agy_price", "am_income", "am_media_price" };
            //_flexM.VerifyNotNull = new string[] { "CD_COMPANY", "TP_SALES", "MER_REQ_NO", "cpid", "NM_CPID", "ME_SEQ", "AY_YEAR_MONTH", "AY_TRADE_TYPE", "AY_AGENCYID", "AY_TRADE_TYPE", "ME_CORPID", "ME_YEAR_MONTH", "ME_TRADE_TYPE", "ME_TEAMID", "CD_ACCT", "AM_BUDGET", "AM_AGY_PRICE", "AM_INCOME", "AM_MEDIA_PRICE", "CP_AGENTID" };
        }

        #endregion

        #region -> InitPaint

        protected override void InitPaint()
        {
            base.InitPaint();

            //Grant.CanDelete = false;
            //Grant.CanAdd = false;
            //Grant.CanPrint = false;

            btn복구처리.Click += new EventHandler(btn복구처리_Click);

            DateTime time = this.MainFrameInterface.GetDateTimeToday(); // 오늘 날짜

            today = time.ToString("yyyMMdd");
            toyear = today.Substring(0, 4);

            dp년도.Text = toyear;

            SetControl set = new SetControl();

            set.SetCombobox(cbo등록구분, MA.GetCodeUser(new string[] { "2", "9" }, new string[] { DD("전기이월수정"), DD("삭제내역") }));

            //콤보박스 셋팅
            //DataTable dt계정코드 = _biz.Get계정코드();
            //_flexM.SetDataMap("CD_ACCT", dt계정코드.Copy(), "CODE", "NAME");
            _flexM.SetDataMap("cd_acct", MA.GetCode("CZ_ME_C008"), "CODE", "NAME");
            _flexM.SetDataMap("tp_sales", MA.GetCode("CZ_ME_C005"), "CODE", "NAME");
            _flexM.SetDataMap("ay_trade_type", MA.GetCode("CZ_ME_C004"), "CODE", "NAME");
            _flexM.SetDataMap("me_trade_type", MA.GetCode("CZ_ME_C004"), "CODE", "NAME");

            //페이지 로드 시 첫번 컷오프이므로 해당 컬럼 들 editing false 설정
            _flexM.Cols["cpname"].AllowEditing = false;
            _flexM.Cols["ay_year_month"].AllowEditing = false;
            _flexM.Cols["me_year_month"].AllowEditing = false;

            //페이지 오픈 시 조회할 수 있도록 처리
            object[] Params = new object[5];
            Params[0] = LoginInfo.CompanyCode;
            Params[1] = cbo등록구분.SelectedValue; //tp_sales
            Params[2] = dp년도.Text;  //조회연월 FROM
            Params[3] = dp년도.Text; //조회연월 TO
            Params[4] = txt캠페인명.Text; //캠페인명

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
                //삭제내역은 수정할 수 없도록 처리
                if (cbo등록구분.SelectedValue.ToString().Equals("2"))
                {
                    _flexM.Cols["cpname"].AllowEditing = true;
                    _flexM.Cols["ay_year_month"].AllowEditing = true;
                    _flexM.Cols["me_year_month"].AllowEditing = true;
                }
                else
                {
                    _flexM.Cols["cpname"].AllowEditing = false;
                    _flexM.Cols["ay_year_month"].AllowEditing = false;
                    _flexM.Cols["me_year_month"].AllowEditing = false;
                }

                //_flexM.Binding = _biz.GetLineTable();
                object[] Params = new object[5];
                Params[0] = LoginInfo.CompanyCode;
                Params[1] = cbo등록구분.SelectedValue; //tp_sales
                Params[2] = dp년도.Text;  //조회연월 FROM
                Params[3] = dp년도.Text; //조회연월 TO
                Params[4] = txt캠페인명.Text; //캠페인명

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
                        //삭제내역은 수정할 수 없도록 처리
                        if (cbo등록구분.SelectedValue.ToString().Equals("2"))
                        {
                            _flexM.Cols["cpname"].AllowEditing = true;
                            _flexM.Cols["ay_year_month"].AllowEditing = true;
                            _flexM.Cols["me_year_month"].AllowEditing = true;
                        }
                        else
                        {
                            _flexM.Cols["cpname"].AllowEditing = false;
                            _flexM.Cols["ay_year_month"].AllowEditing = false;
                            _flexM.Cols["me_year_month"].AllowEditing = false;
                        }

                        //_flexM.Binding = _biz.GetLineTable();
                        object[] Params = new object[5];
                        Params[0] = LoginInfo.CompanyCode;
                        Params[1] = cbo등록구분.SelectedValue; //tp_sales
                        Params[2] = dp년도.Text;  //조회연월 FROM
                        Params[3] = dp년도.Text; //조회연월 TO
                        Params[4] = txt캠페인명.Text; //캠페인명

                        DataSet ds = _biz.Search_M(Params);

                        _flexM.Binding = ds.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {

                MsgEnd(ex);
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
            try
            {
                if (!_flexM.HasNormalRow)
                    return;

                if (_flexM.GetCheckedRows("S") == null)
                {
                    ShowMessage("삭제할 자료가 선택 되지 않았습니다.");
                    return;
                }

                for (int i = _flexM.Rows.Count - 1; i >= _flexM.Rows.Fixed; i--)
                {
                    if (_flexM.RowState(i) == DataRowState.Deleted)
                        continue;

                    if (_flexM[i, "S"].ToString().Equals("Y"))
                    {
                        _flexM.RemoveItem(i);
                    }
                }
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
                _flexM.Rows.Add();
                _flexM.Row = _flexM.Rows.Count - 1;

                //삭제내역은 수정할 수 없도록 처리
                if (cbo등록구분.SelectedValue.ToString().Equals("2"))
                {
                    _flexM[_flexM.Row, "tp_sales"] = "2";
                    _flexM[_flexM.Row, "cd_acct"] = "1";
                    _flexM[_flexM.Row, "me_year_month"] = dp년도.Text + "01";
                    _flexM[_flexM.Row, "me_trade_type"] = "1";
                    _flexM[_flexM.Row, "ay_year"] = dp년도.Text + "01";
                }

                _flexM.AddFinished();
                _flexM.Col = _flexM.Cols.Fixed;
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }

        }

        #endregion

        #endregion

        #region ♥ 기타 이벤트

        private void btn행복사_Click(object sender, EventArgs e)
        {
            try
            {
                int preIndex = 0;

                preIndex = _flexM.Row;

                if (_flexM.DataTable.Rows.Count > 0)
                {
                    _flexM.Rows.Add();
                    _flexM.Row = _flexM.Rows.Count - 1;

                    _flexM[_flexM.Row, "tp_sales"] = _flexM[preIndex, "tp_sales"];
                    _flexM[_flexM.Row, "cd_acct"] = _flexM[preIndex, "cd_acct"];
                    _flexM[_flexM.Row, "cpid"] = _flexM[preIndex, "cpid"];
                    _flexM[_flexM.Row, "cpname"] = _flexM[preIndex, "cpname"];

                    _flexM[_flexM.Row, "ay_year_month"] = _flexM[preIndex, "ay_year_month"];
                    _flexM[_flexM.Row, "ay_trade_type"] = _flexM[preIndex, "ay_trade_type"];
                    _flexM[_flexM.Row, "ay_agencyno"] = _flexM[preIndex, "ay_agencyno"];
                    _flexM[_flexM.Row, "ay_agencyid"] = _flexM[preIndex, "ay_agencyid"];
                    _flexM[_flexM.Row, "ay_agencynm"] = _flexM[preIndex, "ay_agencynm"];

                    _flexM[_flexM.Row, "me_year_month"] = _flexM[preIndex, "me_year_month"];
                    _flexM[_flexM.Row, "me_trade_type"] = _flexM[preIndex, "me_trade_type"];
                    _flexM[_flexM.Row, "me_corpno"] = _flexM[preIndex, "me_corpno"];
                    _flexM[_flexM.Row, "me_corpid"] = _flexM[preIndex, "me_corpid"];
                    _flexM[_flexM.Row, "me_corpnm"] = _flexM[preIndex, "me_corpnm"];
                    _flexM[_flexM.Row, "nm_mediagr"] = _flexM[preIndex, "nm_mediagr"];

                    _flexM[_flexM.Row, "me_teamid"] = _flexM[preIndex, "me_teamid"];
                    _flexM[_flexM.Row, "me_teamnm"] = _flexM[preIndex, "me_teamnm"];
                    _flexM[_flexM.Row, "ay_year"] = dp년도.Text + "01";

                }
                else
                {
                    ShowMessage(공통메세지.선택된자료가없습니다);
                    return;
                }

                _flexM.AddFinished();
                _flexM.Col = _flexM.Cols.Fixed;
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }

        private void btn복구처리_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow[] ldrchk = _flexM.DataTable.Select("S = 'Y'", "", DataViewRowState.CurrentRows);

                if (ldrchk == null || ldrchk.Length == 0)
                {
                    ShowMessage(공통메세지.선택된자료가없습니다);
                    return;
                }

                if (ShowMessage(" 이월처리하시겠습니까?", "QY2") == DialogResult.Yes)
                {
                    for (int i = 2; i < _flexM.Rows.Count; i++)
                    {
                        if (_flexM[i, "S"].ToString().Equals("Y"))
                        {
                            string 캠페인코드 = _flexM[i, "cpid"].ToString();
                            string 순번 = _flexM[i, "seq"].ToString();
                            string 구분 = "";

                            //삭제내역은 수정할 수 없도록 처리
                            if (cbo등록구분.SelectedValue.ToString().Equals("2"))
                            {
                                구분 = "이월복구";
                            }
                            else
                            {
                                구분 = "삭제복구";
                            }

                            if (_biz.Update_Sales(구분, 캠페인코드, 순번))
                            {

                            }
                        }
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

        void _flexM_BeforeCodeHelp(object sender, BeforeCodeHelpEventArgs e)
        {
            try
            {
                if (cbo등록구분.SelectedValue.ToString().Equals("2"))
                {
                    switch (_flexM.Cols[e.Col].Name)
                    {
                        case "cpname":

                            e.Parameter.UserParams = "캠페인 도움창;H_CZ_CP_SUB;";
                            break;
                    }
                }

            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }

        void _flexM_AfterEdit(object sender, RowColEventArgs e)
        {
            try
            {
                switch (_flexM.Cols[e.Col].Name)
                {
                    case "am_budget":
                    case "am_income":
                    case "am_agy_price":
                        decimal AM_SALES_1 = D.GetDecimal(_flexM[e.Row, "am_budget"]);
                        decimal AM_SALES_2 = D.GetDecimal(_flexM[e.Row, "am_agy_price"]);
                        decimal AM_SALES_3 = D.GetDecimal(_flexM[e.Row, "am_income"]);

                        _flexM[e.Row, "am_media_price"] = AM_SALES_1 - AM_SALES_2 - AM_SALES_3;
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