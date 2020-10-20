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

        internal bool Update_Status_Tax(string 전표번호, string 전표라인번호)
        {
            return DBHelper.ExecuteNonQuery("UP_CZ_ME_SALES_IO_U3", new object[] { 전표번호, 전표라인번호 });
        }

        internal bool Insert_IO(string 캠페인코드, string 전표번호, string 전표라인번호, string 상태값변경, string 발행상태, string 사유)
        {
            return DBHelper.ExecuteNonQuery("UP_CZ_ME_SALES_IO_U", new object[] { 캠페인코드, 회사코드, 전표번호, 전표라인번호, 상태값변경, 발행상태, 사유, 사용자ID });
        }

        internal bool Delete_IO(string 캠페인코드)
        {
            return DBHelper.ExecuteNonQuery("UP_CZ_ME_SALES_IO_D", new object[] { 회사코드, 캠페인코드 });
        }

        internal DataTable Get마감여부(string 연월)
        {
            string sql = string.Format(@" SELECT ST_MAGAM, CASE WHEN ST_MAGAM = '1' THEN '마감' ELSE '미마감' END ST_FLAG
                FROM [NEOE].[CZ_MEZZO_SALES_CLOSE_N] 
                WHERE DT_YEAR = LEFT('" + 연월 + @"',4) AND DT_MAGAM = (SELECT MAX(DT_MAGAM) FROM [NEOE].[CZ_MEZZO_SALES_CLOSE_N] WHERE CD_INDEX = 'M' AND DT_YEAR = LEFT('" + 연월 + @"',4)) ", 회사코드);

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

                si.SpNameInsert = "UP_CZ_ME_SALES_IO_U";
                si.SpNameUpdate = "UP_CZ_ME_SALES_IO_U";
                si.SpNameDelete = "UP_CZ_ME_SALES_IO_D";
                si.SpParamsInsert = new string[] { 
                     "CPID", "CD_COMPANY", "NO_DOCU", "NO_DOLINE", "ST_IO", "DUZON_STAT", "NM_USERDE1", "ID_INSERT", "ID_UPDATE"
                };
                si.SpParamsUpdate = new string[] { 
                    "CPID", "CD_COMPANY",  "NO_DOCU", "NO_DOLINE", "ST_IO", "DUZON_STAT", "NM_USERDE1", "ID_INSERT", "ID_UPDATE"
                };
                si.SpParamsDelete = new string[] { "CD_COMPANY", "CPID" };
                sic.Add(si);
            }

            return Global.MainFrame.Save(sic);
        }
    }
}
