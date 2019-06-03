using System;

namespace PoseMeasurer
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            PoseResultsObserver observer = new PoseResultsObserver();
            observer.Start();
        }
    }
}
