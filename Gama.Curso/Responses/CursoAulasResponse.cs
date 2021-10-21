using Gama.Curso.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gama.Curso.Responses
{
    public class CursoAulasResponse
    {
        public CursoResponse Curso { get; set; }
        public List<AulaResponse> Aulas { get; set; }
    }
}
