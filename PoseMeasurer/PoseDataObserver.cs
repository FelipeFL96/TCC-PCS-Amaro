﻿using System;
using System.IO;
using System.Threading.Tasks;

namespace PoseMeasurer
{
    public class PoseDataObserver : IDisposable
    {
        #region Fields

        private const string INPUTS_PATH = @"D:\openpose\openpose_inputs";

        private readonly FileSystemWatcher fsWatcher;
        private readonly OpenPoseAccess openpose;

        #endregion

        public PoseDataObserver()
        {
            openpose = new OpenPoseAccess();
            fsWatcher = new FileSystemWatcher
            {
                Path = INPUTS_PATH,
                IncludeSubdirectories = true
            };
            fsWatcher.Created += (sender, args) => NewPoseData();
            fsWatcher.EnableRaisingEvents = true;
        }

        private void NewPoseData()
        {
            Task.Run(() => ProcessData()).Wait();
        }

        private async Task ProcessData()
        {
            await openpose.ProcessImage().ConfigureAwait(false);
        }

        public void Dispose()
        {
            fsWatcher.Dispose();
        }

    }
}
