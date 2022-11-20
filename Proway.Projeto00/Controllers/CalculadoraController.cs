using Microsoft.AspNetCore.Mvc;
using Proway.Projeto00.Enums;

namespace Proway.Projeto00.Controllers
{
    public class CalculadoraController : ProjectControllerBase
    {
        // Método: (verbo)
        // - POST
        // - GET
        // - PUT
        // - PATCH
        // - DELETE

        // MVC (Model, View, Controller): (POST, GET)
        //      Back-end com front-end
        // Web API: (POST, GET, PUT, PATCH, DELETE)
        //      Model, Controller Back-end
        //      MOdel, Views .... : Front-end (javascript vanilla, jQuery, Angular, REact)
        //      Aplicação Mobile: Kotlin (Android), Swift (iOS), Flutter(Android, iOS)
        // https://developer.mozilla.org/en-US/docs/Web/HTTP/Status#server_error_responses
        //200 - Ok
        //201 - Created
        //400 - Bad Request 
        //422 - Unprocessable Entity(quando ocorre erro de validação)
        //404 - Not Found
        //500 - Internal Server Error

        // Atributo
        [HttpGet] // Rota
        [Route("/calculadora/index")]
        public IActionResult Index()
        {
            return View("Index"); // Retorna StatusCode 200 - OK
        }

        [HttpPost]
        [Route("/calculadora/calcular")]
        public IActionResult Calcular(int numero1, int numero2, int pagina)
        {
            var soma = numero1 + numero2;

            // Passar para o cshtml a variável criada no C#
            ViewBag.ResultadoSoma = soma;
            ViewBag.Numero1 = numero1.ToString(); // converte o int para string
            ViewBag.Numero2 = numero2.ToString();

            if (pagina == (int)PaginaDirecionamento.Mesma)
                return View();

            return View("Index");
        }
    }
}
