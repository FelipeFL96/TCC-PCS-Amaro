using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Pose.Measurer.Repository
{
    public class ProcessedImageRepository
    {
        private const string POSE_DIRECTORY = @"D:\openpose\openpose_output";

        public ProcessedImageRepository() { }

        public List<byte[]> GetImageData()
        {
            List<byte[]> folderData = new List<byte[]>();
            string[] files = Directory.GetFiles(POSE_DIRECTORY);
            foreach (string file in files)
            {
                byte[] data = GetImageAsync(file);
                folderData.Add(data);
            }

            return folderData;
        }

        private byte[] GetImageAsync(string file)
        {
            var openFile = File.Open(file, FileMode.Open);
            int fileLength = (int)openFile.Length;
            byte[] fileData = new byte[fileLength];
            openFile.ReadAsync(fileData, 0, fileLength).Wait();

            return fileData;
        }
    }
}
