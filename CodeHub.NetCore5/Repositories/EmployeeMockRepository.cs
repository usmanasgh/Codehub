using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeHub.NetCore5.Interface;
using CodeHub.NetCore5.Models;

namespace CodeHub.NetCore5.Repositories
{
    public class EmployeeMockRepository : IEmployeeRepository
    {
        private List<Employee> employeeList;
        public EmployeeMockRepository()
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

        public Employee Update(Employee employeeChanges)
        {
            Employee employee = employeeList.FirstOrDefault(x => x.Id == employeeChanges.Id);

            if (employee != null)
            {
                employee.Name = employeeChanges.Name;
                employee.Email = employeeChanges.Email;
                employee.Email = employeeChanges.Email;
            }

            return employee;
        }

        public Employee Delete(int Id)
        {
            Employee employee = employeeList.FirstOrDefault(x => x.Id == Id);
            
            if(employee != null)
            {
                employeeList.Remove(employee);
            }

            return employee;
        }

        public IEnumerable<DeptHeadCount> EmployeeCountByDept(DepartmentEnum? dept)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> Search(string searchTerm = null)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return employeeList;
            }

            return employeeList.Where(e => e.Name.Contains(searchTerm) ||
                                            e.Email.Contains(searchTerm)).ToList();
        }

    }
}
