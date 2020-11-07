using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SharedLibrary.GeneralUse.RestService
{
    public static class RestService
    {
        public static HttpClient client { get; private set; } = new HttpClient();


        public static async Task<T> Service<T>(string EndPoint)
        {
            T Data = default(T);


            HttpResponseMessage response = await client.GetAsync(EndPoint);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Data = JsonConvert.DeserializeObject<T>(content);
            }



            return Data;
        }
    }

}
