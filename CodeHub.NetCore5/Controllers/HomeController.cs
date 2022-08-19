using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeHub.NetCore5.Interface;
using CodeHub.NetCore5.Models;

namespace CodeHub.NetCore5.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public ViewResult Index()
        {
            var model = _employeeRepository.GetAllEmployee();
            return View(model);
        }
        
        public string FirstEmployee()
        {
            return _employeeRepository.GetEmployee(1).Name;
        }

        public ViewResult Details()
        {
            Employee model = _employeeRepository.GetEmployee(1);
            ViewData["PageTitle"] = "Employee Details";
            ViewData["EmployeeModel"] = model;
            ViewBag.EmployeeViewBagModel = model;

            return View(model);
        }
        public ObjectResult DetailsInXml() // MUA : May be renamed after documentation
        {
            Employee model = _employeeRepository.GetEmployee(1);
            return new ObjectResult(model);
        }

        public JsonResult DetailsInJson() // MUA : May be renamed after documentation
        {
            Employee model = _employeeRepository.GetEmployee(1);
            return Json(model);
        }
        
        public JsonResult Index2()
        {
            return Json(new { id = 1, name = "Usman" });
        }
    }
}
