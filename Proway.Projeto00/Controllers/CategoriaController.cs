using Microsoft.AspNetCore.Mvc;
using Service.Services.Categorias;
using Service.ViewModels.Categorias;

namespace Proway.Projeto00.Controllers
{
    [Route("categorias")]
    public class CategoriaController : ProjectControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            // Select no banco de dados buscando
            // da tabela de categorias todos os registros
            var categoriaIndexViewModels = _categoriaService.ObterTodos();


            return View("Index", categoriaIndexViewModels);
        }

        [HttpGet("cadastrar")]
        public IActionResult Cadastrar()
        {
            var categoriaCadastrarViewModel = new CategoriaCadastrarViewModel();

            return View(categoriaCadastrarViewModel);
        }

        [HttpPost("cadastrar")]
        public IActionResult Cadastrar(CategoriaCadastrarViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var _ = _categoriaService.Cadastrar(viewModel);

            StoreSuccessMessageOnTempData("Categoria Cadastrada com sucesso");

            return RedirectToAction("ObterTodos");
        }

        [HttpGet("apagar/{id}")]
        public IActionResult Apagar(int id)
        {
            _categoriaService.Apagar(id);

            StoreSuccessMessageOnTempData("Categoria apagada com sucesso");

            return RedirectToAction("ObterTodos");
        }

        [HttpGet("editar/{id}")]
        public IActionResult Editar(int id)
        {
            var categoriaIndexViewModel = _categoriaService.ObterPorId(id);

            if (categoriaIndexViewModel == null)
            {
                return RedirectToAction("ObterTodos");
            }

            var categoriaEditarViewModel = new CategoriaEditarViewModel
            {
                Id = id,
                Nome = categoriaIndexViewModel.Nome
            };

            return View(categoriaEditarViewModel);
        }

        [HttpPost("editar/{id}")]
        public IActionResult Editar(int id, CategoriaEditarViewModel categoriaEditarViewModel)
        {
            var categoriaExistente = _categoriaService.ObterPorId(id);

            if (categoriaExistente == null)
                return RedirectToAction("ObterTodos");

            categoriaEditarViewModel.Id = id;
            _categoriaService.Alterar(categoriaEditarViewModel);

            StoreSuccessMessageOnTempData("Categoria alterada com sucesso");

            return RedirectToAction("ObterTodos");
        }
    }
}