using API_CRUD_OPERATION.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_CRUD_OPERATION.Controllers
{
    public class EmployeesController : ApiController
    {
        CompanyDBContext context = new CompanyDBContext();
        
        [HttpGet, Route("api/Employees/GetAll")]
        public IHttpActionResult AllEmps()
        {
            List<Employee> employees = context.Employees.ToList();
            if (employees.Count < 1)
            {
                return NotFound();
            }
            return Ok(employees);
        }
        [HttpPost, Route("api/Employees/Add")]
        public IHttpActionResult AddEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                context.Employees.Add(employee);
                try
                {
                    context.SaveChanges();
                    return Ok(employee);
                    //return Created($"api/Employee/GetEmp/{employee.ID}", employee);
                    //return CreatedAtRoute("DefaultApi", new { id = employee.ID },employee);
                }
                catch (Exception)
                {
                    if (context.Employees.Find(employee.ID) != null)
                    {
                        return BadRequest("Duplicated Value");
                    }
                    throw;
                }
            }
        }
        [HttpPut, Route("api/Employees/Edit")]
        public IHttpActionResult EditEmployee([FromBody] Employee employee, [FromUri] int ID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                if (employee.ID == ID)
                {
                    context.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                    try
                    {
                        context.SaveChanges();
                        return Ok();
                    }
                    catch (Exception)
                    {
                        return NotFound();
                        throw;
                    }
                    
                }
                return BadRequest();
            }
        }
    }
}
