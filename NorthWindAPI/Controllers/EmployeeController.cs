using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWindAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet("GetAll")]
        public List<Employee> GetAllEmployees()
        {
            List<Employee> result = new List<Employee>();
            using (NorthwindContext context = new NorthwindContext())
            {
                result = context.Employees.ToList();
            }
            return result;
        }


        [HttpGet("GetById/{Id}")]
        public Employee GetEmployeeById(int Id)
        {
            Employee result = null;
            using (NorthwindContext context = new NorthwindContext())
            {
                result = context.Employees.Find(Id); ;
            }
            return result;
        }

        [HttpPost("Add")]
        public Employee CreateEmployee(string firstName, string lastName )
        {
            Employee newEmployee = new Employee();
            newEmployee.FirstName = firstName;
            newEmployee.LastName = lastName;
            using (NorthwindContext context = new NorthwindContext())
            {
                context.Employees.Add(newEmployee);
                context.SaveChanges();
            }
            return newEmployee;
        }



    }
}
