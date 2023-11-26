using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;

namespace Linode.Api
{
    public class Core
    {
        public static long PerPage = 25;

        private const string ApiServer = " https://api.linode.com/v4";

        public static async Task<string> SendGetRequest(string token, string url)
        {
            HttpResponseMessage httpResponseMessage;
            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpRequestMessage httpRequestMessage = new HttpRequestMessage(new HttpMethod("GET"), $"{ApiServer}{url}"))
                {
                    httpRequestMessage.Headers.TryAddWithoutValidation("Authorization", $"Bearer {token}");
                    httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
                }
            }

            // Response
            string json = await httpResponseMessage.Content.ReadAsStringAsync();

            switch (httpResponseMessage.StatusCode)
            {
                case HttpStatusCode.OK:
                    break;

                default:
                    // Get Error
                    JObject result = JObject.Parse(json);
                    //Error error = JsonConvert.DeserializeObject<Error>($"{result["error"]}") ?? new Error();

                    //Check error
                    //if (error.Message.Contains("with ID") && error.Message.Contains("not found"))
                    //{
                    //    // The error is due to the resource not being found. Let's make it return empty instead of an error.
                    //    json = "{}";
                    //}
                    //else
                    //{
                    //    // If it's a genuine error
                    //    throw new Exception($"{error.Code} - {error.Message}");
                    //}
                    break;
            }

            return json;
        }
    }
}
