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
        string rdo_idx = "";

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

            _flexM.SetCol("TP_SALES", "구분", 60, false);
            _flexM.SetCol("CD_ACCT", "계정과목", 120, true);
            _flexM.SetCol("ME_CPID", "캠페인", 60, false);
            _flexM.SetCol("NM_CPID", "캠페인명", 160, true);

            _flexM.SetCol("AY_YEAR_MONTH", "월", 60, true, typeof(string), FormatTpType.YEAR_MONTH);
            _flexM.SetCol("AY_TRADE_TYPE", "기준", 60, true);
            _flexM.SetCol("AY_AGENCYNO", "사업자등록번호", 100, true);
            _flexM.SetCol("AY_AGENCYID", "대행사코드", 0, false);
            _flexM.SetCol("AY_AGENCYNM", "대행사명", 120, false);

            _flexM.SetCol("ME_YEAR_MONTH", "월", 60, true, typeof(string), FormatTpType.YEAR_MONTH);
            _flexM.SetCol("ME_TRADE_TYPE", "기준", 60, true);
            _flexM.SetCol("ME_CORPNO", "사업자등록번호", 120, true);
            _flexM.SetCol("ME_CORPID", "매체코드", 0, false);
            _flexM.SetCol("ME_CORPNM", "매체명", 120, false);
            _flexM.SetCol("CD_SYSDEF", "구분", 60, false);

            _flexM.SetCol("ME_TEAMID", "팀코드", 0, false);
            _flexM.SetCol("ME_TEAMNM", "팀명", 120, true);
            _flexM.SetCol("AM_BUDGET", "광고수주액", 100, true, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("AM_AGY_PRICE", "대행사수수료", 100, true, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("AM_INCOME", "영업수익(매출)", 100, true, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("AM_MEDIA_PRICE", "매체수익", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
           
            _flexM.SetCol("DT_YEAR", "년", 0, false);

            _flexM.Cols["TP_SALES"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["CD_ACCT"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["AY_YEAR_MONTH"].TextAlign = TextAlignEnum.LeftCenter;
            _flexM.Cols["AY_TRADE_TYPE"].TextAlign = TextAlignEnum.CenterCenter;

            _flexM.Cols["AY_AGENCYNO"].Format = _flexM.Cols["AY_AGENCYNO"].EditMask = "###-##-#####";
            _flexM.Cols["AY_AGENCYNO"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.SetStringFormatCol("AY_AGENCYNO");
            _flexM.SetNoMaskSaveCol("AY_AGENCYNO");

            _flexM.Cols["ME_YEAR_MONTH"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["ME_TRADE_TYPE"].TextAlign = TextAlignEnum.CenterCenter;

            _flexM.Cols["ME_CORPNO"].Format = _flexM.Cols["ME_CORPNO"].EditMask = "###-##-#####";
            _flexM.Cols["ME_CORPNO"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.SetStringFormatCol("ME_CORPNO");
            _flexM.SetNoMaskSaveCol("ME_CORPNO");

            _flexM.Cols["CD_SYSDEF"].TextAlign = TextAlignEnum.LeftCenter;

            _flexM.SetDummyColumn("S");
            _flexM.Cols.Frozen = 1;

            //MERGE 처리
            _flexM[0, "AY_YEAR_MONTH"] = _flexM[0, "AGE"] = "대행사";
            _flexM[0, "ME_TRADE_TYPE"] = _flexM[0, "AGE"] = "대행사";
            _flexM[0, "AY_AGENCYNO"] = _flexM[0, "AGE"] = "대행사";
            _flexM[0, "AY_AGENCYID"] = _flexM[0, "AGE"] = "대행사";
            _flexM[0, "AY_AGENCYNM"] = _flexM[0, "AGE"] = "대행사";

            //MERGE 처리
            _flexM[0, "ME_YEAR_MONTH"] = _flexM[0, "MED"] = "매체";
            _flexM[0, "ME_TRADE_TYPE"] = _flexM[0, "MED"] = "매체";
            _flexM[0, "ME_CORPNO"] = _flexM[0, "MED"] = "매체";
            _flexM[0, "ME_CORPID"] = _flexM[0, "MED"] = "매체";
            _flexM[0, "ME_CORPNM"] = _flexM[0, "MED"] = "매체";
            _flexM[0, "CD_SYSDEF"] = _flexM[0, "MED"] = "매체";

            _flexM.SettingVersion = "1.0.1.7";// new Random().Next().ToString();
            _flexM.EndSetting(GridStyleEnum.Green, AllowSortingEnum.MultiColumn, SumPositionEnum.Top);

            //_flexM.SetCodeHelpCol("CD_DEPT", HelpID.P_MA_DEPT_SUB, ShowHelpEnum.Always, new string[] { "CD_DEPT", "NM_DEPT" }, new string[] { "CD_DEPT", "NM_DEPT" }, ResultMode.FastMode);
            _flexM.SetCodeHelpCol("AY_AGENCYNO", HelpID.P_MA_PARTNER_SUB, ShowHelpEnum.Always, new string[] { "AY_AGENCYNO", "AY_AGENCYID", "AY_AGENCYNM" }, new string[] { "NO_COMPANY", "CD_PARTNER", "LN_PARTNER" }, ResultMode.FastMode);
            _flexM.SetCodeHelpCol("ME_CORPNO", HelpID.P_MA_PARTNER_SUB, ShowHelpEnum.Always, new string[] { "ME_CORPNO", "ME_CORPID", "ME_CORPNM" }, new string[] { "NO_COMPANY", "CD_PARTNER", "LN_PARTNER" }, ResultMode.FastMode);
            _flexM.SetCodeHelpCol("ME_TEAMNM", HelpID.P_MA_DEPT_SUB, ShowHelpEnum.Always, new string[] { "ME_TEAMID", "ME_TEAMNM" }, new string[] { "CD_DEPT", "NM_DEPT" }, ResultMode.FastMode);
            _flexM.SetCodeHelpCol("NM_CPID", "H_CZ_CP_SUB", ShowHelpEnum.Always, new string[] { "ME_CPID", "NM_CPID" }, new string[] { "cpid", "cpname" });

            rdo컷.CheckedChanged += new EventHandler(rdo컷_CheckedChanged);
            //_flexM.StartEdit += new RowColEventHandler(_flexM_StartEdit);
            _flexM.AfterEdit += new RowColEventHandler(_flexM_AfterEdit);
            _flexM.BeforeCodeHelp += new BeforeCodeHelpEventHandler(_flexM_BeforeCodeHelp);
            //_flexM.OwnerDrawCell += new OwnerDrawCellEventHandler(_flexM_OwnerDrawCell);

            //20200720 Null Check 임시추가
            _flexM.VerifyNotNull = new string[] { "ME_CPID", "AY_YEAR_MONTH", "AY_TRADE_TYPE", "AY_AGENCYID", "ME_CORPID", "ME_TEAMID", "AM_BUDGET", "AM_AGY_PRICE", "AM_INCOME", "AM_MEDIA_PRICE" };
            //_flexM.VerifyNotNull = new string[] { "CD_COMPANY", "TP_SALES", "MER_REQ_NO", "ME_CPID", "NM_CPID", "ME_SEQ", "AY_YEAR_MONTH", "AY_TRADE_TYPE", "AY_AGENCYID", "AY_TRADE_TYPE", "ME_CORPID", "ME_YEAR_MONTH", "ME_TRADE_TYPE", "ME_TEAMID", "CD_ACCT", "AM_BUDGET", "AM_AGY_PRICE", "AM_INCOME", "AM_MEDIA_PRICE", "CP_AGENTID" };
        }

        #endregion

        #region -> InitPaint

        protected override void InitPaint()
        {
            base.InitPaint();

            //Grant.CanDelete = false;
            //Grant.CanAdd = false;
            //Grant.CanPrint = false;

            DateTime time = this.MainFrameInterface.GetDateTimeToday(); // 오늘 날짜

            today = time.ToString("yyyMMdd");
            toyear = today.Substring(0, 4);

            dp년도.Text = toyear;

            //체크박스 value 값 가져와서 조회하기 위해서
            rdo_idx = rdo컷.Checked == true ? "4" : "3";

            //콤보박스 셋팅
            //DataTable dt계정코드 = _biz.Get계정코드();
            //_flexM.SetDataMap("CD_ACCT", dt계정코드.Copy(), "CODE", "NAME");
            _flexM.SetDataMap("CD_ACCT", MA.GetCode("CZ_ME_C008"), "CODE", "NAME");
            _flexM.SetDataMap("TP_SALES", MA.GetCode("CZ_ME_C005"), "CODE", "NAME");
            _flexM.SetDataMap("AY_TRADE_TYPE", MA.GetCode("CZ_ME_C004"), "CODE", "NAME");
            _flexM.SetDataMap("ME_TRADE_TYPE", MA.GetCode("CZ_ME_C004"), "CODE", "NAME");

            //페이지 오픈 시 조회할 수 있도록 처리
            object[] Params = new object[5];
            Params[0] = LoginInfo.CompanyCode;
            Params[1] = "SELECT";
            Params[2] = dp년도.Text;
            Params[3] = rdo_idx;
            Params[4] = txt캠페인명.Text;
            DataSet ds = _biz.Search_M(Params);
            _flexM.Binding = ds.Tables[0];

            //페이지 로드 시 첫번 컷오프이므로 해당 컬럼 들 editing false 설정
            _flexM.Cols["NM_CPID"].AllowEditing = false;
            _flexM.Cols["AY_YEAR_MONTH"].AllowEditing = false;
            _flexM.Cols["ME_YEAR_MONTH"].AllowEditing = false;
        }

        #endregion

        #endregion

        #region ♥ 메인버튼 클릭

        #region -> 조회버튼클릭

        public override void OnToolBarSearchButtonClicked(object sender, EventArgs e)
        {
            try
            {
                rdo_idx = rdo컷.Checked == true ? "4" : "3";

                if (rdo_idx == "4")
                {
                    _flexM.Cols["NM_CPID"].AllowEditing = false;
                    _flexM.Cols["AY_YEAR_MONTH"].AllowEditing = false;
                    _flexM.Cols["ME_YEAR_MONTH"].AllowEditing = false;
                }
                else
                {
                    _flexM.Cols["NM_CPID"].AllowEditing = true;
                    _flexM.Cols["AY_YEAR_MONTH"].AllowEditing = true;
                    _flexM.Cols["ME_YEAR_MONTH"].AllowEditing = true;
                }

                //_flexM.Binding = _biz.GetLineTable();

                object[] Params = new object[5];
                Params[0] = LoginInfo.CompanyCode;
                Params[1] = "SELECT";
                Params[2] = dp년도.Text;
                Params[3] = rdo_idx;
                Params[4] = txt캠페인명.Text;

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
                        rdo_idx = rdo컷.Checked == true ? "4" : "3";

                        if (rdo_idx == "4")
                        {
                            _flexM.Cols["NM_CPID"].AllowEditing = false;
                            _flexM.Cols["AY_YEAR_MONTH"].AllowEditing = false;
                            _flexM.Cols["ME_YEAR_MONTH"].AllowEditing = false;
                        }
                        else
                        {
                            _flexM.Cols["NM_CPID"].AllowEditing = true;
                            _flexM.Cols["AY_YEAR_MONTH"].AllowEditing = true;
                            _flexM.Cols["ME_YEAR_MONTH"].AllowEditing = true;
                        }

                        object[] Params = new object[5];
                        Params[0] = LoginInfo.CompanyCode;
                        Params[1] = "SELECT";
                        Params[2] = dp년도.Text;
                        Params[3] = rdo_idx;
                        Params[4] = txt캠페인명.Text;

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
          
                if (rdo컷.Checked == true)
                {
                    rdo_idx = "4";

                    _flexM[_flexM.Row, "TP_SALES"] = rdo_idx;
                    _flexM[_flexM.Row, "CD_ACCT"] = "1";
                    _flexM[_flexM.Row, "ME_CPID"] = toyear + "C";
                    _flexM[_flexM.Row, "NM_CPID"] = Int32.Parse(dp년도.Text.Substring(2, 2)) - 1 + "년 컷오프";
                    _flexM[_flexM.Row, "AY_YEAR_MONTH"] = toyear + "01";
                    _flexM[_flexM.Row, "AY_TRADE_TYPE"] = "1";
                    _flexM[_flexM.Row, "ME_YEAR_MONTH"] = toyear + "01";
                    _flexM[_flexM.Row, "ME_TRADE_TYPE"] = "2";
                    _flexM[_flexM.Row, "DT_YEAR"] = dp년도.Text;
                }
                else if (rdo이월.Checked == true)
                {
                    rdo_idx = "3";

                    _flexM[_flexM.Row, "TP_SALES"] = rdo_idx;
                    _flexM[_flexM.Row, "CD_ACCT"] = "1";
                    _flexM[_flexM.Row, "ME_YEAR_MONTH"] = "1";
                    _flexM[_flexM.Row, "ME_TRADE_TYPE"] = "1";
                    _flexM[_flexM.Row, "DT_YEAR"] = dp년도.Text;
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

        private void rdo컷_CheckedChanged(object sender, EventArgs e)
        {
            rdo_idx = rdo컷.Checked == true ? "4" : "3";

            if (rdo_idx == "4")
            {
                _flexM.Cols["NM_CPID"].AllowEditing = false;
                _flexM.Cols["AY_YEAR_MONTH"].AllowEditing = false;
                _flexM.Cols["ME_YEAR_MONTH"].AllowEditing = false;
            }
            else
            {
                _flexM.Cols["NM_CPID"].AllowEditing = true;
                _flexM.Cols["AY_YEAR_MONTH"].AllowEditing = true;
                _flexM.Cols["ME_YEAR_MONTH"].AllowEditing = true;
            }

            object[] Params = new object[5];
            Params[0] = LoginInfo.CompanyCode;
            Params[1] = "SELECT";
            Params[2] = dp년도.Text;
            Params[3] = rdo_idx;
            Params[4] = txt캠페인명.Text;

            DataSet ds = _biz.Search_M(Params);

            _flexM.Binding = ds.Tables[0];
        }

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

                    _flexM[_flexM.Row, "TP_SALES"] = _flexM[preIndex, "TP_SALES"];
                    _flexM[_flexM.Row, "CD_ACCT"] = _flexM[preIndex, "CD_ACCT"];
                    _flexM[_flexM.Row, "ME_CPID"] = _flexM[preIndex, "ME_CPID"];
                    _flexM[_flexM.Row, "NM_CPID"] = _flexM[preIndex, "NM_CPID"];

                    _flexM[_flexM.Row, "AY_YEAR_MONTH"] = _flexM[preIndex, "AY_YEAR_MONTH"];
                    _flexM[_flexM.Row, "AY_TRADE_TYPE"] = _flexM[preIndex, "AY_TRADE_TYPE"];
                    _flexM[_flexM.Row, "AY_AGENCYNO"] = _flexM[preIndex, "AY_AGENCYNO"];
                    _flexM[_flexM.Row, "AY_AGENCYID"] = _flexM[preIndex, "AY_AGENCYID"];
                    _flexM[_flexM.Row, "AY_AGENCYNM"] = _flexM[preIndex, "AY_AGENCYNM"];

                    _flexM[_flexM.Row, "ME_YEAR_MONTH"] = _flexM[preIndex, "ME_YEAR_MONTH"];
                    _flexM[_flexM.Row, "ME_TRADE_TYPE"] = _flexM[preIndex, "ME_TRADE_TYPE"];
                    _flexM[_flexM.Row, "ME_CORPNO"] = _flexM[preIndex, "ME_CORPNO"];
                    _flexM[_flexM.Row, "ME_CORPID"] = _flexM[preIndex, "ME_CORPID"];
                    _flexM[_flexM.Row, "ME_CORPNM"] = _flexM[preIndex, "ME_CORPNM"];
                    _flexM[_flexM.Row, "CD_SYSDEF"] = _flexM[preIndex, "CD_SYSDEF"];

                    _flexM[_flexM.Row, "ME_TEAMID"] = _flexM[preIndex, "ME_TEAMID"];
                    _flexM[_flexM.Row, "ME_TEAMNM"] = _flexM[preIndex, "ME_TEAMNM"];
                    _flexM[_flexM.Row, "DT_YEAR"] = dp년도.Text;
                 
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

        #endregion

        #region ♥ 그리드 이벤트

        void _flexM_BeforeCodeHelp(object sender, BeforeCodeHelpEventArgs e)
        {
            try
            {
                rdo_idx = rdo컷.Checked == true ? "4" : "3";

                if (rdo_idx == "3")
                {
                    switch (_flexM.Cols[e.Col].Name)
                    {
                        case "NM_CPID":

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
                    case "AM_BUDGET":
                    case "AM_INCOME":
                    case "AM_AGY_PRICE":
                        decimal AM_SALES_1 = D.GetDecimal(_flexM[e.Row, "AM_BUDGET"]);
                        decimal AM_SALES_2 = D.GetDecimal(_flexM[e.Row, "AM_AGY_PRICE"]);
                        decimal AM_SALES_3 = D.GetDecimal(_flexM[e.Row, "AM_INCOME"]);

                        _flexM[e.Row, "AM_MEDIA_PRICE"] = AM_SALES_1 - AM_SALES_2 - AM_SALES_3;
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