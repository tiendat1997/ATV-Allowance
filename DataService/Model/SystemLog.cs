namespace DataService.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SystemLog")]
    public partial class SystemLog
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime Date { get; set; }

        public int TypeId { get; set; }
    }
}
