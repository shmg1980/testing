using System.Collections.Generic;
using TgsARM.TestUtility.Extensions;

namespace TgsARM.TestUtility.StringHelpers
{

    public static class CharUtility
    {
        private const string numericChars = "12345678890";
        private const string latinChars = "abcdefghijklmnopqrstuvwxyz";
        private const string cyrillicChars = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        private const string specialChars = @"!#$%&'*+-/=?^_`{|}~";

        public static readonly IEnumerable<char> EmailSafeChars = numericChars + latinChars + specialChars + latinChars.ToUpper();
        public static readonly IEnumerable<char> EmailChars = EmailSafeChars + ".";     
        public static readonly IEnumerable<char> DomainChars = latinChars;
        public static readonly IEnumerable<char> SpecialChars = specialChars;
        public static readonly IEnumerable<char> NumericChars = numericChars;

        private const string letterChars = latinChars + cyrillicChars;
        private const string alphanumericChars = latinChars + cyrillicChars + numericChars;

        public static IEnumerable<char> GetLatinChars(bool upperCase = false) =>
            upperCase ? latinChars.ToUpper() : latinChars;

        public static IEnumerable<char> GetCyrillicChars(bool upperCase = false) =>
            upperCase ? cyrillicChars.ToUpper() : cyrillicChars;

        public static char GetRandomNumericChar() => numericChars.RandomElement();

        public static char GetRandomLatinChar() => latinChars.RandomElement();

        public static char GetRandomCyrillicChar() => cyrillicChars.RandomElement();

        public static char GetRandomLetterChar() => letterChars.RandomElement();

        public static char GetRandomAlphanumericChar() => alphanumericChars.RandomElement();

        public static char GetRandomSpecialChar() => specialChars.RandomElement();   
    }

}
