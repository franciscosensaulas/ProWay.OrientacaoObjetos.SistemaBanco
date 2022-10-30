using Microsoft.Extensions.DependencyInjection;
using Service.Services.Categorias;
using Service.Services.Livros;

namespace Service.DependecyInjection
{
    public static class ServiceDependecyInjection
    {
        // Fluent
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services
                .AddScoped<ICategoriaService, CategoriaService>()
                .AddScoped<ILivroService, LivroService>();

            return services;
        }
    }
}
