using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeHub.NetCore5.Interface;
using CodeHub.NetCore5.Models;
using CodeHub.NetCore5.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace CodeHub.NetCore5.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        [Obsolete]
        private readonly IHostingEnvironment hostingEnvironment;

        [Obsolete]
        public HomeController(IEmployeeRepository employeeRepository,
                              IHostingEnvironment hostingEnvironment)
        {
            _employeeRepository = employeeRepository;
            this.hostingEnvironment = hostingEnvironment;
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

        //[HttpPost]
        //public IActionResult Create(Employee employee) // MUA : IActionResult can work with both, RedirectToAction and Return View()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Employee model = _employeeRepository.Add(employee);
        //        return RedirectToAction("Details", new { id = model.Id });
        //    }

        //    return View();
        //}

        [HttpPost]
        [Obsolete]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;

                // If the Photo property on the incoming model object is not null, then the user
                // has selected an image to upload.
                if (model.Photo != null)
                {
                    // The image must be uploaded to the images folder in wwwroot
                    // To get the path of the wwwroot folder we are using the inject
                    // HostingEnvironment service provided by ASP.NET Core
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    // To make sure the file name is unique we are appending a new
                    // GUID value and and an underscore to the file name
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    // Use CopyTo() method provided by IFormFile interface to
                    // copy the file to wwwroot/images folder
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                //// MUA : For multiple files
                //if (model.Photos != null && model.Photos.Count > 0)
                //{
                //    // Loop thru each selected file
                //    foreach (IFormFile photo in model.Photos)
                //    {
                //        // The file must be uploaded to the images folder in wwwroot
                //        // To get the path of the wwwroot folder we are using the injected
                //        // IHostingEnvironment service provided by ASP.NET Core
                //        string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                //        // To make sure the file name is unique we are appending a new
                //        // GUID value and and an underscore to the file name
                //        uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                //        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                //        // Use CopyTo() method provided by IFormFile interface to
                //        // copy the file to wwwroot/images folder
                //        photo.CopyTo(new FileStream(filePath, FileMode.Create));
                //    }
                //}

                Employee newEmployee = new Employee
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department,
                    // Store the file name in PhotoPath property of the employee object
                    // which gets saved to the Employees database table
                    PhotoPath = uniqueFileName
                };

                _employeeRepository.Add(newEmployee);
                return RedirectToAction("details", new { id = newEmployee.Id });
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
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = _employeeRepository.GetEmployee(id ?? 1)
            };

            //Employee model = _employeeRepository.GetEmployee(id??1);
            ViewData["PageTitle"] = "Employee Details";
            //ViewData["EmployeeModel"] = model;
            //ViewBag.EmployeeViewBagModel = model;

            return View(homeDetailsViewModel);
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
