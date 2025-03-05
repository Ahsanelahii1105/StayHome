using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test.Data;
using test.Models;
using test.Models.Menu;

namespace test.Controllers
{
    public class AdminController : Controller
    {
        private readonly Context _context;
        public AdminController(Context context)
        {
            this._context = context;
        }
        
        // Admin HomePage Insert Form

        public async Task<IActionResult> Index(listningPropertyCreator listningPropertyCreator)
        {
            if (ModelState.IsValid)
            {
                await _context.listningPropertyCreator.AddAsync(listningPropertyCreator);
                await _context.SaveChangesAsync();
                TempData["AdminData"] = "Data Inserted";
                return RedirectToAction("Index", "Admin");
            }

            return View(listningPropertyCreator);
        }
        //----------End--------


        // Admin Agent Table

        public async Task<IActionResult> Agent()
        {
            var data = await _context.ProfileCreator.ToListAsync();

            return View(data);
        }

        public async Task<IActionResult> AgentDetails(int Id)
        {
            if (Id==null  || _context.ProfileCreator == null)
            {

                return NotFound();
            }
            var Details = await _context.ProfileCreator.FindAsync(Id);

            return View(Details);
        }

        public async Task<IActionResult> AgentEdit(int? Id)
        {
            if (Id == null || _context.ProfileCreator == null)
            {

                return NotFound();
            }
            var Edit = await _context.ProfileCreator.FindAsync(Id);

            return View(Edit);
        }

        [HttpPost]
        public async Task<IActionResult> AgentEdit(int? Id, ProfileCreator profileCreator)
        {
            if (profileCreator == null || Id == null || _context.ProfileCreator == null)
            {
                return NotFound();
            }
            _context.ProfileCreator.Update(profileCreator);
            await _context.SaveChangesAsync();

            return RedirectToAction("Agent", "Admin");
        }

        // ------------ End ---------


        public async Task<IActionResult> Saller()
        {
            var data = await _context.SallerProfileCreator.ToListAsync();

            return View(data);
        }


        public async Task<IActionResult> RegisteredUsers()
        {
            var data = await _context.Register.ToListAsync();

            return View(data);
        }

    }
}
