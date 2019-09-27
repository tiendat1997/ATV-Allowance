using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATV_Allowance.ViewModel
{
    public class EmployeePointViewModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Organization { get; set; }
        public int SoTin { get; set; }
        public double DiemTin { get; set; }
        public int SoTTh_Gnh { get; set; }
        public double DiemTTh_Gnh { get; set; }
        public int SoCde { get; set; }
        public double DiemCde { get; set; }
        public int SoPsu { get; set; }
        public double DiemPsu { get; set; }
        public double DiemQtin { get; set; }
        public double DiemQPsu { get; set; }
        public int SoBai { get; set; }
        public double DiemBai { get; set; }
        public int SoCd { get; set; }
        public double DiemCd { get; set; }
        public int SoPv { get; set; }
        public double DiemPv { get; set; }
        public int SoTLT { get; set; }
        public double DiemTLT { get; set; }
        public int SoSD { get; set; }
        public double DiemSD { get; set; }
        public int SoBs_DCT { get; set; }
        public double DiemBs_DCT { get; set; }
        public int SoBt_Dd { get; set; }
        public double DiemBt_Dd { get; set; }
        public double Sum { get; set; }
        public double Descrease { get; set; }
        public double IncreasePercent { get; set; }
        public double TotalPoint { get; set; }
        public int TotalCost { get; set; }
    }
}
