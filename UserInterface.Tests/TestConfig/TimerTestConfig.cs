using Newtonsoft.Json;
using TgsARM.TestUtility.Configuration;

namespace UserInterface.Tests.TestConfig
{

    internal class TimerTestConfig : IConfigData
    {
        [JsonProperty("expectedTimerValue")]
        public string ExpectedTimerValue { get; }

        [JsonConstructor]
        public TimerTestConfig(string expectedTimerValue)
        {
            ExpectedTimerValue = expectedTimerValue;
        }
    }

}
