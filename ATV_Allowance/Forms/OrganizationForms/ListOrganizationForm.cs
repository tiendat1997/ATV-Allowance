using ATV_Allowance.Common;
using ATV_Allowance.Forms.CommonForms;
using ATV_Allowance.Services;
using ATV_Allowance.ViewModel;
using DataService.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ATV_Allowance.Common.Constants;

namespace ATV_Allowance.Forms.OrganizationForms
{
    public partial class ListOrganizationForm : CommonForm
    {
        private IOrganizationService orgService = null;
        private BindingSource bs = null;
        private OrganizationViewModel model = null;
        private List<OrganizationViewModel> list = new List<OrganizationViewModel>();
        public ListOrganizationForm()
        {
            InitializeComponent();
            InitTabIndex();
            LoadDGV();
        }
        private void InitTabIndex()
        {
            txtSearch.TabIndex = 0;
            adgvOrg.TabIndex = 1;
            btnAdd.TabIndex = 2;
            btnEdit.TabIndex = 3;
        }
        private void LoadDGV()
        {
            try
            {
                orgService = new OrganizationService();
                list = orgService.GetAllIsActive(true);
                SortableBindingList<OrganizationViewModel> sbl = new SortableBindingList<OrganizationViewModel>(list);
                bs = new BindingSource();
                bs.DataSource = sbl;
                adgvOrg.DataSource = bs;
                adgvOrg.Columns["Id"].Visible = false;
                adgvOrg.Columns["Name"].Visible = true;
                adgvOrg.Columns["IsActive"].Visible = false;

                adgvOrg.Columns["Name"].HeaderText = ADGVOrganizationText.Name;
                adgvOrg.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;                    

                // Set selected employee 
                if (list.Count > 0)
                {
                    model = list[0];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                orgService = null;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddOrganizationForm detailForm = new AddOrganizationForm();
            detailForm.FormClosed += new FormClosedEventHandler(AddOrgForm_Closed);
            detailForm.ShowDialog();
        }
        private void AddOrgForm_Closed(object sender, FormClosedEventArgs e)
        {
            if (adgvOrg.CurrentRow != null)
            {
                int oldCount = adgvOrg.Rows.Count - 1;
                int currIndex = adgvOrg.CurrentRow.Index;
                int selectedIndex = currIndex;
                LoadDGV();
                txtSearch_TextChanged(sender, new EventArgs());
                adgvOrg.ClearSelection();
                int rowIndex = adgvOrg.Rows.Count - 1;
                if (rowIndex > oldCount)
                {
                    selectedIndex = rowIndex;
                }
                adgvOrg.Rows[selectedIndex].Selected = true;
                adgvOrg.CurrentCell = adgvOrg.Rows[selectedIndex].Cells[1];                
            }   
            else {
                LoadDGV();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var orgSrc = (OrganizationViewModel)adgvOrg.CurrentRow.DataBoundItem;
            if (orgSrc != null)
            {
                UpdateOrganizationForm detailForm = new UpdateOrganizationForm(orgSrc);
                detailForm.FormClosed += new FormClosedEventHandler(EditOrgForm_Closed);
                detailForm.ShowDialog();
            }
        }

        private void EditOrgForm_Closed(object sender, FormClosedEventArgs e)
        {
            int rowIndex = adgvOrg.CurrentRow.Index;
            LoadDGV();
            txtSearch_TextChanged(sender, new EventArgs());
            adgvOrg.ClearSelection();
            adgvOrg.Rows[rowIndex].Selected = true;
            adgvOrg.CurrentCell = adgvOrg.Rows[rowIndex].Cells[1];
        }

        private void adgvOrg_SortStringChanged(object sender, EventArgs e)
        {
            bs.Sort = adgvOrg.SortString;
        }

        private void adgvOrg_FilterStringChanged(object sender, EventArgs e)
        {

            string tmp = adgvOrg.FilterString;
            string pattern = @"([a-zA-Z]+)";
            MatchCollection matches = Regex.Matches(tmp, pattern);
            try
            {
                bs.Filter = adgvOrg.FilterString;
            }
            catch (Exception ex)
            {
                Utilities.ShowError(ex.Message);
            }
        }        

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string unsignSearchValue = Utilities.RemoveSign4VietnameseString(txtSearch.Text.ToUpper());
            var filteredList = list.Where(t => Utilities.RemoveSign4VietnameseString(t.Name.ToUpper()).Contains(unsignSearchValue)).ToList();
            SortableBindingList<OrganizationViewModel> sbl = new SortableBindingList<OrganizationViewModel>(filteredList);
            bs = new BindingSource();
            bs.DataSource = sbl;
            adgvOrg.DataSource = bs;
        }

        private void adgvOrg_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var orgSrc = (OrganizationViewModel)adgvOrg.Rows[e.RowIndex].DataBoundItem;
            if (orgSrc != null)
            {
                UpdateOrganizationForm detailForm = new UpdateOrganizationForm(orgSrc);
                detailForm.FormClosed += new FormClosedEventHandler(EditOrgForm_Closed);
                detailForm.ShowDialog();
            }
        }
    }
}
