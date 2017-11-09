using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Login
{
    public static class PasswordGenerator
    {
        public static string GeneratePassword(int length)
        {
            var provider = new RNGCryptoServiceProvider();
            var password = new StringBuilder();
            var bytes = new byte[length];
            provider.GetBytes(bytes);
            for (var i = 0; i < length; i++)
            {
                var symbol = Convert.ToInt32(bytes[i]) % '~';
                password.Append((char)(symbol + ' ' > '~' ? symbol : symbol + ' ' + 1));
            }
            return password.ToString();
        }
    }
}
