using System.Collections.Generic;

namespace Pose.Measurer.Models
{
    public class PoseData
    {
        public string Version { get; set; }
        public IList<PoseKeypoints> People { get; set; } 
    }
}
