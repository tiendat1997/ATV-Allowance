using ATV_Allowance.Common;
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
    public partial class LoginFormTest : Form
    {
        public LoginFormTest()
        {
            InitializeComponent();
            this.BackColor = Color.Beige;
            this.TransparencyKey = Color.Beige;
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
            this.Close();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {

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
