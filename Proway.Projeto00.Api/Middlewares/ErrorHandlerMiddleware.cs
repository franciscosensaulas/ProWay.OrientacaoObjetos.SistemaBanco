using Newtonsoft.Json;
using Proway.Projeto00.API.Responses;
using Service.Exceptions;
using System.Net;

namespace Proway.Projeto00.API.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                int statusCode;
                if (exception is NotFoundException)
                    statusCode = (int)HttpStatusCode.NotFound;
                else
                    statusCode = (int)HttpStatusCode.InternalServerError;

                var errorMessage = exception.Message;
                var responseMessage = ResponseMessage.ConstruirComMensagemErro(errorMessage);
                context.Response.StatusCode = statusCode;
                context.Response.ContentType = "application/json";

                var responseMessageJson = JsonConvert.SerializeObject(responseMessage);
                await context.Response.WriteAsync(responseMessageJson);
            }
        }
    }
}