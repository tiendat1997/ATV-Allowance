using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATV_Allowance.Helpers
{
    public static class DialogHelper
    {
        public static DialogResult OpenConfirmationDialog(string message, string title, MessageBoxButtons msgBoxButtons)
        {
            var result = MessageBox.Show(message, title, msgBoxButtons);
            return result;
        }
        public static void OpenActionResultDialog(string message, string title)
        {
            MessageBox.Show(message, title);
        }
    }
}
