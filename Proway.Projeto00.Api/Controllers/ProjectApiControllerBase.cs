using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Proway.Projeto00.API.Responses;

namespace Proway.Projeto00.API.Controllers
{
    public class ProjectApiControllerBase : ControllerBase
    {
        public override OkObjectResult Ok([ActionResultObjectValue] object? value)
        {
            var responseMessage = ResponseMessage.ConstruirComDado(value);

            return base.Ok(responseMessage);
        }
    }
}
