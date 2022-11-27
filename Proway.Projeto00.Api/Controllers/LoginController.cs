using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proway.Projeto00.API.Responses;
using Repository.Extensions;
using Service.Exceptions;
using Service.Services.Usuarios;
using Service.ViewModels.Usuarios;

namespace Proway.Projeto00.API.Controllers
{
    [Route("login")]
    public class LoginController : ProjectApiControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<LoginController> _logger;
        private readonly IValidator<UsuarioViewModel> _validator;

        public LoginController(
            IUsuarioService usuarioService,
            IHttpContextAccessor httpContextAccessor,
            ILogger<LoginController> logger,
            IValidator<UsuarioViewModel> validator)
        {
            _usuarioService = usuarioService;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
            _validator = validator;
        }

        [HttpPost]
        public IActionResult Autenticar([FromBody] UsuarioViewModel viewModel)
        {
            var validationResult = _validator.Validate(viewModel);

            if (!validationResult.IsValid)
            {
                var responseMessage = ResponseMessage.ConstruirComMensagemErro(
                    string.Join(
                        ",",
                        validationResult.Errors.Select(x => $"{x.PropertyName} => {x.ErrorMessage}").ToList()));

                return UnprocessableEntity(responseMessage);
            }

            try
            {
                viewModel.Senha = viewModel.Senha.Hash();

                _logger.LogDebug($"Iniciando autenticação usuário: {viewModel.Login}");

                var usuario = _usuarioService.Autenticar(viewModel);

                var usuarioJson = JsonConvert.SerializeObject(usuario);

                _httpContextAccessor.HttpContext.Session.SetString("userSession", usuarioJson);

                _logger.LogDebug($"Usuário {viewModel.Login} autenticado com sucesso");

                return Ok();
            }
            catch (UserNotAuthenticatedException ex)
            {
                _logger.LogError($"Usuário {viewModel.Login} não autorizado");

                return Unauthorized();
            }
        }

        [HttpGet("logout")]
        public IActionResult Sair()
        {
            _httpContextAccessor.HttpContext.Session.Remove("userSession");

            return Ok();
        }
    }
}
