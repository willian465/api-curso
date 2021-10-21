using Gama.Curso.Arguments;
using Gama.Curso.Mappers;
using Gama.Curso.Repositories.Interfaces;
using Gama.Curso.Requests;
using Gama.Curso.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gama.Curso.Services
{
    public class AulaService : IAulaService
    {
        private readonly IAulaRepository _aulaRepositoty;
        private readonly IConverter _converter;

        public AulaService(IAulaRepository aulaRepositoty,
                           IConverter converter)
        {
            _aulaRepositoty = aulaRepositoty;
            _converter = converter;
        }
        public async Task<int> CriarAula(AulaRequest request)
        {
            return await _aulaRepositoty.CriarAula(_converter.Map<AulaArgument>(request));
        }
    }
}
