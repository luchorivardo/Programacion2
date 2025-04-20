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
    public class TipoRepositorio : ITipoRepositorio
    {
        private readonly AppDbContext _context;

        public TipoRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Tipo>> ObtenerTodosAsync()
        {
            return await _context.Tipos.ToListAsync();
        }

        public async Task<Tipo> ObtenerPorIdAsync(int id)
        {
            return await _context.Tipos.FindAsync(id);
        }

        public async Task AgregarAsync(Tipo tipo)
        {
            _context.Tipos.Add(tipo);
            await _context.SaveChangesAsync();
        }
    }
}
