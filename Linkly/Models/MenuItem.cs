using System.Text.Json.Serialization;

namespace Linkly.Models
{
    public class MenuItem
    {
        [JsonPropertyName("menuItemType")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public MenuItemType MenuItemType { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("imageFileName")]
        public string ImageFileName { get; set; }

        [JsonPropertyName("linkOptions")]
        public LinkOptions LinkOptions { get; set; }
    }
}
