using System.Collections.Generic;
using System.IO;

namespace BestFitClient.Repository
{
    class ImageRepository
    {
        #region Fields

        private const string POSE_DIRECTORY = @"D:\openpose\poses";

        #endregion

        #region Constructor

        public ImageRepository() { }

        #endregion

        public List<byte[]> GetImageData()
        {
            List<byte[]> folderData = new List<byte[]>();
            string[] files = Directory.GetFiles(POSE_DIRECTORY);
            foreach(string file in files)
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
