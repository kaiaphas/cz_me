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

        internal bool Insert_Info(string 거래처, string 종류, string 설정액, string 체결일, string 시작일
                                , string 만기일, string 소멸시효, string 채무자, string 소유자, string 물건지
                                , string 종류2, string 증권번호, string 발행인1, string 발행인2, string 발행인3
                                , string 증권번호2, string 보험료, string 연대보증인1, string 연대보증인2, string 연대보증인3
                                , string 제3채1, string 제3채2, string 제3채3, string 구분, string 시작일2
                                , string 종료일, string 분할횟수, string 특이사항, string 비고
                                   )
        {
            return DBHelper.ExecuteNonQuery("UP_CZ_ME_BOND_INFO_IU", new object[] { 회사코드, 거래처, 종류, 설정액, 체결일
                                                                                 , 시작일, 만기일, 소멸시효, 채무자, 소유자
                                                                                 , 물건지, 종류2, 증권번호, 발행인1, 발행인2
                                                                                 , 발행인3, 증권번호2, 보험료, 연대보증인1, 연대보증인2
                                                                                 , 연대보증인3, 제3채1, 제3채2, 제3채3, 구분
                                                                                 , 시작일2, 종료일, 분할횟수, 특이사항, 비고
                                                                                 , 사용자ID});
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
