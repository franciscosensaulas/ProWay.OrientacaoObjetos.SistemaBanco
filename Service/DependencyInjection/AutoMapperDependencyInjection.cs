using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Repository.Entities;
using Service.ViewModels.Livros;

namespace Service.DependencyInjection
{
    public static class AutoMapperDependencyInjection
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            var mapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<LivroCadastrarViewModel, Livro>();
                x.CreateMap<Livro, LivroEditarViewModel>();
                x.CreateMap<Livro, LivroIndexViewModel>();
            });

            var mapper = mapperConfiguration.CreateMapper();

            services.AddSingleton(mapper);

            return services;
        }
    }
}
