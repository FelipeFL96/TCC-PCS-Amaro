using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BestFitAPIService.Model
{
    public class OpenPoseWrapper
    {
        #region FIELDS

        private const string PATH = @"C:\Users\danie\Desktop\OpenPose\openpose\build\x64\Release\OpenPoseDemo.exe";
        private const string ARGUMENTS = @"--image_dir D:\openpose\inputs --write_json D:\openpose\outputs";

        private readonly Process openposeProcess;

        #endregion

        public OpenPoseWrapper()
        {
            openposeProcess = new Process
            {
                StartInfo =
                {
                    FileName = PATH,
                    Arguments = ARGUMENTS,
                    UseShellExecute = false,
                    CreateNoWindow = true
                },
            };
        }

        public async Task ProcessImages()
        {
            await Task.Run(() => openposeProcess.Start()).ConfigureAwait(false);
        }
    }
}
