using Newtonsoft.Json;

namespace TgsARM.TestUtility.Configuration
{

    public class MainConfig : IConfigData
    {
        [JsonProperty("homePageUrl")]
        public string HomePageUrl { get; }
        [JsonProperty("randomStringMinLength")]
        public int RandomStringMinLength { get; }
        [JsonProperty("randomStringMaxLength")]
        public int RandomStringMaxLength { get; } 

        [JsonConstructor]
        public MainConfig(string homePageUrl, int randomStringMinLength, int randomStringMaxLength)
        {
            HomePageUrl = homePageUrl;
            RandomStringMinLength = randomStringMinLength;
            RandomStringMaxLength = randomStringMaxLength;
        }
    }

}
