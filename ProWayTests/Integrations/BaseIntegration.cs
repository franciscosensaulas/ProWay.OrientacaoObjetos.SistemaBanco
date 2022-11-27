using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Repository.Database;
using Repository.DependencyInjection;
using Repository.Entities;
using Service.DependencyInjection;

namespace ProwayTests.Integrations
{
    public abstract class BaseIntegration
    {
        protected readonly HttpClient _client;
        protected readonly ProjetoContext _context;
        private readonly TestServer _testServer;

        public BaseIntegration()
        {
            _testServer = new TestServer(new WebHostBuilder().UseStartup<TestStartup>());

            _client = _testServer.CreateClient();
            _context = _testServer.Services.GetService<ProjetoContext>();

            _context.Database.EnsureDeleted();
            _context.Database.Migrate();

            //_context.Set<Categoria>().RemoveRange(_context.Set<Categoria>().ToList());
            //_context.Set<Livro>().RemoveRange(_context.Set<Livro>().ToList());
        }

        public void CreateEntity<TEntity>(params TEntity[] entities)
            where TEntity : EntityBase
        {
            foreach (var item in entities)
            {
                _context.Set<TEntity>().Add(item);

            }

            _context.SaveChanges();
        }

        public TEntity? GetById<TEntity>(int id)
            where TEntity : EntityBase
        {
            return _context
                .Set<TEntity>()
                .FirstOrDefault(x => x.Id == id);
        }

        public T GetService<T>() =>
            _testServer.Services.GetService<T>();
    }

    public class TestStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //services.AddDbContext<ProjetoContext>(x => x.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=ProjetoProwayTestsIntegrations"));
            services.AddDbContext<ProjetoContext>(x => x.UseInMemoryDatabase("ProjetoProwayBancoMemoria"));
            services
                .AddRespository()
                .AddService();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
