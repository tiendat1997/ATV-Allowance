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
        public int SoPsu { get; set; }
        public double DiemPsu { get; set; }
        public double DiemQtin { get; set; }
        public double DiemQPsu { get; set; }
        public double TotalPoint { get; set; }
        public int IncreasePercent { get; set; }
        public int TotalCost { get; set; }
    }
}
