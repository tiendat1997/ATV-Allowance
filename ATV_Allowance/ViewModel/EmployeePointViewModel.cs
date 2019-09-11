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
        public int ArticleAmount { get; set; }
        public int ArticlePoint { get; set; }
        public int SpeechAmount { get; set; }
        public int SpeechPoint { get; set; }
        public int MajorAmount { get; set; }
        public int MajorPoint { get; set; }
        public int PVAmount { get; set; }
        public int PVPoint { get; set; }
        public int BSAmount { get; set; }
        public int BSPoint { get; set; }
        public int BTAmount { get; set; }
        public int BTPoint { get; set; }
        public int TotalPoint { get; set; }
        public int IncreasePercent { get; set; }
        public int TotalCost { get; set; }
    }
}
