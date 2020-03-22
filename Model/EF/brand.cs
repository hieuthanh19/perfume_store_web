namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("brand")]
    public partial class brand
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public brand()
        {
            products = new HashSet<product>();
        }

        [Key, Display(Name = "ID")]        
        public int brand_id { get; set; }        
      
        [StringLength(200), Display(Name ="Brand Name"), Required(ErrorMessage = "Please enter brand name")]
        public string brand_name { get; set; }

        [Display(Name = "Country ID"), Required(ErrorMessage = "Please enter country name")]
        public int? country_id { get; set; }

        
        [Column(TypeName = "datetime2"), Display(Name = "Created At")]
        public DateTime? brand_createdAt { get; set; }

        [Display(Name = "Status"), Required(ErrorMessage = "Please enter brand status"), Range(0, 1)]
        public int? brand_status { get; set; }

        public virtual country country { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<product> products { get; set; }
    }
}
