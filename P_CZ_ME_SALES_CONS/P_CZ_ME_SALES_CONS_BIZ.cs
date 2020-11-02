using System;
using System.Data;
using Duzon.Common.Forms;
using Duzon.Common.Util;
using Duzon.ERPU;

namespace cz
{
    class P_CZ_ME_SALES_CONS_BIZ
    {
        string 회사코드 = Global.MainFrame.LoginInfo.CompanyCode;
        string 사용자ID = Global.MainFrame.LoginInfo.UserID;

        internal DataSet Search_M(object[] obj)
        {
            return DBHelper.GetDataSet("UP_CZ_ME_SALES_CONS_S1", obj);
        }

        internal DataSet Search_D(object[] obj)
        {
            return DBHelper.GetDataSet("UP_CZ_ME_SALES_CONS_S2", obj);
        }

        internal DataSet Search_T(object[] obj)
        {
            return DBHelper.GetDataSet("UP_CZ_ME_SALES_CONS_S3", obj);
        }

        internal bool Update_Cust(string 전표번호, string 광고주사업자번호, string 광고주명, string 사업자번호)
        {
            string CD_PC = Global.MainFrame.LoginInfo.CdPc;

            return DBHelper.ExecuteNonQuery("UP_CZ_ME_SALES_CONS_CUST_U", new object[] { 회사코드, CD_PC, 전표번호, 광고주사업자번호, 광고주명, 사업자번호, 사용자ID });
        }

        internal bool Update_Cust_Cancel(string 전표번호, string 수탁자번호, string 수탁자명)
        {
            string CD_PC = Global.MainFrame.LoginInfo.CdPc;

            return DBHelper.ExecuteNonQuery("UP_CZ_ME_SALES_CONS_CUST_U2", new object[] { 회사코드, CD_PC, 전표번호, 수탁자번호, 수탁자명, 사용자ID });
        }

        internal bool Insert_Cust(string 광고주사업자번호, string 광고주명, string 광고주대표, string 광고주담당이메일, string 광고주주소)
        {
            string CD_PC = Global.MainFrame.LoginInfo.CdPc;

            return DBHelper.ExecuteNonQuery("UP_CZ_ME_SALES_CONS_CUST_I", new object[] { 회사코드, CD_PC, 광고주사업자번호, 광고주명, 광고주대표, 광고주담당이메일, 광고주주소, 사용자ID });
        }

        internal DataTable Get업로드일시()
        {
            string sql = string.Format(@" SELECT CASE WHEN MAX(DTS_UPDATE) IS NULL THEN MAX(CONVERT(DATETIME, LEFT(DTS_INSERT,8) + ' ' + STUFF(STUFF(RIGHT(DTS_INSERT,6), 3, 0, ':'), 6, 0, ':'), 120))
											          ELSE MAX(CONVERT(DATETIME, LEFT(DTS_UPDATE,8) + ' ' + STUFF(STUFF(RIGHT(DTS_UPDATE,6), 3, 0, ':'), 6, 0, ':'), 120)) END AS DTS_INSERT
                                            FROM CZ_MEZZO_ETAX WHERE CHK_YN IS NULL ", 회사코드);
            return DBHelper.GetDataTable(sql);
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

                si.SpNameInsert = "UP_CZ_ME_SALES_CONS_IU";
                si.SpNameUpdate = "UP_CZ_ME_SALES_CONS_IU";
                si.SpNameDelete = "";
                si.SpParamsInsert = new string[] { 
                   "CD_COMPANY", "NO_ETAX", "DT_WRITE", "DT_START", "NO_COMPANY1"
                  ,"NO_JONG1", "NM_COMPANY1", "NM_CEO1", "NO_COMPANY2", "NO_JONG2"
                  ,"NM_COMPANY2", "NM_CEO2", "AM_SUM", "AM_TAXSTD", "AM_ADDTAX"
                  ,"TP_TAX", "NM_TAX", "TP_BAL", "NM_BIGO", "DT_SEND"
                  ,"SELL_DAM_EMAIL", "BUY_DAM_EMAIL", "NM_ST_TAX", "BUY_DAM_EMAIL2", "NM_ITEM"
                  ,"DC_ADDRESS_SELL", "DC_ADDRESS_BUY", "NO_COMPANY3", "NM_COMPANY3", "NM_BIGO2"
                  ,"S", "ID_INSERT"
                };
                si.SpParamsUpdate = new string[] { 
                  "CD_COMPANY", "NO_ETAX", "DT_WRITE", "DT_START", "NO_COMPANY1"
                  ,"NO_JONG1", "NM_COMPANY1", "NM_CEO1", "NO_COMPANY2", "NO_JONG2"
                  ,"NM_COMPANY2", "NM_CEO2", "AM_SUM", "AM_TAXSTD", "AM_ADDTAX"
                  ,"TP_TAX", "NM_TAX", "TP_BAL", "NM_BIGO", "DT_SEND"
                  ,"SELL_DAM_EMAIL", "BUY_DAM_EMAIL", "NM_ST_TAX", "BUY_DAM_EMAIL2", "NM_ITEM"
                  ,"DC_ADDRESS_SELL", "DC_ADDRESS_BUY", "NO_COMPANY3", "NM_COMPANY3", "NM_BIGO2"
                  ,"S", "ID_INSERT"
                };
                si.SpParamsDelete = new string[] { };
                sic.Add(si);
            }

            return Global.MainFrame.Save(sic);
        }
    }
}
