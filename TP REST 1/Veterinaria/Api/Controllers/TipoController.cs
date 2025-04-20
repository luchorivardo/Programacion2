using Entidades.DTOs;
using Logica.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoController : ControllerBase
    {
        private readonly ITipoLogic _logic;

        public TipoController(ITipoLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        public async Task<ActionResult<List<TipoDTO>>> Get()
        {
            return await _logic.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoDTO>> Get(int id)
        {
            var tipo = await _logic.ObtenerPorIdAsync(id);
            if (tipo == null) return NotFound();
            return tipo;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CrearTipoDTO dto)
        {
            await _logic.CrearAsync(dto);
            return Ok();
        }
    }
}
