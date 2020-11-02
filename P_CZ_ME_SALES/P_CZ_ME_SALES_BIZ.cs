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
            return DBHelper.GetDataSet("UP_CZ_ME_SALES_H_S3", obj);
        }

        internal bool Search_Save(object[] obj)
        {
            return DBHelper.ExecuteNonQuery("UP_CZ_ME_SALES_H_I_2", obj);
        }

        internal DataTable Get계정변경코드()
        {
            string sql = string.Format(@"                                
                                        SELECT CD_FLAG1 AS CODE, NM_SYSDEF AS [NAME], CD_FLAG2 AS GUBUN FROM MA_CODEDTL WHERE CD_COMPANY != '' AND CD_FIELD = 'CZ_ME_C024' ", 회사코드);
            return DBHelper.GetDataTable(sql);
        }

        internal DataTable Get계정코드()
        {
            string sql = string.Format(@" 
                                          SELECT CD_SYSDEF AS CODE, NM_SYSDEF AS NAME FROM MA_CODEDTL WHERE CD_COMPANY != '' ", 회사코드);
            return DBHelper.GetDataTable(sql);
        }

        internal DataTable Get마감여부(string 연월)
        {
            string sql = string.Format(@" SELECT ST_MAGAM, CASE WHEN ST_MAGAM = '1' THEN '마감' ELSE '미마감' END ST_FLAG
                FROM [NEOE].[CZ_MEZZO_SALES_CLOSE_N] 
                WHERE DT_YEAR = LEFT('" +연월+ @"',4) AND DT_MAGAM = (SELECT MAX(DT_MAGAM) FROM [NEOE].[CZ_MEZZO_SALES_CLOSE_N] WHERE CD_INDEX = 'M' AND DT_YEAR = LEFT('" +연월+ @"',4)) ", 회사코드);

            return DBHelper.GetDataTable(sql);
        }

        internal DataTable Get일괄처리여부(string 연월)
        {
            string sql = string.Format(@" SELECT CASE WHEN ISNULL(NM_USERDE1,'') = '일괄처리완료' THEN '1' ELSE '0' END AS FLAG
                FROM [NEOE].[CZ_MEZZO_SALES_DOCU] 
                WHERE DT_YEAR_MONTH = '" +연월+ @"' AND ISNULL(NM_USERDE1,'') = '일괄처리완료'
                GROUP BY NM_USERDE1 ", 회사코드);

            return DBHelper.GetDataTable(sql);
        }

        internal DataTable Get대행사세금계산서여부(string 대행사전표번호)
        {
            string sql = string.Format(@" SELECT ISNULL(B.FINAL_STATUS,'0') AS FINAL_STATUS
                FROM FI_DOCU A
                LEFT OUTER JOIN FI_TAX B ON A.CD_COMPANY = B.CD_COMPANY AND A.NO_DOCU = B.NO_DOCU AND A.NO_DOLINE = B.NO_DOLINE
                WHERE A.NO_DOCU = '" +대행사전표번호+ @"'", 회사코드);

            return DBHelper.GetDataTable(sql);
        }

        internal DataTable Get매체세금계산서여부(string 매체전표번호)
        {
            string sql = string.Format(@" SELECT ISNULL(B.FINAL_STATUS,'0') AS FINAL_STATUS
                FROM FI_DOCU A
                LEFT OUTER JOIN FI_TAX B ON A.CD_COMPANY = B.CD_COMPANY AND A.NO_DOCU = B.NO_DOCU AND A.NO_DOLINE = B.NO_DOLINE
                WHERE A.NO_DOCU = '" +매체전표번호+ @"'", 회사코드);

            return DBHelper.GetDataTable(sql);
        }

        internal DataTable Get대행사전표여부(string 캠페인ID, string SEQ)
        {
            string sql = string.Format(@" SELECT CASE WHEN ISNULL(NO_DOCU_M,'') != '' THEN '1' ELSE '0' END AS NO_DOCU
                FROM [NEOE].[CZ_MEZZO_SALES_MAP] 
                WHERE ME_CPID = '" +캠페인ID+ @"' AND ME_SEQ = '" +SEQ+ @"'", 회사코드);

            return DBHelper.GetDataTable(sql);
        }

        internal DataTable Get매체전표여부(string 캠페인ID, string SEQ)
        {
            string sql = string.Format(@" SELECT CASE WHEN ISNULL(NO_DOCU_D,'') != '' THEN '1' ELSE '0' END AS NO_DOCU
                FROM [NEOE].[CZ_MEZZO_SALES_MAP] 
                WHERE ME_CPID = '" +캠페인ID+ @"' AND ME_SEQ = '" +SEQ+ @"'", 회사코드);

            return DBHelper.GetDataTable(sql);
        }

        internal DataTable Get결산일시(string DT_DATE)
        {
            string sql = string.Format(@" SELECT MAX(CONVERT(DATETIME, LEFT(DT_MAGAM,8) + ' ' + STUFF(STUFF(RIGHT(DT_MAGAM,6), 3, 0, ':'), 6, 0, ':'), 120)) AS DT_CLOSING FROM [NEOE].[CZ_MEZZO_SALES_CLOSE_N] WHERE CD_INDEX = 'S' AND DT_YEAR = LEFT('" +DT_DATE+ @"',4)", 회사코드);
            return DBHelper.GetDataTable(sql);
        }

        internal bool Save_Junpyo_me(string 캠페인코드, string 순번, string 발행월, string 대행사기준, string 매체기준, string 계정과목, string 구분, string 매체아이디, string 합산매체, string REQ_NO)
        {
            string BIZ_AREA = Global.MainFrame.LoginInfo.BizAreaCode;
            string CD_PC = Global.MainFrame.LoginInfo.CdPc;
            string DEPT_CODE = Global.MainFrame.LoginInfo.DeptCode;
            string EMPLOYEE_NO = Global.MainFrame.LoginInfo.EmployeeNo;

            return DBHelper.ExecuteNonQuery("UP_CZ_ME_SALES_DOCU_ME_I", new object[] { 회사코드, 발행월, 캠페인코드, 순번, 매체기준, 계정과목, 구분, 합산매체, REQ_NO, BIZ_AREA, CD_PC, DEPT_CODE, EMPLOYEE_NO });
        }

        internal bool Save_Junpyo_ay(string 캠페인코드, string 순번, string 발행월, string 대행사기준, string 매체기준, string 계정과목, string 구분, string 매체아이디, string 합산매체)
        {
            string BIZ_AREA = Global.MainFrame.LoginInfo.BizAreaCode;
            string CD_PC = Global.MainFrame.LoginInfo.CdPc;
            string DEPT_CODE = Global.MainFrame.LoginInfo.DeptCode;
            string EMPLOYEE_NO = Global.MainFrame.LoginInfo.EmployeeNo;

            return DBHelper.ExecuteNonQuery("UP_CZ_ME_SALES_DOCU_AY_I", new object[] { 회사코드, 발행월, 캠페인코드, 순번, 대행사기준, 계정과목, 구분, 매체아이디, BIZ_AREA, CD_PC, DEPT_CODE, EMPLOYEE_NO });
        }

        internal bool Delete_Junpyo(string 대행사전표번호, string 매체전표번호, string 대행사세금계산서여부, string 매체세금계산서여부)
        {
            return DBHelper.ExecuteNonQuery("UP_CZ_ME_SALES_DOCU_D", new object[] { 회사코드, 대행사전표번호, 매체전표번호, 대행사세금계산서여부, 매체세금계산서여부 });
        }

        internal bool Delete_Junpyo_all(string 발행월)
        {
            return DBHelper.ExecuteNonQuery("UP_CZ_ME_SALES_DOCU_D_ALL", new object[] { 회사코드, 발행월 });
        }

        internal bool Save_Junpyo_ay_all(string 발행월)
        {
            string BIZ_AREA = Global.MainFrame.LoginInfo.BizAreaCode;
            string CD_PC = Global.MainFrame.LoginInfo.CdPc;
            string DEPT_CODE = Global.MainFrame.LoginInfo.DeptCode;
            string EMPLOYEE_NO = Global.MainFrame.LoginInfo.EmployeeNo;

            return DBHelper.ExecuteNonQuery("UP_CZ_ME_SALES_DOCU_AY_ALL_I", new object[] { 회사코드, 발행월, BIZ_AREA, CD_PC, DEPT_CODE, EMPLOYEE_NO });
        }

        internal bool Save_Junpyo_me_all(string 발행월)
        {
            string BIZ_AREA = Global.MainFrame.LoginInfo.BizAreaCode;
            string CD_PC = Global.MainFrame.LoginInfo.CdPc;
            string DEPT_CODE = Global.MainFrame.LoginInfo.DeptCode;
            string EMPLOYEE_NO = Global.MainFrame.LoginInfo.EmployeeNo;

            return DBHelper.ExecuteNonQuery("UP_CZ_ME_SALES_DOCU_ME_ALL_I", new object[] { 회사코드, 발행월, BIZ_AREA, CD_PC, DEPT_CODE, EMPLOYEE_NO });
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

        internal bool Update_Acct(string 대행사전표, string 매체전표, string 전계정, string 후계정)
        {
            return DBHelper.ExecuteNonQuery("UP_CZ_ME_SALES_ACCT_U", new object[] { 회사코드, 대행사전표, 매체전표, 전계정, 후계정 });
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
                    , "AM_AGY_PRICE", "AM_INCOME", "AM_MEDIA_PRICE", "AM_FEE_ALL", "CP_AGENTID", "NM_NOTE", "ID_INSERT"
                };
                si.SpParamsUpdate = new string[] { 
                    "CD_COMPANY", "TP_SALES", "REQ_NO", "CPID", "CPNAME", "SEQ", "AY_YEAR"
                    , "AY_AGENCYID", "AY_AGENCYNM", "AY_AGENCYNO", "AY_YEAR_MONTH", "AY_TRADE_TYPE", "ME_CORPID", "ME_CORPNM", "ME_CORPNO", "ME_YEAR_MONTH"
                    , "ME_TRADE_TYPE", "CD_SYSDEF", "CD_ACCT", "ME_TEAMID", "AM_BUDGET"
                    , "AM_AGY_PRICE", "AM_INCOME", "AM_MEDIA_PRICE", "AM_FEE_ALL", "CP_AGENTID", "NM_NOTE", "ID_INSERT"
                };

                sic.Add(si);

            }

            return Global.MainFrame.Save(sic);
        }
    }
}
