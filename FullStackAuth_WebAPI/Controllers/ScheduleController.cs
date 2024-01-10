using FullStackAuth_WebAPI.Data;
using FullStackAuth_WebAPI.DataTransferObjects;
using FullStackAuth_WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SchedulesController(ApplicationDbContext context)
        {
            _context = context;
        }
                        
        /// POST api/Schedule
        [HttpPost]
        public IActionResult Post([FromBody] Schedule data)
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
                _context.Schedules.Add(data);

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
        // GET: api/schedule/today
        [HttpGet("today")]
        public IActionResult GetSchedulesForToday()

        {
            try
            {
                
                var currentDate = DateTime.Today; // Get the current date

                var todaysSchedules = _context.Schedules
                    .Where(s => s.Date.Date == currentDate)
                    .Select(s => new
                    {
                        DogId = s.DogId,
                        Date = s.Date,
                        UserId = s.UserId
                    })
                    .ToList();

                return Ok(todaysSchedules);
            }
            catch (Exception ex)
            {
                // Handle exceptions and return a 500 internal server error
                return StatusCode(500, ex.Message);
            }
        }


        // GET: api/schedule
        [HttpGet, Authorize]
        public IActionResult GetSchedules()
        {
            try
            {
                // Retrieving user ID from the token claims
               
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Retrieve all Schedules from the database
                var schedules = _context.Schedules
                    .Select(a => new Schedule
                    {
                        Date = a.Date,
                        UserId = a.UserId, 
                        DogId = a.DogId,
                    })
                    .ToList();

                return Ok(schedules);

                               
            }
            catch (Exception ex)
            {
                // Handle exceptions and return a 500 internal server error
                return StatusCode(500, ex.Message);
            }
        }







        // PUT api/<ScheduleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ScheduleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
