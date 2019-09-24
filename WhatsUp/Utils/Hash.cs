using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WhatsUp.Utils
{
    public class Hash
    {
        public static byte[] CreateHash(string password)
        {
            var md5 = MD5.Create();

            // Chars and Strings in C# are UTF-16 (Unicode).
            var passwordBytes = Encoding.Unicode.GetBytes(password);

            return md5.ComputeHash(passwordBytes);
            // TODO: Add salt
        }

    }
}