using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.Database;
using Repository.Repositories.Categorias;
using Repository.Repositories.Livros;
using Repository.Repositories.Usuario;

namespace Repository.DependencyInjection
{
    public static class RepositoryDependencyInjection
    {
        public static IServiceCollection AddRespository(this IServiceCollection services)
        {
            services
            .AddScoped<ICategoriaRepositorio, CategoriaRepositorio>()
            .AddScoped<ILivroRepository, LivroRepository>()
            .AddScoped<IUsuarioRepository, UsuarioRepository>();

            return services;
        }

        public static IServiceCollection AddSqlServerDataBase(this IServiceCollection services,
            IConfiguration configuration)
        {
            // ConnectionStrings de exemplo: https://www.connectionstrings.com/sql-server/
            var connectionString = configuration.GetConnectionString("SqlServer");

            services.AddDbContext<ProjetoContext>(options => options.UseSqlServer(connectionString));

            return services;
        }
    }

}
