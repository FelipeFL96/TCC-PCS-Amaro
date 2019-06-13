using System;
using System.IO;
using System.Threading.Tasks;

namespace Pose.Observer
{
    public class ReceivedImageObserver : IDisposable
    {
        #region Fields

        private const string INPUTS_PATH = @"D:\openpose\openpose_inputs";

        private readonly FileSystemWatcher fsWatcher;
        private readonly OpenPoseAccess openpose;

        #endregion

        public ReceivedImageObserver()
        {
            openpose = new OpenPoseAccess();
            fsWatcher = new FileSystemWatcher
            {
                Path = INPUTS_PATH,
                IncludeSubdirectories = true
            };
            fsWatcher.Created += (sender, args) => NewImageReceived();
            fsWatcher.EnableRaisingEvents = true;
        }

        private void NewImageReceived()
        {
            Task.Run(() => ProcessImage()).Wait();
        }

        private async Task ProcessImage()
        {
            await openpose.ProcessImage().ConfigureAwait(false);
        }

        public void Dispose()
        {
            fsWatcher.Dispose();
        }

    }
}
