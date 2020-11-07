using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeHub.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View("Login1");
        }

        [HttpPost]
        public ActionResult Index(CodeHub.ViewModel.Login Model)
        {
            if(Model.UserName=="123" && Model.Password=="123")
            {

            }
            return View("Login1");
        }
    }
}