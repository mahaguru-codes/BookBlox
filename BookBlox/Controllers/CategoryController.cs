using BookBlox.Data;
using BookBlox.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookBlox.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categories = _db.Categories;
            return View(categories);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            _db.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
