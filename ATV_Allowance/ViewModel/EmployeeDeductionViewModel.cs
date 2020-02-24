using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATV_Allowance.ViewModel
{
    public class EmployeeDeductionViewModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public double Deduction { get; set; }
        public int DeductionType { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }
}
