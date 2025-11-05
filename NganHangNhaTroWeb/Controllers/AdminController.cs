using Microsoft.AspNetCore.Mvc;
using NganHangNhaTroWeb.Models;

namespace NganHangNhaTroWeb.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Trang quản lý phòng trọ
        public IActionResult ManageProperties()
        {
            var properties = _context.Properties.ToList();
            return View(properties);
        }

        // Sửa phòng (giống HomeOwner)
        [HttpGet]
        public IActionResult EditProperty(int id)
        {
            var property = _context.Properties.Find(id);
            if(property == null) return NotFound();
            return View(property);
        }

        [HttpPost]
        public IActionResult EditProperty(Property model)
        {
            if(ModelState.IsValid)
            {
                _context.Properties.Update(model);
                _context.SaveChanges();
                return RedirectToAction("ManageProperties");
            }
            return View(model);
        }

        // Xóa phòng
        public IActionResult DeleteProperty(int id)
        {
            var property = _context.Properties.Find(id);
            if(property != null)
            {
                _context.Properties.Remove(property);
                _context.SaveChanges();
            }
            return RedirectToAction("ManageProperties");
        }

        // Quản lý người dùng
        public IActionResult ManageUsers()
        {
            var users = _context.Users.ToList();
            return View(users);
        }

        // Xóa user
        public IActionResult DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if(user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            return RedirectToAction("ManageUsers");
        }
    }
}
