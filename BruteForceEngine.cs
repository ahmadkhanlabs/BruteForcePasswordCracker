using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BruteForcePasswordCracker
{
    public class BruteForceEngine
    {
        private BruteForceGenerator generator = new BruteForceGenerator();
        private PasswordValidator validator = new PasswordValidator();

        private const string CharSet = "abcdefghijklmnopqrstuvwxyz";
        private const int MaxLength = 6;

        // ---------- SINGLE-THREADED (Version 6) ----------
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

        // ---------- MULTI-THREADED (Version 7) ----------
        public string CrackPasswordParallel(string targetHash)
        {
            int threadCount = Environment.ProcessorCount - 1;
            if (threadCount < 1) threadCount = 1;

            string foundPassword = null;
            var cancel = new CancellationTokenSource();

            for (int length = 1; length <= MaxLength; length++)
            {
                if (foundPassword != null) break;

                int currentLength = length;
                var tasks = new List<Task>();

                for (int t = 0; t < threadCount; t++)
                {
                    int threadIndex = t;
                    Task task = Task.Run(() =>
                    {
                        for (int first = threadIndex; first < CharSet.Length; first += threadCount)
                        {
                            char firstLetter = CharSet[first];

                            foreach (string guess in GenerateWithFirstLetter(firstLetter, currentLength))
                            {
                                if (cancel.Token.IsCancellationRequested)
                                    return;

                                if (validator.IsMatch(guess, targetHash))
                                {
                                    foundPassword = guess;
                                    cancel.Cancel();
                                    return;
                                }
                            }
                        }
                    });
                    tasks.Add(task);
                }

                Task.WaitAll(tasks.ToArray());
            }

            return foundPassword;
        }
        private IEnumerable<string> GenerateWithFirstLetter(char firstLetter, int length)
        {
            if (length == 1)
            {
                yield return firstLetter.ToString();
                yield break;
            }

            foreach (string rest in generator.GenerateCombinations(length - 1))
            {
                yield return firstLetter + rest;
            }
        }
    }
}