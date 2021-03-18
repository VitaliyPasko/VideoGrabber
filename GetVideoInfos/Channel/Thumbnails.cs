using System.Text.Json.Serialization;
using GetVideoInfos.PlayList;

namespace GetVideoInfos.Channel
{
    public class Thumbnails
    {
        [JsonPropertyName("default")] public Default Default { get; set; }
        [JsonPropertyName("medium")] public Medium Medium { get; set; }
        [JsonPropertyName("high")] public High High { get; set; }
    }
}