using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository.Database;
using Repository.Repositories.Categorias;
using Repository.Repositories.Livros;
using Service.Services.Categorias;
using Service.Services.Livros;

namespace Service.DependencyInjection
{
    public static class ServiceDependencyInjection
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<ILivroService, LivrosService>();

            return services;
        }
    }

}
