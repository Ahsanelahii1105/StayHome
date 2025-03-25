using Microsoft.AspNetCore.Authentication;

using Microsoft.AspNetCore.Mvc;
using test.Data;
using test.Models;
using test.Repositories.Interfaces;
using test.Repository.Interface;
using test.Repository.Services;

namespace test.Controllers
{
    public class UserController : Controller
    {
        private readonly IAuthRepository _authRepository;
        private readonly Context _context;
        private readonly IEmailSender _EmailSender;

        public UserController(IAuthRepository authRepository, Context context, IEmailSender emailSender)
        {
            _EmailSender = emailSender;
            _authRepository = authRepository;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Users user)
        {
            if (await _authRepository.IsEmailExistsAsync(user.Email))
            {
                ModelState.AddModelError("Email", "Email is already registered.");
                return View(user);
            }



            var (isSuccess, message, userId) = await _authRepository.RegisterUserAsync(user);

            if (ModelState.IsValid)
            {

                TempData["Message"] = "Registration successful! Please log in.";
                return RedirectToAction("Login");
            }

            TempData["Error"] = "Registration failed. Try again.";
            return View();
        }


        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.SuccessMessage = TempData["Message"];
            ViewBag.ErrorMessage = TempData["ErrorMessage"];
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {

            var (isSuccess, message) = await _authRepository.LoginUserAsync(email, password);
            if (isSuccess)
            {


                bool emailSent = await _EmailSender.SendEmailAsync(email, "Login", "Your Account Approval");

                TempData["SuccessMessage"] = "Login successful! Welcome.";
                return RedirectToAction("Index", "Web");
            }
            TempData["ErrorMessage"] = message;
            return RedirectToAction("Login");


            ModelState.AddModelError(string.Empty, message);
            return View();
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData["Message"] = "You have been logged out!";
            Response.Cookies.Delete(".AspNetCore.Cookies");
            return RedirectToAction("Login");
        }

    }
}
