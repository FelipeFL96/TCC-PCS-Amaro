using System;

namespace PoseMeasurer
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            using (PoseResultsObserver observer = new PoseResultsObserver())
            {
                Console.ReadKey();
            }
        }
    }
}
