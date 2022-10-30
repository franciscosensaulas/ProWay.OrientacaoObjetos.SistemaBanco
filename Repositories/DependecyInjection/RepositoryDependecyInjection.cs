using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository.Database;
using Repository.Repositories.Categorias;
using Repository.Repositories.Livros;

namespace Repository.DependecyInjection
{
    public static class RepositoryDependecyInjection
    {
        // Fluent
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services
                .AddScoped<ICategoriaRepository, CategoriaRepository>()
                .AddScoped<ILivroRepository, LivroRepository>();

            return services;
        }

        public static IServiceCollection AddSqlServerDatabase(this IServiceCollection services)
        {
            // TODO: trocar connection string para arquivo appSettings.json
            var connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Moc\\Desktop\\ProWay.CSharp.AspNetCore5-2022-10-02-master\\Proway.Projeto00\\Database\\BancoDados.mdf;Integrated Security=True";

            services.AddDbContext<ProjetoContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }
    }
}
