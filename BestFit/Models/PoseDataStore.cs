using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace BestFitAPIService.Models
{
    public class PoseDataStore
    {
        #region Fields

        private const string POSE_INPUT_DIR = @"D:\openpose\openpose_inputs";
        private readonly CancellationTokenSource tokenSource;
        private readonly CancellationToken token;

        #endregion

        #region Constructor

        public PoseDataStore()
        {
            tokenSource = new CancellationTokenSource();
            token = tokenSource.Token;
        }

        #endregion

        #region Methods

        public async Task StorePoseData(byte[] data)
        {
            await File.WriteAllBytesAsync(POSE_INPUT_DIR, data, token).ConfigureAwait(false);
        }

        #endregion
    }
}
