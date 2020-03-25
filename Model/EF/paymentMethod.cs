namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("paymentMethod")]
    public partial class paymentMethod
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public paymentMethod()
        {
            orders = new HashSet<order>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None), Display(Name = "Payment ID:"), Required(ErrorMessage = "Please enter id")]
        public int payment_id { get; set; }

        [Required(ErrorMessage = "Please enter payment name"), Display(Name = "Payment name:"), StringLength(100)]

        public string payment_name { get; set; }

        [Column(TypeName = "text"), Required(ErrorMessage = "Please enter payment description"), Display(Name = "Payment description:")]
        public string payment_description { get; set; }

        [Required(ErrorMessage = "Please enter payment status"), Display(Name = "Payment status:")]
        public int? payment_status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order> orders { get; set; }
    }
}
