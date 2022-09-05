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

        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        public ViewResult Index()
        {
            var model = _employeeRepository.GetAllEmployee();
            return View(model);
        }

        [HttpGet]
        public ViewResult Create()
        {
            //var model = _employeeRepository.GetAllEmployee();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee) // MUA : IActionResult can work with both, RedirectToAction and Return View()
        {
            if (ModelState.IsValid)
            {
                Employee model = _employeeRepository.Add(employee);
                return RedirectToAction("Details", new { id = model.Id });
            }

            return View();
        }

        public string FirstEmployee()
        {
            return _employeeRepository.GetEmployee(1).Name;
        }

        [Route("Home/Details/{id?}")]
        public ViewResult Details(int? id)
        {
            Employee model = _employeeRepository.GetEmployee(id??1);
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
