using Microsoft.AspNetCore.Mvc;
using NganHangNhaTroWeb.Models;

namespace NganHangNhaTroWeb.Controllers
{
    public class HomeOwnerController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeOwnerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Trang chủ: danh sách phòng của chủ trọ
        public IActionResult Index()
        {
            int ownerId = (int)HttpContext.Session.GetInt32("IdUser");
            var properties = _context.Properties
                                .Where(p => p.IdOwner == ownerId)
                                .ToList();
            return View(properties);
        }

        // Thêm phòng mới
        [HttpGet]
        public IActionResult AddProperty()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProperty(Property model)
        {
            if (ModelState.IsValid)
            {
                model.IdOwner = (int)HttpContext.Session.GetInt32("IdUser");
                _context.Properties.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // Sửa phòng
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var property = _context.Properties.Find(id);
            if(property == null) return NotFound();
            return View(property);
        }

        [HttpPost]
        public IActionResult Edit(Property model)
        {
            if(ModelState.IsValid)
            {
                _context.Properties.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // Xóa phòng
        public IActionResult Delete(int id)
        {
            var property = _context.Properties.Find(id);
            if(property != null)
            {
                _context.Properties.Remove(property);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
