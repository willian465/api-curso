using Gama.Curso.Arguments;
using Gama.Curso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gama.Curso.Repositories.Interfaces
{
    public interface IReacaoRepository
    {
        Task<int> RegistrarReacao(ReacaoArgument argument);
        Task DeletarReacao(int codigoReacao);
        Task<IEnumerable<ReacaoEntidadeModel>> BuscarReacoes(List<int> codigosExterno);
    }
}
