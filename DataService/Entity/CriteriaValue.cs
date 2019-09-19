namespace DataService.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CriteriaValue")]
    public partial class CriteriaValue
    {
        public int Id { get; set; }

        public int? CriteriaId { get; set; }

        public double? Value { get; set; }

        public int? ConfigurationId { get; set; }

        public virtual Configuration Configuration { get; set; }

        public virtual Criteria Criteria { get; set; }
    }
}
