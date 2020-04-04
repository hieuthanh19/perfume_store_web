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
            //products = new HashSet<product>();
            favLists = new HashSet<favList>();
        }

        [Key, Display(Name = "User ID")]
        public int user_id { get; set; }

        [Required]
        [StringLength(100), Display(Name = "Username")]
        public string user_username { get; set; }

        [Required]
        [StringLength(32), Display(Name = "Password")]
        public string user_password { get; set; }

        [Display(Name = "User Role ID")]
        public int user_roleId { get; set; }

        [Required]
        [StringLength(150), Display(Name = "Fullname")]
        public string user_fullName { get; set; }

        [StringLength(300), Display(Name = "Address")]
        public string user_address { get; set; }

        [StringLength(20), Display(Name = "Phone number")]
        public string user_phone { get; set; }

        [StringLength(100), Display(Name = "Email")]
        public string user_email { get; set; }

        [StringLength(200), Display(Name = "Avartar")]
        public string user_avartar { get; set; }

        [Column(TypeName = "datetime2"), Display(Name = "Create Date")]
        public DateTime? user_createdAt { get; set; }

        [Display(Name = "User Status")]
        public int? user_status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order> orders { get; set; }

        public virtual user_role user_role { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<product> products { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<favList> favLists { get; set; }
    }
}
