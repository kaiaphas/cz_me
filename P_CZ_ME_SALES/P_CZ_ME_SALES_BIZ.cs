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
            return DBHelper.GetDataSet("UP_CZ_ME_SALES_H_S2", obj);
        }

        internal bool Search_Save(object[] obj)
        {
             return DBHelper.ExecuteNonQuery("UP_CZ_ME_SALES_H_I_2", obj);
        }

        internal DataTable Get계정코드()
        {
            string sql = string.Format(@" 
                                          SELECT CD_SYSDEF AS CODE, NM_SYSDEF AS NAME FROM MA_CODEDTL WHERE CD_COMPANY != '' ", 회사코드);
            return DBHelper.GetDataTable(sql);
        }

        internal DataTable Get결산여부(string FROM, string TO)
        {
            string sql = string.Format(@" SELECT ISNULL(MAX(DT_YEAR_MONTH),'N') AS YEAR_MONTH FROM [NEOE].[CZ_MEZZO_SALES_DOCU] WHERE DT_YEAR_MONTH BETWEEN '" +FROM+ @"' AND '" +TO+ @"'", 회사코드);
            return DBHelper.GetDataTable(sql);
        }

        internal bool Save_Junpyo_ay(string 캠페인코드, string 순번, string 발행월, string 대행사기준, string 매체기준, string 합산매체, string 계정과목, string 구분)
        {
            string BIZ_AREA = Global.MainFrame.LoginInfo.BizAreaCode;
            string CD_PC = Global.MainFrame.LoginInfo.CdPc;
            string DEPT_CODE = Global.MainFrame.LoginInfo.DeptCode;
            string EMPLOYEE_NO = Global.MainFrame.LoginInfo.EmployeeNo;

            return DBHelper.ExecuteNonQuery("UP_CZ_ME_SALES_DOCU_AY_I", new object[] { 회사코드, 캠페인코드, 순번, 발행월, 대행사기준, 매체기준, 합산매체, 계정과목, 구분, BIZ_AREA, CD_PC, DEPT_CODE, EMPLOYEE_NO });
        }

        internal bool Save_Junpyo_me(string 캠페인코드, string 순번, string 발행월, string 대행사기준, string 매체기준, string 합산매체, string 계정과목, string 구분)
        {
            string BIZ_AREA = Global.MainFrame.LoginInfo.BizAreaCode;
            string CD_PC = Global.MainFrame.LoginInfo.CdPc;
            string DEPT_CODE = Global.MainFrame.LoginInfo.DeptCode;
            string EMPLOYEE_NO = Global.MainFrame.LoginInfo.EmployeeNo;

            return DBHelper.ExecuteNonQuery("UP_CZ_ME_SALES_DOCU_ME_I", new object[] { 회사코드, 캠페인코드, 순번, 발행월, 대행사기준, 매체기준, 합산매체, 계정과목, 구분, BIZ_AREA, CD_PC, DEPT_CODE, EMPLOYEE_NO });
        }

        internal DataSet Save_Sync(string FROM, string TO)
        {
            return DBHelper.GetDataSet("UP_CZ_ME_SALES_H_I_SYNC", new object[] { 회사코드, FROM, TO });
        }

        internal bool Delete(string FROM, string TO)
        {
            return DBHelper.ExecuteNonQuery("UP_CZ_ME_SALES_H_D", new object[] { 회사코드, FROM, TO });
        }

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

                si.SpNameInsert = "UP_CZ_ME_SALES_H_I";
                si.SpNameUpdate = "UP_CZ_ME_SALES_H_U";
                si.SpParamsInsert = new string[] { 
                    "CD_COMPANY", "TP_SALES", "REQ_NO", "CPID", "CPNAME", "SEQ", "AY_YEAR"
                    , "AY_AGENCYID", "AY_AGENCYNM", "AY_AGENCYNO", "AY_YEAR_MONTH", "AY_TRADE_TYPE", "ME_CORPID", "ME_CORPNM", "ME_CORPNO", "ME_YEAR_MONTH"
                    , "ME_TRADE_TYPE", "CD_SYSDEF", "CD_ACCT", "ME_TEAMID", "AM_BUDGET"
                    , "AM_AGY_PRICE", "AM_INCOME", "AM_MEDIA_PRICE", "FEE_ALL", "CP_AGENTID", "NM_NOTE", "ID_INSERT"
                };
                si.SpParamsUpdate = new string[] { 
                    "CD_COMPANY", "TP_SALES", "REQ_NO", "CPID", "CPNAME", "SEQ", "AY_YEAR"
                    , "AY_AGENCYID", "AY_AGENCYNM", "AY_AGENCYNO", "AY_YEAR_MONTH", "AY_TRADE_TYPE", "ME_CORPID", "ME_CORPNM", "ME_CORPNO", "ME_YEAR_MONTH"
                    , "ME_TRADE_TYPE", "CD_SYSDEF", "CD_ACCT", "ME_TEAMID", "AM_BUDGET"
                    , "AM_AGY_PRICE", "AM_INCOME", "AM_MEDIA_PRICE", "FEE_ALL", "CP_AGENTID", "NM_NOTE", "ID_INSERT"
                };
                
                sic.Add(si);

            }

            return Global.MainFrame.Save(sic);
        }
    }
}
