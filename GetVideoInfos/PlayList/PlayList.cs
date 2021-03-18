using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GetVideoInfos.PlayList
{
    public class PlayList
    {
        [JsonPropertyName("kind")] public string Kind { get; set; }
        [JsonPropertyName("etag")] public string Etag { get; set; }
        [JsonPropertyName("items")] public List<Item> Items { get; set; }
    }
}