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
    public class AtencionRepositorio : IAtencionRepositorio
    {
        private readonly AppDbContext _context;

        public AtencionRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task AgregarAsync(Atencion atencion)
        {
            _context.Atenciones.Add(atencion);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Atencion>> ObtenerTodasAsync()
        {
            return await _context.Atenciones.Include(a => a.Animal).ToListAsync();
        }

        public async Task<Atencion> ObtenerPorIdAsync(int id)
        {
            return await _context.Atenciones.Include(a => a.Animal).FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
