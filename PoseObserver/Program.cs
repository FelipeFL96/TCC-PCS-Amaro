using System;

namespace Pose.Observer
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            using (ReceivedImageObserver observer = new ReceivedImageObserver())
            {
                Console.ReadKey();
            }
        }
    }
}
