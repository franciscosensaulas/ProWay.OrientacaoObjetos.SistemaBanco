using Microsoft.AspNetCore.Mvc;
using Proway.Projeto00.Models;

namespace Proway.Projeto00.Controllers
{
    [Route("/colaborador")]
    public class ColaboradorController : ProjectControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("Calcular")]
        public IActionResult Calcular(ColaboradorFolhaPagamentoViewModel viewModel)
        {
            if (ModelState.IsValid == false)
            {
                return View("Index", viewModel);
            }

            var salarioLiquido = viewModel.CalcularSalarioliquido();

            return Ok($"Salário Líquido: {salarioLiquido:C2}");
        }
    }
}
