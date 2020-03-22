namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("deliveryMethod")]
    public partial class deliveryMethod
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public deliveryMethod()
        {
            orders = new HashSet<order>();
        }

        [Key]
        public int delivery_id { get; set; }

        [StringLength(100)]
        public string delivery_name { get; set; }

        [Column(TypeName = "text")]
        public string delivery_description { get; set; }

        public int? delivery_status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order> orders { get; set; }
    }
}
