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
            if (ModelState.IsValid)
            {
                _db.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully!";
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        // GET
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var category = _db.Categories.FirstOrDefault(c => c.Id == id);

            if(category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Update(obj);
                    _db.SaveChanges();
                    TempData["success"] = "Category updated successfully!";
                    return RedirectToAction("Index");
                }
            }
            catch(Exception err)
            {

            }

            return View(obj);
        }

        // GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var category = _db.Categories.FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category obj)
        {
            try
            {
                _db.Remove(obj);
                _db.SaveChanges();
                TempData["success"] = "Category deleted successfully!";
            }
            catch(Exception err)
            {

            }

            return RedirectToAction("Index");
        }
    }
}
