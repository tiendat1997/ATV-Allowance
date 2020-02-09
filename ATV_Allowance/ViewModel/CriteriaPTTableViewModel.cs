using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATV_Allowance.ViewModel
{
    public class CriteriaPTTableViewModel
    {
        public int Id { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public double PV { get; set; }
        public double CTV { get; set; }
        public double TrichBBT { get; set; } // Trich Ban Bien Tap        
    }
}
