using AnonymousFeedback.Domian.IHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace AnonymousFeedback.Infrastructure.PasswordHashing
{
    public class PasswordHasher : IPasswordHasher
    {
        public  string HashPassword(string password)
        {

            var sha256 = new SHA256Managed();
            var sb = new StringBuilder();
            byte[] crypto = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            foreach (byte theByte in crypto)
                sb.Append(theByte.ToString("x2"));
            return sb.ToString();
        }


        public  bool VerifyPassword(string inputPassword, string hashedPassword)
        {
            string hashedInputPassword = HashPassword(inputPassword);
            return string.Equals(hashedInputPassword, hashedPassword);
        }

    }
}
