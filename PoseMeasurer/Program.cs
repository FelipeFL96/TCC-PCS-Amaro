﻿using System;

namespace Pose.Measurer
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            using (ProcessedImageObserver observer = new ProcessedImageObserver())
            {
                Console.ReadKey();
            }
        }
    }
}
