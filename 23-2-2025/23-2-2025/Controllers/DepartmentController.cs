using _23_2_2025.Models;
using Microsoft.AspNetCore.Mvc;

namespace _23_2_2025.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly MyDbContext _dbContext;

        public DepartmentController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {

            var Dps = _dbContext.Departments.ToList();
            return View(Dps);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department Dps)
        {
            _dbContext.Departments.Add(Dps);
            _dbContext.SaveChanges();
            return RedirectToAction("Create");
        }
    }
}