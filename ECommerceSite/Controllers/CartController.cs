using ECommerceSite.Data;
using ECommerceSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace ECommerceSite.Controllers
{
    public class CartController : Controller
    {
        private const string Cart = "Cart";
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
                CartItemViewModel cartItem = new CartItemViewModel
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = 1
                };
                List<CartItemViewModel> cartItems = GetCartData();
                if (cartItems.Any(c => c.ProductId == cartItem.ProductId))
                {
                    CartItemViewModel existingItem = cartItems.First(c => c.ProductId == cartItem.ProductId);
                    existingItem.Quantity++;
                }
                else
                {
                    cartItems.Add(cartItem);
                }

                SetCartCookie(cartItems);
                TempData["Message"] = $"Product {product.Name} added to cart";
            }
            return RedirectToAction("Index", "Product");
        }


        private List<CartItemViewModel> GetCartData()
        {
            string cookie = HttpContext.Request.Cookies[Cart];
            if (cookie.IsNullOrEmpty())
            {
                return new List<CartItemViewModel>();
            }
            else
            {
                return JsonConvert.DeserializeObject<List<CartItemViewModel>>(cookie);
            }
        }

        public IActionResult Summary()
        {
            List<CartItemViewModel> cartItems = GetCartData();
            return View(cartItems);
        }

        public IActionResult Remove(int id)
        {
            List<CartItemViewModel> cartItems = GetCartData();
            CartItemViewModel? item = cartItems.FirstOrDefault(c => c.ProductId == id);
            cartItems.Remove(item);
            SetCartCookie(cartItems);
            return RedirectToAction("Summary");
        }

        private void SetCartCookie(List<CartItemViewModel> cartItems)
        {
            HttpContext.Response.Cookies.Append(Cart, JsonConvert.SerializeObject(cartItems), new CookieOptions()
            {
                Expires = DateTime.Now.AddYears(1)
            });
        }
    }
}
