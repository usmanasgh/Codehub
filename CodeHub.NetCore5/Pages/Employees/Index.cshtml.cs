using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeHub.NetCore5.Interface;
using CodeHub.NetCore5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CodeHub.NetCore5.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly IEmployeeRepository employeeRepository;

        // This public property holds the list of employees 
        // Display Template (Index.html) has access to this property
        public IEnumerable<Employee> Employees { get; set; }

        // Inject IEmployeeRepository service. It is this service
        // that knows how to retrieve the list of employees
        public IndexModel(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        // This method handles the GET request to /Employees/Index
        public void OnGet()
        {
            Employees = employeeRepository.GetAllEmployee();
        }
    }
}
