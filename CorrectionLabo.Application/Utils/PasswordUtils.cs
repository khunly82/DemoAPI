using System.Security.Cryptography;
using System.Text;

namespace CorrectionLabo.Application.Utils
{
    public static class PasswordUtils
    {
        public static string CreatePassword()
        {
            return Guid.NewGuid().ToString()[..8];
        }

        public static byte[] HashPassword(string plainPassword, string salt)
        {
            return SHA512.HashData(Encoding.UTF8.GetBytes(plainPassword + salt));
        }

        public static bool Verify(byte[] encodedPassword, string plainPassword, string salt)
        {
            // attention il faut compare les valeurs et pas les references
            return HashPassword(plainPassword, salt).SequenceEqual(encodedPassword);
        }
    }
}
