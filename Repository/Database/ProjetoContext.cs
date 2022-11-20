using Microsoft.EntityFrameworkCore;
using Repository.Mapeamento;

namespace Repository.Database
{
    public class ProjetoContext : DbContext
    {
        public ProjetoContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Registrar o mapeamento das tabelas com suas colunas e propriedade da entidade
            modelBuilder.ApplyConfiguration(new CategoriaMapeamento());
            modelBuilder.ApplyConfiguration(new LivroMapeamento());
        }
    }
}
