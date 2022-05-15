using Gama.Curso.Requests;
using Gama.Curso.Responses;
using Gama.Curso.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gama.Curso.Controllers
{
    [Route("V{version:ApiVersion}/cursos")]
    [ApiController]
    [ApiVersion("1")]
    public class CursoController : ControllerBase
    {
        private readonly ICursoService _cursoService;

        public CursoController(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }
        /// <summary>
        /// Método para gerar um curso com suas aulas 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(CursoAulasResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<CursoAulasResponse>> CriarCurso([FromBody] CriarCursoRequest request)
        {
            return Ok(await _cursoService.CriarCurso(request));
        }
        /// <summary>
        /// Método para buscar os cursos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(CursoAulasResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CursoAulasResponse>>> BuscarCursos()
        {
            return Ok(await _cursoService.BuscarCursos());
        }
        /// <summary>
        /// Método para buscar todos os cursos cadastrados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("resumido")]
        [ProducesResponseType(typeof(IEnumerable<DadosCursoResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<DadosCursoResponse>>> BuscarDadosCursos()
        {
            return Ok(await _cursoService.BuscarDadosCursos());
        }
        /// <summary>
        /// Método para deletar uma aula de um curso
        /// </summary>
        /// <param name="codigoCuso"></param>
        /// <param name="codigoAula"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{codigoCuso}/aulas/{codigoAula}")]
        [ProducesResponseType(typeof(CursoAulasResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<CursoAulasResponse>> DeletarAulaCurso(int codigoCuso, int codigoAula)
        {
            return Ok(await _cursoService.DeletarAulaCurso(codigoCuso, codigoAula));
        }
        /// <summary>
        /// Método para deletar um curso
        /// </summary>
        /// <param name="codigoCuso"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{codigoCuso}")]
        [ProducesResponseType(typeof(CursoAulasResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<CursoAulasResponse>> DeletarCurso(int codigoCuso)
        {
            return Ok(await _cursoService.DeletarCurso(codigoCuso));
        }
        /// <summary>
        /// Método para atualizar a descrição do curso
        /// </summary>
        /// <param name="codigoCuso"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("{codigoCuso}")]
        [ProducesResponseType(typeof(CursoAulasResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<CursoAulasResponse>> AtualizarCurso(int codigoCuso, AlterarCursoRequest request)
        {
            return Ok(await _cursoService.AlterarCurso(codigoCuso, request));
        }
    }
}
