using Newtonsoft.Json;
using TgsARM.TestUtility.Configuration;

namespace UserInterface.Tests.TestConfig
{

    internal class CardsTestConfig : IConfigData
    {
        [JsonProperty("minPasswordLength")]
        public int MinPasswordLength { get; }
        [JsonProperty("domain")]
        public string Domain { get; }
        [JsonProperty("interestsToSelect")]
        public int InterestsToSelect { get; }
        [JsonProperty("avatarImgPath")]
        public string AvatarImgPath { get; }

        [JsonConstructor]
        public CardsTestConfig(int minPasswordLength, string domain, int interestsToSelect, string avatarImgPath)
        {
            MinPasswordLength = minPasswordLength;
            Domain = domain;
            InterestsToSelect = interestsToSelect;
            AvatarImgPath = avatarImgPath;
        }
    }

}
