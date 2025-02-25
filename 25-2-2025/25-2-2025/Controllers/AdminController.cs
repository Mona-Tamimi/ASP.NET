using _25_2_2025.Models;
using Microsoft.AspNetCore.Mvc;

namespace _25_2_2025.Controllers
{
    public class AdminController : Controller
    {

        private readonly MyDbContext _context;

        public AdminController(MyDbContext context)
        {
            _context = context;
        }

        // GET: AdminController
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Product()
        {
            return View(_context.Products.ToList());
        }

        // GET: AdminController/Details/5
        public ActionResult ProductDetails(int Id)
        {
            var product = _context.Products.Find(Id);
            return View(product);
        }

        // GET: AdminController/Create
        public IActionResult ProductCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ProductCreate(Product product)
        {
            //_context.Add(product)=_context.Products.Add(product);
            //or
            _context.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Product");
        }

        // GET: AdminController/Edit/5
        public IActionResult ProductEdit(int Id)
        {
            var product = _context.Products.Find(Id);
            return View(product);
        }

        [HttpPost]
        public IActionResult ProductEdit(Product product)
        {
            _context.Update(product);
            _context.SaveChanges();
            return RedirectToAction("Product");
        }

        public IActionResult ProductDelete(int Id)
        {
            var product = _context.Products.Find(Id);
            _context.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Product");
        }


        public ActionResult User()
        {
            return View(_context.Users.ToList());
        }

        public IActionResult UserCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UserCreate(User user)
        {
            //_context.Add(product)=_context.Products.Add(product);
            //or
            _context.Add(user);
            _context.SaveChanges();
            return RedirectToAction("User");
        }

        // GET: AdminController/Edit/5
        public IActionResult UserEdit(int Id)
        {
            var user = _context.Users.Find(Id);
            return View(user);
        }

        [HttpPost]
        public IActionResult UserEdit(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
            return RedirectToAction("User");
        }

        public IActionResult UserDelete(int Id)
        {
            var user = _context.Users.Find(Id);
            _context.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("User");
        }
    }
}
