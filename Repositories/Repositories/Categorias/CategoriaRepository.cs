using Repository.Database;
using Repository.Entities;
using Repository.Repositories.Generic;

namespace Repository.Repositories.Categorias
{
    public class CategoriaRepository : RepositoryBase<Categoria>, ICategoriaRepository
    {
        // private -> somente na classe
        // internal -> publico porém somente dentro do mesmo projeto
        // public -> acessar de qualquer parte
        // protected -> private porém classes filhas conseguem acessar
        public CategoriaRepository(ProjetoContext context) : base(context)
        {
        }
    }
}
