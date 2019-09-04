namespace DataService.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ArticlePointType")]
    public partial class ArticlePointType
    {
        public int Id { get; set; }

        public int ArticleTypeId { get; set; }

        public int PointTypeId { get; set; }

        public virtual ArticleType ArticleType { get; set; }

        public virtual PointType PointType { get; set; }
    }
}
