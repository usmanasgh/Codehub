using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorWebAssemblyApp.Server.Interface;
using BlazorWebAssemblyApp.Shared.Business;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebAssemblyApp.Server.Models
{
    public class BusinessDepartmentRepository : IBusinessDepartmentRepository
    {
        private readonly AppDbContext appDbContext;
        public BusinessDepartmentRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
       
        public async Task<BusinessDepartment> GetDepartment(int departmentId)
        {
            return await appDbContext.BusinessDepartments
                .FirstOrDefaultAsync(d => d.DepartmentId == departmentId);
        }

        public async Task<IEnumerable<BusinessDepartment>> GetDepartments()
        {
            return await appDbContext.BusinessDepartments.ToListAsync();
        }
    }
}
