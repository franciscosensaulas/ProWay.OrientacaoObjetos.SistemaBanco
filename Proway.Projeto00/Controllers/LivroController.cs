using Globalization.Resources;
using Microsoft.AspNetCore.Mvc;
using Repository.Repositories.Livros;
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
        public LivroController(ILivroService livroService, 
            ILivroRepository livroRepository,
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

        [HttpGet("Cadastrar")]
        public IActionResult Cadastrar()
        {
            var livroCadastrarViewModel = new LivroCadastrarViewModel();

            var categorias = _categoriaService.ObterTodos();

            ViewBag.Categorias = categorias;

            return View(livroCadastrarViewModel);
        }

        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar(LivroCadastrarViewModel viewModel)
        {
            var livroCadastrarViewModel = _livroService.Cadastrar(viewModel);

            StoreSucessMessageOnTempData(Resource.EntityCreated.Format("Livro"));

            return RedirectToAction("Editar", new {id = livroCadastrarViewModel.Id});
        }

        [HttpGet("Apagar/{id}")]
        public IActionResult Apagar(int id)
        {
            try
            {
                _livroService.Apagar(id);

                StoreSucessMessageOnTempData(Resource.EntityRemoved.Format("Livro"));

            }
            catch (NotFoundException ex)
            {
                StoreExceptioMessageOnTempData(ex);
            }

            return RedirectToAction("Index");
        }

        [HttpGet("Editar/{id}")]
        public IActionResult Editar(int id)
        {
            try
            {
                var livroEditarViewModel = _livroService.ObterPorId(id);

                var categorias = _categoriaService.ObterTodos();

                ViewBag.Categorias = categorias;


                return View(livroEditarViewModel);
            }
            catch (NotFoundException ex)
            {
                StoreExceptioMessageOnTempData(ex);
            }

            return RedirectToAction("Index");
        }

        [HttpPost("Editar/{id}")]
        public IActionResult Editar(int id, LivroEditarViewModel viewModel)
        {
            viewModel.Id = id;
            try 
            { 
                _livroService.Editar(viewModel);

                StoreSucessMessageOnTempData(Resource.EntityUpdated.Format("Livro"));

            }
            catch (NotFoundException ex)
            {
                StoreExceptioMessageOnTempData(ex);
            }

            return RedirectToAction("Index");
        }
    }
}
