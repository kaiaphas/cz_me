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
    // 작성일 : 2020-07-07
    // 모듈명 : 퍼블리셔 등록
    // 페이지 : P_CZ_ME_SALES_PUB
    // **************************************

    public partial class P_CZ_ME_SALES_REPORT : PageBase
    {
        #region ♥ 멤버필드

        private P_CZ_ME_SALES_REPORT_BIZ _biz = new P_CZ_ME_SALES_REPORT_BIZ();
        bool _타메뉴호출 = false;

        string today = "";
        string toyear = "";
        string rdo_idx = "";
        #endregion

        #region ♥ 초기화

        #region -> 생성자

        public P_CZ_ME_SALES_REPORT()
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
            _flexM.BeginSetting(1, 1, false);
            _flexM_Sum.BeginSetting(1, 1, false);
            //_flexM.SetCol("S", "선택", 35, true, CheckTypeEnum.Y_N);
            _flexM.SetCol("idx", "계정명", 0, false);

            _flexM.SetCol("media_type", "계정명", 110, false);
            _flexM.SetCol("cp_date", "월", 60, false, typeof(string), FormatTpType.YEAR_MONTH);
            _flexM.SetCol("cp_trade_type", "종류", 40, false);
            _flexM.SetCol("cpid", "캠페인ID", 60, false);
            _flexM.SetCol("cpname", "캠페인명", 130, false);

            _flexM.SetCol("agent_name", "광고주", 130, false);

            _flexM.SetCol("am_etc", "기타매출", 100, false, typeof(decimal), FormatTpType.MONEY);
            _flexM.SetCol("am_budget", "광고수주액", 100, false, typeof(decimal), FormatTpType.MONEY);
            _flexM.SetCol("am_adev", "디지털광고료", 100, false, typeof(decimal), FormatTpType.MONEY);
            _flexM.SetCol("am_adev_dif", "순액차이", 100, false, typeof(decimal), FormatTpType.MONEY);
            _flexM.SetCol("am_adev_tax", "광고대행수수료", 100, false, typeof(decimal), FormatTpType.MONEY);
            _flexM.SetCol("am_adev_tax_for", "광고대행수수료이월발행", 100, false, typeof(decimal), FormatTpType.MONEY);
            _flexM.SetCol("am_adev_int_for", "인터넷광고료이월발행", 100, false, typeof(decimal), FormatTpType.MONEY);

            _flexM.SetCol("am_net", "네트워크광고료", 100, false, typeof(decimal), FormatTpType.MONEY);
            _flexM.SetCol("am_net_dif", "순액차이", 100, false, typeof(decimal), FormatTpType.MONEY);
            _flexM.SetCol("am_net_tax", "네트워크광고대행사수수료", 100, false, typeof(decimal), FormatTpType.MONEY);
            _flexM.SetCol("am_net_int_for", "네트워크광고대행사수수료이월발행", 100, false, typeof(decimal), FormatTpType.MONEY);

            _flexM.SetCol("med_date", "월", 60, false, typeof(string), FormatTpType.YEAR_MONTH);
            _flexM.SetCol("med_trade_type", "종류", 40, false);
            //_flexM.SetCol("med_biz_name", "담당자", 80, false);
            //_flexM.SetCol("me_corpid", "매체ID", 0, false);
            _flexM.SetCol("med_biz_name", "매체", 130, false);

            _flexM.SetCol("am_proxy", "대행수수료", 100, false, typeof(decimal), FormatTpType.MONEY);
            _flexM.SetCol("am_proxy_dif", "순액차이", 100, false, typeof(decimal), FormatTpType.MONEY);
            _flexM.SetCol("am_proxy_tax", "매체광고료", 100, false, typeof(decimal), FormatTpType.MONEY);
            //_flexM.SetCol("am_proxy_tax_for", "매체광고료(세금계산서미발행)", 100, false, typeof(decimal), FormatTpType.MONEY);
            _flexM.SetCol("am_proxy_tax_for", "대행수수료이월발행", 100, false, typeof(decimal), FormatTpType.MONEY);
            _flexM.SetCol("am_proxy_int_for", "매체광고료이월발행", 100, false, typeof(decimal), FormatTpType.MONEY);

            _flexM.SetCol("am_netpro", "네트워크대행수수료", 100, false, typeof(decimal), FormatTpType.MONEY);
            _flexM.SetCol("am_netpro_dif", "순액차이", 100, false, typeof(decimal), FormatTpType.MONEY);
            _flexM.SetCol("am_netpro_tax", "네트워크매체광고료", 100, false, typeof(decimal), FormatTpType.MONEY);
            _flexM.SetCol("am_netpro_tax_for", "네트워크대행수수료이월발행", 100, false, typeof(decimal), FormatTpType.MONEY);
            _flexM.SetCol("am_netpro_int_for", "네트워크매체광고료이월발행", 100, false, typeof(decimal), FormatTpType.MONEY);
            _flexM.SetCol("am_media_price", "매출총이익", 100, false, typeof(decimal), FormatTpType.MONEY);

            _flexM.Cols["media_type"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["cp_date"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["cp_trade_type"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["med_date"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["med_trade_type"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["cpid"].TextAlign = TextAlignEnum.CenterCenter;

            //_flexM.SetDummyColumn("S");

            _flexM.Cols.Frozen = 1;

            _flexM.SettingVersion = "1.0.2.9";// new Random().Next().ToString();
            _flexM.EndSetting(GridStyleEnum.Green, AllowSortingEnum.MultiColumn, SumPositionEnum.Top);

            _flexM_Sum.SetCol("idx", "구분", 160, false);

            _flexM_Sum.SetCol("am_etc", "기타매출", 100, false, typeof(decimal), FormatTpType.MONEY);
            _flexM_Sum.SetCol("am_budget", "광고수주액", 100, false, typeof(decimal), FormatTpType.MONEY);
            _flexM_Sum.SetCol("am_adev", "디지털광고료", 100, false, typeof(decimal), FormatTpType.MONEY);
            _flexM_Sum.SetCol("am_adev_dif", "순액차이", 100, false, typeof(decimal), FormatTpType.MONEY);
            _flexM_Sum.SetCol("am_adev_tax", "광고대행수수료", 100, false, typeof(decimal), FormatTpType.MONEY);
            _flexM_Sum.SetCol("am_adev_tax_for", "광고대행수수료이월발행", 100, false, typeof(decimal), FormatTpType.MONEY);
            _flexM_Sum.SetCol("am_adev_int_for", "인터넷광고료이월발행", 100, false, typeof(decimal), FormatTpType.MONEY);

            _flexM_Sum.SetCol("am_net", "네트워크광고료", 100, false, typeof(decimal), FormatTpType.MONEY);
            _flexM_Sum.SetCol("am_net_dif", "순액차이", 100, false, typeof(decimal), FormatTpType.MONEY);
            _flexM_Sum.SetCol("am_net_tax", "네트워크광고대행사수수료", 100, false, typeof(decimal), FormatTpType.MONEY);
            _flexM_Sum.SetCol("am_net_int_for", "네트워크광고대행사수수료이월발행", 100, false, typeof(decimal), FormatTpType.MONEY);

            _flexM_Sum.SetCol("am_proxy", "대행수수료", 100, false, typeof(decimal), FormatTpType.MONEY);
            _flexM_Sum.SetCol("am_proxy_dif", "순액차이", 100, false, typeof(decimal), FormatTpType.MONEY);
            _flexM_Sum.SetCol("am_proxy_tax", "매체광고료", 100, false, typeof(decimal), FormatTpType.MONEY);
            //_flexM.SetCol("am_proxy_tax_for", "매체광고료(세금계산서미발행)", 100, false, typeof(decimal), FormatTpType.MONEY);
            _flexM_Sum.SetCol("am_proxy_tax_for", "대행수수료이월발행", 100, false, typeof(decimal), FormatTpType.MONEY);
            _flexM_Sum.SetCol("am_proxy_int_for", "매체광고료이월발행", 100, false, typeof(decimal), FormatTpType.MONEY);

            _flexM_Sum.SetCol("am_netpro", "네트워크대행수수료", 100, false, typeof(decimal), FormatTpType.MONEY);
            _flexM_Sum.SetCol("am_netpro_dif", "순액차이", 100, false, typeof(decimal), FormatTpType.MONEY);
            _flexM_Sum.SetCol("am_netpro_tax", "네트워크매체광고료", 100, false, typeof(decimal), FormatTpType.MONEY);
            _flexM_Sum.SetCol("am_netpro_tax_for", "네트워크대행수수료이월발행", 100, false, typeof(decimal), FormatTpType.MONEY);
            _flexM_Sum.SetCol("am_netpro_int_for", "네트워크매체광고료이월발행", 100, false, typeof(decimal), FormatTpType.MONEY);
            _flexM_Sum.SetCol("am_media_price", "매출총이익", 100, false, typeof(decimal), FormatTpType.MONEY);

            _flexM_Sum.Cols.Frozen = 1;

            _flexM_Sum.SettingVersion = "1.0.0.3";// new Random().Next().ToString();
            _flexM_Sum.EndSetting(GridStyleEnum.Green, AllowSortingEnum.MultiColumn, SumPositionEnum.None);

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

        #region -> InitPaint

        protected override void InitPaint()
        {
            base.InitPaint();

            Grant.CanDelete = false;
            Grant.CanAdd = false;
            Grant.CanPrint = false;

            DateTime time = this.MainFrameInterface.GetDateTimeToday(); // 오늘 날짜

            today = time.ToString("yyyMMdd");
            toyear = today.Substring(0, 6);

            dp년도.Text = toyear;

            //콤보박스 셋팅
            //DataTable dt계정코드 = _biz.Get계정코드();
            //_flexM.SetDataMap("CD_ACCT", dt계정코드.Copy(), "CODE", "NAME");
            _flexM.SetDataMap("media_type", MA.GetCode("CZ_ME_C008"), "CODE", "NAME");
            _flexM.SetDataMap("cp_trade_type", MA.GetCode("CZ_ME_C004"), "CODE", "NAME");
            _flexM.SetDataMap("med_trade_type", MA.GetCode("CZ_ME_C004"), "CODE", "NAME");
        }

        #endregion

        #endregion

        #region ♥ 메인버튼 클릭

        #region -> 조회버튼클릭

        public override void OnToolBarSearchButtonClicked(object sender, EventArgs e)
        {
            try
            {
                object[] Params = new object[4];
                Params[0] = LoginInfo.CompanyCode;
                Params[1] = dp년도.Text;
                Params[2] = dp년도.Text;
                Params[3] = txt캠페인명.Text;

                DataSet ds = _biz.Search_M(Params);

                _flexM.Binding = ds.Tables[0];

                DataSet ds2 = _biz.Search_M_Sum(Params);

                _flexM_Sum.Binding = ds2.Tables[0];

                string DT_DATE = dp년도.Text;

                DataTable dt = _biz.Get결산일시(DT_DATE);

                lbl결산일시.Text = "동기화 시간 : " + dt.Rows[0]["DT_CLOSING"].ToString();
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
                        object[] Params = new object[4];
                        Params[0] = LoginInfo.CompanyCode;
                        Params[1] = dp년도.Text;
                        Params[2] = dp년도.Text;
                        Params[3] = txt캠페인명.Text;

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
              /*
                for (int i = _flexM.Rows.Fixed; i < _flexM.Rows.Count; i++)
                {
                    if (D.GetString(_flexM.Rows[i]["NO_DOCU_M"]).Length != 0)
                    {
                        ShowMessage("수주전표가 이미 발행되었습니다.");
                        return false;
                    }

                    if (D.GetString(_flexM.Rows[i]["NO_DOCU_C"]).Length == 0 && _flexM[i, "S1"].ToString().Equals("Y"))
                    {
                        ShowMessage("수수료 전표가 발행되지 않았습니다.");
                        return false;
                    }
                }
                */
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

                    _flexM.RemoveItem(i);             
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

                //_flexM[_flexM.Row, "ME_YEAR_MONTH"] = toyear + "01";
                //_flexM[_flexM.Row, "ME_TRADE_TYPE"] = "1";

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

        #endregion

        #region ♥ 그리드 이벤트

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
                    case "S":
                        _flexM[e.Row, "S1"] = "N";
                        _flexM[e.Row, "S2"] = "N";
                        break;
                    case "S1":
                        _flexM[e.Row, "S"] = "N";
                        _flexM[e.Row, "S2"] = "N";
                        break;
                    case "S2":
                        _flexM[e.Row, "S"] = "N";
                        _flexM[e.Row, "S1"] = "N";
                        break;
                }
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }

        void _flexM_HelpClick(object sender, EventArgs e)
        {
            if (_flexM.Cols[_flexM.Col].Name == "S")
                return;

            string 전표번호 = D.GetString(_flexM["NO_DOCU"]);

            if (전표번호 == "")
                return;

            object[] Args = { 전표번호, "", "", Global.MainFrame.LoginInfo.CompanyCode };
            CallOtherPageMethod("P_FI_DOCU", "전표입력(" + PageName + ")", Grant, Args);
        }

        private void _flexM_OwnerDrawCell(object sender, OwnerDrawCellEventArgs e)
        {
            CellRange rg;

            if (!_flexM.HasNormalRow)
                return;

            if (e.Row < _flexM.Rows.Fixed || e.Col < _flexM.Cols.Fixed)
                return;

            if (D.GetString(_flexM[e.Row, "TP_INDEX"]) == "자료변경")
            {
                CellStyle csCellstyle = _flexM.Styles.Add("CellStyle");
                csCellstyle.BackColor = System.Drawing.Color.FromArgb(((Byte)(255)), ((Byte)(230)), ((Byte)(230)));

                _flexM.Rows[e.Row].Style = csCellstyle;

                if (D.GetString(_flexM[e.Row, "AM_BUDGET"]) != D.GetString(_flexM[e.Row, "PUB_BUDGET"]))
                {
                    rg = _flexM.GetCellRange(e.Row, "AM_BUDGET");
                    rg.StyleNew.ForeColor = System.Drawing.Color.Red;
                }

                if (D.GetString(_flexM[e.Row, "AM_AGY_PRICE"]) != D.GetString(_flexM[e.Row, "PUB_AGY_PRICE"]))
                {
                    rg = _flexM.GetCellRange(e.Row, "AM_AGY_PRICE");
                    rg.StyleNew.ForeColor = System.Drawing.Color.Red;
                }

                if (D.GetString(_flexM[e.Row, "AM_MEDIA_PRICE"]) != D.GetString(_flexM[e.Row, "PUB_MEDIA_PRICE"]))
                {
                    rg = _flexM.GetCellRange(e.Row, "AM_MEDIA_PRICE");
                    rg.StyleNew.ForeColor = System.Drawing.Color.Red;
                }

            }
        }

        #endregion

        #region ♥ 기타 Property
        string ServerKey { get { return Global.MainFrame.ServerKeyCommon.ToUpper(); } }
        #endregion
    }
}