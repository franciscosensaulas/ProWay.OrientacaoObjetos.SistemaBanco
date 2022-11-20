using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
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
            //Select no banco de dados buscando todos os registros
            var categoriasIndexViewModel = _categoriaService.ObterTodos();

            return View("Index", categoriasIndexViewModel);
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
            if(!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var _ = _categoriaService.Cadastrar(viewModel);

            StoreSucessMessageOnTempData($"Categoria {viewModel.Nome} cadastrada com Sucesso");

            return RedirectToAction("ObterTodos");
        }

        [HttpGet("apagar/{id}")]
        public IActionResult Apagar(int id)
        {
            _categoriaService.Apagar(id);

            StoreSucessMessageOnTempData("Categoria Apagada com Sucesso!");

            return RedirectToAction("ObterTodos");
        }

        [HttpGet("editar/{id}")]
        public IActionResult Editar(int id)
        {
            var categoriaIndexViewModel = _categoriaService.ObterPorId(id);

            if(categoriaIndexViewModel == null)
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
            {
                return RedirectToAction("ObterTodos");
            }

            StoreSucessMessageOnTempData("Categoria Alterada com Sucesso!");

            categoriaEditarViewModel.Id = categoriaExistente.Id;
            _categoriaService.Alterar(categoriaEditarViewModel);

            return RedirectToAction("ObterTodos");
        }
    }
}
