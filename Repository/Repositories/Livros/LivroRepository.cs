using Microsoft.EntityFrameworkCore;
using Repository.Database;
using Repository.Entities;
using Repository.Repositories.Generic;

namespace Repository.Repositories.Livros
{
    public class LivroRepository : RepositoryBase<Livro>, ILivroRepository
    {
        public LivroRepository(ProjetoContext context) : base(context)
        {
        }

        public override List<Livro> GetAll()
        {
            return _dbSet
                .Include(x => x.Categoria)
                .ToList();
        }
    }
}

