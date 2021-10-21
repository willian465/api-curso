using Gama.Curso.Configurations.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gama.Curso.Models
{
    public class CursoModel 
    {
        public int CodigoCurso { get; set; }
        public string NomeCurso { get; set; }
        public string CaminhoCapa { get; set; }
        public string NomeProfessor { get; set; }
        public string DescricaoCurso { get; set; }
    }
}
