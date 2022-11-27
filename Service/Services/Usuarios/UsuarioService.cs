using Repository.Entities;
using Repository.Repositories.Usuario;
using Service.Exceptions;
using Service.ViewModels.Usuarios;

namespace Service.Services.Usuarios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Usuario Autenticar(UsuarioViewModel viewModel)
        {
            var usuario = _usuarioRepository.GetByLoginAndPassword(viewModel.Login, viewModel.Senha);

            if(usuario == null)
                throw new UserNotAuthenticatedException();

            return usuario;
        }
    }
}
