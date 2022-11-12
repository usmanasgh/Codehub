using Codehub.DAL;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace CodeHub.Controllers
{
    public class EmployeeController : ApiController
    {

        public IEnumerable<Employee> Get()
        {
            using (CodehubEntities entities = new CodehubEntities())
            {
                var EmployeeList = (IEnumerable<Employee>)entities.Employees.ToList();

                return EmployeeList;
            }
        }

        public HttpResponseMessage Get(int id)
        {
            using (CodehubEntities entities = new CodehubEntities())
            {
                var entity = entities.Employees.FirstOrDefault(e => e.Id == id);
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                        "Employee with Id " + id.ToString() + " not found");
                }
            }
        }

        public HttpResponseMessage Post([FromBody] Employee employee)
        {
            try
            {
                using (CodehubEntities entities = new CodehubEntities())
                {
                    entities.Employees.Add(employee);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, employee);
                    message.Headers.Location = new Uri(Request.RequestUri + employee.Id.ToString());

                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
