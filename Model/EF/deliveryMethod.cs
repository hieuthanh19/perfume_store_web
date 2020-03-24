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
        [DatabaseGenerated(DatabaseGeneratedOption.None), Required(ErrorMessage = "Please enter delivery id"), Display(Name = "Delivery id:")]
        public int delivery_id { get; set; }

        [StringLength(100), Required(ErrorMessage = "Please enter delivery name"), Display(Name = "Delivery name:")]
        public string delivery_name { get; set; }

        [Column(TypeName = "text"), Required(ErrorMessage = "Please enter delivery description"), Display(Name = "Delivery description:")]
        public string delivery_description { get; set; }

        [Required(ErrorMessage = "Please enter delivery status"), Display(Name = "Delivery status:")]
        public int? delivery_status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order> orders { get; set; }
    }
}
