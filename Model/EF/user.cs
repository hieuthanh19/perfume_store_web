namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            orders = new HashSet<order>();
            products = new HashSet<product>();
        }

        [Key]
        public int user_id { get; set; }

        [Required]
        [StringLength(100)]
        public string user_username { get; set; }

        [Required]
        [StringLength(32)]
        public string user_password { get; set; }

        public int user_roleId { get; set; }

        [Required]
        [StringLength(150)]
        public string user_fullName { get; set; }

        [StringLength(300)]
        public string user_address { get; set; }

        [StringLength(20)]
        public string user_phone { get; set; }

        [StringLength(100)]
        public string user_email { get; set; }

        [StringLength(200)]
        public string user_avartar { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? user_createdAt { get; set; }

        public int? user_status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order> orders { get; set; }

        public virtual user_role user_role { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<product> products { get; set; }
    }
}
