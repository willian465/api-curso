using Gama.Curso.Configurations.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gama.Curso.Requests
{
    public class RegistarReacaoRequest
    {
        public int CodigoExterno { get; set; }
        public TipoReacaoEnum TipoReacao { get; set; }
    }
}
