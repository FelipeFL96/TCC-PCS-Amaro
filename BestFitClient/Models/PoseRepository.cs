using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace BestFitClient.Models
{
    class PoseRepository
    {
        #region Fields

        private const string POSE_DIRECTORY = @"D:\openpose\poses";
        private readonly CancellationTokenSource tokenSource;
        private readonly CancellationToken token;

        #endregion

        #region Constructor

        public PoseRepository()
        {
            tokenSource = new CancellationTokenSource();
            token = tokenSource.Token;
        }

        #endregion

        public List<byte[]> GetPoseData()
        {
            List<byte[]> folderData = new List<byte[]>();
            string[] files = Directory.GetFiles(POSE_DIRECTORY);
            foreach(string file in files)
            {
                byte[] data = GetPoseAsync(file);
                folderData.Add(data);
            }

            return folderData;
        }

        private byte[] GetPoseAsync(string file)
        {
            var openFile = File.Open(file, FileMode.Open);
            int fileLength = (int)openFile.Length;
            byte[] fileData = new byte[fileLength];
            openFile.ReadAsync(fileData, 0, fileLength).Wait();

            return fileData;
        }
    }
}
