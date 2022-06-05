using AutoMapper;
using Gama.Curso.Models;
using Gama.Curso.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gama.Curso.Mappers.Profiles
{
    public class ModelToResponseProfile : Profile
    {
        public ModelToResponseProfile()
        {
            CreateMap<CursoAulasModel, CursoAulasResponse>().ReverseMap();
            CreateMap<AulaModel, AulaResponse>().ReverseMap();
            CreateMap<CursoModel, CursoResponse>().ReverseMap();
            CreateMap<DadosCursoModel, DadosCursoResponse>().ReverseMap();
        }
    }
}
