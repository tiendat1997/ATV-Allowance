using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATV_Allowance.ViewModel
{
    public class CriteriaTableViewModel
    {
        public int Id { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public double PV { get; set; }
        public double CTV { get; set; }
        public double BtCTTS { get; set; }
        public double PTV { get; set; }
        public double KTDung { get; set; }
        public double TPCTTS { get; set; }
        public double PVTruc { get; set; }
        public double Vtinh { get; set; }
        public double Ngay { get; set; }
        public double TienVT { get; set; }
        public double TienDS { get; set; }
    }
}
