using ATV_Allowance.Forms.CommonForms;
using ATV_Allowance.Helpers;
using ATV_Allowance.Services;
using ATV_Allowance.Validators;
using DataService.Entity;
using FluentValidation.Results;
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
        private bool btnAdd_Validate(Organization org)
        {
            OrganizationValidator validator = new OrganizationValidator();
            ValidationResult result = validator.Validate(org);
            if (result.IsValid == false)
            {
                ValidatorHelper.ShowValidationMessage(gbOrgInfo, result.Errors, epDic);
            }
            return result.IsValid;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                organizationService = new OrganizationService();
                ValidatorHelper.ClearEPValidation(epDic);
                Organization newEmp = new Organization()
                {                    
                    Name = txtName.Text,                                        
                    IsActive = true
                };
                bool result = btnAdd_Validate(newEmp);
                if (result == true)
                {
                    organizationService.AddOrganization(newEmp);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                organizationService = null;
            }
        }
    }
}
