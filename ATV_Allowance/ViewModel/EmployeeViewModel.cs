using DataService.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATV_Allowance.ViewModel
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        public string Name { get; set; }

        public string Position { get; set; }
        public int PositionId { get; set; }

        public string Organization { get; set; }
        public int OrganizationId { get; set; }
        public bool IsActive { get; set; }
        public string Title { get; set; }
        public string CodeAndName { get; set; }
    }
}
