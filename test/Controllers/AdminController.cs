using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test.Data;
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

        public async Task<IActionResult> Index(listningPropertyCreator listningPropertyCreator)
        {
            if (ModelState.IsValid)
            {
                await _context.listningPropertyCreator.AddAsync(listningPropertyCreator);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Admin");
            }
            return View(listningPropertyCreator);
        }

        public async Task<IActionResult> Agent()
        {
            var data = await _context.ProfileCreator.ToListAsync();

            return View(data);
        }
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
