using System;
using System.Collections.Generic;
using System.Text;
using Marquette_Mansions.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Marquette_Mansions.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Tennant> Tennants { get; set; }
        public DbSet<WorkOrder> WorkOrders { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>()
                .HasData(
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "Admin"
                }
                );
        }
        public DbSet<Marquette_Mansions.Models.Payment> Payment { get; set; }

        
    }
}
