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


        public DbSet<ForumPost> ForumPosts { get; set; }
        public DbSet<ForumThread> ForumThreads { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<OfferCategory> OfferCategories { get; set; }


        public Context(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            //User relations

            builder.Entity<Domain.Model.Type>() //type - user
                .HasMany(p => p.Users)
                .WithOne(b => b.Type)
                .IsRequired(false);

            builder.Entity<User>() //address - user
                .HasOne(a => a.Address).WithOne(b => b.User)
                .HasForeignKey<Address>(e => e.UserRef);

            builder.Entity<ContactInformation>() //contact information - user
                .HasOne(p => p.User)
                .WithMany(b => b.ContactInformations);

            //Forum relations

            builder.Entity<ForumPost>() //post - thread
                .HasOne(p => p.ForumThread)
                .WithMany(b => b.ForumPosts);

            //Market relations

            builder.Entity<Offer>() //offer price-property
                .Property(p => p.Price)
                .HasColumnType("decimal(18,4)");

            builder.Entity<Offer>() //offer - offer category
                .HasOne(p => p.OfferCategory)
                .WithMany(b => b.Offers)
                .IsRequired(false);


            

            

            

        }
    }
}
