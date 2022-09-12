using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeHub.NetCore5.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeHub.NetCore5.DAL
{
    public static class ModelBuilderExtension
    {
        public static void SeedEmployees(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 1,
                Name = "Usman Asghar",
                Email = "usmanasgh@gmail.com",
                Department = DepartmentEnum.IT
            },
            new Employee
            {
                Id = 2,
                Name = "Roham bin Usman",
                Email = "rohambinusman@gmail.com",
                Department = DepartmentEnum.IT
            });
        }
    }
}
