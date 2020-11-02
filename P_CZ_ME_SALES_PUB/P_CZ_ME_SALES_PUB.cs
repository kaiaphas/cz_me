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
            _flexM.SetCol("ME_CORPNM", "사업자명", 150, false);
            _flexM.SetCol("AM_BUDGET", "수주액", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("AM_AGY_PRICE", "수수료", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("AM_MEDIA_PRICE", "매체수익", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("TP_INDEX", "상태", 60, false);
            _flexM.SetCol("DT_SYNC", "동기화일시", 130, false);
            _flexM.SetCol("DT_JUNPYO", "전표처리일시", 130, false);
            //_flexM.SetCol("NO_DOCU", "전표번호", 100, false);
            _flexM.SetCol("S1", "선택", 35, true, CheckTypeEnum.Y_N);
            _flexM.SetCol("NO_DOCU_M", "수주전표", 100, false);
            _flexM.SetCol("S2", "선택", 35, true, CheckTypeEnum.Y_N);
            _flexM.SetCol("NO_DOCU_C", "수수료전표", 100, false);
            _flexM.SetCol("TP_TAXSTATUS", "전자세금계산서", 100, false);
            _flexM.SetCol("NO_COMPANY", "더존거래처코드", 100, true);
            _flexM.SetCol("LN_PARTNER", "더존거래처명", 150, false);

            _flexM.SetCol("PUB_BUDGET", "전수주액", 0, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("PUB_AGY_PRICE", "전수수료", 0, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("PUB_MEDIA_PRICE", "전매체수익", 0, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);

            _flexM.Cols["TP_INDEX"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["ME_YEAR_MONTH"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["ME_TRADE_TYPE"].TextAlign = TextAlignEnum.CenterCenter;

            _flexM.Cols["ME_CORPNO"].Format = _flexM.Cols["ME_CORPNO"].EditMask = "###-##-#####";
            _flexM.Cols["ME_CORPNO"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.SetStringFormatCol("ME_CORPNO");
            _flexM.SetNoMaskSaveCol("ME_CORPNO");

            //_flexM.Cols["NO_COMPANY"].Format = _flexM.Cols["NO_COMPANY"].EditMask = "###-##-#####";
            _flexM.Cols["NO_COMPANY"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.SetStringFormatCol("NO_COMPANY");
            _flexM.SetNoMaskSaveCol("NO_COMPANY");

            _flexM.Cols["DT_JUNPYO"].Format = _flexM.Cols["DT_JUNPYO"].EditMask = "####-##-## ##:##:##";
            _flexM.Cols["DT_JUNPYO"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.SetStringFormatCol("DT_JUNPYO");
            _flexM.SetNoMaskSaveCol("DT_JUNPYO");

            _flexM.Cols["DT_SYNC"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["DT_JUNPYO"].TextAlign = TextAlignEnum.CenterCenter;
            //_flexM.Cols["NO_DOCU"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["NO_DOCU_M"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["NO_DOCU_C"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["TP_TAXSTATUS"].TextAlign = TextAlignEnum.CenterCenter;

            _flexM.SetDummyColumn("S");
            _flexM.SetDummyColumn("S1");
            _flexM.SetDummyColumn("S2");

            _flexM.Cols.Frozen = 1;

            _flexM.SettingVersion = "1.0.2.6";// new Random().Next().ToString();
            _flexM.EndSetting(GridStyleEnum.Green, AllowSortingEnum.MultiColumn, SumPositionEnum.Top);

            //_flexM.SetCodeHelpCol("CD_DEPT", HelpID.P_MA_DEPT_SUB, ShowHelpEnum.Always, new string[] { "CD_DEPT", "NM_DEPT" }, new string[] { "CD_DEPT", "NM_DEPT" }, ResultMode.FastMode);            
            //_flexM.SetCodeHelpCol("NO_COMPANY", HelpID.P_MA_PARTNER_SUB, ShowHelpEnum.Always, new string[] { "NO_COMPANY",  "ME_CORPID", "LN_PARTNER" }, new string[] { "NO_COMPANY", "BIZ_ID", "LN_PARTNER" }, ResultMode.FastMode);
            //_flexM.SetCodeHelpCol("NO_COMPANY", HelpID.P_MA_PARTNER_SUB, ShowHelpEnum.Always, new string[] { "NO_COMPANY", "LN_PARTNER" }, new string[] { "NO_COMPANY", "LN_PARTNER" }, ResultMode.FastMode);

            _flexM.SetCodeHelpCol("NO_COMPANY", HelpID.P_MA_PARTNER_SUB, ShowHelpEnum.Always, new string[] { "NO_COMPANY", "LN_PARTNER" }, new string[] { "cd_partner", "ln_partner" }, ResultMode.FastMode);

            _flexM.OwnerDrawCell += new OwnerDrawCellEventHandler(_flexM_OwnerDrawCell);
            _flexM.HelpClick += new EventHandler(_flexM_HelpClick);
            _flexM.StartEdit += new RowColEventHandler(_flexM_StartEdit);
            _flexM.AfterEdit += new RowColEventHandler(_flexM_AfterEdit);
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

            DateTime time = Global.MainFrame.GetDateTimeToday();

            toyear = time.ToString("yyyy") + "0101";

            dt일자.StartDate = DateTime.ParseExact(toyear, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            dt일자.EndDate = DateTime.ParseExact(toyear, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);

            //콤보박스 셋팅
            //DataTable dt계정코드 = _biz.Get계정코드();
            //_flexM.SetDataMap("CD_ACCT", dt계정코드.Copy(), "CODE", "NAME");
            _flexM.SetDataMap("ME_TRADE_TYPE", MA.GetCode("CZ_ME_C004"), "CODE", "NAME");
            //_flexM.SetDataMap("ME_TRADE_TYPE", MA.GetCode("CZ_ME_C004"), "CODE", "NAME");
            SetControl set = new SetControl();
            set.SetCombobox(cbo상태구분, MA.GetCodeUser(new string[] { "전체", "미처리", "전표처리", "자료변경", "수기등록" }, new string[] { DD("전체"), DD("미처리"), DD("전표처리"), DD("자료변경"), DD("수기등록") }));
            set.SetCombobox(cbo기준, MA.GetCodeUser(new string[] { "", "1", "2" }, new string[] { DD("전체"), DD("전액"), DD("순액") }));

            btn전표처리.Click += new EventHandler(btn전표처리_Click);
            btn전표삭제.Click += new EventHandler(btn전표삭제_Click);       
        }

        #endregion

        #endregion

        #region ♥ 메인버튼 클릭

        #region -> 조회버튼클릭

        public override void OnToolBarSearchButtonClicked(object sender, EventArgs e)
        {
            try
            {
                object[] Params = new object[8];
                Params[0] = LoginInfo.CompanyCode;
                Params[1] = "SELECT";
                Params[2] = dt일자.StartDateToString.Substring(0, 6);
                Params[3] = dt일자.EndDateToString.Substring(0, 6);
                Params[4] = txt명.Text;
                Params[5] = cbo상태구분.SelectedValue;
                Params[6] = cbo기준.SelectedValue;

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
                        object[] Params = new object[7];
                        Params[0] = LoginInfo.CompanyCode;
                        Params[1] = "SELECT";
                        Params[2] = dt일자.StartDateToString.Substring(0, 6);
                        Params[3] = dt일자.EndDateToString.Substring(0, 6);
                        Params[4] = txt명.Text;
                        Params[5] = cbo상태구분.SelectedValue;
                        Params[6] = cbo기준.SelectedValue;

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
            /*
            if (!_flexM.HasNormalRow)
            {
                ShowMessage("저장할 내용이 없습니다.");
                return false;
            }

            if (!_flexM.Verify())
                return false;

            return true;
            */

            // 20200720 이미 전표처리된 데이터는 전표발행이 불가능하도록 추가 (DB연동)
            for (int i = 2; i < _flexM.Rows.Count; i++)
            {
                if (_flexM[i, "S"].ToString().Equals("Y"))
                {
                    string SALES_구분 = _flexM[i, "TP_SALES"].ToString(); 
                    string PUB코드 = _flexM[i, "ME_CPID"].ToString();
                    string 순번 = _flexM[i, "ME_SEQ"].ToString();

                    object[] Params = new object[5];
                    Params[0] = LoginInfo.CompanyCode;
                    Params[1] = "SELECT";
                    Params[2] = SALES_구분;
                    Params[3] = PUB코드;
                    Params[4] = 순번;

                    DataSet ds = _biz.Search_M2(Params);
                    DataTable dt = new DataTable();
                    
                    dt = ds.Tables[0];

                    if (dt.Rows.Count == 1)
                    {
                        ShowMessage((i - 1) + "행은 이미 전표가 처리되었습니다.");
                        return false;
                    }
                }
            }
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

        /*
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                rdo_idx = ((RadioButton)sender).Text;
            string[] tempstr = rdo_idx.Split('-');
            rdo_idx = tempstr[0].Trim();
        }
        */

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
            try
            {
                if (_flexM.Cols[_flexM.Col].Name == "S")
                    return;

                string 수주전표 = D.GetString(_flexM["NO_DOCU_M"]);
                string 수수료전표 = D.GetString(_flexM["NO_DOCU_C"]);

                if (수주전표 == "" && 수수료전표 == "")
                    return;

                switch (_flexM.Cols[_flexM.Col].Name)
                {
                    case "NO_DOCU_M":

                        if (수주전표 == "")
                            return;

                        object[] Args = { 수주전표, "", "", Global.MainFrame.LoginInfo.CompanyCode };
                        CallOtherPageMethod("P_FI_DOCU", "전표입력(" + PageName + ")", Grant, Args);

                        break;

                    case "NO_DOCU_C":

                        if (수수료전표 == "")
                            return;

                        object[] Args2 = { 수수료전표, "", "", Global.MainFrame.LoginInfo.CompanyCode };
                        CallOtherPageMethod("P_FI_DOCU", "전표입력(" + PageName + ")", Grant, Args2);

                        break;
                }
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
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

            // 기준컬럼 : '순액'일 경우 글자색상 적색
            if (D.GetString(_flexM[e.Row, "ME_TRADE_TYPE"]) == "2")
            {
                rg = _flexM.GetCellRange(e.Row, "ME_TRADE_TYPE");
                rg.StyleNew.ForeColor = System.Drawing.Color.Red;
            }

            if (D.GetString(_flexM[e.Row, "PARTNER_CHK"]) == "2")
            {
                rg = _flexM.GetCellRange(e.Row, "ME_CORPNO");
                rg.StyleNew.BackColor = System.Drawing.Color.FromArgb(((Byte)(255)), ((Byte)(126)), ((Byte)(126)));
                rg = _flexM.GetCellRange(e.Row, "ME_CORPNM");
                rg.StyleNew.BackColor = System.Drawing.Color.FromArgb(((Byte)(255)), ((Byte)(126)), ((Byte)(126)));
            }
        }

        void _flexM_StartEdit(object sender, RowColEventArgs e)
        {
            switch (_flexM.Cols[_flexM.Col].Name)
            {
                case "S2":

                    //수수료전표 선택 체크박스의 경우 '순액'인 경우 비활성화 처리
                    if (D.GetString(_flexM[e.Row, "ME_TRADE_TYPE"]) == "2")
                    {
                        e.Cancel = true;
                    }

                    break;
            }
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
              
                // 20200720 이미 전표처리된 데이터는 전표발행이 불가능하도록 추가 (DB연동)
                //if (!BeforeSaveChk())
                //    return;

                DataRow[] ldrchk = _flexM.DataTable.Select("S = 'Y' or S1 = 'Y' or S2 = 'Y'", "", DataViewRowState.CurrentRows);

                if (ldrchk == null || ldrchk.Length == 0)
                {
                    ShowMessage(공통메세지.선택된자료가없습니다);
                    return;
                }

                int row_chk = 0;
                int j = 0;

                if (ShowMessage("선택한 데이터를 전표처리 하시겠습니까?", "QY2") == DialogResult.Yes)
                {
                    for (int i = 2; i < _flexM.Rows.Count; i++)
                    {
                        if ((_flexM[i, "S"].ToString().Equals("Y") || _flexM[i, "S1"].ToString().Equals("Y") || _flexM[i, "S2"].ToString().Equals("Y")))
                        {
                            if (D.GetString(_flexM.Rows[i]["NO_DOCU_M"]).Length != 0 && _flexM[i, "S2"].ToString().Equals("Y"))
                            {
                                ShowMessage((i-1) + "행은 수주전표가 발행되어 전표처리가 불가능합니다.");
                            }
                                /*
                            else if (D.GetString(_flexM.Rows[i]["NO_DOCU_C"]).Length == 0 && _flexM[i, "S1"].ToString().Equals("Y"))
                            {
                                ShowMessage((i-1) + "행은 수수료 전표가 발행되지 않아 전표처리가 불가능합니다.");
                            }
                                 */
                            else if (D.GetString(_flexM.Rows[i]["NO_DOCU_C"]).Length != 0 && _flexM[i, "S2"].ToString().Equals("Y"))
                            {
                                ShowMessage((i-1) + "행은 이미 수수료 전표가 처리되었습니다.");
                            }
                            else if (D.GetString(_flexM.Rows[i]["NO_DOCU_M"]).Length != 0 && _flexM[i, "S1"].ToString().Equals("Y"))
                            {
                                ShowMessage((i-1) + "행은 이미 수주 전표가 처리되었습니다.");
                            }
                            else if ((_flexM[i, "S"].ToString().Equals("Y") && D.GetString(_flexM.Rows[i]["NO_DOCU_M"]).Length != 0) || (_flexM[i, "S"].ToString().Equals("Y") && D.GetString(_flexM.Rows[i]["NO_DOCU_C"]).Length != 0))
                            {
                                ShowMessage((i-1) + "행은 이미 전표가 처리되어 일괄발행할 수 없습니다. 개별로 선택하여 전표처리 해주세요.");
                            }
                            else
                            {
                                string tp_job = "";

                                if (_flexM[i, "S1"].ToString().Equals("Y"))
                                {
                                    tp_job = "수주전표";
                                }
                                else if (_flexM[i, "S2"].ToString().Equals("Y"))
                                {
                                    tp_job = "수수료전표";
                                }
                                else if (_flexM[i, "S"].ToString().Equals("Y"))
                                {
                                    tp_job = "일괄발행";
                                }

                                object[] Params = new object[18];
                                Params[0] = LoginInfo.CompanyCode;
                                Params[1] = _flexM[i, "ME_CORPNO"].ToString();
                                Params[2] = _flexM[i, "ME_CORPNM"].ToString();  //조회연월 FROM
                                Params[3] = _flexM[i, "ME_TRADE_TYPE"].ToString();
                                Params[4] = _flexM[i, "AM_BUDGET"].ToString();
                                Params[5] = _flexM[i, "AM_AGY_PRICE"].ToString();
                                Params[6] = _flexM[i, "AM_MEDIA_PRICE"].ToString();
                                Params[7] = Global.MainFrame.LoginInfo.BizAreaCode;
                                Params[8] = Global.MainFrame.LoginInfo.CdPc;
                                Params[9] = Global.MainFrame.LoginInfo.DeptCode;
                                Params[10] = Global.MainFrame.LoginInfo.EmployeeNo;
                                Params[11] = _flexM[i, "TP_SALES"].ToString();
                                Params[12] = _flexM[i, "ME_CPID"].ToString();
                                Params[13] = _flexM[i, "ME_SEQ"].ToString();
                                Params[14] = _flexM[i, "ME_YEAR_MONTH"].ToString();
                                Params[15] = _flexM[i, "DT_SYNC"].ToString();
                                Params[16] = tp_job;
                                Params[17] = Global.MainFrame.LoginInfo.UserID;

                                if (_biz.Save_Junpyo(Params))
                                {
                                    if (j == 0)
                                    {
                                        row_chk = i;
                                        j = j + 1;
                                    }
                                }
                            }
                        }
                    }

                    object[] Params2 = new object[7];
                    Params2[0] = LoginInfo.CompanyCode;
                    Params2[1] = "SELECT";
                    Params2[2] = dt일자.StartDateToString.Substring(0, 6);
                    Params2[3] = dt일자.EndDateToString.Substring(0, 6);
                    Params2[4] = txt명.Text;
                    Params2[5] = cbo상태구분.SelectedValue;
                    Params2[6] = cbo기준.SelectedValue;

                    DataSet ds = _biz.Search_M(Params2);

                    _flexM.Binding = ds.Tables[0];

                    _flexM.Select(row_chk, "NO_DOCU_M"); 

                    //ShowMessage("전표 처리가 완료 되었습니다.");

                    //SetToolBarButtonState(true, false, true, true, true);
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

                DataRow[] ldrchk = _flexM.DataTable.Select("S = 'Y' or S1 = 'Y' or S2 = 'Y'", "", DataViewRowState.CurrentRows);

                if (ldrchk == null || ldrchk.Length == 0)
                {
                    ShowMessage(공통메세지.선택된자료가없습니다);
                    return;
                }

                if (ShowMessage("선택하신 전표를 삭제하시겠습니까?", "QY2") == DialogResult.Yes)
                {
                    int row_chk = 0;
                    int j = 0;

                    for (int i = 2; i < _flexM.Rows.Count; i++)
                    {
                        if (_flexM[i, "S1"].ToString().Equals("Y") && (_flexM[i, "TP_INDEX"].ToString().Equals("전표처리") || _flexM[i, "TP_INDEX"].ToString().Equals("변경")))
                        {
                            string 수주전표번호 = _flexM[i, "NO_DOCU_M"].ToString();

                            if (_flexM[i, "S1"].ToString().Equals("Y"))
                            {
                                if (_flexM[i, "TP_TAXSTATUS"].ToString().Equals("처리"))
                                {
                                    ShowMessage((i - 1) + "행은 세금계산서 처리가 되어 삭제할 수 없습니다.");
                                    return;
                                }
                            }

                            if (_biz.Delete_Junpyo("0", 수주전표번호))
                            {
                                if (j == 0)
                                {
                                    row_chk = i;
                                    j = j + 1;
                                }
                            }
                        }

                        if (_flexM[i, "S2"].ToString().Equals("Y") && (_flexM[i, "TP_INDEX"].ToString().Equals("전표처리") || _flexM[i, "TP_INDEX"].ToString().Equals("변경")))
                        {
                            string 수수료전표번호 = _flexM[i, "NO_DOCU_C"].ToString();

                            if (_flexM[i, "S2"].ToString().Equals("Y"))
                            {
                                if (_flexM[i, "TP_TAXSTATUS"].ToString().Equals("처리"))
                                {
                                    ShowMessage((i - 1) + "행은 세금계산서 처리가 되어 삭제할 수 없습니다.");
                                    return;
                                }
                            }

                            if (_biz.Delete_Junpyo("1", 수수료전표번호))
                            {
                                if (j == 0)
                                {
                                    row_chk = i;
                                    j = j + 1;
                                }
                            }
                        }
                    }

                    //ShowMessage("전표 삭제가 완료 되었습니다.");

                    object[] Params = new object[7];
                    Params[0] = LoginInfo.CompanyCode;
                    Params[1] = "SELECT";
                    Params[2] = dt일자.StartDateToString.Substring(0, 6);
                    Params[3] = dt일자.EndDateToString.Substring(0, 6);
                    Params[4] = txt명.Text;
                    Params[5] = cbo상태구분.SelectedValue;
                    Params[6] = cbo기준.SelectedValue;

                    DataSet ds = _biz.Search_M(Params);

                    _flexM.Binding = ds.Tables[0];

                    _flexM.Select(row_chk, "NO_DOCU_M"); 
                }
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }


    }
}