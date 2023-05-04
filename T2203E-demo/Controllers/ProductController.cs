using Microsoft.AspNetCore.Mvc;
using T2203E_demo.Entities;

namespace T2203E_demo.Controllers
{
    public class ProductController : Controller
    {
        private readonly DataContext _context;
        public ProductController(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Product> list = _context.Products.ToList<Product>();
            ViewBag.Products = list;
            return View();
        }

        public IActionResult Edit(int Id)
        {
            var product = _context.Products.FindAsync(Id);
            return View(product);
        }
    }
}
