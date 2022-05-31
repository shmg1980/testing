using Newtonsoft.Json;
using TgsARM.TestUtility.Configuration;

namespace TgsARM.TestUtility.Input
{

    internal class InputSimConfig : IConfigData
    {
        [JsonProperty("shortSleepTime")]
        public int ShortSleepTime { get; }
        [JsonProperty("longSleepTime")]
        public int LongSleepTime { get; }

        [JsonConstructor]
        public InputSimConfig(int shortSleepTime, int longSleepTime)
        {
            ShortSleepTime = shortSleepTime;
            LongSleepTime = longSleepTime;
        }
    }

}
