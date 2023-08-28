using ECommerceSite.Data;
using ECommerceSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSite.Controllers
{
    public class CartController : Controller
    {
        private readonly PetStoreContext _context;

        public CartController(PetStoreContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Add(int id)
        {
            Product? product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                TempData["Message"] = "Product not found";
            }
            else
            {
                TempData["Message"] = $"Product {product.Name} added to cart";
            }
            return RedirectToAction("Index", "Product");
        }
    }
}
