using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace SquadBot.Core.Http
{
    public static class HttpRequestHandler
    {

        private static HttpClient client = new HttpClient();

        public async static Task<T?> GetRequest<T>(string url, string acceptType) where T : class
        {

            //Clear previous headers
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(acceptType));

            //Perform Request
            var response = await client.GetAsync(url);
            
            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            
            //Deserialize JSON to T object
            string body = await response.Content.ReadAsStringAsync();
            T? value = JsonConvert.DeserializeObject<T>(body);

            return value;
      
        }


    }
}
