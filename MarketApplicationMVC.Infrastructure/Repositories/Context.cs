using MarketApplicationMVC.Domain.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApplicationMVC.Infrastructure.Repositories
{
    public class Context : IdentityDbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ContactInformation> ContactInformations { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<Domain.Model.Type> Types { get; set; }
        public DbSet<User> Users { get; set; }

        public Context(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasOne(a => a.Address).WithOne(b => b.User)
                .HasForeignKey<Address>(e => e.UserRef);

        }
    }
}
