using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeHub.NetCore5.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeHub.NetCore5.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 1,
                Name = "Usman Asghar",
                Email = "usmanasgh@gmail.com",
                Department = DepartmentEnum.IT
            });
        }
    }
}
