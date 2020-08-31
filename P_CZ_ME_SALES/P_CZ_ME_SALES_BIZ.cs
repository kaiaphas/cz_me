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

        internal DataTable Get마감여부(string 연월)
        {
            string sql = string.Format(@" SELECT ST_MAGAM 
                FROM [NEOE].[CZ_MEZZO_SALES_CLOSE_N] 
                WHERE DT_YEAR = LEFT('" +연월+ @"',4) AND DT_MAGAM = (SELECT MAX(DT_MAGAM) FROM [NEOE].[CZ_MEZZO_SALES_CLOSE_N] WHERE CD_INDEX = 'M') ", 회사코드);

            return DBHelper.GetDataTable(sql);
        }

        internal DataTable Get결산일시(string DT_DATE)
        {
            string sql = string.Format(@" SELECT MAX(CONVERT(DATETIME, LEFT(DT_MAGAM,8) + ' ' + STUFF(STUFF(RIGHT(DT_MAGAM,6), 3, 0, ':'), 6, 0, ':'), 120)) AS DT_CLOSING FROM [NEOE].[CZ_MEZZO_SALES_CLOSE_N] WHERE CD_INDEX = 'S' AND DT_YEAR = LEFT('" +DT_DATE+ @"',4)", 회사코드);
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
            string EMPLOYEE_NO = Global.MainFrame.LoginInfo.EmployeeNo;

            return DBHelper.GetDataSet("UP_CZ_ME_SALES_H_I_SYNC", new object[] { 회사코드, FROM, TO, EMPLOYEE_NO });
        }

        internal bool Delete(string FROM, string TO)
        {
            string EMPLOYEE_NO = Global.MainFrame.LoginInfo.EmployeeNo;

            return DBHelper.ExecuteNonQuery("UP_CZ_ME_SALES_H_D", new object[] { 회사코드, FROM, TO, EMPLOYEE_NO });
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
