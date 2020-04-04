namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PerfumeStoreDbContext : DbContext
    {
        public PerfumeStoreDbContext()
            : base("name=PerfumeStore")
        {
        }

        public virtual DbSet<brand> brands { get; set; }
        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<country> countries { get; set; }
        public virtual DbSet<deliveryMethod> deliveryMethods { get; set; }
        public virtual DbSet<orderItem> orderItems { get; set; }
        public virtual DbSet<order> orders { get; set; }
        public virtual DbSet<paymentMethod> paymentMethods { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<productImg> productImgs { get; set; }
        public virtual DbSet<user_role> user_role { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<favList> favLists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<brand>()
                .Property(e => e.brand_name)
                .IsUnicode(false);

            modelBuilder.Entity<brand>()
                .Property(e => e.brand_createdAt)
                .HasPrecision(0);

            modelBuilder.Entity<brand>()
                .HasMany(e => e.products)
                .WithRequired(e => e.brand)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<category>()
                .Property(e => e.category_name)
                .IsUnicode(false);

            modelBuilder.Entity<country>()
                .Property(e => e.country_name)
                .IsUnicode(false);

            modelBuilder.Entity<country>()
                .Property(e => e.country_createdAt)
                .HasPrecision(0);

            modelBuilder.Entity<deliveryMethod>()
                .Property(e => e.delivery_name)
                .IsUnicode(false);

            modelBuilder.Entity<deliveryMethod>()
                .Property(e => e.delivery_description)
                .IsUnicode(false);

            modelBuilder.Entity<deliveryMethod>()
                .HasMany(e => e.orders)
                .WithOptional(e => e.deliveryMethod)
                .HasForeignKey(e => e.deliveryMethod_id);

            modelBuilder.Entity<order>()
                .Property(e => e.order_receiverName)
                .IsUnicode(false);

            modelBuilder.Entity<order>()
                .Property(e => e.order_receiverAddress)
                .IsUnicode(false);

            modelBuilder.Entity<order>()
                .Property(e => e.order_receiverPhone)
                .IsUnicode(false);

            modelBuilder.Entity<order>()
                .Property(e => e.order_receiverEmail)
                .IsUnicode(false);

            modelBuilder.Entity<order>()
                .Property(e => e.order_createdAt)
                .HasPrecision(0);

            modelBuilder.Entity<order>()
                .Property(e => e.order_updatedAt)
                .HasPrecision(0);

            modelBuilder.Entity<order>()
                .Property(e => e.order_deliveredAt)
                .HasPrecision(0);

            modelBuilder.Entity<order>()
                .HasMany(e => e.orderItems)
                .WithRequired(e => e.order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<paymentMethod>()
                .Property(e => e.payment_name)
                .IsUnicode(false);

            modelBuilder.Entity<paymentMethod>()
                .Property(e => e.payment_description)
                .IsUnicode(false);

            modelBuilder.Entity<paymentMethod>()
                .HasMany(e => e.orders)
                .WithOptional(e => e.paymentMethod)
                .HasForeignKey(e => e.order_paymentMethod);

            modelBuilder.Entity<product>()
                .Property(e => e.product_name)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.product_description)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.product_createdAt)
                .HasPrecision(0);

            modelBuilder.Entity<product>()
                .Property(e => e.product_updatedAt)
                .HasPrecision(0);

            modelBuilder.Entity<product>()
                .HasMany(e => e.orderItems)
                .WithRequired(e => e.product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<product>()
                .HasMany(e => e.productImgs)
                .WithRequired(e => e.product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<product>()
                .HasMany(e => e.favLists)
                 .WithRequired(e => e.product)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<productImg>()
                .Property(e => e.img_path)
                .IsUnicode(false);

            modelBuilder.Entity<user_role>()
                .Property(e => e.role_name)
                .IsUnicode(false);

            modelBuilder.Entity<user_role>()
                .HasMany(e => e.users)
                .WithRequired(e => e.user_role)
                .HasForeignKey(e => e.user_roleId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .Property(e => e.user_username)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.user_password)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.user_fullName)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.user_address)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.user_phone)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.user_email)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.user_avartar)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.user_createdAt)
                .HasPrecision(0);

            modelBuilder.Entity<user>()
                .HasMany(e => e.orders)
                .WithRequired(e => e.user)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<user>()
                .HasMany(e => e.favLists)
                .WithRequired(e => e.user)
                .WillCascadeOnDelete(false);
        }
    }
}
