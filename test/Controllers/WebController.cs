﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test.Data;
using test.Models;

namespace test.Controllers
{

    public class WebController : Controller
    {
        private readonly Context _context;

        public WebController(Context context)
        {
            this._context = context;
        }


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
        public async Task<IActionResult> Listning()
        {
            var data = await _context.listningPropertyCreator.ToListAsync();

            return View(data);

        }

        public IActionResult listingDetails()
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
        public async Task<IActionResult> Agent()
        {
            var data = await _context.ProfileCreator.ToListAsync();

            return View(data);
        }
        
        public async Task<IActionResult> ProfileView()
        {
            var data = await _context.ProfileCreator.ToListAsync();

            return View(data);
        }

        public IActionResult ProfileCreator()
        {
            //

            return View();
        }
        [HttpPost]

        
        public async Task<IActionResult> ProfileCreator(ProfileCreator profileCreator)
        {
            if (ModelState.IsValid)
            {
               await _context.ProfileCreator.AddAsync(profileCreator);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Web");
            }

            return View(profileCreator);
        }



        //public IActionResult ProfileCreator(ProfileCreator profileCreator)
        //{
        //    return View();
        //}

        public IActionResult SallerProfileCreator()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> SallerProfileCreator(SallerProfileCreator sallerProfileCreator)
        {
            if (ModelState.IsValid)
            {
                await _context.SallerProfileCreator.AddAsync(sallerProfileCreator);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Web");
            }

            return View(sallerProfileCreator);
        }
    }
}
