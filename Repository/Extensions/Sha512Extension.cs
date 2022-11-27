using System.Security.Cryptography;
using System.Text;

namespace Repository.Extensions
{
    public static class Sha512Extension
    {
        public static string Hash(this string senha)
        {
            var shaManaged = new SHA512Managed();
            var senhaBytes = Encoding.UTF8.GetBytes(senha);
            var senhaCriptografada = BitConverter.ToString(shaManaged.ComputeHash(senhaBytes)).Replace("-", "");

            return senhaCriptografada;
        }
    }
}
