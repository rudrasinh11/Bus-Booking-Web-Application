using Microsoft.AspNetCore.Mvc;
using BusBookingWebApp.Data;
using BusBookingWebApp.Models;

namespace BusBookingWebApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ✅ Register Page
        [HttpGet]
        public IActionResult Register() => View();

        // ✅ Register (POST)
        [HttpPost]
        public IActionResult Register(User user)
        {
            if (_context.Users.Any(u => u.Email == user.Email))
            {
                ViewBag.Error = "Email already registered!";
                return View();
            }

            _context.Users.Add(user);
            _context.SaveChanges();

            ViewBag.Success = "Registration successful! Please login.";
            return RedirectToAction("Login");
        }

        // ✅ Login Page
        [HttpGet]
        public IActionResult Login() => View();

        // ✅ Login (POST)
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user == null)
            {
                ViewBag.Error = "Invalid credentials!";
                return View();
            }

            HttpContext.Session.SetInt32("UserId", user.Id);
            HttpContext.Session.SetString("UserName", user.UserName);
            HttpContext.Session.SetString("UserEmail", user.Email);
            HttpContext.Session.SetString("IsAdmin", user.IsAdmin.ToString());

            return RedirectToAction("Index", "Home");
        }

        // ✅ Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
