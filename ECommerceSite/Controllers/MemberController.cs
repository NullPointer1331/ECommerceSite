using Microsoft.AspNetCore.Mvc;

namespace ECommerceSite.Controllers
{
    public class MemberController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
    }
}
