using System;
using System.Collections.Generic;
using TgsARM.TestUtility.StringHelpers;
using System.Linq;
using TgsARM.TestUtility.Extensions;
using Aquality.Selenium.Core.Logging;

namespace TgsARM.TestUtility.Maths
{

    public static class RandomGenerator
    {
        private static Random Random = new Random();

        public static string NextEmail(int minLength, int maxLength)
        {           
            var email = NextStringFromCharPool(minLength, maxLength, CharUtility.EmailChars);

            if (email.First() == '.')
            {
                email.Skip(1).Prepend(CharUtility.EmailSafeChars.RandomElement());
            }

            if (email.Last() == '.')
            {
                email.Take(email.Count() - 1).Append(CharUtility.EmailSafeChars.RandomElement());
            }

            while (email.Contains(".."))
            {
                var dotIndex = email.IndexOf("..");
                email.Remove(dotIndex, 1);
                email.Insert(dotIndex, CharUtility.EmailSafeChars.RandomElement().ToString());
            }

            return email;
        }           

        public static string NextDomain(int minLength, int maxLength) => 
            NextStringFromCharPool(minLength, maxLength, CharUtility.DomainChars);

        public static string NextStringFromCharPool(int minLength, int maxLength, IEnumerable<char> charPool)
        {
            Logger.Instance.Info("Generating a random string.");

            if (maxLength <= 0)
            {
                Logger.Instance.Error("Requested random string max length is less than zero.");
                throw new ArgumentOutOfRangeException("Random string must contain at least one character.");
            }

            var chars = new char[NextInt(Math.Max(minLength, 0), maxLength + 1)];

            for (int i = 0; i < chars.Length; i++)
            {
                chars[i] = charPool.RandomElement();
            }

            return new string(chars);
        }
        
        public static string NextStringWithMinReqs(int minLength, int maxLength, StringRequirements requirements, params char[] requiredChars)
        {
            Logger.Instance.Info($"Generating a random string with min requirements.");

            if (maxLength <= 0)
            {
                Logger.Instance.Error("Requested random string max length is less than zero.");
                throw new ArgumentOutOfRangeException("Random string must contain at least one character.");
            }

            var charPool = new List<char>();
            var chars = new List<char>();           

            if (requirements.HasFlag(StringRequirements.ContainNumeric))
            {
                chars.Add(CharUtility.GetRandomNumericChar());
                charPool.AddRange(CharUtility.NumericChars);
            }

            if (requirements.HasFlag(StringRequirements.ContainSpecial))
            {
                chars.Add(CharUtility.GetRandomSpecialChar());
                charPool.AddRange(CharUtility.SpecialChars);
            }

            if (requirements.HasFlag(StringRequirements.ContainLatin))
            {
                var c = CharUtility.GetRandomLatinChar();
                charPool.AddRange(CharUtility.GetLatinChars());

                if (requirements.HasFlag(StringRequirements.ContainUpperCase))
                {
                    c = char.ToUpper(c);
                    charPool.AddRange(CharUtility.GetLatinChars(true));
                }

                chars.Add(c);
            }

            if (requirements.HasFlag(StringRequirements.ContainCyrillic))
            {
                var c = CharUtility.GetRandomCyrillicChar();
                charPool.AddRange(CharUtility.GetCyrillicChars());

                if (requirements.HasFlag(StringRequirements.ContainUpperCase))
                {
                    c = char.ToUpper(c);
                    charPool.AddRange(CharUtility.GetCyrillicChars(true));
                }

                chars.Add(c);
            }       

            chars.AddRange(requiredChars.Except(chars));

            if (chars.Count > maxLength)
            {
                Logger.Instance.Error("Requested random string max length is not enough to satisfy all requirements.");
                throw new ArgumentException("Max string length is not enough to satisfy all requirements.");
            }

            var length = NextInt(Math.Max(chars.Count, minLength), maxLength + 1);

            while (chars.Count < length)
            {
                chars.Insert(NextInt(chars.Count), charPool.RandomElement());
            }

            return new string(chars.ToArray());
        }

        public static int NextInt() => NextInt(0, int.MaxValue);

        public static int NextInt(int max) => NextInt(0, max);

        public static int NextInt(int min, int max) => Random.Next(min, max);
    }

}
