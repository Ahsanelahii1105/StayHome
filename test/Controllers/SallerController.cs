using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test.Data;
using test.Models;
using test.Models.Menu;

namespace test.Controllers
{
    public class SallerController : Controller
    {
        private readonly Context _context;
        public SallerController(Context context)
        {
            this._context = context;
        }

        public async Task<IActionResult> SallerPropertyCreator(SallerPropertyCreator sallerPropertyCreator)
        {
            if (ModelState.IsValid)
            {
                await _context.SallerPropertyCreator.AddAsync(sallerPropertyCreator);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Saller");
            }

            return View(sallerPropertyCreator);
        }


        public async Task<IActionResult> Index()
        {
            var data = await _context.SallerPropertyCreator.ToListAsync();

            return View(data);
        }

        // --------------------------------------- Saller ------------------------------


        public async Task<IActionResult> SallerDetails(int Id)
        {
            if (Id == null || _context.SallerPropertyCreator == null)
            {

                return NotFound();
            }
            var Details = await _context.SallerPropertyCreator.FindAsync(Id);

            return View(Details);
        }

        public async Task<IActionResult> SallerEdit(int? Id)
        {
            if (Id == null || _context.SallerPropertyCreator == null)
            {

                return NotFound();
            }
            var Edit = await _context.SallerPropertyCreator.FindAsync(Id);

            return View(Edit);
        }

        [HttpPost]
        public async Task<IActionResult> SallerEdit(int? Id, SallerPropertyCreator sallerPropertyCreator)
        {
            if (sallerPropertyCreator == null || Id == null || _context.SallerPropertyCreator == null)
            {
                return NotFound();
            }
            _context.SallerPropertyCreator.Update(sallerPropertyCreator);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Saller");
        }

        // Delete

        public async Task<IActionResult> SallerDelete(int? Id)
        {
            if (Id == null || _context.SallerPropertyCreator == null)
            {
                return NotFound();
            }
            var delete = await _context.SallerPropertyCreator.FindAsync(Id);

            return View(delete);
        }

        [HttpPost, ActionName("SallerDelete")]
        public async Task<IActionResult> SallerDeleteConfirm(int? Id)
        {
            var delete = await _context.SallerPropertyCreator.FindAsync(Id);

            _context.SallerPropertyCreator.Remove(delete);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Saller");
        }

        // ------------ End ---------
    }
}
