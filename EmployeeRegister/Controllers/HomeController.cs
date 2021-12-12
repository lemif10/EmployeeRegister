using Microsoft.AspNetCore.Mvc;

namespace EmployeeRegister.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult HomePage()
        {
            return View();
        }
    }
}
