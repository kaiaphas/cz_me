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
using System.ComponentModel;
using Duzon.Common.Controls;
using Duzon.Common.Util;

namespace cz
{
    // **************************************
    // 작   성   자 : 김승일
    // 재 작  성 일 : 2020-10-20
    // 모   듈   명 : 지급리스트
    // 시 스  템 명 : 지급리스트
    // 서브시스템명 : 지급리스트
    // 페 이 지  명 : 지급리스트
    // 프로젝트  명 : CZ_ME_SALES_PAYABLELIST
    // **************************************
    public partial class P_CZ_ME_SALES_PAYABLELIST : PageBase
    {
        #region ♥ 멤버필드

        private P_CZ_ME_SALES_PAYABLELIST_BIZ _biz = new P_CZ_ME_SALES_PAYABLELIST_BIZ();
        bool _타메뉴호출 = false;

        #endregion

        #region ♥ 초기화

        #region -> 생성자

        public P_CZ_ME_SALES_PAYABLELIST()
        {
            InitializeComponent();
            MainGrids = new FlexGrid[] { _flexM };    //그리드 자동 저장 기능 필요시 주석 해제
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

            toyear = time.ToString("yyyyMM") + "01";

            dt회계일자.StartDate = DateTime.ParseExact(toyear, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            dt회계일자.EndDate = DateTime.ParseExact(today, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);

            //dp조회일자.Text = "";

            InitGrid();
        }

        #endregion

        #region -> InitGrid

        private void InitGrid()
        {
            //DETAIL
            //merge 기능을 위해서 row 2 설정
            _flexM.BeginSetting(1, 1, false);

            _flexM.SetCol("S", "S", 35, true, CheckTypeEnum.Y_N);

            _flexM.SetCol("DT_ACCT", "회계일자", 100, false, typeof(decimal), FormatTpType.YEAR_MONTH_DAY);
            _flexM.SetCol("CD_PARTNER", "거래처코드", 100, false);
            _flexM.SetCol("LN_PARTNER", "거래처명", 150, false);
            _flexM.SetCol("NM_NOTE", "적요", 200, false);
            _flexM.SetCol("AM_CR", "금액", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("CD_MEDIA", "매체코드", 100, false);
            _flexM.SetCol("NM_MEDIA", "매체명", 150, false);
            _flexM.SetCol("TP_PAYABLE", "지급조건", 100, false);
            _flexM.SetCol("DT_START", "지급일자 계산", 100, false, typeof(decimal), FormatTpType.YEAR_MONTH_DAY);
            _flexM.SetCol("CD_BANK", "등록 은행명", 100, false);
            _flexM.SetCol("NO_DEPOSIT", "등록 계좌번호", 100, false);
            _flexM.SetCol("DT_START_DOCU", "전표 지급일자", 100, true, typeof(decimal), FormatTpType.YEAR_MONTH_DAY);
            _flexM.SetCol("CD_BANK_DOCU", "전표 은행명", 100, true);
            _flexM.SetCol("NO_DEPOSIT_DOCU", "전표 계좌번호", 100, true);
            _flexM.SetCol("NO_DOCU_LINE", "전표번호", 120, false);

            _flexM.SetDummyColumn("S");
            _flexM.Cols.Frozen = 1;

            _flexM.Cols["CD_PARTNER"].Format = _flexM.Cols["CD_PARTNER"].EditMask = "###-##-#####";
            _flexM.Cols["CD_PARTNER"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.SetStringFormatCol("CD_PARTNER");
            _flexM.SetNoMaskSaveCol("CD_PARTNER");

            _flexM.Cols["DT_START"].Format = _flexM.Cols["DT_START"].EditMask = "####/##/##";
            _flexM.Cols["DT_START"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.SetStringFormatCol("DT_START");
            _flexM.SetNoMaskSaveCol("DT_START");

            _flexM.Cols["DT_START_DOCU"].Format = _flexM.Cols["DT_START_DOCU"].EditMask = "####/##/##";
            _flexM.Cols["DT_START_DOCU"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.SetStringFormatCol("DT_START_DOCU");
            _flexM.SetNoMaskSaveCol("DT_START_DOCU");

            _flexM.Cols["DT_ACCT"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["DT_START"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["DT_START_DOCU"].TextAlign = TextAlignEnum.CenterCenter;
         
            _flexM.SettingVersion = "1.0.0.6";// new Random().Next().ToString();
            _flexM.EndSetting(GridStyleEnum.Green, AllowSortingEnum.MultiColumn, SumPositionEnum.None);

            _flexM.AfterEdit += new RowColEventHandler(_flexM_AfterEdit);
            _flexM.HelpClick += new EventHandler(_flexM_HelpClick);

        }

        #endregion

        #region -> InitPaint

        protected override void InitPaint()
        {
            base.InitPaint();

            Grant.CanSave = false;
            Grant.CanDelete = false;
            Grant.CanAdd = false;
            Grant.CanPrint = false;

            btn전표반영.Click += new EventHandler(btn전표반영_Click);
            btn이체내역관리.Click += new EventHandler(btn이체내역관리_Click);

            UGrant grant = new UGrant();

            _flexM.SetDataMap("TP_PAYABLE", MA.GetCode("CZ_ME_C023", true), "CODE", "NAME");
            _flexM.SetDataMap("CD_BANK", MA.GetCode("MA_B000043", true), "CODE", "NAME");
            _flexM.SetDataMap("CD_BANK_DOCU", MA.GetCode("MA_B000043", true), "CODE", "NAME");

        }

        #endregion

        #endregion

        #region ♥ 메인버튼 클릭

        #region -> 조회버튼클릭

        public void searchNo()
        {
            try
            {
                if (bp_CD_ACCT.CodeValue == "")
                {
                    ShowMessage(공통메세지._은는필수입력항목입니다, lb_NM_ACCT.Text);
                    bp_CD_ACCT.Focus();
                    return;
                }

                object[] Params = new object[5];
                Params[0] = LoginInfo.CompanyCode;
                Params[1] = dt회계일자.StartDate.ToString().Substring(0, 10).Replace("-", "");
                Params[2] = dt회계일자.EndDate.ToString().Substring(0, 10).Replace("-", "");
                Params[3] = bp_CD_ACCT.CodeValue;
                Params[4] = MULTI_CD_CORP.QueryWhereIn_Pipe.Replace("|", "");

                DataSet ds = _biz.Search_M(Params);

                _flexM.Binding = ds.Tables[0];
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

            if (bp_CD_ACCT.CodeValue == "")
            {
                ShowMessage(공통메세지._은는필수입력항목입니다, lb_NM_ACCT.Text);
                bp_CD_ACCT.Focus();
                return false;
            }

            return true;
        }

        #endregion

        protected override bool SaveData()
        {
            object obj = null;

            if (_flexM.HasNormalRow)
            {
                if (_flexM.GetChanges() == null)
                {
                    return false;
                }

                obj = _biz.Save(_flexM.GetChanges(), _타메뉴호출);
            }

            ResultData[] result = (ResultData[])obj;

            return true;
        }

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
                        searchNo();
                    }
                }
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }

        #endregion

        #region -> 삭제버튼클릭

        public override void OnToolBarDeleteButtonClicked(object sender, EventArgs e)
        {
            try
            {
                
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
 
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }

        }
        #endregion
        
        
        #region ♥ 그리드 이벤트

        void _flexM_AfterEdit(object sender, RowColEventArgs e)
        {
            switch (_flexM.Cols[_flexM.Col].Name)
            {
                case "S":

                    if (_flexM.Row.ToString() == null || _flexM.Row.ToString() == "")
                        return;

                    string 지급일자계산 = _flexM[_flexM.Row, "DT_START"].ToString();
                    string 등록은행명 = _flexM[_flexM.Row, "CD_BANK"].ToString();
                    string 등록계좌번호 = _flexM[_flexM.Row, "NO_DEPOSIT"].ToString();
               
                    if (_flexM[_flexM.Row, "S"].ToString().Equals("Y"))
                    {
                        if (_flexM[_flexM.Row, "DT_START_DOCU"].ToString().Equals(""))
                        {
                            _flexM[_flexM.Row, "DT_START_DOCU"] = 지급일자계산;
                        }
                        if (_flexM[_flexM.Row, "CD_BANK_DOCU"].ToString().Equals(""))
                        {
                            _flexM[_flexM.Row, "CD_BANK_DOCU"] = 등록은행명;
                        }
                        if (_flexM[_flexM.Row, "NO_DEPOSIT_DOCU"].ToString().Equals(""))
                        {
                            _flexM[_flexM.Row, "NO_DEPOSIT_DOCU"] = 등록계좌번호;
                        }                  
                    }

                    break;
            }
        }


        #endregion


        #region ♥ 기타 이벤트

        #region -> Control_QueryBefore

        private void btn전표반영_Click(object sender, EventArgs e)
        {
            try
            {
                //if (!_flexM.HasNormalRow)
                //    return;

                //if (!BeforeSaveChk())
                //    return;

                DataRow[] ldrchk = _flexM.DataTable.Select("S = 'Y'", "", DataViewRowState.CurrentRows);

                if (ldrchk == null || ldrchk.Length == 0)
                {
                    ShowMessage(공통메세지.선택된자료가없습니다);
                    return;
                }

                if (ShowMessage("선택한 데이터를 전표에 반영 하시겠습니까?", "QY2") == DialogResult.Yes)
                {

                    if (!BeforeSaveChk())
                        return;

                    for (int i = 1; i < _flexM.Rows.Count; i++)
                    {
                        if (_flexM[i, "S"].ToString().Equals("Y"))
                        {

                            string 전표번호 = _flexM[i, "NO_DOCU"].ToString();
                            string 라인번호 = _flexM[i, "NO_DOLINE"].ToString();
                            string 전표지급일자 = _flexM[i, "DT_START_DOCU"].ToString();
                            string 전표은행명 = _flexM[i, "CD_BANK_DOCU"].ToString();
                            string 전표계좌번호 = _flexM[i, "NO_DEPOSIT_DOCU"].ToString();

                            if (_biz.Update_Docu(전표번호, 라인번호, 전표지급일자, 전표은행명, 전표계좌번호))
                            {

                            }
                                
                        }
                    }

                    searchNo();
                }
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }

        private void btn이체내역관리_Click(object sender, EventArgs e)
        {
            try
            {
                object[] Args = {  };
                CallOtherPageMethod("P_FI_BANK_SEND_BAN", "이체내역관리(반제)(" + PageName + ")", Grant, Args);
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }

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

        private void MULTI_CD_CORP_QueryBefore(object sender, BpQueryArgs e)
        {
            MULTI_CD_CORP.UserParams = "거래처 도움창;H_CZ_ME_GR;" + MULTI_CD_CORP.CodeNames + ";";
        }

        void _flexM_HelpClick(object sender, EventArgs e)
        {
            try
            {
                string 전표번호 = D.GetString(_flexM["NO_DOCU"]);
               
                if (전표번호 == "")
                    return;

                switch (_flexM.Cols[_flexM.Col].Name)
                {
                    case "NO_DOCU_LINE":

                        object[] Args = { 전표번호, "", "", Duzon.Common.Forms.Global.MainFrame.LoginInfo.CompanyCode };
                        CallOtherPageMethod("P_FI_DOCU", "전표입력(" + PageName + ")", Grant, Args);

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