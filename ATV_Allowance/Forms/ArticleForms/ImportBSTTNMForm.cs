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
        public ImportBSTTNMForm()
        {
            InitializeComponent();
            InitTabControl();
        }
        private void InitTabControl()
        {
            UserControl articleControl = new ImportArticleUserControl(ArticleType.BIENSOAN_TTNM);
            tpArticle.Controls.Add(articleControl);
            UserControl postProductionControl = new ImportArticleUserControl(ArticleType.KHOIHK_TTNM);
            tpPostProduction.Controls.Add(postProductionControl);
        }
    }
}
