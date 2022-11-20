namespace Proway.Projeto00.API.Responses
{
    public class ResponseMessage
    {
        public string ErrorMessage { get; set; }
        public object Data { get; set; }

        public static ResponseMessage ConstruirComMensagemErro(string errorMessage)
        {
            return new ResponseMessage
            {
                ErrorMessage = errorMessage
            };
        }

        public static ResponseMessage ConstruirComDado(object data) =>
            new ResponseMessage
            {
                Data = data
            };
    }
}