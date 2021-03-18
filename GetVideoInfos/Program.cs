using System.Threading.Tasks;
using GetVideoInfos.Download;

namespace GetVideoInfos
{
    class Program
    {
        static async Task Main(string[] args)
        {
            DawnLoadManager manager = new DawnLoadManager();
            await manager.ChooseTypeAction();
        }
    }
}