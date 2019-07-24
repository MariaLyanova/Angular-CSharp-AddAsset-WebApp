using Newtonsoft.Json;
using System;

namespace AngularCSharp_AddAssetApp.Models
{
    public class AssetViewModel
    {
        [JsonProperty("assetId")]
        public Guid AssetId { get; set; }

        [JsonProperty("title")]
        public string FileName { get; set; }

        [JsonProperty("mimeType")]
        public string MimeTypeName { get; set; }

        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("countryName")]
        public string CountryName { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}