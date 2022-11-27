namespace Service.Exceptions
{
    public class UserNotAuthenticatedException : Exception
    {
        public UserNotAuthenticatedException(): base("Usuário não autorizado")
        {
        }
    }
}
