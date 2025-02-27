using Microsoft.AspNetCore.Mvc;

namespace test.Controllers
{
    public class WebController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Contactus()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Listning()
        {
            return View();
        }
        public IActionResult service()
        {
            return View();
        }
        public IActionResult Blogs()
        {
            return View();
        }
        public IActionResult Agent()
        {
            return View();
        }
    }
}
