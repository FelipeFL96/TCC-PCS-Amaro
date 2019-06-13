using System.IO;
using System.Threading.Tasks;

namespace Pose.Measurer.Repository
{
    public class ProcessedImageRepository
    {
        public ProcessedImageRepository() { }

        public async Task<string> GetPoseDataAsync(string filePath)
        {
            string fileData;
            using (StreamReader sr = new StreamReader(filePath))
            {
                fileData = await sr.ReadToEndAsync().ConfigureAwait(false);
            }

            return fileData;
        }
    }
}
