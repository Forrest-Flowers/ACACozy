using Cozy.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cozy.Data.Context
{
    public class CozyDbContext : IdentityDbContext<AppUser>
    {
        //Db Sets
        //Interprate Models -> Db Entities
        //Query those entities (Tables)

        //public DbSet<Landlord> Landlords { get; set; }
        public DbSet<Home> Homes { get; set; }
        public DbSet<Lease> Leases { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }
        public DbSet<Payment> Payments { get; set; }
        //public DbSet<Tenant> Tenants { get; set; }
        public DbSet<MaintenanceStatus> MaintenanceStatuses { get; set; }

        //Setting up the provider (SQL Server) and location of the Database.
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
            {
            //bad way of providing the connection string
                optionBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=cozy;Trusted_Connection= true");
            }

        //Seeding - populate db with initial data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); //IdentityDbContext.OnModelCreating();

            modelBuilder.Entity<Home>()
                .HasOne(h => h.Landlord)
                .WithMany(l => l.Homes)
                .HasForeignKey(h => h.LandlordId)
                .HasConstraintName("ForeignKey_Home_AppUser");

            modelBuilder.Entity<Lease>()
                .HasOne(l => l.Tenant)
                .WithMany(t => t.Leases)
                .HasForeignKey(l => l.TenantId)
                .HasConstraintName("ForeignKey_Lease_AppUser");

            modelBuilder.Entity<Maintenance>()
                .HasOne(m => m.Tenant)
                .WithMany(t => t.Maintenances)
                .HasForeignKey(m => m.TenantId)
                .HasConstraintName("ForeignKey_Maintenance_AppUser");

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "Landlord", NormalizedName = "LANDLORD" },
                new IdentityRole { Name = "Tenant", NormalizedName = "TENANT" }
             );

            modelBuilder.Entity<MaintenanceStatus>().HasData(
             new MaintenanceStatus {Id = 1, Description = "New"},
             new MaintenanceStatus {Id = 2, Description = "In Progress"},
             new MaintenanceStatus {Id = 3, Description = "Closed"},
             new MaintenanceStatus {Id = 4, Description = "Cancelled"}
            );


        }
    }
}
