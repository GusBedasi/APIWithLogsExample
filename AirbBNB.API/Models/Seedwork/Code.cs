using System;
using System.Linq;
using HashidsNet;

namespace AirbBNB.API.Models.Seedwork
{
    internal static class Code
    {
        private const string LOWERCASE_ALPHABET = "abcdefghijklmnopqrstuvxwxyz";
        private const string UPPERCASE_ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVXWYZ";
        private const string NUMBERS = "1234567890";

        internal static string Create(string prefix)
        {
            var random = new Random();
            
            var alphabet = string.Concat(LOWERCASE_ALPHABET, UPPERCASE_ALPHABET, NUMBERS);
            
            var salt = Guid.NewGuid().ToString();

            var hashids = new Hashids(salt, 16, alphabet);

            var numbers = Enumerable.Range(0, 3)
                .Select(x => random.Next(100)).ToList();
            
            var hash = hashids.Encode(numbers);
            
            hash = string.Concat(prefix, hash);

            return hash;
        }
    }
}