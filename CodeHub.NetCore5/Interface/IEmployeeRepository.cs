using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeHub.NetCore5.Models;

namespace CodeHub.NetCore5.Interface
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int Id);
        IEnumerable<Employee> GetAllEmployee();
        Employee Add(Employee employee);
        Employee Update(Employee employee);
        Employee Delete(int Id);

        IEnumerable<DeptHeadCount> EmployeeCountByDept(DepartmentEnum? dept);
    }
}
