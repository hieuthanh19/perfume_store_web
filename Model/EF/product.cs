namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("product")]
    public partial class product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public product()
        {
            orderItems = new HashSet<orderItem>();
            productImgs = new HashSet<productImg>();
            users = new HashSet<user>();
        }

        [Key]
        public int product_id { get; set; }

        [StringLength(200)]
        public string product_name { get; set; }

        public double? product_volumne { get; set; }

        public int? product_quantity { get; set; }

        public int? category_id { get; set; }

        public int brand_id { get; set; }

        public double? product_originalPrice { get; set; }

        public double? product_currentPrice { get; set; }

        public string product_description { get; set; }

        public int? product_status { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? product_createdAt { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? product_updatedAt { get; set; }

        public virtual brand brand { get; set; }

        public virtual category category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<orderItem> orderItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<productImg> productImgs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user> users { get; set; }
    }
}
