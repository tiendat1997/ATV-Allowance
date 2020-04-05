using ATV_Allowance.Forms.CommonForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATV_Allowance.Helpers
{
    public class ProgressBarHelper
    {
        public static void StartLoadingReportForm()
        {
            FlashPrintForm form = new FlashPrintForm("Đang xử lý dữ liệu...");
            form.ShowDialog();
        }
    }
}
