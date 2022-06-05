using Gama.Curso.Configurations.Enum;
using Gama.Curso.Requests;
using Gama.Curso.Responses;
using Gama.Curso.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Gama.Curso.Controllers
{
    [Route("V{version:ApiVersion}/reacoes")]
    [ApiController]
    [ApiVersion("1")]
    public class ReacaoController : ControllerBase
    {
        private readonly IReacaoService _reacaoService;

        public ReacaoController(IReacaoService reacaoService)
        {
            _reacaoService = reacaoService;
        }
        /// <summary>
        /// Método para reagir a um curso ou uma aula
        /// </summary>
        /// <param name="endidade"> 1- Curso 2 - Aula </param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(CursoAulasResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<ReacaoReponse>> RegistrarReacao(EntidadeEnum endidade, [FromBody] ReacaoRequest request)
        {
            return Ok(await _reacaoService.RegistrarReacao(endidade, request));
        }
        /// <summary>
        /// Método para deletar uma reação
        /// </summary>
        /// <param name="codigoReacao"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{codigoReacao}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeletarReacao(int codigoReacao)
        {
            await _reacaoService.DeletarReacao(codigoReacao);
            return NoContent();
        }
    }
}
