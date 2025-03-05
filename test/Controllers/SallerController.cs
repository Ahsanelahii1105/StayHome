using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test.Data;
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
                return RedirectToAction("SallerPropertyCreator", "Agent");
            }

            return View(sallerPropertyCreator);
        }


        public async Task<IActionResult> SallerPropertyCreator()
        {
            var data = await _context.SallerPropertyCreator.ToListAsync();

            return View(data);
        }
    }
}
