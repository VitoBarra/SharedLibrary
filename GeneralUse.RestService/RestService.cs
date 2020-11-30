using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SharedLibrary.GeneralUse.RestService
{
    public static class RestService
    {
        public static async Task<T> CallServiceAsync<T>(string EndPoint)
        {
            T Data = default(T);

            try
            {
                using (HttpClient Client = HTTPClientFactory.GenerateInstance())
                {
                    HttpResponseMessage response = await Client.GetAsync(EndPoint);
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        Data = JsonConvert.DeserializeObject<T>(content);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return Data;
        }

        public static T CallService<T>(string EndPoint)
        {
            T Data = default(T);

            try
            {
                using (HttpClient Client = HTTPClientFactory.GenerateInstance())
                {
                    HttpResponseMessage response = Client.GetAsync(EndPoint).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string content = response.Content.ReadAsStringAsync().Result;
                        Data = JsonConvert.DeserializeObject<T>(content);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return Data;
        }
    }


    public static class HTTPClientFactory
    {
        public static IList<Header> DefHeaders = new List<Header>();

        public static HttpClient GenerateInstance()
        {
            var NewClient = new HttpClient();
            if (DefHeaders.Count==0 ) return NewClient;

            else
                foreach (var header in DefHeaders)
                    NewClient.DefaultRequestHeaders.Add(header.name, header.values);

            return NewClient;
        }
    }

    public class Header
    {
        public string name { get; set; }
        public string values { get; set; }

        public Header(string name, string values)
        {
            this.name = name;
            this.values = values;
        }
    }
}
