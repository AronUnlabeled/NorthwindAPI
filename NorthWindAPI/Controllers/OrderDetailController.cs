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
    public class OrderDetailController : ControllerBase
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
        public OrderDetail GetProductById(int Id)
        {
            OrderDetail result = null;
            using (NorthwindContext context = new NorthwindContext())
            {
                result = context.OrderDetails.Find(Id); 
            }
            return result;
        }

    }


}
    

