using HW4.App.Filters;
using HW4.App.Models;
using HW4.App.Business.Abstracts;
using HW4.App.Business.DTOs;
using HW4.App.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HW4.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService companyService;

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        // Using LogAttribute
        [Route("Log")]
        [HttpGet]
        [Log]
        public IActionResult Log()
        {
            return Content("Action Level Logging");
        }

        [Route("Compaines")]
        [HttpGet]
        public IActionResult Get()
        {
            var companies = companyService.GetCompanies().Select(x => new CompanyDto
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                City = x.City,
                Country = x.Country,
                Description = x.Description,
                Location = x.Location,
                Phone = x.Phone
            });
            return Ok(new CompanyResponseModel { Data = companies, Success = true });
        }

        // "id" field is required on Swagger Header
        [HttpGet("{id}")]
        public IActionResult GetCompanyByID(int id)
        {
            // Getting company information by id
            var company = companyService.GetCompany(x => x.Id == id);
            return Ok(company);

        }

        [Route("AddCompany")]
        [HttpPost]
        public IActionResult Insert([FromBody] CompanyDto model)
        {
            companyService.InsertCompany(new Company
            {
                Address = model.Address,
                City = model.City,
                Description = model.Description,
                CreatedBy = "Meleknur Yazlamaz",
                CreatedAt = System.DateTime.Now,
                IsDeleted = false,
                Name = model.Name.ToUpper(),
                Country = model.Country,
                Location = model.Location,
                Phone = model.Phone,
            });
            return Ok(
                new CompanyResponseModel
                {
                    Data = "Company Inserted Successfully!",
                    Success = true
                });
        }

        // "id" field is required on Swagger Header
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CompanyDto model)
        {
            // Updating company information by id
            var company = companyService.GetCompany(x => x.Id == id);
            if (company != null)
            {
                // First change the data saved in the database
                company.Name = model.Name;
                company.Address = model.Address;
                company.Country = model.Country;
                company.City = model.City;
                company.Location = model.Location;
                company.Phone = model.Phone;
                company.Description = model.Description;

                // Then update it
                companyService.UpdateCompany(company);           
                
                return Ok(
                    new CompanyResponseModel
                    {
                        Data = "Company Updated Successfully!",
                        Success = true
                    });
            }
            return BadRequest(new CompanyResponseModel
            {
                Data = "Company Not Found!",
                Success = false
            });
        }

        // "id" field is required on Swagger Header
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Deleting company information by id
            var company = companyService.GetCompany(x => x.Id == id);
            if (company != null)
            {
                companyService.DeleteCompany(company);
                return Ok(new CompanyResponseModel
                {
                    Data = $"Company with Id:{id} Deleted successfully!",
                    Success = true
                });
            }
            return BadRequest(new CompanyResponseModel
            {
                Data = "Company Not Found!",
                Success = false
            });

        }
    }
}
