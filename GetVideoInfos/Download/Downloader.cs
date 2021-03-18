using System;
using System.Collections.Generic;
using System.Net.Http;
using VideoLibrary;

namespace GetVideoInfos.Download
{
    public abstract class Downloader
    {
        protected string GoogleApiKey = "AIzaSyBYhNckUiM0z6GPkz1CWBNhQUR84MdP1m0";
        protected readonly List<string> IdList;
        protected readonly Client<YouTubeVideo> Service;
        protected string ChannelTitle;
        protected readonly HttpClient HttpClient;

        protected Downloader()
        {
            IdList = new List<string>();
            Service = Client.For(YouTube.Default);
            ChannelTitle = string.Empty;
            HttpClient = new HttpClient();
        }
        public abstract string GetStringForChannel();
        public abstract string GetDefaultFolder(string channelTitle);
        public abstract void Download(List<string> idList, string channelTitle);
    }
}