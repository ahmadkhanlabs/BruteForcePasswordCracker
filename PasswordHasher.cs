using System;
using System.Security.Cryptography;
using System.Text;

namespace BruteForcePasswordCracker
{
    public class PasswordHasher
    {
        private const string Salt = "Ahmad2026";

        public string HashPassword(string password)
        {
            //don't allow a null password
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password), "Password cannot be null.");
            }

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] data = Encoding.UTF8.GetBytes(Salt + password);

                byte[] result = sha256.ComputeHash(data);

                StringBuilder hashString = new StringBuilder();
                foreach (byte b in result)
                {
                    hashString.Append(b.ToString("x2"));
                }
                return hashString.ToString();
            }
        }
    }
}