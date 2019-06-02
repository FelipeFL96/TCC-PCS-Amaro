using System.Collections.Generic;
using System.Threading.Tasks;
using BestFitAPIService.Model;
using Microsoft.AspNetCore.Mvc;

namespace BestFit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoseProcessingController : ControllerBase
    {
        private readonly OpenPoseWrapper poseProcessor;

        public PoseProcessingController()
        {
            poseProcessor = new OpenPoseWrapper();
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2", "value3"};
    
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody] string value)
        {
            

        }
    }
}
