using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeHub.NetCore5.Interface;

namespace CodeHub.NetCore5.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<Employee> employeeList;
        public EmployeeRepository()
        {
            employeeList = new List<Employee>()
            {
                new Employee {Id = 1, Name = "Humayun", Department = DepartmentEnum.IT, Email ="Humayunasgh@gmail.com"},
                new Employee {Id = 2, Name = "Sana", Department = DepartmentEnum.HR, Email ="Sanaasgh@gmail.com"},
                new Employee {Id = 3, Name = "Emaan", Department = DepartmentEnum.Payroll, Email ="Emaanasgh@gmail.com"}
            };
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return employeeList;
        }

        public Employee GetEmployee(int Id)
        {
            return employeeList.FirstOrDefault(e => e.Id == Id);
        }

        public Employee Add(Employee employee)
        {
            employee.Id = employeeList.Max(x => x.Id) + 1;
            
            employeeList.Add(employee);
            
            return employee;
        }
    }
}
