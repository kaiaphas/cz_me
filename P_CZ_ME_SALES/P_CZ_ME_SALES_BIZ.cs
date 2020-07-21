using System;
using System.Data;
using Duzon.Common.Forms;
using Duzon.Common.Util;
using Duzon.ERPU;

namespace cz
{
    class P_CZ_ME_SALES_BIZ
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
            return DBHelper.GetDataSet("UP_CZ_ME_SALES_H_S_TEST", obj);
        }

        internal DataTable Get계정코드()
        {
            string sql = string.Format(@" 
                                          SELECT CD_SYSDEF AS CODE, NM_SYSDEF AS NAME FROM MA_CODEDTL WHERE CD_COMPANY != '' ", 회사코드);
            return DBHelper.GetDataTable(sql);
        }

        public object Save(DataTable dtM)
        {

            SpInfoCollection sic = new SpInfoCollection();
            SpInfo si;

            if (dtM != null)
            {
                si = new SpInfo();
                
                si.DataValue = dtM;
                si.CompanyID = 회사코드;
                si.UserID = 사용자ID;

                si.SpNameInsert = "UP_CZ_ME_SALES_I";
                si.SpNameUpdate = "UP_CZ_ME_SALES_U";
                si.SpParamsInsert = new string[] { 
                    "CD_COMPANY", "actyear", "CD_ACCT", "cpid", "cpname", "yearmonth"
                    , "trade_type_d", "biz_no_d", "agencyid", "corpname_d", "yearmonth2"
                    , "trade_type_m", "biz_no_m", "corpid", "corpname_m", "NM_MEDIAGR"
                    , "teamid", "teamname", "budget", "agy_price", "income"
                    , "corp_amt", "agentid", "agentname", "closed", "status"
                    , "ID_INSERT", "ID_UPDATE"};
                si.SpParamsUpdate = new string[] { 
                    "CD_COMPANY", "actyear", "CD_ACCT", "cpid", "cpname", "yearmonth"
                    , "trade_type_d", "biz_no_d", "agencyid", "corpname_d", "yearmonth2"
                    , "trade_type_m", "biz_no_m", "corpid", "corpname_m", "NM_MEDIAGR"
                    , "teamid", "teamname", "budget", "agy_price", "income"
                    , "corp_amt", "agentid", "agentname", "closed", "status"
                    , "ID_INSERT", "ID_UPDATE"};
                
                sic.Add(si);

            }

            return Global.MainFrame.Save(sic);
        }

    }
}
