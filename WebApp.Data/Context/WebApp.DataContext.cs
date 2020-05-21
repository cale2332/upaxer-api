
using WebApp.Entities;
using Microsoft.EntityFrameworkCore;
using WebApp.Common;
using System;

namespace WebApp.Data.Context
{
    public class WebAppDataContext : DbContext
    {
        public WebAppDataContext(DbContextOptions<WebAppDataContext> options)
            : base(options)
        {
        }

        //example




        //public virtual DbSet<AppUser> Users { get; set; }
        //public virtual DbSet<AppRole> Roles { get; set; }
        //public virtual DbSet<AppRoleClaim> RolesClaims { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AppUser>().ToTable("Users", "Security").HasKey(e => e.Id);
            base.OnModelCreating(builder);
        }
    }
}
