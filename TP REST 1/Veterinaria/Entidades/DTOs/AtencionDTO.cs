using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTOs
{
    public class AtencionDTO
    {
        public int Id { get; set; }
        public string MotivoConsulta { get; set; }
        public string Tratamiento { get; set; }
        public string Medicamentos { get; set; }
        public DateTime FechaAtencion { get; set; }
        public string NombreAnimal { get; set; }
    }
}

