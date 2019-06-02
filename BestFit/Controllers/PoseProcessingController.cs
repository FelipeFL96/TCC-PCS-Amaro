using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace BestFit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoseProcessingController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2", "value3"};
    
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
