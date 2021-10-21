using Gama.Curso.Arguments;
using Gama.Curso.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gama.Curso.Services.Interfaces
{
    public interface IAulaService
    {
        Task<int> CriarAula(AulaRequest request);
    }
}
