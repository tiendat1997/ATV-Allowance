using ATV_Allowance.Common;
using ATV_Allowance.Common.Actions;
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
        private readonly IAppLogger _logger;
        public OrganizationViewModel model { get; set; }

        public UpdateOrganizationForm(OrganizationViewModel model)
        {
            _logger = new AppLogger();
            components = new System.ComponentModel.Container();
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
            BusinessLog actionLog = new BusinessLog
            {
                ActorId = Common.Session.GetId(),
                Status = Constants.BusinessLogStatus.SUCCESS,
                Type = Constants.BusinessLogType.CREATE
            };

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
                actionLog.Message = string.Format(AppActions.Organization_Update, org.Name);
                bool result = btnUpdate_Validate(org);
                if (result == true)
                {
                    organizationService.UpdateOrganization(org);
                    DialogHelper.OpenActionResultDialog("Lưu thành công", "Cập nhật đơn vị");
                }
            }
            catch (Exception ex)
            {
                _logger.LogSystem(ex, AppActions.Organization_Update);
                actionLog.Status = Constants.BusinessLogStatus.FAIL;
                MessageBox.Show("Có lỗi xảy ra! Vui lòng liên hệ kỹ thuật!", "Cập nhật đơn vị", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _logger.LogBusiness(actionLog);
                organizationService = null;
            }
        }
    }
}
