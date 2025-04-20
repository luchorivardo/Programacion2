using Entidades.DTOs;
using Logica.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DuenoController : ControllerBase
    {
        private readonly IDuenoLogic _logic;

        public DuenoController(IDuenoLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        public async Task<ActionResult<List<DuenoDTO>>> Get()
        {
            return await _logic.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DuenoDTO>> Get(int id)
        {
            var d = await _logic.ObtenerPorIdAsync(id);
            if (d == null) return NotFound();
            return d;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CrearDuenoDTO dto)
        {
            await _logic.CrearAsync(dto);
            return Ok();
        }
    }
}
