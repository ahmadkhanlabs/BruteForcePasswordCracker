using System;
using System.Text;

namespace BruteForcePasswordCracker
{
    public class PasswordGenerator
    {
        private const string CharSet = "abcdefghijklmnopqrstuvwxyz";

        private Random rng = new Random();
        private PasswordHasher passwordHasher = new PasswordHasher();

       public string PlainPassword { get; private set; } = "";
       public string HashedPassword { get; private set; } = "";

        public void GeneratePassword()
        {
            int length = rng.Next(4, 6);

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                int pick = rng.Next(CharSet.Length);
                result.Append(CharSet[pick]);
            }
            PlainPassword = result.ToString();

            HashedPassword = passwordHasher.HashPassword(PlainPassword);
        }
    }
}