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
    // 작성일 : 2020-07-28
    // 모듈명 : IO대사
    // 페이지 : P_CZ_ME_SALES_IO
    // **************************************

    public partial class P_CZ_ME_SALES_IO_SUB : PageBase
    {
        #region ♥ 멤버필드

        private P_CZ_ME_SALES_IO_BIZ _biz = new P_CZ_ME_SALES_IO_BIZ();
        bool _타메뉴호출 = false;

        string today = "";
        string toyear = "";
        string rdo_idx = "";
        #endregion

        #region ♥ 초기화

        #region -> 생성자

        public P_CZ_ME_SALES_IO_SUB()
        {
            InitializeComponent();

            MainGrids = new FlexGrid[] { _flexM };
            _flexM.DetailGrids = new FlexGrid[] { _flexD };
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

            _flexM.SetCol("S", "선택", 35, true, CheckTypeEnum.Y_N);

            _flexM.SetCol("CPID", "CPID", 0, false);

            _flexM.SetCol("DUZON_STATDT", "요청일시", 100, false);
            _flexM.SetCol("IO상태", "IO 상태", 100, false);
            _flexM.SetCol("발행상태", "발행상태", 100, false);
            _flexM.SetCol("사유", "사유", 200, false);
            _flexM.SetCol("발행일시", "발행(반려)일시", 100, false);
            _flexM.SetCol("NO_DOCU", "전표번호", 100, false);

            _flexM.SetCol("TP_TAXSTATUS", "세금계산서", 0, false);
            _flexM.SetCol("DUZON_NOTE", "비고", 0, false);
           
            _flexM.SetCol("MONTH2", "월", 40, false);
            _flexM.SetCol("TEAMNAME", "팀", 100, false);
            _flexM.SetCol("CPNAME", "캠페인", 200, false);
            _flexM.SetCol("PERIOD", "기간", 200, false);
            _flexM.SetCol("MEZZO_AE_NAME", "담당자", 100, false);
            _flexM.SetCol("BUDGET", "수주액", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("AGY_PRICE", "대행사 수수료", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("INCOME", "내수액", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("AGENTNAME", "광고주", 120, false);
            _flexM.SetCol("BIZ_NAME", "대행사", 120, false);
            _flexM.SetCol("AGENCY_AE_NAME", "대행사담당자(설정정보)", 100, false);
            
            _flexM.SetCol("AGENTNAME2", "광고주명", 120, false);
            _flexM.SetCol("CPNAME2", "캠페인명", 200, false);

            _flexM.SetCol("BIZ_NAME2", "신청인(대행사)", 120, false);
            _flexM.SetCol("AGENCY_AE_NAME2", "담당자", 100, false);
            _flexM.SetCol("AGE_MGR", "대표", 100, false);
            _flexM.SetCol("AGE_PHONE", "전화번호", 100, false);
            _flexM.SetCol("AGE_FAX", "팩스번호", 100, false);
            _flexM.SetCol("BIZ_NO", "사업자번호", 100, false);
            _flexM.SetCol("AGENCY_AE_EMAIL", "이메일", 150, false);
            _flexM.SetCol("ADDRESS", "주소", 250, false);
            _flexM.SetCol("BIZ_TYPE", "업종", 100, false);
            _flexM.SetCol("AGE_OUTDATE_TXT", "계산서 발행일", 100, false);
            _flexM.SetCol("AGE_FEE", "수수료율", 120, false);
            _flexM.SetCol("PERIOD2", "계약기간", 200, false);
            _flexM.SetCol("ACNAME", "결제조건", 180, false);
            _flexM.SetCol("AGE_BUDGET", "금액", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("AGE_ACDATE_TXT", "입금일", 100, false);


            _flexM.Cols["DUZON_STATDT"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["IO상태"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["발행상태"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["발행일시"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["NO_DOCU"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["TP_TAXSTATUS"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["MONTH2"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["BIZ_NO"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["PERIOD"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["AGE_PHONE"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["AGE_FAX"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["AGE_OUTDATE_TXT"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["PERIOD2"].TextAlign = TextAlignEnum.CenterCenter;

            //MERGE 처리
            _flexM[0, "DUZON_STATDT"] = _flexM[0, "TAX"] = "세금계산서 정보";
            _flexM[0, "IO상태"] = _flexM[0, "TAX"] = "세금계산서 정보";
            _flexM[0, "발행상태"] = _flexM[0, "TAX"] = "세금계산서 정보";
            _flexM[0, "사유"] = _flexM[0, "TAX"] = "세금계산서 정보";
            _flexM[0, "발행일시"] = _flexM[0, "TAX"] = "세금계산서 정보";
            _flexM[0, "NO_DOCU"] = _flexM[0, "TAX"] = "세금계산서 정보";

            _flexM[0, "MONTH2"] = _flexM[0, "IOL"] = "IO 발급목록";
            _flexM[0, "TEAMNAME"] = _flexM[0, "IOL"] = "IO 발급목록";
            _flexM[0, "CPNAME"] = _flexM[0, "IOL"] = "IO 발급목록";
            _flexM[0, "PERIOD"] = _flexM[0, "IOL"] = "IO 발급목록";
            _flexM[0, "MEZZO_AE_NAME"] = _flexM[0, "IOL"] = "IO 발급목록";
            _flexM[0, "BUDGET"] = _flexM[0, "IOL"] = "IO 발급목록";
            _flexM[0, "AGY_PRICE"] = _flexM[0, "IOL"] = "IO 발급목록";
            _flexM[0, "INCOME"] = _flexM[0, "IOL"] = "IO 발급목록";
            _flexM[0, "AGENTNAME"] = _flexM[0, "IOL"] = "IO 발급목록";
            _flexM[0, "BIZ_NAME"] = _flexM[0, "IOL"] = "IO 발급목록";
            _flexM[0, "AGENCY_AE_NAME"] = _flexM[0, "IOL"] = "IO 발급목록";

            _flexM[0, "AGENTNAME2"] = _flexM[0, "CAM"] = "Campaign Information";
            _flexM[0, "CPNAME2"] = _flexM[0, "CAM"] = "Campaign Information";
            
            _flexM[0, "BIZ_NAME2"] = _flexM[0, "AGE"] = "Agency Information";
            _flexM[0, "AGENCY_AE_NAME2"] = _flexM[0, "AGE"] = "Agency Information";
            _flexM[0, "AGE_MGR"] = _flexM[0, "AGE"] = "Agency Information";
            _flexM[0, "AGE_PHONE"] = _flexM[0, "AGE"] = "Agency Information";
            _flexM[0, "AGE_FAX"] = _flexM[0, "AGE"] = "Agency Information";
            _flexM[0, "BIZ_NO"] = _flexM[0, "AGE"] = "Agency Information";
            _flexM[0, "AGENCY_AE_EMAIL"] = _flexM[0, "AGE"] = "Agency Information";
            _flexM[0, "ADDRESS"] = _flexM[0, "AGE"] = "Agency Information";
            _flexM[0, "BIZ_TYPE"] = _flexM[0, "AGE"] = "Agency Information";
            _flexM[0, "AGE_OUTDATE_TXT"] = _flexM[0, "AGE"] = "Agency Information";
            _flexM[0, "AGE_FEE"] = _flexM[0, "AGE"] = "Agency Information";
            _flexM[0, "PERIOD2"] = _flexM[0, "AGE"] = "Agency Information";
            _flexM[0, "ACNAME"] = _flexM[0, "AGE"] = "Agency Information";
            _flexM[0, "AGE_BUDGET"] = _flexM[0, "AGE"] = "Agency Information";
            _flexM[0, "AGE_ACDATE_TXT"] = _flexM[0, "AGE"] = "Agency Information";
            
            _flexM.SetDummyColumn("S");

            _flexM.Cols.Frozen = 1;
            _flexM.Cols.Frozen = _flexM.Cols["DUZON_STATDT"].Index;
            _flexM.Cols.Frozen = _flexM.Cols["IO상태"].Index;
            _flexM.Cols.Frozen = _flexM.Cols["발행상태"].Index;
            _flexM.Cols.Frozen = _flexM.Cols["사유"].Index;
            _flexM.Cols.Frozen = _flexM.Cols["발행일시"].Index;
            _flexM.Cols.Frozen = _flexM.Cols["NO_DOCU"].Index;

            _flexM.SettingVersion = new Random().Next().ToString();
            _flexM.EndSetting(GridStyleEnum.Green, AllowSortingEnum.MultiColumn, SumPositionEnum.None);

            _flexM.AfterRowChange += new RangeEventHandler(_flexM_AfterRowChange);

            //_flexD 하단그리드
            _flexD.BeginSetting(1, 1, false);

            _flexD.SetCol("CD_ACCT", "계정코드", 100, false);
            _flexD.SetCol("NM_ACCT", "계정명", 100, false);
            _flexD.SetCol("NM_NOTE", "적요", 100, false);
            _flexD.SetCol("AM_DR", "차변", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexD.SetCol("AM_CR", "대변", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexD.SetCol("CD_PARTNER", "거래처코드", 100, false);        
            _flexD.SetCol("LN_PARTNER", "거래처명", 100, false);
            _flexD.SetCol("CD_MNGD1", "사업자등록번호", 100, false);
            _flexD.SetCol("CD_MNGD2", "코드", 100, false);
            _flexD.SetCol("NM_MNGD2", "코스트센터명", 100, false);


            _flexD.SettingVersion = new Random().Next().ToString();
            _flexD.EndSetting(GridStyleEnum.Green, AllowSortingEnum.MultiColumn, SumPositionEnum.None);
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

            string longtoday = "";

            longtoday = DateTime.Now.ToString("yyyMMddHHmmss");

            dp년월.Text = longtoday.Substring(0, 6);

            DateTime time = Global.MainFrame.GetDateTimeToday();
            
            //콤보박스 셋팅
            //_flexD.SetDataMap("CD_RELATION", MA.GetCode("FI_B000006"), "CODE", "NAME");
            //DataTable dt계정코드 = _biz.Get계정코드();
            //_flexM.SetDataMap("CD_ACCT", dt계정코드.Copy(), "CODE", "NAME");
            //_flexM.SetDataMap("ME_TRADE_TYPE", MA.GetCode("CZ_ME_C004"), "CODE", "NAME");

            //btn전표처리.Click += new EventHandler(btn전표처리_Click);          


            SetControl set = new SetControl();

            set.SetCombobox(cboIO상태, MA.GetCode("CZ_ME_C010", false));
            set.SetCombobox(cbo세금계산서발행상태, MA.GetCode("CZ_ME_C009", false));
            set.SetCombobox(cboIO상태값변경, MA.GetCode("CZ_ME_C011", false));

         
  
        }

        #endregion

        #endregion

        #region ♥ 메인버튼 클릭

        #region -> 조회버튼클릭

        public override void OnToolBarSearchButtonClicked(object sender, EventArgs e)
        {
            try
            {
                object[] Params = new object[3];
                Params[0] = LoginInfo.CompanyCode;
                Params[1] = "SELECT";
                Params[2] = dp년월.Text;
             
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
                        object[] Params = new object[3];
                        Params[0] = LoginInfo.CompanyCode;
                        Params[1] = "SELECT";
                        Params[2] = dp년월.Text;

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
            return false;
        }

        // 저장 전 체크 사항
        protected bool BeforeSaveChk()
        {
            return false;
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

        //_flexD 하단그리드
        void _flexM_AfterRowChange(object sender, RangeEventArgs e)
        {
            try
            {
                object[] Params = new object[5];
                Params[0] = "*";
                Params[1] = LoginInfo.CompanyCode;
                Params[2] = Global.MainFrame.LoginInfo.CdPc;
                Params[3] = D.GetString(_flexM["NO_DOCU"]);
                //Params[3] = "NO202004300089";
                Params[4] = "L0";

                DataSet ds = _biz.Search_D(Params);

                _flexD.Binding = ds.Tables[0];
            }
            catch (Exception ex)
            {
                this.MsgEnd(ex);
            }
        }
        #endregion

        #region ♥ 기타 Property
        string ServerKey { get { return Global.MainFrame.ServerKeyCommon.ToUpper(); } }
        #endregion     
    }
}