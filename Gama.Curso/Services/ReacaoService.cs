using Gama.Curso.Arguments;
using Gama.Curso.Configurations.Enum;
using Gama.Curso.Mappers;
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
    public class ReacaoService : IReacaoService
    {
        private readonly IReacaoRepository _reacaoRepository;

        public ReacaoService(IReacaoRepository reacaoRepository)
        {
            _reacaoRepository = reacaoRepository;
        }

        public async Task DeletarReacao(int codigoReacao)
        {
            await _reacaoRepository.DeletarReacao(codigoReacao);
        }

        public async Task<ReacaoReponse> RegistrarReacao(EntidadeEnum endidade, ReacaoRequest request)
        {
            int codigoReacao = await _reacaoRepository.RegistrarReacao(
                                                        new ReacaoArgument
                                                        {
                                                            CodigoExterno = request.CodigoExterno,
                                                            CodigoTipoEntidade = (int)endidade,
                                                            CodigoTipoReacao = (int)request.TipoReacao
                                                        });

            return new ReacaoReponse()
            {
                CodigoExterno = request.CodigoExterno,
                CodigoReacao = codigoReacao
            };
        }
    }
}
