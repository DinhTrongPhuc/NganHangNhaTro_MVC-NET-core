using Microsoft.AspNetCore.Mvc;
using NganHangNhaTroWeb.Models;

namespace NganHangNhaTroWeb.Controllers
{
    public class HomeUserController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeUserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(decimal? minPrice, decimal? maxPrice)
        {
            var query = _context.Properties.AsQueryable();

            if(minPrice.HasValue)
                query = query.Where(p => p.Price >= minPrice.Value);
            if(maxPrice.HasValue)
                query = query.Where(p => p.Price <= maxPrice.Value);

            return View(query.ToList());
        }
    }
}
