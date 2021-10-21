﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gama.Curso.Configurations.DTO
{
    public class AulaDTO
    {
        public string NomeAula { get; set; }
        public string TituloAula { get; set; }
        public string LinkAula { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataConclusao { get; set; }
    }
}
