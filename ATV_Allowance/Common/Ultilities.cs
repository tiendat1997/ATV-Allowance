﻿using ATV_Allowance.Forms.CommonForms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Collections;

namespace ATV_Allowance.Common
{
    public static class Utilities
    {
        public static Hashtable OpenedForms = new Hashtable();
        public static Hashtable MenuItemNames = new Hashtable();

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
                    case "Tin Thời sự hằng ngày":                      
                        break;
                    case "Tin Phát thanh":                        
                        break;
                    case "Tin Phát thanh trực tiếp":                        
                        break;
                    case "Danh mục thời điểm":                        
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
    }
}
