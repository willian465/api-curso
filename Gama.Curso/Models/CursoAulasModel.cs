using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gama.Curso.Models
{
    public class CursoAulasModel
    {
        public CursoModel Curso { get; set; }
        public List<AulaModel> Aulas { get; set; }
    }
}
