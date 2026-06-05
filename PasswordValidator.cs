namespace BruteForcePasswordCracker
{
    public class PasswordValidator
    {
        private PasswordHasher passwordHasher = new PasswordHasher();

        public bool IsMatch(string guess, string targetHash)
        {
            string guessHash = passwordHasher.HashPassword(guess);

            return guessHash == targetHash;
        }
    }
}