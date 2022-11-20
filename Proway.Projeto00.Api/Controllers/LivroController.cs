using Globalization.Resources;
using Microsoft.AspNetCore.Mvc;
using Service.Exceptions;
using Service.Extensions;
using Service.Services.Categorias;
using Service.Services.Livros;
using Service.ViewModels.Livros;

namespace Proway.Projeto00.API.Controllers
{
    [Route("livros")]
    public class LivroController : ProjectApiControllerBase
    {
        private readonly ILivroService _livroService;
        public LivroController(ILivroService livroService)
        {
            _livroService = livroService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var livros = _livroService.ObterTodos();

            return Ok(livros);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var livro = _livroService.ObterPorId(id);
            return Ok(livro);
        }

        [HttpPost("")]
        public IActionResult Cadastrar([FromBody] LivroCadastrarViewModel viewModel)
        {
            var livroCadastrarViewModel = _livroService.Cadastrar(viewModel);

            return CreatedAtAction("ObterPorId",
                new { id = livroCadastrarViewModel.Id }, livroCadastrarViewModel);
        }

        [HttpDelete("{id}")]
        public IActionResult Apagar(int id)
        {
            _livroService.Apagar(id);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Editar(int id, [FromBody] LivroEditarViewModel viewModel)
        {
            viewModel.Id = id;

            _livroService.Editar(viewModel);

            return Ok();
        }
    }
}
