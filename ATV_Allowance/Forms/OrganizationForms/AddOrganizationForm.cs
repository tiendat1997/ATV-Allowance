using ATV_Allowance.Forms.CommonForms;
using ATV_Allowance.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATV_Allowance.Forms.OrganizationForms
{
    public partial class AddOrganizationForm : CommonForm
    {
        private IOrganizationService organizationService;
        private System.Windows.Forms.ErrorProvider epName;
        internal new Dictionary<Control, ErrorProvider> epDic;

        public AddOrganizationForm()
        {
            InitializeComponent();
            InitializeErrorProvider();
        }

        private void InitializeErrorProvider()
        {
            epName = new System.Windows.Forms.ErrorProvider(components);          
            epDic = new Dictionary<Control, ErrorProvider>();
            epDic.Add(txtName, epName);
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
