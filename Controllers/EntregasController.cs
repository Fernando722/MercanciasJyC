using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MercanciasJyC.Data;
using MercanciasJyC.Models;

namespace MercanciasJyC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntregasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EntregasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Entregas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entrega>>> GetEntregas()
        {
            return await _context.Entregas.ToListAsync();
        }

        // GET: api/Entregas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Entrega>> GetEntrega(int id)
        {
            var entrega = await _context.Entregas.FindAsync(id);

            if (entrega == null)
            {
                return NotFound();
            }

            return entrega;
        }

        // POST: api/Entregas
        [HttpPost]
        public async Task<ActionResult<Entrega>> PostEntrega(Entrega entrega)
        {
            _context.Entregas.Add(entrega);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEntrega), new { id = entrega.EntregaID }, entrega);
        }

        // PUT: api/Entregas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntrega(int id, Entrega entrega)
        {
            if (id != entrega.EntregaID)
            {
                return BadRequest();
            }

            _context.Entry(entrega).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntregaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Entregas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntrega(int id)
        {
            var entrega = await _context.Entregas.FindAsync(id);
            if (entrega == null)
            {
                return NotFound();
            }

            _context.Entregas.Remove(entrega);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EntregaExists(int id)
        {
            return _context.Entregas.Any(e => e.EntregaID == id);
        }
    }
}