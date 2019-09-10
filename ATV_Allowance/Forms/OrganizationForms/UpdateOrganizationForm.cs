using ATV_Allowance.Forms.CommonForms;
using ATV_Allowance.Helpers;
using ATV_Allowance.Services;
using ATV_Allowance.Validators;
using ATV_Allowance.ViewModel;
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
    public partial class UpdateOrganizationForm : CommonForm
    {
        private IOrganizationService organizationService;
        private System.Windows.Forms.ErrorProvider epName;
        internal new Dictionary<Control, ErrorProvider> epDic;
        public OrganizationViewModel model { get; set; }

        public UpdateOrganizationForm(OrganizationViewModel model)
        {
            this.model = model;
            InitializeComponent();
            InitializeErrorProvider();
            LoadData();
        }
        private void LoadData()
        {
            if (model != null)
            {
                txtName.Text = model.Name;                              
            }
        }

        private void InitializeErrorProvider()
        {
            epName = new System.Windows.Forms.ErrorProvider(components);
            epDic = new Dictionary<Control, ErrorProvider>();
            epDic.Add(txtName, epName);
        }
        private bool btnUpdate_Validate(Organization org)
        {
            OrganizationValidator validator = new OrganizationValidator();
            ValidationResult result = validator.Validate(org);
            if (result.IsValid == false)
            {
                ValidatorHelper.ShowValidationMessage(gbOrgInfo, result.Errors, epDic);
            }
            return result.IsValid;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                organizationService = new OrganizationService();
                ValidatorHelper.ClearEPValidation(epDic);
                Organization org = new Organization()
                {
                    Id = model.Id,
                    Name = txtName.Text,
                    IsActive = true
                };
                bool result = btnUpdate_Validate(org);
                if (result == true)
                {
                    organizationService.UpdateOrganization(org);
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
