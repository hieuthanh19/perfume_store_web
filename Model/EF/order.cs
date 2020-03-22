namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public order()
        {
            orderItems = new HashSet<orderItem>();
        }

        [Key]
        public int order_id { get; set; }

        public int user_id { get; set; }

        public int? order_paymentStatus { get; set; }

        public int? order_handledBy { get; set; }

        public int? order_status { get; set; }

        public int? order_paymentMethod { get; set; }

        public double? order_totalCost { get; set; }

        [StringLength(100)]
        public string order_receiverName { get; set; }

        [Column(TypeName = "text")]
        public string order_receiverAddress { get; set; }

        [StringLength(20)]
        public string order_receiverPhone { get; set; }

        [StringLength(100)]
        public string order_receiverEmail { get; set; }

        public int? deliveryMethod_id { get; set; }

        public int? order_deliveryStatus { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? order_createdAt { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? order_updatedAt { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? order_deliveredAt { get; set; }

        public virtual deliveryMethod deliveryMethod { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<orderItem> orderItems { get; set; }

        public virtual paymentMethod paymentMethod { get; set; }

        public virtual user user { get; set; }
    }
}
