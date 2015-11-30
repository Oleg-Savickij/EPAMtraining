namespace DBModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model : DbContext
    {
        public Model()
            : base("name=BaseModel")
        {
        }

        public virtual DbSet<Managers> Managers { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Managers>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Managers>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Managers)
                .HasForeignKey(e => e.Manager_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Orders>()
                .Property(e => e.Client)
                .IsFixedLength();

            modelBuilder.Entity<Orders>()
                .Property(e => e.Product)
                .IsFixedLength();
        }
    }
}
