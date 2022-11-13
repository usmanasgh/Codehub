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

        //public IEnumerable<Employee> Get()
        //{
        //    using (CodehubEntities entities = new CodehubEntities())
        //    {
        //        var EmployeeList = (IEnumerable<Employee>)entities.Employees.ToList();

        //        return EmployeeList;
        //    }
        //}

        //public HttpResponseMessage Get(int id)
        //{
        //    using (CodehubEntities entities = new CodehubEntities())
        //    {
        //        var entity = entities.Employees.FirstOrDefault(e => e.Id == id);
        //        if (entity != null)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.OK, entity);
        //        }
        //        else
        //        {
        //            return Request.CreateErrorResponse(HttpStatusCode.NotFound,
        //                "Employee with Id " + id.ToString() + " not found");
        //        }
        //    }
        //}

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

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (CodehubEntities entities = new CodehubEntities())
                {
                    var entity = entities.Employees.FirstOrDefault(e => e.Id == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Employee with Id = " + id.ToString() + " not found to delete");
                    }
                    else
                    {
                        entities.Employees.Remove(entity);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Put(int id, [FromBody] Employee employee)
        {
            try
            {
                using (CodehubEntities entities = new CodehubEntities())
                {
                    var entity = entities.Employees.FirstOrDefault(e => e.Id == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Employee with Id " + id.ToString() + " not found to update");
                    }
                    else
                    {
                        entity.Name = employee.Name;
                        entity.Email = employee.Email;
                        entity.Department = employee.Department;
                        entity.PhotoPath = employee.PhotoPath;

                        entities.SaveChanges();

                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        #region"Custom Methods"

        /*
         MUA: By default, the HTTP verb GET is mapped to a method in a controller that has the name Get() 
         or starts with the word Get. In the following EmployeeController, the method is named Get() so 
         by convention this is mapped to the HTTP verb GET. Even if you rename it to GetEmployees() or GetSomething() 
         it will still be mapped to the HTTP verb GET as long as the name of the method is prefixed with the word Get. 
         The word Get is case-insensitive. It can be lowercase, uppercase or a mix of both.

         */

        /*
         MUA: If the method is not named Get or if it does not start with the word get then Web API does not know the method name 
         to which the GET request must be mapped and the request fails with an error message stating The requested resource 
         does not support http method 'GET' with the status code 405 Method Not Allowed. 
         In the following example, we have renamed Get() method to LoadEmployees(). When we issue a GET request the request 
         will fail, because ASP.NET Web API does not know it has to map the GET request to this method.
         */

        [HttpGet]
        public IEnumerable<Employee> LoadEmployees()
        {
            using (CodehubEntities entities = new CodehubEntities())
            {
                return entities.Employees.ToList();
            }
        }

        [HttpGet]
        public HttpResponseMessage LoadEmployeeById(int id)
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

        #endregion

    }
}
