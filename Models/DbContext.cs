using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CJHillPhotography.Models
{
    // Define your DbContext class
    public class YourDbContext : DbContext
    {
        // DbSet for your User model
        public DbSet<User> Users { get; set; }

        // DbSet for your Image model
        public DbSet<Image> Images { get; set; }

        // DbSet for your CartItem model
        public DbSet<CartItem> CartItems { get; set; }

        // Constructor to specify connection string
        public YourDbContext() : base("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ImgDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartItem>()
                .Property(c => c.CartItemId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); // This configures the property as identity
        }
    }
}