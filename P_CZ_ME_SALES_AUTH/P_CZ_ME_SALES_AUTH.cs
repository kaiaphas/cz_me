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
    // 모듈명 : 예산계정별접근권한
    // 페이지 : P_CZ_ME_SALES_AUTH
    // **************************************

    public partial class P_CZ_ME_SALES_AUTH : PageBase
    {
        #region ♥ 멤버필드

        private P_CZ_ME_SALES_AUTH_BIZ _biz = new P_CZ_ME_SALES_AUTH_BIZ();
        bool _타메뉴호출 = false;
        
        DataTable dt = new DataTable();

        #endregion

        #region ♥ 초기화

        #region -> 생성자

        public P_CZ_ME_SALES_AUTH()
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

           _flexM.SetCol("예산계정코드", "CD_BGACCT", 0, false);
            _flexM.SetCol("대목코드", "대목코드", 100, false);
            _flexM.SetCol("대목명", "대목명", 100, false);
            _flexM.SetCol("세목코드", "세목코드", 100, false);
            _flexM.SetCol("세목명", "세목명", 0, false);
            _flexM.SetCol("통제구분", "통제구분", 100, false);
            _flexM.SetCol("기간통제", "기간통제", 100, false);
            _flexM.SetCol("공통비분배", "공통비분배", 100, true);
            _flexM.SetCol("개인경비", "개인경비", 100, true);
            _flexM.SetCol("일반경비", "일반경비", 100, true);
            _flexM.SetCol("접근레벨", "접근레벨", 100, true);

            _flexM.Cols["대목코드"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["세목코드"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["통제구분"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["기간통제"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["공통비분배"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["개인경비"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["일반경비"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["접근레벨"].TextAlign = TextAlignEnum.CenterCenter;
        
            _flexM.SettingVersion = new Random().Next().ToString();
            _flexM.EndSetting(GridStyleEnum.Green, AllowSortingEnum.MultiColumn, SumPositionEnum.None);
        }
        #endregion

        #region -> InitPaint

        protected override void InitPaint()
        {
            base.InitPaint();

            Grant.CanAdd = false;
            Grant.CanDelete = false;
            Grant.CanPrint = false;

            //콤보박스 셋팅
            _flexM.SetDataMap("공통비분배", MA.GetCode("CZ_ME_C013", true), "CODE", "NAME");
            _flexM.SetDataMap("개인경비", MA.GetCode("CZ_ME_C013", true), "CODE", "NAME");
            _flexM.SetDataMap("일반경비", MA.GetCode("CZ_ME_C013", true), "CODE", "NAME");
            _flexM.SetDataMap("접근레벨", MA.GetCode("CZ_ME_C015", true), "CODE", "NAME");

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