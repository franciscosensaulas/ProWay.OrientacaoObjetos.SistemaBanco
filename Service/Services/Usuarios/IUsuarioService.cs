using Repository.Entities;
using Service.ViewModels.Usuarios;

namespace Service.Services.Usuarios
{
    public interface IUsuarioService
    {
        Usuario Autenticar(UsuarioViewModel viewModel);
    }
}