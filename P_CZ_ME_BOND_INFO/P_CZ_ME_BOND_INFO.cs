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

        public override void OnCallExistingPageMethod(object sender, Duzon.Common.Forms.PageEventArgs e)
        {
            try
            {
                object[] obj = e.Args;

                ctx거래처.CodeValue = obj[0].ToString();
                ctx거래처.CodeName = obj[1].ToString();
                cbo보전서류구분.SelectedValue = obj[2].ToString();
                txt번호.Text = obj[3].ToString();
                txt기존번호.Text = obj[3].ToString();

                searchNo();

                SetToolBarButtonState(true, false, false, true, false);


            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
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

            //dp만기일.Value = DateTime.Now;
            //dp소멸시효.Value = DateTime.Now;
            dp시작일.Value = DateTime.Now;
            dp체결일.Value = DateTime.Now;
            dp_6_시작일.Value = DateTime.Now;
            dp_6_종료일.Value = DateTime.Now;
            dp_3_계약시작일.Value = DateTime.Now;
            dp_3_계약종료일.Value = DateTime.Now;
            dp_3_계약체결일자.Value = DateTime.Now;


            //콤보박스 셋팅
            SetControl set = new SetControl();
            set.SetCombobox(cbo보전서류구분, MA.GetCode("CZ_ME_C019", true));

            txt_1_채무자.Enabled = false;
            txt_1_물건지.Enabled = false;
            txt_1_소유자.Enabled = false;
            txt_1_memo.Enabled = false;

            txt_2_종류.Enabled = false;
            txt_2_증권번호.Enabled = false;
            txt_2_발행인1.Enabled = false;
            txt_2_발행인2.Enabled = false;
            txt_2_발행인3.Enabled = false;
            txt_2_memo.Enabled = false;

            cur_3_보험료.Enabled = false;
            txt_3_증권번호.Enabled = false;
            txt_3_주계약내용.Enabled = false;
            dp_3_계약시작일.Enabled = false;
            dp_3_계약종료일.Enabled = false;
            dp_3_계약체결일자.Enabled = false;
            cur_3_계약금액.Enabled = false;
            cur_3_발생채무액.Enabled = false;
            txt_3_memo.Enabled = false;

            txt_4_연대보증인1.Enabled = false;
            txt_4_연대보증인2.Enabled = false;
            txt_4_연대보증인3.Enabled = false;
            txt_4_memo.Enabled = false;

            txt_5_제3채1.Enabled = false;
            txt_5_제3채2.Enabled = false;
            txt_5_제3채3.Enabled = false;
            cur_5_채권양도통지서.Enabled = false;
            chk_5_인감증명서.Enabled = false;
            chk_5_부속합의서.Enabled = false;
            txt_5_memo.Enabled = false;

            txt_6_구분.Enabled = false;
            dp_6_시작일.Enabled = false;
            dp_6_종료일.Enabled = false;
            cur_6_분할횟수.Enabled = false;
            txt_6_특이사항.Enabled = false;
            txt_6_memo.Enabled = false;

            txt_7_비고.Enabled = false;
            txt_7_memo.Enabled = false;

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
                object[] Params = new object[4];
                Params[0] = LoginInfo.CompanyCode;
                Params[1] = ctx거래처.CodeValue;
                Params[2] = cbo보전서류구분.SelectedValue.ToString();
                Params[3] = txt번호.Text;

                DataTable dt = new DataTable();

                DataSet ds = _biz.Search_M(Params);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    dt = ds.Tables[0];

                    //MULTI_CD_CORP.CodeValues = dt.Rows[0]["NO_COMPANY"].ToString();

                    ctx거래처.CodeValue = dt.Rows[0]["NO_COMPANY"].ToString();
                    cbo보전서류구분.SelectedValue = dt.Rows[0]["DOCU_GUBUN"].ToString();
                    txt번호.Text = dt.Rows[0]["NO_GUBUN"].ToString();
                    txt기존번호.Text = dt.Rows[0]["NO_GUBUN"].ToString();
                    cur설정액.Text = dt.Rows[0]["AM_SET"].ToString();
                    dp체결일.Text = dt.Rows[0]["DT_SIGN"].ToString();
                    dp시작일.Text = dt.Rows[0]["DT_START"].ToString();
                    dp만기일.Text = dt.Rows[0]["DT_END"].ToString();
                    dp소멸시효.Text = dt.Rows[0]["DT_LIMIT"].ToString();
                    txt_1_채무자.Text = dt.Rows[0]["NM_USERDE1_1"].ToString();
                    txt_1_소유자.Text = dt.Rows[0]["NM_USERDE2_1"].ToString();
                    txt_1_물건지.Text = dt.Rows[0]["NM_USERDE3_1"].ToString();
                    txt_1_memo.Text = dt.Rows[0]["NM_USERDE4_1"].ToString();

                    txt_2_종류.Text = dt.Rows[0]["NM_USERDE1_2"].ToString();
                    txt_2_증권번호.Text = dt.Rows[0]["NM_USERDE2_2"].ToString();
                    txt_2_발행인1.Text = dt.Rows[0]["NM_USERDE3_2"].ToString();
                    txt_2_발행인2.Text = dt.Rows[0]["NM_USERDE4_2"].ToString();
                    txt_2_발행인3.Text = dt.Rows[0]["NM_USERDE5_2"].ToString();
                    txt_2_memo.Text = dt.Rows[0]["NM_USERDE6_2"].ToString();

                    txt_3_증권번호.Text = dt.Rows[0]["NM_USERDE1_3"].ToString();
                    cur_3_보험료.Text = dt.Rows[0]["NM_USERDE2_3"].ToString();
                    txt_3_주계약내용.Text = dt.Rows[0]["NM_USERDE3_3"].ToString();
                    dp_3_계약시작일.Text = dt.Rows[0]["NM_USERDE4_3"].ToString();
                    dp_3_계약종료일.Text = dt.Rows[0]["NM_USERDE5_3"].ToString();
                    dp_3_계약체결일자.Text = dt.Rows[0]["NM_USERDE6_3"].ToString();
                    cur_3_계약금액.Text = dt.Rows[0]["NM_USERDE7_3"].ToString();
                    cur_3_발생채무액.Text = dt.Rows[0]["NM_USERDE8_3"].ToString();
                    txt_3_memo.Text = dt.Rows[0]["NM_USERDE9_3"].ToString();

                    txt_4_연대보증인1.Text = dt.Rows[0]["NM_USERDE1_4"].ToString();
                    txt_4_연대보증인2.Text = dt.Rows[0]["NM_USERDE2_4"].ToString();
                    txt_4_연대보증인3.Text = dt.Rows[0]["NM_USERDE3_4"].ToString();
                    txt_4_memo.Text = dt.Rows[0]["NM_USERDE4_4"].ToString();

                    txt_5_제3채1.Text = dt.Rows[0]["NM_USERDE1_5"].ToString();
                    txt_5_제3채2.Text = dt.Rows[0]["NM_USERDE2_5"].ToString();
                    txt_5_제3채3.Text = dt.Rows[0]["NM_USERDE3_5"].ToString();
                    cur_5_채권양도통지서.Text = dt.Rows[0]["NM_USERDE4_5"].ToString();

                    if (dt.Rows[0]["NM_USERDE5_5"].ToString().Equals("Y"))
                    {
                        chk_5_인감증명서.Checked = true;
                    }
                    else
                    {
                        chk_5_인감증명서.Checked = false;
                    }

                    if (dt.Rows[0]["NM_USERDE6_5"].ToString().Equals("Y"))
                    {
                        chk_5_부속합의서.Checked = true;
                    }
                    else
                    {
                        chk_5_부속합의서.Checked = false;
                    }

                    txt_5_memo.Text = dt.Rows[0]["NM_USERDE7_5"].ToString();

                    txt_6_구분.Text = dt.Rows[0]["NM_USERDE1_6"].ToString();
                    dp_6_시작일.Text = dt.Rows[0]["NM_USERDE2_6"].ToString();
                    dp_6_종료일.Text = dt.Rows[0]["NM_USERDE3_6"].ToString();
                    cur_6_분할횟수.Text = dt.Rows[0]["NM_USERDE4_6"].ToString();
                    txt_6_특이사항.Text = dt.Rows[0]["NM_USERDE5_6"].ToString();
                    txt_6_memo.Text = dt.Rows[0]["NM_USERDE6_6"].ToString();

                    txt_7_비고.Text = dt.Rows[0]["NM_USERDE1_7"].ToString();
                    txt_7_memo.Text = dt.Rows[0]["NM_USERDE2_7"].ToString();
                }
                else
                {
                    ctx거래처.CodeValue = "";
                    ctx거래처.CodeName = "";
                    cbo보전서류구분.SelectedValue = "";
                    txt번호.Text = "";
                    txt기존번호.Text = "";
                    cur설정액.Text = "";
                    dp체결일.Value = DateTime.Now;
                    dp시작일.Value = DateTime.Now;
                    dp만기일.Text = "";
                    dp소멸시효.Text = "";

                    txt_1_채무자.Text = "";
                    txt_1_소유자.Text = "";
                    txt_1_물건지.Text = "";
                    txt_1_memo.Text = "";

                    txt_2_종류.Text = "";
                    txt_2_증권번호.Text = "";
                    txt_2_발행인1.Text = "";
                    txt_2_발행인2.Text = "";
                    txt_2_발행인3.Text = "";
                    txt_2_memo.Text = "";

                    txt_3_증권번호.Text = "";
                    cur_3_보험료.Text = "";
                    txt_3_주계약내용.Text = "";
                    dp_3_계약시작일.Text = "";
                    dp_3_계약종료일.Text = "";
                    dp_3_계약체결일자.Text = "";
                    cur_3_계약금액.Text = "";
                    cur_3_발생채무액.Text = "";
                    txt_3_memo.Text = "";

                    txt_4_연대보증인1.Text = "";
                    txt_4_연대보증인2.Text = "";
                    txt_4_연대보증인3.Text = "";
                    txt_4_memo.Text = "";

                    txt_5_제3채1.Text = "";
                    txt_5_제3채2.Text = "";
                    txt_5_제3채3.Text = "";
                    cur_5_채권양도통지서.Text = "";
                    chk_5_인감증명서.Checked =  false;
                    chk_5_부속합의서.Checked = false;
                    txt_5_memo.Text = "";

                    txt_6_구분.Text = "";
                    dp_6_시작일.Text = "";
                    dp_6_종료일.Text = "";
                    cur_6_분할횟수.Text = "";
                    txt_6_특이사항.Text = "";
                    txt_6_memo.Text = "";

                    txt_7_비고.Text = "";
                    txt_7_memo.Text = "";
                }
                //_flexM.Binding = ds.Tables[0];

                //SetToolBarButtonState(true, false, false, false, false);
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
            string 거래처 = ctx거래처.CodeValue;
            string 종류 = cbo보전서류구분.SelectedValue.ToString();
            string 체결일 = dp체결일.Text;

            if (거래처.Equals("") || 종류.Equals("") || 체결일.Equals(""))
            {
                ShowMessage("거래처, 종류, 체결일은 필수 입력 값 입니다.");
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
                if (ShowMessage(" 삭제하시겠습니까?", "QY2") == DialogResult.Yes)
                {
                    string 거래처코드 = ctx거래처.CodeValue;
                    string 보전서류구분 = cbo보전서류구분.SelectedValue.ToString();
                    string 번호 = txt번호.Text;

                    if (_biz.Delete_Info(거래처코드, 보전서류구분, 번호))
                    {

                    }
     
                    ShowMessage("삭제가 완료 되었습니다.");
                    searchNo();
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
                
             }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }

        }

        #endregion

        #endregion

        #region ♥ 기타 이벤트

        private void cbo보전서류구분_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbo보전서류구분.SelectedIndex.ToString())
            {
                case "1":

                    txt_1_채무자.Enabled = true;
                    txt_1_물건지.Enabled = true;
                    txt_1_소유자.Enabled = true;
                    txt_1_memo.Enabled = true;

                    txt_2_종류.Enabled = false;
                    txt_2_증권번호.Enabled = false;
                    txt_2_발행인1.Enabled = false;
                    txt_2_발행인2.Enabled = false;
                    txt_2_발행인3.Enabled = false;
                    txt_2_memo.Enabled = false;

                    cur_3_보험료.Enabled = false;
                    txt_3_증권번호.Enabled = false;
                    txt_3_주계약내용.Enabled = false;
                    dp_3_계약시작일.Enabled = false;
                    dp_3_계약종료일.Enabled = false;
                    dp_3_계약체결일자.Enabled = false;
                    cur_3_계약금액.Enabled = false;
                    cur_3_발생채무액.Enabled = false;
                    txt_3_memo.Enabled = false;

                    txt_4_연대보증인1.Enabled = false;
                    txt_4_연대보증인2.Enabled = false;
                    txt_4_연대보증인3.Enabled = false;
                    txt_4_memo.Enabled = false;

                    txt_5_제3채1.Enabled = false;
                    txt_5_제3채2.Enabled = false;
                    txt_5_제3채3.Enabled = false;
                    cur_5_채권양도통지서.Enabled = false;
                    chk_5_인감증명서.Enabled = false;
                    chk_5_부속합의서.Enabled = false;
                    txt_5_memo.Enabled = false;

                    txt_6_구분.Enabled = false;
                    dp_6_시작일.Enabled = false;
                    dp_6_종료일.Enabled = false;
                    cur_6_분할횟수.Enabled = false;
                    txt_6_특이사항.Enabled = false;
                    txt_6_memo.Enabled = false;

                    txt_7_비고.Enabled = false;
                    txt_7_memo.Enabled = false;
                   
                    break;
              
                case "2":

                    txt_1_채무자.Enabled = false;
                    txt_1_물건지.Enabled = false;
                    txt_1_소유자.Enabled = false;
                    txt_1_memo.Enabled = false;

                    txt_2_종류.Enabled = true;
                    txt_2_증권번호.Enabled = true;
                    txt_2_발행인1.Enabled = true;
                    txt_2_발행인2.Enabled = true;
                    txt_2_발행인3.Enabled = true;
                    txt_2_memo.Enabled = true;

                    cur_3_보험료.Enabled = false;
                    txt_3_증권번호.Enabled = false;
                    txt_3_주계약내용.Enabled = false;
                    dp_3_계약시작일.Enabled = false;
                    dp_3_계약종료일.Enabled = false;
                    dp_3_계약체결일자.Enabled = false;
                    cur_3_계약금액.Enabled = false;
                    cur_3_발생채무액.Enabled = false;
                    txt_3_memo.Enabled = false;

                    txt_4_연대보증인1.Enabled = false;
                    txt_4_연대보증인2.Enabled = false;
                    txt_4_연대보증인3.Enabled = false;
                    txt_4_memo.Enabled = false;

                    txt_5_제3채1.Enabled = false;
                    txt_5_제3채2.Enabled = false;
                    txt_5_제3채3.Enabled = false;
                    cur_5_채권양도통지서.Enabled = false;
                    chk_5_인감증명서.Enabled = false;
                    chk_5_부속합의서.Enabled = false;
                    txt_5_memo.Enabled = false;

                    txt_6_구분.Enabled = false;
                    dp_6_시작일.Enabled = false;
                    dp_6_종료일.Enabled = false;
                    cur_6_분할횟수.Enabled = false;
                    txt_6_특이사항.Enabled = false;
                    txt_6_memo.Enabled = false;

                    txt_7_비고.Enabled = false;
                    txt_7_memo.Enabled = false;

                    break;

                case "3":

                    txt_1_채무자.Enabled = false;
                    txt_1_물건지.Enabled = false;
                    txt_1_소유자.Enabled = false;
                    txt_1_memo.Enabled = false;

                    txt_2_종류.Enabled = false;
                    txt_2_증권번호.Enabled = false;
                    txt_2_발행인1.Enabled = false;
                    txt_2_발행인2.Enabled = false;
                    txt_2_발행인3.Enabled = false;
                    txt_2_memo.Enabled = false;

                    cur_3_보험료.Enabled = true;
                    txt_3_증권번호.Enabled = true;
                    txt_3_주계약내용.Enabled = true;
                    dp_3_계약시작일.Enabled = true;
                    dp_3_계약종료일.Enabled = true;
                    dp_3_계약체결일자.Enabled = true;
                    cur_3_계약금액.Enabled = true;
                    cur_3_발생채무액.Enabled = true;
                    txt_3_memo.Enabled = true;

                    txt_4_연대보증인1.Enabled = false;
                    txt_4_연대보증인2.Enabled = false;
                    txt_4_연대보증인3.Enabled = false;
                    txt_4_memo.Enabled = false;

                    txt_5_제3채1.Enabled = false;
                    txt_5_제3채2.Enabled = false;
                    txt_5_제3채3.Enabled = false;
                    cur_5_채권양도통지서.Enabled = false;
                    chk_5_인감증명서.Enabled = false;
                    chk_5_부속합의서.Enabled = false;
                    txt_5_memo.Enabled = false;

                    txt_6_구분.Enabled = false;
                    dp_6_시작일.Enabled = false;
                    dp_6_종료일.Enabled = false;
                    cur_6_분할횟수.Enabled = false;
                    txt_6_특이사항.Enabled = false;
                    txt_6_memo.Enabled = false;

                    txt_7_비고.Enabled = false;
                    txt_7_memo.Enabled = false;

                    break;

                case "4":

                    txt_1_채무자.Enabled = false;
                    txt_1_물건지.Enabled = false;
                    txt_1_소유자.Enabled = false;
                    txt_1_memo.Enabled = false;

                    txt_2_종류.Enabled = false;
                    txt_2_증권번호.Enabled = false;
                    txt_2_발행인1.Enabled = false;
                    txt_2_발행인2.Enabled = false;
                    txt_2_발행인3.Enabled = false;
                    txt_2_memo.Enabled = false;

                    cur_3_보험료.Enabled = false;
                    txt_3_증권번호.Enabled = false;
                    txt_3_주계약내용.Enabled = false;
                    dp_3_계약시작일.Enabled = false;
                    dp_3_계약종료일.Enabled = false;
                    dp_3_계약체결일자.Enabled = false;
                    cur_3_계약금액.Enabled = false;
                    cur_3_발생채무액.Enabled = false;
                    txt_3_memo.Enabled = false;

                    txt_4_연대보증인1.Enabled = true;
                    txt_4_연대보증인2.Enabled = true;
                    txt_4_연대보증인3.Enabled = true;
                    txt_4_memo.Enabled = true;

                    txt_5_제3채1.Enabled = false;
                    txt_5_제3채2.Enabled = false;
                    txt_5_제3채3.Enabled = false;
                    cur_5_채권양도통지서.Enabled = false;
                    chk_5_인감증명서.Enabled = false;
                    chk_5_부속합의서.Enabled = false;
                    txt_5_memo.Enabled = false;

                    txt_6_구분.Enabled = false;
                    dp_6_시작일.Enabled = false;
                    dp_6_종료일.Enabled = false;
                    cur_6_분할횟수.Enabled = false;
                    txt_6_특이사항.Enabled = false;
                    txt_6_memo.Enabled = false;

                    txt_7_비고.Enabled = false;
                    txt_7_memo.Enabled = false;

                    break;

                case "5":

                    txt_1_채무자.Enabled = false;
                    txt_1_물건지.Enabled = false;
                    txt_1_소유자.Enabled = false;
                    txt_1_memo.Enabled = false;

                    txt_2_종류.Enabled = false;
                    txt_2_증권번호.Enabled = false;
                    txt_2_발행인1.Enabled = false;
                    txt_2_발행인2.Enabled = false;
                    txt_2_발행인3.Enabled = false;
                    txt_2_memo.Enabled = false;

                    cur_3_보험료.Enabled = false;
                    txt_3_증권번호.Enabled = false;
                    txt_3_주계약내용.Enabled = false;
                    dp_3_계약시작일.Enabled = false;
                    dp_3_계약종료일.Enabled = false;
                    dp_3_계약체결일자.Enabled = false;
                    cur_3_계약금액.Enabled = false;
                    cur_3_발생채무액.Enabled = false;
                    txt_3_memo.Enabled = false;

                    txt_4_연대보증인1.Enabled = false;
                    txt_4_연대보증인2.Enabled = false;
                    txt_4_연대보증인3.Enabled = false;
                    txt_4_memo.Enabled = false;

                    txt_5_제3채1.Enabled = true;
                    txt_5_제3채2.Enabled = true;
                    txt_5_제3채3.Enabled = true;
                    cur_5_채권양도통지서.Enabled = true;
                    chk_5_인감증명서.Enabled = true;
                    chk_5_부속합의서.Enabled = true;
                    txt_5_memo.Enabled = true;

                    txt_6_구분.Enabled = false;
                    dp_6_시작일.Enabled = false;
                    dp_6_종료일.Enabled = false;
                    cur_6_분할횟수.Enabled = false;
                    txt_6_특이사항.Enabled = false;
                    txt_6_memo.Enabled = false;

                    txt_7_비고.Enabled = false;
                    txt_7_memo.Enabled = false;

                    break;

                case "6":

                    txt_1_채무자.Enabled = false;
                    txt_1_물건지.Enabled = false;
                    txt_1_소유자.Enabled = false;
                    txt_1_memo.Enabled = false;

                    txt_2_종류.Enabled = false;
                    txt_2_증권번호.Enabled = false;
                    txt_2_발행인1.Enabled = false;
                    txt_2_발행인2.Enabled = false;
                    txt_2_발행인3.Enabled = false;
                    txt_2_memo.Enabled = false;

                    cur_3_보험료.Enabled = false;
                    txt_3_증권번호.Enabled = false;
                    txt_3_주계약내용.Enabled = false;
                    dp_3_계약시작일.Enabled = false;
                    dp_3_계약종료일.Enabled = false;
                    dp_3_계약체결일자.Enabled = false;
                    cur_3_계약금액.Enabled = false;
                    cur_3_발생채무액.Enabled = false;
                    txt_3_memo.Enabled = false;

                    txt_4_연대보증인1.Enabled = false;
                    txt_4_연대보증인2.Enabled = false;
                    txt_4_연대보증인3.Enabled = false;
                    txt_4_memo.Enabled = false;

                    txt_5_제3채1.Enabled = false;
                    txt_5_제3채2.Enabled = false;
                    txt_5_제3채3.Enabled = false;
                    cur_5_채권양도통지서.Enabled = false;
                    chk_5_인감증명서.Enabled = false;
                    chk_5_부속합의서.Enabled = false;
                    txt_5_memo.Enabled = false;

                    txt_6_구분.Enabled = true;
                    dp_6_시작일.Enabled = true;
                    dp_6_종료일.Enabled = true;
                    cur_6_분할횟수.Enabled = true;
                    txt_6_특이사항.Enabled = true;
                    txt_6_memo.Enabled = true;

                    txt_7_비고.Enabled = false;
                    txt_7_memo.Enabled = false;

                    break;

                case "7":

                    txt_1_채무자.Enabled = false;
                    txt_1_물건지.Enabled = false;
                    txt_1_소유자.Enabled = false;
                    txt_1_memo.Enabled = false;

                    txt_2_종류.Enabled = false;
                    txt_2_증권번호.Enabled = false;
                    txt_2_발행인1.Enabled = false;
                    txt_2_발행인2.Enabled = false;
                    txt_2_발행인3.Enabled = false;
                    txt_2_memo.Enabled = false;

                    cur_3_보험료.Enabled = false;
                    txt_3_증권번호.Enabled = false;
                    txt_3_주계약내용.Enabled = false;
                    dp_3_계약시작일.Enabled = false;
                    dp_3_계약종료일.Enabled = false;
                    dp_3_계약체결일자.Enabled = false;
                    cur_3_계약금액.Enabled = false;
                    cur_3_발생채무액.Enabled = false;
                    txt_3_memo.Enabled = false;

                    txt_4_연대보증인1.Enabled = false;
                    txt_4_연대보증인2.Enabled = false;
                    txt_4_연대보증인3.Enabled = false;
                    txt_4_memo.Enabled = false;

                    txt_5_제3채1.Enabled = false;
                    txt_5_제3채2.Enabled = false;
                    txt_5_제3채3.Enabled = false;
                    cur_5_채권양도통지서.Enabled = false;
                    chk_5_인감증명서.Enabled = false;
                    chk_5_부속합의서.Enabled = false;
                    txt_5_memo.Enabled = false;

                    txt_6_구분.Enabled = false;
                    dp_6_시작일.Enabled = false;
                    dp_6_종료일.Enabled = false;
                    cur_6_분할횟수.Enabled = false;
                    txt_6_특이사항.Enabled = false;
                    txt_6_memo.Enabled = false;

                    txt_7_비고.Enabled = true;
                    txt_7_memo.Enabled = true;

                    break;

                default:

                    txt_1_채무자.Enabled = false;
                    txt_1_물건지.Enabled = false;
                    txt_1_소유자.Enabled = false;
                    txt_1_memo.Enabled = false;

                    txt_2_종류.Enabled = false;
                    txt_2_증권번호.Enabled = false;
                    txt_2_발행인1.Enabled = false;
                    txt_2_발행인2.Enabled = false;
                    txt_2_발행인3.Enabled = false;
                    txt_2_memo.Enabled = false;

                    cur_3_보험료.Enabled = false;
                    txt_3_증권번호.Enabled = false;
                    txt_3_주계약내용.Enabled = false;
                    dp_3_계약시작일.Enabled = false;
                    dp_3_계약종료일.Enabled = false;
                    dp_3_계약체결일자.Enabled = false;
                    cur_3_계약금액.Enabled = false;
                    cur_3_발생채무액.Enabled = false;
                    txt_3_memo.Enabled = false;

                    txt_4_연대보증인1.Enabled = false;
                    txt_4_연대보증인2.Enabled = false;
                    txt_4_연대보증인3.Enabled = false;
                    txt_4_memo.Enabled = false;

                    txt_5_제3채1.Enabled = false;
                    txt_5_제3채2.Enabled = false;
                    txt_5_제3채3.Enabled = false;
                    cur_5_채권양도통지서.Enabled = false;
                    chk_5_인감증명서.Enabled = false;
                    chk_5_부속합의서.Enabled = false;
                    txt_5_memo.Enabled = false;

                    txt_6_구분.Enabled = false;
                    dp_6_시작일.Enabled = false;
                    dp_6_종료일.Enabled = false;
                    cur_6_분할횟수.Enabled = false;
                    txt_6_특이사항.Enabled = false;
                    txt_6_memo.Enabled = false;

                    txt_7_비고.Enabled = false;
                    txt_7_memo.Enabled = false;

                    break;
            }
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
                    string 번호 = "";
                    string 기존번호 = "";
                    string 설정액 = "0";
                    string 체결일 = "";
                    string 시작일 = "";
                    string 만기일 = "";
                    string 소멸시효 = "";

                    string 채무자 = "";
                    string 소유자 = "";
                    string 물건지 = "";
                    string memo1 = "";

                    string 종류2 = "";
                    string 증권번호 = "";
                    string 발행인1 = "";
                    string 발행인2 = "";
                    string 발행인3 = "";
                    string memo2 = "";

                    string 증권번호2 = "";
                    string 보험료 = "0";
                    string 주계약내용 = "";
                    string 계약시작일 = "";
                    string 계약종료일 = "";
                    string 계약체결일자 = "";
                    string 계약금액 = "0";
                    string 발생채무액 = "0";
                    string memo3 = "";

                    string 연대보증인1 = "";
                    string 연대보증인2 = "";
                    string 연대보증인3 = "";
                    string memo4 = "";

                    string 제3채1 = "";
                    string 제3채2 = "";
                    string 제3채3 = "";
                    string 채권양도통지서 = "0";
                    string 인감증명서 = "";
                    string 부속합의서 = "";
                    string memo5 = "";

                    string 구분 = "";
                    string 시작일2 = "";
                    string 종료일 = "";
                    string 분할횟수 = "";
                    string 특이사항 = "";
                    string memo6 = "";

                    string 비고 = "";
                    string memo7 = "";


                    거래처 = ctx거래처.CodeValue;
                    종류 = cbo보전서류구분.SelectedValue.ToString();
                    번호 = txt번호.Text;

                    if (txt번호.Text.Equals(""))
                    {
                        기존번호 = "";
                    }
                    else
                    {
                        기존번호 = txt기존번호.Text;
                    }

                    if (cur설정액.Text.Equals(""))
                    {
                        설정액 = "0";
                    }
                    else
                    {
                        설정액 = cur설정액.Text;
                    }


                    체결일 = dp체결일.Text.Replace("-", "");
                    시작일 = dp시작일.Text.Replace("-", "");
                    만기일 = dp만기일.Text.Replace("-", "");
                    소멸시효 = dp소멸시효.Text.Replace("-", "");
                   
                    switch (cbo보전서류구분.SelectedIndex.ToString())
                    {
                        case "1":

                            채무자 = txt_1_채무자.Text;
                            소유자 = txt_1_소유자.Text;
                            물건지 = txt_1_물건지.Text;
                            memo1 = txt_1_memo.Text;
                            
                            종류2 = "";
                            증권번호 = "";
                            발행인1 = "";
                            발행인2 = "";
                            발행인3 = "";
                            memo2 = "";

                            증권번호2 = "";
                            보험료 = "";
                            주계약내용 = "";
                            계약시작일 = "";
                            계약종료일 = "";
                            계약체결일자 = "";
                            계약금액 = "";
                            발생채무액 = "";
                            memo3 = "";

                            연대보증인1 = "";
                            연대보증인2 = "";
                            연대보증인3 = "";
                            memo4 = "";

                            제3채1 = "";
                            제3채2 = "";
                            제3채3 = "";
                            채권양도통지서 = "";
                            인감증명서 = "";
                            부속합의서 = "";
                            memo5 = "";

                            구분 = "";
                            시작일2 = "";
                            종료일 = "";
                            분할횟수 = "";
                            특이사항 = "";
                            memo6 = "";

                            비고 = "";
                            memo7 = "";
                           
                            break;

                        case "2":

                            채무자 = "";
                            소유자 = "";
                            물건지 = "";
                            memo1 = "";
                            
                            종류2 = txt_2_종류.Text;
                            증권번호 = txt_2_증권번호.Text;
                            발행인1 = txt_2_발행인1.Text;
                            발행인2 = txt_2_발행인2.Text;
                            발행인3 = txt_2_발행인3.Text;
                            memo2 = txt_2_memo.Text;

                            증권번호2 = "";
                            보험료 = "";
                            주계약내용 = "";
                            계약시작일 = "";
                            계약종료일 = "";
                            계약체결일자 = "";
                            계약금액 = "";
                            발생채무액 = "";
                            memo3 = "";

                            연대보증인1 = "";
                            연대보증인2 = "";
                            연대보증인3 = "";
                            memo4 = "";

                            제3채1 = "";
                            제3채2 = "";
                            제3채3 = "";
                            채권양도통지서 = "";
                            인감증명서 = "";
                            부속합의서 = "";
                            memo5 = "";

                            구분 = "";
                            시작일2 = "";
                            종료일 = "";
                            분할횟수 = "";
                            특이사항 = "";
                            memo6 = "";

                            비고 = "";
                            memo7 = "";
                           
                            break;

                        case "3":

                            채무자 = "";
                            소유자 = "";
                            물건지 = "";
                            memo1 = "";

                            종류2 = "";
                            증권번호 = "";
                            발행인1 = "";
                            발행인2 = "";
                            발행인3 = "";
                            memo2 = "";

                            증권번호2 = txt_3_증권번호.Text;
                            보험료 = cur_3_보험료.Text;
                            주계약내용 = txt_3_주계약내용.Text;
                            계약시작일 = dp_3_계약시작일.Text.Replace("-", "");
                            계약종료일 = dp_3_계약종료일.Text.Replace("-", "");
                            계약체결일자 = dp_3_계약체결일자.Text.Replace("-", "");
                            계약금액 = cur_3_계약금액.Text;
                            발생채무액 = cur_3_발생채무액.Text;
                            memo3 = txt_3_memo.Text;

                            연대보증인1 = "";
                            연대보증인2 = "";
                            연대보증인3 = "";
                            memo4 = "";

                            제3채1 = "";
                            제3채2 = "";
                            제3채3 = "";
                            채권양도통지서 = "";
                            인감증명서 = "";
                            부속합의서 = "";
                            memo5 = "";

                            구분 = "";
                            시작일2 = "";
                            종료일 = "";
                            분할횟수 = "";
                            특이사항 = "";
                            memo6 = "";

                            비고 = "";
                            memo7 = "";
                           
                            break;

                        case "4":

                            채무자 = "";
                            소유자 = "";
                            물건지 = "";
                            memo1 = "";

                            종류2 = "";
                            증권번호 = "";
                            발행인1 = "";
                            발행인2 = "";
                            발행인3 = "";
                            memo2 = "";

                            증권번호2 = "";
                            보험료 = "";
                            주계약내용 = "";
                            계약시작일 = "";
                            계약종료일 = "";
                            계약체결일자 = "";
                            계약금액 = "";
                            발생채무액 = "";
                            memo3 = "";

                            연대보증인1 = txt_4_연대보증인1.Text;
                            연대보증인2 = txt_4_연대보증인2.Text;
                            연대보증인3 = txt_4_연대보증인3.Text;
                            memo4 = txt_4_memo.Text;

                            제3채1 = "";
                            제3채2 = "";
                            제3채3 = "";
                            채권양도통지서 = "";
                            인감증명서 = "";
                            부속합의서 = "";
                            memo5 = "";

                            구분 = "";
                            시작일2 = "";
                            종료일 = "";
                            분할횟수 = "";
                            특이사항 = "";
                            memo6 = "";

                            비고 = "";
                            memo7 = "";
                           
                            break;

                        case "5":

                            채무자 = "";
                            소유자 = "";
                            물건지 = "";
                            memo1 = "";

                            종류2 = "";
                            증권번호 = "";
                            발행인1 = "";
                            발행인2 = "";
                            발행인3 = "";
                            memo2 = "";

                            증권번호2 = "";
                            보험료 = "";
                            주계약내용 = "";
                            계약시작일 = "";
                            계약종료일 = "";
                            계약체결일자 = "";
                            계약금액 = "";
                            발생채무액 = "";
                            memo3 = "";

                            연대보증인1 = "";
                            연대보증인2 = "";
                            연대보증인3 = "";
                            memo4 = "";

                            제3채1 = txt_5_제3채1.Text;
                            제3채2 = txt_5_제3채2.Text;
                            제3채3 = txt_5_제3채3.Text;
                            채권양도통지서 = cur_5_채권양도통지서.Text;

                            if (chk_5_인감증명서.Checked == true)
                            {
                                인감증명서 = "Y";
                            }
                            else
                            {
                                인감증명서 = "N";
                            }

                            if (chk_5_부속합의서.Checked == true)
                            {
                                부속합의서 = "Y";
                            }
                            else
                            {
                                부속합의서 = "N";
                            }

                            memo5 = txt_5_memo.Text;

                            구분 = "";
                            시작일2 = "";
                            종료일 = "";
                            분할횟수 = "";
                            특이사항 = "";
                            memo6 = "";

                            비고 = "";
                            memo7 = "";
                           
                            break;

                        case "6":

                            채무자 = "";
                            소유자 = "";
                            물건지 = "";
                            memo1 = "";

                            종류2 = "";
                            증권번호 = "";
                            발행인1 = "";
                            발행인2 = "";
                            발행인3 = "";
                            memo2 = "";

                            증권번호2 = "";
                            보험료 = "";
                            주계약내용 = "";
                            계약시작일 = "";
                            계약종료일 = "";
                            계약체결일자 = "";
                            계약금액 = "";
                            발생채무액 = "";
                            memo3 = "";

                            연대보증인1 = "";
                            연대보증인2 = "";
                            연대보증인3 = "";
                            memo4 = "";

                            제3채1 = "";
                            제3채2 = "";
                            제3채3 = "";
                            채권양도통지서 = "";
                            인감증명서 = "";
                            부속합의서 = "";
                            memo5 = "";

                            구분 = txt_6_구분.Text;
                            시작일2 = dp_6_시작일.Text.Replace("-", "");
                            종료일 = dp_6_종료일.Text.Replace("-", "");
                            분할횟수 = cur_6_분할횟수.Text;
                            특이사항 = txt_6_특이사항.Text;
                            memo6 = txt_6_memo.Text;

                            비고 = "";
                            memo7 = "";
                           
                            break;

                        case "7":

                            채무자 = "";
                            소유자 = "";
                            물건지 = "";
                            memo1 = "";

                            종류2 = "";
                            증권번호 = "";
                            발행인1 = "";
                            발행인2 = "";
                            발행인3 = "";
                            memo2 = "";

                            증권번호2 = "";
                            보험료 = "";
                            주계약내용 = "";
                            계약시작일 = "";
                            계약종료일 = "";
                            계약체결일자 = "";
                            계약금액 = "";
                            발생채무액 = "";
                            memo3 = "";

                            연대보증인1 = "";
                            연대보증인2 = "";
                            연대보증인3 = "";
                            memo4 = "";

                            제3채1 = "";
                            제3채2 = "";
                            제3채3 = "";
                            채권양도통지서 = "";
                            인감증명서 = "";
                            부속합의서 = "";
                            memo5 = "";

                            구분 = "";
                            시작일2 = "";
                            종료일 = "";
                            분할횟수 = "";
                            특이사항 = "";
                            memo6 = "";

                            비고 = txt_7_비고.Text;
                            memo7 = txt_7_memo.Text;
                           
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

                    if (_biz.Insert_Info( 거래처, 종류, 번호, 기존번호, 설정액, 체결일, 시작일
                                        , 만기일, 소멸시효, 채무자, 소유자, 물건지
                                        , memo1, 종류2, 증권번호, 발행인1, 발행인2
                                        , 발행인3, memo2, 증권번호2, 보험료, 주계약내용
                                        , 계약시작일, 계약종료일, 계약체결일자, 계약금액, 발생채무액
                                        , memo3, 연대보증인1, 연대보증인2, 연대보증인3, memo4
                                        , 제3채1, 제3채2, 제3채3, 채권양도통지서, 인감증명서
                                        , 부속합의서, memo5, 구분, 시작일2, 종료일
                                        , 분할횟수, 특이사항, memo6, 비고, memo7))
                    {
                        ShowMessage("입력이 완료 되었습니다.");

                        if (txt번호.Text.Equals(""))
                        {
                            DataTable dt = _biz.GetMAX_NO_GUBUN(거래처, 종류);

                            txt번호.Text = dt.Rows[0]["NO_GUBUN"].ToString();
                            txt기존번호.Text = dt.Rows[0]["NO_GUBUN"].ToString();
                        }

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

        #region ♥ 그리드 이벤트

        #endregion

        #region ♥ 기타 Property
        string ServerKey { get { return Global.MainFrame.ServerKeyCommon.ToUpper(); } }


        #endregion            

    }
}