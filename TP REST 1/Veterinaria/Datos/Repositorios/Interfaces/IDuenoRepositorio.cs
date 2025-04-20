using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorios.Interfaces
{
    public interface IDuenoRepositorio
    {
        Task<List<Duenio>> ObtenerTodosAsync();
        Task<Duenio> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Duenio dueno);
    }
}
