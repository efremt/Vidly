﻿using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Vidly.Models
{
    using Vidly.Models.ViewModel;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies{ get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<GenreType> GenreTypes { get; set; }
    
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}