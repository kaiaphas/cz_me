using System;
using System.Data;
using Duzon.Common.Forms;
using Duzon.Common.Util;
using Duzon.ERPU;

namespace cz
{
    class P_CZ_ME_SALES_COMMISSION_BIZ
    {
        string 회사코드 = Global.MainFrame.LoginInfo.CompanyCode;
        string 사용자ID = Global.MainFrame.LoginInfo.UserID;

        internal DataSet Search_M(object[] obj)
        {
            return DBHelper.GetDataSet("UP_CZ_ME_SALES_COMMISSION_S1", obj);
        }

        internal DataSet Search_D(object[] obj)
        {
            return DBHelper.GetDataSet("UP_CZ_ME_SALES_COMMISSION_S2", obj);
        }

        internal DataSet Search_T(object[] obj)
        {
            return DBHelper.GetDataSet("UP_CZ_ME_SALES_COMMISSION_S3", obj);
        }

        internal DataTable Get계정코드()
        {
            string sql = string.Format(@" 
                                          SELECT NM_USERDE1 AS CODE, NM_ACCT AS NAME FROM FI_ACCTCODE WHERE NM_USERDE1 != '' ", 회사코드);
            return DBHelper.GetDataTable(sql);
        }

        public object Save(DataTable dtM, bool 타메뉴호출)
        {
            SpInfoCollection sic = new SpInfoCollection();
            SpInfo si;

            string DEPT_CODE = Global.MainFrame.LoginInfo.DeptCode;

            if (dtM != null)
            {
                si = new SpInfo();

                si.DataValue = dtM;
                si.CompanyID = 회사코드;
                si.UserID = 사용자ID;

                si.SpNameInsert = "UP_CZ_ME_SALES_COMMISSION_I";
                si.SpNameUpdate = "UP_CZ_ME_SALES_COMMISSION_U";
                si.SpNameDelete = "UP_CZ_ME_SALES_COMMISSION_D";
                si.SpParamsInsert = new string[] { 
                      "CD_COMPANY", "TP_SALES", "MER_REQ_NO", "ME_CPID", "CPNAME", "ME_SEQ", "DT_YEAR_MONTH", "AY_AGENCYID", "AY_AGENCYNM", "AY_AGENCYNO", "AY_YEAR_MONTH"
                    , "AY_TRADE_TYPE_CD", "ME_CORPID", "ME_CORPNM", "ME_CORPNO", "ME_YEAR_MONTH", "ME_TRADE_TYPE_CD", "AY_AGENCYID_ORI", "AY_AGENCYNM_ORI", "CD_SYSDEF", "CD_ACCT", "ME_TEAMID"
                    , "ME_TEAMNM", "ME_TEAMLV", "ME_TEAMORD", "AM_BUDGET", "AM_AGY_PRICE", "AM_INCOME", "AM_MEDIA_PRICE", "AM_FEE_ALL", "CP_AGENTID", "CP_AGENTNM", "CP_AGENTNO"
                    , "NM_NOTE", "ID_NOTE", "DT_NOTE", "NM_USERDE1", "NM_USERDE2", "ID_INSERT" 

                };
                si.SpParamsUpdate = new string[] { 
                      "CD_COMPANY", "TP_SALES", "MER_REQ_NO", "ME_CPID", "ME_SEQ"
                     , "AY_YEAR_MONTH", "ME_YEAR_MONTH", "AM_BUDGET", "AM_AGY_PRICE", "AM_INCOME"
                     , "AM_MEDIA_PRICE", "ID_INSERT" 
                };
                si.SpParamsDelete = new string[] { "CD_COMPANY", "TP_SALES", "MER_REQ_NO", "ME_CPID", "ME_SEQ" };
                sic.Add(si);
            }

            return Global.MainFrame.Save(sic);
        }
    }
}
