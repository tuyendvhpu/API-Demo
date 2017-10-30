﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeDataAccess;

namespace EmployeeService.Controllers
{
    public class EmployeesController : ApiController
    {
        public IEnumerable<Employee> Get()
        {
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                return entities.Employees.ToList();
            }
        }

        public HttpResponseMessage Get(int id)
        {
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                var entity= entities.Employees.FirstOrDefault(e => e.ID == id);
                if(entity !=null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.OK,entity.ToString());
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with id="+id.ToString()+" not found");
                }
             }
          }

        public HttpResponseMessage Post([FromBody] Employee employee)
        {
            try {
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                entities.Employees.Add(employee);
                entities.SaveChanges();
                var message = Request.CreateErrorResponse(HttpStatusCode.Created, employee.ToString());
                message.Headers.Location = new Uri(Request.RequestUri + employee.ID.ToString());
                return message;

              }
           }
           catch (Exception ex)
            {
               return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }


        }

        // Delete API
        public HttpResponseMessage Delete(int id)
        {
            try  {
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                var entity = entities.Employees.FirstOrDefault(e => e.ID == id);
                if(entity==null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with Id= " + id.ToString() + " not found");
                }

                else
                {
                    entities.Employees.Remove(entity);
                    entities.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
              }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //Update API
        public HttpResponseMessage Put(int id, [FromBody]Employee employee)
        {
            try
            {
                using (EmployeeDBEntities entities = new EmployeeDBEntities())
                {
                    var entity = entities.Employees.FirstOrDefault(e => e.ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with id = " + id.ToString() + " not found");
                    }
                    else
                    {
                        entity.FirstName = employee.FirstName;
                        entity.LastName = employee.LastName;
                        entity.Gender = employee.Gender;
                        entity.Salary = employee.Salary;
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
}
}