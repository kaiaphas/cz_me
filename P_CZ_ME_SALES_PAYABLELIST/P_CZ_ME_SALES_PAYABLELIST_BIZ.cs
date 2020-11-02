using System;
using System.Data;
using Duzon.Common.Forms;
using Duzon.Common.Util;
using Duzon.ERPU;

namespace cz
{
    class P_CZ_ME_SALES_PAYABLELIST_BIZ
    {
        string 회사코드 = Global.MainFrame.LoginInfo.CompanyCode;
        string 사용자ID = Global.MainFrame.LoginInfo.UserID;

        #region -> 조회

        internal DataSet Search_M(object[] obj)
        {
            return DBHelper.GetDataSet("UP_CZ_ME_SALES_PAYABLELIST_S1", obj);
        }

        internal bool Update_Docu(string 전표번호, string 라인번호, string 전표지급일자, string 전표은행명, string 전표계좌번호)
        {
            string CD_PC = Global.MainFrame.LoginInfo.CdPc;

            return DBHelper.ExecuteNonQuery("UP_CZ_ME_SALES_PAYABLELIST_DOCU_U", new object[] { 회사코드, CD_PC, 전표번호, 라인번호, 전표지급일자, 전표은행명, 전표계좌번호, 사용자ID });
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
                
                /*
                if (타메뉴호출)
                    si.DataState = DataValueState.Added;
                else
                    si.DataState = DataValueState.Modified;
                */

                si.SpNameInsert = "";
                si.SpNameUpdate = "UP_CZ_ME_SALES_PAYABLELIST_DOCU_U";
                si.SpNameDelete = "";
                si.SpParamsInsert = new string[] { 
                     
                };
                si.SpParamsUpdate = new string[] { 
                        "CD_COMPANY", "CD_PC", "NO_DOCU", "NO_DOLINE", "DT_START_DOCU"
                      , "CD_BANK_DOCU", "NO_DEPOSIT_DOCU", "ID_INSERT"
                };
                si.SpParamsDelete = new string[] { 
                    
                };
                
                sic.Add(si);

            }

            return Global.MainFrame.Save(sic);
        }
    }
}
