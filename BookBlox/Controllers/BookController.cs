using BookBlox.Data;
using BookBlox.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookBlox.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET
        public IActionResult Index()
        {
            IEnumerable<Book> books = _db.Books;
            return View(books);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _db.Add(book);
                _db.SaveChanges();
                TempData["success"] = "Book has been created successfully!";
                return RedirectToAction("Index");
            }

            return View(book);
        }
    }
}
