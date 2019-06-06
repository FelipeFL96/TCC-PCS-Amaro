using BestFitClient.Models;
using BestFitClient.Client;
using System.Threading.Tasks;

namespace BestFitClient
{
    class Program
    {
        static void Main(string[] args)
        {
            PoseRepository poseRepo = new PoseRepository();
            PoseClient client = new PoseClient();
            foreach(byte[] data in poseRepo.GetPoseData())
            {
                Task.Run(() => client.PublishPoseImage(data)).ConfigureAwait(false);
            }
        }
    }
}
