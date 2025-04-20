using Datos.Repositorios.Interfaces;
using Entidades.DTOs;
using Entidades.Entidades;
using Logica.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Implementaciones
{
    public class TipoLogic : ITipoLogic
    {
        private readonly ITipoRepositorio _repo;

        public TipoLogic(ITipoRepositorio repo)
        {
            _repo = repo;
        }

        public async Task<List<TipoDTO>> ObtenerTodosAsync()
        {
            var lista = await _repo.ObtenerTodosAsync();
            return lista.Select(t => new TipoDTO
            {
                Id = t.Id,
                Nombre = t.Nombre
            }).ToList();
        }

        public async Task<TipoDTO> ObtenerPorIdAsync(int id)
        {
            var t = await _repo.ObtenerPorIdAsync(id);
            if (t == null) return null;

            return new TipoDTO
            {
                Id = t.Id,
                Nombre = t.Nombre
            };
        }

        public async Task CrearAsync(CrearTipoDTO dto)
        {
            var nuevo = new Tipo
            {
                Nombre = dto.Nombre
            };

            await _repo.AgregarAsync(nuevo);
        }
    }
}
