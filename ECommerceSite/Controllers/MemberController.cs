using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ECommerceSite.Models;
using ECommerceSite.Data;

namespace ECommerceSite.Controllers
{
    public class MemberController : Controller
    {
        private readonly PetStoreContext _context;

        public MemberController(PetStoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                // Map RegisterViewModel to Member
                Member member = new Member
                {
                    Email = model.Email,
                    Password = model.Password
                };
                _context.Members.Add(member);
                await _context.SaveChangesAsync();
                TempData["Message"] = $"Member {member.Email} added successfully!";
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                Member member = await _context.Members
                    .Where(m => m.Email == model.Email && m.Password == model.Password)
                    .FirstOrDefaultAsync();
                if(member != null)
                {
                    TempData["Message"] = $"Welcome {member.Email}!";
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid email or password");
            }
            return View(model);
        }
    }
}
