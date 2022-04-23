using Gama.Curso.Arguments;
using Gama.Curso.Exceptions;
using Gama.Curso.Mappers;
using Gama.Curso.Models;
using Gama.Curso.Repositories.Interfaces;
using Gama.Curso.Requests;
using Gama.Curso.Responses;
using Gama.Curso.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gama.Curso.Services
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRespository _cursoRepository;
        private readonly IAulaService _aulaService;
        private readonly IConverter _converter;

        public CursoService(ICursoRespository cursoRepository,
                            IAulaService aulaService,
                            IConverter converter)
        {
            _cursoRepository = cursoRepository;
            _aulaService = aulaService;
            _converter = converter;
        }

        public async Task<bool> AlterarCurso(int codigoCurso, AlterarCursoRequest request)
        {
            await _cursoRepository.AlterarCurso(codigoCurso, new AlterarCursoArgument() { NomeCurso = request.NomeCurso });

            return true;
        }

        public async Task<IEnumerable<CursoAulasResponse>> BuscarCursos()
        {
            return _converter.Map<IEnumerable<CursoAulasResponse>>(await _cursoRepository.BuscarCursos());
        }

        public async Task<IEnumerable<DadosCursoResponse>> BuscarDadosCursos()
        {
            return _converter.Map<IEnumerable<DadosCursoResponse>>(
                await _cursoRepository.BuscarDadosCursos()
                );
        }

        public async Task<CursoAulasResponse> CriarCurso(CriarCursoRequest request)
        {
            if (request == null)
                throw new CursoException("Request inválido");

            int codigoCurso;
            try
            {
                // curso 
                codigoCurso = await _cursoRepository.CriarCurso(_converter.Map<CursoArgument>(request.Curso));

                if (codigoCurso == 0)
                    throw new CursoException($"Ocorreu um erro ao criar o curso {request.Curso.NomeCurso}");

                // aulas 
                List<int> aulas = await RegistrarAulas(request.Aulas);

                // vínculo das aulas com o curso
                if (aulas.Any())
                {
                    int ordem = 0;
                    foreach (int aula in aulas)
                    {
                        ordem += 1;
                        await _cursoRepository.RegistrarAulaCurso(
                                        new AulaCursoArgument()
                                        {
                                            CodigoCurso = codigoCurso,
                                            CodigoAula = aula,
                                            Ordem = ordem
                                        });
                    }
                }
            }
            catch (Exception e)
            {
                throw new CursoException($"Ocorreu um erro ao salvar o curso. MSG: {e.Message}");
            }

            return _converter.Map<CursoAulasResponse>((await _cursoRepository.BuscarCursos(codigoCurso)).FirstOrDefault());
        }

        public async Task<bool> DeletarAulaCurso(int codigoCurso, int codigoAula)
        {
            if (codigoCurso == 0)
                throw new CursoException("Código de curso deve ser informado");

            if (codigoAula == 0)
                throw new CursoException("Código da aula deve ser informado");

            await _cursoRepository.DeletarAulaCurso(codigoCurso, codigoAula);

            return true;
        }

        public async Task<bool> DeletarCurso(int codigoCurso)
        {
            if (codigoCurso == 0)
                throw new CursoException("Código de curso deve ser informado");

            await _cursoRepository.DeletarCurso(codigoCurso);

            return true;
        }

        private async Task<List<int>> RegistrarAulas(IEnumerable<AulaRequest> aulas)
        {
            List<int> codigosAulas = new List<int>();
            foreach (AulaRequest aula in aulas)
            {
                try
                {
                    codigosAulas.Add(await _aulaService.CriarAula(aula));
                }
                catch { }
            }
            return codigosAulas;
        }
    }
}
