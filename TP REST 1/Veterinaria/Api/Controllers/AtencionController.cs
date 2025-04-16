using Entidades.DTOs;
using Logica.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AtencionController : Controller
    {
        private readonly IAtencionesLogic _logic;

        public AtencionController(IAtencionesLogic logic)
        {
            _logic = logic;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CrearAtencionDTO dto)
        {
            try
            {
                await _logic.CrearAsync(dto);
                return Ok("Atención registrada correctamente.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<AtencionDTO>>> Get()
        {
            return await _logic.ObtenerTodasAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AtencionDTO>> Get(int id)
        {
            var atencion = await _logic.ObtenerPorIdAsync(id);
            if (atencion == null)
            {
                return NotFound();
            }
                
            return atencion;
        }
    }
}
