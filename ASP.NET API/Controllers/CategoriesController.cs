using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP.NET_API.Entities;
using Microsoft.AspNetCore.Authorization;

namespace ASP.NET_API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    [Authorize(Policy = "ValidYearOld")]
    public class CategoriesController : ControllerBase
    {
        private readonly AspNetApiContext _context;

        public CategoriesController(AspNetApiContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        //[Authorize(Policy = "ValidYearOld")]
        [AllowAnonymous]
        public IActionResult index()
        {
            var products = _context.Categories.ToList<Category>();
            return Ok(products);
        }   

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public IActionResult get(int id)
        {
            // var category = _context.Categories.Find(id);
            var category = _context.Categories.Where(c => c.Id == id)
                .Include(category => category.Products)
                .First();

            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }


        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Created($"/get-by-id?id={category.Id}", category);
        }
       

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public IActionResult update(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            return NoContent();
        }


        // DELETE: api/Categories/5
        [HttpDelete]
        public IActionResult delete(int id)
        {
            var productdelete = _context.Categories.Find(id);
            if (productdelete == null)
                return NotFound();
            _context.Categories.Remove(productdelete);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
