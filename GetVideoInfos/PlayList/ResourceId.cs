using System.Text.Json.Serialization;

namespace GetVideoInfos.PlayList
{
    public class ResourceId
    {
        [JsonPropertyName("kind")] public string Kind { get; set; }
        [JsonPropertyName("videoId")] public string VideoId { get; set; }
    }
}