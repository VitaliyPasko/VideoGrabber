using System.Text.Json.Serialization;

namespace GetVideoInfos.PlayList
{
    public class Item
    {
        [JsonPropertyName("kind")] public string Kind { get; set; }
        [JsonPropertyName("etag")] public string Etag { get; set; }
        [JsonPropertyName("id")] public string Id { get; set; }
        [JsonPropertyName("snippet")] public Snippet Snippet { get; set; }
    }
}