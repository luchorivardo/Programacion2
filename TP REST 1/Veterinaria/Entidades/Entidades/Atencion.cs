﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Entidades
{
    public class Atencion
    {
        public int Id { get; set; }
        public string MotivoConsulta { get; set; }
        public string Tratamiento { get; set; }
        public string Medicamentos { get; set; }
        public DateTime FechaAtencion { get; set; }
        public int AnimalId { get; set; }
        public Animal Animal { get; set; }
    }
}
