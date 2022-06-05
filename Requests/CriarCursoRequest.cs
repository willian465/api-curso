using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gama.Curso.Requests
{
    public class CriarCursoRequest
    {
        public CursoRequest Curso { get; set; }
        public IEnumerable<AulaRequest> Aulas { get; set; }
    }
}
