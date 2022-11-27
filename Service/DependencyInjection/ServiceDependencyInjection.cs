using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Service.Services.Categorias;
using Service.Services.Livros;
using Service.Services.Usuarios;
using Service.Validations;
using Service.ViewModels.Usuarios;

namespace Service.DependencyInjection
{
    public static class ServiceDependencyInjection
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<ILivroService, LivrosService>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            return services;
        }

        public static IServiceCollection AddFluentValidationProjeto(this IServiceCollection services)
        {
            services.AddScoped<IValidator<UsuarioViewModel>, UsuarioViewModelValidation>();

            return services;
        }
    }

}
