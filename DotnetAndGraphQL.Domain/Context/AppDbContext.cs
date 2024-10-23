using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetAndGraphQL.Domain.Context
{
    using Microsoft.EntityFrameworkCore;
    using System.Reflection.Emit;

    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Contacts)
                .WithOne(e => e.Customer)
                .HasForeignKey(e => e.CustomerId);

            base.OnModelCreating(modelBuilder);
        }
    }

}
