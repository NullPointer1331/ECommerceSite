using ECommerceSite.Data;
using ECommerceSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSite.Controllers
{
    public class ProductController : Controller
    {
        private readonly PetStoreContext _context;

        public ProductController(PetStoreContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if(ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                ViewData["Message"] = "Product added successfully!";
                return View();
            }
            return View(product);
        }
    }
}
