using System;
using System.Data;
using Duzon.Common.Forms;
using Duzon.Common.Util;
using Duzon.ERPU;

namespace cz
{
    class P_CZ_ME_SALES_MAGAM_BIZ
    {
        string 회사코드 = Global.MainFrame.LoginInfo.CompanyCode;
        string 사용자ID = Global.MainFrame.LoginInfo.UserID;

        internal DataSet Search_M(object[] obj)
        {
            string sql = string.Format(@" 
                                          select * from fi_accseq ", 회사코드);
            return DBHelper.GetDataSet(sql);
        }

        internal DataSet Search_D(object[] obj)
        {
            return DBHelper.GetDataSet("UP_CZ_ME_SALES_MAGAM_S", obj);
        }

        internal DataTable Get계정코드()
        {
            string sql = string.Format(@" 
                                          SELECT NM_USERDE1 AS CODE, NM_ACCT AS NAME FROM FI_ACCTCODE WHERE NM_USERDE1 != '' ", 회사코드);
            return DBHelper.GetDataTable(sql);
        }


        internal DataTable Get마감여부(string 연월, string 구분)
        {
            string sql = string.Format(@" SELECT ST_MAGAM 
                FROM [NEOE].[CZ_MEZZO_SALES_CLOSE_N] 
                WHERE DT_YEAR = LEFT('" +연월+ @"',4) AND DT_MAGAM = (SELECT MAX(DT_MAGAM) FROM [NEOE].[CZ_MEZZO_SALES_CLOSE_N] WHERE CD_INDEX = 'M') ", 회사코드);

            return DBHelper.GetDataTable(sql);
        }

        internal bool Update_Magam(string 구분, string 연월)
        {
            string EMPLOYEE_NO = Global.MainFrame.LoginInfo.EmployeeNo;

            return DBHelper.ExecuteNonQuery("UP_CZ_ME_SALES_MAGAM_U", new object[] { 회사코드, 구분, 연월, EMPLOYEE_NO });
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
                    "CD_COMPANY", "TP_SALES", "MER_REQ_NO", "ME_CPID", "NM_CPID", "ME_SEQ"
                    , "AY_AGENCYID", "AY_YEAR_MONTH", "AY_TRADE_TYPE", "ME_CORPID", "ME_YEAR_MONTH"
                    , "ME_TRADE_TYPE", "CD_SYSDEF", "CD_ACCT", "ME_TEAMID", "AM_BUDGET"
                    , "AM_INCOME", "AM_AGY_PRICE", "AM_MEDIA_PRICE", "ID_INSERT", "ID_UPDATE"
                    , "DT_YEAR" 

                };
                si.SpParamsUpdate = new string[] { 
                    "CD_COMPANY", "TP_SALES", "MER_REQ_NO", "ME_CPID", "NM_CPID", "ME_SEQ"
                    , "AY_AGENCYID", "AY_YEAR_MONTH", "AY_TRADE_TYPE", "ME_CORPID", "ME_YEAR_MONTH"
                    , "ME_TRADE_TYPE", "CD_SYSDEF", "CD_ACCT", "ME_TEAMID", "AM_BUDGET"
                    , "AM_INCOME", "AM_AGY_PRICE", "AM_MEDIA_PRICE", "ID_INSERT", "ID_UPDATE"
                    , "DT_YEAR"
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
