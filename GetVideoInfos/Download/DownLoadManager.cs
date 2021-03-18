using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GetVideoInfos.Enums;
using GetVideoInfos.Helpers;

namespace GetVideoInfos.Download
{
    public class DownLoadManager
    {
        delegate Task DownloadVideosDelegate(string id);

        private readonly Dictionary<int, DownloadVideosDelegate> _dictionary;
        public DownLoadManager()
        {
            _dictionary = new Dictionary<int, DownloadVideosDelegate>
            {
                {1, StartDownloadingFromChannel},
                {2, StartDownloadingFromPlayList}
            };
        }
        
        public async Task ChooseTypeAction()
        {
            try
            {
                string inputOp = UserInput("Качаем все видео с канала - 1\n" +
                                           "Качаем все видосы с плейлиста - 2");
                bool isNum = int.TryParse(inputOp, out int typeOp);
                if (isNum && _dictionary.ContainsKey(typeOp))
                {
                    string id = UserInput("Введите id:");
                    await _dictionary[typeOp].Invoke(id);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ErrorEnum.WrongOperation.GetEnumDescription());
                    Console.ResetColor();
                    await ChooseTypeAction();
                }
            }
            catch (HttpRequestException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ErrorEnum.WrongId.GetEnumDescription());
                Console.ResetColor();
                await ChooseTypeAction();
            }
        }
        
        private string UserInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        private async Task StartDownloadingFromChannel(string id)
        {
            ChannelDownloader channelDownloader = new ChannelDownloader(id);
            await channelDownloader.DownLoad();
        }

        private async Task StartDownloadingFromPlayList(string id)
        {
            PlayListDownLoader playListDownLoader = new PlayListDownLoader(id);
            await playListDownLoader.DownLoad();
        }
    }
}