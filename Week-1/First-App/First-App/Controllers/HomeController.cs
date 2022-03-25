using First_App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace First_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Sample()
        {
            var customerList = new List<CustomerViewModel>
            {
                new CustomerViewModel
                {

                FirstName = "Matt",
                LastName = "Smith",
                Age = 39,
                Address = "London",
                Id = Guid.NewGuid(),
                BirthDate = new DateTime(1982,10,28)

                },

                new CustomerViewModel
                {

                FirstName = "Samet",
                LastName = "Kayıkcı",
                Age = 29,
                Address = "İstanbul",
                Id = Guid.NewGuid(),
                BirthDate = new DateTime(1992,02,11)

                },

                new CustomerViewModel
                {

                FirstName = "Meleknur",
                LastName = "Yazlamaz",
                Age = 23,
                Address = "Mersin",
                Id = Guid.NewGuid(),
                BirthDate = new DateTime(1998,10,29)

                }
            };

            var isAdressNewYork = customerList.Where(x => x.Address.Contains("London")).Any();

            /*if (isAdressNewYork)
            {
                 return Ok(new SuccessViewModel { Message = "Matt Smith's Adress is London", StatusCode = 200 });

            } */

            // "var" is the variable type that satisfies all objects.
            // CustomerViewModel (or var) model = new CustomerViewModel();



            return View(customerList);
            // return Json(model);
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

        public IActionResult BadReq()
        {
            return BadRequest("Error");
            // This method has two different Overloads.
            // return BadRequest(new {Error = "Unauthorized Access" });
        }

        public IActionResult Success()
        {
            // return Ok("Successful");
            // return Ok(new {Data = "Done" }); 
            // Anonymous type -> Json format
            return Ok(new SuccessViewModel { Message = "Transaction Successful", StatusCode = 200 });
        }

        public IActionResult PageNotFound()
        {
            return NotFound();
        }

        public IActionResult ForbiddenPage()
        {
            return StatusCode(403, "Server Error Forbidden");
            // return StatusCode(StatusCodes.); All Status Codes "."
        }

        public IActionResult ServerError()
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
            // "StatusCodes" is a static class. Static classes don't take instances.
        }

    }

}
