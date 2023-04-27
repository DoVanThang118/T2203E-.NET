using Microsoft.AspNetCore.Mvc;
using T2203E_demo.Entities;

namespace T2203E_demo.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            DataContext context = new DataContext();
            return View(context);
        }
    }
}
