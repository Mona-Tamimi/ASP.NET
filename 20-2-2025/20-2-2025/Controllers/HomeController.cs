using System.Diagnostics;
using _20_2_2025.Models;
using Microsoft.AspNetCore.Mvc;

namespace _20_2_2025.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public ActionResult Calculate()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Calculate(string firstNumber, string secondNumber, string Cal)
        {
            int a = Convert.ToInt32(firstNumber);
            int b = Convert.ToInt32(secondNumber);
            int result = 0;
            string msg = "";
            string[] operations = { "Add", "Sub", "Mul", "Div" };

            for (int i = 0; i < operations.Length; i++)
            {
                if (Cal == operations[i])
                {
                    if (Cal == "Add")
                        result = a + b;
                    else if (Cal == "Sub")
                        result = a - b;
                    else if (Cal == "Mul")
                        result = a * b;
                    else if (Cal == "Div" && b == 0)
                    {
                        msg = "Can't devide by ZERO";

                    }

                    else if (Cal == "Div" && b != 0)
                        result = a / b;




                    break;
                }
            }

            ViewBag.Result = result;
            TempData["msg"] = msg;
            return View();
        }
    }
}
