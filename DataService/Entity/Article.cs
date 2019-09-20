namespace DataService.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Article")]
    public partial class Article
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Article()
        {
            ArticleEmployee = new HashSet<ArticleEmployee>();
        }

        public int Id { get; set; }

        [StringLength(200)]
        public string Code { get; set; }

        [Required]
        public string Title { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public int TypeId { get; set; }

        public bool IsActive { get; set; }

        public virtual ArticleType ArticleType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArticleEmployee> ArticleEmployee { get; set; }
    }
}
