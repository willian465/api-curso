using Gama.Curso.Arguments;
using Gama.Curso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gama.Curso.Repositories.Interfaces
{
    public interface ICursoRespository
    {
        Task<int> CriarCurso(CursoArgument argument);
        Task RegistrarAulaCurso(AulaCursoArgument argument);
        Task<IEnumerable<CursoAulasModel>> BuscarCursos(int codigoCurso = 0);
        Task DeletarAulaCurso(int codigoCurso, int codigoAula);
        Task DeletarCurso(int codigoCurso);
        Task<IEnumerable<DadosCursoModel>> BuscarDadosCursos();
        Task AlterarCurso(int codigoCurso, AlterarCursoArgument argument);
    }
}
