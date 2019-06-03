using System;
using System.IO;

namespace PoseMeasurer
{
    public class PoseResultsObserver
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
                EnableRaisingEvents = true,
                IncludeSubdirectories = true
            };
        }

        private void NewOpenPoseOutputs()
        {
            Console.WriteLine("New outputs!");
        }

        public void Start()
        {
            try
            {
                fsWatcher.BeginInit();

                while(true)
                {
                    fsWatcher.WaitForChanged(WatcherChangeTypes.All);
                    NewOpenPoseOutputs();
                }
            }
            catch
            {

            }
        }
    }
}
