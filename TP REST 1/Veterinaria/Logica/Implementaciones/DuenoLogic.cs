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
    public class DuenoLogic : IDuenoLogic
    {
        private readonly IDuenoRepositorio _repo;

        public DuenoLogic(IDuenoRepositorio repo)
        {
            _repo = repo;
        }

        public async Task<List<DuenoDTO>> ObtenerTodosAsync()
        {
            var lista = await _repo.ObtenerTodosAsync();
            return lista.Select(d => new DuenoDTO
            {
                Id = d.Id,
                Nombre = d.Nombre,
                Apellido = d.Apellido,
                Dni = d.Dni
            }).ToList();
        }

        public async Task<DuenoDTO> ObtenerPorIdAsync(int id)
        {
            var d = await _repo.ObtenerPorIdAsync(id);
            if (d == null) return null;

            return new DuenoDTO
            {
                Id = d.Id,
                Nombre = d.Nombre,
                Apellido = d.Apellido,
                Dni = d.Dni
            };
        }

        public async Task CrearAsync(CrearDuenoDTO dto)
        {
            var nuevo = new Duenio
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Dni = dto.Dni
            };

            await _repo.AgregarAsync(nuevo);
        }
    }
}
