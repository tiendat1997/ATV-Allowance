using ATV_Allowance.Common;
using ATV_Allowance.Common.Actions;
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
        private readonly IAppLogger _logger;

        public AddOrganizationForm()
        {
            _logger = new AppLogger();
            components = new System.ComponentModel.Container();
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
                Organization newEmp = new Organization()
                {                    
                    Name = txtName.Text,                                        
                    IsActive = true
                };
                actionLog.Message = string.Format(AppActions.Organization_Add, newEmp.Name);
                bool result = btnAdd_Validate(newEmp);
                if (result == true)
                {
                    organizationService.AddOrganization(newEmp);
                    DialogHelper.OpenActionResultDialog("Lưu thành công", "Thêm đơn vị");
                }
            }
            catch (Exception ex)
            {                
                _logger.LogSystem(ex, AppActions.Organization_Add);
                actionLog.Status = Constants.BusinessLogStatus.FAIL;
                MessageBox.Show("Có lỗi xảy ra! Vui lòng liên hệ kỹ thuật!", "Thêm đơn vị", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _logger.LogBusiness(actionLog);
                organizationService = null;
            }
        }
    }
}
