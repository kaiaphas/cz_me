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
    // 재 작  성 일 : 2020-10-19
    // 모   듈   명 : 지급계좌관리
    // 시 스  템 명 : 지급계좌관리
    // 서브시스템명 : 지급계좌관리
    // 페 이 지  명 : 지급계좌관리
    // 프로젝트  명 : CZ_ME_SALES_PAYABLE
    // **************************************
    public partial class P_CZ_ME_SALES_PAYABLE : PageBase
    {
        #region ♥ 멤버필드

        private P_CZ_ME_SALES_PAYABLE_BIZ _biz = new P_CZ_ME_SALES_PAYABLE_BIZ();
        bool _타메뉴호출 = false;

        #endregion

        #region ♥ 초기화

        #region -> 생성자

        public P_CZ_ME_SALES_PAYABLE()
        {
            InitializeComponent();
            MainGrids = new FlexGrid[] { _flexM };    //그리드 자동 저장 기능 필요시 주석 해제
        }

        #endregion

        #region -> InitLoad

        protected override void InitLoad()
        {
            base.InitLoad();

            Grant.CanPrint = false;

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
            
            _flexM.SetCol("CD_COMPANY", "회사구분", 0, false);
            _flexM.SetCol("CD_PARTNER", "거래처코드", 100, true);
            _flexM.SetCol("LN_PARTNER", "거래처명", 150, false);
            _flexM.SetCol("CD_MEDIA", "매체코드", 100, true);
            _flexM.SetCol("NM_MEDIA", "매체명", 150, false);
            _flexM.SetCol("TP_PAYABLE", "지급조건", 100, true);
            _flexM.SetCol("CD_BANK", "은행코드", 100, true);
            _flexM.SetCol("NO_DEPOSIT", "계좌번호", 120, true);
            _flexM.SetCol("NM_DEPOSIT", "예금주", 50, true);
            _flexM.SetCol("NO_COMPANY", "사업자등록번호", 100, true);
            _flexM.SetCol("NM_COMPANY", "사업자등록증법인명", 150, true);
            _flexM.SetCol("MA_CEO", "사업자등록증대표자명", 100, true);
            _flexM.SetCol("NM_NOTE", "비고", 200, true);
            _flexM.SetCol("CD_DEPOSITNO", "계좌번호코드", 100, false);
            _flexM.SetCol("CD_USE", "사용여부", 100, true);
            _flexM.SetCol("USE_YN", "주요사용", 35, true, CheckTypeEnum.Y_N);

            _flexM.SetDummyColumn("S");
            _flexM.Cols.Frozen = 1;

            _flexM.Cols["NO_COMPANY"].Format = _flexM.Cols["NO_COMPANY"].EditMask = "###-##-#####";
            _flexM.Cols["NO_COMPANY"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.SetStringFormatCol("NO_COMPANY");
            _flexM.SetNoMaskSaveCol("NO_COMPANY");

            //_flexM.Cols["DT_SIGN"].TextAlign = TextAlignEnum.CenterCenter;
         
            _flexM.SettingVersion = "1.0.0.6";// new Random().Next().ToString();
            _flexM.EndSetting(GridStyleEnum.Green, AllowSortingEnum.MultiColumn, SumPositionEnum.None);

            _flexM.SetCodeHelpCol("CD_PARTNER", HelpID.P_MA_PARTNER_SUB, ShowHelpEnum.Always, new string[] { "CD_PARTNER", "LN_PARTNER", "NO_COMPANY" }, new string[] { "CD_PARTNER", "LN_PARTNER", "CD_PARTNER" }, ResultMode.FastMode);

            _flexM.SetCodeHelpCol("CD_MEDIA", "H_CZ_HELP01", ShowHelpEnum.Always, new string[] { "CD_MEDIA", "NM_MEDIA" }, new string[] { "CD_MEDIA", "NM_MEDIA" });
          
            _flexM.BeforeCodeHelp += new BeforeCodeHelpEventHandler(_flexM_BeforeCodeHelp);

            _flexM.VerifyNotNull = new string[] { "CD_PARTNER", "CD_MEDIA", "NO_DEPOSIT" };
        }

        #endregion

        #region -> InitPaint

        protected override void InitPaint()
        {
            base.InitPaint();

            UGrant grant = new UGrant();

            try
            {
                _flexM.SetDataMap("TP_PAYABLE", MA.GetCode("CZ_ME_C023", true), "CODE", "NAME");
                _flexM.SetDataMap("CD_BANK", MA.GetCode("MA_B000043", true), "CODE", "NAME");
                _flexM.SetDataMap("CD_USE", MA.GetCode("CZ_ME_C014"), "CODE", "NAME");

                SetControl set = new SetControl();
                set.SetCombobox(cbo사용여부, MA.GetCode("CZ_ME_C014", true));

                
                SetToolBarButtonState(true, true, false, false, false);
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
                object[] Params = new object[3];
                Params[0] = LoginInfo.CompanyCode;
                Params[1] = MULTI_CD_CORP.QueryWhereIn_Pipe.Replace("|", "");
                Params[2] = cbo사용여부.SelectedValue;
                
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

                _flexM[_flexM.Row, "CD_COMPANY"] = Global.MainFrame.LoginInfo.CompanyCode;
                _flexM[_flexM.Row, "CD_USE"] = "Y"; 

                _flexM.AddFinished();
                _flexM.Col = _flexM.Cols.Fixed;
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

        void _flexM_BeforeCodeHelp(object sender, BeforeCodeHelpEventArgs e)
        {
            try
            {
                switch (_flexM.Cols[e.Col].Name)
                {
                    case "CD_MEDIA":

                        e.Parameter.UserParams = "매체 도움창;H_CZ_ME_COR;";
                        break;
                }

            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }
        #endregion

        #endregion

        #region ♥ 기타 Property
        string ServerKey { get { return Global.MainFrame.ServerKeyCommon.ToUpper(); } }
        #endregion
    }
}
