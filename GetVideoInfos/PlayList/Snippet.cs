using System.Text.Json.Serialization;

namespace GetVideoInfos.PlayList
{
    public class Snippet
    {
        [JsonPropertyName("publishedAt")] public string PublishedAt { get; set; }
        [JsonPropertyName("channelId")] public string ChannelId { get; set; }
        [JsonPropertyName("title")] public string Title { get; set; }
        [JsonPropertyName("Description")] public string Description { get; set; }
        [JsonPropertyName("thumbnails")] public Thumbnails Thumbnails { get; set; }
        [JsonPropertyName("channelTitle")] public string ChannelTitle { get; set; }
        [JsonPropertyName("playlistId")] public string PlaylistId { get; set; }
        [JsonPropertyName("position")] public int Position { get; set; }
        [JsonPropertyName("resourceId")] public ResourceId ResourceId { get; set; }
    }
}