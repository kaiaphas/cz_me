using System;
using System.Data;
using Duzon.Common.Forms;
using Duzon.Common.Util;
using Duzon.ERPU;

namespace cz
{
    class P_CZ_ME_SALES_FOR_BIZ
    {
        string 회사코드 = Global.MainFrame.LoginInfo.CompanyCode;
        string 사용자ID = Global.MainFrame.LoginInfo.UserID;

        #region -> 조회
        public DataTable Search_T(object[] obj) // 헤더부분
        {
            string sp_name = "UP_CZ_MEZZO_MEDIAGR_H_S";
            DataTable dt = DBHelper.GetDataTable(sp_name, obj);
            return dt;
        }

        #endregion

        internal DataSet Search_M(object[] obj)
        {
            return DBHelper.GetDataSet("UP_CZ_ME_SALES_H_S2", obj);
        }

        internal DataTable Get계정코드()
        {
            string sql = string.Format(@" 
                                          SELECT NM_USERDE1 AS CODE, NM_ACCT AS NAME FROM FI_ACCTCODE WHERE NM_USERDE1 != '' ", 회사코드);
            return DBHelper.GetDataTable(sql);
        }

        internal bool Update_Sales(string 구분, string 캠페인코드, string 순번)
        {
            string EMPLOYEE_NO = Global.MainFrame.LoginInfo.EmployeeNo;

            return DBHelper.ExecuteNonQuery("UP_CZ_ME_SALES_TP_UP", new object[] { 회사코드, 구분, 캠페인코드, 순번, EMPLOYEE_NO });
        }

        public object Save(DataTable dtM, bool 타메뉴호출)
        {
            
            SpInfoCollection sic = new SpInfoCollection();
            SpInfo si;

            if (dtM != null)
            {
                si = new SpInfo();
              /*
                if (!타메뉴호출)
                    si.DataState = DataValueState.Added;
                else
                    si.DataState = DataValueState.Modified;
                */
                si.DataValue = dtM;
                si.CompanyID = 회사코드;
                si.UserID = 사용자ID;

                si.SpNameInsert = "UP_CZ_ME_SALES_FOR_I";
                si.SpNameUpdate = "UP_CZ_ME_SALES_FOR_U";
                si.SpNameDelete = "UP_CZ_ME_SALES_FOR_D";
                si.SpParamsInsert = new string[] { 
                    "CD_COMPANY", "TP_SALES", "MER_REQ_NO", "ME_CPID", "ME_CPNM"
                    , "ME_SEQ", "AY_AGENCYID", "AY_YEAR_MONTH", "AY_TRADE_TYPE", "ME_CORPID", "ME_YEAR_MONTH"
                    , "ME_TRADE_TYPE", "CD_SYSDEF", "CD_ACCT", "ME_TEAMID", "ME_TEAMNM", "AM_BUDGET"
                    , "AM_INCOME", "AM_AGY_PRICE", "AM_MEDIA_PRICE", "AY_AGENCYNO", "AY_AGENCYNM", "ME_CORPNO"
                    , "ME_CORPNM", "DT_YEAR_MONTH", "ID_INSERT"
                };
                si.SpParamsUpdate = new string[] { 
                    "CD_COMPANY", "TP_SALES", "MER_REQ_NO", "ME_CPID", "ME_CPNM"
                    , "ME_SEQ", "AY_AGENCYID", "AY_YEAR_MONTH", "AY_TRADE_TYPE", "ME_CORPID", "ME_YEAR_MONTH"
                    , "ME_TRADE_TYPE", "CD_SYSDEF", "CD_ACCT", "ME_TEAMID", "ME_TEAMNM", "AM_BUDGET"
                    , "AM_INCOME", "AM_AGY_PRICE", "AM_MEDIA_PRICE", "AY_AGENCYNO", "AY_AGENCYNM", "ME_CORPNO"
                    , "ME_CORPNM", "DT_YEAR_MONTH", "ID_INSERT"
                };
                si.SpParamsDelete = new string[] { "CD_COMPANY", "TP_SALES", "MER_REQ_NO", "ME_CPID", "ME_SEQ" };
                sic.Add(si);
            }
            
            return Global.MainFrame.Save(sic);
        }

        public DataTable GetLineTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("S", typeof(string));
            dt.Columns.Add("CD_DEPT_MTS", typeof(string));
            dt.Columns.Add("NM_DEPT_MTS", typeof(string));
            dt.Columns.Add("CD_DEPT", typeof(int));

            dt.Columns.Add("NM_DEPT", typeof(string));
            dt.Columns.Add("NO_APPLY", typeof(string));
            dt.Columns.Add("ID_INSERT", typeof(string));
            dt.Columns.Add("DTS_INSERT", typeof(string));

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (dt.Columns[i].DataType == Type.GetType("System.Decimal"))
                    dt.Columns[dt.Columns[i].ColumnName].DefaultValue = 0;
            }

            return dt;
        }

    }
}
