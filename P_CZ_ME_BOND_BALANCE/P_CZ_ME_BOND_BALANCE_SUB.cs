using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;
using Dass.FlexGrid;
using Duzon.ERPU;
using Duzon.Common.Forms;
using Duzon.Common.Controls;
using Duzon.Common.Forms.Help;
using Duzon.Common.Util;
using DzHelpFormLib;
using Duzon.Common.BpControls;
using System.Collections.Generic;

using Duzon.ERPU.MF;
using Duzon.ERPU.MF.Common;
using Duzon.Windows.Print;


namespace cz
{
    public partial class P_CZ_ME_BOND_BALANCE_SUB : Duzon.Common.Forms.CommonDialog
    {
        #region ♣ 멤버필드

        public string strNoIv = string.Empty;
        public delegate void Form2_EventHandler(string strSearchFrom, string strSearchTo, string strCampaign, string strAgent, string strAccount, string strAgency, string strAgencyMonthFrom, string strAgencyMonthTo, string strdoAgency, string strDept, string strCorp, string strCorpMonthFrom, string strCorpMonthTo, string strdoCorp, string strCorpGubun, string strAgent_Amt_From, string strAgent_Amt_To, string strAgency_Amt_From, string strAgency_Amt_To, string strMezzo_Amt_From, string strMezzo_Amt_To, string strCorp_Amt_From, string strCorp_Amt_To, string strAgencyDoc, string strMediaDoc, string strAgencyTax, string strMediaTax, string strClosed, string strStatus); // string 을 반환값으로 같은 대리자를 선언
        public event Form2_EventHandler TextSendEvent;  // 대리자 타입의 이벤트 처리기를 설정

        //public P_CZ_ME_SALES _biz = new P_CZ_ME_SALES();

        #endregion

        #region ♣ 생성자

        public P_CZ_ME_BOND_BALANCE_SUB()
        {
            InitializeComponent();

        }
        #endregion

        #region ♣ 초기화

        #region -> InitLoad

        protected override void InitLoad()
        {
            base.InitLoad();

            btn상세검색.Text = "상세\r\n\r\n검색";

            string longtoday = "";
            string today = "";

            longtoday = DateTime.Now.ToString("yyyMMddHHmmss");
            today = longtoday.Substring(0, 6);

            dp년월_FROM.Text = longtoday.Substring(0, 4) + "01";
            dp년월_TO.Text = longtoday.Substring(0, 6);

            dpAgencyFROM.Text = "";
            dpAgencyTO.Text = "";
            dp매체월FROM.Text = "";
            dp매체월TO.Text = "";
        }

        #endregion

        #region -> InitPaint

        protected override void InitPaint()
        {
            base.InitPaint();

           
            btn상세검색.Click += new EventHandler(btn검색_Click);

        }

      
        void bpc담당자_QueryAfter(object sender, BpQueryArgs e)
        {
            
        }

    
        #endregion

        #endregion

        #region ♣ 화면버튼 이벤트

        #region -> Check

      
        #endregion

        private void btn검색_Click(object sender, EventArgs e)
        {
            try
            {
             //   doSearch();

            }
            catch (Exception ex)
            {
                Global.MainFrame.MsgEnd(ex);
            }
        }


        #endregion

        #region ♣ 컨트롤
        
      #endregion


        private void chkAgent_Amt_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAgent_Amt.Checked == true)
            {
                txtAgent_Amt_From.Text = "0";
                txtAgent_Amt_To.Text = "0";
            }
            else
            {
                txtAgent_Amt_From.Text = "";
                txtAgent_Amt_To.Text = "";
            }
        }

        private void txtAgent_Amt_From_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자만 입력되도록 필터링
            if(!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }

        private void txtAgent_Amt_To_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자만 입력되도록 필터링
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }

        private void txtAgency_Amt_From_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자만 입력되도록 필터링
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }

        private void txtAgency_Amt_To_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자만 입력되도록 필터링
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }

        private void txtMezzo_Amt_From_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자만 입력되도록 필터링
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }

        private void txtMezzo_Amt_To_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자만 입력되도록 필터링
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }

        private void txtCorp_Amt_From_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자만 입력되도록 필터링
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }

        private void txtCorp_Amt_To_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자만 입력되도록 필터링
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }

        private void chkAgency_Amt_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAgency_Amt.Checked == true)
            {
                txtAgency_Amt_From.Text = "0";
                txtAgency_Amt_To.Text = "0";
            }
            else
            {
                txtAgency_Amt_From.Text = "";
                txtAgency_Amt_To.Text = "";
            }
        }

        private void chkMezzo_Amt_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMezzo_Amt.Checked == true)
            {
                txtMezzo_Amt_From.Text = "0";
                txtMezzo_Amt_To.Text = "0";
            }
            else
            {
                txtMezzo_Amt_From.Text = "";
                txtMezzo_Amt_To.Text = "";
            }
        }

        private void chkCorp_Amt_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCorp_Amt.Checked == true)
            {
                txtCorp_Amt_From.Text = "0";
                txtCorp_Amt_To.Text = "0";
            }
            else
            {
                txtCorp_Amt_From.Text = "";
                txtCorp_Amt_To.Text = "";
            }
        }

        private void btn상세검색_Click_1(object sender, EventArgs e)
        {

            string strSearchFrom = dp년월_FROM.Text; 
            string strSearchTo = dp년월_TO.Text;//조회연월 FROM TO
            string strCampaign = txt캠페인명.Text; //캠페인명
            string strAgent = MULTI_CD_AGENT.QueryWhereIn_Pipe; //광고주
            string strAccount = MULTI_CD_ACCOUNT.QueryWhereIn_Pipe; //계정과목

            string strAgency = MULTI_CD_AGENCY.QueryWhereIn_Pipe;
            string strAgencyMonthFrom = dpAgencyFROM.Text;
            string strAgencyMonthTo = dpAgencyTO.Text;
            string strdoAgency = "";

            //대행사기준  1:세금계산서(전액),2:세금계산서(순액),3:INVOICE,4:전체
            if (rdoAgency1.Checked == true){strdoAgency = "4";}
            else if (rdoAgency2.Checked == true){strdoAgency = "1";}
            else if (rdoAgency3.Checked == true){strdoAgency = "2";}
            else if (rdoAgency4.Checked == true){strdoAgency = "3";}

            string strDept = MULTI_CD_DEPT.QueryWhereIn_Pipe;
            string strCorp = MULTI_CD_CORP.QueryWhereIn_Pipe;
            string strCorpMonthFrom = dp매체월FROM.Text;string strCorpMonthTo = dp매체월TO.Text;

            //매체기준 1:세금계산서(전액),2:세금계산서(순액),3:INVOICE, 4:전체
            string strdoCorp = "";
            if (rdoCorp1.Checked == true){strdoCorp = "4";}
            else if (rdoCorp2.Checked == true){strdoCorp = "1";}
            else if (rdoCorp3.Checked == true){strdoCorp = "2";}
            else if (rdoCorp4.Checked == true){strdoCorp = "3";}

            //string strCorpGubun = bp매체구분.CodeValue;
            string strCorpGubun = MULTI_CD_MEDIAGR.QueryWhereIn_Pipe;  //매체구분

            //광고수주액
            string strAgent_Amt_From = "";string strAgent_Amt_To = "";

            if (txtAgent_Amt_From.Text == "") strAgent_Amt_From = "";
            else strAgent_Amt_From = txtAgent_Amt_To.Text;

            if (txtAgent_Amt_To.Text == "") strAgent_Amt_To = "";
            else strAgent_Amt_To = txtAgent_Amt_To.Text;

            //대행사수수료
            string strAgency_Amt_From = "";string strAgency_Amt_To = "";

            if (txtAgency_Amt_From.Text == "") strAgency_Amt_From = "";
            else strAgency_Amt_From = txtAgency_Amt_From.Text;

            if (txtAgency_Amt_To.Text == "") strAgency_Amt_To = "";
            else strAgency_Amt_To = txtAgency_Amt_To.Text;

            //영업수익
            string strMezzo_Amt_From = "";string strMezzo_Amt_To = "";

            if (txtMezzo_Amt_From.Text == "") strMezzo_Amt_From = "";
            else strMezzo_Amt_From = txtMezzo_Amt_From.Text;

            if (txtMezzo_Amt_To.Text == "") strMezzo_Amt_To = "";
            else strMezzo_Amt_To = txtMezzo_Amt_To.Text;

            //매체수익
            string strCorp_Amt_From = "";string strCorp_Amt_To = "";

            if (txtCorp_Amt_From.Text == "") strCorp_Amt_From = "";
            else strCorp_Amt_From = txtCorp_Amt_From.Text;

            if (txtCorp_Amt_To.Text == "") strCorp_Amt_To = "";
            else strCorp_Amt_To = txtCorp_Amt_To.Text;

            //대행사전표처리 1:처리,2:미처리,3:전체
            string strAgencyDoc = "";
            if (rdoAgencyDoc1.Checked == true) { strAgencyDoc = "3"; }
            else if (rdoAgencyDoc2.Checked == true) { strAgencyDoc = "1"; }
            else if (rdoAgencyDoc3.Checked == true) { strAgencyDoc = "2"; }

            //매체전표처리 1:처리,2:미처리,3:전체
            string strMediaDoc = "";
            if (rdoMediaDoc1.Checked == true) { strMediaDoc = "3"; }
            else if (rdoMediaDoc2.Checked == true) { strMediaDoc = "1"; }
            else if (rdoMediaDoc3.Checked == true) { strMediaDoc = "2"; }

            //대행사세금계산서 1:발행,2:미발행,3:전체
            string strAgencyTax = "";
            if (rdoAgencyTax1.Checked == true) { strAgencyTax = "3"; }
            else if (rdoAgencyTax2.Checked == true) { strAgencyTax = "1"; }
            else if (rdoAgencyTax3.Checked == true) { strAgencyTax = "2"; }

            //매체세금계산서 1:발행,2:미발행,3:전체
            string strMediaTax = "";
            if (rdoMediaTax1.Checked == true) { strMediaTax = "3"; }
            else if (rdoMediaTax2.Checked == true) { strMediaTax = "1"; }
            else if (rdoMediaTax3.Checked == true) { strMediaTax = "2"; }

            //마감구분 1:마감,0:미마감,2:전체
            string strClosed = "";
            if (rdoClosed1.Checked == true) { strClosed = "2"; }
            else if (rdoClosed2.Checked == true) { strClosed = "1"; }
            else if (rdoClosed3.Checked == true) { strClosed = "0"; }

            //수정구분 0:검수,1:승인,2:수정,3:전체
            string strStatus = "";
            if (rdoStatus1.Checked == true) { strStatus = "4"; }
            else if (rdoStatus2.Checked == true) { strStatus = "0"; }
            else if (rdoStatus3.Checked == true) { strStatus = "1"; }
            else if (rdoStatus4.Checked == true) { strStatus = "2"; }
            else if (rdoStatus5.Checked == true) { strStatus = "3"; }

            TextSendEvent(strSearchFrom, strSearchTo, strCampaign, strAgent, strAccount, strAgency, strAgencyMonthFrom, strAgencyMonthTo, strdoAgency, strDept, strCorp, strCorpMonthFrom, strCorpMonthTo, strdoCorp, strCorpGubun, strAgent_Amt_From, strAgent_Amt_To, strAgency_Amt_From, strAgency_Amt_To, strMezzo_Amt_From, strMezzo_Amt_To, strCorp_Amt_From, strCorp_Amt_To, strAgencyDoc, strMediaDoc, strAgencyTax, strMediaTax, strClosed, strStatus); // 스트링값을 메인폼에게 보내줌
        }

        private void MULTI_CD_AGENCY_QueryBefore(object sender, BpQueryArgs e)
        {
            MULTI_CD_AGENCY.UserParams = "대행사 도움창;H_CZ_ME_AGENCY;" + MULTI_CD_AGENCY.CodeNames + ";";
        }

        private void MULTI_CD_DEPT_QueryBefore(object sender, BpQueryArgs e)
        {
            MULTI_CD_DEPT.UserParams = "부서 도움창;H_CZ_ME_DEPT;" + MULTI_CD_DEPT.CodeNames + ";";
        }

        private void MULTI_CD_CORP_QueryBefore(object sender, BpQueryArgs e)
        {
            MULTI_CD_CORP.UserParams = "매체 도움창;H_CZ_ME_GR;" + MULTI_CD_CORP.CodeNames + ";";
        }

        private void MULTI_CD_MEDIAGR_QueryBefore(object sender, BpQueryArgs e)
        {
            MULTI_CD_MEDIAGR.UserParams = "매체구분 도움창;H_CZ_ME_MEDIAGR;" + MULTI_CD_MEDIAGR.CodeNames + ";";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MULTI_CD_AGENT_QueryBefore(object sender, BpQueryArgs e)
        {
            MULTI_CD_AGENT.UserParams = "광고주 도움창;H_CZ_ME_AGENT;" + MULTI_CD_AGENT.CodeNames + ";";
        }

        private void MULTI_CD_ACCOUNT_QueryBefore(object sender, BpQueryArgs e)
        {
            MULTI_CD_ACCOUNT.UserParams = "매출분석 계정과목 도움창;H_CZ_ME_ACCOUNT_USERDE1;" + MULTI_CD_ACCOUNT.CodeNames + ";";
        }

        #region ♣ 기타 메소드

 
        #endregion
    }
}
