using Globalization.Resources;
using Microsoft.AspNetCore.Mvc;
using Service.Exceptions;
using Service.Extensions;
using Service.Services.Categorias;
using Service.Services.Livros;
using Service.ViewModels.Livros;

namespace Proway.Projeto00.Controllers
{
    [Route("livros")]
    public class LivroController : ProjectControllerBase
    {
        private readonly ILivroService _livroService;
        private readonly ICategoriaService _categoriaService;

        public LivroController(
            ILivroService livroService,
            ICategoriaService categoriaService)
        {
            _livroService = livroService;
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var livros = _livroService.ObterTodos();

            return View(livros);
        }

        [HttpGet("cadastrar")]
        public IActionResult Cadastrar()
        {
            var livroCadastrarViewModel = new LivroCadastrarViewModel();

            var categorias = _categoriaService.ObterTodos();

            ViewBag.Categorias = categorias;

            return View(livroCadastrarViewModel);
        }

        [HttpPost("cadastrar")]
        public IActionResult Cadastrar(LivroCadastrarViewModel viewModel)
        {
            var livroIndeViewModel = _livroService.Cadastrar(viewModel);

            StoreSuccessMessageOnTempData(Resource.EntityCreated.Format($"Livro '{viewModel.Titulo}'"));

            return RedirectToAction("Editar", new {id = livroIndeViewModel.Id});
        }

        [HttpGet("apagar/{id}")]
        public IActionResult Apagar(int id)
        {
            try
            {
                _livroService.Apagar(id);

                StoreSuccessMessageOnTempData(Resource.EntityRemoved.Format("Livro"));
            }
            catch (NotFoundException e)
            {
                StoreExceptionMessageOnTempData(e);
            }

            return RedirectToAction("Index");
        }

        [HttpGet("editar/{id}")]
        public IActionResult Editar(int id)
         {
            try
            {
                var livroEditarViewModel = _livroService.ObterPorId(id);

                var categorias = _categoriaService.ObterTodos();
                ViewBag.Categorias = categorias;

                return View(livroEditarViewModel);
            }
            catch (NotFoundException e)
            {
                StoreExceptionMessageOnTempData(e);

                return RedirectToAction("Index");
            }
        }

        [HttpPost("editar/{id}")]
        public IActionResult Editar(int id, LivroEditarViewModel viewModel)
        {
            try
            {
                viewModel.Id = id;
                _livroService.Editar(viewModel);

                StoreSuccessMessageOnTempData(Resource.EntityUpdated.Format("Livro"));
            }
            catch (NotFoundException e)
            {
                StoreExceptionMessageOnTempData(e);
            }

            return RedirectToAction("Index");
        }
    }
}
