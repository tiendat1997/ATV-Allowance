using ATV_Allowance.Common;
using ATV_Allowance.Forms.CommonForms;
using ATV_Allowance.Services;
using ATV_Allowance.ViewModel;
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

namespace ATV_Allowance.Forms.DeductionForms
{
    public partial class ListEmployeeDeduction : CommonForm
    {
        private IDeductionService deductionService;
        private IDeductionTypeService deductionTypeService;
        private BindingSource bs;

        private ComboBox comboBox;
        private List<DeductionTypeViewModel> deductionTypes;

        public ListEmployeeDeduction()
        {
            InitializeComponent();
            deductionService = new DeductionService();
            deductionTypeService = new DeductionTypeService();
            InitComboboxView();
            LoadDeduction();
        }

        public ListEmployeeDeduction(int month, int year, int articleType, int employeeRole)
        {
            InitializeComponent();
            deductionService = new DeductionService();
            deductionTypeService = new DeductionTypeService();
            InitComboboxView(articleType, employeeRole);
            LoadDeduction(month, year, employeeRole, articleType);
        }

        private void InitComboboxView(int? articleType = null, int? employeeRole = null)
        {
            var types = new List<ArticleTypeViewModel>();
            types.Add(new ArticleTypeViewModel
            {
                Id = ArticleType.THOI_SU,
                Name = "Thời sự"
            });
            types.Add(new ArticleTypeViewModel
            {
                Id = ArticleType.PHAT_THANH,
                Name = "Phát thanh"
            });
            types.Add(new ArticleTypeViewModel
            {
                Id = ArticleType.PV_TTNM,
                Name = "Phát thanh TTNM"
            });

            types.Add(new ArticleTypeViewModel
            {
                Id = ArticleType.BIENSOAN_TTNM,
                Name = "Bien soan TTNM"
            });
            cbArticleType.DataSource = types;
            cbArticleType.DisplayMember = "Name";
            cbArticleType.ValueMember = "Id";
            cbArticleType.SelectedValue = articleType == null ? ArticleType.THOI_SU : articleType;

            var positions = new List<PositionViewModel>();
            positions.Add(new PositionViewModel
            {
                Id = EmployeeRole.PV,
                Name = "PV"
            });
            //positions.Add(new PositionViewModel
            //{
            //    Id = EmployeeRole.CTV,
            //    Name = "CTV"
            //});
            cbEmpRole.DataSource = positions;
            cbEmpRole.DisplayMember = "Name";
            cbEmpRole.ValueMember = "Id";
            cbEmpRole.SelectedValue = employeeRole == null ? EmployeeRole.PV : employeeRole; 

        }

        public void LoadDeduction(int? month = null, int? year = null, int? employeeRole = null, int? articleType = null)
        {
            
            if (month == null)
            {
                month = DateTime.Now.Month;
            }
            if (year == null)
            {
                year = DateTime.Now.Year;
            }
            if (employeeRole == null)
            {
                employeeRole = EmployeeRole.PV;
            }
            if (articleType == null)
            {
                articleType = ArticleType.THOI_SU;
            }

            var dataSource = deductionService.GetDeductions(month.Value, year.Value, employeeRole.Value, articleType.Value);

            SortableBindingList<EmployeeDeductionViewModel> sbl = new SortableBindingList<EmployeeDeductionViewModel>(dataSource);
            bs = new BindingSource();
            bs.DataSource = sbl;
            adgvDeduction.DataSource = bs;

            adgvDeduction.Columns["EmployeeId"].Visible = false;
            adgvDeduction.Columns["DeductionType"].Visible = false;

            deductionTypes = deductionTypeService.GetDeductionTypes();

            if (adgvDeduction.Columns["cbDeductionCol"] != null)
            {
                adgvDeduction.Columns.Remove("cbDeductionCol");
            }

            DataGridViewComboBoxColumn cmbCol = new DataGridViewComboBoxColumn();
            cmbCol.DataSource = deductionTypes;
            cmbCol.HeaderText = "Giam tru"; //fix here
            cmbCol.DisplayMember = "Name";
            cmbCol.ValueMember = "Id";
            cmbCol.Name = "cbDeductionCol";
            adgvDeduction.Columns.Add(cmbCol);

            if (deductionTypes != null && deductionTypes.Count > 0)
            {
                for (int i = 0; i < dataSource.Count; i++)
                {
                    adgvDeduction.Rows[i].Cells["cbDeductionCol"].Value = ((DeductionTypeViewModel)cmbCol.Items[dataSource[i].DeductionType - 1]).Id;
                }

            }

            adgvDeduction.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(adgvDeduction_EditingControlShowing);

        }

        private void adgvDeduction_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            comboBox = e.Control as ComboBox;
            if (comboBox != null)
            {
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
                comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
                comboBox.SelectionChangeCommitted -= new EventHandler(cbDeductionSelectedIndexChange);
                comboBox.SelectionChangeCommitted += cbDeductionSelectedIndexChange;
                comboBox.SelectedIndex = 0;

            }
        }

        private void cbDeductionSelectedIndexChange(object sender, EventArgs e)
        {
            comboBox = sender as ComboBox;
            double value = deductionTypes.Where(d => d.Id == ((DeductionTypeViewModel)comboBox.SelectedItem).Id).FirstOrDefault().Value;

            adgvDeduction.Rows[adgvDeduction.SelectedRows[0].Index].Cells["Deduction"].Value = value;
            var model = (EmployeeDeductionViewModel)adgvDeduction.CurrentRow.DataBoundItem; ;
            deductionService.UpdateDeduction(model.EmployeeId,
                                            ((DeductionTypeViewModel)comboBox.SelectedItem).Id,
                                            dtpMonth.Value.Month,
                                            dtp.Value.Year,
                                            ((PositionViewModel)cbEmpRole.SelectedItem).Id,
                                            ((ArticleTypeViewModel)cbArticleType.SelectedItem).Id);
        }

        private void cbArticleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbEmpRole.SelectedValue == null || cbArticleType.SelectedValue == null)
            {
                return;
            }
            LoadDeduction(dtpMonth.Value.Month, dtp.Value.Year, ((PositionViewModel)cbEmpRole.SelectedItem).Id, ((ArticleTypeViewModel)cbArticleType.SelectedItem).Id);
        }

        private void cbEmpRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbEmpRole.SelectedValue == null || cbArticleType.SelectedValue == null)
            {
                return;
            }
            LoadDeduction(dtpMonth.Value.Month, dtp.Value.Year, ((PositionViewModel)cbEmpRole.SelectedItem).Id, ((ArticleTypeViewModel)cbArticleType.SelectedItem).Id);
        }

        private void dtpMonth_ValueChanged(object sender, EventArgs e)
        {
            if (cbEmpRole.SelectedValue == null || cbArticleType.SelectedValue == null)
            {
                return;
            }
            LoadDeduction(dtpMonth.Value.Month, dtp.Value.Year, ((PositionViewModel)cbEmpRole.SelectedItem).Id, ((ArticleTypeViewModel)cbArticleType.SelectedItem).Id);
        }

        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            if (cbEmpRole.SelectedValue == null || cbArticleType.SelectedValue == null)
            {
                return;
            }
            LoadDeduction(dtpMonth.Value.Month, dtp.Value.Year, ((PositionViewModel)cbEmpRole.SelectedItem).Id, ((ArticleTypeViewModel)cbArticleType.SelectedItem).Id);
        }
    }
}
