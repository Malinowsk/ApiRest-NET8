using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // para usar el dbcontext
using ApiRestASPNETCore.Models;
using ApiRestASPNETCore.Data;



namespace ApiRestASPNETCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VestimentaController : Controller
    {
        private readonly Conexiones _context; // variable que maneja la conexion con la base de datos

        public VestimentaController(Conexiones context) // inyeccion de dependencias
        {
            _context = context;
        }

        // GET: api/Vestimenta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vestimenta>>> GetVestimentas()
        {
            List<Vestimenta> lista = await _context.Vestimentas.ToListAsync();
            return lista;
            //return View(lista);
        }

        // GET: api/Vestimenta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vestimenta>> GetVestimenta(int id)
        {
            var vestimenta = await _context.Vestimentas.FindAsync(id);

            if (vestimenta == null)
            {
                return NotFound();
            }

            return vestimenta;
        }

        // POST: api/Vestimenta
        [HttpPost]
        public async Task<ActionResult> PostVestimenta(Vestimenta vestimenta)
        {
            _context.Vestimentas.Add(vestimenta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVestimenta", new { id = vestimenta.IdVestimenta }, vestimenta);
        }

    }
}
