using System;
using System.IO;
using System.Threading.Tasks;

namespace Pose.Measurer
{
    public class ProcessedImageObserver : IDisposable
    {
        #region Fields

        private const string INPUTS_PATH = @"D:\openpose\openpose_outputs";

        private readonly FileSystemWatcher fsWatcher;
        private readonly PoseMeasurer measurer;

        #endregion

        public ProcessedImageObserver()
        {
            measurer = new PoseMeasurer();
            fsWatcher = new FileSystemWatcher
            {
                Path = INPUTS_PATH,
                IncludeSubdirectories = true
            };
            fsWatcher.Created += NewImageData;
            fsWatcher.EnableRaisingEvents = true;
        }

        private void NewImageData(object sender, FileSystemEventArgs args)
        {
            Task.Run(() => measurer.Measure(args.FullPath)).Wait();
        }

        public void Dispose()
        {
            fsWatcher.Dispose();
        }

    }
}
