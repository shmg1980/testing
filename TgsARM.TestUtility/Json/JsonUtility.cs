using Aquality.Selenium.Core.Logging;
using Newtonsoft.Json;
using System.IO;

namespace TgsARM.TestUtility.Json
{

    public class JsonUtility
    {
        public static T Deserialize<T>(string path)
        {
            Logger.Instance.Info($"Deserializing JSON document as {typeof(T).Name}. Source: {path}.");

            using (var reader = new StreamReader(path))
            {
                var json = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(json);
            }
        }
    }

}
