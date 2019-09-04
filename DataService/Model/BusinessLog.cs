namespace DataService.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BusinessLog")]
    public partial class BusinessLog
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public int ActorId { get; set; }

        public int TypeId { get; set; }
    }
}
