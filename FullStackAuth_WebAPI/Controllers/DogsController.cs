using FullStackAuth_WebAPI.Data;
using FullStackAuth_WebAPI.DataTransferObjects;
using FullStackAuth_WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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


    public class DogsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public DbSet<Dog> Dogs { get; set; }
        public DogsController(ApplicationDbContext context)
        {
            _context = context;
        }





        // GET api/DogsController
        //GetAll Dogs using DogBioForDisplay
        [HttpGet]
        public IActionResult GetAllDogs()
        {
            try
            {
                var dogs = _context.Dogs.Select(d => new DogBioForDisplayDto
                {
                    Name = d.Name,
                    Age = d.Age,
                    Breed = d.Breed,
                    Gender = d.Gender,
                    Size = d.Size,
                    Weight = d.Weight,
                    EnergyLevel = d.EnergyLevel,
                    Color = d.Color,
                    IsAdopted = d.IsAdopted,
                    Image = d.Image
                }).ToList();

                return Ok(dogs);
            }
            catch (Exception ex)
            {
                // If an error occurs, return a 500 internal server error with the error message
                return StatusCode(500, ex.Message);
            }
        }


        // POST api/Dogs
        [HttpPost]
        //[Authorize(Roles = "Admin")] // Only users in the "Admin" role can access this method
        public IActionResult Post([FromBody] Dog data)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _context.Dogs.Add(data);
                _context.SaveChanges();

                return StatusCode(201, data);
            }
            catch (Exception ex)
            {
                // Log the exception here if possible
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<DogsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Dog data)
        {
            try
            {
                // Find the dog to be updated
                Dog dog = _context.Dogs.FirstOrDefault(d => d.Id == id);

                if (dog == null)
                {
                    // Return a 404 Not Found error if the dog with the specified ID does not exist
                    return NotFound();
                }

                // Update Dog Properties
                dog.Age = data.Age;
                dog.Breed = data.Breed;
                dog.Gender = data.Gender;
                dog.Size = data.Size;
                dog.Weight = data.Weight;
                dog.EnergyLevel = data.EnergyLevel;
                dog.Color = data.Color;
                dog.AdoptionDate = data.AdoptionDate;
                dog.IsAdopted = data.IsAdopted;
                dog.Image = data.Image; // Corrected this line

                if (!ModelState.IsValid)
                {
                    // Return a 400 if bad request and data is invalid
                    return BadRequest(ModelState);
                }

                _context.SaveChanges();

                // Return a 200 OK Status code and updated dog object
                return Ok(dog);
            }
            catch (Exception ex)
            {
                // Return a 500 Internal Server Error with the error message if an exception occurs
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/Dogs/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                // Find the dog to be deleted
                Dog dog = _context.Dogs.FirstOrDefault(dog => dog.Id == id);
                if (dog == null)
                {
                    // Return a 404 Not Found error if the dog with the specified ID does not exist
                    return NotFound();
                }

                // Optional: Check if the authenticated user is the owner of the dog
                // (your logic here, if necessary)

                // Remove the dog from the database
                _context.Dogs.Remove(dog);
                _context.SaveChanges();

                // Return a 204 No Content status code
                return NoContent();
            }
            catch (Exception ex)
            {
                // Return a 500 Internal Server Error with the error message if an exception occurs
                return StatusCode(500, ex.Message);
            }
        }

    }
}

