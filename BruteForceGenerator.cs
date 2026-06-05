using System;
using System.Collections.Generic;

namespace BruteForcePasswordCracker
{
    public class BruteForceGenerator
    {
        private const string CharSet = "abcdefghijklmnopqrstuvwxyz";

        // produces every possible combination
        public IEnumerable<string> GenerateCombinations(int length)
        {
            int[] indexes = new int[length];

            while (true)
            {
                char[] word = new char[length];
                for (int i = 0; i < length; i++)
                {
                    word[i] = CharSet[indexes[i]];
                }
                yield return new string(word);

                int position = length - 1;
                while (position >= 0)
                {
                    indexes[position]++;
                    if (indexes[position] < CharSet.Length)
                    {
                        break; 
                    }
                    indexes[position] = 0; 
                    position--;
                }

                if (position < 0)
                {
                    yield break;
                }
            }
        }
    }
}