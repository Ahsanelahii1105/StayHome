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

        // agent details function

        public async Task<IActionResult> AgentDetails(int Id)
        {
            if (Id==null  || _context.ProfileCreator == null)
            {

                return NotFound();
            }
            var Details = await _context.ProfileCreator.FindAsync(Id);

            return View(Details);
        }


        // agent edits function

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


         
        // agent Delete function

        public async Task<IActionResult> AgentDelete(int? Id)
        {
            if (Id == null || _context.ProfileCreator == null)
            {
                return NotFound();
            }
            var delete = await _context.ProfileCreator.FindAsync(Id);

            return View(delete);
        }

        [HttpPost, ActionName("AgentDelete")]
        public async Task<IActionResult> AgentDeleteConfirm(int? Id)
        {
            var delete = await _context.ProfileCreator.FindAsync(Id);
            _context.ProfileCreator.Remove(delete);
            await _context.SaveChangesAsync();

            return RedirectToAction("Agent", "Admin");
        }

        // ------------ End ---------

        // --------------------------------------- Saller ------------------------------

        public async Task<IActionResult> Saller()
        {
            var data = await _context.SallerProfileCreator.ToListAsync();

            return View(data);
        }


        // saller details function

        public async Task<IActionResult> SallerDetails(int Id)
        {
            if (Id == null || _context.SallerProfileCreator == null)
            {

                return NotFound();
            }
            var Details = await _context.SallerProfileCreator.FindAsync(Id);

            return View(Details);
        }


        // saller edits function

        public async Task<IActionResult> SallerEdit(int? Id)
        {
            if (Id == null || _context.SallerProfileCreator == null)
            {

                return NotFound();
            }
            var Edit = await _context.SallerProfileCreator.FindAsync(Id);

            return View(Edit);
        }

        [HttpPost]
        public async Task<IActionResult> SallerEdit(int? Id, SallerProfileCreator sallerProfileCreator)
        {
            if (sallerProfileCreator == null || Id == null || _context.SallerProfileCreator == null)
            {
                return NotFound();
            }
            _context.SallerProfileCreator.Update(sallerProfileCreator);
            await _context.SaveChangesAsync();

            return RedirectToAction("Saller", "Admin");
        }

        // saller Delete function

        public async Task<IActionResult> SallerDelete(int? Id)
        {
            if (Id == null || _context.SallerProfileCreator == null)
            {
                return NotFound();
            }
            var delete = await _context.SallerProfileCreator.FindAsync(Id);

            return View(delete);
        }

        [HttpPost, ActionName("SallerDelete")]
        public async Task<IActionResult> SallerDeleteConfirm(int? Id)
        {
            var delete = await _context.SallerProfileCreator.FindAsync(Id);

            _context.SallerProfileCreator.Remove(delete);
            await _context.SaveChangesAsync();

            return RedirectToAction("Saller", "Admin");
        }

        // ------------ End ---------


        // registeration function

        //public async Task<IActionResult> RegisteredUsers()
        //{
        //    var data = await _context.Register.ToListAsync();

        //    return View(data);
        //}

    }
}
