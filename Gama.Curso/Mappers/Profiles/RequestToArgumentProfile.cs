using AutoMapper;
using Gama.Curso.Arguments;
using Gama.Curso.Models;
using Gama.Curso.Requests;
using Gama.Curso.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gama.Curso.Mappers.Profiles
{
    public class RequestToArgumentProfile : Profile
    {
        public RequestToArgumentProfile()
        {
            CreateMap<CursoRequest, CursoArgument>().ReverseMap();
            CreateMap<AulaRequest, AulaArgument>().ReverseMap();
        }
    }
}
