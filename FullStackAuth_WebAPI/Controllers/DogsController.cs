using FullStackAuth_WebAPI.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class DogsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DogsController(ApplicationDbContext context)
        {
            _context = context;
        }






        // GET api/<DogsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DogsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DogsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DogsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
