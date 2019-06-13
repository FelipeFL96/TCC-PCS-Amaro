using BestFitClient.Models;
using BestFitClient.Client;
using System.Threading.Tasks;
using System;

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
                try
                {
                    Task.Run(() => client.PublishPoseImage(data)).Wait();
                }
                catch (Exception e)
                {
                    Console.WriteLine(string.Format("Message: {0}\nStackTrace: {1}", e.Message, e.StackTrace));
                }
            }
        }
    }
}
