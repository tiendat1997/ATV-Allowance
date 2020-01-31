﻿using ATV_Allowance.Common;
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

namespace ATV_Allowance.Forms.CommonForms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            // Define the border style of the form to a dialog box.
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            // Set the MaximizeBox to false to remove the maximize box.
            this.MaximizeBox = false;

            // Set the MinimizeBox to false to remove the minimize box.
            this.MinimizeBox = false;

            // Set the start position of the form to the center of the screen.
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Session.Login(txtUsername.Text, txtPassword.Text))
                {
                    Utilities.ShowError(CommonMessage.INVALID_LOGIN);
                }
                else
                {
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                Utilities.ShowError(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }
    }
}
