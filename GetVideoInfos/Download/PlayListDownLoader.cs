using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using VideoLibrary;

namespace GetVideoInfos.Download
{
    public class PlayListDownLoader : Downloader
    {
        private readonly string _playlistId;
        public PlayListDownLoader(string playlistId)
        {
            _playlistId = playlistId;
        }
        public async Task DownLoad()
        {
            string link = GetStringForChannel();
            var stringTask = HttpClient.GetStringAsync(link);
            string json = await stringTask;
            PlayList.PlayList playList = GetMediaObject(json);
            InitializeIdListFromPlayList(playList);
            ChannelTitle = playList.Items[0].Snippet.ChannelTitle;
            Download(IdList, ChannelTitle);
        }

        public override string GetStringForChannel() =>
            $"https://www.googleapis.com/youtube/v3/playlistItems?part=snippet&playlistId={_playlistId}&maxResults=50&key={GoogleApiKey}";
        
        private PlayList.PlayList GetMediaObject(string json) => JsonSerializer.Deserialize<PlayList.PlayList>(json);

        private void InitializeIdListFromPlayList(PlayList.PlayList playList)
        {
            foreach (var item in playList.Items)
                IdList.Add(item.Snippet.ResourceId.VideoId);
        }

        public override void Download(List<string> idList, string channelTitle)
        {
            foreach (var id in idList)
            {
                Console.WriteLine("Awesome! Downloading...");
                Console.WriteLine(id);
                YouTubeVideo video = Service.GetVideo("https://youtube.com/watch?v=" + id);
                var folder = GetDefaultFolder(channelTitle);
                string path = Path.Combine(folder, video.FullName);
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);
                File.WriteAllBytes(path, video.GetBytes());
            }
        }
    }
}