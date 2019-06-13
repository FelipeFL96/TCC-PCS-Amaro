using System.Collections.Generic;

namespace Pose.Measurer.Models
{
    public class KeypointToBodyPart
    {
        private readonly Dictionary<int, string> map = new Dictionary<int, string>
        {
            {0,  "Nose"},
            {1,  "Neck"},
            {2,  "RShoulder"},
            {3,  "RElbow"},
            {4,  "RWrist"},
            {5,  "LShoulder"},
            {6,  "LElbow"},
            {7,  "LWrist"},
            {8,  "MidHip"},
            {9,  "RHip"},
            {10, "RKnee"},
            {11, "RAnkle"},
            {12, "LHip"},
            {13, "LKnee"},
            {14, "LAnkle"},
            {15, "REye"},
            {16, "LEye"},
            {17, "REar"},
            {18, "LEar"},
            {19, "LBigToe"},
            {20, "LSmallToe"},
            {21, "LHeel"},
            {22, "RBigToe"},
            {23, "RSmallToe"},
            {24, "RHeel"},
            //{25, "Background"}
        };

        public Dictionary<int, string> Map => map;
    }
}
