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

    public partial class P_CZ_ME_SALES_IO : PageBase
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

        public P_CZ_ME_SALES_IO()
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

            _flexM.SetCol("CPID", "CPID", 0, false);
            _flexM.SetCol("DUZON_STATDT", "요청일시", 100, false);
            _flexM.SetCol("ME_CPNM", "캠페인", 100, false);
            _flexM.SetCol("AM_AGYPRICE", "대행사 수수료", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("AGENTNAME", "캠페인 광고주명", 120, false);
            _flexM.SetCol("CPNAME", "캠페인명", 200, false);
            _flexM.SetCol("BIZ_NAME", "신청인", 120, false);
            _flexM.SetCol("AGE_MGR", "대표자", 100, false);
            _flexM.SetCol("BIZ_NO", "사업자번호", 100, false);
            _flexM.SetCol("ADDRESS", "주소", 250, false);
            _flexM.SetCol("AGENCY_AE_NAME", "담당자 이름", 100, false);
            _flexM.SetCol("AGENCY_AE_EMAIL", "담당자 이메일", 150, false);
            _flexM.SetCol("BIZ_TYPE", "업종", 100, false);
            _flexM.SetCol("AGE_PHONE", "전화번호", 100, false);
            _flexM.SetCol("AGE_FAX", "팩스번호", 100, false);
            _flexM.SetCol("AGE_FEE", "수수료율", 120, false);
            _flexM.SetCol("ACNAME", "결제조건", 180, false);
            _flexM.SetCol("AGE_ACDATE_TXT", "입금일", 100, false);
            _flexM.SetCol("AGE_OUTDATE_TXT", "계산서 발행일", 120, false);
            _flexM.SetCol("PERIOD", "계약기간", 200, false);
            _flexM.SetCol("AGE_BUDGET", "금액", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("AGENCY_ETC", "기타", 500, false);
            _flexM.SetCol("MEZZO_AE_NAME", "담당자 이름", 100, false);
            _flexM.SetCol("MEZZO_AE_EMAIL", "담당자 이메일", 150, false);
            _flexM.SetCol("MEZZO_AE_PHONE", "담당자 전화번호", 100, false);
            _flexM.SetCol("MEZZO_TEAM_NAME", "대리인 명", 100, false);
            _flexM.SetCol("MEZZO_FAX", "팩스번호", 100, false);
            _flexM.SetCol("MEZZO_CORPNAME", "상호", 150, false);
            _flexM.SetCol("MEZZO_CATE", "업종", 80, false);
            _flexM.SetCol("MEZZO_CEO", "대표자", 100, false);
            _flexM.SetCol("MEZZO_ADDRESS", "주소", 250, false);
            _flexM.SetCol("MEZZO_ACCOUNT", "계좌", 200, false);
            _flexM.SetCol("발행구분", "발행구분", 100, false);
            _flexM.SetCol("비고", "비고", 100, false);
            _flexM.SetCol("발행상태", "발행상태", 100, false);
            _flexM.SetCol("세금계산서번호", "세금계산서번호", 100, false);
            _flexM.SetCol("NO_DOCU", "전표정보", 100, false);

            _flexM.Cols["BIZ_NO"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["PERIOD"].TextAlign = TextAlignEnum.CenterCenter;

            //MERGE 처리
            _flexM[0, "BIZ_NAME"] = _flexM[0, "AGE"] = "대행사";
            _flexM[0, "AGE_MGR"] = _flexM[0, "AGE"] = "대행사";
            _flexM[0, "BIZ_NO"] = _flexM[0, "AGE"] = "대행사";
            _flexM[0, "ADDRESS"] = _flexM[0, "AGE"] = "대행사";
            _flexM[0, "AGENCY_AE_NAME"] = _flexM[0, "AGE"] = "대행사";
            _flexM[0, "AGENCY_AE_EMAIL"] = _flexM[0, "AGE"] = "대행사";
            _flexM[0, "BIZ_TYPE"] = _flexM[0, "AGE"] = "대행사";
            _flexM[0, "AGE_PHONE"] = _flexM[0, "AGE"] = "대행사";
            _flexM[0, "AGE_FAX"] = _flexM[0, "AGE"] = "대행사";
            _flexM[0, "AGE_FEE"] = _flexM[0, "AGE"] = "대행사";
            _flexM[0, "ACNAME"] = _flexM[0, "AGE"] = "대행사";
            _flexM[0, "AGE_ACDATE_TXT"] = _flexM[0, "AGE"] = "대행사";
            _flexM[0, "AGE_OUTDATE_TXT"] = _flexM[0, "AGE"] = "대행사";
            _flexM[0, "PERIOD"] = _flexM[0, "AGE"] = "대행사";
            _flexM[0, "AGE_BUDGET"] = _flexM[0, "AGE"] = "대행사";
            _flexM[0, "AGENCY_ETC"] = _flexM[0, "AGE"] = "대행사";
            
            //MERGE 처리
            _flexM[0, "MEZZO_AE_NAME"] = _flexM[0, "MED"] = "메조미디어";
            _flexM[0, "MEZZO_AE_EMAIL"] = _flexM[0, "MED"] = "메조미디어";
            _flexM[0, "MEZZO_AE_PHONE"] = _flexM[0, "MED"] = "메조미디어";
            _flexM[0, "MEZZO_TEAM_NAME"] = _flexM[0, "MED"] = "메조미디어";
            _flexM[0, "MEZZO_FAX"] = _flexM[0, "MED"] = "메조미디어";
            _flexM[0, "MEZZO_CORPNAME"] = _flexM[0, "MED"] = "메조미디어";
            _flexM[0, "MEZZO_CATE"] = _flexM[0, "MED"] = "메조미디어";
            _flexM[0, "MEZZO_CEO"] = _flexM[0, "MED"] = "메조미디어";
            _flexM[0, "MEZZO_ADDRESS"] = _flexM[0, "MED"] = "메조미디어";
            _flexM[0, "MEZZO_ACCOUNT"] = _flexM[0, "MED"] = "메조미디어";


            _flexM.SetDummyColumn("S");

            _flexM.Cols.Frozen = 1;

            _flexM.SettingVersion = "1.0.2.4";// new Random().Next().ToString();
            _flexM.EndSetting(GridStyleEnum.Green, AllowSortingEnum.MultiColumn, SumPositionEnum.None);

            //_flexM.SetCodeHelpCol("CD_DEPT", HelpID.P_MA_DEPT_SUB, ShowHelpEnum.Always, new string[] { "CD_DEPT", "NM_DEPT" }, new string[] { "CD_DEPT", "NM_DEPT" }, ResultMode.FastMode);
            //_flexM.SetCodeHelpCol("AY_AGENCYNO", HelpID.P_MA_PARTNER_SUB, ShowHelpEnum.Always, new string[] { "AY_AGENCYNO", "AY_AGENCYID", "AY_AGENCYNM" }, new string[] { "NO_COMPANY", "CD_PARTNER", "LN_PARTNER" }, ResultMode.FastMode);

            //_flexM.StartEdit += new RowColEventHandler(_flexM_StartEdit);

            //_flexM.BeforeCodeHelp += new BeforeCodeHelpEventHandler(_flexM_BeforeCodeHelp);
            //_flexM.OwnerDrawCell += new OwnerDrawCellEventHandler(_flexM_OwnerDrawCell);
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

            DateTime time = Global.MainFrame.GetDateTimeToday();

            toyear = time.ToString("yyyy") + "0101";

            dt일자.StartDate = DateTime.ParseExact(toyear, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            dt일자.EndDate = DateTime.ParseExact(toyear, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);

            //콤보박스 셋팅
            //DataTable dt계정코드 = _biz.Get계정코드();
            //_flexM.SetDataMap("CD_ACCT", dt계정코드.Copy(), "CODE", "NAME");
            //_flexM.SetDataMap("ME_TRADE_TYPE", MA.GetCode("CZ_ME_C004"), "CODE", "NAME");
            
            //btn전표처리.Click += new EventHandler(btn전표처리_Click);          
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
                Params[1] = "SELECT";
                Params[2] = dt일자.StartDateToString.Substring(0, 6);
                Params[3] = dt일자.EndDateToString.Substring(0, 6);
             
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
                        object[] Params = new object[6];
                        Params[0] = LoginInfo.CompanyCode;
                        Params[1] = "SELECT";
                        Params[2] = dt일자.StartDateToString.Substring(0, 6);
                        Params[3] = dt일자.EndDateToString.Substring(0, 6);
                        Params[4] = txt명.Text;
                        Params[5] = rdo_idx;

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

        #endregion

        #region ♥ 기타 Property
        string ServerKey { get { return Global.MainFrame.ServerKeyCommon.ToUpper(); } }
        #endregion

        private void btn전표처리_Click(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }
    }
}