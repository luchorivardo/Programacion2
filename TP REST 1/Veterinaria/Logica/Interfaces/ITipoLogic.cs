using Entidades.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Interfaces
{
    public interface ITipoLogic
    {
        Task<List<TipoDTO>> ObtenerTodosAsync();
        Task<TipoDTO> ObtenerPorIdAsync(int id);
        Task CrearAsync(CrearTipoDTO dto);
    }
}
