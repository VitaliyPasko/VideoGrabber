using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using VideoLibrary;

namespace GetVideoInfos.Download
{
    public class ChannelDownloader : Downloader
    {
        private readonly string _channelId;
        
        public ChannelDownloader(string channelId)
        {
            _channelId = channelId;
        }
        public async Task DownLoad()
        {
            string link = GetStringFoChannel();
            var stringTask = HttpClient.GetStringAsync(link);
            string json = await stringTask;
            Channel.Channel channel = GetMediaObject(json);
            InitializeIdListFromChannel(channel);
            ChannelTitle = channel.Items[0].Snippet.ChannelTitle;
            Download(IdList, ChannelTitle);
        }
        public override string GetStringFoChannel() =>
            $"https://www.googleapis.com/youtube/v3/search?key={GoogleApiKey}&channelId={_channelId}&part=snippet,id&order=date&maxResults=20";
        
        private Channel.Channel GetMediaObject(string json)
        {
            Channel.Channel media = JsonSerializer.Deserialize<Channel.Channel>(json);
            return media;
        }
        private void InitializeIdListFromChannel(Channel.Channel channel)
        {
            foreach (var item in channel.Items)
                IdList.Add(item.Id.VideoId);
        }
        public override string GetDefaultFolder(string channelTitle)
        {
            var home = Environment.GetFolderPath(
                Environment.SpecialFolder.UserProfile);
            return Path.Combine(home, $"Downloads/{channelTitle}");
        }
        public override void Download(List<string> idList, string channelTitle)
        {
            foreach (var id in idList)
            {
                Console.WriteLine("Awesome! Downloading...");
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