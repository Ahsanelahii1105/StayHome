using Microsoft.AspNetCore.Mvc;

namespace test.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Agent()
        {
            return View();
        }
        public IActionResult Saler()
        {
            return View();
        }

    }
}
