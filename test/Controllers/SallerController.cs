using Microsoft.AspNetCore.Mvc;

namespace test.Controllers
{
    public class SallerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddSallerProperty()
        {
            return View();
        }
    }
}
