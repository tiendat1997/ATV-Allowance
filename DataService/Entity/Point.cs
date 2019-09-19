namespace DataService.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Point")]
    public partial class Point
    {
        public int Id { get; set; }

        public int? ArticleEmployeeId { get; set; }

        [Column("Point")]
        public int? Point1 { get; set; }

        public int? Type { get; set; }

        public virtual ArticleEmployee ArticleEmployee { get; set; }

        public virtual PointType PointType { get; set; }
    }
}
