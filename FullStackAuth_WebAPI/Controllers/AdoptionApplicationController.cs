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


        // GET: api/AdoptionApplicationController
        [HttpGet,Authorize]
        public IActionResult GetAllAdoptionApplications()
        {
            try
            {
                string userId = User.FindFirstValue("id");



                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                //Retrieve all AdoptionApplication from the database,
                var adoptionApplications = _context.AdoptionApplications
                    .Select(a => new AdoptionApplication
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
            {   // If an error occurs, return a 500 internal server error with the error message
                return StatusCode(500, ex.Message);
            }


        }
        // POST api/AdoptionApplication
        [HttpPost, Authorize]
        public IActionResult Post([FromBody] AdoptionApplication data)
        {
            try
            {
                int userId = User.FindFirstValue(id);


                if (IsNullOrEmpty(userId))
                {
                    return Unauthorized();
                }

                data.UserId =userId;
              


                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);

                }
                _context.AdoptionApplications.Add(data);

                _context.SaveChanges();

                return Ok(data);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }





















        // PUT api/<AdoptionApplicationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {







        }

        // DELETE api/<AdoptionApplicationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
