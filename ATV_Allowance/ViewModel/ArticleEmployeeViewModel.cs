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
        public double Tin { get; set; }
        public double PS { get; set; }
        public double QTin { get; set; }
        public double QPs { get; set; }
    }

    public class ArticleEmployeeThongTinNgayMoiViewModel : ArticleEmployeeViewModel
    {
        public double Tin { get; set; }
        public double PS { get; set; }
        public double QTin { get; set; }
        public double QPs { get; set; }
        public double Tl_Tin { get; set; }
        public double Thop { get; set; }
    }

    public class ArticleEmployeePhatThanhViewModel : ArticleEmployeeViewModel
    {
        public double Tin { get; set; }
        public double Pv_Pb { get; set; }
        public double Tlt { get; set; }
        public double Sd { get; set; }
        public double Cd_Cm { get; set; }
        public double Bai { get; set; }
    }

    public class ArticleEmployeePhatThanhTTViewModel : ArticleEmployeeViewModel
    {
        public double Tin { get; set; }
        public double Pv_Pb { get; set; }
        public double TTh_Gnh { get; set; }
        public double CDe { get; set; }
        public double Bs_DCT { get; set; }
        public double Bt_Dd { get; set; }
    }
    public class ArticleEmployeeBSTTNMViewModel : ArticleEmployeeViewModel
    {
        // BIEN SOAN TTNM
        public double Bs_TTN { get; set; }
        public double Bs_Sapo { get; set; }
        public double KThinh { get; set; }
        public double TFile { get; set; }
        public double Bt_Duyet { get; set; }
    }

    public class ArticleEmployeeHauKyViewModel : ArticleEmployeeViewModel
    {
        // KHOI HAU KY BIEN SOAN TTNM
        public double DCT { get; set; }
        public double KTD { get; set; }
        public double TCT { get; set; }
        public double KT_TH { get; set; }
    }
}
