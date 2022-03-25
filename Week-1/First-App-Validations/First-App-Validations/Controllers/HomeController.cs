
using First_App_Validations.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
namespace FirstApp.Controllers
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
            return View();

        }

        [HttpPost]
        public IActionResult Sample(CustomerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                //return RedirectToAction("Error", ModelState);
                return View();
            }
            return View("Sample");
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

