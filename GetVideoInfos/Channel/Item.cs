using System.Text.Json.Serialization;

namespace GetVideoInfos.Channel
{
    public class Item
    {
        [JsonPropertyName("kind")] public string Kind { get; set; }
        [JsonPropertyName("etag")] public string Etag { get; set; }
        [JsonPropertyName("id")] public Id Id { get; set; }
        [JsonPropertyName("snippet")] public Snippet Snippet { get; set; }
    }
}