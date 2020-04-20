using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Model
{
    public class ReportModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string OrganizationName { get; set; }
        public int PointType { get; set; }
        public double TotalPoint { get; set; }
        public int RoleId { get; set; }
        public int Amount { get; set; }
    }
}
