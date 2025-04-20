using Entidades.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Interfaces
{
    public interface IDuenoLogic
    {
        Task<List<DuenoDTO>> ObtenerTodosAsync();
        Task<DuenoDTO> ObtenerPorIdAsync(int id);
        Task CrearAsync(CrearDuenoDTO dto);
    }
}
