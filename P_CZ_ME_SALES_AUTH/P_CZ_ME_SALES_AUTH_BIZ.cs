using System;
using System.Data;
using Duzon.Common.Forms;
using Duzon.Common.Util;
using Duzon.ERPU;

namespace cz
{
    class P_CZ_ME_SALES_AUTH_BIZ
    {
        string 회사코드 = Global.MainFrame.LoginInfo.CompanyCode;
        string 사용자ID = Global.MainFrame.LoginInfo.UserID;

        internal DataSet Search_M(object[] obj)
        {
            return DBHelper.GetDataSet("UP_CZ_ME_SALES_AUTH_S1", obj);
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

                si.SpNameInsert = "";
                si.SpNameUpdate = "UP_CZ_ME_SALES_AUTH_U";
                si.SpNameDelete = "";
                si.SpParamsInsert = new string[] { 
                };
                si.SpParamsUpdate = new string[] { 
                      "CD_COMPANY", "CD_BGACCT", "MTS통제구분", "공통비분배", "개인경비"
                      , "일반경비", "접근레벨", "ID_INSERT" 
                };
                si.SpParamsDelete = new string[] { 
                };
                sic.Add(si);
            }

            return Global.MainFrame.Save(sic);
        }
    }
}
