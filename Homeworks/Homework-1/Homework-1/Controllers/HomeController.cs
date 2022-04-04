using Homework_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace Homework_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // "Get" Method for Login Page
        public IActionResult UserForm()
        {
            var user = new UserViewModel()
            {

            };
            return View(user);

        }

        // "Post" Method for Login Page
        [HttpPost]
        public IActionResult UserForm(UserViewModel model)
        {
            var user = new Response
            {
                Data = "Null",
                Success = false,
                Error = "Hatalı Giriş!"

            };

            // Checking server-side validation proceess
            if (ModelState.IsValid)
            {
                // If validations are provided, send success note to user
                var newUser = new Response
                {
                    Data = "Giriş İşlemi Başarılı! Hoşgeldiniz :)",
                    Success = true,
                    Error = "Null"

                };

                // Using custom views to display properties of the Response Class
                // Transferring data from Controller to View
                ViewData["Data"] = "<div class='data-valid'>" + "<b>" + "Data: " + newUser.Data + "</b>" + "</div>";
                ViewData["Success"] = "<div class='success-valid'>" + "<b>" + "Success: " + newUser.Success + "</b>" + "</div>";
                ViewData["Error"] = "<div class='error-valid'>" + "<b>" + "Error: " + newUser.Error + "</b>" + "</div>";

                return View();
            }

            // If validations are fail, send error note to user
            ViewData["Data"] = "<div class='data-unvalid'>" + "<b>" + "Data: " + user.Data + "</b>" + "</div>";
            ViewData["Success"] = "<div class='success-unvalid'>" + "<b>" + "Success: " + user.Success + "</b>" + "</div>";
            ViewData["Error"] = "<div class='error-unvalid'>" + "<b>" + "Error: " + user.Error + "</b>" + "</div>";


            return View(model);
        }
                                                                                   
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

