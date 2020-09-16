using System;
using System.Data;
using Duzon.Common.Forms;
using Duzon.Common.Util;
using Duzon.ERPU;

namespace cz
{
    class P_CZ_ME_MAP_DEPT_BIZ
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
            return DBHelper.GetDataSet("UP_CZ_ME_MAP_DEPT_S", obj);
        }

        public DataTable Search_tree(object[] obj)
        {
            string sp_name = "UP_CZ_ME_MAP_DEPT_S";
            DataTable dt = DBHelper.GetDataTable(sp_name, obj);
            return dt;
        }

        public object Save_Row_Number(DataTable dtM, bool 타메뉴호출)
        {
            SpInfoCollection sic = new SpInfoCollection();
            SpInfo si;

            si = new SpInfo();

            si.DataValue = dtM;
            si.CompanyID = 회사코드;
            si.UserID = 사용자ID;

            si.SpNameInsert = "UP_CZ_ME_MAP_DEPT_ROW";
            si.SpNameUpdate = "UP_CZ_ME_MAP_DEPT_ROW";
            si.SpParamsInsert = new string[] { "CD_COMPANY", "CD_DEPT", "NO_SORT", "LF_FLAG", "ID_TREE" };
            si.SpParamsUpdate = new string[] { "CD_COMPANY", "CD_DEPT", "NO_SORT", "LF_FLAG", "ID_TREE" };
            sic.Add(si);

            return Global.MainFrame.Save(sic);
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

                si.SpNameInsert = "UP_CZ_ME_MAP_DEPT_IU";
                si.SpNameUpdate = "UP_CZ_ME_MAP_DEPT_IU";
                si.SpNameDelete = "UP_CZ_ME_MAP_DEPT_D";
                si.SpParamsInsert = new string[] { "CD_COMPANY", "CD_DEPT_MTS", "NM_DEPT_MTS", "CD_DEPT", "NM_DEPT", "NO_APPLY", "CD_CC", "DT_START", "DT_END", "ID_TREE", "ID_INSERT" };
                si.SpParamsUpdate = new string[] { "CD_COMPANY", "CD_DEPT_MTS", "NM_DEPT_MTS", "CD_DEPT", "NM_DEPT", "NO_APPLY", "CD_CC", "DT_START", "DT_END", "ID_TREE", "ID_INSERT" };
                si.SpParamsDelete = new string[] { "CD_COMPANY", "CD_DEPT" };
                sic.Add(si);
            }
            
            return Global.MainFrame.Save(sic);
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
