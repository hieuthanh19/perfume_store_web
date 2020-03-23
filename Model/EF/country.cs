namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class country
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public country()
        {
            brands = new HashSet<brand>();
        }

        [Key, Display(Name = "ID")]
        public int country_id { get; set; }

        [Display(Name = "Country Name"), StringLength(100), Required(ErrorMessage = "Please enter country name")]
        public string country_name { get; set; }

        [Display(Name = "Status"), Range(0, 1)]
        public int? country_status { get; set; }

        [Column(TypeName = "datetime2"), Display(Name = "Created At")]
        public DateTime? country_createdAt { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<brand> brands { get; set; }
    }
}
