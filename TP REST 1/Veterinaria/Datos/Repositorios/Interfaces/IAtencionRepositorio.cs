using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorios.Interfaces
{
    public interface IAtencionRepositorio
    {
        Task AgregarAsync(Atencion atencion);
        Task<List<Atencion>> ObtenerTodasAsync();
        Task<Atencion> ObtenerPorIdAsync(int id);
    }
}
