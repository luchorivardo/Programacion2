﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Entidades
{
    public class Tipo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public ICollection<Animal> Animales { get; set; }
    }
}
