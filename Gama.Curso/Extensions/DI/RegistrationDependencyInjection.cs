
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Conta.Extensions.DI
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
            //services.AddSingleton<IConverter, Coverter>();
            ResgistrarRepositories(services);
            ResgistrarServices(services);
        }

        public static void ResgistrarRepositories(IServiceCollection services)
        {
            
        }

        public static void ResgistrarServices(IServiceCollection services)
        {
            
        }
    }
}
