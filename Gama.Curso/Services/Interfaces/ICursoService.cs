using Gama.Curso.Requests;
using Gama.Curso.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gama.Curso.Services.Interfaces
{
    public interface ICursoService
    {
        Task<CursoAulasResponse> CriarCurso(CriarCursoRequest request);
        Task<IEnumerable<CursoAulasResponse>> BuscarCursos();
        Task<bool> DeletarAulaCurso(int codigoCurso, int codigoAula);
        Task<bool> DeletarCurso(int codigoCurso);
        Task<IEnumerable<DadosCursoResponse>> BuscarDadosCursos();
        Task<bool> AlterarCurso(int codigoCurso, AlterarCursoRequest request);
    }
}
