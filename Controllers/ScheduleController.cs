using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusBookingWebApp.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BusBookingWebApp.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ScheduleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ✅ Search by route or bus name
        public async Task<IActionResult> Index(string search)
        {
            var schedules = _context.Schedules
                .Include(s => s.Bus)
                .ThenInclude(b => b.Route)
                .Include(s => s.Bookings)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim().ToLower();

                schedules = schedules.Where(s =>
                    s.Bus.Name.ToLower().Contains(search) ||
                    s.Bus.Route.From.ToLower().Contains(search) ||
                    s.Bus.Route.To.ToLower().Contains(search));
            }

            var result = await schedules.ToListAsync();
            return View(result);
        }
    }
}
