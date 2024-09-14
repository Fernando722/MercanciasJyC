using MercanciasJyC.Data;
using MercanciasJyC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace MercanciasJyC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/clientes
        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> Get()
        {
            // Verifica que se están recuperando clientes de la base de datos
            var clientes = _context.Clientes.ToList();

            if (clientes == null || !clientes.Any())
            {
                // Retorna un código 404 si no hay clientes
                return NotFound("No se encontraron clientes.");
            }

            // Retorna un código 200 con la lista de clientes
            return Ok(clientes);
        }
    }
}