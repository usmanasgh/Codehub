using Codehub.DAL;
using CodeHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CodeHub.Controllers
{
    public class BusinessEmployeeController : ApiController
    {
        //using (CodehubEntities entities = new CodehubEntities())
        //    {
        //        return null;
        //    }

        public IEnumerable<TempModel> Get()
        {
            using (CodehubEntities entities = new CodehubEntities())
            {
                return (IEnumerable<TempModel>)entities.BusinessEmployees.ToList();
            }
        }

        //public Employee Get(int id)
        //{
        //    using (EmployeeDBEntities entities = new EmployeeDBEntities())
        //    {
        //        return entities.Employees.FirstOrDefault(e => e.ID == id);
        //    }
        //}
    }
}
