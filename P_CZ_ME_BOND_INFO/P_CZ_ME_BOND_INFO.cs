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
    // 작성일 : 2020-10-05
    // 모듈명 : 채권보전서류
    // 페이지 : P_CZ_ME_BOND_INFO
    // **************************************

    public partial class P_CZ_ME_BOND_INFO : PageBase
    {
        #region ♥ 멤버필드

        private P_CZ_ME_BOND_INFO_BIZ _biz = new P_CZ_ME_BOND_INFO_BIZ();
        bool _타메뉴호출 = false;
        
        DataTable dt = new DataTable();

        #endregion

        #region ♥ 초기화

        #region -> 생성자

        public P_CZ_ME_BOND_INFO()
        {
            InitializeComponent();
        }

        #endregion

        #region -> InitLoad

        protected override void InitLoad()
        {
            base.InitLoad();
        }

        #endregion

        #region -> InitGrid

        private void InitGrid()
        {

        }
        #endregion

        #region -> InitPaint

        protected override void InitPaint()
        {
            base.InitPaint();

            Grant.CanAdd = false;
            Grant.CanDelete = false;
            Grant.CanSave = false;
            Grant.CanPrint = false;

            dp만기일.Value = DateTime.Now;
            dp소멸시효.Value = DateTime.Now;
            dp시작일.Value = DateTime.Now;
            dp체결일.Value = DateTime.Now;
            dp_6_시작일.Value = DateTime.Now;
            dp_6_종료일.Value = DateTime.Now;

            //콤보박스 셋팅
            SetControl set = new SetControl();
            set.SetCombobox(cbo보전서류구분, MA.GetCode("CZ_ME_C019", true));

            txt_1_채무자.Enabled = false;
            txt_1_물건지.Enabled = false;
            txt_1_소유자.Enabled = false;

            txt_2_종류.Enabled = false;
            txt_2_증권번호.Enabled = false;
            txt_2_발행인1.Enabled = false;
            txt_2_발행인2.Enabled = false;
            txt_2_발행인3.Enabled = false;

            txt_3_보험료.Enabled = false;
            txt_3_증권번호.Enabled = false;

            txt_4_연대보증인1.Enabled = false;
            txt_4_연대보증인2.Enabled = false;
            txt_4_연대보증인3.Enabled = false;

            txt_5_제3채1.Enabled = false;
            txt_5_제3채2.Enabled = false;
            txt_5_제3채3.Enabled = false;

            txt_6_구분.Enabled = false;
            dp_6_시작일.Enabled = false;
            dp_6_종료일.Enabled = false;
            txt_6_분할횟수.Enabled = false;
            txt_6_특이사항.Enabled = false;

            txt_7_비고.Enabled = false;

            btn입력.Click += new EventHandler(btn입력_Click);

           // cboIO상태.SelectedIndex = 0;
           // cbo세금계산서발행상태.SelectedIndex = 2;
        }

        #endregion

        #endregion

        #region ♥ 메인버튼 클릭

        #region -> 조회버튼클릭

        public override void OnToolBarSearchButtonClicked(object sender, EventArgs e)
        {
            searchNo();
        }

        public void searchNo()
        {
            try
            {
                object[] Params = new object[3];
                Params[0] = LoginInfo.CompanyCode;
                Params[1] = MULTI_CD_CORP.QueryWhereIn_Pipe.Replace("|", "");
                Params[2] = cbo보전서류구분.SelectedValue.ToString();

                DataTable dt = new DataTable();

                DataSet ds = _biz.Search_M(Params);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    dt = ds.Tables[0];

                    //MULTI_CD_CORP.CodeValues = dt.Rows[0]["NO_COMPANY"].ToString();

                    MULTI_CD_CORP.UserCodeValue = dt.Rows[0]["NO_COMPANY"].ToString();
                    cbo보전서류구분.SelectedValue = dt.Rows[0]["DOCU_GUBUN"].ToString();
                    txt설정액.Text = dt.Rows[0]["AM_SET"].ToString();
                    dp체결일.Text = dt.Rows[0]["DT_SIGN"].ToString();
                    dp시작일.Text = dt.Rows[0]["DT_START"].ToString();
                    dp만기일.Text = dt.Rows[0]["DT_END"].ToString();
                    dp소멸시효.Text = dt.Rows[0]["DT_LIMIT"].ToString();
                    txt_1_채무자.Text = dt.Rows[0]["NM_USERDE1_1"].ToString();
                    txt_1_소유자.Text = dt.Rows[0]["NM_USERDE2_1"].ToString();
                    txt_1_물건지.Text = dt.Rows[0]["NM_USERDE3_1"].ToString();
                    txt_2_종류.Text = dt.Rows[0]["NM_USERDE1_2"].ToString();
                    txt_2_증권번호.Text = dt.Rows[0]["NM_USERDE2_2"].ToString();
                    txt_2_발행인1.Text = dt.Rows[0]["NM_USERDE3_2"].ToString();
                    txt_2_발행인2.Text = dt.Rows[0]["NM_USERDE4_2"].ToString();
                    txt_2_발행인3.Text = dt.Rows[0]["NM_USERDE5_2"].ToString();
                    txt_3_증권번호.Text = dt.Rows[0]["NM_USERDE1_3"].ToString();
                    txt_3_보험료.Text = dt.Rows[0]["NM_USERDE2_3"].ToString();
                    txt_4_연대보증인1.Text = dt.Rows[0]["NM_USERDE1_4"].ToString();
                    txt_4_연대보증인2.Text = dt.Rows[0]["NM_USERDE2_4"].ToString();
                    txt_4_연대보증인3.Text = dt.Rows[0]["NM_USERDE3_4"].ToString();
                    txt_5_제3채1.Text = dt.Rows[0]["NM_USERDE1_5"].ToString();
                    txt_5_제3채2.Text = dt.Rows[0]["NM_USERDE2_5"].ToString();
                    txt_5_제3채3.Text = dt.Rows[0]["NM_USERDE3_5"].ToString();
                    txt_6_구분.Text = dt.Rows[0]["NM_USERDE1_6"].ToString();
                    dp_6_시작일.Text = dt.Rows[0]["NM_USERDE2_6"].ToString();
                    dp_6_종료일.Text = dt.Rows[0]["NM_USERDE3_6"].ToString();
                    txt_6_분할횟수.Text = dt.Rows[0]["NM_USERDE4_6"].ToString();
                    txt_6_특이사항.Text = dt.Rows[0]["NM_USERDE5_6"].ToString();
                    txt_7_비고.Text = dt.Rows[0]["NM_USERDE1_7"].ToString();
                }
                //_flexM.Binding = ds.Tables[0];
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
                
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }

        // 실제 저장 기능
        protected override bool SaveData()
        {
            return true;
        }

        // 저장 전 체크 사항
        protected bool BeforeSaveChk()
        {
            string 거래처 = MULTI_CD_CORP.QueryWhereIn_Pipe.Replace("|", "");
            string 종류 = cbo보전서류구분.SelectedValue.ToString();
            string 설정액 = txt설정액.Text;

            if (거래처.Equals("") || 종류.Equals("") || 설정액.Equals(""))
            {
                ShowMessage("거래처, 종류, 설정액은 필수 입력 값 입니다.");
                return false;
            }
            else
            {
                return true;
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

        #endregion

        #region ♥ 기타 이벤트

        private void MULTI_CD_CORP_QueryBefore(object sender, BpQueryArgs e)
        {
            MULTI_CD_CORP.UserParams = "매체 도움창;H_CZ_ME_GR;" + MULTI_CD_CORP.CodeNames + ";";
        }

        private void cbo보전서류구분_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbo보전서류구분.SelectedIndex.ToString())
            {
                case "1":

                    txt_1_채무자.Enabled = true;
                    txt_1_물건지.Enabled = true;
                    txt_1_소유자.Enabled = true;

                    txt_2_종류.Enabled = false;
                    txt_2_증권번호.Enabled = false;
                    txt_2_발행인1.Enabled = false;
                    txt_2_발행인2.Enabled = false;
                    txt_2_발행인3.Enabled = false;

                    txt_3_보험료.Enabled = false;
                    txt_3_증권번호.Enabled = false;

                    txt_4_연대보증인1.Enabled = false;
                    txt_4_연대보증인2.Enabled = false;
                    txt_4_연대보증인3.Enabled = false;

                    txt_5_제3채1.Enabled = false;
                    txt_5_제3채2.Enabled = false;
                    txt_5_제3채3.Enabled = false;

                    txt_6_구분.Enabled = false;
                    dp_6_시작일.Enabled = false;
                    dp_6_종료일.Enabled = false;
                    txt_6_분할횟수.Enabled = false;
                    txt_6_특이사항.Enabled = false;

                    txt_7_비고.Enabled = false;
                   
                    break;
              
                case "2":

                    txt_1_채무자.Enabled = false;
                    txt_1_물건지.Enabled = false;
                    txt_1_소유자.Enabled = false;

                    txt_2_종류.Enabled = true;
                    txt_2_증권번호.Enabled = true;
                    txt_2_발행인1.Enabled = true;
                    txt_2_발행인2.Enabled = true;
                    txt_2_발행인3.Enabled = true;

                    txt_3_보험료.Enabled = false;
                    txt_3_증권번호.Enabled = false;

                    txt_4_연대보증인1.Enabled = false;
                    txt_4_연대보증인2.Enabled = false;
                    txt_4_연대보증인3.Enabled = false;

                    txt_5_제3채1.Enabled = false;
                    txt_5_제3채2.Enabled = false;
                    txt_5_제3채3.Enabled = false;

                    txt_6_구분.Enabled = false;
                    dp_6_시작일.Enabled = false;
                    dp_6_종료일.Enabled = false;
                    txt_6_분할횟수.Enabled = false;
                    txt_6_특이사항.Enabled = false;

                    txt_7_비고.Enabled = false;

                    break;

                case "3":

                    txt_1_채무자.Enabled = false;
                    txt_1_물건지.Enabled = false;
                    txt_1_소유자.Enabled = false;

                    txt_2_종류.Enabled = false;
                    txt_2_증권번호.Enabled = false;
                    txt_2_발행인1.Enabled = false;
                    txt_2_발행인2.Enabled = false;
                    txt_2_발행인3.Enabled = false;

                    txt_3_보험료.Enabled = true;
                    txt_3_증권번호.Enabled = true;

                    txt_4_연대보증인1.Enabled = false;
                    txt_4_연대보증인2.Enabled = false;
                    txt_4_연대보증인3.Enabled = false;

                    txt_5_제3채1.Enabled = false;
                    txt_5_제3채2.Enabled = false;
                    txt_5_제3채3.Enabled = false;

                    txt_6_구분.Enabled = false;
                    dp_6_시작일.Enabled = false;
                    dp_6_종료일.Enabled = false;
                    txt_6_분할횟수.Enabled = false;
                    txt_6_특이사항.Enabled = false;

                    txt_7_비고.Enabled = false;

                    break;

                case "4":

                    txt_1_채무자.Enabled = false;
                    txt_1_물건지.Enabled = false;
                    txt_1_소유자.Enabled = false;

                    txt_2_종류.Enabled = false;
                    txt_2_증권번호.Enabled = false;
                    txt_2_발행인1.Enabled = false;
                    txt_2_발행인2.Enabled = false;
                    txt_2_발행인3.Enabled = false;

                    txt_3_보험료.Enabled = false;
                    txt_3_증권번호.Enabled = false;

                    txt_4_연대보증인1.Enabled = true;
                    txt_4_연대보증인2.Enabled = true;
                    txt_4_연대보증인3.Enabled = true;

                    txt_5_제3채1.Enabled = false;
                    txt_5_제3채2.Enabled = false;
                    txt_5_제3채3.Enabled = false;

                    txt_6_구분.Enabled = false;
                    dp_6_시작일.Enabled = false;
                    dp_6_종료일.Enabled = false;
                    txt_6_분할횟수.Enabled = false;
                    txt_6_특이사항.Enabled = false;

                    txt_7_비고.Enabled = false;

                    break;

                case "5":

                    txt_1_채무자.Enabled = false;
                    txt_1_물건지.Enabled = false;
                    txt_1_소유자.Enabled = false;

                    txt_2_종류.Enabled = false;
                    txt_2_증권번호.Enabled = false;
                    txt_2_발행인1.Enabled = false;
                    txt_2_발행인2.Enabled = false;
                    txt_2_발행인3.Enabled = false;

                    txt_3_보험료.Enabled = false;
                    txt_3_증권번호.Enabled = false;

                    txt_4_연대보증인1.Enabled = false;
                    txt_4_연대보증인2.Enabled = false;
                    txt_4_연대보증인3.Enabled = false;

                    txt_5_제3채1.Enabled = true;
                    txt_5_제3채2.Enabled = true;
                    txt_5_제3채3.Enabled = true;

                    txt_6_구분.Enabled = false;
                    dp_6_시작일.Enabled = false;
                    dp_6_종료일.Enabled = false;
                    txt_6_분할횟수.Enabled = false;
                    txt_6_특이사항.Enabled = false;

                    txt_7_비고.Enabled = false;

                    break;

                case "6":

                    txt_1_채무자.Enabled = false;
                    txt_1_물건지.Enabled = false;
                    txt_1_소유자.Enabled = false;

                    txt_2_종류.Enabled = false;
                    txt_2_증권번호.Enabled = false;
                    txt_2_발행인1.Enabled = false;
                    txt_2_발행인2.Enabled = false;
                    txt_2_발행인3.Enabled = false;

                    txt_3_보험료.Enabled = false;
                    txt_3_증권번호.Enabled = false;

                    txt_4_연대보증인1.Enabled = false;
                    txt_4_연대보증인2.Enabled = false;
                    txt_4_연대보증인3.Enabled = false;

                    txt_5_제3채1.Enabled = false;
                    txt_5_제3채2.Enabled = false;
                    txt_5_제3채3.Enabled = false;

                    txt_6_구분.Enabled = true;
                    dp_6_시작일.Enabled = true;
                    dp_6_종료일.Enabled = true;
                    txt_6_분할횟수.Enabled = true;
                    txt_6_특이사항.Enabled = true;

                    txt_7_비고.Enabled = false;

                    break;

                case "7":

                    txt_1_채무자.Enabled = false;
                    txt_1_물건지.Enabled = false;
                    txt_1_소유자.Enabled = false;

                    txt_2_종류.Enabled = false;
                    txt_2_증권번호.Enabled = false;
                    txt_2_발행인1.Enabled = false;
                    txt_2_발행인2.Enabled = false;
                    txt_2_발행인3.Enabled = false;

                    txt_3_보험료.Enabled = false;
                    txt_3_증권번호.Enabled = false;

                    txt_4_연대보증인1.Enabled = false;
                    txt_4_연대보증인2.Enabled = false;
                    txt_4_연대보증인3.Enabled = false;

                    txt_5_제3채1.Enabled = false;
                    txt_5_제3채2.Enabled = false;
                    txt_5_제3채3.Enabled = false;

                    txt_6_구분.Enabled = false;
                    dp_6_시작일.Enabled = false;
                    dp_6_종료일.Enabled = false;
                    txt_6_분할횟수.Enabled = false;
                    txt_6_특이사항.Enabled = false;

                    txt_7_비고.Enabled = true;

                    break;

                default:

                    txt_1_채무자.Enabled = false;
                    txt_1_물건지.Enabled = false;
                    txt_1_소유자.Enabled = false;

                    txt_2_종류.Enabled = false;
                    txt_2_증권번호.Enabled = false;
                    txt_2_발행인1.Enabled = false;
                    txt_2_발행인2.Enabled = false;
                    txt_2_발행인3.Enabled = false;

                    txt_3_보험료.Enabled = false;
                    txt_3_증권번호.Enabled = false;

                    txt_4_연대보증인1.Enabled = false;
                    txt_4_연대보증인2.Enabled = false;
                    txt_4_연대보증인3.Enabled = false;

                    txt_5_제3채1.Enabled = false;
                    txt_5_제3채2.Enabled = false;
                    txt_5_제3채3.Enabled = false;

                    txt_6_구분.Enabled = false;
                    dp_6_시작일.Enabled = false;
                    dp_6_종료일.Enabled = false;
                    txt_6_분할횟수.Enabled = false;
                    txt_6_특이사항.Enabled = false;

                    txt_7_비고.Enabled = false;

                    break;
            }

            searchNo();
        }

        private void btn입력_Click(object sender, EventArgs e)
        {

            try
            {
                if (!BeforeSaveChk())
                    return;

                if (ShowMessage("데이터를 저장 하시겠습니까?", "QY2") == DialogResult.Yes)
                {
                    string 거래처 = "";
                    string 종류 = "";
                    string 설정액 = "";
                    string 체결일 = "";
                    string 시작일 = "";
                    string 만기일 = "";
                    string 소멸시효 = "";
                    string 채무자 = "";
                    string 소유자 = "";
                    string 물건지 = "";
                    string 종류2 = "";
                    string 증권번호 = "";
                    string 발행인1 = "";
                    string 발행인2 = "";
                    string 발행인3 = "";
                    string 증권번호2 = "";
                    string 보험료 = "";
                    string 연대보증인1 = "";
                    string 연대보증인2 = "";
                    string 연대보증인3 = "";
                    string 제3채1 = "";
                    string 제3채2 = "";
                    string 제3채3 = "";
                    string 구분 = "";
                    string 시작일2 = "";
                    string 종료일 = "";
                    string 분할횟수 = "";
                    string 특이사항 = "";
                    string 비고 = "";           

                    switch (cbo보전서류구분.SelectedIndex.ToString())
                    {
                        case "1":

                            거래처 = MULTI_CD_CORP.QueryWhereIn_Pipe.Replace("|", "");
                            종류 = cbo보전서류구분.SelectedValue.ToString();
                            설정액 = txt설정액.Text.Replace(",", "");
                            체결일 = dp체결일.Text.Replace("-", "");
                            시작일 = dp시작일.Text.Replace("-", "");
                            만기일 = dp만기일.Text.Replace("-", "");
                            소멸시효 = dp소멸시효.Text.Replace("-", "");
                            채무자 = txt_1_채무자.Text;
                            소유자 = txt_1_소유자.Text;
                            물건지 = txt_1_물건지.Text;
                            종류2 = "";
                            증권번호 = "";
                            발행인1 = "";
                            발행인2 = "";
                            발행인3 = "";
                            증권번호2 = "";
                            보험료 = "";
                            연대보증인1 = "";
                            연대보증인2 = "";
                            연대보증인3 = "";
                            제3채1 = "";
                            제3채2 = "";
                            제3채3 = "";
                            구분 = "";
                            시작일2 = "";
                            종료일 = "";
                            분할횟수 = "";
                            특이사항 = "";
                            비고 = "";
                            
                            break;

                        case "2":

                            거래처 = MULTI_CD_CORP.QueryWhereIn_Pipe.Replace("|", "");
                           종류 = cbo보전서류구분.SelectedValue.ToString();
                           설정액 = txt설정액.Text.Replace(",", "");
                           체결일 = dp체결일.Text.Replace("-", "");
                           시작일 = dp시작일.Text.Replace("-", "");
                           만기일 = dp만기일.Text.Replace("-", "");
                           소멸시효 = dp소멸시효.Text.Replace("-", "");
                           채무자 = "";
                           소유자 = "";
                           물건지 = "";
                           종류2 = txt_2_종류.Text;
                           증권번호 = txt_2_증권번호.Text;
                           발행인1 = txt_2_발행인1.Text;
                           발행인2 = txt_2_발행인2.Text;
                           발행인3 = txt_2_발행인3.Text;
                           증권번호2 = "";
                           보험료 = "";
                           연대보증인1 = "";
                           연대보증인2 = "";
                           연대보증인3 = "";
                           제3채1 = "";
                           제3채2 = "";
                           제3채3 = "";
                           구분 = "";
                           시작일2 = "";
                           종료일 = "";
                           분할횟수 = "";
                           특이사항 = "";
                           비고 = "";

                            break;

                        case "3":

                            거래처 = MULTI_CD_CORP.QueryWhereIn_Pipe.Replace("|", "");
                            종류 = cbo보전서류구분.SelectedValue.ToString();
                            설정액 = txt설정액.Text.Replace(",", "");
                            체결일 = dp체결일.Text.Replace("-", "");
                            시작일 = dp시작일.Text.Replace("-", "");
                            만기일 = dp만기일.Text.Replace("-", "");
                            소멸시효 = dp소멸시효.Text.Replace("-", "");
                            채무자 = "";
                            소유자 = "";
                            물건지 = "";
                            종류2 = "";
                            증권번호 = "";
                            발행인1 = "";
                            발행인2 = "";
                            발행인3 = "";
                            증권번호2 = txt_3_증권번호.Text;
                            보험료 = txt_3_보험료.Text;
                            연대보증인1 = "";
                            연대보증인2 = "";
                            연대보증인3 = "";
                            제3채1 = "";
                            제3채2 = "";
                            제3채3 = "";
                            구분 = "";
                            시작일2 = "";
                            종료일 = "";
                            분할횟수 = "";
                            특이사항 = "";
                            비고 = "";

                            break;

                        case "4":

                            거래처 = MULTI_CD_CORP.QueryWhereIn_Pipe.Replace("|", "");
                            종류 = cbo보전서류구분.SelectedValue.ToString();
                            설정액 = txt설정액.Text.Replace(",", "");
                            체결일 = dp체결일.Text.Replace("-", "");
                            시작일 = dp시작일.Text.Replace("-", "");
                            만기일 = dp만기일.Text.Replace("-", "");
                            소멸시효 = dp소멸시효.Text.Replace("-", "");
                            채무자 = "";
                            소유자 = "";
                            물건지 = "";
                            종류2 = "";
                            증권번호 = "";
                            발행인1 = "";
                            발행인2 = "";
                            발행인3 = "";
                            증권번호2 = "";
                            보험료 = "";
                            연대보증인1 = txt_4_연대보증인1.Text;
                            연대보증인2 = txt_4_연대보증인2.Text;
                            연대보증인3 = txt_4_연대보증인3.Text;
                            제3채1 = "";
                            제3채2 = "";
                            제3채3 = "";
                            구분 = "";
                            시작일2 = "";
                            종료일 = "";
                            분할횟수 = "";
                            특이사항 = "";
                            비고 = "";

                            break;

                        case "5":

                            거래처 = MULTI_CD_CORP.QueryWhereIn_Pipe.Replace("|", "");
                            종류 = cbo보전서류구분.SelectedValue.ToString();
                            설정액 = txt설정액.Text.Replace(",", "");
                            체결일 = dp체결일.Text.Replace("-", "");
                            시작일 = dp시작일.Text.Replace("-", "");
                            만기일 = dp만기일.Text.Replace("-", "");
                            소멸시효 = dp소멸시효.Text.Replace("-", "");
                            채무자 = "";
                            소유자 = "";
                            물건지 = "";
                            종류2 = "";
                            증권번호 = "";
                            발행인1 = "";
                            발행인2 = "";
                            발행인3 = "";
                            증권번호2 = "";
                            보험료 = "";
                            연대보증인1 = "";
                            연대보증인2 = "";
                            연대보증인3 = "";
                            제3채1 = txt_5_제3채1.Text;
                            제3채2 = txt_5_제3채2.Text;
                            제3채3 = txt_5_제3채3.Text;
                            구분 = "";
                            시작일2 = "";
                            종료일 = "";
                            분할횟수 = "";
                            특이사항 = "";
                            비고 = "";

                            break;

                        case "6":

                            거래처 = MULTI_CD_CORP.QueryWhereIn_Pipe.Replace("|", "");
                            종류 = cbo보전서류구분.SelectedValue.ToString();
                            설정액 = txt설정액.Text.Replace(",", "");
                            체결일 = dp체결일.Text.Replace("-", "");
                            시작일 = dp시작일.Text.Replace("-", "");
                            만기일 = dp만기일.Text.Replace("-", "");
                            소멸시효 = dp소멸시효.Text.Replace("-", "");
                            채무자 = "";
                            소유자 = "";
                            물건지 = "";
                            종류2 = "";
                            증권번호 = "";
                            발행인1 = "";
                            발행인2 = "";
                            발행인3 = "";
                            증권번호2 = "";
                            보험료 = "";
                            연대보증인1 = "";
                            연대보증인2 = "";
                            연대보증인3 = "";
                            제3채1 = "";
                            제3채2 = "";
                            제3채3 = "";
                            구분 = txt_6_구분.Text;
                            시작일2 = dp_6_시작일.Text.Replace("-", "");
                            종료일 = dp_6_종료일.Text.Replace("-", "");
                            분할횟수 = txt_6_분할횟수.Text;
                            특이사항 = txt_6_특이사항.Text;
                            비고 = "";

                            break;

                        case "7":

                            거래처 = MULTI_CD_CORP.QueryWhereIn_Pipe.Replace("|", "");
                            종류 = cbo보전서류구분.SelectedValue.ToString();
                            설정액 = txt설정액.Text.Replace(",", "");
                            체결일 = dp체결일.Text.Replace("-", "");
                            시작일 = dp시작일.Text.Replace("-", "");
                            만기일 = dp만기일.Text.Replace("-", "");
                            소멸시효 = dp소멸시효.Text.Replace("-", "");
                            채무자 = "";
                            소유자 = "";
                            물건지 = "";
                            종류2 = "";
                            증권번호 = "";
                            발행인1 = "";
                            발행인2 = "";
                            발행인3 = "";
                            증권번호2 = "";
                            보험료 = "";
                            연대보증인1 = "";
                            연대보증인2 = "";
                            연대보증인3 = "";
                            제3채1 = "";
                            제3채2 = "";
                            제3채3 = "";
                            구분 = "";
                            시작일2 = "";
                            종료일 = "";
                            분할횟수 = "";
                            특이사항 = "";
                            비고 = txt_7_비고.Text;  

                            break;
                    }
                   
                    /*
                    string 거래처 = MULTI_CD_CORP.QueryWhereIn_Pipe;
                    string 종류 = cbo보전서류구분.SelectedValue.ToString();
                    string 설정액 = txt설정액.Text;
                    string 체결일 = dp체결일.Text;
                    string 시작일 = dp시작일.Text;
                    string 만기일 = dp만기일.Text;
                    string 소멸시효 = dp소멸시효.Text;
                    string 채무자 = txt_1_채무자.Text;
                    string 소유자 = txt_1_소유자.Text;
                    string 물건지 = txt_1_물건지.Text;
                    string 종류2 = txt_2_종류.Text;
                    string 증권번호 = txt_2_증권번호.Text;
                    string 발행인1 = txt_2_발행인1.Text;
                    string 발행인2 = txt_2_발행인2.Text;
                    string 발행인3 = txt_2_발행인3.Text;
                    string 증권번호2 = txt_3_증권번호.Text;
                    string 보험료 = txt_3_보험료.Text;
                    string 연대보증인1 = txt_4_연대보증인1.Text;
                    string 연대보증인2 = txt_4_연대보증인2.Text;
                    string 연대보증인3 = txt_4_연대보증인3.Text;
                    string 제3채1 = txt_5_제3채1.Text;
                    string 제3채2 = txt_5_제3채2.Text;
                    string 제3채3 = txt_5_제3채3.Text;
                    string 구분 = txt_6_구분.Text;
                    string 시작일2 = dp_6_시작일.Text;
                    string 종료일 = dp_6_종료일.Text;
                    string 분할횟수 = txt_6_분할횟수.Text;
                    string 특이사항 = txt_6_특이사항.Text;
                    string 비고 = txt_7_비고.Text;                    
                    */

                    if (_biz.Insert_Info( 거래처, 종류, 설정액, 체결일, 시작일
                                        , 만기일, 소멸시효, 채무자, 소유자, 물건지
                                        , 종류2, 증권번호, 발행인1, 발행인2, 발행인3
                                        , 증권번호2, 보험료, 연대보증인1, 연대보증인2, 연대보증인3
                                        , 제3채1, 제3채2, 제3채3, 구분, 시작일2
                                        , 종료일, 분할횟수, 특이사항, 비고))
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

        private void txt설정액_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자만 입력되도록 필터링
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back))) // 숫자와 백스페이스
            {
                e.Handled = true;
            }
        }

        private void txt설정액_TextChanged(object sender, EventArgs e)
        {
            if (txt설정액.Text != "")
            {
                string value = txt설정액.Text.Replace(",", "");

                Int64 data = Int64.Parse(value);

                txt설정액.Text = string.Format("{0:###,###,###,###,###,###,###}", data);
                txt설정액.SelectionStart = txt설정액.Text.Length;
                txt설정액.ScrollToCaret();
            }
        }


        #endregion

        #region ♥ 그리드 이벤트

        #endregion

        #region ♥ 기타 Property
        string ServerKey { get { return Global.MainFrame.ServerKeyCommon.ToUpper(); } }


        #endregion            
    }
}