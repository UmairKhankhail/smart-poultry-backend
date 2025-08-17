using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using SmartPoultry.Authorization.Roles;
using SmartPoultry.Authorization.Users;
using SmartPoultry.MultiTenancy;
using SmartPoultry.Models;

namespace SmartPoultry.EntityFrameworkCore
{
    public class SmartPoultryDbContext : AbpZeroDbContext<Tenant, Role, User, SmartPoultryDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Customer> Customers { get; set; }
        //public DbSet<Supplier> Suppliers { get; set; }  
        public DbSet<Sale> Sales { get; set; }  
        public DbSet<SaleLineItem> SaleLineItems { get; set; }  
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseLineItem> PurchaseLineItems { get; set; }
        
        public SmartPoultryDbContext(DbContextOptions<SmartPoultryDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>(b =>
            {
                b.Property(x => x.Name)
                    .HasMaxLength(100)
                    .HasColumnType("varchar(100)");

                b.Property(x => x.Phone)
                    .HasMaxLength(40)
                    .HasColumnType("varchar(40)");

                b.Property(x => x.Address)
                    .HasColumnType("varchar(max)");
            });

            modelBuilder.Entity<Supplier>(b =>
            {
                b.Property(x => x.Name)
                    .HasMaxLength(100)
                    .HasColumnType("varchar(100)");

                b.Property(x => x.Phone)
                    .HasMaxLength(40)
                    .HasColumnType("varchar(40)");

                b.Property(x => x.Address)
                    .HasColumnType("varchar(max)");
            });

            modelBuilder.Entity<Category>(b => 
            {
                b.Property(x => x.Name)
                    .HasMaxLength(100)
                    .HasColumnType("varchar(100)");

                b.Property(x => x.Description)
                    .HasColumnType("varchar(max)");
            });

            modelBuilder.Entity<Item>(b =>
            {
                b.Property(x => x.Name)
                    .HasMaxLength(100)
                    .HasColumnType("varchar(100)");

                b.Property(x => x.UnitOfMeasure)
                    .HasMaxLength(20)
                    .HasColumnType("varchar(20)");

                b.Property(x => x.Description)
                    .HasColumnType("varchar(max)");

            });

            modelBuilder.Entity<Sale>(b =>
            {
                b.Property(x => x.Status)
                    .HasMaxLength(50)
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Purchase>(b =>
            {
                b.Property(x => x.Status)
                    .HasMaxLength(50)
                    .HasColumnType("varchar(50)");
            });
        }
    }
}
