using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace BestFitAPIService.Models
{
    public class DataFileWriter
    {
        #region Fields

        private const string POSE_INPUT_DIR = @"D:\openpose\openpose_inputs";
        private CancellationTokenSource tokenSource = new CancellationTokenSource();

        #endregion

        #region Constructor

        public DataFileWriter()
        {
            
        }

        #endregion

        #region Methods

        public async Task WriteDataToFileAsync(byte[] data, string filename)
        {
            await File.WriteAllBytesAsync(string.Format(@"{0}\{1}.jpg", POSE_INPUT_DIR, filename), data, tokenSource.Token).ConfigureAwait(false);
        }

        #endregion
    }
}
