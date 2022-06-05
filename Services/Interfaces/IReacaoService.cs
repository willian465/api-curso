using Gama.Curso.Arguments;
using Gama.Curso.Configurations.Enum;
using Gama.Curso.Requests;
using Gama.Curso.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gama.Curso.Services.Interfaces
{
    public interface IReacaoService
    {
        Task<ReacaoReponse> RegistrarReacao(EntidadeEnum endidade, ReacaoRequest request);
        Task DeletarReacao(int codigoReacao);
    }
}
