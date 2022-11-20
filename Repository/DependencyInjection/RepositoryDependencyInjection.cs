using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository.Database;
using Repository.Repositories.Categorias;
using Repository.Repositories.Livros;

namespace Repository.DependencyInjection
{
    public static class RepositoryDependencyInjection
    {
        public static IServiceCollection AddRespository(this IServiceCollection services)
        {
            services
            .AddScoped<ICategoriaRepositorio, CategoriaRepositorio>()
            .AddScoped<ILivroRepository, LivroRepository>();

            return services;
        }

        public static IServiceCollection AddSqlServerDataBase(this IServiceCollection services)
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Moc\Desktop\Proway.Projeto00\Proway.Projeto00\Database\BancoDados.mdf;Integrated Security=True";

            services.AddDbContext<ProjetoContext>(options => options.UseSqlServer(connectionString));

            return services;
        }
    }

}
