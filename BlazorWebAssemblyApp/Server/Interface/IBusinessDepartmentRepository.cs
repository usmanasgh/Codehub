using BlazorWebAssemblyApp.Shared.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWebAssemblyApp.Server.Interface
{
    public interface IBusinessDepartmentRepository
    {
        Task<IEnumerable<BusinessDepartment>> GetDepartments();
        Task<BusinessDepartment> GetDepartment(int departmentId);
    }
}
