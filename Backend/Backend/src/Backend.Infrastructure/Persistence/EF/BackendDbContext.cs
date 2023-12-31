using Backend.Infrastructure.Persistence.Postgres.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Backend.Infrastructure.Persistence.EF
{
    public class BackendDbContext : DbContext
    {
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<BuyerModel> Buyers { get; set; }
        public DbSet<OrderItemModel> OrderItems { get; set; }

        public BackendDbContext(DbContextOptions<BackendDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderModel>(model =>
            {
                model.ToTable("Order");
                model.HasKey(x => x.Id);
                model.HasIndex(x => x.Id);
                model.OwnsOne(x => x.ShippingAddress);
                model.Property<DateTime>("CreatedAt");
            });

            modelBuilder.Entity<OrderItemModel>(model =>
            {
                model.ToTable("OrderItem");
                model.HasKey(x => x.Id);
                model.HasIndex(x => x.Id);

                model.HasOne(x => x.Order)
                    .WithMany(x => x.Items)
                    .HasForeignKey(x => x.Id)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<BuyerModel>(model =>
            {
                model.ToTable("Buyer");
                model.HasKey(x => x.Id);
                model.OwnsOne(x => x.Address);
                model.Property<DateTime>("CreatedAt");
            });
        }
    }
}
