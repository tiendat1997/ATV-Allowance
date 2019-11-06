﻿using ATV_Allowance.Forms.ArticleForms;
using ATV_Allowance.Forms.CommonForms;
using ATV_Allowance.Forms.CriteriaForms;
using ATV_Allowance.Forms.DeductionForms;
using ATV_Allowance.Forms.EmployeeForms;
using ATV_Allowance.Forms.OrganizationForms;
using ATV_Allowance.Forms.Report;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using static ATV_Allowance.Common.Constants;

namespace ATV_Allowance.Common
{
    public static class Utilities
    {
        public static Hashtable OpenedForms = new Hashtable();
        public static Hashtable MenuItemNames = new Hashtable();
        private static readonly string[] VietNamChar = new string[]
        {
           "aAeEoOuUiIdDyY",
            "áàạảãâấầậẩẫăắằặẳẵ",
            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
            "éèẹẻẽêếềệểễ",
            "ÉÈẸẺẼÊẾỀỆỂỄ",
            "óòọỏõôốồộổỗơớờợởỡ",
            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
            "úùụủũưứừựửữ",
            "ÚÙỤỦŨƯỨỪỰỬỮ",
            "íìịỉĩ",
            "ÍÌỊỈĨ",
            "đ",
            "Đ",
            "ýỳỵỷỹ",
            "ÝỲỴỶỸ"
        };

        public static void ShowMessage(string message)
        {
            var cursor = Cursor.Current;
            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowError(string message)
        {
            var cursor = Cursor.Current;
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowReturnMessage(int type, string message)
        {
            //TODO show message by type
            var cursor = Cursor.Current;
            MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool ShowConfirmMessage(string message)
        {
            bool result = false;
            var cursor = Cursor.Current;

            if (MessageBox.Show(message, "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                result = true;
            }

            return result;
        }

        public static bool IsNumberic(string strNum, out int number)
        {
            bool isNumeric = int.TryParse(strNum, out number);
            return isNumeric;
        }

        public static DateTime GetServerDateTimeNow()
        {
            DateTime dt;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ATVEntities"].ConnectionString))
            {
                var cmd = new SqlCommand("SELECT GETDATE()", conn);
                conn.Open();

                dt = (DateTime)cmd.ExecuteScalar();
            };
            return dt;
        }

        public static void LoadComboBoxOptions(ComboBox comboBox, Dictionary<int, string> pairs)
        {
            comboBox.DataSource = new BindingSource(pairs, null);
            comboBox.DisplayMember = "Value";
            comboBox.ValueMember = "Key";
        }

        public static void LoadComboBoxOptions(ComboBox comboBox, Dictionary<int, int> pairs)
        {
            comboBox.DataSource = new BindingSource(pairs, null);
            comboBox.DisplayMember = "Value";
            comboBox.ValueMember = "Key";
        }

        public static void LoadComboBoxOptions(ComboBox comboBox, Dictionary<string, string> pairs)
        {
            comboBox.DataSource = new BindingSource(pairs, null);
            comboBox.DisplayMember = "Value";
            comboBox.ValueMember = "Key";
        }

        public static void LoadComboBoxOptions(ComboBox comboBox, List<KeyValuePair<double, string>> pairs)
        {
            comboBox.DataSource = new BindingSource(pairs, null);
            comboBox.DisplayMember = "Value";
            comboBox.ValueMember = "Key";
        }

        public static void LoadComboBoxOptions(ComboBox comboBox, List<KeyValuePair<int, int>> pairs)
        {
            comboBox.DataSource = new BindingSource(pairs, null);
            comboBox.DisplayMember = "Value";
            comboBox.ValueMember = "Key";
        }
        public static void LoadComboBoxOptions(ComboBox comboBox, List<KeyValuePair<double, int>> pairs)
        {
            comboBox.DataSource = new BindingSource(pairs, null);
            comboBox.DisplayMember = "Value";
            comboBox.ValueMember = "Key";
        }

        public static int GetHourFromHourInt(int hourInt)
        {
            return hourInt / 100;
        }

        public static int GetMinuteFromHourInt(int hourInt)
        {
            return hourInt % 100;
        }

        public static string GetHourFormInt(int hourInt)
        {
            int hour = GetHourFromHourInt(hourInt);
            int minute = GetMinuteFromHourInt(hourInt);

            string result = hour.ToString("00") + ":" + minute.ToString("00");
            return result;
        }

        public static int GetHourFromHourString(string hour, string minute)
        {
            return int.Parse(hour) * 100 + int.Parse(minute);
        }

        public static int GetIntFromTextBox(TextBox textBox)
        {
            int result = 0;
            if (!string.IsNullOrWhiteSpace(textBox.Text))
            {
                int.TryParse(textBox.Text, out result);
            }

            return result;
        }

        public static double GetDoubleFromTextBox(TextBox textBox)
        {
            double result = 0;
            if (!string.IsNullOrWhiteSpace(textBox.Text))
            {
                double.TryParse(textBox.Text, out result);
            }

            return result;
        }

        public static string DoubleMoneyToText(double money)
        {
            string result = "0";

            if (money != 0)
            {
                result = String.Format("{0:0,0}", money);
            }

            return result;
        }

        public static Form OpenFormByName(string formName, out bool isLogout)
        {
            Form form = null;
            bool isFunctionLogout = false;
            if (!string.IsNullOrWhiteSpace(formName))
            {
                formName = formName.Trim();

                //Check if form is opened
                if (OpenedForms.Contains(formName))
                {
                    form = (Form)OpenedForms[formName];
                    form.Dispose();
                    if (form.IsDisposed)
                    {
                        OpenedForms.Remove(formName);
                        form = null;
                    }
                }

                switch (formName)
                {
                    case "Nhập Tin thời sự hàng ngày":
                        ImportArticleForm importTSForm = new ImportArticleForm(ArticleType.THOI_SU);
                        form = importTSForm;
                        break;
                    case "Nhập Tin, PS ttnm":
                        ImportArticleForm ttnmForm = new ImportArticleForm(ArticleType.PV_TTNM);
                        form = ttnmForm;
                        break;
                    case "Nhập Tin phát thanh":
                        ImportArticleForm importPTForm = new ImportArticleForm(ArticleType.PHAT_THANH);
                        form = importPTForm;
                        break;
                    case "Nhập Tin phát thanh tt":
                        ImportArticleForm importPTTTForm = new ImportArticleForm(ArticleType.PHAT_THANH_TT);
                        form = importPTTTForm;
                        break;
                    case "Nhập Thù lao biên soạn tnnm":
                        ImportArticleForm imporBSForm = new ImportArticleForm(ArticleType.BIENSOAN_TTNM);
                        form = imporBSForm;
                        break;
                    case "Nhập Khối hậu kỳ biên soạn tnnm":
                        ImportArticleForm importHKForm = new ImportArticleForm(ArticleType.KHOIHK_TTNM);
                        form = importHKForm;
                        break;
                    case "Xem nhanh tin":
                        ManageTSForm tsForm = new ManageTSForm();
                        form = tsForm;
                        break;
                    case "Quản lý nhân viên":
                        ListEmployeeForm listEmployeesForm = new ListEmployeeForm();
                        form = listEmployeesForm;
                        break;
                    case "In Thời sự":
                        ReportBroadcastForm reportBroadcastForm = new ReportBroadcastForm();
                        form = reportBroadcastForm;
                        break;
                    case "In Phát thanh":
                        ReportPTForm reportPTForm = new ReportPTForm();
                        form = reportPTForm;
                        break;
                    case "In Phát thanh trực tiếp":
                        ReportPTTTForm reportPTTTForm = new ReportPTTTForm();
                        form = reportPTTTForm;
                        break;
                    case "In Thông tin ngày mới":
                        ReportTTNgayMoiForm reportTTNgayMoiForm = new ReportTTNgayMoiForm();
                        form = reportTTNgayMoiForm;
                        break;
                    case "In Biên soạn thông tin ngày mới":
                        ReportBienSoanTTForm reportBienSoanTTForm = new ReportBienSoanTTForm();
                        form = reportBienSoanTTForm;
                        break;
                    case "In Khối hậu kỳ biên soạn thông tin ngày mới":
                        ReportKhoiHauKyForm reportKhoiHauKyForm = new ReportKhoiHauKyForm();
                        form = reportKhoiHauKyForm;
                        break;
                    case "Quản lý đơn vị":
                        ListOrganizationForm listOrgForm = new ListOrganizationForm();
                        form = listOrgForm;
                        break;
                    case "Quản lý chỉ tiêu":
                        ListCriteriaForm listCriteriaForm = new ListCriteriaForm();
                        form = listCriteriaForm;
                        break;
                    case "Quản lý giảm trừ":
                        ListEmployeeDeduction listEmployeeDeduction = new ListEmployeeDeduction();
                        form = listEmployeeDeduction;
                        break;
                    case "Logout":
                        Session.Logout();
                        isFunctionLogout = true;
                        break;
                    case "Exit":
                        Application.Exit();
                        break;

                }

                if (form != null)
                {
                    form.Owner = GlobalForm.ActiveForm;
                    form.MdiParent = GlobalForm.ActiveForm;
                    form.ShowInTaskbar = true;
                    form.BringToFront();
                    form.TopMost = true;
                    form.MinimizeBox = true;
                    form.WindowState = FormWindowState.Normal;
                    form.StartPosition = FormStartPosition.CenterScreen;

                    form.Show();

                    if (!OpenedForms.Contains(formName))
                    {
                        OpenedForms.Add(formName, form);
                    }
                }
            }

            isLogout = isFunctionLogout;
            return form;
        }
        public static string RemoveSign4VietnameseString(string str)
        {
            //Thay thế và lọc dấu từng char      
            for (int i = 1; i < VietNamChar.Length; i++)
            {
                for (int j = 0; j < VietNamChar[i].Length; j++)
                    str = str.Replace(VietNamChar[i][j], VietNamChar[0][i - 1]);
            }

            char[] arr = str.ToCharArray();

            arr = Array.FindAll<char>(arr, (c => (char.IsLetterOrDigit(c)
                                              || char.IsWhiteSpace(c)
                                              || c == '-')));
            str = new string(arr);
            return str;
        }
        public static DateTime RemoveTimePortion(DateTime datetime)
        {
            return new DateTime(datetime.Year, datetime.Month, datetime.Day);
        }
    }
}
