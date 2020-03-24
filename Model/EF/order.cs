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
        [Required(ErrorMessage = "Please enter order id"), Display(Name = "Order  ID:")]
        public int order_id { get; set; }

        [Required(ErrorMessage = "Please enter user id"), Display(Name = "User ID:")]
        public int user_id { get; set; }

        [Required(ErrorMessage = "Please enter order payment status"), Display(Name = "Order payment status:")]
        public int? order_paymentStatus { get; set; }

        [Required(ErrorMessage = "Please enter order handle by"), Display(Name = "Order handle by:")]
        public int? order_handledBy { get; set; }

        [Required(ErrorMessage = "Please enter order status"), Display(Name = "Order status:")]
        public int? order_status { get; set; }

        [/*Required(ErrorMessage = "Please enter order payment method"),*/ Display(Name = "Order payment method:")]
        public int? order_paymentMethod { get; set; }

        [Required(ErrorMessage = "Please enter order total cost"), Display(Name = "Order total cost:")]
        public double? order_totalCost { get; set; }

        [StringLength(100), Required(ErrorMessage = "Please enter order receiver name"), Display(Name = "Order receiver name:")]
        public string order_receiverName { get; set; }

        [Column(TypeName = "text"), Required(ErrorMessage = "Please enter order receiver address"), Display(Name = "Order receiver address:")]
        public string order_receiverAddress { get; set; }

        [StringLength(20), Required(ErrorMessage = "Please enter order receiver phone"), Display(Name = "Order receiver phone:")]
        public string order_receiverPhone { get; set; }

        [StringLength(100), Required(ErrorMessage = "Please enter order receiver email"), Display(Name = "Order recei email:")]
        public string order_receiverEmail { get; set; }

        [/*Required(ErrorMessage = "Please enter delivery method id"),*/ Display(Name = "Delivery method ID:")]
        public int? deliveryMethod_id { get; set; }

        [Required(ErrorMessage = "Please enter order delivery status"), Display(Name = "Order delivery status:")]
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
