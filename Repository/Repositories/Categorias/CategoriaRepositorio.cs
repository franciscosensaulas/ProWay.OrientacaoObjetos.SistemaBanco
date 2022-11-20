using Repository.Database;
using Repository.Entities;
using Repository.Repositories.Generic;

namespace Repository.Repositories.Categorias

{
    public class CategoriaRepositorio : RepositoryBase<Categoria>, ICategoriaRepositorio
    {
        public CategoriaRepositorio(ProjetoContext context) : base(context)
        {
        }
    }
}
