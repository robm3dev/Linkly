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

        /// <summary>
        /// Method to do a deep clone of the MenuItem Object, including the LinkOptions object if it exists.
        /// </summary>
        /// <returns>The Deep Clone of the MenuItem objects</returns>
        public MenuItem Clone()
        {
            // Deep Clone the Menu Item
            var clone = new MenuItem()
            {
                MenuItemType = this.MenuItemType,
                Name = this.Name,
                ImageFileName = this.ImageFileName
            };

            // Deep Clone the LinkOptions object if it exists
            if (this.LinkOptions != null)
            {
                clone.LinkOptions = new LinkOptions()
                {
                    Url = this.LinkOptions.Url,
                    Browser = this.LinkOptions.Browser,
                    IsIncognito = this.LinkOptions.IsIncognito,
                    IsNewWindow = this.LinkOptions.IsNewWindow,
                    LaunchOnStartup = this.LinkOptions.LaunchOnStartup,
                    ParamReplacementsDic = this.LinkOptions.ParamReplacementsDic != null
                        ? new Dictionary<string, string>(this.LinkOptions.ParamReplacementsDic)
                        : null
                };
            }

            return clone;
        }
    }
}
