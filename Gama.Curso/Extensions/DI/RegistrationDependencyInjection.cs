
using Gama.Curso.Mappers;
using Gama.Curso.Repositories;
using Gama.Curso.Repositories.Interfaces;
using Gama.Curso.Services;
using Gama.Curso.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Gama.Curso.Extensions.DI
{
    public static class RegistrationDependencyInjection
    {
        /// <summary>
        /// Método para realizar o registro das dependências
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void RegistrarDependencias(this IServiceCollection services, IConfiguration configuration = null)
        {
            services.AddSingleton<IConverter, Converter>();
            ResgistrarRepositories(services);
            ResgistrarServices(services);
        }

        public static void ResgistrarRepositories(IServiceCollection services)
        {
            services.AddScoped<IAulaRepository, AulaRepository>();
            services.AddScoped<ICursoRespository, CursoRepository>();
        }

        public static void ResgistrarServices(IServiceCollection services)
        {
            services.AddScoped<IAulaService, AulaService>();
            services.AddScoped<ICursoService, CursoService>();
        }
    }
}
