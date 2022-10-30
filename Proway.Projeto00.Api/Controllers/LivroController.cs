using Microsoft.AspNetCore.Mvc;
using Service.Exceptions;
using Service.Services.Livros;
using Service.ViewModels.Livros;

namespace Proway.Projeto00.Controllers
{
    [Route("livros")]
    public class LivroController : ControllerBase
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
            try
            {
                var livro = _livroService.ObterPorId(id);
                return Ok(livro);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost()]
        public IActionResult Cadastrar([FromBody] LivroCadastrarViewModel viewModel)
        {
            var livroIndeViewModel = _livroService.Cadastrar(viewModel);

            return CreatedAtAction("Livro", new {id = livroIndeViewModel.Id}, livroIndeViewModel);
        }

        [HttpDelete("{id}")]
        public IActionResult Apagar(int id)
        {
            try
            {
                _livroService.Apagar(id);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Editar(int id, [FromBody] LivroEditarViewModel viewModel)
        {
            try
            {
                viewModel.Id = id;
                _livroService.Editar(viewModel);

                return Ok(); // 200
            }
            catch (NotFoundException)
            {
                return NotFound(); // 404
            }
        }
    }
}
