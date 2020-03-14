using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATV_Allowance.Common.Actions
{
    public static class AppActions
    {
        public const string Employee_Add = "Add Employee {0}";
        public const string Employee_Update = "Update Employee {0}";
        public const string Employee_Remove = "Remove Employee {0}";

        public const string Organization_Add = "Add Organization {0}";
        public const string Organization_Update = "Update Organization {0}";

        public const string Article_Add = "Add Article {0}";
        public const string Article_Update = "Update Article {0}";
        public const string Article_Remove = "Remove Article {0}";

        public const string ArticleEmployee_Add = "Add Employee [{0}] to Article [{1}]";
        public const string ArticleEmployee_Update = "Update Employee [{0}] in Article [{1}]";
        public const string ArticleEmployee_Remove = "Remove Employee [{0}] in Article [{1}]";

        public const string Export_ThoiSu_KhoiHauKy = "Export Thoi Su - Khoi Hau Ky {0} - {1}";
        public const string Export_ThoiSu_TongHopThuLoa = "Export Thoi Su - Tong Hop Thu Lao {0} - {1}";
        public const string Export_PhatThanh = "Export Phat Thanh {0} - {1}";
        public const string Export_PhatThanhTT = "Export Phat Thanh Truc Tiep {0} - {1}";
        public const string Export_BienSoanTTNM = "Export Bien Soan Thong Tin Ngay Moi {0} - {1}";
        public const string Export_TTNM = "Export Thong tin ngay moi {0} - {1}";

        public const string SaveDeduction_PV = "Lưu giảm trừ PV tháng {0} - năm {1}";
        public const string SaveDeduction_PTV = "Lưu giảm trừ PTV tháng {0} - năm {1}";
        public const string SaveDeduction_KTD = "Lưu giảm trừ KTD tháng {0} - năm {1}";

        public const string Login = "Login";
    }
}
