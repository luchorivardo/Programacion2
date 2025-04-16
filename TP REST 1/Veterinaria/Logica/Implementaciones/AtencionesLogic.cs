using Datos.Repositorios;
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
    public class AtencionesLogic : IAtencionesLogic
    {
        private readonly IAtencionRepositorio _repo;

        public AtencionesLogic(IAtencionRepositorio repo)
        {
            _repo = repo;
        }

        public async Task CrearAsync(CrearAtencionDTO dto)
        {
            if (dto.FechaAtencion < DateTime.Today || dto.FechaAtencion > DateTime.Today.AddDays(30))
                throw new Exception("La fecha de atención no puede ser anterior al día de hoy ni posterior a 30 días.");

            var atencion = new Atencion
            {
                MotivoConsulta = dto.MotivoConsulta,
                Tratamiento = dto.Tratamiento,
                Medicamentos = dto.Medicamentos,
                FechaAtencion = dto.FechaAtencion,
                AnimalId = dto.AnimalId
            };

            await _repo.AgregarAsync(atencion);
        }

        public async Task<List<AtencionDTO>> ObtenerTodasAsync()
        {
            var atenciones = await _repo.ObtenerTodasAsync();
            return atenciones.Select(a => new AtencionDTO
            {
                Id = a.Id,
                MotivoConsulta = a.MotivoConsulta,
                Tratamiento = a.Tratamiento,
                Medicamentos = a.Medicamentos,
                FechaAtencion = a.FechaAtencion,
                NombreAnimal = a.Animal.Nombre
            }).ToList();
        }

        public async Task<AtencionDTO> ObtenerPorIdAsync(int id)
        {
            var a = await _repo.ObtenerPorIdAsync(id);
            if (a == null) return null;

            return new AtencionDTO
            {
                Id = a.Id,
                MotivoConsulta = a.MotivoConsulta,
                Tratamiento = a.Tratamiento,
                Medicamentos = a.Medicamentos,
                FechaAtencion = a.FechaAtencion,
                NombreAnimal = a.Animal.Nombre
            };
        }
    }
}
