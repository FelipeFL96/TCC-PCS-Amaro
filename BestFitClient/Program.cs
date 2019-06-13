using BestFitClient.Repository;
using BestFitClient.Client;
using System.Threading.Tasks;
using System;

namespace BestFitClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ImageRepository poseRepo = new ImageRepository();
            ImageClient client = new ImageClient();
            foreach(byte[] data in poseRepo.GetImageData())
            {
                try
                {
                    Task.Run(() => client.PublishImage(data)).Wait();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Message: {0}\nStackTrace: {1}", e.Message, e.StackTrace);
                }
            }
        }
    }
}
