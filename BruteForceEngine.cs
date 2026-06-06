using System;

namespace BruteForcePasswordCracker
{
    public class BruteForceEngine
    {
        private BruteForceGenerator generator = new BruteForceGenerator();
        private PasswordValidator validator = new PasswordValidator();

        private const int MaxLength = 6;

        public string CrackPassword(string targetHash)
        {
            for (int length = 1; length <= MaxLength; length++)
            {
                foreach (string guess in generator.GenerateCombinations(length))
                {
                    if (validator.IsMatch(guess, targetHash))
                    {
                        return guess;
                    }
                }
            }

            return null; 
        }
    }
}