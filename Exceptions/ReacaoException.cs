using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Gama.Curso.Exceptions
{
    [Serializable]
    public class ReacaoException : Exception
    {
        public HttpStatusCode SatusCode { get; set; }
        public ReacaoException(string message) : base(message)
        {
            SatusCode = HttpStatusCode.UnprocessableEntity;
        }
    }
}
