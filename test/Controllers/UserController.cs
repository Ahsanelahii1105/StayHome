using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using test.Models;
using test.Repository.Interface;
using test.Repository.Services;

namespace test.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IEmailSender _emailSender;

        public UserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IEmailSender emailSender)
        {

            this._userManager = userManager;
            this._signInManager = signInManager;
            this._emailSender = emailSender;
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

                if (ModelState.IsValid)
                {

                    var checkemail = await _userManager.FindByEmailAsync(r.Email);

                    if(checkemail != null)
                    {
                        ModelState.AddModelError(string.Empty, "Email is Already Exist");

                        return View(r);
                    }

                    var data = new IdentityUser
                    {
                        Email = r.Email,
                        UserName = r.Email
                    };


                    var User = await _userManager.CreateAsync(data, r.Password);

                    await _signInManager.SignInAsync(data, isPersistent: true);

                    return RedirectToAction("Login", "User");

                }

            }

            catch (Exception)
            {
                throw;
            }

            return View(r);

        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Login(Login l)
        {

            try
            {

                if (ModelState.IsValid)
                {
                    IdentityUser checkemail = await _userManager.FindByEmailAsync(l.Email);

                    if (checkemail == null)
                    {
                        ModelState.AddModelError(string.Empty, "Email is not found!");

                        return View(l);
                    }

                    if (await _userManager.CheckPasswordAsync(checkemail, l.Password)==false)
                    {
                        ModelState.AddModelError(string.Empty, "User Doen not Exist");
                        return View(l);
                    }

                    var result = await _signInManager.PasswordSignInAsync(checkemail, l.Password, isPersistent: false, lockoutOnFailure:false);

                    if (result.Succeeded)
                    {
                        var template = await _emailSender.CreateEmailTemplate(l.Email);
                        var s = await _emailSender.SendEmailAsync(l.Email, "User Register", template);

                        return RedirectToAction("Index", "Web");
                    }
                }

            }

            catch (Exception)
            {
                throw;
            }

            return View(l);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Loging", "User");
        }
    }
}
