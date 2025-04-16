using Entidades.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Interfaces
{
    public interface IAtencionesLogic
    {
        Task CrearAsync(CrearAtencionDTO dto);
        Task<List<AtencionDTO>> ObtenerTodasAsync();
        Task<AtencionDTO> ObtenerPorIdAsync(int id);
    }
}
