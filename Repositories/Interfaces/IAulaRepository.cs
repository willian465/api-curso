using Gama.Curso.Arguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gama.Curso.Repositories.Interfaces
{
    public interface IAulaRepository
    {
        Task<int> CriarAula(AulaArgument argument);
    }
}
