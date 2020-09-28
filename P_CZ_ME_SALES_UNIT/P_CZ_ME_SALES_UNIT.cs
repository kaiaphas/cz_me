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
    // 작성일 : 2020-09-08
    // 모듈명 : 합산예산단위등록
    // 페이지 : P_CZ_ME_SALES_UNIT
    // **************************************

    public partial class P_CZ_ME_SALES_UNIT : PageBase
    {
        #region ♥ 멤버필드

        private P_CZ_ME_SALES_UNIT_BIZ _biz = new P_CZ_ME_SALES_UNIT_BIZ();
        bool _타메뉴호출 = false;
        
        DataTable dt = new DataTable();

        #endregion

        #region ♥ 초기화

        #region -> 생성자

        public P_CZ_ME_SALES_UNIT()
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
            //_flexM 메인그리드
           _flexM.BeginSetting(1, 1, false);

           _flexM.SetCol("코드", "코드", 100, false);
           _flexM.SetCol("부서명", "부서명", 150, false);
           _flexM.SetCol("예산단위코드", "예산단위코드", 100, true);
           _flexM.SetCol("예산단위명", "예산단위명", 150, false);
           _flexM.SetCol("합산코드", "합산코드", 100, true);
           _flexM.SetCol("합산예산단위명", "합산예산단위명", 150, false);
           _flexM.SetCol("CC코드", "C/C코드", 100, true);
           _flexM.SetCol("CC명", "C/C명", 150, false);

           _flexM.Cols["코드"].TextAlign = TextAlignEnum.CenterCenter;
           _flexM.Cols["예산단위코드"].TextAlign = TextAlignEnum.CenterCenter;
           _flexM.Cols["합산코드"].TextAlign = TextAlignEnum.CenterCenter;
           _flexM.Cols["CC코드"].TextAlign = TextAlignEnum.CenterCenter;

           _flexM.SettingVersion = new Random().Next().ToString();
           _flexM.EndSetting(GridStyleEnum.Green, AllowSortingEnum.MultiColumn, SumPositionEnum.None);

           _flexM.SetCodeHelpCol("예산단위코드", HelpID.P_FI_BGCODE_DEPT_SUB, ShowHelpEnum.Always, new string[] { "예산단위코드", "예산단위명" }, new string[] { "CD_BUDGET", "NM_BUDGET" }, ResultMode.FastMode);
           _flexM.SetCodeHelpCol("합산코드", HelpID.P_FI_BGCODE_DEPT_SUB, ShowHelpEnum.Always, new string[] { "합산코드", "합산예산단위명" }, new string[] { "CD_BUDGET", "NM_BUDGET" }, ResultMode.FastMode);
           _flexM.SetCodeHelpCol("CC코드", HelpID.P_MA_CC_SUB, ShowHelpEnum.Always, new string[] { "CC코드", "CC명" }, new string[] { "CD_CC", "NM_CC" }, ResultMode.FastMode);
        }
        #endregion

        #region -> InitPaint

        protected override void InitPaint()
        {
            base.InitPaint();

            Grant.CanAdd = false;
            Grant.CanDelete = false;
            Grant.CanPrint = false;

        }

        #endregion

        #endregion

        #region ♥ 메인버튼 클릭

        #region -> 조회버튼클릭

        public override void OnToolBarSearchButtonClicked(object sender, EventArgs e)
        {
            try
            {
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
            try
            {
                if (!BeforeSaveChk())
                    return;

                if (SaveData())
                {
                    ShowMessage(PageResultMode.SaveGood);
                    {
                        object[] Params = new object[1];
                        Params[0] = LoginInfo.CompanyCode;

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

            obj = _biz.Save(_flexM.GetChanges(), _타메뉴호출);

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

        #endregion

        #region ♥ 기타 이벤트

        #endregion

        #region ♥ 그리드 이벤트

        #endregion

        #region ♥ 기타 Property
        string ServerKey { get { return Global.MainFrame.ServerKeyCommon.ToUpper(); } }

        #endregion            
    }
}