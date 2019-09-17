using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATV_Allowance.ViewModel
{
    public class CriteriaViewModel
    {
        public int ID { get; set; }
        public int CriteriaId { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public int Unit { get; set; }
    }
}
