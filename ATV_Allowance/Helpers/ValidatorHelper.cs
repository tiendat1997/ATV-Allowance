using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATV_Allowance.Helpers
{
    public static class ValidatorHelper
    {
        public static void ClearEPValidation(Dictionary<Control, ErrorProvider> errDic)
        {
            foreach (KeyValuePair<Control, ErrorProvider> entry in errDic)
            {
                entry.Value.Clear();
            }
        }
        public static void ShowValidationMessage(GroupBox wrapper, IList<ValidationFailure> errors, Dictionary<Control, ErrorProvider> errDic)
        {
            foreach (ValidationFailure error in errors)
            {
                var control = wrapper.Controls
                                .Cast<Control>()
                                .Where(c => c is TextBox || c is ComboBox)
                                .FirstOrDefault(r => r.Name.Contains(error.PropertyName));
                var dicData = errDic.FirstOrDefault(t => t.Key.Equals(control));
                if (dicData.Equals(null) == false)
                {
                    ErrorProvider ep = dicData.Value;
                    ep.SetError(control, error.ErrorMessage);
                }
            }
        }
    }
}
