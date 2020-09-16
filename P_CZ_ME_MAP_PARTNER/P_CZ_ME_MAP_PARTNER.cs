using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;
using Dass.FlexGrid;
using Duzon.Common.BpControls;
using Duzon.Common.Forms;
using Duzon.Common.Forms.Help;
using Duzon.Common.Util;
using Duzon.ERPU;
using Duzon.ERPU.MF;
using Duzon.ERPU.MF.Common;
using Duzon.Windows.Print;

namespace cz
{
    // **************************************
    // 작성자 : 박승한
    // 작성일 : 2020-06
    // 모듈명 : MTS 연동 - 거래처
    // 페이지 : CZ_ME_MAP_PARTNER
    // **************************************

    public partial class P_CZ_ME_MAP_PARTNER : PageBase
    {
        #region ♥ 멤버필드

        private P_CZ_ME_MAP_PARTNER_BIZ _biz = new P_CZ_ME_MAP_PARTNER_BIZ();
        bool _타메뉴호출 = false;
        string tab_index = "";
        string rdo_index = "";
        string rdo_yn = "";
        int show_cell = 0;

        #endregion

        #region ♥ 초기화

        #region -> 생성자

        public P_CZ_ME_MAP_PARTNER()
        {
            InitializeComponent();

            MainGrids = new FlexGrid[] { _flexM_T1 };
            _flexM_T1.DetailGrids = new FlexGrid[] { _flexD_T1 };
        }

        #endregion

        #region -> InitLoad

        protected override void InitLoad()
        {
            base.InitLoad();

            InitGrid();
        }

        #endregion

        #region -> InitGrid

        private void InitGrid()
        {
                //탭 1번 상단 그리드
                _flexM_T1.BeginSetting(1, 1, false);

                _flexM_T1.SetCol("S", "선택", 35, true, CheckTypeEnum.Y_N);
                _flexM_T1.SetCol("no_apply", "반영구분", 60, false);
                //MTS
                _flexM_T1.SetCol("biz_id", "ID", 40, false);
                _flexM_T1.SetCol("biz_name", "사업자명", 130, false);
                _flexM_T1.SetCol("biz_name2", "거래처명", 130, false);
                _flexM_T1.SetCol("biz_no", "사업자번호", 100, false);
                //DOUZON
                _flexM_T1.SetCol("cd_partner", "더존코드", 80, true);
                _flexM_T1.SetCol("ln_partner", "더존명", 130, false);
                _flexM_T1.SetCol("adress", "주소", 150, false);
                _flexM_T1.SetCol("mgr_name", "대표자", 80, false);
                //_flexM_T1.SetCol("DZ_DTS_UPDATE", "대행사구분", 100, false);
                _flexM_T1.SetCol("biz_type", "업종", 80, false);
                _flexM_T1.SetCol("biz_type2", "종목", 100, false);
                _flexM_T1.SetCol("bank", "은행", 60, false);
                //_flexM_T1.SetCol("bank", "은행계좌번호", 100, false);
                _flexM_T1.SetCol("account", "은행계좌번호", 120, false);
                //_flexM_T1.SetCol("ACCOUNT", "매입채무지급", 80, false);
                //_flexM_T1.SetCol("DZ_NM_USER1", "매출채권입금", 80, false);
                _flexM_T1.SetCol("grade", "신용등급", 60, false);
                _flexM_T1.SetCol("nm_acid", "매입채무지급", 90, false);
                _flexM_T1.SetCol("nm_acid2", "매출채권입금", 90, false);
                _flexM_T1.SetCol("flag", "사용여부", 60, false);
                _flexM_T1.SetCol("registdate", "등록일", 80, false);
                _flexM_T1.SetCol("updatedate", "수정일", 80, false);
                _flexM_T1.SetCol("nm_ceo", "대표자명", 0, false);

                _flexM_T1.SetDummyColumn("S");
                _flexM_T1.Cols.Frozen = 1;

                _flexM_T1.Cols["no_apply"].TextAlign = TextAlignEnum.CenterCenter;
                _flexM_T1.Cols["biz_id"].TextAlign = TextAlignEnum.CenterCenter;
                //_flexM_T1.Cols["biz_name"].TextAlign = TextAlignEnum.CenterCenter;
                //_flexM_T1.Cols["biz_name2"].TextAlign = TextAlignEnum.CenterCenter;
                _flexM_T1.Cols["biz_no"].Format = _flexM_T1.Cols["biz_no"].EditMask = "###-##-#####";
                _flexM_T1.Cols["biz_no"].TextAlign = TextAlignEnum.CenterCenter;
                _flexM_T1.SetStringFormatCol("biz_no");
                _flexM_T1.SetNoMaskSaveCol("biz_no");

                _flexM_T1.Cols["cd_partner"].TextAlign = TextAlignEnum.CenterCenter;
                //_flexM_T1.Cols["ln_partner"].TextAlign = TextAlignEnum.CenterCenter;
                _flexM_T1.Cols["adress"].TextAlign = TextAlignEnum.CenterCenter;
                _flexM_T1.Cols["mgr_name"].TextAlign = TextAlignEnum.CenterCenter;
                //_flexM_T1.Cols["biz_type"].TextAlign = TextAlignEnum.CenterCenter;
                //_flexM_T1.Cols["biz_type2"].TextAlign = TextAlignEnum.CenterCenter;
                _flexM_T1.Cols["bank"].TextAlign = TextAlignEnum.CenterCenter;
                //_flexM_T1.Cols["account"].TextAlign = TextAlignEnum.CenterCenter;
                _flexM_T1.Cols["grade"].TextAlign = TextAlignEnum.CenterCenter;
                _flexM_T1.Cols["nm_acid"].TextAlign = TextAlignEnum.CenterCenter;
                _flexM_T1.Cols["nm_acid2"].TextAlign = TextAlignEnum.CenterCenter;
                _flexM_T1.Cols["flag"].TextAlign = TextAlignEnum.CenterCenter;
                //_flexM_T1.Cols["registdate"].TextAlign = TextAlignEnum.CenterCenter;
                //_flexM_T1.Cols["updatedate"].TextAlign = TextAlignEnum.CenterCenter;

                _flexM_T1.SetCodeHelpCol("cd_partner", HelpID.P_MA_PARTNER_SUB, ShowHelpEnum.Always, new string[] { "cd_partner", "ln_partner" }, new string[] { "cd_partner", "ln_partner" }, ResultMode.FastMode);

                _flexM_T1.VerifyNotNull = new string[] { "cd_partner", "ln_partner" };

                _flexM_T1.SettingVersion = "1.0.1.3";
                _flexM_T1.EndSetting(GridStyleEnum.Green, AllowSortingEnum.MultiColumn, SumPositionEnum.None);

                _flexM_T1.OwnerDrawCell += new OwnerDrawCellEventHandler(_flexM_T1_OwnerDrawCell);
                _flexM_T1.AfterRowChange += new RangeEventHandler(_flexM_T1_AfterRowChange);
                _flexM_T1.StartEdit += new RowColEventHandler(_flexM_T1_StartEdit);
                _flexM_T1.AfterCodeHelp += new AfterCodeHelpEventHandler(_flexM_T1_AfterCodeHelp);

                //탭 1번 하단 그리드
                _flexD_T1.BeginSetting(1, 1, false);

                _flexD_T1.SetCol("corpflag", "구분", 60, false);
                _flexD_T1.SetCol("corpid", "ID", 40, false);
                _flexD_T1.SetCol("corpname", "명칭", 130, false);
                _flexD_T1.SetCol("trade_type", "계산서발행양식", 100, false);
                _flexD_T1.SetCol("tax_type", "세금계산서기준", 100, false);
                _flexD_T1.SetCol("status", "사용여부", 60, false);

                _flexD_T1.Cols["corpflag"].TextAlign = TextAlignEnum.CenterCenter;
                _flexD_T1.Cols["corpid"].TextAlign = TextAlignEnum.CenterCenter;
                _flexD_T1.Cols["trade_type"].TextAlign = TextAlignEnum.CenterCenter;
                _flexD_T1.Cols["tax_type"].TextAlign = TextAlignEnum.CenterCenter;
                _flexD_T1.Cols["status"].TextAlign = TextAlignEnum.CenterCenter;

                _flexD_T1.SettingVersion = "1.0.1.0";
                _flexD_T1.EndSetting(GridStyleEnum.Green, AllowSortingEnum.MultiColumn, SumPositionEnum.None);

                //탭 2번 그리드
                _flexM_T2.BeginSetting(1, 1, false);

                _flexM_T2.SetCol("corpflag", "구분", 60, false);
                _flexM_T2.SetCol("corpid", "ID", 40, false);
                _flexM_T2.SetCol("corpname", "명칭", 130, false);
                _flexM_T2.SetCol("trade_type", "계산서발행양식", 100, false);
                _flexM_T2.SetCol("tax_type", "세금계산서기준", 100, false);
                _flexM_T2.SetCol("status", "사용여부", 60, false);
                _flexM_T2.SetCol("biz_id", "사업자ID", 60, false);
                _flexM_T2.SetCol("biz_name", "사업자명", 130, false);

                _flexM_T2.SetCol("me_type", "매체구분", 80, true);
                _flexM_T2.SetCol("me_attr", "매체속성", 100, true);
                _flexM_T2.SetCol("me_sumcode", "합산기준코드", 100, true);
                _flexM_T2.SetCol("nm_sumcode", "합산기준매체명", 150, true);

                _flexM_T2.Cols["corpflag"].TextAlign = TextAlignEnum.CenterCenter;
                _flexM_T2.Cols["corpid"].TextAlign = TextAlignEnum.CenterCenter;
                _flexM_T2.Cols["trade_type"].TextAlign = TextAlignEnum.CenterCenter;
                _flexM_T2.Cols["tax_type"].TextAlign = TextAlignEnum.CenterCenter;
                _flexM_T2.Cols["status"].TextAlign = TextAlignEnum.CenterCenter;
                _flexM_T2.Cols["biz_id"].TextAlign = TextAlignEnum.CenterCenter;

                _flexM_T2.Cols["me_type"].TextAlign = TextAlignEnum.CenterCenter;
                _flexM_T2.Cols["me_attr"].TextAlign = TextAlignEnum.CenterCenter;

                _flexM_T2.SetDummyColumn("S");

                _flexM_T2.SetCodeHelpCol("me_sumcode", "H_CZ_HELP01", ShowHelpEnum.Always, new string[] { "me_sumcode", "nm_sumcode" }, new string[] { "CD_PARTNER", "biz_name" });

                _flexM_T2.SettingVersion = "1.0.1.1";
                _flexM_T2.EndSetting(GridStyleEnum.Green, AllowSortingEnum.MultiColumn, SumPositionEnum.None);

                _flexM_T2.StartEdit += new RowColEventHandler(_flexM_T2_StartEdit);
                _flexM_T2.BeforeCodeHelp += new BeforeCodeHelpEventHandler(_flexM_T2_BeforeCodeHelp);
                _flexM_T2.AfterCodeHelp += new AfterCodeHelpEventHandler(_flexM_T2_AfterCodeHelp);

                //탭 3번 그리드
                _flexM_T3.BeginSetting(1, 1, false);

                _flexM_T3.SetCol("corpflag", "구분", 60, false);
                _flexM_T3.SetCol("corpid", "ID", 40, false);
                _flexM_T3.SetCol("corpname", "명칭", 130, false);
                _flexM_T3.SetCol("trade_type", "계산서발행양식", 100, false);
                _flexM_T3.SetCol("tax_type", "세금계산서기준", 100, false);
                _flexM_T3.SetCol("status", "사용여부", 60, false);
                _flexM_T3.SetCol("biz_id", "사업자ID", 60, false);
                _flexM_T3.SetCol("biz_name", "사업자명", 130, false);

                _flexM_T3.Cols["corpflag"].TextAlign = TextAlignEnum.CenterCenter;
                _flexM_T3.Cols["corpid"].TextAlign = TextAlignEnum.CenterCenter;
                _flexM_T3.Cols["trade_type"].TextAlign = TextAlignEnum.CenterCenter;
                _flexM_T3.Cols["tax_type"].TextAlign = TextAlignEnum.CenterCenter;
                _flexM_T3.Cols["status"].TextAlign = TextAlignEnum.CenterCenter;
                _flexM_T3.Cols["biz_id"].TextAlign = TextAlignEnum.CenterCenter;

                _flexM_T3.SettingVersion = "1.0.0.8";
                _flexM_T3.EndSetting(GridStyleEnum.Green, AllowSortingEnum.MultiColumn, SumPositionEnum.None);

                //탭 4번 그리드
                _flexM_T4.BeginSetting(1, 1, false);

                _flexM_T4.SetCol("corpflag", "구분", 60, false);
                _flexM_T4.SetCol("corpid", "ID", 40, false);
                _flexM_T4.SetCol("corpname", "명칭", 130, false);
                _flexM_T4.SetCol("trade_type", "계산서발행양식", 100, false);
                _flexM_T4.SetCol("tax_type", "세금계산서기준", 100, false);
                _flexM_T4.SetCol("status", "사용여부", 60, false);
                _flexM_T4.SetCol("biz_id", "사업자ID", 60, false);
                _flexM_T4.SetCol("biz_name", "사업자명", 130, false);

                _flexM_T4.Cols["corpflag"].TextAlign = TextAlignEnum.CenterCenter;
                _flexM_T4.Cols["corpid"].TextAlign = TextAlignEnum.CenterCenter;
                _flexM_T4.Cols["trade_type"].TextAlign = TextAlignEnum.CenterCenter;
                _flexM_T4.Cols["tax_type"].TextAlign = TextAlignEnum.CenterCenter;
                _flexM_T4.Cols["status"].TextAlign = TextAlignEnum.CenterCenter;
                _flexM_T4.Cols["biz_id"].TextAlign = TextAlignEnum.CenterCenter;

                _flexM_T4.SettingVersion = "1.0.0.8";
                _flexM_T4.EndSetting(GridStyleEnum.Green, AllowSortingEnum.MultiColumn, SumPositionEnum.None);

                //탭 5번 그리드
                _flexM_T5.BeginSetting(1, 1, false);

                _flexM_T5.SetCol("corpflag", "구분", 60, false);
                _flexM_T5.SetCol("corpid", "ID", 40, false);
                _flexM_T5.SetCol("corpname", "명칭", 130, false);
                _flexM_T5.SetCol("trade_type", "계산서발행양식", 100, false);
                _flexM_T5.SetCol("tax_type", "세금계산서기준", 100, false);
                _flexM_T5.SetCol("status", "사용여부", 60, false);
                _flexM_T5.SetCol("biz_id", "사업자ID", 60, false);
                _flexM_T5.SetCol("biz_name", "사업자명", 130, false);

                _flexM_T5.Cols["corpflag"].TextAlign = TextAlignEnum.CenterCenter;
                _flexM_T5.Cols["corpid"].TextAlign = TextAlignEnum.CenterCenter;
                _flexM_T5.Cols["trade_type"].TextAlign = TextAlignEnum.CenterCenter;
                _flexM_T5.Cols["tax_type"].TextAlign = TextAlignEnum.CenterCenter;
                _flexM_T5.Cols["status"].TextAlign = TextAlignEnum.CenterCenter;
                _flexM_T5.Cols["biz_id"].TextAlign = TextAlignEnum.CenterCenter;

                _flexM_T5.SettingVersion = "1.0.0.8";
                _flexM_T5.EndSetting(GridStyleEnum.Green, AllowSortingEnum.MultiColumn, SumPositionEnum.None);
        }

        #endregion

        #region -> InitPaint

        protected override void InitPaint()
        {
            base.InitPaint();

            // 추가할 필요가 없으므로 false 처리
            Grant.CanAdd = false;

            // 사업자 정보 탭 일 때 매체 조회조건을 enabled false 시킨다.
            txt명.Enabled = false;

            조회조건체크(true);

            // 처음 페이지 열면 탭이 사업자 정보이므로
            tab_index = "0";

            // 콤보박스 셋팅 부분
            _flexM_T1.SetDataMap("grade", MA.GetCode("CZ_ME_C002"), "CODE", "NAME");
            _flexD_T1.SetDataMap("corpflag", MA.GetCode("CZ_ME_C001"), "CODE", "NAME");
            _flexM_T2.SetDataMap("corpflag", MA.GetCode("CZ_ME_C001"), "CODE", "NAME");
            _flexM_T3.SetDataMap("corpflag", MA.GetCode("CZ_ME_C001"), "CODE", "NAME");
            _flexM_T4.SetDataMap("corpflag", MA.GetCode("CZ_ME_C001"), "CODE", "NAME");
            _flexM_T5.SetDataMap("corpflag", MA.GetCode("CZ_ME_C001"), "CODE", "NAME");

            //DataTable dt매체구분 = _biz.Get매체구분();
            //_flexM_T2.SetDataMap("cd_mediagr", dt매체구분.Copy(), "CODE", "NAME");
            _flexM_T2.SetDataMap("me_type", MA.GetCode("CZ_ME_C007", true), "CODE", "NAME");
            _flexM_T2.SetDataMap("me_attr", MA.GetCode("CZ_ME_C006", true), "CODE", "NAME");

            this.DataChanged += new EventHandler(Page_DataChanged);

            if (rdoDz2.Checked == true)
            {
                rdo_index = "1";
            }
            else if (rdoDz3.Checked == true)
            {
                rdo_index = "2";
            }
            else
            {
                rdo_index = "0";
            }

            if (rdoYn2.Checked == true)
            {
                rdo_yn = "Y";
            }
            else if (rdoYn3.Checked == true)
            {
                rdo_yn = "N";
            }
            else
            {
                rdo_yn = "";
            }
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
                    rdo_index = "1";
                }
                else if (rdoDz3.Checked == true)
                {
                    rdo_index = "2";
                }
                else
                {
                    rdo_index = "0";
                }

                if (rdoYn2.Checked == true)
                {
                    rdo_yn = "Y";
                }
                else if (rdoYn3.Checked == true)
                {
                    rdo_yn = "N";
                }
                else
                {
                    rdo_yn = "";
                }

                object[] Params = new object[6];
                Params[0] = LoginInfo.CompanyCode;

                switch (tab_index)
                {
                    case "0":

                        Params[1] = "MT1";
                        Params[2] = "";
                        Params[3] = txt사업자.Text;
                        Params[4] = rdo_index;
                        Params[5] = rdo_yn;

                        DataSet ds_mt1 = _biz.Search_T1(Params);

                        _flexM_T1.Binding = ds_mt1.Tables[0];
                        SetToolBarButtonState(true, false, false, false, true);

                        break;

                    case "1":

                        Params[1] = "MT2";
                        Params[2] = txt사업자.Text;
                        Params[3] = "4";
                        Params[4] = txt명.Text;
                        Params[5] = rdo_yn;

                        DataSet ds_mt2 = _biz.Search_T2(Params);

                        _flexM_T2.Binding = ds_mt2.Tables[0];

                        _flexM_T2.SetDataMap("me_type", MA.GetCode("CZ_ME_C007", true), "CODE", "NAME");

                        SetToolBarButtonState(true, false, false, false, true);
                        break;

                    case "2":

                        Params[1] = "MT2";
                        Params[2] = txt사업자.Text;
                        Params[3] = "2";
                        Params[4] = txt명.Text;
                        Params[5] = rdo_yn;

                        DataSet ds_mt3 = _biz.Search_T2(Params);

                        _flexM_T3.Binding = ds_mt3.Tables[0];

                        break;

                    case "3":

                        Params[1] = "MT2";
                        Params[2] = txt사업자.Text;
                        Params[3] = "3";
                        Params[4] = txt명.Text;
                        Params[5] = rdo_yn;

                        DataSet ds_mt4 = _biz.Search_T2(Params);

                        _flexM_T4.Binding = ds_mt4.Tables[0];

                        break;

                    case "4":

                        Params[1] = "MT2";
                        Params[2] = txt사업자.Text;
                        Params[3] = "1";
                        Params[4] = txt명.Text;
                        Params[5] = rdo_yn;

                        DataSet ds_mt5 = _biz.Search_T2(Params);

                        _flexM_T5.Binding = ds_mt5.Tables[0];

                        break;
                }
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
                switch (tab_index)
                {
                    case "0":

                        if (!BeforeSaveChk())
                            return;

                        if (SaveData())
                        {
                            ShowMessage(PageResultMode.SaveGood);
                            {

                                for (int i = 0; i < _flexM_T1.Rows.Count; i++)
                                {
                                    if (_flexM_T1[i, "S"].ToString().Equals("Y"))
                                    {
                                        show_cell = _flexM_T1.Row;
                                    }
                                }

                                object[] Params = new object[6];
                                Params[0] = LoginInfo.CompanyCode;
                                Params[1] = "MT1";
                                Params[2] = "";
                                Params[3] = txt사업자.Text;
                                Params[4] = rdo_index;
                                Params[5] = rdo_yn;

                                DataSet ds_mt1 = _biz.Search_T1(Params);

                                _flexM_T1.Binding = ds_mt1.Tables[0];

                                _flexM_T1.ShowCell(show_cell, 1);

                                SetToolBarButtonState(true, false, false, false, true);

                            }
                        }

                        break;

                    case "1":

                        if (!BeforeSaveChk2())
                            return;

                        if (SaveData())
                        {
                            ShowMessage(PageResultMode.SaveGood);
                            {
                                object[] Params = new object[6];
                                Params[0] = LoginInfo.CompanyCode;
                                Params[1] = "MT2";
                                Params[2] = txt사업자.Text;
                                Params[3] = "4";
                                Params[4] = txt명.Text;
                                Params[5] = rdo_yn;

                                DataSet ds_mt2 = _biz.Search_T2(Params);

                                _flexM_T2.Binding = ds_mt2.Tables[0];
                            }
                        }

                        break;
                    case "2":
                    case "3":
                    case "4":
                        break;
                }

            }
            catch (Exception ex)
            {                
                MsgEnd(ex);
            }
            
        }

        protected override bool SaveData()
        {

            object obj = null;

            switch (tab_index)
            {
                case "0":
                    if (_flexM_T1.HasNormalRow)
                    {
                        //for (int i = _flexM_T1.Rows.Fixed; i < _flexM_T1.Rows.Count; i++)
                        //{
                        //     if (_flexM_T1[i, "S"].ToString().Equals("Y"))
                        //    {
                        //        if (D.GetString(_flexM_T1.Rows[i]["cd_partner"]).Length == 0 || (D.GetString(_flexM_T1.Rows[i]["ln_partner"]).Length == 0))
                        //        {
                        //            ShowMessage((i) + "행에 더존코드, 더존명이 입력 되지 않았습니다.");
                        //            return false;
                        //        }
                        //    }
                        //}
                        obj = _biz.Save(_flexM_T1.GetChanges(), _타메뉴호출);
                    }
                    break;
                case "1":
                    if (_flexM_T2.HasNormalRow)
                    {
                        obj = _biz.Save_t2(_flexM_T2.GetChanges(), _타메뉴호출);
                    }
                    break;
                case "2":
                case "3":
                case "4":
                    break;
            }
            return true;
        }

        protected bool BeforeSaveChk()
        {
            if (!_flexM_T1.HasNormalRow)
            {
                ShowMessage("저장할 내용이 없습니다.");
                return false;
            }

            if (!_flexM_T1.Verify())
                return false;

            //if (!_flexD_T1.HasNormalRow)
            //    return false;

            //if (!_flexD_T1.Verify())
            //    return false;

            return true;
        }

        protected bool BeforeSaveChk2()
        {
            if (!_flexM_T2.HasNormalRow)
            {
                ShowMessage("저장할 내용이 없습니다.");
                return false;
            }

            if (!_flexM_T2.Verify())
                return false;

            return true;
        }
        #endregion

        #region -> 삭제버튼클릭

        public override void OnToolBarDeleteButtonClicked(object sender, EventArgs e)
        {
           /*
            try
            {
                if (!BeforeDelete())
                    return;

                DialogResult Result = ShowMessage(공통메세지.자료를삭제하시겠습니까, PageName);

                if (Result != DialogResult.Yes)
                    return;

                if (!_flexM_T1.HasNormalRow)
                    return;

                if (_flexM_T1.GetCheckedRows("S") == null)
                {
                    ShowMessage("삭제할 자료가 선택 되지 않았습니다.");
                    return;
                }
                for (int i = _flexM_T1.Rows.Count - 1; i >= _flexM_T1.Rows.Fixed; i--)
                {
                    if (_flexM_T1[i, "S"].ToString().Equals("Y"))
                    {
                        _flexM_T1[i, "cd_partner"] = "";
                        _flexM_T1[i, "ln_partner"] = "";
                        _flexM_T1[i, "no_apply"] = "삭제";
                    }
                }
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
            */
        }
        #endregion

        #region -> 추가버튼클릭

        // 추가버튼 사용하지 않음
        public override void OnToolBarAddButtonClicked(object sender, EventArgs e)
        {
            try
            {
                _flexM_T1.Rows.Add();
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
                if (!_flexM_T1.HasNormalRow)
                    return;

                DataRow[] ldrchk = _flexM_T1.DataTable.Select("S = 'Y'", "", DataViewRowState.CurrentRows);

                object[] Params = new object[2];
                Params[0] = LoginInfo.CompanyCode;
                Params[1] = "DUZON_MAP";

                DataSet ds = _biz.Search_T1(Params);

                _flexM_T1.Redraw = false;

                if (ldrchk == null || ldrchk.Length == 0)
                {
                    ShowMessage(공통메세지.선택된자료가없습니다);
                    return;
                }

                else
                {
                    for (int i = 0; i < _flexM_T1.Rows.Count; i++)
                    {
                        if (_flexM_T1[i, "biz_no"].ToString().Length >= 10 && _flexM_T1[i, "S"].ToString().Equals("Y") && _flexM_T1[i, "no_apply"].ToString().Equals("미반영"))
                        {
                            
                            //20200722 조인 기준을 사업자번호로 변경으로 수정
                            _flexM_T1[i, "cd_partner"] = _flexM_T1[i, "biz_no"];
                            _flexM_T1[i, "ln_partner"] = _flexM_T1[i, "biz_name"];
                            _flexM_T1[i, "no_apply"] = "맵핑완료";

                            /* 20200722 조인 기준을 사업자번호로 변경으로 수정
                             _flexM_T1[i, "cd_partner"] = _flexM_T1[i, "cd_partner_map"];
                             _flexM_T1[i, "ln_partner"] = _flexM_T1[i, "ln_partner_map"];
                             _flexM_T1[i, "no_apply"] = "맵핑완료";
                             */
                            
                            //if (ldrchk != null && ldrchk.Length > 0)
                            //cd_dept_mst = cd_dept_mst + ":" + ldrchk[i]["CD_DEPT_MTS"].ToString();
                        }
                    }
                }

                _flexM_T1.Redraw = true;

            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }

        private void tab거래처_SelectedIndexChanged(object sender, EventArgs e)
        {
            tab_index = tab거래처.SelectedIndex.ToString();

            switch (tab거래처.SelectedIndex.ToString())
            {
                case "0":
                    txt명.Enabled = false;
                    조회조건체크(true);

                    MainGrids = new FlexGrid[] { _flexM_T1 };
                    _flexM_T1.DetailGrids = new FlexGrid[] { _flexD_T1 };

                    SetToolBarButtonState(true, false, true, false, true);
                    break;

                case "1":
                    lbl명.Text = "매체명";
                    txt명.Enabled = true;
                    조회조건체크(false);

                    MainGrids = new FlexGrid[] { _flexM_T2 };

                    SetToolBarButtonState(true, false, false, false, true);
                    break;

                case "2":
                    lbl명.Text = "대행사명";
                    txt명.Enabled = true;
                    조회조건체크(false);

                    SetToolBarButtonState(true, false, false, false, true);
                    break;

                case "3":
                    lbl명.Text = "렙사명";
                    txt명.Enabled = true;
                    조회조건체크(false);

                    SetToolBarButtonState(true, false, false, false, true);
                    break;

                case "4":
                    lbl명.Text = "광고주명";
                    txt명.Enabled = true;
                    조회조건체크(false);

                    SetToolBarButtonState(true, false, false, false, true);
                    break;
            }
        }

        #endregion

        #region ♥ 그리드 이벤트


        void Page_DataChanged(object sender, EventArgs e)
        {
            try
            {
                switch (tab거래처.SelectedIndex.ToString())
                {
                    case "0":
                        SetToolBarButtonState(true, false, true, true, true);
                        break;
                    case "1":
                        SetToolBarButtonState(true, false, false, true, true);
                        break;
                    case "2":
                    case "3":
                    case "4":
                        SetToolBarButtonState(true, false, false, false, true);
                        break;
                }
            }
            catch (Exception ex)
            {
                this.MsgEnd(ex);
            }
        }


        // 탭 1번 사업자 정보 이벤트
        void _flexM_T1_AfterRowChange(object sender, RangeEventArgs e)
        {
            try
            {
                object[] Params = new object[3];
                Params[0] = LoginInfo.CompanyCode;
                Params[1] = "DT1";
                Params[2] = D.GetString(_flexM_T1["biz_id"]);

                DataSet ds = _biz.Search_T1(Params);

                _flexD_T1.Binding = ds.Tables[0];
            }
            catch (Exception ex)
            {
                this.MsgEnd(ex);
            }
        }

        void _flexM_T1_StartEdit(object sender, RowColEventArgs e)
        {
            try
            {
                if (!_flexM_T1.AllowEditing)
                    return;

                switch (_flexM_T1.Cols[e.Col].Name)
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

        void _flexM_T1_AfterCodeHelp(object sender, AfterCodeHelpEventArgs e)
        {
            try
            {
                DataTable dt = e.Result.DataTable;        //멀티 or 단일 도움창에서 선택된 데이터들을 Table형태로 가져온다
                //설정   

                string oldValue = D.GetString(_flexM_T1.GetData(e.Row, e.Col));//수정 전에 입력되어있던 값
                string newValue = e.Result.CodeValue;//수정한 값

                if (oldValue == newValue) return;

                switch (_flexM_T1.Cols[e.Col].Name)
                {
                    case "cd_partner":
                        _flexM_T1[e.Row, "no_apply"] = "수정";
                        break;
                }
            }
            catch (Exception ex)
            {
                this.MsgEnd(ex);
            }
        }

        private void _flexM_T1_OwnerDrawCell(object sender, OwnerDrawCellEventArgs e)
        {
            //CellRange rg;

            if (!_flexM_T1.HasNormalRow)
                return;

            if (e.Row < _flexM_T1.Rows.Fixed || e.Col < _flexM_T1.Cols.Fixed)
                return;

            if (D.GetString(_flexM_T1[e.Row, "no_apply"]) == "미반영")
            {
                CellStyle csCellstyle = _flexM_T1.Styles.Add("CellStyle");
                csCellstyle.BackColor = System.Drawing.Color.LightGray;

                _flexM_T1.Rows[e.Row].Style = csCellstyle;
            }
        }

        // 탭 2번 매체 그리드 이벤트
        void _flexM_T2_StartEdit(object sender, RowColEventArgs e)
        {
            try
            {
                if (!_flexM_T2.AllowEditing)
                    return;

                switch (_flexM_T2.Cols[e.Col].Name)
                {
                    case "me_sumcode":
                        break;
                }
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }

        void _flexM_T2_BeforeCodeHelp(object sender, BeforeCodeHelpEventArgs e)
        {
            try
            {
                switch (_flexM_T2.Cols[e.Col].Name)
                {
                    case "me_sumcode":

                        e.Parameter.UserParams = "매체 도움창;H_CZ_ME_GR2;";
                        break;
                }

            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }

        void _flexM_T2_AfterCodeHelp(object sender, AfterCodeHelpEventArgs e)
        {
            try
            {
                DataTable dt = e.Result.DataTable;        //멀티 or 단일 도움창에서 선택된 데이터들을 Table형태로 가져온다
                //설정   

                string oldValue = D.GetString(_flexM_T1.GetData(e.Row, e.Col));//수정 전에 입력되어있던 값
                string newValue = e.Result.CodeValue;//수정한 값

                if (oldValue == newValue) return;

                switch (_flexM_T1.Cols[e.Col].Name)
                {
                    case "me_sumcode":
                        break;
                }
            }
            catch (Exception ex)
            {
                this.MsgEnd(ex);
            }
        }

        #endregion

        #region ♥ 기타 Property
        string ServerKey { get { return Global.MainFrame.ServerKeyCommon.ToUpper(); } }
        #endregion

        private void 조회조건체크(bool b_tf)
        {
            rdoDz1.Enabled = b_tf;
            rdoDz2.Enabled = b_tf;
            rdoDz3.Enabled = b_tf;
        }
    }
}