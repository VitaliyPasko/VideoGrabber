using System.Threading.Tasks;
using GetVideoInfos.Download;

namespace GetVideoInfos
{
    class Program
    {
        static async Task Main(string[] args)
        {
            DownLoadManager manager = new DownLoadManager();
            await manager.ChooseTypeAction();
        }
    }
}