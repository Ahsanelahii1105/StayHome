using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using test.Models;


namespace test.Controllers
{
    public class IdentityUser : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        IdentityUser(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Register(Register r)
        {
            try
            {
                var data = new IdentityUser
                {
                    Email = r.Email,
                    UserName = r.Email
                };


                if (!ModelState.IsValid)
                {
                    await _userManager.CreateAsync(data, r.Password);
                }

            }

            catch (Exception)
            {
                throw;
            }

            return RedirectToAction("Index", "Home");
        }



        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Logout()
        {
            return View();
        }
    }
}
