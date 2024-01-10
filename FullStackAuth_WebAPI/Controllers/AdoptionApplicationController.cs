using FullStackAuth_WebAPI.Data;
using FullStackAuth_WebAPI.DataTransferObjects;
using FullStackAuth_WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Drawing;
using System.Linq.Expressions;
using System.Security.Claims;
using static Google.Protobuf.WellKnownTypes.Field.Types;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdoptionApplicationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AdoptionApplicationController(ApplicationDbContext context)
        {
            _context = context;
        }


        /// POST api/AdoptionApplication
        [HttpPost, Authorize]
        public IActionResult Post([FromBody] AdoptionApplication data)
        {
            try
            {
                // Retrieve the authenticated user's ID from the JWT token
                string userId = User.FindFirstValue("id");

                // If the user ID is null or empty, the user is not authenticated, so return a 401 unauthorized response
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized();
                }

                data.UserId = userId;


                // Add information to the database and save changes
                _context.AdoptionApplications.Add(data);
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _context.SaveChanges();

                // Return the newly created car as a 201 created response
                return StatusCode(201, data);
            }
            catch (Exception ex)
            {
                // If an error occurs, return a 500 internal server error with the error message
                return StatusCode(500, ex.Message);
            }
        }

        

        // DELETE api/AdoptionApplication/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {

                var adoptionApplication = _context.AdoptionApplications.FirstOrDefault(a => a.Id == id);

                // If the adoption application does not exist, return a 404 not found response
                if (adoptionApplication == null)
                {
                    return NotFound();
                }


                _context.AdoptionApplications.Remove(adoptionApplication);
                _context.SaveChanges();

                // Return a 200 OK response or 204 No Content
                return Ok(); // or return NoContent();
            }
            catch (Exception ex)
            {
                // If an error occurs, return a 500 internal server error with the error message
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/AdoptionApplication/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AdoptionApplication updatedData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Retrieve the existing adoption application from the database
                var adoptionApplication = _context.AdoptionApplications.FirstOrDefault(a => a.Id == id);

                // If the adoption application does not exist, return a 404 not found response
                if (adoptionApplication == null)
                {
                    return NotFound();
                }

                adoptionApplication.ApplicationDate = updatedData.ApplicationDate;
                adoptionApplication.Status = updatedData.Status;
                adoptionApplication.UserId = updatedData.UserId;
                adoptionApplication.DogId = updatedData.DogId;

                // Save the changes to the database
                _context.SaveChanges();

                // Return a 204 No Content response
                return NoContent();
            }
            catch (Exception ex)
            {
                // If an error occurs, return a 500 internal server error with the error message
                return StatusCode(500, ex.Message);
            }
        }




        // GET: api/Application/myApplicationStatus
        [HttpGet("myApplicationStatus"), Authorize]
        public IActionResult GetUsersAdoptionApplication()
        {
            try
            {
                // Retrieve the authenticated user's ID from the JWT token
                string userId = User.FindFirstValue("id");

                // Retrieve all cars that belong to the authenticated user, including the owner object
                var adoptionApplications = _context.AdoptionApplications.Where(c => c.UserId.Equals(userId));

                // Return the list of cars as a 200 OK response
                return StatusCode(200, adoptionApplications);
            }
            catch (Exception ex)
            {
                // If an error occurs, return a 500 internal server error with the error message
                return StatusCode(500, ex.Message);
            }
        }









        // working line above


        // GET: api/AdoptionApplication
        [HttpGet]
        public IActionResult GetAllAdoptionApplications()
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Retrieve all AdoptionApplications from the database
                var adoptionApplications = _context.AdoptionApplications
                    .Select(a => new AdoptionApplication // Consider using a DTO instead
                    {
                        ApplicationDate = a.ApplicationDate,
                        Status = a.Status,
                        UserId = a.UserId,
                        DogId = a.DogId
                      
                    })
                    .ToList();

                return Ok(adoptionApplications);
            }
            catch (Exception ex)
            {
                // Handle exceptions and return a 500 internal server error
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/AdoptionApplications/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var adoptionApplication = _context.AdoptionApplications
                    .Include(a => a.User)
                    .Include(a => a.Dog)
                    .FirstOrDefault(a => a.Id == id);

                // If the adoption application does not exist, return a 404 not found response
                if (adoptionApplication == null)
                {
                    return NotFound();
                }

                // Return the adoption application as a 200 OK response
                return Ok(adoptionApplication);
            }
            catch (Exception ex)
            {
                // If an error occurs, return a 500 internal server error with the error message
                return StatusCode(500, ex.Message);
            }
        }

    }
}
