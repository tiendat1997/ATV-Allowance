using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATV_Allowance.ViewModel
{
    public class ArticleEmployeeViewModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int ArticleId { get; set; }
        public string EmployeeCode { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Organization { get; set; }
    }

    public class ArticleEmployeeThoiSuHangNgayViewModel : ArticleEmployeeViewModel
    {
        public int Tin { get; set; }
        public int PS { get; set; }
        public int QTin { get; set; }
        public int QPs { get; set; }
    }

    public class ArticleEmployeeThongTinNgayMoiViewModel : ArticleEmployeeViewModel
    {
        public int Tin { get; set; }
        public int PS { get; set; }
        public int QTin { get; set; }
        public int QPs { get; set; }
        public int Tl_Tin { get; set; }
        public int Thop { get; set; }
    }

    public class ArticleEmployeePhatThanhViewModel : ArticleEmployeeViewModel
    {
        public int Tin { get; set; }
        public int Pv_Pb { get; set; }
        public int Tlt { get; set; }
        public int Sd { get; set; }
        public int Cd_Cm { get; set; }
        public int Bai { get; set; }
    }

    public class ArticleEmployeePhatThanhTTViewModel : ArticleEmployeeViewModel
    {
        public int Tin { get; set; }
        public int Pv_Pb { get; set; }
        public int TTh_Gnh { get; set; }
        public int CDe { get; set; }
        public int Bs_DCT { get; set; }
        public int Bt_Dd { get; set; }
    }
    public class ArticleEmployeeBSTTNMViewModel : ArticleEmployeeViewModel
    {
        // BIEN SOAN TTNM
        public int Bs_TTN { get; set; }
        public int Bs_Sapo { get; set; }
        public int KThinh { get; set; }
        public int TFile { get; set; }
        public int Bt_Duyet { get; set; }
    }

    public class ArticleEmployeeHauKyViewModel : ArticleEmployeeViewModel
    {
        // KHOI HAU KY BIEN SOAN TTNM
        public int DCT { get; set; }
        public int KTD { get; set; }
        public int TCT { get; set; }
        public int KT_TH { get; set; }
    }
}
