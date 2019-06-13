using Newtonsoft.Json;
using Pose.Measurer.Models;
using Pose.Measurer.Repository;
using System;
using System.Threading.Tasks;

namespace Pose.Measurer
{
    public class PoseMeasurer
    {
        private readonly ProcessedImageRepository repo;
        private const int REFERENCE_SIZE = 180;

        public PoseMeasurer()
        {
            repo = new ProcessedImageRepository();
        }

        public async Task Measure(string pathToData)
        {
            string poseData = await repo.GetPoseDataAsync(pathToData).ConfigureAwait(false);
            TakeMeasurements(poseData, REFERENCE_SIZE);
        }

        private void TakeMeasurements(string data, int referenceSize)
        {
            var poses = JsonConvert.DeserializeObject<PoseData>(data);
            foreach (var pose in poses.People)
            {
                MeasurePose(pose, referenceSize);
            }
        }

        private void MeasurePose(PoseKeypoints data, int referenceSize)
        {
            var keysToBody = new KeypointToBodyPart();
            Console.WriteLine("Part -> (x, y, confidence score)");
            foreach (var part in keysToBody.Map)
            {
                string bodyPart = part.Value;
                double x = data.Pose_KeyPoints_2d[3 * part.Key];
                double y = data.Pose_KeyPoints_2d[3 * part.Key + 1];
                double confidenceScore = data.Pose_KeyPoints_2d[3 * part.Key + 2];

                Console.WriteLine("Part: {0} -> ({1}, {2}, {3})", bodyPart, x, y, confidenceScore);
            }
        }
    }
}
