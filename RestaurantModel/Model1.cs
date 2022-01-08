using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Restaurant.RestaurantModel
{
    public partial class RestaurantEntitiesModel : DbContext
    {
        public RestaurantEntitiesModel()
            : base("name=RestaurantEntititesModel")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Menu_items> Menu_items { get; set; }
        public virtual DbSet<Order_Items> Order_Items { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Table> Tables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Tables)
                .WithOptional(e => e.Employee)
                .HasForeignKey(e => e.employee_id)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Menu_items>()
                .HasMany(e => e.Order_Items)
                .WithOptional(e => e.Menu_items)
                .HasForeignKey(e => e.menu_id)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Order_Items)
                .WithOptional(e => e.Order)
                .HasForeignKey(e => e.order_id)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Reservation>()
                .Property(e => e.phone_number)
                .IsFixedLength();

            modelBuilder.Entity<Table>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Table)
                .HasForeignKey(e => e.table_id)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Table>()
                .HasMany(e => e.Reservations)
                .WithOptional(e => e.Table)
                .HasForeignKey(e => e.table_id)
                .WillCascadeOnDelete();
        }
    }
}
