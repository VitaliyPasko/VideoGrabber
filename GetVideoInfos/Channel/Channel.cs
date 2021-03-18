using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GetVideoInfos.Channel
{
    public class Channel
    {
        [JsonPropertyName("kind")] public string Kind { get; set; }
        [JsonPropertyName("etag")] public string Etag { get; set; }
        [JsonPropertyName("nextPageToken")] public string NextPageToken { get; set; }
        [JsonPropertyName("regionCode")] public string RegionCode { get; set; }
        [JsonPropertyName("pageInfo")] public PageInfo PageInfo { get; set; }
        [JsonPropertyName("items")] public List<Item> Items { get; set; }
    }
}