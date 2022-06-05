using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gama.Curso.Configurations.DTO
{
    public class ReacaoEntidadeDTO<IReacao> where IReacao: ReacaoDTO
    {
        public int CodigoExterno { get; set; }
        public int CodigoTipoEntidade { get; set; }
        public List<IReacao> Reacoes { get; set; }
    }
}
