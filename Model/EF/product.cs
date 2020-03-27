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

        [Key, Display(Name = "ID")]
        public int product_id { get; set; }

        [StringLength(200), Display(Name = "Product Name"), Required(ErrorMessage ="Please enter Product name!")]
        public string product_name { get; set; }

        [Display(Name ="Volume (ml)"), Range(1, 1000)]
        public double? product_volume { get; set; }

        [Display(Name = "Quantity"), Range(0, 10000)]
        public int? product_quantity { get; set; }
        
        public int? category_id { get; set; }

        public int brand_id { get; set; }

        [Display(Name = "Original Price ($)"), Range(typeof(double), "0.00", "10000.00")]
        public double? product_originalPrice { get; set; }

        [Display(Name = "Current Price ($)"), Range(typeof(double), "0.00", "10000.00")]
        public double? product_currentPrice { get; set; }

        [Display(Name = "Description")]
        public string product_description { get; set; }

        [Display(Name = "Status"), Range(0, 2)]
        public int? product_status { get; set; }

        [Column(TypeName = "datetime2"), Display(Name ="Created At")]
        public DateTime? product_createdAt { get; set; }

        [Column(TypeName = "datetime2"),Display(Name = "Updated At")]
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
