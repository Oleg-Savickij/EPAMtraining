namespace OrdersModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OrdersModel : DbContext
    {
        public OrdersModel()
            : base("name=Model")
        {
        }

        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Seller> Seller { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .Property(e => e.Client)
                .IsFixedLength();

            modelBuilder.Entity<Order>()
                .Property(e => e.Sum);
                

            modelBuilder.Entity<Product>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.Product_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Seller>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Seller>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.Seller)
                .HasForeignKey(e => e.Seller_Id)
                .WillCascadeOnDelete(false);
        }
    }
}
