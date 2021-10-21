using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gama.Curso.Exceptions
{
    public class CursoException : Exception
    {
        public CursoException(string message) : base(message)
        {
        }
    }
}
