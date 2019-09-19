namespace DataService.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Criteria
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Criteria()
        {
            CriteriaValue = new HashSet<CriteriaValue>();
        }

        public int Id { get; set; }

        [Required]
        public string DisplayName { get; set; }

        public int ArticleTypeId { get; set; }

        public int? Unit { get; set; }

        public virtual ArticleType ArticleType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CriteriaValue> CriteriaValue { get; set; }
    }
}
