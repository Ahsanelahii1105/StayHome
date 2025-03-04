using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test.Data;
using test.Models;
using test.Models.Menu;

namespace test.Controllers
{
    public class AgentController : Controller
    {
        private readonly Context _context;
        public AgentController(Context context)
        {
            this._context = context;
        }

        public async Task<IActionResult> Index(AgentPropertyCreator agentPropertyCreator)
        {
            if (ModelState.IsValid)
            {
                await _context.AgentPropertyCreator.AddAsync(agentPropertyCreator);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Web");
            }

            return View(agentPropertyCreator);
        }


        public async Task<IActionResult> AgentPropertyCreator()
        {
            var data = await _context.AgentPropertyCreator.ToListAsync();

            return View(data);
        }
    }
}
