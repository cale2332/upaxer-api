using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace WebApp.Common.Helpers
{
    public class RandomGenerator
    {
        private const string AllowableCharacters = "abcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private static string GenerateString(int length)
        {
            var bytes = new byte[length];

            using (var random = RandomNumberGenerator.Create())
            {
                random.GetBytes(bytes);
            }

            return new string(bytes.Select(x => AllowableCharacters[x % AllowableCharacters.Length]).ToArray());
        }

        public static KeyValuePair<string, string> EncryptPassword(string password, bool isAutoPassword)
        {
            if (string.IsNullOrEmpty(password) || isAutoPassword)
            {
                password = GenerateString(6);
            }

            var passwordEncrypted = Protector.Encrypt(password, string.Empty);
            return new KeyValuePair<string, string>(password, passwordEncrypted);
        }
    }
}
