using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Duzon.Common.Forms.Help;
using Duzon.Common.Forms;
using System.Collections;
using Duzon.ERPU;
using C1.Win.C1FlexGrid;

namespace cz
{
    public partial class H_CZ_TAX_SUB : HelpBase, IHelp
    {
        public H_CZ_TAX_SUB(HelpParam helpParam) : base(helpParam)
        {
            InitializeComponent();
            base.SetIHelp = this as IHelp;

            InitGrid();

            DateTime time = Global.MainFrame.GetDateTimeToday();
            string today = "";
            string toyearmonth = "";

            today = time.ToString("yyyyMMdd");
            toyearmonth = today.Substring(0, 6)+"01";

            dt일자.StartDate = DateTime.ParseExact(toyearmonth, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            dt일자.EndDate = Global.MainFrame.GetDateTimeToday();

            SetDefault(base.Get타이틀명, flex, btn확인, btn검색, btn취소, txt검색);
            helpParam.QueryAction = QueryAction.RealTime;

            txt검색.Text = helpParam.P92_DETAIL_SEARCH_CODE;
        }

        private void InitGrid()
        {
            ArrayList list = new ArrayList();

            list.Add(new object[] { "DT_ACCT", "회계일자", 100 });
            list.Add(new object[] { "NO_DOCU", "전표번호", 120 });
            list.Add(new object[] { "NM_NOTE", "적요", 120 });
            list.Add(new object[] { "ID_UPDATE", "사업자번호", 100 });
            list.Add(new object[] { "LN_PARTNER", "거래처명", 120 });
            list.Add(new object[] { "AM_TAXSTD", "공급대가", 100 });
            list.Add(new object[] { "AM_ADDTAX", "공급가액", 100 });

            base.InitGrid(flex, list);

            flex.Cols["DT_ACCT"].TextAlign = TextAlignEnum.CenterCenter;
            flex.Cols["DT_ACCT"].Format = "####/##/##";
            flex.SetStringFormatCol("DT_ACCT");

            flex.Cols["AM_TAXSTD"].DataType = typeof(decimal);
            flex.Cols["AM_TAXSTD"].Format = "#,###";
            flex.SetStringFormatCol("AM_TAXSTD");

            flex.Cols["AM_ADDTAX"].DataType = typeof(decimal);
            flex.Cols["AM_ADDTAX"].Format = "#,###";
            flex.SetStringFormatCol("AM_ADDTAX");

            flex.Cols["ID_UPDATE"].TextAlign = TextAlignEnum.CenterCenter;
            flex.Cols["ID_UPDATE"].Format = "###-##-#####";
            flex.SetStringFormatCol("ID_UPDATE");

            /*
            flex.Cols["AM_GIMALMISU"].DataType = typeof(decimal);
            flex.Cols["AM_GIMALMISU"].Format = "#,###";
            flex.Cols["AM_GIMALMISU"].TextAlign = TextAlignEnum.RightCenter;
            flex.SetStringFormatCol("AM_GIMALMISU");

            flex.Cols["NO_COMPANY"].TextAlign = TextAlignEnum.CenterCenter;
            flex.Cols["NO_COMPANY"].Format = "###-##-#####";
            flex.SetStringFormatCol("NO_COMPANY");
            */

            flex.SettingVersion = "1.2";
        }

        #region IHelp 멤버

        public DataTable SetDetail(string 검색)
        {
            string 회사코드 = Global.MainFrame.LoginInfo.CompanyCode;

            object 시작일자 = dt일자.StartDateToString;
            object 종료일자 = dt일자.EndDateToString;

            List<object> parma = new List<object>();
            parma.Add(회사코드);
            parma.Add(base.GetHelpID);
            parma.Add(검색);

            MsgControl.ShowMsg("전표 목록을 조회중 입니다.");

            DataTable dt = DBHelper.GetDataTable("UP_H_CZ_TAX_SUB_S", new object[] { 회사코드, 시작일자, 종료일자, 검색 });

            MsgControl.CloseMsg();

            flex.Focus();

            return dt;
        }

        public string Get검색
        {
            get { return txt검색.Text; }
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
