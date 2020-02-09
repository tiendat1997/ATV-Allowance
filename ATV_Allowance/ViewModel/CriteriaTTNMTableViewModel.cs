using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATV_Allowance.ViewModel
{
    public class CriteriaTTNMTableViewModel
    {
        public int Id { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public double PV { get; set; }
        public double CTV { get; set; }
        public double KTDung { get; set; } // Ky Thuat Dung
        public double BanBT { get; set; } // Ban Bien Tap
        public double PTV { get; set; } // Phat Thanh Vien 
    }
}
