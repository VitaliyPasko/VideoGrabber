using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using VideoLibrary;

namespace GetVideoInfos.Download
{
    public abstract class Downloader
    {
        protected string GoogleApiKey = "AIzaSyBYhNckUiM0z6GPkz1CWBNhQUR84MdP1m0";
        protected readonly List<string> IdList;
        private readonly Client<YouTubeVideo> _service;
        protected string ChannelTitle;
        protected readonly HttpClient HttpClient;

        protected Downloader()
        {
            IdList = new List<string>();
            _service = Client.For(YouTube.Default);
            ChannelTitle = string.Empty;
            HttpClient = new HttpClient();
        }
        public abstract string GetStringForChannel();
        protected void Download(List<string> idList, string channelTitle)
        {
            int videosCount = idList.Count;
            int i = 1;
            Console.WriteLine($"Количество видео для скачивания: {videosCount}");
            foreach (var id in idList)
            {
                YouTubeVideo video = _service.GetVideo("https://youtube.com/watch?v=" + id);
                Console.WriteLine($"{i++} {video.FullName}. Id = {id}");
                var folder = GetDefaultFolder(channelTitle);
                string path = Path.Combine(folder, video.FullName);
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);

                File.WriteAllBytes(path, video.GetBytes());
            }
        }
        private string GetDefaultFolder(string channelTitle)
        {
            var home = Environment.GetFolderPath(
                Environment.SpecialFolder.UserProfile);
            return Path.Combine(home, $"Downloads/{channelTitle}");
        }
    }
}