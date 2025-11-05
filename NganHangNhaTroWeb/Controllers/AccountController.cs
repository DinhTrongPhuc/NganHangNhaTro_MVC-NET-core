using Microsoft.AspNetCore.Mvc;
using NganHangNhaTroWeb.Models;

namespace NganHangNhaTroWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Đăng ký
        public IActionResult Register()
        {
            return View();
        }

        // POST: Đăng ký
        [HttpPost]
        public IActionResult Register(User model)
        {
            if(ModelState.IsValid)
            {
                _context.Users.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(model);
        }

        // GET: Đăng nhập
        public IActionResult Login()
        {
            return View();
        }

        // POST: Đăng nhập
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if(user == null)
            {
                ViewBag.Error = "Sai tên đăng nhập hoặc mật khẩu!";
                return View();
            }

            // Lưu session
            HttpContext.Session.SetInt32("IdUser", user.IdUser);
            HttpContext.Session.SetString("Role", user.Role);

            // Redirect theo role
            if(user.Role == "User") return RedirectToAction("Index", "HomeUser");
            if(user.Role == "Owner") return RedirectToAction("Index", "HomeOwner");
            if(user.Role == "Admin") return RedirectToAction("Index", "Admin");

            return View();
        }

        // Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
