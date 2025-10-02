using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskTest.Context;
using TaskTest.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstimacionController(ApplicationDbContext _context) : ControllerBase
    {
        // GET: api/<EstimacionController>
        [HttpGet]
        public async Task<List<Estimacion>> Get()
        {
            return await _context.Estimaciones.ToListAsync();
        }

        // GET api/<EstimacionController>/5
        [HttpGet("{id}")]
        public async Task<Estimacion?> Get(int id)
        {
            var estimacion = await _context.Estimaciones.FindAsync(id);
            return estimacion ?? null;
        }

        // POST api/<EstimacionController>
        [HttpPost]
        public async Task<IActionResult> Post(Estimacion estimacion)
        {
            try
            {
                await _context.AddAsync(estimacion);
                await _context.SaveChangesAsync();

                return Created();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT api/<EstimacionController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Estimacion estimacion)
        {
            try
            {
                var estimacionItem = await _context.Estimaciones.FindAsync(id);
                if (estimacionItem != null)
                {
                    estimacionItem.Duration = estimacion.Duration;

                    _context.Update(estimacionItem);
                    await _context.SaveChangesAsync();

                    return NoContent();
                }

                return BadRequest();

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE api/<EstimacionController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var estimacion = await _context.Estimaciones.FindAsync(id);
                if (estimacion != null)
                {
                    estimacion.Activo = !estimacion.Activo;

                    _context.Update(estimacion);
                    await _context.SaveChangesAsync();

                    return NoContent();
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
