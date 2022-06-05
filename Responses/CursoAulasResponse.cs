using Gama.Curso.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gama.Curso.Responses
{
    public class CursoAulasResponse
    {
        public int CodigoCurso { get; set; }
        public string NomeCurso { get; set; }
        public string CaminhoCapa { get; set; }
        public string NomeProfessor { get; set; }
        public string DescricaoCurso { get; set; }
        public List<AulaResponse> Aulas { get; set; }
    }
}
