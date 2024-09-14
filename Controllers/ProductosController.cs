using MercanciasJyC.Data;
using MercanciasJyC.Models;
using Microsoft.AspNetCore.Mvc;

namespace MercanciasJyC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductosController(AppDbContext context)
        {
            _context = context;
        }

        // Obtener todos los productos
        [HttpGet]
        public ActionResult<IEnumerable<Producto>> GetProductos()
        {
            var productos = _context.Productos.ToList();
            if (productos == null || productos.Count == 0)
            {
                return NotFound("No se encontraron productos.");
            }
            return Ok(productos);
        }

        // Obtener un producto por ID
        [HttpGet("{id}")]
        public ActionResult<Producto> GetProducto(int id)
        {
            var producto = _context.Productos.Find(id);
            if (producto == null)
            {
                return NotFound($"El producto con ID {id} no existe.");
            }
            return Ok(producto);
        }

        // Crear un nuevo producto
        [HttpPost]
        public ActionResult<Producto> PostProducto([FromBody] Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Productos.Add(producto);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetProducto), new { id = producto.ProductoID }, producto);
        }

        // Actualizar un producto existente
        [HttpPut("{id}")]
        public IActionResult PutProducto(int id, [FromBody] Producto producto)
        {
            if (id != producto.ProductoID)
            {
                return BadRequest("El ID del producto no coincide.");
            }

            var productoExistente = _context.Productos.Find(id);
            if (productoExistente == null)
            {
                return NotFound($"El producto con ID {id} no existe.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            productoExistente.Nombre = producto.Nombre;
            productoExistente.Descripción = producto.Descripción;
            productoExistente.Precio = producto.Precio;
            productoExistente.Stock = producto.Stock;

            _context.SaveChanges();
            return NoContent();
        }

        // Eliminar un producto
        [HttpDelete("{id}")]
        public IActionResult DeleteProducto(int id)
        {
            var producto = _context.Productos.Find(id);
            if (producto == null)
            {
                return NotFound($"El producto con ID {id} no existe.");
            }

            _context.Productos.Remove(producto);
            _context.SaveChanges();
            return NoContent();
        }
    }
}