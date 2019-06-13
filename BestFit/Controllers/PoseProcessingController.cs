using System;
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

        private readonly DataFileWriter poseStore;

        #endregion

        #region Constructor

        public PoseProcessingController()
        {
            poseStore = new DataFileWriter();
        }

        #endregion

        #region Http Methods

        [HttpPost]
        public async Task<HttpResponseMessage> Post()
        {
            HttpStatusCode httpStatus;
            try
            {
                Guid id = Guid.NewGuid();
                int bufferSize = (int)Request.ContentLength;
                byte[] data = await ReadByteArrayBody(bufferSize).ConfigureAwait(false);
                await poseStore.WriteDataToFileAsync(data, id.ToString()).ConfigureAwait(false);

                httpStatus = HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("Message: {0}\nStackTrace{1}", e.Message, e.StackTrace));

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
