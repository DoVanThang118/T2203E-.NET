using ASP.NET_API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ASP.NET_API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AspNetApiContext _context;
        public ProductsController(AspNetApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult index()
        {
            // var products = _context.Products.ToList<Product>();
            var products = _context.Products.Include(p => p.Category)
                .ToArray();

            return Ok(products);
        }

        [HttpGet]
        [Route("get-by-id")]
        public IActionResult get(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return Created($"/get-by-id?id={product.Id}", product);
        }

        [HttpPut]
        public IActionResult update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        public IActionResult delete(int id)
        {
            var productdelete = _context.Products.Find(id);
            if (productdelete == null)
                return NotFound();
            _context.Products.Remove(productdelete);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
