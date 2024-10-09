using System.Security.Cryptography;
using System.Text;

namespace Desafio_Criptografia.Api.Services
{
    public static class CryptoService
    {
        public static string Hash256(string data)
        {

            byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(data));

            StringBuilder builder = new();
            foreach (byte b in bytes)
            {
                builder.Append(b);
            }

            return builder.ToString();
        }
    }
}