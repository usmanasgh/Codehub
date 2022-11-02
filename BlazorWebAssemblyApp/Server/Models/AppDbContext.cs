﻿using Microsoft.EntityFrameworkCore;
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

        public DbSet<BusinessEmployee> BusinessEmployees { get; set; }
        public DbSet<BusinessUser> BusinessUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BusinessRole>().HasData(new BusinessRole { Id = (int)Enums.Role.Admin, Name = "Administrator", ShortName = "Admin" });
            modelBuilder.Entity<BusinessRole>().HasData(new BusinessRole { Id = (int)Enums.Role.Standard, Name = "Standard", ShortName = "Std" });

            //Seed Departments Table
            modelBuilder.Entity<BusinessDepartment>().HasData(
                new BusinessDepartment { DepartmentId = 1, DepartmentName = "IT" });
            modelBuilder.Entity<BusinessDepartment>().HasData(
                new BusinessDepartment { DepartmentId = 2, DepartmentName = "HR" });
            modelBuilder.Entity<BusinessDepartment>().HasData(
                new BusinessDepartment { DepartmentId = 3, DepartmentName = "Payroll" });
            modelBuilder.Entity<BusinessDepartment>().HasData(
                new BusinessDepartment { DepartmentId = 4, DepartmentName = "Admin" });

            modelBuilder.Entity<BusinessUser>().HasData(new BusinessUser
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
