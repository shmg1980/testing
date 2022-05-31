using System.Collections.Generic;
using System.Linq;
using TgsARM.TestUtility.Maths;

namespace TgsARM.TestUtility.Extensions
{

    public static class CollectionExtensions
    {
        public static T RandomElement<T>(this IEnumerable<T> colletion) =>
            colletion.ElementAt(RandomGenerator.NextInt(colletion.Count()));
    }

}
