using System.Diagnostics;
using System.Threading.Tasks;

namespace PoseMeasurer
{
    public class OpenPoseAccess
    {
        #region Fields

        private const string PATH = @"D:\openpose\binaries\build\x64\Release\OpenPoseDemo.exe";
        private const string WORKING_DIR = @"D:\openpose\binaries";
        private const string ARGUMENTS = @"--image_dir D:\openpose\openpose_inputs --write_json D:\openpose\openpose_outputs";

        private readonly Process openposeProcess;

        #endregion

        #region Constructor

        public OpenPoseAccess()
        {
            openposeProcess = new Process
            {
                StartInfo =
                {
                    FileName = PATH,
                    Arguments = ARGUMENTS,
                    WorkingDirectory = WORKING_DIR,
                    UseShellExecute = false,
                    CreateNoWindow = true
                },
            };
        }

        #endregion

        #region Methods

        public async Task ProcessImage()
        {
            await Task.Run(() => openposeProcess.Start()).ConfigureAwait(false);
        }

        #endregion
    }
}
