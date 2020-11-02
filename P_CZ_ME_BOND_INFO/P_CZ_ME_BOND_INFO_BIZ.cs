using System;
using System.Data;
using Duzon.Common.Forms;
using Duzon.Common.Util;
using Duzon.ERPU;

namespace cz
{
    class P_CZ_ME_BOND_INFO_BIZ
    {
        string 회사코드 = Global.MainFrame.LoginInfo.CompanyCode;
        string 사용자ID = Global.MainFrame.LoginInfo.UserID;


        internal DataSet Search_M(object[] obj)
        {
            return DBHelper.GetDataSet("UP_CZ_ME_BOND_INFO_S1", obj);
        }

        internal DataTable GetMAX_NO_GUBUN(string 거래처코드, string 종류)
        {
            string sql = string.Format(@" SELECT MAX(NO_GUBUN) AS NO_GUBUN
                FROM [NEOE].[CZ_MEZZO_BOND_INFO] 
               WHERE NO_COMPANY = '" + 거래처코드 + @"' AND DOCU_GUBUN = '" + 종류 + @"'", 회사코드);

            return DBHelper.GetDataTable(sql);
        }

        internal bool Insert_Info(string 거래처, string 종류, string 번호, string 기존번호, string 설정액, string 체결일, string 시작일
                                , string 만기일, string 소멸시효, string 채무자, string 소유자, string 물건지
                                , string memo1, string 종류2, string 증권번호, string 발행인1, string 발행인2
                                , string 발행인3, string memo2, string 증권번호2, string 보험료, string 주계약내용
                                , string 계약시작일, string 계약종료일, string 계약체결일자, string 계약금액, string 발생채무액
                                , string memo3, string 연대보증인1, string 연대보증인2, string 연대보증인3, string memo4
                                , string 제3채1, string 제3채2, string 제3채3, string 채권양도통지서, string 인감증명서
                                , string 부속합의서 , string memo5, string 구분, string 시작일2, string 종료일
                                , string 분할횟수, string 특이사항, string memo6, string 비고, string memo7
                                   )
        {
            return DBHelper.ExecuteNonQuery("UP_CZ_ME_BOND_INFO_IU", new object[] {   회사코드, 거래처, 종류, 번호, 기존번호, 설정액, 체결일
                                                                                    , 시작일, 만기일, 소멸시효, 채무자, 소유자
                                                                                    , 물건지, memo1, 종류2, 증권번호, 발행인1
                                                                                    , 발행인2, 발행인3, memo2, 증권번호2, 보험료
                                                                                    , 주계약내용, 계약시작일, 계약종료일, 계약체결일자, 계약금액
                                                                                    , 발생채무액, memo3, 연대보증인1, 연대보증인2, 연대보증인3
                                                                                    , memo4, 제3채1, 제3채2, 제3채3, 채권양도통지서
                                                                                    , 인감증명서, 부속합의서, memo5, 구분, 시작일2
                                                                                    , 종료일, 분할횟수, 특이사항, memo6, 비고, memo7
                                                                                    , 사용자ID});
        }

        internal bool Delete_Info(string 거래처코드, string 보전서류구분, string 번호)
        {
            return DBHelper.ExecuteNonQuery("UP_CZ_ME_BOND_INFO_D", new object[] { 회사코드, 거래처코드, 보전서류구분, 번호 });
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

                si.SpNameInsert = "";
                si.SpNameUpdate = "";
                si.SpNameDelete = "";
                si.SpParamsInsert = new string[] { 
                };
                si.SpParamsUpdate = new string[] {     
                };
                si.SpParamsDelete = new string[] { 
                };
                sic.Add(si);
            }

            return Global.MainFrame.Save(sic);
        }
    }
}
