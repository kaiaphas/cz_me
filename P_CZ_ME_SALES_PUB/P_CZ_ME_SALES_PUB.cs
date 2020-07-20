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

    public partial class P_CZ_ME_SALES_PUB : PageBase
    {
        #region ♥ 멤버필드

        private P_CZ_ME_SALES_PUB_BIZ _biz = new P_CZ_ME_SALES_PUB_BIZ();
        bool _타메뉴호출 = false;

        string today = "";
        string toyear = "";
        string rdo_idx = "";
        #endregion

        #region ♥ 초기화

        #region -> 생성자

        public P_CZ_ME_SALES_PUB()
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

            _flexM.SetCol("S", "선택", 35, true, CheckTypeEnum.Y_N);

            _flexM.SetCol("TP_SALES", "구분", 0, false);
            _flexM.SetCol("ME_SEQ", "번호", 0, false);
            _flexM.SetCol("ME_YEAR_MONTH", "발행월", 60, false, typeof(string), FormatTpType.YEAR_MONTH);
            _flexM.SetCol("ME_TRADE_TYPE", "기준", 60, false);

            _flexM.SetCol("ME_CORPNO", "사업자등록번호", 100, false);
            _flexM.SetCol("ME_CORPID", "사업자코드", 0, false);
            _flexM.SetCol("ME_CORPNM", "사업자명", 120, false);

            _flexM.SetCol("AM_BUDGET", "수주액", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("AM_AGY_PRICE", "수수료", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("AM_MEDIA_PRICE", "매체수익", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);

            _flexM.SetCol("TP_INDEX", "상태", 60, false);

            _flexM.SetCol("DT_SYNC", "동기화일시", 130, false);
            _flexM.SetCol("DT_JUNPYO", "전표처리일시", 130, false);
            _flexM.SetCol("NO_DOCU", "전표번호", 100, false);

            _flexM.Cols["TP_INDEX"].TextAlign = TextAlignEnum.CenterCenter;
            //_flexM.Cols["TP_SALES"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["ME_YEAR_MONTH"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["ME_TRADE_TYPE"].TextAlign = TextAlignEnum.CenterCenter;

            _flexM.Cols["ME_CORPNO"].Format = _flexM.Cols["ME_CORPNO"].EditMask = "###-##-#####";
            _flexM.Cols["ME_CORPNO"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.SetStringFormatCol("ME_CORPNO");
            _flexM.SetNoMaskSaveCol("ME_CORPNO");

            _flexM.Cols["DT_JUNPYO"].Format = _flexM.Cols["DT_JUNPYO"].EditMask = "####-##-## ##:##:##";
            _flexM.Cols["DT_JUNPYO"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.SetStringFormatCol("DT_JUNPYO");
            _flexM.SetNoMaskSaveCol("DT_JUNPYO");

            _flexM.Cols["DT_SYNC"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["DT_JUNPYO"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["NO_DOCU"].TextAlign = TextAlignEnum.CenterCenter;

            _flexM.SetDummyColumn("S");

            _flexM.SetDummyColumn("DT_SYNC");
            _flexM.SetDummyColumn("DT_JUNPYO");
            _flexM.SetDummyColumn("NO_DOCU");

            _flexM.Cols.Frozen = 1;

            _flexM.SettingVersion = "1.0.0.8";// new Random().Next().ToString();
            _flexM.EndSetting(GridStyleEnum.Green, AllowSortingEnum.MultiColumn, SumPositionEnum.Top);

            //_flexM.SetCodeHelpCol("CD_DEPT", HelpID.P_MA_DEPT_SUB, ShowHelpEnum.Always, new string[] { "CD_DEPT", "NM_DEPT" }, new string[] { "CD_DEPT", "NM_DEPT" }, ResultMode.FastMode);
            //_flexM.SetCodeHelpCol("AY_AGENCYNO", HelpID.P_MA_PARTNER_SUB, ShowHelpEnum.Always, new string[] { "AY_AGENCYNO", "AY_AGENCYID", "AY_AGENCYNM" }, new string[] { "NO_COMPANY", "CD_PARTNER", "LN_PARTNER" }, ResultMode.FastMode);

            //_flexM.StartEdit += new RowColEventHandler(_flexM_StartEdit);

            _flexM.HelpClick += new EventHandler(_flexM_HelpClick);
            _flexM.AfterEdit += new RowColEventHandler(_flexM_AfterEdit);
            //_flexM.BeforeCodeHelp += new BeforeCodeHelpEventHandler(_flexM_BeforeCodeHelp);
            //_flexM.OwnerDrawCell += new OwnerDrawCellEventHandler(_flexM_OwnerDrawCell);


            
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                rdo_idx = ((RadioButton)sender).Text;
            string[] tempstr = rdo_idx.Split('-');
            rdo_idx = tempstr[0].Trim();
        }
        #endregion

        #region -> InitPaint

        protected override void InitPaint()
        {
            base.InitPaint();

            //Grant.CanDelete = false;
            //Grant.CanAdd = false;
            //Grant.CanPrint = false;

            btn전표처리.Click += new EventHandler(btn전표처리_Click);
            btn전표삭제.Click += new EventHandler(btn전표삭제_Click);

            DateTime time = Global.MainFrame.GetDateTimeToday();

            toyear = time.ToString("yyyy") + "0101";

            dt일자.StartDate = DateTime.ParseExact(toyear, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            dt일자.EndDate = DateTime.ParseExact(toyear, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);

            //콤보박스 셋팅
            //DataTable dt계정코드 = _biz.Get계정코드();
            //_flexM.SetDataMap("CD_ACCT", dt계정코드.Copy(), "CODE", "NAME");
            _flexM.SetDataMap("ME_TRADE_TYPE", MA.GetCode("CZ_ME_C004"), "CODE", "NAME");
            //_flexM.SetDataMap("ME_TRADE_TYPE", MA.GetCode("CZ_ME_C004"), "CODE", "NAME");
            rdo전체.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            rdo미처리.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            rdo처리.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            rdo변경.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            rdo수기.CheckedChanged += new EventHandler(radioButton_CheckedChanged);

            
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
                Params[2] = dt일자.StartDateToString.Substring(0, 6);
                Params[3] = dt일자.EndDateToString.Substring(0, 6);
                Params[4] = txt명.Text;

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
                        Params[2] = dt일자.StartDateToString.Substring(0, 6);
                        Params[3] = dt일자.EndDateToString.Substring(0, 6);
                        Params[4] = txt명.Text;

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

                _flexM[_flexM.Row, "ME_YEAR_MONTH"] = toyear + "01";
                _flexM[_flexM.Row, "ME_TRADE_TYPE"] = "1";

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
        #endregion

        #region ♥ 기타 Property
        string ServerKey { get { return Global.MainFrame.ServerKeyCommon.ToUpper(); } }
        #endregion

        private void btn전표처리_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_flexM.HasNormalRow)
                    return;

                DataRow[] ldrchk = _flexM.DataTable.Select("S = 'Y'", "", DataViewRowState.CurrentRows);

                if (ldrchk == null || ldrchk.Length == 0)
                {
                    ShowMessage(공통메세지.선택된자료가없습니다);
                    return;
                }
                if (ShowMessage("선택한 데이터를 전표처리 하시겠습니까?", "QY2") == DialogResult.Yes)
                {
                    for (int i = 2; i < _flexM.Rows.Count; i++)
                    {
                        if (_flexM[i, "S"].ToString().Equals("Y") && _flexM[i, "TP_INDEX"].ToString().Equals(""))
                        {
                            string SALES_구분 = _flexM[i, "TP_SALES"].ToString();
                            string 순번 = _flexM[i, "ME_SEQ"].ToString();

                            string 거래처코드 = _flexM[i, "ME_CORPNO"].ToString();
                            string 거래처명 = _flexM[i, "ME_CORPNM"].ToString();
                            string 거래처구분 = _flexM[i, "ME_TRADE_TYPE"].ToString();
                            string 발행월 = _flexM[i, "ME_YEAR_MONTH"].ToString();

                            string PUB코드 = _flexM[i, "ME_CPID"].ToString();

                            string 수주액 = _flexM[i, "AM_BUDGET"].ToString();
                            string 수수료 = _flexM[i, "AM_AGY_PRICE"].ToString();
                            string 수익 = _flexM[i, "AM_MEDIA_PRICE"].ToString();

                            string 동기화 = _flexM[i, "DT_SYNC"].ToString();

                            //if (_biz.Save_Pub(SALES_구분, 순번, 거래처코드, 발행월, 거래처구분, PUB코드, 수주액, 수수료, 수익))
                            //{
                            //    ShowMessage("퍼블리셔 발행이 완료 되었습니다.");
                            //}

                            if (_biz.Save_Junpyo(SALES_구분, 순번, 거래처코드, 발행월, 거래처명, 거래처구분, PUB코드, 수주액, 수수료, 수익, 동기화))
                            {

                            }
                        }
                    }

                    ShowMessage("전표 처리가 완료 되었습니다.");

                    object[] Params = new object[5];
                    Params[0] = LoginInfo.CompanyCode;
                    Params[1] = "SELECT";
                    Params[2] = dt일자.StartDateToString.Substring(0, 6);
                    Params[3] = dt일자.EndDateToString.Substring(0, 6);
                    Params[4] = txt명.Text;

                    DataSet ds = _biz.Search_M(Params);

                    _flexM.Binding = ds.Tables[0];

                    SetToolBarButtonState(true, false, true, true, true);
                }
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }


        private void btn전표삭제_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_flexM.HasNormalRow)
                    return;

                DataRow[] ldrchk = _flexM.DataTable.Select("S = 'Y'", "", DataViewRowState.CurrentRows);

                if (ldrchk == null || ldrchk.Length == 0)
                {
                    ShowMessage(공통메세지.선택된자료가없습니다);
                    return;
                }

                if (ShowMessage("선택하신 전표를 삭제하시겠습니까?", "QY2") == DialogResult.Yes)
                {
                    for (int i = 2; i < _flexM.Rows.Count; i++)
                    {
                        if (_flexM[i, "S"].ToString().Equals("Y") && _flexM[i, "TP_INDEX"].ToString().Equals("전표처리"))
                        {
                            string 전표번호 = _flexM[i, "NO_DOCU"].ToString();

                            if (_biz.Delete_Junpyo(전표번호))
                            {

                            }
                        }
                    }

                    ShowMessage("전표 삭제가 완료 되었습니다.");

                    object[] Params = new object[5];
                    Params[0] = LoginInfo.CompanyCode;
                    Params[1] = "SELECT";
                    Params[2] = dt일자.StartDateToString.Substring(0, 6);
                    Params[3] = dt일자.EndDateToString.Substring(0, 6);
                    Params[4] = txt명.Text;

                    DataSet ds = _biz.Search_M(Params);

                    _flexM.Binding = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }


    }
}