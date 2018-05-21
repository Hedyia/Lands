using Newtonsoft.Json;

namespace Lands.Models
{
    public class Translation
    {
        [JsonProperty(PropertyName = "de")]
        public string DE { get; set; }
        [JsonProperty(PropertyName = "es")]
        public string ES { get; set; }
        [JsonProperty(PropertyName = "fr")]
        public string FR { get; set; }
        [JsonProperty(PropertyName = "ja")]
        public string JA { get; set; }
        [JsonProperty(PropertyName = "it")]
        public string IT { get; set; }
        [JsonProperty(PropertyName = "br")]
        public string BR { get; set; }
        [JsonProperty(PropertyName = "pt")]
        public string PT { get; set; }
        [JsonProperty(PropertyName = "nl")]
        public string NL { get; set; }
        [JsonProperty(PropertyName = "hr")]
        public string HR { get; set; }
        [JsonProperty(PropertyName = "fa")]
        public string FA { get; set; }
    }
}
