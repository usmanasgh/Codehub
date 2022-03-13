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



            modelBuilder.Entity<User>().HasData(new User
            {
                Id = new Guid(),
                FirstName = "Usman",
                LastName = "Asghar",
                Username = "Admin",
                Role = new Role { Id = Enums.Role.Admin, Name = "Administrator", ShortName = "Admin" },
                Phone = "Test",
                Email = "usmanasgh@gmail.com"
            });
        }
    }
}
