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
