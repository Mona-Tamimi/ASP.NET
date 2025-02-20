using Microsoft.AspNetCore.Mvc;

namespace _20_2_2025.Controllers
{
    public class CookiesController : Controller
    {
        // Store data in cookies
        public IActionResult SetCookie()
        {
           

            Response.Cookies.Append("Username", "Mona Altamimi");
            Response.Cookies.Append("UserRole", "Admin");

            return Content("Cookies have been set!");
        }

        // Retrieve data from cookies
        public IActionResult GetCookie()
        {
            string username = Request.Cookies["Username"];
            string userRole = Request.Cookies["UserRole"];

            if (!string.IsNullOrEmpty(username) || !string.IsNullOrEmpty(userRole))
            {
                return Content($"Stored Cookies: Username = {username}, Role = {userRole}");
            }
            else
            {
                return Content("No cookies found.");
            }
        }

        // Remove cookies
        public IActionResult RemoveCookie()
        {
            Response.Cookies.Delete("Username");
            //Response.Cookies.Delete("UserRole");

            return Content("Cookies have been deleted!");
        }

        // Clear all cookies
        public IActionResult ClearCookies()
        {
            var cookies = Request.Cookies.Keys.ToList();
            foreach (var cookie in cookies)
            {
                Response.Cookies.Delete(cookie);
            }
            return Content("All cookies have been cleared!");
        }

    }
}