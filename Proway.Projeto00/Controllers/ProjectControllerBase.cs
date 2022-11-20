using Microsoft.AspNetCore.Mvc;
using Service.Exceptions;

namespace Proway.Projeto00.Controllers
{
    public class ProjectControllerBase : Controller
    {
        public const string KeyMessageSuccess = "MensagemSucesso";
        public const string KeyMessageError = "MensagemErro";

        protected void StoreExceptioMessageOnTempData(NotFoundException exception) => 
                TempData[KeyMessageError] = exception.Message;
        
        protected void StoreSucessMessageOnTempData(string message) => 
            TempData[KeyMessageSuccess] = message;
    }
}
