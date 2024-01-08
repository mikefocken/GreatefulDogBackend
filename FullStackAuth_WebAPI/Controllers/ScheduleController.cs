using FullStackAuth_WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        // GET: api/<ScheduleController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ScheduleController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ScheduleController>
        [HttpPost]
        public void Post([FromBody] string value)
        {




        }
        // POST api/Schedule
        [HttpPost, Authorize]
        public IActionResult Post([FromBody] Schedule data)
        {
            try
            {
                string userId = User.FindFirstValue("id")


                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized();
                }


                data.UserId = userId;


                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);

                }
                _context.Schedule.Add(data);

                _context.SaveChanges();

                return Ok(data);

            }
            catch (Exception ex)
            {
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
