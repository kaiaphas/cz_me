using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
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
using Duzon.Common.Controls;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace cz
{
    // **************************************
    // 작성자 : 김승일
    // 작성일 : 2020-09-02
    // 모듈명 : 위수탁세금계산서 거래처변경
    // 페이지 : P_CZ_ME_SALES_CONS
    // **************************************

    public partial class P_CZ_ME_SALES_CONS : PageBase
    {
        #region ♥ 멤버필드

        private P_CZ_ME_SALES_CONS_BIZ _biz = new P_CZ_ME_SALES_CONS_BIZ();
        bool _타메뉴호출 = false;
        int show_cell = 0;

        #endregion

        #region ♥ 초기화

        #region -> 생성자

        public P_CZ_ME_SALES_CONS()
        {
            InitializeComponent();

            MainGrids = new FlexGrid[] { _flexM, _flexD };
            _flexD.DetailGrids = new FlexGrid[] { _flexT };

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
            //_flexM 좌상그리드 국세청 정보
            _flexM.BeginSetting(1, 1, false);

            _flexM.SetCol("S", "S", 20, true, CheckTypeEnum.Y_N);
            _flexM.SetCol("CD_COMPANY", "회사코드", 0, false);
            _flexM.SetCol("NO_COMPANY3", "수탁자번호", 90, false);
            _flexM.SetCol("NM_COMPANY3", "수탁자명", 120, false);
            _flexM.SetCol("NO_COMPANY2", "광고주번호", 100, false);
            _flexM.SetCol("NM_COMPANY2", "광고주명", 120, false);
            _flexM.SetCol("AM_TAXSTD", "공급가액", 90, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("AM_ADDTAX", "세액", 90, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("AM_SUM", "합계", 0, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexM.SetCol("NM_BIGO", "비고", 200, false);
            _flexM.SetCol("NM_ITEM", "품목명", 200, false);          
            _flexM.SetCol("NM_BIGO2", "품목비고", 200, false);

            _flexM.SetCol("NO_ETAX", "NO_ETAX", 0, false);
            _flexM.SetCol("TP_GUBUN", "TP_GUBUN", 0, false);
            _flexM.SetCol("NO_SEQ", "NO_SEQ", 0, false);
            _flexM.SetCol("DT_WRITE", "DT_WRITE", 0, false);
            _flexM.SetCol("DT_START", "DT_START", 0, false);
            _flexM.SetCol("NO_COMPANY1", "NO_COMPANY1", 0, false);
            _flexM.SetCol("NO_JONG1", "NO_JONG1", 0, false);
            _flexM.SetCol("NM_COMPANY1", "NM_COMPANY1", 0, false);
            _flexM.SetCol("NM_CEO1", "NM_CEO1", 0, false);
            _flexM.SetCol("NO_JONG2", "NO_JONG2", 0, false);
            _flexM.SetCol("NM_CEO2", "NM_CEO2", 0, false);
            _flexM.SetCol("TP_TAX", "TP_TAX", 0, false);
            _flexM.SetCol("NM_TAX", "NM_TAX", 0, false);
            _flexM.SetCol("TP_BAL", "TP_BAL", 0, false);
            _flexM.SetCol("NM_GITA", "NM_GITA", 0, false);
            _flexM.SetCol("DT_SEND", "DT_SEND", 0, false);
            _flexM.SetCol("SELL_DAM_EMAIL", "SELL_DAM_EMAIL", 0, false);
            _flexM.SetCol("BUY_DAM_EMAIL", "BUY_DAM_EMAIL", 0, false);
            _flexM.SetCol("NM_ST_TAX", "NM_ST_TAX", 0, false);
            _flexM.SetCol("BUY_DAM_EMAIL2", "BUY_DAM_EMAIL2", 0, false);
            _flexM.SetCol("NM_ITEM", "NM_ITEM", 0, false);
            _flexM.SetCol("DC_ADDRESS_SELL", "DC_ADDRESS_SELL", 0, false);
            _flexM.SetCol("DC_ADDRESS_BUY", "DC_ADDRESS_BUY", 0, false);
            _flexM.SetCol("NO_ORDER", "순번", 0, false);
            _flexM.SetCol("PARTNER_CHK", "광고주등록유무", 0, false);
            _flexM.SetCol("NM_CEO2", "광고주대표", 0, false);
            _flexM.SetCol("BUY_DAM_EMAIL", "광고주담당이메일", 0, false);
            _flexM.SetCol("DC_ADDRESS_BUY", "광고주주소", 0, false);
            _flexM.SetCol("ID_INSERT", "등록자", 0, false);

            _flexM.Cols["NO_COMPANY1"].Format = _flexM.Cols["NO_COMPANY1"].EditMask = "###-##-#####";
            _flexM.Cols["NO_COMPANY1"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.SetStringFormatCol("NO_COMPANY1");
            _flexM.SetNoMaskSaveCol("NO_COMPANY1");

            _flexM.Cols["NO_COMPANY2"].Format = _flexM.Cols["NO_COMPANY2"].EditMask = "###-##-#####";
            _flexM.Cols["NO_COMPANY2"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.SetStringFormatCol("NO_COMPANY2");
            _flexM.SetNoMaskSaveCol("NO_COMPANY2");

            _flexM.Cols["NO_COMPANY3"].Format = _flexM.Cols["NO_COMPANY3"].EditMask = "###-##-#####";
            _flexM.Cols["NO_COMPANY3"].TextAlign = TextAlignEnum.CenterCenter;
            _flexM.SetStringFormatCol("NO_COMPANY3");
            _flexM.SetNoMaskSaveCol("NO_COMPANY3");

            _flexM.Cols["AM_TAXSTD"].Format = "###,###,###,##0;(###,###,###,##0)";
            _flexM.Cols["AM_ADDTAX"].Format = "###,###,###,##0;(###,###,###,##0)";
            _flexM.Cols["AM_SUM"].Format = "###,###,###,##0;(###,###,###,##0)";

            _flexM.VerifyNotNull = new string[] { "NO_ETAX", "CD_COMPANY", "NO_COMPANY1", "NO_COMPANY2" };
          
            _flexM.SettingVersion = new Random().Next().ToString();
            _flexM.EndSetting(GridStyleEnum.Green, AllowSortingEnum.MultiColumn, SumPositionEnum.None);
            
            _flexM.OwnerDrawCell += new OwnerDrawCellEventHandler(_flexM_OwnerDrawCell);
            _flexM.StartEdit += new RowColEventHandler(_flexM_StartEdit);

            //_flexD 중단그리드 FI_TAX
            _flexD.BeginSetting(1, 1, false);

            _flexD.SetCol("S", "S", 20, true, CheckTypeEnum.Y_N);
            _flexD.SetCol("ID_UPDATE", "사업자번호", 90, false);
            _flexD.SetCol("NM_PARTNER", "사업자명", 120, false);
            _flexD.SetCol("NO_COMPANY2", "수탁자번호", 90, false);
            _flexD.SetCol("NM_COMPANY2", "수탁자명", 120, false);
            _flexD.SetCol("AM_TAXSTD", "공급가액", 90, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexD.SetCol("AM_ADDTAX", "세액", 90, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexD.SetCol("AM_SUM", "공급대가", 0, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexD.SetCol("NO_DOCU", "전표번호", 100, false);
            _flexD.SetCol("NM_NOTE", "적요", 200, false);
            _flexD.SetCol("NO_ORDER", "순번", 0, false);
            _flexD.SetCol("NO_COMPANY3", "수탁자번호", 0, false);
            _flexD.SetCol("NM_COMPANY3", "수탁자명", 0, false);
            _flexD.SetCol("ID_UPDATE_PRE", "체크전사업자번호", 0, false);
            _flexD.SetCol("NM_PARTNER_PRE", "체크전사업자명", 0, false);
            _flexD.SetCol("PARTNER_CHK", "광고주등록유무", 0, false);
            _flexD.SetCol("NM_CEO2", "광고주대표", 0, false);
            _flexD.SetCol("BUY_DAM_EMAIL", "광고주담당이메일", 0, false);
            _flexD.SetCol("DC_ADDRESS_BUY", "광고주주소", 0, false);

            _flexD.SetDummyColumn("S");

            _flexD.Cols["NO_COMPANY2"].Format = _flexD.Cols["NO_COMPANY2"].EditMask = "###-##-#####";
            _flexD.Cols["NO_COMPANY2"].TextAlign = TextAlignEnum.CenterCenter;
            _flexD.SetStringFormatCol("NO_COMPANY2");
            _flexD.SetNoMaskSaveCol("NO_COMPANY2");

            _flexD.Cols["NO_COMPANY3"].Format = _flexD.Cols["NO_COMPANY3"].EditMask = "###-##-#####";
            _flexD.Cols["NO_COMPANY3"].TextAlign = TextAlignEnum.CenterCenter;
            _flexD.SetStringFormatCol("NO_COMPANY3");
            _flexD.SetNoMaskSaveCol("NO_COMPANY3");

            _flexD.Cols["ID_UPDATE"].Format = _flexD.Cols["ID_UPDATE"].EditMask = "###-##-#####";
            _flexD.Cols["ID_UPDATE"].TextAlign = TextAlignEnum.CenterCenter;
            _flexD.SetStringFormatCol("ID_UPDATE");
            _flexD.SetNoMaskSaveCol("ID_UPDATE");

            _flexD.Cols["NO_DOCU"].TextAlign = TextAlignEnum.CenterCenter;

            _flexD.Cols["AM_TAXSTD"].Format = "###,###,###,##0;(###,###,###,##0)";
            _flexD.Cols["AM_ADDTAX"].Format = "###,###,###,##0;(###,###,###,##0)";
            _flexD.Cols["AM_SUM"].Format = "###,###,###,##0;(###,###,###,##0)";

            _flexD.SettingVersion = new Random().Next().ToString();
            _flexD.EndSetting(GridStyleEnum.Green, AllowSortingEnum.MultiColumn, SumPositionEnum.None);

            _flexD.AfterRowChange += new RangeEventHandler(_flexD_AfterRowChange);
            _flexD.AfterEdit += new RowColEventHandler(_flexD_AfterEdit);
            _flexD.StartEdit += new RowColEventHandler(_flexD_StartEdit);
            _flexD.OwnerDrawCell += new OwnerDrawCellEventHandler(_flexD_OwnerDrawCell);
            _flexD.HelpClick += new EventHandler(_flexD_HelpClick);

            //_flexT 하단그리드 
            _flexT.BeginSetting(1, 1, false);

            _flexT.SetCol("NO_DOCU", "전표번호", 100, false);
            _flexT.SetCol("NO_DOLINE", "순번", 35, false);
            _flexT.SetCol("DT_ACCT", "회계일자", 100, false, typeof(string), FormatTpType.YEAR_MONTH_DAY);
            _flexT.SetCol("CD_ACCT", "계정코드", 80, false);
            _flexT.SetCol("NM_ACCT", "계정명", 150, false);
            _flexT.SetCol("NM_NOTE", "적요", 200, false);
            _flexT.SetCol("AM_DR", "차변", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexT.SetCol("AM_CR", "대변", 100, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flexT.SetCol("CD_MNGD1", "사업자번호", 100, false);
            _flexT.SetCol("NM_MNGD1", "사업자명", 200, false);

            _flexT.Cols["NO_DOCU"].TextAlign = TextAlignEnum.CenterCenter;
            _flexT.Cols["NO_DOLINE"].TextAlign = TextAlignEnum.CenterCenter;
            _flexT.Cols["DT_ACCT"].TextAlign = TextAlignEnum.CenterCenter;
            _flexT.Cols["CD_ACCT"].TextAlign = TextAlignEnum.CenterCenter;

            _flexT.Cols["CD_MNGD1"].Format = _flexT.Cols["CD_MNGD1"].EditMask = "###-##-#####";
            _flexT.Cols["CD_MNGD1"].TextAlign = TextAlignEnum.CenterCenter;
            _flexT.SetStringFormatCol("CD_MNGD1");
            _flexT.SetNoMaskSaveCol("CD_MNGD1");

            _flexT.Cols["AM_DR"].Format = "###,###,###,##0;(###,###,###,##0)";
            _flexT.Cols["AM_CR"].Format = "###,###,###,##0;(###,###,###,##0)";

            _flexT.SettingVersion = new Random().Next().ToString();
            _flexT.EndSetting(GridStyleEnum.Green, AllowSortingEnum.MultiColumn, SumPositionEnum.None);
            _flexT.OwnerDrawCell += new OwnerDrawCellEventHandler(_flexT_OwnerDrawCell);
            _flexT.HelpClick += new EventHandler(_flexT_HelpClick);

        }
        #endregion

        #region -> InitPaint

        protected override void InitPaint()
        {
            base.InitPaint();

            btn거래처변경.Click += new EventHandler(btn거래처변경_Click);
            btn엑셀업로드.Click += new EventHandler(btn엑셀업로드_Click);
            btn변경취소.Click += new EventHandler(btn변경취소_Click);
            //btn광고주반영.Click += new EventHandler(btn광고주반영_Click);

            Grant.CanAdd = false;
            Grant.CanPrint = false;
            Grant.CanDelete = false;

            string longtoday = "";

            longtoday = DateTime.Now.ToString("yyyMMddHHmmss");

            dp년월.Text = longtoday.Substring(0, 6);
        }

        #endregion

        #endregion

        #region ♥ 메인버튼 클릭

        #region -> 조회버튼클릭

        public override void OnToolBarSearchButtonClicked(object sender, EventArgs e)
        {
            searchNo();
        }

        public void searchNo()
        {
            try
            {
                object[] Params = new object[3];
                Params[0] = LoginInfo.CompanyCode;
                Params[1] = dp년월.Text;
                Params[2] = txt명.Text;

                DataSet ds = _biz.Search_M(Params);

                _flexM.Binding = ds.Tables[0];

                object[] Params2 = new object[3];
                Params2[0] = LoginInfo.CompanyCode;
                Params2[1] = dp년월.Text;
                Params2[2] = txt더존명.Text;

                DataSet ds2 = _biz.Search_D(Params2);

                _flexD.Binding = ds2.Tables[0];

                System.Data.DataTable dt = _biz.Get업로드일시();

                lbl엑셀업로드일시.Text = "업로드일시 : " + dt.Rows[0]["DTS_INSERT"].ToString();
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
                    ShowMessage(PageResultMode.SaveGood);
                    {
                        searchNo();
                    }
                }
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }

        // 실제 저장 기능
        protected override bool SaveData()
        {
            object obj = null;

            if (_flexM.HasNormalRow)
            {
                if (_flexM.GetChanges() == null)
                {
                    return false;
                }

                obj = _biz.Save(_flexM.GetChanges(), _타메뉴호출);
            }

            ResultData[] result = (ResultData[])obj;

            return true;
        }

        // 저장 전 체크 사항
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
               
             }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }

        }

        #endregion

        #endregion

        #region ♥ 기타 이벤트

        private void btn거래처변경_Click(object sender, EventArgs e)
        {
            try
            {
                //if (!_flexM.HasNormalRow)
                //    return;

                //if (!BeforeSaveChk())
                //    return;

                if (_flexD.GetCheckedRows("S") == null)
                {
                    ShowMessage("변경 할 자료가 선택 되지 않았습니다.");
                    return;
                }

                DataRow[] ldrchk = _flexD.DataTable.Select("S = 'Y'", "", DataViewRowState.CurrentRows);

                if (ldrchk == null || ldrchk.Length == 0)
                {
                    ShowMessage(공통메세지.선택된자료가없습니다);
                    return;
                }

                if (ShowMessage("선택한 데이터의 거래처를 반영 하시겠습니까?", "QY2") == DialogResult.Yes)
                {

                    if (!BeforeSaveChk())
                        return;

                    if (SaveData())
                    {

                    }

                    for (int i = 1; i < _flexD.Rows.Count; i++)
                    {
                        if (_flexD[i, "S"].ToString().Equals("Y"))
                        {

                            string 전표번호 = _flexD[i, "NO_DOCU"].ToString();
                            string 광고주사업자번호 = _flexD[i, "ID_UPDATE"].ToString();
                            string 광고주명 = _flexD[i, "NM_PARTNER"].ToString();
                            string 사업자번호 = _flexD[i, "NO_COMPANY2"].ToString();
                            string 광고주대표 = _flexD[i, "NM_CEO2"].ToString();
                            string 광고주담당이메일 = _flexD[i, "BUY_DAM_EMAIL"].ToString();
                            string 광고주주소 = _flexD[i, "DC_ADDRESS_BUY"].ToString();

                            if (광고주사업자번호 == null || 광고주사업자번호 == "")
                            {
                                ShowMessage((i) + "행에 광고주 사업자번호가 없습니다.");
                                return;
                            }
                            else
                            {
                                //국세청자료에 광고주가 등록되어 있지 않은경우 MA_PARTNER에 INSERT 처리 한다.
                                if (_flexM[_flexM.Row, "PARTNER_CHK"].ToString() == "2")
                                {
                                    if (_biz.Insert_Cust(광고주사업자번호, 광고주명, 광고주대표, 광고주담당이메일, 광고주주소))
                                    {

                                    }
                                }

                                if (_biz.Update_Cust(전표번호, 광고주사업자번호, 광고주명, 사업자번호))
                                {
                                
                                }
                            }
                        }
                    }

                    object[] Params = new object[3];
                    Params[0] = LoginInfo.CompanyCode;
                    Params[1] = dp년월.Text;
                    Params[2] = txt명.Text;

                    DataSet ds = _biz.Search_M(Params);

                    _flexM.Binding = ds.Tables[0];


                    object[] Params2 = new object[3];
                    Params2[0] = LoginInfo.CompanyCode;
                    Params2[1] = dp년월.Text;
                    Params2[2] = txt더존명.Text;

                    DataSet ds2 = _biz.Search_D(Params2);

                    _flexD.Binding = ds2.Tables[0];


                    object[] Params3 = new object[2];
                    Params3[0] = LoginInfo.CompanyCode;
                    Params3[1] = D.GetString(_flexD["NO_DOCU"]);

                    DataSet ds3 = _biz.Search_T(Params3);

                    _flexT.Binding = ds3.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }

        
        private void btn엑셀업로드_Click(object sender, EventArgs e)
        {
            //엑셀 변수 선언
            Excel.Application ap = null;
            Excel.Workbook wb = null;
            Excel.Worksheet ws = null;

            //파일 선택
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel File (*.xlsx|*.xlsx|Excel file 97~2003 (*.xls)|*.xls|All files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    searchNo();

                    System.Data.DataTable dt = new System.Data.DataTable();

                    Console.WriteLine(ofd.FileName);
                    ap = new Excel.Application();
                    wb = ap.Workbooks.Open(ofd.FileName);
                    ws = wb.Sheets[1];

                    Excel.Range range = ws.UsedRange;

                    object[,] data = range.Value;

                    _flexM.Redraw = false;

                    for (int r = 7; r <= range.Rows.Count; r++)
                    {
                        _flexM.Rows.Add();
                        _flexM.Row = _flexM.Rows.Count - 1;
       
                        _flexM[_flexM.Row, "CD_COMPANY"] = Duzon.Common.Forms.Global.MainFrame.LoginInfo.CompanyCode;
                        _flexM[_flexM.Row, "NO_ETAX"] = data[r, 2];
                        _flexM[_flexM.Row, "DT_WRITE"] = data[r, 1];
                        _flexM[_flexM.Row, "DT_START"] = data[r, 3];
                        _flexM[_flexM.Row, "NO_COMPANY1"] = data[r, 5];
                        _flexM[_flexM.Row, "NO_JONG1"] = data[r, 6];
                        _flexM[_flexM.Row, "NM_COMPANY1"] = data[r, 7];
                        _flexM[_flexM.Row, "NM_CEO1"] = data[r, 8];
                        _flexM[_flexM.Row, "NO_COMPANY2"] = data[r, 10];
                        _flexM[_flexM.Row, "NO_JONG2"] = data[r, 11];
                        _flexM[_flexM.Row, "NM_COMPANY2"] = data[r, 12];
                        _flexM[_flexM.Row, "NM_CEO2"] = data[r, 13];
                        _flexM[_flexM.Row, "AM_SUM"] = data[r, 15];
                        _flexM[_flexM.Row, "AM_TAXSTD"] = data[r, 16];
                        _flexM[_flexM.Row, "AM_ADDTAX"] = data[r, 17];
                        _flexM[_flexM.Row, "TP_TAX"] = data[r, 18];
                        _flexM[_flexM.Row, "NM_TAX"] = data[r, 19];
                        _flexM[_flexM.Row, "TP_BAL"] = data[r, 20];
                        _flexM[_flexM.Row, "NM_BIGO"] = data[r, 21];
                        _flexM[_flexM.Row, "DT_SEND"] = data[r, 4];
                        _flexM[_flexM.Row, "SELL_DAM_EMAIL"] = data[r, 23];
                        _flexM[_flexM.Row, "BUY_DAM_EMAIL"] = data[r, 24];
                        _flexM[_flexM.Row, "NM_ST_TAX"] = data[r, 22];
                        _flexM[_flexM.Row, "BUY_DAM_EMAIL2"] = data[r, 25];
                        _flexM[_flexM.Row, "NM_ITEM"] = data[r, 29];
                        _flexM[_flexM.Row, "DC_ADDRESS_SELL"] = data[r, 9];
                        _flexM[_flexM.Row, "DC_ADDRESS_BUY"] = data[r, 14];
                        _flexM[_flexM.Row, "NO_COMPANY3"] = data[r, 26];
                        _flexM[_flexM.Row, "NM_COMPANY3"] = data[r, 27];
                        _flexM[_flexM.Row, "NM_BIGO2"] = data[r, 35];
                        _flexM[_flexM.Row, "ID_INSERT"] = Duzon.Common.Forms.Global.MainFrame.LoginInfo.UserID;
                        
                    }


                    wb.Close(true);
                    ap.Quit();

                    _flexM.AddFinished();
                    _flexM.Redraw = true;
                    _flexM.IsDataChanged = true;

                    ToolBarSaveButtonEnabled = true;

                    MsgControl.CloseMsg();

                }
                catch (Exception ex)
                {
                    Duzon.Common.Forms.Global.MainFrame.MsgEnd(ex);
                    MsgControl.CloseMsg();
                }
                finally
                {
                    _flexM.Redraw = true;
                }
            }
        }

        private void btn변경취소_Click(object sender, EventArgs e)
        {
            try
            {
                //if (!_flexM.HasNormalRow)
                //    return;

                //if (!BeforeSaveChk())
                //    return;
                if (_flexD.Row.ToString() == null || _flexD.Row.ToString() == "" || _flexD.Rows.Count == 2)
                    return;

                if (ShowMessage(_flexD.Row + "행 데이터를 변경취소 하시겠습니까?", "QY2") == DialogResult.Yes)
                {

                    if (!BeforeSaveChk())
                        return;

                    string 전표번호 = _flexD[_flexD.Row, "NO_DOCU"].ToString();
                    string 사업자번호 = _flexD[_flexD.Row, "ID_UPDATE"].ToString();
                    string 사업자명 = _flexD[_flexD.Row, "NM_PARTNER"].ToString();
                    string 수탁자번호 = _flexD[_flexD.Row, "NO_COMPANY2"].ToString();
                    string 수탁자명 = _flexD[_flexD.Row, "NM_COMPANY2"].ToString();
                    string 소계 = _flexD[_flexD.Row, "NO_ORDER"].ToString();

                    if (소계.Equals("2"))
                    {
                        ShowMessage("소계행은 취소할 수 없습니다.");
                        return;
                    }

                    if (수탁자번호 == null || 수탁자번호 == "")
                    {
                        ShowMessage("거래처 변경이 안된 데이터입니다.");
                        return;
                    }
                    else
                    {
                        if (_biz.Update_Cust_Cancel(전표번호, 수탁자번호, 수탁자명))
                        {

                        }
                    }

                    object[] Params = new object[3];
                    Params[0] = LoginInfo.CompanyCode;
                    Params[1] = dp년월.Text;
                    Params[2] = txt명.Text;

                    DataSet ds = _biz.Search_M(Params);

                    _flexM.Binding = ds.Tables[0];


                    object[] Params2 = new object[3];
                    Params2[0] = LoginInfo.CompanyCode;
                    Params2[1] = dp년월.Text;
                    Params2[2] = txt더존명.Text;

                    DataSet ds2 = _biz.Search_D(Params2);

                    _flexD.Binding = ds2.Tables[0];


                    object[] Params3 = new object[2];
                    Params3[0] = LoginInfo.CompanyCode;
                    Params3[1] = D.GetString(_flexD["NO_DOCU"]);

                    DataSet ds3 = _biz.Search_T(Params3);

                    _flexT.Binding = ds3.Tables[0];

                    for (int i = 1; i < _flexD.Rows.Count; i++)
                    {
                        if (_flexD[i, "NO_DOCU"].ToString().Equals(전표번호))
                        {
                            show_cell = i;
                        }
                    }

                    _flexD.ShowCell(show_cell, 1);
                    _flexD.Select(show_cell, "S");
                }
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }

        /*
        private void btn광고주반영_Click(object sender, EventArgs e)
        {
            try
            {
                if (_flexM.Row.ToString() == null || _flexM.Row.ToString() == "")
                    return;             

                string 광고주사업자번호 = _flexM[_flexM.Row, "NO_COMPANY2"].ToString();
                string 광고주명 = _flexM[_flexM.Row, "NM_COMPANY2"].ToString();

                for (int i = 1; i < _flexD.Rows.Count; i++)
                {
                    if (_flexD[i, "S"].ToString().Equals("Y"))
                    {
                        _flexD[i, "NO_COMPANY2"] = 광고주사업자번호;
                        _flexD[i, "NM_COMPANY2"] = 광고주명;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }
        */


        #endregion

        #region ♥ 그리드 이벤트

        void _flexM_StartEdit(object sender, RowColEventArgs e)
        {
            switch (_flexM.Cols[_flexM.Col].Name)
            {
                case "S":

                    if (D.GetString(_flexM["NO_ORDER"]).Equals("2"))
                        e.Cancel = true;

                    break;
            }
        }

        //_flexD 
        void _flexD_AfterRowChange(object sender, RangeEventArgs e)
        {
            try
            {
                object[] Params = new object[2];
                Params[0] = LoginInfo.CompanyCode;
                Params[1] = D.GetString(_flexD["NO_DOCU"]);
                               
                DataSet ds = _biz.Search_T(Params);
                
                _flexT.Binding = ds.Tables[0];
                
            }
            catch (Exception ex)
            {
                this.MsgEnd(ex);
            }
        }

        void _flexD_AfterEdit(object sender, RowColEventArgs e)
        {
            switch (_flexD.Cols[_flexD.Col].Name)
            {
                case "S":

                    if (_flexM.Row.ToString() == null || _flexM.Row.ToString() == "")
                        return;

                    string 광고주사업자번호 = _flexM[_flexM.Row, "NO_COMPANY2"].ToString();
                    string 광고주명 = _flexM[_flexM.Row, "NM_COMPANY2"].ToString();

                    string 수탁자사업자번호 = _flexD[_flexD.Row, "ID_UPDATE"].ToString();
                    string 수탁자명 = _flexD[_flexD.Row, "NM_PARTNER"].ToString();

                    string 체크전사업자번호 = _flexD[_flexD.Row, "ID_UPDATE_PRE"].ToString();
                    string 체크전사업자명 = _flexD[_flexD.Row, "NM_PARTNER_PRE"].ToString();

                    string 체크전광고주사업자번호 = _flexD[_flexD.Row, "NO_COMPANY2_PRE"].ToString();
                    string 체크전광고주명 = _flexD[_flexD.Row, "NM_COMPANY2_PRE"].ToString();

                    string 광고주등록유무 = _flexM[_flexM.Row, "PARTNER_CHK"].ToString();
                    string 광고주대표 = _flexM[_flexM.Row, "NM_CEO2"].ToString();
                    string 광고주담당이메일 = _flexM[_flexM.Row, "BUY_DAM_EMAIL"].ToString();
                    string 광고주주소 = _flexM[_flexM.Row, "DC_ADDRESS_BUY"].ToString();


                    if (_flexD[_flexD.Row, "S"].ToString().Equals("Y"))
                    {
                        _flexD[_flexD.Row, "ID_UPDATE"] = 광고주사업자번호;
                        _flexD[_flexD.Row, "NM_PARTNER"] = 광고주명;

                        _flexD[_flexD.Row, "NO_COMPANY2"] = 수탁자사업자번호;
                        _flexD[_flexD.Row, "NM_COMPANY2"] = 수탁자명;

                        _flexD[_flexD.Row, "PARTNER_CHK"] = 광고주등록유무;
                        _flexD[_flexD.Row, "NM_CEO2"] = 광고주대표;
                        _flexD[_flexD.Row, "BUY_DAM_EMAIL"] = 광고주담당이메일;
                        _flexD[_flexD.Row, "DC_ADDRESS_BUY"] = 광고주주소;

                        _flexM[_flexM.Row, "S"] = "Y";
                        //_flexM[_flexM.Row, "S"] = "Y";
                    }

                    if (_flexD[_flexD.Row, "S"].ToString().Equals("N"))
                    {
                        _flexD[_flexD.Row, "ID_UPDATE"] = 체크전사업자번호;
                        _flexD[_flexD.Row, "NM_PARTNER"] = 체크전사업자명;

                        _flexD[_flexD.Row, "NO_COMPANY2"] = 체크전광고주사업자번호;
                        _flexD[_flexD.Row, "NM_COMPANY2"] = 체크전광고주명;

                        _flexD[_flexD.Row, "PARTNER_CHK"] = "";
                        _flexD[_flexD.Row, "NM_CEO2"] = "";
                        _flexD[_flexD.Row, "BUY_DAM_EMAIL"] = "";
                        _flexD[_flexD.Row, "DC_ADDRESS_BUY"] = "";
                    }

                    break;
            }
        }

        void _flexD_StartEdit(object sender, RowColEventArgs e)
        {
            switch (_flexD.Cols[_flexD.Col].Name)
            {
                case "S":
                    
                    if (D.GetString(_flexD["NO_ORDER"]).Equals("2"))
                        e.Cancel = true;

                    if (D.GetString(_flexD["S"]).Equals("N"))
                    {
                        if (D.GetString(_flexM["NO_COMPANY3"]) != D.GetString(_flexD["ID_UPDATE"]))
                            e.Cancel = true;
                    }

                    break;
            }
        }

        void _flexD_HelpClick(object sender, EventArgs e)
        {
            try
            {
                string 전표번호 = D.GetString(_flexD["NO_DOCU"]);

                if (전표번호 == "")
                    return;

                switch (_flexD.Cols[_flexD.Col].Name)
                {
                    case "NO_DOCU":

                        object[] Args = { 전표번호, "", "", Duzon.Common.Forms.Global.MainFrame.LoginInfo.CompanyCode };
                        CallOtherPageMethod("P_FI_DOCU", "전표입력(" + PageName + ")", Grant, Args);

                        break;
                }
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }

        void _flexT_HelpClick(object sender, EventArgs e)
        {
            try
            {
                string 전표번호 = D.GetString(_flexT["NO_DOCU"]);

                if (전표번호 == "")
                    return;

                switch (_flexT.Cols[_flexT.Col].Name)
                {
                    case "NO_DOCU":

                        object[] Args = { 전표번호, "", "", Duzon.Common.Forms.Global.MainFrame.LoginInfo.CompanyCode };
                        CallOtherPageMethod("P_FI_DOCU", "전표입력(" + PageName + ")", Grant, Args);

                        break;
                }
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }


        #endregion

        #region ♥ 기타 Property
        string ServerKey { get { return Duzon.Common.Forms.Global.MainFrame.ServerKeyCommon.ToUpper(); } }

        private void _flexM_OwnerDrawCell(object sender, OwnerDrawCellEventArgs e)
        {
            CellRange rg;
            CellStyle csCellstyle = _flexM.Styles.Add("CellStyle");

            if (!_flexM.HasNormalRow)
                return;

            if (e.Row < _flexM.Rows.Fixed || e.Col < _flexM.Cols.Fixed)
                return;

            if (D.GetString(_flexM[e.Row, "NO_ORDER"]) == "2")
            {
                csCellstyle.BackColor = System.Drawing.Color.FromArgb(((Byte)(255)), ((Byte)(242)), ((Byte)(230)));
                _flexM.Rows[e.Row].Style = csCellstyle;

                rg = _flexM.GetCellRange(e.Row, "S");
                rg.StyleNew.Display = DisplayEnum.None;
            }

            if (D.GetString(_flexM[e.Row, "PARTNER_CHK"]) == "2")
            {
                rg = _flexM.GetCellRange(e.Row, "NO_COMPANY2");
                rg.StyleNew.BackColor = System.Drawing.Color.FromArgb(((Byte)(255)), ((Byte)(126)), ((Byte)(126)));
                rg = _flexM.GetCellRange(e.Row, "NM_COMPANY2");
                rg.StyleNew.BackColor = System.Drawing.Color.FromArgb(((Byte)(255)), ((Byte)(126)), ((Byte)(126)));
            }

            if (D.GetDecimal(_flexM[e.Row, "AM_TAXSTD"]) < 0)
            {
                rg = _flexM.GetCellRange(e.Row, "AM_TAXSTD");
                rg.StyleNew.ForeColor = System.Drawing.Color.Red;
            }

            if (D.GetDecimal(_flexM[e.Row, "AM_ADDTAX"]) < 0)
            {
                rg = _flexM.GetCellRange(e.Row, "AM_ADDTAX");
                rg.StyleNew.ForeColor = System.Drawing.Color.Red;
            }

            if (D.GetDecimal(_flexM[e.Row, "AM_SUM"]) < 0)
            {
                rg = _flexM.GetCellRange(e.Row, "AM_SUM");
                rg.StyleNew.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void _flexD_OwnerDrawCell(object sender, OwnerDrawCellEventArgs e)
        {
            CellRange rg;
            CellStyle csCellstyle = _flexD.Styles.Add("CellStyle");

            if (!_flexD.HasNormalRow)
                return;

            if (e.Row < _flexD.Rows.Fixed || e.Col < _flexD.Cols.Fixed)
                return;

            if (D.GetString(_flexD[e.Row, "NO_ORDER"]) == "2")
            {
                csCellstyle.BackColor = System.Drawing.Color.FromArgb(((Byte)(255)), ((Byte)(242)), ((Byte)(230)));
                _flexD.Rows[e.Row].Style = csCellstyle;

                rg = _flexD.GetCellRange(e.Row, "S");
                rg.StyleNew.Display = DisplayEnum.None;
            }

            if (D.GetDecimal(_flexD[e.Row, "AM_TAXSTD"]) < 0)
            {
                rg = _flexD.GetCellRange(e.Row, "AM_TAXSTD");
                rg.StyleNew.ForeColor = System.Drawing.Color.Red;
            }

            if (D.GetDecimal(_flexD[e.Row, "AM_ADDTAX"]) < 0)
            {
                rg = _flexD.GetCellRange(e.Row, "AM_ADDTAX");
                rg.StyleNew.ForeColor = System.Drawing.Color.Red;
            }

            if (D.GetDecimal(_flexD[e.Row, "AM_SUM"]) < 0)
            {
                rg = _flexD.GetCellRange(e.Row, "AM_SUM");
                rg.StyleNew.ForeColor = System.Drawing.Color.Red;
            }

        }

        private void _flexT_OwnerDrawCell(object sender, OwnerDrawCellEventArgs e)
        {
            CellRange rg;
            CellStyle csCellstyle = _flexT.Styles.Add("CellStyle");

            if (!_flexT.HasNormalRow)
                return;

            if (e.Row < _flexT.Rows.Fixed || e.Col < _flexT.Cols.Fixed)
                return;

            if (D.GetDecimal(_flexT[e.Row, "AM_DR"]) < 0)
            {
                rg = _flexT.GetCellRange(e.Row, "AM_DR");
                rg.StyleNew.ForeColor = System.Drawing.Color.Red;
            }

            if (D.GetDecimal(_flexT[e.Row, "AM_CR"]) < 0)
            {
                rg = _flexT.GetCellRange(e.Row, "AM_CR");
                rg.StyleNew.ForeColor = System.Drawing.Color.Red;
            }           
        }


        #endregion            

    }
}