using System;
using System.Data;
using Duzon.Common.Forms;
using Duzon.Common.Util;
using Duzon.ERPU;

namespace cz
{
    class P_CZ_ME_SALES_PUB_BIZ
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
            return DBHelper.GetDataSet("UP_CZ_ME_SALES_PUB_S", obj);
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

                si.SpNameInsert = "UP_CZ_ME_SALES_PUB_I";
                si.SpNameUpdate = "UP_CZ_ME_SALES_PUB_U";
                si.SpNameDelete = "UP_CZ_ME_SALES_PUB_D";
                si.SpParamsInsert = new string[] { 
                    "CD_COMPANY", "TP_SALES", "MER_REQ_NO", "ME_CPID", "ME_SEQ"
                    , "ME_CORPID", "ME_YEAR_MONTH", "ME_TRADE_TYPE", "AM_BUDGET", "AM_AGY_PRICE"
                    , "AM_MEDIA_PRICE", "ID_INSERT", "ID_UPDATE"
                };
                si.SpParamsUpdate = new string[] { 
                    "CD_COMPANY", "TP_SALES", "MER_REQ_NO", "ME_CPID", "ME_SEQ"
                    , "ME_CORPID", "ME_YEAR_MONTH", "ME_TRADE_TYPE", "AM_BUDGET", "AM_AGY_PRICE"
                    , "AM_MEDIA_PRICE", "ID_INSERT", "ID_UPDATE"
                };
                si.SpParamsDelete = new string[] { "CD_COMPANY", "TP_SALES", "MER_REQ_NO", "ME_CPID", "ME_SEQ" };
                sic.Add(si);
            }
            
            return Global.MainFrame.Save(sic);
        }

        internal bool Save_Junpyo(string SALES_구분, string 순번, string 거래처코드, string 발행월, string 거래처명, string 거래처구분, string PUB코드, string 수주액, string 수수료, string 수익, string 동기화)
        {
                string BIZ_AREA = Global.MainFrame.LoginInfo.BizAreaCode;
                string CD_PC = Global.MainFrame.LoginInfo.CdPc;
                string DEPT_CODE = Global.MainFrame.LoginInfo.DeptCode;
                string EMPLOYEE_NO = Global.MainFrame.LoginInfo.EmployeeNo;

                return DBHelper.ExecuteNonQuery("UP_CZ_ME_SALES_PUB_DOCU_I", new object[] { 회사코드, 거래처코드, 거래처명, 거래처구분, 수주액, 수수료, 수익, BIZ_AREA, CD_PC, DEPT_CODE, EMPLOYEE_NO, SALES_구분, PUB코드, 순번, 발행월, 동기화 });
        }

        internal bool Delete_Junpyo(string 전표번호)
        {
            return DBHelper.ExecuteNonQuery("UP_CZ_ME_SALES_PUB_DOCU_D", new object[] { 회사코드, 전표번호});
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
