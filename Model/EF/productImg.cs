namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("productImg")]
    public partial class productImg
    {
        [Key]
        public int img_id { get; set; }

        public int product_id { get; set; }

        [Required]
        [StringLength(200)]
        public string img_path { get; set; }

        public int? img_status { get; set; }

        public virtual product product { get; set; }
    }
}
