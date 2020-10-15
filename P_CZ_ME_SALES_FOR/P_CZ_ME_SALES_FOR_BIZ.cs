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
                    "cd_company", "tp_sales", "req_no", "cpid", "cpname"
                    , "seq", "ay_agencyid", "ay_year_month", "ay_trade_type", "me_corpid"
                    , "me_year_month", "me_trade_type", "cd_sysdef", "cd_acct", "me_teamid"
                    , "me_teamnm", "am_budget", "am_income", "am_agy_price", "am_media_price"
                    , "ay_agencyno", "ay_agencynm", "me_corpno", "me_corpnm", "ay_year"
                    , "id_insert"
                };
                si.SpParamsUpdate = new string[] { 
                    "cd_company", "tp_sales", "req_no", "cpid", "cpname"
                    , "seq", "ay_agencyid", "ay_year_month", "ay_trade_type", "me_corpid"
                    , "me_year_month", "me_trade_type", "cd_sysdef", "cd_acct", "me_teamid"
                    , "me_teamnm", "am_budget", "am_income", "am_agy_price", "am_media_price"
                    , "ay_agencyno", "ay_agencynm", "me_corpno", "me_corpnm", "ay_year"
                    , "id_insert"
                };
                si.SpParamsDelete = new string[] { "cd_company", "tp_sales", "req_no", "cpid", "seq" };
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
