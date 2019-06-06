using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BestFitAPIService.Models;
using Microsoft.AspNetCore.Mvc;

namespace BestFit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoseProcessingController : ControllerBase
    {
        #region Fields

        private const string CONTENT_TYPE = @"application/octet-stream";

        private readonly PoseDataStore poseStore;

        #endregion

        #region Constructor

        public PoseProcessingController()
        {
            poseStore = new PoseDataStore();
        }

        #endregion

        #region Http Methods

        [HttpPost]
        public async Task<HttpResponseMessage> Post()
        {
            HttpStatusCode httpStatus;
            try
            {
                int bufferSize = (int)Request.ContentLength;
                byte[] data = await ReadByteArrayBody(bufferSize);
                await poseStore.StorePoseData(data).ConfigureAwait(false);

                httpStatus = HttpStatusCode.OK;
            }
            catch
            {
                httpStatus = HttpStatusCode.InternalServerError;
            }

            return new HttpResponseMessage(httpStatus);
        }

        #endregion

        #region Methods

        private async Task<byte[]> ReadByteArrayBody(int bufferSize)
        {
            using (MemoryStream ms = new MemoryStream(bufferSize))
            {
                await Request.Body.CopyToAsync(ms);
                return ms.ToArray();
            }
        }

        #endregion

    }
}
