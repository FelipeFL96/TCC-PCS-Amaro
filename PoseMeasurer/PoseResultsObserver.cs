using System;
using System.IO;

namespace PoseMeasurer
{
    public class PoseResultsObserver : IDisposable
    {
        #region Fields

        private const string PATH = @"D:\openpose\outputs";

        private readonly FileSystemWatcher fsWatcher;

        #endregion

        public PoseResultsObserver()
        {
            fsWatcher = new FileSystemWatcher
            {
                Path = PATH,
                IncludeSubdirectories = true
            };
            fsWatcher.Created += (sender, args) => NewOpenPoseOutputs();
            fsWatcher.Changed += (sender, args) => NewOpenPoseOutputs();
            fsWatcher.Renamed += (sender, args) => NewOpenPoseOutputs();
            fsWatcher.EnableRaisingEvents = true;
        }

        private void NewOpenPoseOutputs()
        {
            Console.WriteLine("New outputs!");
        }

        public void Dispose()
        {
            fsWatcher.Dispose();
        }

    }
}
