using AutoMapper;
using Gama.Curso.Mappers.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gama.Curso.Mappers
{
    public class ConfigMapper
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(config =>
            {
                config.AddProfile(new ModelToResponseProfile());
                config.AddProfile(new RequestToArgumentProfile());
            });
        }
    }
}
