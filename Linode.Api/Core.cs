using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System;
using RestSharp;
using Linode.Api.Objets.Error;

namespace Linode.Api
{
    public class Core
    {
        public static long PerPage = 25;

        private const string ApiServer = " https://api.linode.com/v4";

        public static async Task<string> SendGetRequest(string token, string url)
        {
            // Set
            string content = string.Empty;
            HttpStatusCode httpStatusCode;
            Root.Error error = new Root.Error();

            // Request
            using (RestClient restClient = new RestClient(ApiServer))
            {
                var request = new RestRequest(url);
                request.AddHeader("Authorization", $"Bearer {token}");
                RestResponse response = await restClient.ExecuteAsync(request);

                // Set
                content = response.Content;
                httpStatusCode = response.StatusCode;
            }

            // Check
            switch (httpStatusCode)
            {
                case HttpStatusCode.OK:
                    return content;

                case HttpStatusCode.NotFound:
                    // Get error
                    error = JsonConvert.DeserializeObject<Root.Error>(content) ?? new Root.Error();
                    if (error.Errors[0].Reason == "Not found")
                    {
                        return "{}";
                    }
                    else
                    {
                        throw new Exception($"An error has occurred. Reason: {error.Errors[0].Reason}");
                    }
                    break;

                default:
                    error = JsonConvert.DeserializeObject<Root.Error>(content) ?? new Root.Error();
                    throw new Exception($"An error has occurred. Reason: {error.Errors[0].Reason}");
            }
        }

        public static async Task<string> SendPostRequest(string token, string url)
        {
            HttpResponseMessage httpResponseMessage;
            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpRequestMessage httpRequestMessage = new HttpRequestMessage(new HttpMethod("POST"), $"{ApiServer}{url}"))
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

        public static async Task<string> SendPostRequest(string token, string url, string content)
        {
            HttpResponseMessage httpResponseMessage;
            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpRequestMessage httpRequestMessage = new HttpRequestMessage(new HttpMethod("POST"), $"{ApiServer}{url}"))
                {
                    httpRequestMessage.Headers.TryAddWithoutValidation("Authorization", $"Bearer {token}");
                    httpRequestMessage.Content = new StringContent(content);
                    httpRequestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
                }
            }

            // Response
            string json = await httpResponseMessage.Content.ReadAsStringAsync();

            switch (httpResponseMessage.StatusCode)
            {
                case HttpStatusCode.Created:
                case HttpStatusCode.OK:
                    break;

                default:
                    break;
            }

            return json;
        }

        public static async Task<string> SendPutRequest(string token, string url, string content)
        {
            HttpResponseMessage httpResponseMessage;
            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpRequestMessage httpRequestMessage = new HttpRequestMessage(new HttpMethod("PUT"), $"{ApiServer}{url}"))
                {
                    httpRequestMessage.Headers.TryAddWithoutValidation("Authorization", $"Bearer {token}");
                    httpRequestMessage.Content = new StringContent(content);
                    httpRequestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
                }
            }

            // Response
            string json = await httpResponseMessage.Content.ReadAsStringAsync();

            switch (httpResponseMessage.StatusCode)
            {
                case HttpStatusCode.Created:
                case HttpStatusCode.OK:
                    break;

                default:
                    break;
            }

            return json;
        }

        public static async Task SendDeleteRequest(string token, string url)
        {
            HttpResponseMessage httpResponseMessage;
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("DELETE"), $"{ApiServer}{url}"))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {token}");
                    httpResponseMessage = await httpClient.SendAsync(request);
                }
            }

            // Response
            string json = await httpResponseMessage.Content.ReadAsStringAsync();

            switch (httpResponseMessage.StatusCode)
            {
                case HttpStatusCode.NoContent:
                case HttpStatusCode.OK:
                    break;

                default:
                    //JObject result = JObject.Parse(json);
                    //Error error = JsonConvert.DeserializeObject<Error>($"{result["error"]}") ?? new Error();
                    //throw new Exception($"{error.Code} - {error.Message}");
                    break;
            }
        }
    }
}
