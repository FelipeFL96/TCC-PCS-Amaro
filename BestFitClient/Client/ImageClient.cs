using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BestFitClient.Client
{
    public class ImageClient
    {
        #region Fields

        private const string ENDPOINT = @"http://localhost:5000/api/poseprocessing";
        private readonly HttpClient client;

        #endregion

        #region Constructor

        public ImageClient()
        {
            client = new HttpClient();
        }

        #endregion

        #region Methods

        public async Task PublishImage(byte[] data)
        {
            try
            {
                HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Post, ENDPOINT)
                {
                    Content = new ByteArrayContent(data),

                };
                HttpResponseMessage httpResponse = await client.SendAsync(httpRequest);
                httpResponse.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("Message: {0}\nStackTrace: {1}", e.Message, e.StackTrace));
            }
            
        }

        #endregion
    }
}
