using Microsoft.EntityFrameworkCore;
using Repository.Mapeamento;

namespace Repository.Database
{
    public class ProjetoContext : DbContext
    {
        public ProjetoContext(DbContextOptions options) : base(options)
        {
            // dotnet ef migrations add AdicionarUsuarioTabela --project Repository --startup-project Proway.Projeto00
            // dotnet ef database update --project Repository --startup-project Proway.Projeto00
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Registrar o mapeamento das tabelas com suas colunas e propriedade da entidade
            modelBuilder.ApplyConfiguration(new CategoriaMapeamento());
            modelBuilder.ApplyConfiguration(new LivroMapeamento());
            modelBuilder.ApplyConfiguration(new LoginMapeamento());
        }
    }
}
