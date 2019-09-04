namespace DataService.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Deduction")]
    public partial class Deduction
    {
        public int Id { get; set; }

        public int? Month { get; set; }

        public int? Year { get; set; }

        public int? Amount { get; set; }

        public int? EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
