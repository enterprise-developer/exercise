using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using TinyERP.Common.Responses;

namespace TinyERP.Common.Connector
{
    public class JsonConnector : IConnector
    {
        public TData Post<TData>(string url, object value)
        {
            HttpClient http = new HttpClient();
            var json = JsonConvert.SerializeObject(value);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = http.PostAsync(url, data).Result;
            var result = response.Content.ReadAsStringAsync().Result;
            var responseData = JsonConvert.DeserializeObject<Response<TData>>(result);
            return responseData.Data;
        }
    }
}
