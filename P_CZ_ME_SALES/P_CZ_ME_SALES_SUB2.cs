using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;
using Dass.FlexGrid;
using Duzon.ERPU;
using Duzon.Common.Forms;
using Duzon.Common.Controls;
using Duzon.Common.Forms.Help;
using Duzon.Common.Util;
using DzHelpFormLib;
using Duzon.Common.BpControls;
using System.Collections.Generic;

using Duzon.ERPU.MF;
using Duzon.ERPU.MF.Common;
using Duzon.Windows.Print;


namespace cz
{
    public partial class P_CZ_ME_SALES_SUB2 : Duzon.Common.Forms.CommonDialog
    {
        private P_CZ_ME_SALES_BIZ _biz = new P_CZ_ME_SALES_BIZ();
        #region ♣ 멤버필드

        public string strCD_ACCT_J = string.Empty;
        public string strCD_ACCT_H = string.Empty;

        #endregion

        #region ♣ 생성자

        public P_CZ_ME_SALES_SUB2()
        {
            InitializeComponent();
        }
        #endregion

        #region ♣ 초기화

        #region -> InitLoad

        protected override void InitLoad()
        {
            base.InitLoad();
        }

        #endregion

        #region -> InitPaint

        protected override void InitPaint()
        {
            base.InitPaint();

            btn변경.Click += new EventHandler(btn변경_Click);
            btn종료.Click += new EventHandler(btn취소_Click);

            DataTable dtGubun_J = _biz.Get계정변경코드();

            dtGubun_J.Select("ISNULL(GUBUN,'') = '1'");

            cbo전계정.DataSource = dtGubun_J;

            cbo전계정.DisplayMember = "NAME";
            cbo전계정.ValueMember = "CODE";
            cbo후계정.SelectedValue = "20104";

            DataTable dtGubun_H = _biz.Get계정변경코드();

            dtGubun_H.Select("ISNULL(GUBUN,'') = '2'");

            cbo후계정.DataSource = dtGubun_H;

            cbo후계정.DisplayMember = "NAME";
            cbo후계정.ValueMember = "CODE";
            cbo후계정.SelectedValue = "20103";
        }
    
        #endregion

        #endregion

        #region ♣ 화면버튼 이벤트

        #region -> Check

      
        #endregion

        private void btn변경_Click(object sender, EventArgs e)
        {
            try
            {
                strCD_ACCT_J = cbo전계정.SelectedValue.ToString();
                strCD_ACCT_H = cbo후계정.SelectedValue.ToString();

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Global.MainFrame.MsgEnd(ex);
            }
        }

        private void btn취소_Click(object sender, EventArgs e)
        {
            //this.Close;
        }
        #endregion

        #region ♣ 컨트롤
        
      #endregion


        #region ♣ 기타 메소드

 
        #endregion
    }
}
