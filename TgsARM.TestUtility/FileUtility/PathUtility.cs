using System.IO;
using System.Reflection;

namespace TgsARM.TestUtility.FileUtility
{

    public static class PathUtility
    {
        public static string GetBuildRootDirectory() => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public static string GetResourcePath(string relativeFilePath) => Path.Combine(GetBuildRootDirectory(), relativeFilePath);
    }

}
