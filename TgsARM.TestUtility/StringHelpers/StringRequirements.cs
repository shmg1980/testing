using System;

namespace TgsARM.TestUtility.StringHelpers
{

    [Flags]
    public enum StringRequirements
    {
        None = 0,
        ContainNumeric = 1,
        ContainUpperCase = 2,
        ContainLatin = 4,
        ContainCyrillic = 8,
        ContainSpecial = 16
    }

}
