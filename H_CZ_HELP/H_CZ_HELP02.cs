using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Duzon.Common.Forms.Help;
using System.Collections;
using Duzon.ERPU;
using Duzon.Common.Forms;

namespace cz
{
    public partial class H_CZ_HELP02 : HelpBase, IHelp
    {
        public H_CZ_HELP02()
        {
            InitializeComponent();
        }

        public H_CZ_HELP02(HelpParam helpParam) : base(helpParam)
        {
            InitializeComponent();
            base.SetIHelp = this as IHelp;
            InitGrid();

            SetDefault(base.Get타이틀명, flex, btn확인, btn검색, btn취소, txt검색);
            helpParam.QueryAction = QueryAction.RealTime;
            helpParam.IsCheck = true;
            helpParam.MultiHelp = true;
            txt검색.Text = helpParam.P92_DETAIL_SEARCH_CODE;
        }

         private void InitGrid()
         {
             ArrayList list = new ArrayList();

             //AfterCodeHelp-->그리드일때, 그리드아닐때는 QueryAfter
             
             switch (base.GetHelpID)
             {
                 case "H_CZ_ME_GR":     //매체 도움창 메조미디어
                     list.Add(new object[] { "cd_partner", "ID", 70 });
                     list.Add(new object[] { "biz_name", "사업자명", 180 });
                     list.Add(new object[] { "biz_no", "사업자등록번호", 90 });
                     break;
                 case "H_CZ_ME_ACCOUNT_USERDE1":    //매출분석 계정과목 도움창 메조미디어       
                     //list.Add(new object[] { "S", "S", 30 });
                     list.Add(new object[] { "NM_USERDE1", "계정과목ID", 100 });
                     list.Add(new object[] { "NM_ACCT", "계정과목명", 180 });
                     break;
                 case "H_CZ_ME_AGENT":                 //광고주 도움창 메조미디어
                     list.Add(new object[] { "corpid", "광고주ID", 100 });
                     list.Add(new object[] { "corpname", "광고주명", 200 });
                     break;
                 case "H_CZ_ME_AGENCY":                 //대행사 도움창 메조미디어
                     list.Add(new object[] { "cd_partner", "ID", 70 });
                     list.Add(new object[] { "biz_name", "사업자명", 180 });
                     list.Add(new object[] { "biz_no", "사업자등록번호", 90 });
                     break;
                 case "H_CZ_ME_DEPT":                 //부서 도움창 메조미디어
                     list.Add(new object[] { "CD_DEPT", "부서코드", 100 });
                     list.Add(new object[] { "NM_DEPT", "부서명", 200 });
                     break;
                 case "H_CZ_ME_MEDIAGR":                 //매체구분 도움창 메조미디어
                     list.Add(new object[] { "CD_MEDIAGR", "매체구분ID", 70 });
                     list.Add(new object[] { "NM_MEDIAGR", "매체구분명", 180 });
                     break;
                 case "H_CZ_ME_COR":                 //매체구분 도움창 메조미디어
                     list.Add(new object[] { "CD_MEDIA", "매체구분ID", 70 });
                     list.Add(new object[] { "NM_MEDIA", "매체구분명", 180 });
                     break;
                 case "H_CZ_ME_ACCT":                 //계정코드 도움창 메조미디어
                     list.Add(new object[] { "CD_ACCT", "계정코드", 70 });
                     list.Add(new object[] { "NM_ACCT", "계정명", 180 });
                     break;

                 //default:
                 //    list.Add(new object[] { "CODE", "코드", 100 });
                 //    list.Add(new object[] { "NAME", "코드명", 100 });
                 //    break;
             }

             base.InitGrid(flex, list);  //그리드는 PageBase의 그리드와 다르다    
             flex.SettingVersion = "1.4.0";
         }


         private void txt검색_KeyDown(object sender, KeyEventArgs e)
         {
             switch (e.KeyCode)
             {
                 case Keys.Enter:
                     SetAfterSearch(RefreshSearch());
                     flex.Focus();
                     break;
                 case Keys.Escape:
                     Close();
                     break;
             }
         }

         #region IHelp 멤버

         public DataTable SetDetail(string 검색)
         {
             DataTable dt = null;
             List<object> parma = new List<object>();
             string 회사코드 = Global.MainFrame.LoginInfo.CompanyCode;

             switch (base.GetHelpID)
             {
                 //메조미디어 매체
                 case "H_CZ_ME_GR":
                     dt = DBHelper.GetDataTable("UP_CZ_MEZZO_H_GR_S", new object[] { 회사코드, 검색, GetListParam[0] });
                     break;
                 //메조미디어 매출분석 계정과목
                 case "H_CZ_ME_ACCOUNT_USERDE1":
                     dt = DBHelper.GetDataTable("UP_CZ_ME_ACCOUNT_USERDE1_P_S", new object[] { 회사코드, 검색, GetListParam[0] });
                     break;
                 //메조미디어 광고주
                 case "H_CZ_ME_AGENT":
                     dt = DBHelper.GetDataTable("UP_CZ_ME_AGENT_P_S", new object[] { 회사코드, 검색, GetListParam[0] });
                     break;
                 //메조미디어 대행사
                 case "H_CZ_ME_AGENCY":
                     dt = DBHelper.GetDataTable("UP_CZ_MEZZO_H_GR_S", new object[] { 회사코드, 검색, GetListParam[0] });
                     break;
                 //메조미디어 부서
                 case "H_CZ_ME_DEPT":
                     dt = DBHelper.GetDataTable("UP_CZ_ME_DEPT_P_S", new object[] { 회사코드, 검색, GetListParam[0] });
                     break;
                 //메조미디어 매체구분
                 case "H_CZ_ME_MEDIAGR":
                     dt = DBHelper.GetDataTable("UP_CZ_ME_MEDIAGR_P_S", new object[] { 회사코드, 검색, GetListParam[0] });
                     break;
                 //메조미디어 매체
                 case "H_CZ_ME_COR":
                     dt = DBHelper.GetDataTable("UP_CZ_MEZZO_H_COR_S", new object[] { 회사코드, 검색, GetListParam[0] });
                     break;
                 //메조미디어 계정
                 case "H_CZ_ME_ACCT":
                     dt = DBHelper.GetDataTable("UP_CZ_MEZZO_H_ACCT_S", new object[] { 회사코드, 검색, GetListParam[0] });
                     break;

                 //case "":
                 //    break;
             }
             return dt;
         }

         public string Get검색
         {
             get { return txt검색.Text; }
         }

         #endregion
    }
}
