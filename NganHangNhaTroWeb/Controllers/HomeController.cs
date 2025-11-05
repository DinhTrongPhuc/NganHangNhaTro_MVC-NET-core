using Microsoft.AspNetCore.Mvc;
using NganHangNhaTroWeb.Models;
namespace NganHangNhaTroWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Login", "Account");
        }
    }
}