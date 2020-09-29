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
    // 작성자 : 김승일
    // 작성일 : 2020-09-01
    // 모듈명 : 수수료이월처리
    // 페이지 : P_CZ_ME_SALES_COMMISSION
    // **************************************

    public partial class P_CZ_ME_SALES_COMMISSION : PageBase
    {
        #region ♥ 멤버필드

        private P_CZ_ME_SALES_COMMISSION_BIZ _biz = new P_CZ_ME_SALES_COMMISSION_BIZ();
        bool _타메뉴호출 = false;
        
        DataTable dt = new DataTable();

        #endregion

        #region ♥ 초기화

        #region -> 생성자

        public P_CZ_ME_SALES_COMMISSION()
        {
            InitializeComponent();

            MainGrids = new FlexGrid[] { _flexM, _flexD, _flexT };
            _flexM.DetailGrids = new FlexGrid[] { _flexD };
            _flexD.DetailGrids = new FlexGrid[] { _flexT };
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
            //_flexM 메인그리드
            //merge 기능을 위해서 row 2 설정
            _flexM.BeginSetting(2, 1, false);

            _flexM.SetCol("NO_COMPANY", "사업자번호", 0, false);
            _flexM.SetCol("LN_PARTNER", "거래처명", 0, false);
            _flexM.SetCol("NO_COMPANY2", "사업자번호", 100, false);
            _flexM.SetCol("LN_PARTNER2", "거래처명", 150, false);

            _flexM.SetCol("AM_TAXSTD1", "공급가액", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("AM_ADDTAX1", "세액", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("AM_SUM1", "합계", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("TAX_COUNT1", "매수", 50, false);

            _flexM.SetCol("AM_TAXSTD2", "공급가액", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("AM_ADDTAX2", "세액", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("AM_SUM2", "합계", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("TAX_COUNT2", "매수", 50, false);

            _flexM.SetCol("AM_TAXSTD", "공급가액", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("AM_ADDTAX", "세액", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("AM_SUM", "합계", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);

            _flexM.Cols["TAX_COUNT1"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["TAX_COUNT2"].TextAlign = TextAlignEnum.CenterCenter;

            _flexM.Cols["NO_COMPANY"].Format = _flexM.Cols["NO_COMPANY"].EditMask = "###-##-#####";
            _flexM.Cols["NO_COMPANY"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.SetStringFormatCol("NO_COMPANY");
            _flexM.SetNoMaskSaveCol("NO_COMPANY");

            _flexM.Cols["NO_COMPANY2"].Format = _flexM.Cols["NO_COMPANY2"].EditMask = "###-##-#####";
            _flexM.Cols["NO_COMPANY2"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.SetStringFormatCol("NO_COMPANY2");
            _flexM.SetNoMaskSaveCol("NO_COMPANY2");

            _flexM.Cols["AM_TAXSTD1"].Format = "###,###,###,##0;(###,###,###,##0)";
            _flexM.Cols["AM_ADDTAX1"].Format = "###,###,###,##0;(###,###,###,##0)";
            _flexM.Cols["AM_SUM1"].Format = "###,###,###,##0;(###,###,###,##0)";

            _flexM.Cols["AM_TAXSTD2"].Format = "###,###,###,##0;(###,###,###,##0)";
            _flexM.Cols["AM_ADDTAX2"].Format = "###,###,###,##0;(###,###,###,##0)";
            _flexM.Cols["AM_SUM2"].Format = "###,###,###,##0;(###,###,###,##0)";

            _flexM.Cols["AM_TAXSTD"].Format = "###,###,###,##0;(###,###,###,##0)";
            _flexM.Cols["AM_ADDTAX"].Format = "###,###,###,##0;(###,###,###,##0)";
            _flexM.Cols["AM_SUM"].Format = "###,###,###,##0;(###,###,###,##0)";


            //MERGE 처리    
            _flexM[0, "AM_TAXSTD1"] = _flexM[0, "DUZ"] = "더존";
            _flexM[0, "AM_ADDTAX1"] = _flexM[0, "DUZ"] = "더존";
            _flexM[0, "AM_SUM1"] = _flexM[0, "DUZ"] = "더존";
            _flexM[0, "TAX_COUNT1"] = _flexM[0, "DUZ"] = "더존";

            _flexM[0, "AM_TAXSTD2"] = _flexM[0, "TAX"] = "국세청";
            _flexM[0, "AM_ADDTAX2"] = _flexM[0, "TAX"] = "국세청";
            _flexM[0, "AM_SUM2"] = _flexM[0, "TAX"] = "국세청";
            _flexM[0, "TAX_COUNT2"] = _flexM[0, "TAX"] = "국세청";

            _flexM[0, "AM_TAXSTD"] = _flexM[0, "DIF"] = "차이";
            _flexM[0, "AM_ADDTAX"] = _flexM[0, "DIF"] = "차이";
            _flexM[0, "AM_SUM"] = _flexM[0, "DIF"] = "차이";
            
            _flexM.SettingVersion = new Random().Next().ToString();
            _flexM.EndSetting(GridStyleEnum.Green, AllowSortingEnum.MultiColumn, SumPositionEnum.Top);

            _flexM.AfterRowChange += new RangeEventHandler(_flexM_AfterRowChange);
            _flexM.OwnerDrawCell += new OwnerDrawCellEventHandler(_flexM_OwnerDrawCell);

            //_flexD 하단그리드
            _flexD.BeginSetting(1, 1, false);

            //_flexD.SetCol("S", "선택", 35, true, CheckTypeEnum.Y_N);

            _flexD.SetCol("CPNAME", "캠페인명", 150, false);
            _flexD.SetCol("AY_YEAR_MONTH", "대행사월", 100, false, typeof(string), FormatTpType.YEAR_MONTH);
            _flexD.SetCol("AY_TRADE_TYPE_CD", "구분", 0, false);
            _flexD.SetCol("AY_TRADE_TYPE", "구분", 50, false);
            _flexD.SetCol("AY_AGENCYNM", "대행사명", 150, false);
            _flexD.SetCol("ME_YEAR_MONTH", "매체월", 100, false, typeof(string), FormatTpType.YEAR_MONTH);
            _flexD.SetCol("ME_TRADE_TYPE_CD", "구분", 0, false);
            _flexD.SetCol("ME_TRADE_TYPE", "구분", 50, false);
            _flexD.SetCol("ME_CORPNM", "매체명", 150, false);
            _flexD.SetCol("AM_BUDGET", "광고수주액", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexD.SetCol("AM_AGY_PRICE", "대행사수수료", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexD.SetCol("AM_INCOME", "영업수익", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexD.SetCol("AM_MEDIA_PRICE", "매출수익", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexD.SetCol("AM_FEE_ALL", "AM_FEE_ALL", 0, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexD.SetCol("NO_DOCU_M", "대행사 전표번호", 120, false);
            _flexD.SetCol("NO_DOCU_D", "매체 전표번호", 120, false);
            _flexD.SetCol("ST_DOCU", "마감여부", 0, false);

            _flexD.SetCol("CD_COMPANY", "CD_COMPANY", 0, false);
            _flexD.SetCol("TP_SALES", "TP_SALES", 0, false);
            _flexD.SetCol("MER_REQ_NO", "MER_REQ_NO", 0, false);
            _flexD.SetCol("ME_CPID", "ME_CPID", 0, false);
            _flexD.SetCol("ME_SEQ", "ME_SEQ", 0, false);
            _flexD.SetCol("DT_YEAR_MONTH", "DT_YEAR_MONTH", 0, false);
            _flexD.SetCol("AY_AGENCYID", "AY_AGENCYID", 0, false);
            _flexD.SetCol("AY_AGENCYNO", "AY_AGENCYNO", 0, false);
            _flexD.SetCol("ME_CORPID", "ME_CORPID", 0, false);
            _flexD.SetCol("ME_CORPNO", "ME_CORPNO", 0, false);
            _flexD.SetCol("AY_AGENCYID_ORI", "AY_AGENCYID_ORI", 0, false);
            _flexD.SetCol("AY_AGENCYNM_ORI", "AY_AGENCYNM_ORI", 0, false);
            _flexD.SetCol("CD_SYSDEF", "CD_SYSDEF", 0, false);
            _flexD.SetCol("CD_ACCT", "CD_ACCT", 0, false);
            _flexD.SetCol("ME_TEAMID", "ME_TEAMID", 0, false);
            _flexD.SetCol("ME_TEAMNM", "ME_TEAMNM", 0, false);
            _flexD.SetCol("ME_TEAMLV", "ME_TEAMLV", 0, false);
            _flexD.SetCol("ME_TEAMORD", "ME_TEAMORD", 0, false);
            _flexD.SetCol("CP_AGENTID", "CP_AGENTID", 0, false);
            _flexD.SetCol("CP_AGENTNM", "CP_AGENTNM", 0, false);
            _flexD.SetCol("CP_AGENTNO", "CP_AGENTNO", 0, false);
            _flexD.SetCol("NM_NOTE", "NM_NOTE", 0, false);
            _flexD.SetCol("ID_NOTE", "ID_NOTE", 0, false);
            _flexD.SetCol("DT_NOTE", "DT_NOTE", 0, false);
            _flexD.SetCol("NM_USERDE1", "NM_USERDE1", 0, false);
            _flexD.SetCol("NM_USERDE2", "NM_USERDE2", 0, false);

            _flexD.Cols["AY_YEAR_MONTH"].TextAlign = TextAlignEnum.CenterCenter;
            _flexD.SetStringFormatCol("AY_YEAR_MONTH");
            _flexD.SetNoMaskSaveCol("AY_YEAR_MONTH");

            _flexD.Cols["AY_TRADE_TYPE"].TextAlign = TextAlignEnum.CenterCenter;

            _flexD.Cols["ME_YEAR_MONTH"].TextAlign = TextAlignEnum.CenterCenter;
            _flexD.SetStringFormatCol("ME_YEAR_MONTH");
            _flexD.SetNoMaskSaveCol("ME_YEAR_MONTH");

            _flexD.Cols["ME_TRADE_TYPE"].TextAlign = TextAlignEnum.CenterCenter;
            _flexD.Cols["NO_DOCU_M"].TextAlign = TextAlignEnum.CenterCenter;
            _flexD.Cols["NO_DOCU_D"].TextAlign = TextAlignEnum.CenterCenter;

            _flexD.Cols["AM_BUDGET"].Format = "###,###,###,##0;(###,###,###,##0)";
            _flexD.Cols["AM_AGY_PRICE"].Format = "###,###,###,##0;(###,###,###,##0)";
            _flexD.Cols["AM_INCOME"].Format = "###,###,###,##0;(###,###,###,##0)";
            _flexD.Cols["AM_MEDIA_PRICE"].Format = "###,###,###,##0;(###,###,###,##0)";

            _flexD.SetDummyColumn("S");

            _flexD.SettingVersion = new Random().Next().ToString();
            _flexD.EndSetting(GridStyleEnum.Green, AllowSortingEnum.MultiColumn, SumPositionEnum.Top);

            _flexD.AfterRowChange += new RangeEventHandler(_flexD_AfterRowChange);
            _flexD.OwnerDrawCell += new OwnerDrawCellEventHandler(_flexD_OwnerDrawCell);
            _flexD.HelpClick += new EventHandler(_flexD_HelpClick);
          
            //_flexT 하단그리드
            _flexT.BeginSetting(1, 1, true);

            //_flexT.SetCol("S", "선택", 35, true, CheckTypeEnum.Y_N);

            _flexT.SetCol("CD_COMPANY", "CD_COMPANY", 0, false);
            _flexT.SetCol("TP_SALES", "TP_SALES", 0, false);
            _flexT.SetCol("ME_CPID", "ME_CPID", 0, false);
            _flexT.SetCol("ME_SEQ", "ME_SEQ", 0, false);
            _flexT.SetCol("DT_YEAR_MONTH", "DT_YEAR_MONTH", 0, false);
            _flexT.SetCol("AY_AGENCYID", "AY_AGENCYID", 0, false);
            _flexT.SetCol("AY_AGENCYNO", "AY_AGENCYNO", 0, false);
            _flexT.SetCol("ME_CORPID", "ME_CORPID", 0, false);
            _flexT.SetCol("ME_CORPNO", "ME_CORPNO", 0, false);
            _flexT.SetCol("AY_AGENCYID_ORI", "AY_AGENCYID_ORI", 0, false);
            _flexT.SetCol("AY_AGENCYNM_ORI", "AY_AGENCYNM_ORI", 0, false);
            _flexT.SetCol("CD_SYSDEF", "CD_SYSDEF", 0, false);
            _flexT.SetCol("CD_ACCT", "CD_ACCT", 0, false);
            _flexT.SetCol("ME_TEAMID", "ME_TEAMID", 0, false);
            _flexT.SetCol("ME_TEAMNM", "ME_TEAMNM", 0, false);
            _flexT.SetCol("ME_TEAMLV", "ME_TEAMLV", 0, false);
            _flexT.SetCol("ME_TEAMORD", "ME_TEAMORD", 0, false);
            _flexT.SetCol("CP_AGENTID", "CP_AGENTID", 0, false);
            _flexT.SetCol("CP_AGENTNM", "CP_AGENTNM", 0, false);
            _flexT.SetCol("CP_AGENTNO", "CP_AGENTNO", 0, false);
            _flexT.SetCol("NM_NOTE", "NM_NOTE", 0, false);
            _flexT.SetCol("ID_NOTE", "ID_NOTE", 0, false);
            _flexT.SetCol("DT_NOTE", "DT_NOTE", 0, false);
            _flexT.SetCol("NM_USERDE1", "NM_USERDE1", 0, false);
            _flexT.SetCol("NM_USERDE2", "NM_USERDE2", 0, false);

            _flexT.SetCol("MER_REQ_NO", "조정이월구분", 0, false);
            _flexT.SetCol("MER_REQ_NO_NM", "조정이월구분", 100, false);
            _flexT.SetCol("CPNAME", "캠페인명", 150, false);
            _flexT.SetCol("AY_YEAR_MONTH", "대행사월", 100, false, typeof(string), FormatTpType.YEAR_MONTH);
            _flexT.SetCol("AY_TRADE_TYPE_CD", "구분", 0, false);
            _flexT.SetCol("AY_TRADE_TYPE", "구분", 50, false);
            _flexT.SetCol("AY_AGENCYNM", "대행사명", 150, false);
            _flexT.SetCol("ME_YEAR_MONTH", "매체월", 100, false, typeof(string), FormatTpType.YEAR_MONTH);
            _flexT.SetCol("ME_TRADE_TYPE_CD", "구분", 0, false);
            _flexT.SetCol("ME_TRADE_TYPE", "구분", 50, false);
            _flexT.SetCol("ME_CORPNM", "매체명", 150, false);
            _flexT.SetCol("AM_BUDGET", "광고수주액", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexT.SetCol("AM_AGY_PRICE", "대행사수수료", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexT.SetCol("AM_INCOME", "영업수익", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexT.SetCol("AM_MEDIA_PRICE", "매출수익", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexT.SetCol("AM_FEE_ALL", "AM_FEE_ALL", 0, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexT.SetCol("NO_DOCU_M", "대행사 전표번호", 120, false);
            _flexT.SetCol("NO_DOCU_D", "매체 전표번호", 120, false);
            _flexT.SetCol("ST_DOCU", "마감여부", 0, false);

            _flexT.Cols["MER_REQ_NO_NM"].TextAlign = TextAlignEnum.CenterCenter;
            _flexT.Cols["AY_YEAR_MONTH"].TextAlign = TextAlignEnum.CenterCenter;
            _flexT.SetStringFormatCol("AY_YEAR_MONTH");
            _flexT.SetNoMaskSaveCol("AY_YEAR_MONTH");

            _flexT.Cols["AY_TRADE_TYPE"].TextAlign = TextAlignEnum.CenterCenter;

            _flexT.Cols["ME_YEAR_MONTH"].TextAlign = TextAlignEnum.CenterCenter;
            _flexT.SetStringFormatCol("ME_YEAR_MONTH");
            _flexT.SetNoMaskSaveCol("ME_YEAR_MONTH");

            _flexT.Cols["ME_TRADE_TYPE"].TextAlign = TextAlignEnum.CenterCenter;
            _flexT.Cols["NO_DOCU_M"].TextAlign = TextAlignEnum.CenterCenter;
            _flexT.Cols["NO_DOCU_D"].TextAlign = TextAlignEnum.CenterCenter;
            
            //_flexT.Cols["AM_BUDGET"].Format = "###,###,###,##0;(###,###,###,##0)";
            //_flexT.Cols["AM_AGY_PRICE"].Format = "###,###,###,##0;(###,###,###,##0)";
            //_flexT.Cols["AM_INCOME"].Format = "###,###,###,##0;(###,###,###,##0)";
            //_flexT.Cols["AM_MEDIA_PRICE"].Format = "###,###,###,##0;(###,###,###,##0)";

            _flexT.SetDummyColumn("S");

            _flexT.SettingVersion = new Random().Next().ToString();
            _flexT.EndSetting(GridStyleEnum.Green, AllowSortingEnum.MultiColumn, SumPositionEnum.None);
            _flexT.OwnerDrawCell += new OwnerDrawCellEventHandler(_flexT_OwnerDrawCell);
            _flexT.AfterEdit += new RowColEventHandler(_flexT_AfterEdit);
            _flexT.HelpClick += new EventHandler(_flexT_HelpClick);
            _flexT.StartEdit += new RowColEventHandler(_flexT_StartEdit);

        }
        #endregion

        #region -> InitPaint

        protected override void InitPaint()
        {
            base.InitPaint();

            Grant.CanPrint = false;

            string longtoday = "";

            longtoday = DateTime.Now.ToString("yyyMMddHHmmss");

            dp년월.Text = longtoday.Substring(0, 6);

            DateTime time = Global.MainFrame.GetDateTimeToday();

            //콤보박스 셋팅

            SetControl set = new SetControl();
            set.SetCombobox(cbo구분, MA.GetCode("FI_T000001", false));
            set.SetCombobox(cbo이월구분, MA.GetCodeUser(new string[] { "", "1" }, new string[] { DD("전체"), DD("이월")}));

            //_flexT.SetDataMap("MER_REQ_NO", MA.GetCode("CZ_ME_C016"), "CODE", "NAME");

           // cboIO상태.SelectedIndex = 0;
           // cbo세금계산서발행상태.SelectedIndex = 2;

        }

        #endregion

        #endregion

        #region ♥ 메인버튼 클릭

        #region -> 조회버튼클릭

        public override void OnToolBarSearchButtonClicked(object sender, EventArgs e)
        {
            try
            {
                object[] Params = new object[6];
                Params[0] = LoginInfo.CompanyCode;
                Params[1] = cbo구분.SelectedValue;
                Params[2] = dp년월.Text;
                Params[3] = txt명.Text;
                Params[4] = "Y";
                Params[5] = cbo이월구분.SelectedValue;

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
                        int row = _flexD.Row;

                        object[] Params = new object[7];
                        Params[0] = LoginInfo.CompanyCode;
                        Params[1] = cbo구분.SelectedValue;
                        Params[2] = dp년월.Text;
                        Params[3] = D.GetString(_flexM["NO_COMPANY"]);
                        Params[4] = txt캠페인명.Text;
                        Params[5] = cbo이월구분.SelectedValue;
                        Params[6] = txt대행사매체명.Text;

                        DataSet ds = _biz.Search_D(Params);

                        _flexD.Binding = ds.Tables[0];

                        _flexD.Row = row;
                        
                        object[] Params2 = new object[6];
                        Params2[0] = LoginInfo.CompanyCode;
                        Params2[1] = cbo구분.SelectedValue;
                        Params2[2] = dp년월.Text;
                        Params2[3] = D.GetString(_flexD["TP_SALES"]);
                        Params2[4] = D.GetString(_flexD["ME_CPID"]);
                        Params2[5] = D.GetString(_flexD["ME_SEQ"]);

                        DataSet ds2 = _biz.Search_T(Params2);

                        _flexT.Binding = ds2.Tables[0];
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

            obj = _biz.Save(_flexT.GetChanges(), _타메뉴호출);

            ResultData[] result = (ResultData[])obj;

            return true;
        }

        // 저장 전 체크 사항
        protected bool BeforeSaveChk()
        {
            return true;
        }
        #endregion

        #region -> 삭제버튼클릭

        public override void OnToolBarDeleteButtonClicked(object sender, EventArgs e)
        {
            try
            {
                //if (!_flexM.HasNormalRow)
                //    return;

                if (_flexT.Row.ToString() == null || _flexT.Row.ToString() == "" || _flexT.Row == -1)
                    return;

                int 매체전표 = _flexT[_flexT.Row, "NO_DOCU_D"].ToString().Length;
                int 대행사전표 = _flexT[_flexT.Row, "NO_DOCU_M"].ToString().Length;

                if (매체전표 > 0 || 대행사전표 > 0)
                {
                    ShowMessage((_flexT.Row) + "행은 전표가 등록되어 있어, 삭제가 불가능합니다.");
                    return;
                }
                _flexT.RemoveItem(_flexT.Row);  

                /*
                for (int i = _flexT.Rows.Count - 1; i >= _flexT.Rows.Fixed; i--)
                {
                    if (_flexT.RowState(i) == DataRowState.Deleted)
                        continue;
                    int 매체전표 = _flexT[i, "NO_DOCU_M"].ToString().Length;
                    int 대행사전표 = _flexT[i, "NO_DOCU_M"].ToString().Length;

                    if (매체전표 > 0 || 대행사전표 > 0)
                    {
                        ShowMessage((i) + "행은 전표가 등록되어 있어, 삭제가 불가능합니다.");
                        return;
                    }
                    _flexT.RemoveItem(i);  
                }
                */
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
                if (_flexD.Row.ToString() == null || _flexD.Row.ToString() == "")
                    return;

                string 매수체크 = _flexM[_flexM.Row, "TAX_COUNT1"].ToString();
                string 마감여부 = "";

                if (매수체크.Equals("0"))
                {
                    return;
                }
                else
                {
                    마감여부 = _flexD[_flexD.Row, "ST_DOCU"].ToString();
                }

                if (마감여부.Equals("1"))
                {
                    ShowMessage((_flexD.Row) + "행은 이미 마감 처리되었습니다.");
                    return;
                }
               
                /*
                if (_flexT.Rows.Count > 1)
                {
                    ShowMessage("라인을 추가 할 수 없습니다.");
                    return;
                }
                */ 

                int am_agy_price = Convert.ToInt32(_flexD[_flexD.Row, "AM_AGY_PRICE"]);
                int am_income = Convert.ToInt32(_flexD[_flexD.Row, "AM_INCOME"]);

                // 매출
                if (cbo구분.SelectedValue.Equals("1"))
                {                           
                    _flexT.Rows.Add();
                    _flexT.Row = _flexT.Rows.Count - 1;

                    _flexT[_flexT.Row, "CD_COMPANY"] = _flexD[_flexD.Row, "CD_COMPANY"];
                    _flexT[_flexT.Row, "TP_SALES"] = _flexD[_flexD.Row, "TP_SALES"];
                    _flexT[_flexT.Row, "MER_REQ_NO"] = _flexD[_flexD.Row, "MER_REQ_NO"];
                    _flexT[_flexT.Row, "MER_REQ_NO_NM"] = "조정";
                    _flexT[_flexT.Row, "ME_CPID"] = _flexD[_flexD.Row, "ME_CPID"];
                    _flexT[_flexT.Row, "ME_SEQ"] = _flexD[_flexD.Row, "ME_SEQ"];
                    _flexT[_flexT.Row, "DT_YEAR_MONTH"] = _flexD[_flexD.Row, "DT_YEAR_MONTH"];
                    _flexT[_flexT.Row, "AY_AGENCYID"] = _flexD[_flexD.Row, "AY_AGENCYID"];
                    _flexT[_flexT.Row, "AY_AGENCYNO"] = _flexD[_flexD.Row, "AY_AGENCYNO"];
                    _flexT[_flexT.Row, "ME_CORPID"] = _flexD[_flexD.Row, "ME_CORPID"];
                    _flexT[_flexT.Row, "ME_CORPNO"] = _flexD[_flexD.Row, "ME_CORPNO"];
                    _flexT[_flexT.Row, "AY_AGENCYID_ORI"] = _flexD[_flexD.Row, "AY_AGENCYID_ORI"];
                    _flexT[_flexT.Row, "AY_AGENCYNM_ORI"] = _flexD[_flexD.Row, "AY_AGENCYNM_ORI"];
                    _flexT[_flexT.Row, "CD_SYSDEF"] = _flexD[_flexD.Row, "CD_SYSDEF"];
                    _flexT[_flexT.Row, "CD_ACCT"] = _flexD[_flexD.Row, "CD_ACCT"];
                    _flexT[_flexT.Row, "ME_TEAMID"] = _flexD[_flexD.Row, "ME_TEAMID"];
                    _flexT[_flexT.Row, "ME_TEAMNM"] = _flexD[_flexD.Row, "ME_TEAMNM"];
                    _flexT[_flexT.Row, "ME_TEAMLV"] = _flexD[_flexD.Row, "ME_TEAMLV"];
                    _flexT[_flexT.Row, "ME_TEAMORD"] = _flexD[_flexD.Row, "ME_TEAMORD"];
                    _flexT[_flexT.Row, "CP_AGENTID"] = _flexD[_flexD.Row, "CP_AGENTID"];
                    _flexT[_flexT.Row, "CP_AGENTNM"] = _flexD[_flexD.Row, "CP_AGENTNM"];
                    _flexT[_flexT.Row, "CP_AGENTNO"] = _flexD[_flexD.Row, "CP_AGENTNO"];
                    _flexT[_flexT.Row, "NM_NOTE"] = _flexD[_flexD.Row, "NM_NOTE"];
                    _flexT[_flexT.Row, "ID_NOTE"] = _flexD[_flexD.Row, "ID_NOTE"];
                    _flexT[_flexT.Row, "DT_NOTE"] = _flexD[_flexD.Row, "DT_NOTE"];
                    _flexT[_flexT.Row, "NM_USERDE1"] = _flexD[_flexD.Row, "NM_USERDE1"];
                    _flexT[_flexT.Row, "NM_USERDE2"] = _flexD[_flexD.Row, "NM_USERDE2"];

                    _flexT[_flexT.Row, "CPNAME"] = _flexD[_flexD.Row, "CPNAME"];
                    _flexT[_flexT.Row, "AY_YEAR_MONTH"] = _flexD[_flexD.Row, "AY_YEAR_MONTH"];
                    _flexT[_flexT.Row, "AY_TRADE_TYPE_CD"] = _flexD[_flexD.Row, "AY_TRADE_TYPE_CD"];
                    _flexT[_flexT.Row, "AY_TRADE_TYPE"] = _flexD[_flexD.Row, "AY_TRADE_TYPE"];
                    _flexT[_flexT.Row, "AY_AGENCYNM"] = _flexD[_flexD.Row, "AY_AGENCYNM"];
                    _flexT[_flexT.Row, "ME_YEAR_MONTH"] = _flexD[_flexD.Row, "ME_YEAR_MONTH"];
                    _flexT[_flexT.Row, "ME_TRADE_TYPE_CD"] = _flexD[_flexD.Row, "ME_TRADE_TYPE_CD"];
                    _flexT[_flexT.Row, "ME_TRADE_TYPE"] = _flexD[_flexD.Row, "ME_TRADE_TYPE"];
                    _flexT[_flexT.Row, "ME_CORPNM"] = _flexD[_flexD.Row, "ME_CORPNM"];
                    _flexT[_flexT.Row, "AM_BUDGET"] = 0;
                    _flexT[_flexT.Row, "AM_AGY_PRICE"] = -1 * am_agy_price;
                    _flexT[_flexT.Row, "AM_INCOME"] = -1 * am_income;
                    _flexT[_flexT.Row, "AM_MEDIA_PRICE"] = am_agy_price + am_income;
                    _flexT[_flexT.Row, "AM_FEE_ALL"] = _flexD[_flexD.Row, "AM_FEE_ALL"];

                    _flexT.Rows.Add();
                    _flexT.Row = _flexT.Rows.Count - 1;

                    //DateTime me_year_month = DateTime.Now;
                    //string me_year_month_2 = "";

                    _flexT[_flexT.Row, "CD_COMPANY"] = _flexD[_flexD.Row, "CD_COMPANY"];
                    _flexT[_flexT.Row, "TP_SALES"] = _flexD[_flexD.Row, "TP_SALES"];
                    _flexT[_flexT.Row, "MER_REQ_NO"] = _flexD[_flexD.Row, "MER_REQ_NO"];
                    _flexT[_flexT.Row, "MER_REQ_NO_NM"] = "이월";
                    _flexT[_flexT.Row, "ME_CPID"] = _flexD[_flexD.Row, "ME_CPID"];
                    _flexT[_flexT.Row, "ME_SEQ"] = _flexD[_flexD.Row, "ME_SEQ"];
                    _flexT[_flexT.Row, "DT_YEAR_MONTH"] = _flexD[_flexD.Row, "DT_YEAR_MONTH"];
                    _flexT[_flexT.Row, "AY_AGENCYID"] = _flexD[_flexD.Row, "AY_AGENCYID"];
                    _flexT[_flexT.Row, "AY_AGENCYNO"] = _flexD[_flexD.Row, "AY_AGENCYNO"];
                    _flexT[_flexT.Row, "ME_CORPID"] = _flexD[_flexD.Row, "ME_CORPID"];
                    _flexT[_flexT.Row, "ME_CORPNO"] = _flexD[_flexD.Row, "ME_CORPNO"];
                    _flexT[_flexT.Row, "AY_AGENCYID_ORI"] = _flexD[_flexD.Row, "AY_AGENCYID_ORI"];
                    _flexT[_flexT.Row, "AY_AGENCYNM_ORI"] = _flexD[_flexD.Row, "AY_AGENCYNM_ORI"];
                    _flexT[_flexT.Row, "CD_SYSDEF"] = _flexD[_flexD.Row, "CD_SYSDEF"];
                    _flexT[_flexT.Row, "CD_ACCT"] = _flexD[_flexD.Row, "CD_ACCT"];
                    _flexT[_flexT.Row, "ME_TEAMID"] = _flexD[_flexD.Row, "ME_TEAMID"];
                    _flexT[_flexT.Row, "ME_TEAMNM"] = _flexD[_flexD.Row, "ME_TEAMNM"];
                    _flexT[_flexT.Row, "ME_TEAMLV"] = _flexD[_flexD.Row, "ME_TEAMLV"];
                    _flexT[_flexT.Row, "ME_TEAMORD"] = _flexD[_flexD.Row, "ME_TEAMORD"];
                    _flexT[_flexT.Row, "CP_AGENTID"] = _flexD[_flexD.Row, "CP_AGENTID"];
                    _flexT[_flexT.Row, "CP_AGENTNM"] = _flexD[_flexD.Row, "CP_AGENTNM"];
                    _flexT[_flexT.Row, "CP_AGENTNO"] = _flexD[_flexD.Row, "CP_AGENTNO"];
                    _flexT[_flexT.Row, "NM_NOTE"] = _flexD[_flexD.Row, "NM_NOTE"];
                    _flexT[_flexT.Row, "ID_NOTE"] = _flexD[_flexD.Row, "ID_NOTE"];
                    _flexT[_flexT.Row, "DT_NOTE"] = _flexD[_flexD.Row, "DT_NOTE"];
                    _flexT[_flexT.Row, "NM_USERDE1"] = _flexD[_flexD.Row, "NM_USERDE1"];
                    _flexT[_flexT.Row, "NM_USERDE2"] = _flexD[_flexD.Row, "NM_USERDE2"];

                    _flexT[_flexT.Row, "CPNAME"] = _flexD[_flexD.Row, "CPNAME"];
                    _flexT[_flexT.Row, "AY_YEAR_MONTH"] = _flexD[_flexD.Row, "AY_YEAR_MONTH"];
                    _flexT[_flexT.Row, "AY_TRADE_TYPE_CD"] = _flexD[_flexD.Row, "AY_TRADE_TYPE_CD"];
                    _flexT[_flexT.Row, "AY_TRADE_TYPE"] = _flexD[_flexD.Row, "AY_TRADE_TYPE"];
                    _flexT[_flexT.Row, "AY_AGENCYNM"] = _flexD[_flexD.Row, "AY_AGENCYNM"];

                    //me_year_month = DateTime.ParseExact(_flexD[_flexD.Row, "ME_YEAR_MONTH"].ToString(), "yyyyMM", System.Globalization.CultureInfo.InvariantCulture);
                    //me_year_month_2 = me_year_month.AddMonths(1).ToString("yyyyMM");

                    //_flexD[_flexD.Row, "ME_YEAR_MONTH"] = me_year_month_2;

                    _flexT[_flexT.Row, "ME_YEAR_MONTH"] = _flexD[_flexD.Row, "ME_YEAR_MONTH"];
                    _flexT[_flexT.Row, "ME_TRADE_TYPE_CD"] = _flexD[_flexD.Row, "ME_TRADE_TYPE_CD"];
                    _flexT[_flexT.Row, "ME_TRADE_TYPE"] = _flexD[_flexD.Row, "ME_TRADE_TYPE"];
                    _flexT[_flexT.Row, "ME_CORPNM"] = _flexD[_flexD.Row, "ME_CORPNM"];
                    _flexT[_flexT.Row, "AM_BUDGET"] = 0;
                    _flexT[_flexT.Row, "AM_AGY_PRICE"] = am_agy_price;
                    _flexT[_flexT.Row, "AM_INCOME"] = am_income;
                    _flexT[_flexT.Row, "AM_MEDIA_PRICE"] = -1 * (am_agy_price + am_income);
                    _flexT[_flexT.Row, "AM_FEE_ALL"] = _flexD[_flexD.Row, "AM_FEE_ALL"];
                }
                // 매입
                else if (cbo구분.SelectedValue.Equals("2"))
                {
                    _flexT.Rows.Add();
                    _flexT.Row = _flexT.Rows.Count - 1;

                    _flexT[_flexT.Row, "CD_COMPANY"] = _flexD[_flexD.Row, "CD_COMPANY"];
                    _flexT[_flexT.Row, "TP_SALES"] = _flexD[_flexD.Row, "TP_SALES"];
                    _flexT[_flexT.Row, "MER_REQ_NO"] = _flexD[_flexD.Row, "MER_REQ_NO"];
                    _flexT[_flexT.Row, "MER_REQ_NO_NM"] = "조정";
                    _flexT[_flexT.Row, "ME_CPID"] = _flexD[_flexD.Row, "ME_CPID"];
                    _flexT[_flexT.Row, "ME_SEQ"] = _flexD[_flexD.Row, "ME_SEQ"];
                    _flexT[_flexT.Row, "DT_YEAR_MONTH"] = _flexD[_flexD.Row, "DT_YEAR_MONTH"];
                    _flexT[_flexT.Row, "AY_AGENCYID"] = _flexD[_flexD.Row, "AY_AGENCYID"];
                    _flexT[_flexT.Row, "AY_AGENCYNO"] = _flexD[_flexD.Row, "AY_AGENCYNO"];
                    _flexT[_flexT.Row, "ME_CORPID"] = _flexD[_flexD.Row, "ME_CORPID"];
                    _flexT[_flexT.Row, "ME_CORPNO"] = _flexD[_flexD.Row, "ME_CORPNO"];
                    _flexT[_flexT.Row, "AY_AGENCYID_ORI"] = _flexD[_flexD.Row, "AY_AGENCYID_ORI"];
                    _flexT[_flexT.Row, "AY_AGENCYNM_ORI"] = _flexD[_flexD.Row, "AY_AGENCYNM_ORI"];
                    _flexT[_flexT.Row, "CD_SYSDEF"] = _flexD[_flexD.Row, "CD_SYSDEF"];
                    _flexT[_flexT.Row, "CD_ACCT"] = _flexD[_flexD.Row, "CD_ACCT"];
                    _flexT[_flexT.Row, "ME_TEAMID"] = _flexD[_flexD.Row, "ME_TEAMID"];
                    _flexT[_flexT.Row, "ME_TEAMNM"] = _flexD[_flexD.Row, "ME_TEAMNM"];
                    _flexT[_flexT.Row, "ME_TEAMLV"] = _flexD[_flexD.Row, "ME_TEAMLV"];
                    _flexT[_flexT.Row, "ME_TEAMORD"] = _flexD[_flexD.Row, "ME_TEAMORD"];
                    _flexT[_flexT.Row, "CP_AGENTID"] = _flexD[_flexD.Row, "CP_AGENTID"];
                    _flexT[_flexT.Row, "CP_AGENTNM"] = _flexD[_flexD.Row, "CP_AGENTNM"];
                    _flexT[_flexT.Row, "CP_AGENTNO"] = _flexD[_flexD.Row, "CP_AGENTNO"];
                    _flexT[_flexT.Row, "NM_NOTE"] = _flexD[_flexD.Row, "NM_NOTE"];
                    _flexT[_flexT.Row, "ID_NOTE"] = _flexD[_flexD.Row, "ID_NOTE"];
                    _flexT[_flexT.Row, "DT_NOTE"] = _flexD[_flexD.Row, "DT_NOTE"];
                    _flexT[_flexT.Row, "NM_USERDE1"] = _flexD[_flexD.Row, "NM_USERDE1"];
                    _flexT[_flexT.Row, "NM_USERDE2"] = _flexD[_flexD.Row, "NM_USERDE2"];

                    _flexT[_flexT.Row, "CPNAME"] = _flexD[_flexD.Row, "CPNAME"];
                    _flexT[_flexT.Row, "AY_YEAR_MONTH"] = _flexD[_flexD.Row, "AY_YEAR_MONTH"];
                    _flexT[_flexT.Row, "AY_TRADE_TYPE_CD"] = _flexD[_flexD.Row, "AY_TRADE_TYPE_CD"];
                    _flexT[_flexT.Row, "AY_TRADE_TYPE"] = _flexD[_flexD.Row, "AY_TRADE_TYPE"];
                    _flexT[_flexT.Row, "AY_AGENCYNM"] = _flexD[_flexD.Row, "AY_AGENCYNM"];
                    _flexT[_flexT.Row, "ME_YEAR_MONTH"] = _flexD[_flexD.Row, "ME_YEAR_MONTH"];
                    _flexT[_flexT.Row, "ME_TRADE_TYPE_CD"] = _flexD[_flexD.Row, "ME_TRADE_TYPE_CD"];
                    _flexT[_flexT.Row, "ME_TRADE_TYPE"] = _flexD[_flexD.Row, "ME_TRADE_TYPE"];
                    _flexT[_flexT.Row, "ME_CORPNM"] = _flexD[_flexD.Row, "ME_CORPNM"];
                    _flexT[_flexT.Row, "AM_BUDGET"] = 0;
                    _flexT[_flexT.Row, "AM_AGY_PRICE"] = -1 * am_agy_price;
                    _flexT[_flexT.Row, "AM_INCOME"] = _flexD[_flexD.Row, "AM_INCOME"];
                    _flexT[_flexT.Row, "AM_MEDIA_PRICE"] = 0;
                    _flexT[_flexT.Row, "AM_FEE_ALL"] = _flexD[_flexD.Row, "AM_FEE_ALL"];

                    _flexT.Rows.Add();
                    _flexT.Row = _flexT.Rows.Count - 1;

                    DateTime ay_year_month = DateTime.Now;
                    string ay_year_month_2 = "";

                    _flexT[_flexT.Row, "CD_COMPANY"] = _flexD[_flexD.Row, "CD_COMPANY"];
                    _flexT[_flexT.Row, "TP_SALES"] = _flexD[_flexD.Row, "TP_SALES"];
                    _flexT[_flexT.Row, "MER_REQ_NO"] = _flexD[_flexD.Row, "MER_REQ_NO"];
                    _flexT[_flexT.Row, "MER_REQ_NO_NM"] = "이월";
                    _flexT[_flexT.Row, "ME_CPID"] = _flexD[_flexD.Row, "ME_CPID"];
                    _flexT[_flexT.Row, "ME_SEQ"] = _flexD[_flexD.Row, "ME_SEQ"];
                    _flexT[_flexT.Row, "DT_YEAR_MONTH"] = _flexD[_flexD.Row, "DT_YEAR_MONTH"];
                    _flexT[_flexT.Row, "AY_AGENCYID"] = _flexD[_flexD.Row, "AY_AGENCYID"];
                    _flexT[_flexT.Row, "AY_AGENCYNO"] = _flexD[_flexD.Row, "AY_AGENCYNO"];
                    _flexT[_flexT.Row, "ME_CORPID"] = _flexD[_flexD.Row, "ME_CORPID"];
                    _flexT[_flexT.Row, "ME_CORPNO"] = _flexD[_flexD.Row, "ME_CORPNO"];
                    _flexT[_flexT.Row, "AY_AGENCYID_ORI"] = _flexD[_flexD.Row, "AY_AGENCYID_ORI"];
                    _flexT[_flexT.Row, "AY_AGENCYNM_ORI"] = _flexD[_flexD.Row, "AY_AGENCYNM_ORI"];
                    _flexT[_flexT.Row, "CD_SYSDEF"] = _flexD[_flexD.Row, "CD_SYSDEF"];
                    _flexT[_flexT.Row, "CD_ACCT"] = _flexD[_flexD.Row, "CD_ACCT"];
                    _flexT[_flexT.Row, "ME_TEAMID"] = _flexD[_flexD.Row, "ME_TEAMID"];
                    _flexT[_flexT.Row, "ME_TEAMNM"] = _flexD[_flexD.Row, "ME_TEAMNM"];
                    _flexT[_flexT.Row, "ME_TEAMLV"] = _flexD[_flexD.Row, "ME_TEAMLV"];
                    _flexT[_flexT.Row, "ME_TEAMORD"] = _flexD[_flexD.Row, "ME_TEAMORD"];
                    _flexT[_flexT.Row, "CP_AGENTID"] = _flexD[_flexD.Row, "CP_AGENTID"];
                    _flexT[_flexT.Row, "CP_AGENTNM"] = _flexD[_flexD.Row, "CP_AGENTNM"];
                    _flexT[_flexT.Row, "CP_AGENTNO"] = _flexD[_flexD.Row, "CP_AGENTNO"];
                    _flexT[_flexT.Row, "NM_NOTE"] = _flexD[_flexD.Row, "NM_NOTE"];
                    _flexT[_flexT.Row, "ID_NOTE"] = _flexD[_flexD.Row, "ID_NOTE"];
                    _flexT[_flexT.Row, "DT_NOTE"] = _flexD[_flexD.Row, "DT_NOTE"];
                    _flexT[_flexT.Row, "NM_USERDE1"] = _flexD[_flexD.Row, "NM_USERDE1"];
                    _flexT[_flexT.Row, "NM_USERDE2"] = _flexD[_flexD.Row, "NM_USERDE2"];

                    _flexT[_flexT.Row, "CPNAME"] = _flexD[_flexD.Row, "CPNAME"];

                    //ay_year_month = DateTime.ParseExact(_flexD[_flexD.Row, "AY_YEAR_MONTH"].ToString(), "yyyyMM", System.Globalization.CultureInfo.InvariantCulture);
                    //ay_year_month_2 = ay_year_month.AddMonths(1).ToString("yyyyMM");

                    _flexT[_flexT.Row, "AY_YEAR_MONTH"] = _flexD[_flexD.Row, "AY_YEAR_MONTH"];
                    _flexT[_flexT.Row, "AY_TRADE_TYPE_CD"] = _flexD[_flexD.Row, "AY_TRADE_TYPE_CD"];
                    _flexT[_flexT.Row, "AY_TRADE_TYPE"] = _flexD[_flexD.Row, "AY_TRADE_TYPE"];
                    _flexT[_flexT.Row, "AY_AGENCYNM"] = _flexD[_flexD.Row, "AY_AGENCYNM"];
                    _flexT[_flexT.Row, "ME_YEAR_MONTH"] = _flexD[_flexD.Row, "ME_YEAR_MONTH"];
                    _flexT[_flexT.Row, "ME_TRADE_TYPE_CD"] = _flexD[_flexD.Row, "ME_TRADE_TYPE_CD"];
                    _flexT[_flexT.Row, "ME_TRADE_TYPE"] = _flexD[_flexD.Row, "ME_TRADE_TYPE"];
                    _flexT[_flexT.Row, "ME_CORPNM"] = _flexD[_flexD.Row, "ME_CORPNM"];
                    _flexT[_flexT.Row, "AM_BUDGET"] = 0;
                    _flexT[_flexT.Row, "AM_AGY_PRICE"] = _flexD[_flexD.Row, "AM_AGY_PRICE"];
                    _flexT[_flexT.Row, "AM_INCOME"] = -1 * am_income;
                    _flexT[_flexT.Row, "AM_MEDIA_PRICE"] = 0;
                    _flexT[_flexT.Row, "AM_FEE_ALL"] = _flexD[_flexD.Row, "AM_FEE_ALL"];
                }
                
                //_flexT.Cols["MER_REQ_NO_NM"].AllowEditing = false;
                //_flexT.Cols["CPNAME"].AllowEditing = false;
                //_flexT.Cols["AY_TRADE_TYPE"].AllowEditing = false;
                //_flexT.Cols["AY_AGENCYNM"].AllowEditing = false;
                //_flexT.Cols["ME_TRADE_TYPE"].AllowEditing = false;
                //_flexT.Cols["ME_CORPNM"].AllowEditing = false;
                //_flexT.Cols["AM_MEDIA_PRICE"].AllowEditing = false;
                //_flexT.Cols["NO_DOCU_M"].AllowEditing = false;
                //_flexT.Cols["NO_DOCU_D"].AllowEditing = false;

                _flexT.AddFinished();

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

        //_flexD 하단그리드
        void _flexM_AfterRowChange(object sender, RangeEventArgs e)
        {
            try
            {
                object[] Params = new object[7];
                Params[0] = LoginInfo.CompanyCode;
                Params[1] = cbo구분.SelectedValue;
                Params[2] = dp년월.Text;
                Params[3] = D.GetString(_flexM["NO_COMPANY"]);
                Params[4] = txt캠페인명.Text;
                Params[5] = cbo이월구분.SelectedValue;
                Params[6] = txt대행사매체명.Text;

                DataSet ds = _biz.Search_D(Params);
                
                _flexD.Binding = ds.Tables[0];
            }
            catch (Exception ex)
            {
                this.MsgEnd(ex);
            }
        }

        //_flexT 하단그리드
        void _flexD_AfterRowChange(object sender, RangeEventArgs e)
        {
            try
            {
                object[] Params = new object[6];
                Params[0] = LoginInfo.CompanyCode;
                Params[1] = cbo구분.SelectedValue;
                Params[2] = dp년월.Text;
                Params[3] = D.GetString(_flexD["TP_SALES"]);
                Params[4] = D.GetString(_flexD["ME_CPID"]);
                Params[5] = D.GetString(_flexD["ME_SEQ"]);

                DataSet ds = _biz.Search_T(Params);

                _flexT.Binding = ds.Tables[0];
            }
            catch (Exception ex)
            {
                this.MsgEnd(ex);
            }
        }

        void _flexT_AfterEdit(object sender, RowColEventArgs e)
        {
            try
            {
                switch (_flexT.Cols[e.Col].Name)
                {
                    case "AM_BUDGET":
                    case "AM_INCOME":
                    case "AM_AGY_PRICE":
                        decimal AM_SALES_1 = D.GetDecimal(_flexT[e.Row, "AM_BUDGET"]);
                        decimal AM_SALES_2 = D.GetDecimal(_flexT[e.Row, "AM_AGY_PRICE"]);
                        decimal AM_SALES_3 = D.GetDecimal(_flexT[e.Row, "AM_INCOME"]);

                        _flexT[e.Row, "AM_MEDIA_PRICE"] = AM_SALES_1 - AM_SALES_2 - AM_SALES_3;

                        break;                  
                }
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }

        void _flexD_HelpClick(object sender, EventArgs e)
        {
            try
            {
                string 대행사전표번호 = D.GetString(_flexD["NO_DOCU_M"]);
                string 매체전표번호 = D.GetString(_flexD["NO_DOCU_D"]);

                if (대행사전표번호 == "" && 매체전표번호 == "")
                    return;

                switch (_flexD.Cols[_flexD.Col].Name)
                {
                    case "NO_DOCU_M":

                        if (대행사전표번호 == "")
                            return;

                        object[] Args = { 대행사전표번호, "", "", Global.MainFrame.LoginInfo.CompanyCode };
                        CallOtherPageMethod("P_FI_DOCU", "전표입력(" + PageName + ")", Grant, Args);

                        break;

                    case "NO_DOCU_D":

                        if (매체전표번호 == "")
                            return;

                        object[] Args2 = { 매체전표번호, "", "", Global.MainFrame.LoginInfo.CompanyCode };
                        CallOtherPageMethod("P_FI_DOCU", "전표입력(" + PageName + ")", Grant, Args2);

                        break;
                }
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }

        void _flexT_HelpClick(object sender, EventArgs e)
        {
            try
            {
                string 대행사전표번호 = D.GetString(_flexT["NO_DOCU_M"]);
                string 매체전표번호 = D.GetString(_flexT["NO_DOCU_D"]);

                if (대행사전표번호 == "" && 매체전표번호 == "")
                    return;

                switch (_flexT.Cols[_flexT.Col].Name)
                {
                    case "NO_DOCU_M":

                        if (대행사전표번호 == "")
                            return;

                        object[] Args = { 대행사전표번호, "", "", Global.MainFrame.LoginInfo.CompanyCode };
                        CallOtherPageMethod("P_FI_DOCU", "전표입력(" + PageName + ")", Grant, Args);

                        break;

                    case "NO_DOCU_D":

                        if (매체전표번호 == "")
                            return;

                        object[] Args2 = { 매체전표번호, "", "", Global.MainFrame.LoginInfo.CompanyCode };
                        CallOtherPageMethod("P_FI_DOCU", "전표입력(" + PageName + ")", Grant, Args2);

                        break;
                }
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }

        void _flexT_StartEdit(object sender, RowColEventArgs e)
        {
            switch (_flexT.Cols[_flexT.Col].Name)
            {
                case "MER_REQ_NO_NM":
                case "CPNAME":
                case "AY_TRADE_TYPE":
                case "AY_AGENCYNM":
                case "ME_TRADE_TYPE":
                case "ME_CORPNM":
                case "AM_MEDIA_PRICE":
                case "NO_DOCU_M":
                case "NO_DOCU_D":

                    e.Cancel = true;
                    break;
            }
        }

        #endregion

        #region ♥ 기타 Property
        string ServerKey { get { return Global.MainFrame.ServerKeyCommon.ToUpper(); } }

        private void _flexM_OwnerDrawCell(object sender, OwnerDrawCellEventArgs e)
        {
            CellRange rg;
            CellStyle csCellstyle = _flexM.Styles.Add("CellStyle");

            if (!_flexM.HasNormalRow)
                return;

            if (e.Row < _flexM.Rows.Fixed || e.Col < _flexM.Cols.Fixed)
                return;
          
            if (D.GetString(_flexM[e.Row, "PARTNER_CHK"]) == "2")
            {
                rg = _flexM.GetCellRange(e.Row, "NO_COMPANY2");
                rg.StyleNew.BackColor = System.Drawing.Color.FromArgb(((Byte)(255)), ((Byte)(126)), ((Byte)(126)));
                rg = _flexM.GetCellRange(e.Row, "LN_PARTNER2");
                rg.StyleNew.BackColor = System.Drawing.Color.FromArgb(((Byte)(255)), ((Byte)(126)), ((Byte)(126)));
            }

            if (D.GetDecimal(_flexM[e.Row, "CNT"]) > 0)
            {
                csCellstyle.BackColor = System.Drawing.Color.FromArgb(((Byte)(183)), ((Byte)(240)), ((Byte)(177)));
                _flexM.Rows[e.Row].Style = csCellstyle;
            }

            if (D.GetDecimal(_flexM[e.Row, "AM_TAXSTD1"]) < 0)
            {
                rg = _flexM.GetCellRange(e.Row, "AM_TAXSTD1");
                rg.StyleNew.ForeColor = System.Drawing.Color.Red;
            }

            if (D.GetDecimal(_flexM[e.Row, "AM_ADDTAX1"]) < 0)
            {
                rg = _flexM.GetCellRange(e.Row, "AM_ADDTAX1");
                rg.StyleNew.ForeColor = System.Drawing.Color.Red;
            }

            if (D.GetDecimal(_flexM[e.Row, "AM_SUM1"]) < 0)
            {
                rg = _flexM.GetCellRange(e.Row, "AM_SUM1");
                rg.StyleNew.ForeColor = System.Drawing.Color.Red;
            }

            if (D.GetDecimal(_flexM[e.Row, "AM_TAXSTD2"]) < 0)
            {
                rg = _flexM.GetCellRange(e.Row, "AM_TAXSTD2");
                rg.StyleNew.ForeColor = System.Drawing.Color.Red;
            }

            if (D.GetDecimal(_flexM[e.Row, "AM_ADDTAX2"]) < 0)
            {
                rg = _flexM.GetCellRange(e.Row, "AM_ADDTAX2");
                rg.StyleNew.ForeColor = System.Drawing.Color.Red;
            }

            if (D.GetDecimal(_flexM[e.Row, "AM_SUM2"]) < 0)
            {
                rg = _flexM.GetCellRange(e.Row, "AM_SUM2");
                rg.StyleNew.ForeColor = System.Drawing.Color.Red;
            }

            if (D.GetDecimal(_flexM[e.Row, "AM_TAXSTD"]) < 0)
            {
                rg = _flexM.GetCellRange(e.Row, "AM_TAXSTD");
                rg.StyleNew.ForeColor = System.Drawing.Color.Red;
            }

            if (D.GetDecimal(_flexM[e.Row, "AM_ADDTAX"]) < 0)
            {
                rg = _flexM.GetCellRange(e.Row, "AM_ADDTAX");
                rg.StyleNew.ForeColor = System.Drawing.Color.Red;
            }

            if (D.GetDecimal(_flexM[e.Row, "AM_SUM"]) < 0)
            {
                rg = _flexM.GetCellRange(e.Row, "AM_SUM");
                rg.StyleNew.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void _flexD_OwnerDrawCell(object sender, OwnerDrawCellEventArgs e)
        {
            CellRange rg;
            CellStyle csCellstyle = _flexD.Styles.Add("CellStyle");

            if (!_flexD.HasNormalRow)
                return;

            if (e.Row < _flexD.Rows.Fixed || e.Col < _flexD.Cols.Fixed)
                return;

            if (D.GetDecimal(_flexD[e.Row, "AM_BUDGET"]) < 0)
            {
                rg = _flexD.GetCellRange(e.Row, "AM_BUDGET");
                rg.StyleNew.ForeColor = System.Drawing.Color.Red;
            }

            if (D.GetDecimal(_flexD[e.Row, "AM_AGY_PRICE"]) < 0)
            {
                rg = _flexD.GetCellRange(e.Row, "AM_AGY_PRICE");
                rg.StyleNew.ForeColor = System.Drawing.Color.Red;
            }

            if (D.GetDecimal(_flexD[e.Row, "AM_INCOME"]) < 0)
            {
                rg = _flexD.GetCellRange(e.Row, "AM_INCOME");
                rg.StyleNew.ForeColor = System.Drawing.Color.Red;
            }

            if (D.GetDecimal(_flexD[e.Row, "AM_MEDIA_PRICE"]) < 0)
            {
                rg = _flexD.GetCellRange(e.Row, "AM_MEDIA_PRICE");
                rg.StyleNew.ForeColor = System.Drawing.Color.Red;
            }

            if (D.GetDecimal(_flexD[e.Row, "CNT"]) > 0)
            {
                //csCellstyle.BackColor = System.Drawing.Color.FromArgb(((Byte)(55)), ((Byte)(220)), ((Byte)(20)));
                csCellstyle.BackColor = System.Drawing.Color.FromArgb(((Byte)(183)), ((Byte)(240)), ((Byte)(177)));
                _flexD.Rows[e.Row].Style = csCellstyle;
            }
        }

        private void _flexT_OwnerDrawCell(object sender, OwnerDrawCellEventArgs e)
        {
            CellRange rg;
            CellStyle csCellstyle = _flexT.Styles.Add("CellStyle");

            if (!_flexT.HasNormalRow)
                return;

            if (e.Row < _flexT.Rows.Fixed || e.Col < _flexT.Cols.Fixed)
                return;

            if (D.GetDecimal(_flexT[e.Row, "AM_BUDGET"]) < 0)
            {
                rg = _flexT.GetCellRange(e.Row, "AM_BUDGET");
                rg.StyleNew.ForeColor = System.Drawing.Color.Red;
            }

            if (D.GetDecimal(_flexT[e.Row, "AM_AGY_PRICE"]) < 0)
            {
                rg = _flexT.GetCellRange(e.Row, "AM_AGY_PRICE");
                rg.StyleNew.ForeColor = System.Drawing.Color.Red;
            }

            if (D.GetDecimal(_flexT[e.Row, "AM_INCOME"]) < 0)
            {
                rg = _flexT.GetCellRange(e.Row, "AM_INCOME");
                rg.StyleNew.ForeColor = System.Drawing.Color.Red;
            }

            if (D.GetDecimal(_flexT[e.Row, "AM_MEDIA_PRICE"]) < 0)
            {
                rg = _flexT.GetCellRange(e.Row, "AM_MEDIA_PRICE");
                rg.StyleNew.ForeColor = System.Drawing.Color.Red;
            }

        }
        #endregion            
    }
}