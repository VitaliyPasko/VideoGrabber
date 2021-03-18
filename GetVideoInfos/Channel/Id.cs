using System.Text.Json.Serialization;

namespace GetVideoInfos.Channel
{
    public class Id
    {
        [JsonPropertyName("kind")] public string Kind { get; set; }
        [JsonPropertyName("videoId")] public string VideoId { get; set; }
    }
}