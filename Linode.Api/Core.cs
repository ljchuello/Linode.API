using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using RestSharp;
using Linode.Api.Objets.Error;
using System.Reflection;

namespace Linode.Api
{
    public class Core
    {
        public static long PerPage = 500;

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
            // Set
            string content = string.Empty;
            HttpStatusCode httpStatusCode;
            Root.Error error = new Root.Error();

            // Request
            using (RestClient restClient = new RestClient(ApiServer))
            {
                var request = new RestRequest(url, Method.Post);
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

                default:
                    error = JsonConvert.DeserializeObject<Root.Error>(content) ?? new Root.Error();
                    throw new Exception($"An error has occurred. Reason: {error.Errors[0].Reason}");
            }
        }

        public static async Task<string> SendPostRequest(string token, string url, string raw)
        {
            // Set
            string content = string.Empty;
            HttpStatusCode httpStatusCode;
            Root.Error error = new Root.Error();

            // Request
            using (RestClient restClient = new RestClient(ApiServer))
            {
                RestRequest request = new RestRequest(url, Method.Post);
                request.AddHeader("Authorization", $"Bearer {token}");
                request.AddJsonBody(raw, "application/json");
                RestResponse response = await restClient.ExecuteAsync(request);

                // Set
                content = response.Content;
                httpStatusCode = response.StatusCode;
            }

            // Check
            switch (httpStatusCode)
            {
                case HttpStatusCode.OK:
                case HttpStatusCode.Created:
                    return content;

                default:
                    error = JsonConvert.DeserializeObject<Root.Error>(content) ?? new Root.Error();
                    throw new Exception($"An error has occurred. Reason: {error.Errors[0].Reason}");
            }
        }

        public static async Task<string> SendPutRequest(string token, string url, string raw)
        {
            // Set
            string content = string.Empty;
            HttpStatusCode httpStatusCode;
            Root.Error error = new Root.Error();

            // Request
            using (RestClient restClient = new RestClient(ApiServer))
            {
                RestRequest request = new RestRequest(url, Method.Put);
                request.AddHeader("Authorization", $"Bearer {token}");
                request.AddJsonBody(raw, "application/json");
                RestResponse response = await restClient.ExecuteAsync(request);

                // Set
                content = response.Content;
                httpStatusCode = response.StatusCode;
            }

            // Check
            switch (httpStatusCode)
            {
                case HttpStatusCode.OK:
                case HttpStatusCode.Created:
                    return content;

                default:
                    error = JsonConvert.DeserializeObject<Root.Error>(content) ?? new Root.Error();
                    throw new Exception($"An error has occurred. Reason: {error.Errors[0].Reason}");
            }
        }

        public static async Task SendDeleteRequest(string token, string url)
        {
            // Set
            string content = string.Empty;
            HttpStatusCode httpStatusCode;
            Root.Error error = new Root.Error();

            // Request
            using (RestClient restClient = new RestClient(ApiServer))
            {
                RestRequest request = new RestRequest(url, Method.Delete);
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
                case HttpStatusCode.NoContent:
                    break;

                default:
                    error = JsonConvert.DeserializeObject<Root.Error>(content) ?? new Root.Error();
                    throw new Exception($"An error has occurred. Reason: {error.Errors[0].Reason}");
            }
        }

        public static object SetEmptyStringsToNull(object obj)
        {
            // Creamos una instancia nueva del mismo tipo de objeto
            object newObj = Activator.CreateInstance(obj.GetType());

            // Obtenemos todas las propiedades del objeto original
            PropertyInfo[] properties = obj.GetType().GetProperties();

            // Recorremos cada propiedad
            foreach (PropertyInfo property in properties)
            {
                // Verificamos si la propiedad es de tipo string
                if (property.PropertyType == typeof(string))
                {
                    // Obtenemos el valor de la propiedad del objeto original
                    string value = (string)property.GetValue(obj);

                    // Si el valor es una cadena vacía, lo seteamos a null en la nueva instancia
                    if (string.IsNullOrEmpty(value))
                    {
                        property.SetValue(newObj, null);
                    }
                    else
                    {
                        // Si no es una cadena vacía, copiamos el valor a la nueva instancia
                        property.SetValue(newObj, value);
                    }
                }
                else
                {
                    // Si no es una propiedad de tipo string, copiamos el valor a la nueva instancia
                    property.SetValue(newObj, property.GetValue(obj));
                }
            }

            // Retornamos la nueva instancia con las cadenas vacías convertidas a null
            return newObj;
        }
    }
}
