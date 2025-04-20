using Datos.Context;
using Datos.Repositorios.Interfaces;
using Entidades.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorios
{
    public class DuenoRepositorio : IDuenoRepositorio
    {
        private readonly AppDbContext _context;

        public DuenoRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Duenio>> ObtenerTodosAsync()
        {
            return await _context.Duenios.ToListAsync();
        }

        public async Task<Duenio> ObtenerPorIdAsync(int id)
        {
            return await _context.Duenios.FindAsync(id);
        }

        public async Task AgregarAsync(Duenio dueno)
        {
            _context.Duenios.Add(dueno);
            await _context.SaveChangesAsync();
        }
    }
}
