namespace TinyERP.Common.Connector
{
    using System.Net.Http;
    using System.Text;
    using TinyERP.Common.Common.Helper;

    public class JsonContent<T> : StringContent
    {
        public JsonContent(string dataInJson) : base(dataInJson, Encoding.UTF8, ConnectorContentType.Json)
        {
        }
        public JsonContent(T data) : base(JsonHelper.ToJson(data), Encoding.UTF8, ConnectorContentType.Json)
        {
        }
    }
}
