using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskTest.Context;
using TaskTest.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        // GET: api/<TaskController>
        [HttpGet]
        public async Task<List<Tarea>> Get()
        {
            return await _context.Tareas.ToListAsync();
        }

        // GET api/<TaskController>/5
        [HttpGet("{id}")]
        public async Task<Tarea> Get(int id)
        {
            return await _context.Tareas.FirstOrDefaultAsync(x => x.Id == id);
        }

        // POST api/<TaskController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TaskController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TaskController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
