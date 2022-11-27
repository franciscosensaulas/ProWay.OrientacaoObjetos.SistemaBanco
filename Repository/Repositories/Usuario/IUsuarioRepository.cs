using Repository.Repositories.Generic;
using UsuarioEntidade = Repository.Entities.Usuario;

namespace Repository.Repositories.Usuario
{
    public interface IUsuarioRepository : IRepositoryBase<UsuarioEntidade>
    {
        UsuarioEntidade? GetByLoginAndPassword(string login, string senha);
    }
}