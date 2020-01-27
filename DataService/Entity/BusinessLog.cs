namespace DataService.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BusinessLog")]
    public partial class BusinessLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public int ActorId { get; set; }

        public string Type { get; set; } // Import, Login, Logout, Export, Save
        public string Status { get; set; } // Success, Fail
        public DateTime LoggedOnDate { get; set; }
    }
}
