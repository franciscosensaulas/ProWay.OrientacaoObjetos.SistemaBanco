using Repository.Database;
using Repository.Repositories.Generic;
using UsuarioEntidade = Repository.Entities.Usuario;

namespace Repository.Repositories.Usuario
{
    public class UsuarioRepository : RepositoryBase<UsuarioEntidade>, IUsuarioRepository
    {
        public UsuarioRepository(ProjetoContext context) : base(context)
        {
        }

        public UsuarioEntidade? GetByLoginAndPassword(string login, string senha)
        {
            return _dbSet.FirstOrDefault(x => x.Login == login && x.Senha == senha);
        }
    }
}
