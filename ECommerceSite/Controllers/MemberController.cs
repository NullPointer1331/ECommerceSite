using Microsoft.AspNetCore.Mvc;

namespace ECommerceSite.Controllers
{
    public class MemberController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
