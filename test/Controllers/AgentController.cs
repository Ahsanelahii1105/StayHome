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

        public async Task<IActionResult> AgentPropertyCreator(AgentPropertyCreator agentPropertyCreator)
        {
            if (ModelState.IsValid)
            {
                await _context.AgentPropertyCreator.AddAsync(agentPropertyCreator);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Agent");
            }

            return View(agentPropertyCreator);
        }


        public async Task<IActionResult> Index()
        {
            var data = await _context.AgentPropertyCreator.ToListAsync();

            return View(data);
        }

        public async Task<IActionResult> AgentDetails(int Id)
        {
            if (Id == null || _context.AgentPropertyCreator == null)
            {

                return NotFound();
            }
            var Details = await _context.AgentPropertyCreator.FindAsync(Id);

            return View(Details);
        }

        public async Task<IActionResult> AgentEdit(int? Id)
        {
            if (Id == null || _context.AgentPropertyCreator == null)
            {

                return NotFound();
            }
            var Edit = await _context.AgentPropertyCreator.FindAsync(Id);

            return View(Edit);
        }

        [HttpPost]
        public async Task<IActionResult> AgentEdit(int? Id, AgentPropertyCreator agentPropertyCreator)
        {
            if (agentPropertyCreator == null || Id == null || _context.AgentPropertyCreator == null)
            {
                return NotFound();
            }
            _context.AgentPropertyCreator.Update(agentPropertyCreator);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Agent");
        }

        // Delete

        public async Task<IActionResult> AgentDelete(int? Id)
        {
            if (Id == null || _context.AgentPropertyCreator == null)
            {
                return NotFound();
            }
            var delete = await _context.AgentPropertyCreator.FindAsync(Id);

            return View(delete);
        }

        [HttpPost, ActionName("AgentDelete")]
        public async Task<IActionResult> AgentDeleteConfirm(int? Id)
        {
            var delete = await _context.AgentPropertyCreator.FindAsync(Id);

            _context.AgentPropertyCreator.Remove(delete);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Agent");
        }

        // ------------ End ---------
    }
}
