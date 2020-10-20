using System;
using System.Data;
using Duzon.Common.Forms;
using Duzon.Common.Util;
using Duzon.ERPU;

namespace cz
{
    class P_CZ_ME_SALES_PAYABLE_BIZ
    {
        string 회사코드 = Global.MainFrame.LoginInfo.CompanyCode;
        string 사용자ID = Global.MainFrame.LoginInfo.UserID;

        #region -> 조회

        internal DataSet Search_M(object[] obj)
        {
            return DBHelper.GetDataSet("UP_CZ_ME_SALES_PAYABLE_S1", obj);
        }

        #endregion


        public object Save(DataTable dtM, bool 타메뉴호출)
        {
            SpInfoCollection sic = new SpInfoCollection();
            SpInfo si;

            if (dtM != null)
            {
                si = new SpInfo();
                
                si.DataValue = dtM;
                si.CompanyID = 회사코드;
                si.UserID = 사용자ID;

                if (타메뉴호출)
                    si.DataState = DataValueState.Added;
                else
                    si.DataState = DataValueState.Modified;

                si.SpNameInsert = "UP_CZ_ME_SALES_PAYABLE_IU";
                si.SpNameUpdate = "UP_CZ_ME_SALES_PAYABLE_IU";
                si.SpParamsInsert = new string[] { 
                        "CD_COMPANY", "CD_PARTNER", "CD_MEDIA", "NM_MEDIA", "TP_PAYABLE"
                      , "CD_BANK", "NO_DEPOSIT", "NO_COMPANY", "NM_COMPANY", "MA_CEO"
                      , "NM_NOTE", "ID_INSERT"
                };
                si.SpParamsUpdate = new string[] { 
                        "CD_COMPANY", "CD_PARTNER", "CD_MEDIA", "NM_MEDIA", "TP_PAYABLE"
                      , "CD_BANK", "NO_DEPOSIT", "NO_COMPANY", "NM_COMPANY", "MA_CEO"
                      , "NM_NOTE", "ID_INSERT"
                };
                
                sic.Add(si);

            }

            return Global.MainFrame.Save(sic);
        }
    }
}
