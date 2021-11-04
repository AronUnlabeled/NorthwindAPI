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
    public class ProductController : ControllerBase
    {


        [HttpGet("GetAll")]
        public List<Product> GetAllProducts()
        {
            List<Product> result = new List<Product>();
            using (NorthwindContext context = new NorthwindContext())
            {
                result = context.Products.ToList();
            }
            return result;
        }


        [HttpGet("GetById/{Id}")]
        public Product GetProductById(int Id)
        {
            Product result = null;
            using (NorthwindContext context = new NorthwindContext())
            {
                result = context.Products.Find(Id); ;
            }
            return result;
        }

        [HttpPost("Add")]
        public Product CreateProduct( string productName,int supplierId)
        {
            Product newProduct = new Product();
            newProduct.ProductName = productName;
            newProduct.SupplierId = supplierId;
            using (NorthwindContext context = new NorthwindContext())
            {
                context.Products.Add(newProduct);
                context.SaveChanges();
            }
            return newProduct;
        }

        [HttpDelete("delete/{id}")]
        public Product DeleteByProductId(int id)
        {
            Product result = null;
            List<OrderDetail> resultOne = null;
            using (NorthwindContext context = new NorthwindContext())
            {
                resultOne = context.OrderDetails.Where(o => o.ProductId == id).ToList();
                foreach (OrderDetail i in resultOne)
                {
                    context.OrderDetails.Remove(i);
                }
                context.SaveChanges();
                result = context.Products.Find(id);
                if (result != null)
                {
                    context.Products.Remove(result);
                }
                context.SaveChanges();
            }
            return result;
        }

    }
}
