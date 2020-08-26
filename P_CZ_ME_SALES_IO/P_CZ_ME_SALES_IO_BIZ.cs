using System;
using System.Data;
using Duzon.Common.Forms;
using Duzon.Common.Util;
using Duzon.ERPU;

namespace cz
{
    class P_CZ_ME_SALES_IO_BIZ
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
            return DBHelper.GetDataSet("UP_CZ_ME_SALES_IO_S1", obj);
        }

        internal DataSet Search_D(object[] obj)
        {
            return DBHelper.GetDataSet("UP_FI_DOCU_NEW_S_D", obj);
        }

        internal DataTable Get계정코드()
        {
            string sql = string.Format(@" 
                                          SELECT NM_USERDE1 AS CODE, NM_ACCT AS NAME FROM FI_ACCTCODE WHERE NM_USERDE1 != '' ", 회사코드);
            return DBHelper.GetDataTable(sql);
        }

        internal bool Update_Status(string 캠페인코드, string 상태값변경, string 상태값변경2)
        {
            return DBHelper.ExecuteNonQuery("UP_CZ_ME_SALES_IO_U2", new object[] { 캠페인코드, 상태값변경, 상태값변경2 });
        }

        internal bool Update_Status_Tax(string 전표번호)
        {
            return DBHelper.ExecuteNonQuery("UP_CZ_ME_SALES_IO_U3", new object[] { 전표번호});
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

                si.SpNameInsert = "UP_CZ_ME_SALES_IO_U";
                si.SpNameUpdate = "UP_CZ_ME_SALES_IO_U";
                si.SpNameDelete = "UP_CZ_ME_SALES_IO_D";
                si.SpParamsInsert = new string[] { 
                     "CD_COMPANY", "CPID", "NO_DOCU", "ST_IO", "NM_USERDE1", "ID_INSERT", "ID_UPDATE"
                };
                si.SpParamsUpdate = new string[] { 
                    "CD_COMPANY", "CPID", "NO_DOCU", "ST_IO", "NM_USERDE1", "ID_INSERT", "ID_UPDATE"
                };
                si.SpParamsDelete = new string[] { "CD_COMPANY", "CPID" };
                sic.Add(si);
            }

            return Global.MainFrame.Save(sic);
        }
    }
}
