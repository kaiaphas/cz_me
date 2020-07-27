using System;
using System.Data;
using Duzon.Common.Forms;
using Duzon.Common.Util;
using Duzon.ERPU;

namespace cz
{
    class P_CZ_ME_MAP_PARTNER_BIZ
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

        internal DataSet Search_T1(object[] obj)
        {
            return DBHelper.GetDataSet("UP_CZ_ME_MAP_PARTNER_T1_S", obj);
        }

        internal DataSet Search_T2(object[] obj)
        {
            return DBHelper.GetDataSet("UP_CZ_ME_MAP_PARTNER_T2_S", obj);
        }

        //public object Save(DataTable dtM, DataTable dtD, bool 타메뉴호출)
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

                si.SpNameInsert = "UP_CZ_ME_MAP_PARTNER_T1_IU";
                si.SpNameUpdate = "UP_CZ_ME_MAP_PARTNER_T1_IU";
                si.SpParamsInsert = new string[] { "CD_COMPANY", "BIZ_ID", "BIZ_NAME", "CD_PARTNER", "LN_PARTNER", "NO_APPLY", "BIZ_NO", "MGR_NAME", "ID_INSERT" };
                si.SpParamsUpdate = new string[] { "CD_COMPANY", "BIZ_ID", "BIZ_NAME", "CD_PARTNER", "LN_PARTNER", "NO_APPLY", "BIZ_NO", "MGR_NAME", "ID_UPDATE" };
                sic.Add(si);
            }
            return Global.MainFrame.Save(sic);
        }

        public object Save_t2(DataTable dtM, bool 타메뉴호출)
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

                si.SpNameInsert = "UP_CZ_ME_MAP_PARTNER_T2_IU";
                si.SpNameUpdate = "UP_CZ_ME_MAP_PARTNER_T2_IU";
                si.SpParamsInsert = new string[] { "CD_COMPANY", "me_type", "me_attr", "me_sumcode", "corpflag", "corpid", "ID_INSERT" };
                si.SpParamsUpdate = new string[] { "CD_COMPANY", "me_type", "me_attr", "me_sumcode", "corpflag", "corpid", "ID_UPDATE" };
                sic.Add(si);
            }
            return Global.MainFrame.Save(sic);
        }

        public DataTable GetLineTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("S", typeof(string));
            dt.Columns.Add("corpflag", typeof(string));

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (dt.Columns[i].DataType == Type.GetType("System.Decimal"))
                    dt.Columns[dt.Columns[i].ColumnName].DefaultValue = 0;
            }

            return dt;
        }

       /*
        internal DataTable Get매체구분()
        {
            string sql = string.Format(@" SELECT '' AS CODE , '' AS NAME 
                                            UNION ALL
                                            SELECT CD_MEDIAGR AS CODE, NM_MEDIAGR AS NAME FROM CZ_MEZZO_MEDIAGR_H ", 회사코드);
            return DBHelper.GetDataTable(sql);
        }
        */
    }
}
