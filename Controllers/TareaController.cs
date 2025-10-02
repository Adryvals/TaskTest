using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskTest.Context;
using TaskTest.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController(ApplicationDbContext _context) : ControllerBase
    {
        // GET: api/<TaskController>
        [HttpGet]
        public async Task<List<Tarea>> Get()
        {
            return await _context.Tareas.ToListAsync();
        }

        // GET api/<TaskController>/5
        [HttpGet("{id}")]
        public async Task<Tarea?> Get(int id)
        {
            var tarea = await _context.Tareas.FirstOrDefaultAsync(x => x.Id == id);
            return tarea ?? null;
        }

        // POST api/<TaskController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Tarea tarea)
        {
            try
            {
                await _context.AddAsync(tarea);
                await _context.SaveChangesAsync();

                return Created();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT api/<TaskController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Tarea tarea)
        {
            try
            {
                var tareaItem = await _context.Tareas.FindAsync(id);
                if (tareaItem != null)
                {
                    tareaItem.Estado = tarea.Estado;
                    tareaItem.EstimacionId = tarea.EstimacionId;
                    tareaItem.Completado = tarea.Completado;
                    tareaItem.Descripcion = tarea.Descripcion;
                    tareaItem.FechaTarea = tarea.FechaTarea;
                    tareaItem.Visibilidad = tarea.Visibilidad;

                    _context.Update(tareaItem);
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

        // PATCH api/<TaskController>/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> Achieved(int id)
        {
            try
            {
                var tarea = await _context.Tareas.FindAsync(id);
                if (tarea != null)
                {
                    tarea.Completado = !tarea.Completado;

                    _context.Update(tarea);
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
