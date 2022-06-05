using Gama.Curso.Arguments;
using Gama.Curso.Configurations.Enum;
using Gama.Curso.Mappers;
using Gama.Curso.Repositories.Interfaces;
using Gama.Curso.Requests;
using Gama.Curso.Responses;
using Gama.Curso.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gama.Curso.Services
{
    public class ReacaoService : IReacaoService
    {
        private readonly IReacaoRepository _reacaoRepository;
        private readonly IConverter _converter;

        public ReacaoService(IReacaoRepository reacaoRepository,
                             IConverter converter)
        {
            _reacaoRepository = reacaoRepository;
            _converter = converter;
        }

        public async Task DeletarReacao(int codigoReacao)
        {
            await _reacaoRepository.DeletarReacao(codigoReacao);
        }

        public async Task<ReacaoReponse> RegistrarReacao(EntidadeEnum endidade, RegistarReacaoRequest request)
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
                CodigoReacao = codigoReacao,
                CodigoTipoReacao = (int)request.TipoReacao
            };
        }
        public async Task<IEnumerable<ReacaoEntidadeResponse>> BuscarReacoes(IEnumerable<int> codigosExterno)
        {
            return _converter.Map<IEnumerable<ReacaoEntidadeResponse>>(await _reacaoRepository.BuscarReacoes(codigosExterno.ToList()));
        }
    }
}
