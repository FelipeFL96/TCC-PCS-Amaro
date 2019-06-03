using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
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

        // POST api/value
        [HttpPost]
        public async Task<HttpResponseMessage> Post()
        {
            HttpStatusCode httpStatus;

            try
            {
                await poseProcessor.ProcessImages().ConfigureAwait(false);

                httpStatus = HttpStatusCode.OK;
            }
            catch
            {
                httpStatus = HttpStatusCode.InternalServerError;
            }

            return new HttpResponseMessage(httpStatus);
        }
    }
}
