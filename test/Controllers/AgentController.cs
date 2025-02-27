using Microsoft.AspNetCore.Mvc;

namespace test.Controllers
{
    public class AgentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddProperty()
        {
            return View();
        }
    }
}
