namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("orderItem")]
    public partial class orderItem
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int order_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None), Display(Name = "Product  ID:")]
        public int product_id { get; set; }

        [Display(Name = "Order item  quantity:")]
        public int? orderItem_quantity { get; set; }
        [Display(Name = "Product price:")]
        public double? product_price { get; set; }

        public virtual order order { get; set; }

        public virtual product product { get; set; }
    }
}
