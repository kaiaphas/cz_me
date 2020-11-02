using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using Duzon.ERPU;
using Duzon.Common.Forms;
using Duzon.Common.Forms.Help;
using Duzon.Common.Forms.Help.Forms;

namespace cz
{
    [UserHelpDescription("기본도움창", "기본도움창을 가져옵니다.", "CODE", "NAME")]

    public partial class H_CZ_HELP01 : HelpBase, IHelp
    {
        public H_CZ_HELP01()
        {
            InitializeComponent();
        }

        public H_CZ_HELP01(HelpParam helpParam)
            : base(helpParam)
        {
            InitializeComponent();

            base.SetIHelp = this as IHelp;
            InitGrid();

            SetDefault(base.Get타이틀명, flex, _bnOk, _bnSearch, _bnCancel, _txt검색);
            helpParam.QueryAction = QueryAction.RealTime;
            _txt검색.Text = helpParam.P92_DETAIL_SEARCH_CODE;
        }

        #region ♪ override 메서드 ♪

        //그리드 초기화
        private void InitGrid()
        {
            ArrayList list = new ArrayList();

            switch (base.GetHelpID)
            {
                case "H_CZ_ME_GR":     //매체 도움창 메조미디어
                    list.Add(new object[] { "CD_PARTNER", "매체ID", 70 });
                    list.Add(new object[] { "biz_name", "매체명", 180 });
                    list.Add(new object[] { "biz_name2", "사업자명", 180 });
                    list.Add(new object[] { "biz_no", "사업자등록번호", 90 });
                    break;

                case "H_CZ_ME_GR2":     //매체 도움창 메조미디어
                    list.Add(new object[] { "cd_partner", "ID", 70 });
                    list.Add(new object[] { "biz_name", "사업자명", 180 });
                    list.Add(new object[] { "biz_no", "사업자등록번호", 90 });
                    break;

                case "H_CZ_ME_EMP":              //사원 도움창 메조미디어
                    list.Add(new object[] { "NO_EMP", "사원코드", 100 });
                    list.Add(new object[] { "NM_KOR", "사원명", 200 });
                    break;

                case "H_CZ_ME_COR":              //사원 도움창 메조미디어
                    list.Add(new object[] { "CD_MEDIA", "매체ID", 100 });
                    list.Add(new object[] { "NM_MEDIA", "매체명", 200 });
                    break;
            }

            base.InitGrid(flex, list);  //그리드는 PageBase의 그리드와 다르다 
            flex.SettingVersion = "1.3.9";
        }

        private void _txtSearch_KeyDown(object sender, KeyEventArgs e)
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

        #endregion

        #region ♪ IHelp 멤버      ♪

        public DataTable SetDetail(string 검색)
        {
            DataTable dt = null;

            string 회사코드 = Global.MainFrame.LoginInfo.CompanyCode;
            List<object> parma = new List<object>();
            parma.Add(회사코드);
            parma.Add(base.GetHelpID);
            parma.Add(검색);

            switch (base.GetHelpID)
            {
                //메조미디어 매체
                case "H_CZ_ME_GR":
                    dt = DBHelper.GetDataTable("UP_CZ_MEZZO_SALESGR_P_S", new object[] { 회사코드, 검색, GetListParam[0] });
                    break;

                //메조미디어 매체
                case "H_CZ_ME_GR2":
                    dt = DBHelper.GetDataTable("UP_CZ_MEZZO_H_GR_S", new object[] { 회사코드, 검색, GetListParam[0] });
                    break;

                //메조미디어 사원
                case "H_CZ_ME_EMP":
                    dt = DBHelper.GetDataTable("UP_CZ_ME_EMP_P_S", new object[] { 회사코드, 검색, GetListParam[0] });
                    break;

                //메조미디어 매체
                case "H_CZ_ME_COR":
                    dt = DBHelper.GetDataTable("UP_CZ_MEZZO_H_COR_S", new object[] { 회사코드, 검색, GetListParam[0] });
                    break;
            }

            return dt;
        }

        public string Get검색
        {
            get { return _txt검색.Text; }
        }

        //파라미터 1개
        private void H_CZ_PARAM1(ref List<object> parma)
        {
            parma.Add(GetListParam[0]);
        }

        //파라미터 2개
        private void H_CZ_PARAM2(ref List<object> parma)
        {
            parma.Add(GetListParam[0]);
            parma.Add(GetListParam[1]);
        }

        //파라미터 3개
        private void H_CZ_PARAM3(ref List<object> parma)
        {
            parma.Add(GetListParam[0]);
            parma.Add(GetListParam[1]);
            parma.Add(GetListParam[3]);
        }
        #endregion
    }
}