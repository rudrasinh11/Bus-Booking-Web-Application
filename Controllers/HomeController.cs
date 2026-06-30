using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusBookingWebApp.Data;
using BusBookingWebApp.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BusBookingWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 🏠 Home page showing bus and tour details only
        public async Task<IActionResult> Index()
        {
            // Load all buses with their routes and schedules
            var buses = await _context.Buses
                .Include(b => b.Route)
                .Include(b => b.Schedules)
                .ToListAsync();

            return View(buses);
        }
    }
}
