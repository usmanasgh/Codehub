using CodeHub.NetCore5.DAL;
using CodeHub.NetCore5.Interface;
using CodeHub.NetCore5.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeHub.NetCore5.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext context;
        public EmployeeRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Employee Add(Employee employee)
        {
            //context.Add(employee);
            //context.SaveChanges();
            //return employee;

            context.Database.ExecuteSqlRaw("spInsertEmployee {0}, {1}, {2}, {3}",
                                employee.Name,
                                employee.Email,
                                employee.PhotoPath,
                                employee.Department);
            return employee;
        }

        public Employee Delete(int Id)
        {
            Employee employee = context.Employees.Find(Id);
            if(employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            //return context.Employees;

            // MUA : Simple query
            return context.Employees
                    .FromSqlRaw<Employee>("SELECT * FROM Employees")
                    .ToList();
        }

        public Employee GetEmployee(int Id)
        {
            //return context.Employees.Find(Id);

            // MUA : Using stored procedure
            return context.Employees
                           .FromSqlRaw<Employee>("spGetEmployeeById {0}", Id)
                           .ToList()
                           .FirstOrDefault();
        }

        public Employee Update(Employee employeeChanges)
        {
            var employee = context.Employees.Attach(employeeChanges);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return employeeChanges;
        }

        public IEnumerable<Employee> Search(string searchTerm = null)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return context.Employees;
            }

            return context.Employees.Where(e => e.Name.Contains(searchTerm) ||
                                            e.Email.Contains(searchTerm)).ToList();
        }


        IEnumerable<DeptHeadCount> IEmployeeRepository.EmployeeCountByDept(DepartmentEnum? dept)
        {
            //return context.Employees.GroupBy(e => e.Department).Select(g => new DeptHeadCount()
            //                                                    {
            //                                                        Department = g.Key.Value,
            //                                                        Count = g.Count()

            //                                                    }).ToList();

            IEnumerable<Employee> query = context.Employees;

            if (dept.HasValue)
            {
                query = query.Where(e => e.Department == dept.Value);
            }

            return query.GroupBy(e => e.Department)
                                .Select(g => new DeptHeadCount()
                                {
                                    Department = g.Key.Value,
                                    Count = g.Count()
                                }).ToList();
        }
    }
}
