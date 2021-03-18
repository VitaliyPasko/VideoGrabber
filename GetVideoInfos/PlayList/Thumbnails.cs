using System.Text.Json.Serialization;

namespace GetVideoInfos.PlayList
{
    public class Thumbnails
    {
        [JsonPropertyName("default")] public Default Default { get; set; }
        [JsonPropertyName("medium")] public Medium Medium { get; set; }
        [JsonPropertyName("high")] public High High { get; set; }
        [JsonPropertyName("standard")] public Standard Standard { get; set; }
        [JsonPropertyName("maxres")] public Maxres Maxres { get; set; }
    }
}