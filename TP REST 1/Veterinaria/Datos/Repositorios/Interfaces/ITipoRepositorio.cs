using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorios.Interfaces
{
    public interface ITipoRepositorio
    {
        Task<List<Tipo>> ObtenerTodosAsync();
        Task<Tipo> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Tipo tipo);
    }
}
