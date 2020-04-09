using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TinyERP.Common.Responses;
using TinyERP.Common.Validations;

namespace TinyERP.Common.Connector
{
    public class JsonConnector : IConnector
    {
        private HttpClient http;
        public JsonConnector()
        {
            this.http = new HttpClient();
            this.http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<TData> Get<TData>(string url)
        {
            var response = this.http.GetAsync(url).Result;
            return await this.GetResultFromResponse<TData>(response);
        }

        public async Task<TData> Post<TData>(string url, object value)
        {
            StringContent data = this.ConvertObjectToStringContent(value);
            var response = this.http.PostAsync(url, data).Result;
            return await this.GetResultFromResponse<TData>(response);
        }

        private StringContent ConvertObjectToStringContent(object value)
        {
            var json = JsonConvert.SerializeObject(value);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private async Task<TData> GetResultFromResponse<TData>(HttpResponseMessage response)
        {
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new ValidationException("common.errors.genericError");
            }
            var result = await response.Content.ReadAsStringAsync();
            Response<TData> responseData = JsonConvert.DeserializeObject<Response<TData>>(result);
            if (responseData.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new ValidationException(responseData.Errors);
            }
            return responseData.Data;
        }

    }
}
