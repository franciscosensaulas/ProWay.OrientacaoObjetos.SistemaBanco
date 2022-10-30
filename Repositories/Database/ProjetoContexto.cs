using Microsoft.EntityFrameworkCore;
using Repository.Mapeamento;

namespace Repository.Database
{
    public class ProjetoContext : DbContext
    {
        public ProjetoContext(DbContextOptions options) : base(options)
        {
        }
        // C:\Users\moc\.dotnet\tools\dotnet-ef.exe
        // dotnet ef migrations add AdicionarTabelaLivros --project Repositories --startup-project Proway.Projeto00
        // dotnet ef database update --project Repositories --startup-project Proway.Projeto00
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Registrar os mapeamentos das tabelas com suas colunas
            // e propriedades da entidade
            modelBuilder.ApplyConfiguration(new CategoriaMapeamento());
            modelBuilder.ApplyConfiguration(new LivroMapeamento());
        }
    }
}
// DbFirst
// CodeFirst