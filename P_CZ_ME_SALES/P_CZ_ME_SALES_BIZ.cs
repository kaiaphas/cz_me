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
            return DBHelper.GetDataSet("UP_CZ_ME_SALES_H_S_test2", obj);
        }

        internal DataTable Get계정코드()
        {
            string sql = string.Format(@" 
                                          SELECT CD_SYSDEF AS CODE, NM_SYSDEF AS NAME FROM MA_CODEDTL WHERE CD_COMPANY != '' ", 회사코드);
            return DBHelper.GetDataTable(sql);
        }

        internal bool Save_Junpyo_ay(string 캠페인코드, string 순번, string 발행월, string 대행사기준, string 매체기준, string 합산매체, string 구분)
        {
            string BIZ_AREA = Global.MainFrame.LoginInfo.BizAreaCode;
            string CD_PC = Global.MainFrame.LoginInfo.CdPc;
            string DEPT_CODE = Global.MainFrame.LoginInfo.DeptCode;
            string EMPLOYEE_NO = Global.MainFrame.LoginInfo.EmployeeNo;

            return DBHelper.ExecuteNonQuery("UP_CZ_ME_SALES_DOCU_AY_I", new object[] { 회사코드, 캠페인코드, 순번, 발행월, 대행사기준, 매체기준, 합산매체, 구분, BIZ_AREA, CD_PC, DEPT_CODE, EMPLOYEE_NO });
        }

        internal bool Save_Junpyo_me(string 캠페인코드, string 순번, string 발행월, string 대행사기준, string 매체기준, string 합산매체, string 구분)
        {
            string BIZ_AREA = Global.MainFrame.LoginInfo.BizAreaCode;
            string CD_PC = Global.MainFrame.LoginInfo.CdPc;
            string DEPT_CODE = Global.MainFrame.LoginInfo.DeptCode;
            string EMPLOYEE_NO = Global.MainFrame.LoginInfo.EmployeeNo;

            return DBHelper.ExecuteNonQuery("UP_CZ_ME_SALES_DOCU_ME_I", new object[] { 회사코드, 캠페인코드, 순번, 발행월, 대행사기준, 매체기준, 합산매체, 구분, BIZ_AREA, CD_PC, DEPT_CODE, EMPLOYEE_NO });
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

                si.SpNameInsert = "UP_CZ_ME_SALES_H_I";
                si.SpNameUpdate = "UP_CZ_ME_SALES_H_U";
                si.SpParamsInsert = new string[] { 
                    "CD_COMPANY", "TP_SALES", "REQ_NO", "CPID", "CPNAME", "SEQ"
                    , "AY_AGENCYID", "AY_AGENCYNO", "AY_YEAR_MONTH", "AY_TRADE_TYPE", "ME_CORPID", "ME_CORPNO", "ME_YEAR_MONTH"
                    , "ME_TRADE_TYPE", "CD_SYSDEF", "CD_ACCT", "ME_TEAMID", "AM_BUDGET"
                    , "AM_AGY_PRICE", "AM_INCOME", "AM_MEDIA_PRICE", "CP_AGENTID", "NM_NOTE", "ID_INSERT"
                };
                si.SpParamsUpdate = new string[] { 
                    "CD_COMPANY", "TP_SALES", "REQ_NO", "CPID", "CPNAME", "SEQ"
                    , "AY_AGENCYID", "AY_AGENCYNO", "AY_YEAR_MONTH", "AY_TRADE_TYPE", "ME_CORPID", "ME_CORPNO", "ME_YEAR_MONTH"
                    , "ME_TRADE_TYPE", "CD_SYSDEF", "CD_ACCT", "ME_TEAMID", "AM_BUDGET"
                    , "AM_AGY_PRICE", "AM_INCOME", "AM_MEDIA_PRICE", "CP_AGENTID", "NM_NOTE", "ID_INSERT"
                };
                
                sic.Add(si);

            }

            return Global.MainFrame.Save(sic);
        }

    }
}
