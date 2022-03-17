using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorWebAssemblyApp.Shared.Business;
using BlazorWebAssemblyApp.Shared.Common;

namespace BlazorWebAssemblyApp.Server.Models
{
    // MUA : Manually created.
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>().HasData(new Role { Id = Enums.Role.Admin, Name = "Administrator", ShortName = "Admin" });
            modelBuilder.Entity<Role>().HasData(new Role { Id = Enums.Role.Standard, Name = "Standard", ShortName = "Std" });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = new Guid("7C16155F-C2C9-4130-A5D1-B7B1FA44B1C7"),
                FirstName = "Usman",
                LastName = "Asghar",
                Username = "Admin",
                RoleId = (int)Enums.Role.Admin,
                Phone = "Test",
                Email = "usmanasgh@gmail.com"
            });
        }
    }
}
