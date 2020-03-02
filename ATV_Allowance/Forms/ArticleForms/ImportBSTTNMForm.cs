using ATV_Allowance.Controls;
using ATV_Allowance.Forms.CommonForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ATV_Allowance.Common.Constants;

namespace ATV_Allowance.Forms.ArticleForms
{
    public partial class ImportBSTTNMForm : CommonForm
    {
        ImportArticleUserControl articleControl;
        ImportArticleUserControl postProductionControl;
        public ImportBSTTNMForm()
        {
            InitializeComponent();
            InitTabControl();
        }
        private void InitTabControl()
        {
            articleControl = new ImportArticleUserControl(ArticleType.BIENSOAN_TTNM);
            tpArticle.Controls.Add(articleControl);
            postProductionControl = new ImportArticleUserControl(ArticleType.KHOIHK_TTNM);
            tpPostProduction.Controls.Add(postProductionControl);
        }

        private void ImportBSTTNMForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.N)
            {
                if (tcImportArticle.SelectedTab == tcImportArticle.TabPages["tpArticle"])//your specific tabname
                {
                    // your stuff
                    articleControl.FocusOnTitle();
                }
                else if (tcImportArticle.SelectedTab == tcImportArticle.TabPages["tpPostProduction"])
                {
                    postProductionControl.FocusOnTitle();
                }
                
            }
        }
    }
}
