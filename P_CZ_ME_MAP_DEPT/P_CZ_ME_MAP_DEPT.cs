using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;
using Dass.FlexGrid;
using Duzon.Common.BpControls;
using Duzon.Common.Forms;
using Duzon.ERPU;
using Duzon.Common.Forms.Help;
using Duzon.Common.Util;
using Duzon.ERPU.MF;
using Duzon.ERPU.MF.Common;
using Duzon.Windows.Print;
using System.ComponentModel;
using Duzon.Common.Controls;

namespace cz
{
    // **************************************
    // 작성자 : 박승한
    // 작성일 : 2020-06
    // 모듈명 : MTS 연동 - 부서
    // 페이지 : CZ_ME_MAP_DEPT
    // **************************************

    public partial class P_CZ_ME_MAP_DEPT : PageBase
    {
        #region ♥ 멤버필드

        private P_CZ_ME_MAP_DEPT_BIZ _biz = new P_CZ_ME_MAP_DEPT_BIZ();
        bool _타메뉴호출 = false;
        string today = "";

        // 더존 구분 라디오 버튼
        string rdo_dz_idx = "";

        // MTS 사용유무 라디오 버튼
        string rdo_yn_idx = "";
        #endregion

        #region ♥ 초기화

        #region -> 생성자

        public P_CZ_ME_MAP_DEPT()
        {
            InitializeComponent();

            MainGrids = new FlexGrid[] { _flexM };
        }

        #endregion

        #region -> InitLoad

        protected override void InitLoad()
        {
            base.InitLoad();

            // 그리드 생성
            InitGrid();
        }

        #endregion

        #region -> InitGrid

        private void InitGrid()
        {
            //DETAIL
            _flexM.BeginSetting(1, 1, false);

            _flexM.SetCol("S", "선택", 35, true, CheckTypeEnum.Y_N);
            _flexM.SetCol("NO_APPLY", "반영구분", 60, false);
            _flexM.SetCol("CD_DEPT_MTS", "MTS 코드", 60, false);
            _flexM.SetCol("NM_DEPT_MTS", "MTS 부서명", 120, false);
            _flexM.SetCol("STATUS_IDX", "MTS 사용유무", 80, false);
            _flexM.SetCol("CD_DEPT", "부서코드", 60, true);
            _flexM.SetCol("NM_DEPT", "부서명", 120, true);
            _flexM.SetCol("DT_START", "시작일", 80, true);
            _flexM.SetCol("DT_END", "종료일", 80, true);
            _flexM.SetCol("CD_CC", "CC코드", 60, true);
            _flexM.SetCol("NM_CC", "CC명", 120, false);
            _flexM.SetCol("LF_FLAG", "말단여부", 0, false);

            _flexM.SetDummyColumn("S");
            _flexM.Cols.Frozen = 2;

            _flexM.Cols["NO_APPLY"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["CD_DEPT_MTS"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["NM_DEPT_MTS"].TextAlign = TextAlignEnum.LeftCenter;
            _flexM.Cols["STATUS_IDX"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["CD_DEPT"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["NM_DEPT"].TextAlign = TextAlignEnum.LeftCenter;
            _flexM.Cols["DT_START"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["DT_END"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["CD_CC"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.Cols["NM_CC"].TextAlign = TextAlignEnum.LeftCenter;
            _flexM.Cols["LF_FLAG"].TextAlign = TextAlignEnum.CenterCenter;

            _flexM.Cols["DT_START"].Format = _flexM.Cols["DT_START"].EditMask = "####/##/##";
            _flexM.Cols["DT_START"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.SetStringFormatCol("DT_START");
            _flexM.SetNoMaskSaveCol("DT_START");

            _flexM.Cols["DT_END"].Format = _flexM.Cols["DT_END"].EditMask = "####/##/##";
            _flexM.Cols["DT_END"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.SetStringFormatCol("DT_END");
            _flexM.SetNoMaskSaveCol("DT_END");

            _flexM.SettingVersion = "1.0.1.1";// new Random().Next().ToString();
            _flexM.EndSetting(GridStyleEnum.Green, AllowSortingEnum.MultiColumn, SumPositionEnum.None);

            _flexM.SetCodeHelpCol("CD_DEPT", HelpID.P_MA_DEPT_SUB, ShowHelpEnum.Always, new string[] { "CD_DEPT", "NM_DEPT" }, new string[] { "CD_DEPT", "NM_DEPT" }, ResultMode.FastMode);
            _flexM.SetCodeHelpCol("CD_CC", HelpID.P_MA_CC_SUB, ShowHelpEnum.Always, new string[] { "CD_CC", "NM_CC" }, new string[] { "CD_CC", "NM_CC" }, ResultMode.FastMode);

            _flexM.AfterCodeHelp += new AfterCodeHelpEventHandler(_flexM_AfterCodeHelp);
            _flexM.StartEdit += new RowColEventHandler(_flexM_StartEdit);
            _flexM.AfterEdit += new RowColEventHandler(_flexM_AfterEdit);
            _flexM.OwnerDrawCell += new OwnerDrawCellEventHandler(_flexM_OwnerDrawCell);

            _flexM.VerifyNotNull = new string[] { "DT_START" };
        }

        #endregion

        #region -> InitPaint

        protected override void InitPaint()
        {
            base.InitPaint();

            Grant.CanAdd = false;
            Grant.CanPrint = false;

            DateTime time = this.MainFrameInterface.GetDateTimeToday(); // 오늘 날짜

            _flexM.Binding = _biz.GetLineTable();
        }

        #endregion

        #endregion

        #region ♥ 메인버튼 클릭

        #region -> 조회버튼클릭

        public override void OnToolBarSearchButtonClicked(object sender, EventArgs e)
        {
            try
            {
                if (rdoDz2.Checked == true)
                {
                    rdo_dz_idx = "1";
                }
                else if (rdoDz3.Checked == true)
                {
                    rdo_dz_idx = "2";
                }
                else
                {
                    rdo_dz_idx = "";
                }

                if (rdoYn2.Checked == true)
                {
                    rdo_yn_idx = "1";
                }
                else if (rdoYn3.Checked == true)
                {
                    rdo_yn_idx = "0";
                }
                else
                {
                    rdo_yn_idx = "";
                }

                _flexM.Binding = _biz.GetLineTable();

                object[] Params = new object[4];
                Params[0] = LoginInfo.CompanyCode;
                Params[1] = "DUZON";
                Params[2] = rdo_dz_idx;
                Params[3] = rdo_yn_idx;

                DataSet ds = _biz.Search_M(Params);
                _flexM.Binding = ds.Tables[0];
            }
            catch (Exception ex)
            {
                this.MsgEnd(ex);
            }
        }

        #endregion

        #region -> 저장버튼클릭

        public override void OnToolBarSaveButtonClicked(object sender, EventArgs e)
        {  
            try
            {
                if (!BeforeSaveChk())
                    return;

                if (SaveData())
                {
                    SaveData_Row();

                    ShowMessage(PageResultMode.SaveGood);
                    {
                        object[] Params = new object[4];
                        Params[0] = LoginInfo.CompanyCode;
                        Params[1] = "DUZON";
                        Params[2] = rdo_dz_idx;
                        Params[3] = rdo_yn_idx;

                        DataSet ds = _biz.Search_M(Params);
                        _flexM.Binding = ds.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                
                MsgEnd(ex);
            }
        }

        private void SaveData_Row()
        {
            object obj = null;

            if (_flexM.HasNormalRow)
            {
                DataTable dt = _flexM.DataTable;

                dt.AcceptChanges();

                foreach (DataRow dr in dt.Rows)
                {
                    dr.SetAdded();
                }

                obj = _biz.Save_Row_Number(dt, _타메뉴호출);
            }
        }

        protected override bool SaveData()
        {
            object obj = null;

            if (_flexM.HasNormalRow)
            {
                obj = _biz.Save(_flexM.GetChanges(), _타메뉴호출);
            }

            ResultData[] result = (ResultData[])obj;

            return true;
        }

        protected bool BeforeSaveChk()
        {

            if (!_flexM.HasNormalRow)
            {
                ShowMessage("저장할 내용이 없습니다.");
                return false;
            }

            if (!_flexM.Verify())
                return false;

            return true;
        }

        #endregion

        #region -> 삭제버튼클릭

        public override void OnToolBarDeleteButtonClicked(object sender, EventArgs e)
        {
            try
            {
                if (!BeforeDelete())
                    return;

                DialogResult Result = ShowMessage(공통메세지.자료를삭제하시겠습니까, PageName);

                if (Result != DialogResult.Yes)
                    return;

                if (!_flexM.HasNormalRow)
                    return;

                if (_flexM.GetCheckedRows("S") == null)
                {
                    ShowMessage("삭제할 자료가 선택 되지 않았습니다.");
                    return;
                }

                for (int i = _flexM.Rows.Count - 1; i >= _flexM.Rows.Fixed; i--)
                {
                    if (_flexM[i, "S"].ToString().Equals("Y"))
                    {
                        _flexM[i, "CD_DEPT"] = "";
                        _flexM[i, "NM_DEPT"] = "";
                        _flexM[i, "CD_CC"] = "";
                        _flexM[i, "NM_CC"] = "";
                        _flexM[i, "NO_APPLY"] = "삭제";
                        //_flexM.RemoveItem(i);
                    }
                }
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }
        #endregion

        #region -> 추가버튼클릭

        public override void OnToolBarAddButtonClicked(object sender, EventArgs e)
        {
            try
            {
                _flexM.Rows.Add();
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }

        }

        #endregion

        #endregion

        #region ♥ 기타 이벤트

        private void btnMts연동_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_flexM.HasNormalRow)
                    return;

                DataRow[] ldrchk = _flexM.DataTable.Select("S = 'Y'", "", DataViewRowState.CurrentRows);

                object[] Params = new object[3];
                Params[0] = LoginInfo.CompanyCode;
                Params[1] = "DUZON_MAP";

                DataSet ds = _biz.Search_M(Params);

                _flexM.Redraw = false;

                if (ldrchk == null || ldrchk.Length == 0)
                {
                    ShowMessage(공통메세지.선택된자료가없습니다);
                    return;
                }
                else
                {
                    for (int i = 0; i < _flexM.Rows.Count; i++)
                    {
                        if (_flexM[i, "S"].ToString().Equals("Y") && _flexM[i, "NO_APPLY"].ToString().Equals("미반영"))
                        {
                            foreach (DataRow r in ds.Tables[0].Rows)
                            {
                                if (_flexM[i, "CD_DEPT_MTS"].ToString() == r["CD_DEPT"].ToString())
                                {
                                    _flexM[i, "CD_DEPT"] = r["CD_DEPT"].ToString();
                                    _flexM[i, "NM_DEPT"] = r["NM_DEPT"].ToString();
                                    _flexM[i, "CD_CC"] = r["CD_CC"].ToString();
                                    _flexM[i, "NM_CC"] = r["NM_CC"].ToString();
                                    _flexM[i, "NO_APPLY"] = "맵핑완료";
                                }
                                //if (ldrchk != null && ldrchk.Length > 0)
                                //cd_dept_mst = cd_dept_mst + ":" + ldrchk[i]["CD_DEPT_MTS"].ToString();
                            }

                            if (_flexM[i, "CD_DEPT"].ToString().Length.Equals(0))
                            {
                                _flexM[i, "CD_DEPT"] = _flexM[i, "CD_DEPT_MTS"].ToString();
                                _flexM[i, "NM_DEPT"] = _flexM[i, "NM_DEPT_MTS"].ToString();
                                _flexM[i, "DT_START"] = today;
                                _flexM[i, "NO_APPLY"] = "신규생성";
                            }
                        }
                    }
                }

                _flexM.Redraw = true;

            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }

        #endregion

        #region ♥ 그리드 이벤트

        void _flexM_StartEdit(object sender, RowColEventArgs e)
        {
            try
            {
                if (!_flexM.AllowEditing)
                    return;

                switch (_flexM.Cols[e.Col].Name)
                {
                    case "S":
                        break;
                }
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }

        void _flexM_AfterEdit(object sender, RowColEventArgs e)
        {
            try
            {
                switch (_flexM.Cols[e.Col].Name)
                {
                    case "NM_DEPT":
                        if (D.GetString(_flexM[e.Row, e.Col]) == "")
                        {
                            _flexM[e.Row, "CD_DEPT"] = "";
                        }
                        _flexM[e.Row, "NO_APPLY"] = "수정";
                        break;
                    case "DT_START":
                        _flexM[e.Row, "NO_APPLY"] = "수정";
                        break;
                    case "CD_DEPT":
                        if (D.GetString(_flexM[e.Row, e.Col]) == "")
                        {
                            _flexM[e.Row, "NO_APPLY"] = "수정";
                        }
                        break;
                    case "CD_CC":
                        if (D.GetString(_flexM[e.Row, e.Col]) == "")
                        {
                            _flexM[e.Row, "NO_APPLY"] = "수정";
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }

        void _flexM_AfterCodeHelp(object sender, AfterCodeHelpEventArgs e)
        {
            try
            {
                DataTable dt = e.Result.DataTable;        //멀티 or 단일 도움창에서 선택된 데이터들을 Table형태로 가져온다
                //설정   

                string oldValue = D.GetString(_flexM.GetData(e.Row, e.Col));//수정 전에 입력되어있던 값
                string newValue = e.Result.CodeValue;//수정한 값

                if (oldValue == newValue) return;

                switch (_flexM.Cols[e.Col].Name)
                {
                    case "CD_CC":
                    case "CD_DEPT":
                        _flexM[e.Row, "no_apply"] = "수정";
                        break;
                }
            }
            catch (Exception ex)
            {
                this.MsgEnd(ex);
            }
        }

        private void _flexM_OwnerDrawCell(object sender, OwnerDrawCellEventArgs e)
        {
            CellRange rg;

            if (!_flexM.HasNormalRow)
                return;

            if (e.Row < _flexM.Rows.Fixed || e.Col < _flexM.Cols.Fixed)
                return;

            if ((D.GetString(_flexM[e.Row, "NM_DEPT_MTS"]) != D.GetString(_flexM[e.Row, "NM_DEPT"])) && D.GetString(_flexM[e.Row, "NM_DEPT"]) != "")
            {
                rg = _flexM.GetCellRange(e.Row, "NM_DEPT_MTS");
                rg.StyleNew.ForeColor = System.Drawing.Color.Blue;

                rg = _flexM.GetCellRange(e.Row, "NM_DEPT");
                rg.StyleNew.ForeColor = System.Drawing.Color.Blue;
            }

            if (D.GetString(_flexM[e.Row, "NO_APPLY"]) == "미반영")
            {
                CellStyle csCellstyle = _flexM.Styles.Add("CellStyle");
                csCellstyle.BackColor = System.Drawing.Color.LightGray;

                _flexM.Rows[e.Row].Style = csCellstyle;
            }
        }

        #endregion

        #region ♥ 기타 Property
        string ServerKey { get { return Global.MainFrame.ServerKeyCommon.ToUpper(); } }
        #endregion
    }
}