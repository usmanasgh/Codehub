using BlazorWebAssemblyApp.Shared.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWebAssemblyApp.Server.Interface
{
    public interface IBusinessEmployeeRepository
    {
        Task<IEnumerable<BusinessEmployee>> Search(string name, BusinessGender? gender);
        Task<IEnumerable<BusinessEmployee>> GetEmployees();
        Task<BusinessEmployee> GetEmployee(int employeeId);
        Task<BusinessEmployee> GetEmployeeByEmail(string email);
        Task<BusinessEmployee> AddEmployee(BusinessEmployee employee);
        Task<BusinessEmployee> UpdateEmployee(BusinessEmployee employee);
        Task DeleteEmployee(int employeeId);
    }
}
