using System;

namespace PoseMeasurer
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            using (PoseDataObserver observer = new PoseDataObserver())
            {
                Console.ReadKey();
            }
        }
    }
}
