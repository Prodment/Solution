using Microsoft.EntityFrameworkCore;
using Solution.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.Server
{
    public class ApplicationContextDb : DbContext
    {
        public ApplicationContextDb(DbContextOptions<ApplicationContextDb> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Roles>().HasData(new Roles { Id = 1, DescriptionType = "Admin", Created = DateTime.Now, Updated = DateTime.Now });
            modelBuilder.Entity<Roles>().HasData(new Roles { Id = 2, DescriptionType = "Manager", Created = DateTime.Now, Updated = DateTime.Now });
            modelBuilder.Entity<Roles>().HasData(new Roles { Id = 3, DescriptionType = "Artist", Created = DateTime.Now, Updated = DateTime.Now });
        }

        public virtual DbSet<Users> User { get; set; }
        public virtual DbSet<Roles> Role { get; set; }
        public virtual DbSet<Bookings> Booking { get; set; }
        public virtual DbSet<Profile> Profile { get; set; }
    }
}
