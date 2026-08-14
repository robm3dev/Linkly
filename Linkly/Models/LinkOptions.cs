using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Linkly.Models
{
    public class LinkOptions
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("browser")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public BrowserType Browser { get; set; }

        [JsonPropertyName("isIncognito")]
        public bool IsIncognito { get; set; }

        [JsonPropertyName("isNewWindow")]
        public bool IsNewWindow { get; set; }  
        
        [JsonPropertyName("paramReplacementsDic")]
        public Dictionary<string, string> ParamReplacementsDic { get; set; }
    }
}
