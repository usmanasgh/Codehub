using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorWebAssemblyApp.Server.Interface;
using BlazorWebAssemblyApp.Shared.Business;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebAssemblyApp.Server.Models
{
    public class BusinessEmployeeRepository : IBusinessEmployeeRepository
    {
        private readonly AppDbContext appDbContext;
        public BusinessEmployeeRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<BusinessEmployee> AddEmployee(BusinessEmployee employee)
        {
            if (employee.Department != null)
            {
                appDbContext.Entry(employee.Department).State = EntityState.Unchanged;
            }

            var result = await appDbContext.BusinessEmployees.AddAsync(employee);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteEmployee(int employeeId)
        {
            var result = await appDbContext.BusinessEmployees
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);

            if (result != null)
            {
                appDbContext.BusinessEmployees.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<BusinessEmployee> GetEmployee(int employeeId)
        {
            return await appDbContext.BusinessEmployees
                .Include(e => e.Department)
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
        }

        public async Task<BusinessEmployee> GetEmployeeByEmail(string email)
        {
            return await appDbContext.BusinessEmployees
                .FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<IEnumerable<BusinessEmployee>> GetEmployees()
        {
            return await appDbContext.BusinessEmployees.ToListAsync();
        }

        public async Task<IEnumerable<BusinessEmployee>> Search(string name, BusinessGender? gender)
        {
            IQueryable<BusinessEmployee> query = appDbContext.BusinessEmployees;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.FirstName.Contains(name)
                            || e.LastName.Contains(name));
            }

            if (gender != null)
            {
                query = query.Where(e => e.Gender == gender);
            }

            return await query.ToListAsync();
        }

        public async Task<BusinessEmployee> UpdateEmployee(BusinessEmployee employee)
        {
            var result = await appDbContext.BusinessEmployees
                .FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);

            if (result != null)
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.Email = employee.Email;
                result.DateOfBrith = employee.DateOfBrith;
                result.Gender = employee.Gender;
                if (employee.DepartmentId != 0)
                {
                    result.DepartmentId = employee.DepartmentId;
                }
                else if (employee.Department != null)
                {
                    result.DepartmentId = employee.Department.DepartmentId;
                }
                result.PhotoPath = employee.PhotoPath;

                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}
