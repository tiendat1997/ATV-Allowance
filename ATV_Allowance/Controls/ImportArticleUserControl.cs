﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ATV_Allowance.ViewModel;
using ATV_Allowance.Services;
using static ATV_Allowance.Common.Constants;
using ATV_Allowance.Common;
using DataService.Entity;
using ArticleType = ATV_Allowance.Common.Constants.ArticleType;

namespace ATV_Allowance.Controls
{
    public partial class ImportArticleUserControl : UserControl
    {
        private BindingSource bs = null;
        private ArticleViewModel article;
        private int articleTypeId;
        private IArticleService articleService;
        private IPointTypeService pointTypeService;
        private IEmployeeService employeeService;
        private System.Windows.Forms.ErrorProvider epArticleTitle;
        private ComboBox comboBox;
        private List<EmployeeViewModel> empList;
        private List<ArticleViewModel> articleList;
        private List<PointTypeViewModel> listPointType;
        internal Dictionary<Control, ErrorProvider> epDic;
        private DateTime currDate;
        public ImportArticleUserControl(int articleTypeId)
        {
            this.components = new System.ComponentModel.Container();
            InitializeComponent();
            InitializeErrorProvider();
            InitializeTabIndex();
            this.articleTypeId = articleTypeId;
            this.Text = GetArticleTypeName(articleTypeId);
            LoadArticleData();
            LoadDGV();
        }
        private string GetArticleTypeName(int typeId)
        {
            string typeName = "Nhập ";
            switch (typeId)
            {
                case 1:
                    typeName += "tin phát thanh";
                    break;
                case 2:
                    typeName += "tin phát thanh tt";
                    break;
                case 3:
                    typeName += "tin thời sự hàng ngày";
                    break;
                case 4:
                    typeName += "thông tin ngày mới";
                    break;
                case 5:
                    typeName += "biên soạn thông tin ngày mới";
                    break;
                case 6:
                    typeName += "khối hậu kỳ biên soạn thông tin ngày mới";
                    break;
                default:
                    break;
            }
            return typeName;
        }
        private void InitializeTabIndex()
        {
            dtpDate.TabIndex = 0;
            nudOrdinal.TabIndex = 1;
            txtTitle.TabIndex = 2;
            adgvList.TabIndex = 3;
        }

        private void InitializeErrorProvider()
        {
            epDic = new Dictionary<Control, ErrorProvider>();
            epArticleTitle = new System.Windows.Forms.ErrorProvider(components);
            epDic.Add(txtTitle, epArticleTitle);
        }
        private void InvisiblePointType()
        {
            adgvList.Columns["Tin"].Visible = false;
            adgvList.Columns["PS"].Visible = false;
            adgvList.Columns["QTin"].Visible = false;
            adgvList.Columns["QPs"].Visible = false;
            adgvList.Columns["Pv_Pb"].Visible = false;
            adgvList.Columns["Tlt"].Visible = false;
            adgvList.Columns["Sd"].Visible = false;
            adgvList.Columns["Cd_Cm"].Visible = false;
            adgvList.Columns["Bai"].Visible = false;
            adgvList.Columns["TTh_Gnh"].Visible = false;
            adgvList.Columns["CDe"].Visible = false;
            adgvList.Columns["Bs_DCT"].Visible = false;
            adgvList.Columns["Bt_Dd"].Visible = false;
            adgvList.Columns["Tl_tin"].Visible = false;
            adgvList.Columns["Thop"].Visible = false;
            // BIEN SOAN TTNM
            adgvList.Columns["Bs_TTN"].Visible = false;
            adgvList.Columns["Bs_Sapo"].Visible = false;
            adgvList.Columns["KThinh"].Visible = false;
            adgvList.Columns["TFile"].Visible = false;
            adgvList.Columns["Bt_Duyet"].Visible = false;
            // KHOI HAU KY TTNM
            adgvList.Columns["DCT"].Visible = false;
            adgvList.Columns["KTD"].Visible = false;
            adgvList.Columns["TCT"].Visible = false;
            adgvList.Columns["KT_TH"].Visible = false;
        }
        private void LoadArticleData()
        {
            try
            {
                articleService = new ArticleService();
                articleList = articleService.GetArticle(this.articleTypeId, currDate, currDate, 0);
                nudOrdinal.Maximum = articleList.Count;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }

        }
        private void LoadDGV()
        {
            try
            {
                pointTypeService = new PointTypeService();
                articleService = new ArticleService();
                employeeService = new EmployeeService();
                bs = new BindingSource();
                listPointType = pointTypeService.GetPointType(articleTypeId);
                empList = employeeService.GetAllActive(true);
                List<ArticleEmployeeViewModel> list = new List<ArticleEmployeeViewModel>();
                if (article != null)
                {
                    list = articleService.GetArticleEmployee(article.Id);
                }
                var bindList = new BindingList<ArticleEmployeeViewModel>(list);
                bs.DataSource = bindList;
                adgvList.DataSource = bs;

                adgvList.Columns["Id"].Visible = false;
                adgvList.Columns["EmployeeId"].Visible = false;
                adgvList.Columns["ArticleId"].Visible = false;
                adgvList.Columns["Code"].Visible = false;
                adgvList.Columns["Name"].Visible = true;
                adgvList.Columns["Organization"].Visible = true;
                adgvList.Columns["Position"].Visible = true;
                adgvList.Columns["Name"].ReadOnly = true;
                adgvList.Columns["Organization"].ReadOnly = true;
                adgvList.Columns["Position"].ReadOnly = true;

                adgvList.Columns["Code"].HeaderText = ADGVEmployeeText.Code;
                adgvList.Columns["Code"].Width = ControlsAttribute.GV_WIDTH_SEEM;
                adgvList.Columns["Name"].HeaderText = ADGVEmployeeText.Name;
                adgvList.Columns["Name"].Width = ControlsAttribute.GV_WIDTH_LARGE;
                adgvList.Columns["Position"].HeaderText = ADGVEmployeeText.AbbrPosition;
                adgvList.Columns["Position"].Width = ControlsAttribute.GV_WIDTH_SMALL;
                adgvList.Columns["Organization"].HeaderText = ADGVEmployeeText.Organization;
                adgvList.Columns["Organization"].Width = ControlsAttribute.GV_WIDTH_LARGE;

                if (adgvList.Columns["CbEmployeeColumn"] == null)
                {
                    DataGridViewComboBoxColumn cmbCol = new DataGridViewComboBoxColumn();
                    cmbCol.HeaderText = ADGVEmployeeText.Code;
                    cmbCol.DisplayMember = "Code";
                    cmbCol.ValueMember = "Id";
                    cmbCol.Name = "CbEmployeeColumn";
                    cmbCol.DataSource = empList;
                    adgvList.Columns.Add(cmbCol);
                    adgvList.Columns["CbEmployeeColumn"].DisplayIndex = 2;
                }

                InvisiblePointType();
                foreach (var type in listPointType)
                {
                    adgvList.Columns[type.Code].Visible = true;
                    adgvList.Columns[type.Code].HeaderText = type.Code;
                    adgvList.Columns[type.Code].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                adgvList.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(adgvList_EditingControlShowing);
                adgvList.Refresh();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                articleService = null;
            }
        }

        private void adgvList_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            comboBox = e.Control as ComboBox;
            if (comboBox != null)
            {
                comboBox.DropDownStyle = ComboBoxStyle.DropDown;
                comboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
                comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
                comboBox.SelectionChangeCommitted -= new EventHandler(SelectionChangeCommitted);
                comboBox.SelectionChangeCommitted += SelectionChangeCommitted;
                comboBox.KeyDown -= new KeyEventHandler(KeyDown);
                comboBox.KeyDown += new KeyEventHandler(KeyDown);
                comboBox.SelectedIndex = 0;
            }
        }
        private void KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) // Enter or TAB
            {
                var selectedEmp = (EmployeeViewModel)(sender as ComboBox).SelectedItem;
                if (selectedEmp != null)
                {
                    SelectionChangeCommitted(sender, null);
                }
            }
        }
        private void SelectionChangeCommitted(object sender, EventArgs e)
        {
            var selectedEmp = (EmployeeViewModel)(sender as ComboBox).SelectedItem;
            if (selectedEmp != null)
            {
                int currRowIndex = adgvList.CurrentRow.Index;
                int currColIndex = adgvList.CurrentCell.ColumnIndex;
                adgvList.Rows[currRowIndex].Cells["Name"].Value = selectedEmp.Name;
                adgvList.Rows[currRowIndex].Cells["EmployeeId"].Value = selectedEmp.Id;
                adgvList.Rows[currRowIndex].Cells["Code"].Value = selectedEmp.Code;
                adgvList.Rows[currRowIndex].Cells["CbEmployeeColumn"].Value = selectedEmp.Code;
                adgvList.Rows[currRowIndex].Cells["Position"].Value = selectedEmp.Position;
                adgvList.Rows[currRowIndex].Cells["Organization"].Value = selectedEmp.Organization;
                //adgvList.CurrentCell = adgvList.Rows[currRowIndex].Cells[8]; // the first point column index                
                adgvList.BeginEdit(true);
            }
        }
        private void EditTSForm_Load(object sender, EventArgs e)
        {
            dtpDate.Value = DateTime.Now;
            nudOrdinal.Minimum = 0;
            adgvList.ReadOnly = true;
        }

        private void adgvList_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Note the check to see if the current row is dirty
            string selectedValue = adgvList.Rows[e.RowIndex].Cells["CbEmployeeColumn"].FormattedValue.ToString();
            string currCodeValue = adgvList.Rows[e.RowIndex].Cells["Code"].FormattedValue.ToString();
            if ((string.IsNullOrEmpty(currCodeValue) || !selectedValue.Equals(currCodeValue)) && adgvList.IsCurrentRowDirty)
            {
                e.Cancel = true;
                adgvList.Rows[e.RowIndex].Cells["CbEmployeeColumn"].ErrorText = "Vui lòng chọn nhân viên";
            }
            else
            {
                adgvList.Rows[e.RowIndex].Cells["CbEmployeeColumn"].ErrorText = string.Empty;
            }

            foreach (var type in listPointType)
            {
                string typeValue = adgvList.Rows[e.RowIndex].Cells[type.Code].FormattedValue.ToString();
                int i;
                if (!int.TryParse(typeValue, out i) || i < 0)
                {
                    e.Cancel = true;
                    adgvList.Rows[e.RowIndex].Cells[type.Code].ErrorText = "Vui lòng nhập định dạng số (điểm >= 0)";
                }
                else
                {
                    adgvList.Rows[e.RowIndex].Cells[type.Code].ErrorText = string.Empty;
                }
            }
        }

        private void adgvList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //if (e.Context.ToString().Contains("Parsing"))
            //{
            //    MessageBox.Show("Vui lòng nhập định dạng số cho điểm");
            //}
        }

        private void adgvList_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                articleService = new ArticleService();
                ArticleEmployeeViewModel articleEmployee = (ArticleEmployeeViewModel)adgvList.CurrentRow.DataBoundItem;
                if (articleEmployee != null)
                {
                    if (articleEmployee.Id == 0) // Add new records 
                    {
                        articleEmployee.ArticleId = article.Id;
                        if (articleTypeId == ArticleType.THOI_SU)
                        {
                            articleService.AddArticleEmployeeTS(articleEmployee);
                        }
                        else if (articleTypeId == ArticleType.PV_TTNM)
                        {
                            articleService.AddArticleEmployeeTTNM(articleEmployee);
                        }
                        else if (articleTypeId == ArticleType.BIENSOAN_TTNM)
                        {
                            articleService.AddArticleEmployeeBSTTNM(articleEmployee);
                        }
                        else if (articleTypeId == ArticleType.KHOIHK_TTNM)
                        {
                            articleService.AddArticleEmployeeHKTTNM(articleEmployee);
                        }
                        else if (articleTypeId == ArticleType.PHAT_THANH)
                        {
                            articleService.AddArticleEmployeePT(articleEmployee);
                        }
                        else if (articleTypeId == ArticleType.PHAT_THANH_TT)
                        {
                            articleService.AddArticleEmployeePTTT(articleEmployee);
                        }
                    }
                    else
                    {
                        if (articleTypeId == ArticleType.THOI_SU)
                        {
                            articleService.UpdateArticleEmployeeTS(articleEmployee);
                        }
                        else if (articleTypeId == ArticleType.PV_TTNM)
                        {
                            articleService.UpdateArticleEmployeeTTNM(articleEmployee);
                        }
                        else if (articleTypeId == ArticleType.BIENSOAN_TTNM)
                        {
                            articleService.UpdateArticleEmployeeBSTTNM(articleEmployee);
                        }
                        else if (articleTypeId == ArticleType.KHOIHK_TTNM)
                        {
                            articleService.UpdateArticleEmployeeHKTTNM(articleEmployee);
                        }
                        else if (articleTypeId == ArticleType.PHAT_THANH)
                        {
                            articleService.UpdateArticleEmployeePT(articleEmployee);
                        }
                        else if (articleTypeId == ArticleType.PHAT_THANH_TT)
                        {
                            articleService.UpdateArticleEmployeePTTT(articleEmployee);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                articleService = null;
            }
        }

        private void adgvList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0) //Index of your DataGridViewComboBoxColumn 
            {
                if (adgvList.Rows[e.RowIndex].IsNewRow == false)
                {
                    var data = (ArticleEmployeeViewModel)adgvList.Rows[e.RowIndex].DataBoundItem;
                    e.Value = data.Code;
                }
            }
        }
        private void adgvList_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
        }

        private void adgvList_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                articleService = new ArticleService();
                if (adgvList.CurrentRow.IsNewRow == false)
                {
                    ArticleEmployeeViewModel articleEmployee = (ArticleEmployeeViewModel)adgvList.CurrentRow.DataBoundItem;
                    if (articleEmployee != null)
                    {
                        articleEmployee.ArticleId = article.Id;
                        articleService.RemoveArticleEmployee(articleEmployee);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                articleService = null;
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            currDate = Utilities.RemoveTimePortion(dtpDate.Value);
            LoadArticleData();
            // set the new index
            nudOrdinal.Value = articleList.Count;
            ResetDGV();
        }

        private void txtTitle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return) // ENTER

            {
                // Then Do your Thang
                try
                {
                    articleService = new ArticleService();
                    // validation            
                    if (string.IsNullOrEmpty(txtTitle.Text))
                    {
                        epArticleTitle.SetError(txtTitle, "Vui lòng nhập tiêu đề tin");
                    }
                    else
                    {
                        epArticleTitle.SetError(txtTitle, "");
                        if (article == null)
                        {
                            // add article                            
                            Article newEmp = new Article()
                            {
                                Title = txtTitle.Text,
                                Date = currDate,
                                TypeId = articleTypeId,
                                IsActive = true
                            };
                            articleService.AddArticle(newEmp);
                        }
                        //// load adgv                         
                        LoadArticleData();
                        int articleIndex = (int)nudOrdinal.Value;

                        article = articleList[articleIndex];
                        article.Title = txtTitle.Text;
                        articleService.UpdateArticle(article);
                        adgvList.ReadOnly = false;
                        LoadDGV();
                        this.ActiveControl = adgvList;
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    articleService = null;
                }
            }
        }

        private void nudOrdinal_ValueChanged(object sender, EventArgs e)
        {
            // change text value
            int selectedIndex = (int)nudOrdinal.Value;

            if (selectedIndex < articleList.Count)
            {
                // before new article
                article = articleList[selectedIndex];
                txtTitle.Text = article.Title;
            }
            else
            {
                // check if after new article
                article = null;
                txtTitle.Text = string.Empty;
            }
            ResetDGV();
        }

        private void ResetDGV()
        {
            adgvList.Rows.Clear();
            adgvList.ReadOnly = true;
            adgvList.Refresh();
        }

        private void nudOrdinal_Enter(object sender, EventArgs e)
        {
            nudOrdinal.Select(0, nudOrdinal.Text.Length);
        }
    }
}