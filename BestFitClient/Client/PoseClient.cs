using System.Net.Http;
using System.Threading.Tasks;

namespace BestFitClient.Client
{
    public class PoseClient
    {
        #region Fields

        private const string ENDPOINT = @"https://localhost:52151/api/poseprocessing";
        private readonly HttpClient client;

        #endregion

        #region Constructor

        public PoseClient()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.ConnectionClose = true;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("CONTENT_TYPE", "application/octet-stream");
        }

        #endregion

        #region Methods

        public async Task PublishPoseImage(byte[] data)
        {
            HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Post, ENDPOINT)
            {
                Content = new ByteArrayContent(data),

            };
            httpRequest.Headers.Add("CONTENT-LENGTH", data.Length.ToString());
            HttpResponseMessage httpResponse = await client.SendAsync(httpRequest);
            httpResponse.EnsureSuccessStatusCode();
        }

        #endregion
    }
}
