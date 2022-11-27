using Globalization.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Proway.Projeto00.API.Filters
{
    public class AuthenticatedFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var usuarioJson = context.HttpContext.Session.GetString("userSession");

            if(usuarioJson == null)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}