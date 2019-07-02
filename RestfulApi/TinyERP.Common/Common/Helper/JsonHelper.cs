using Newtonsoft.Json;

namespace TinyERP.Common.Common.Helper
{
    public static class JsonHelper
    {
        public static string ToJson(object data)
        {
            return JsonConvert.SerializeObject(data);
        }

        public static TEntity ToObject<TEntity>(string data)
        {
            return JsonConvert.DeserializeObject<TEntity>(data);
        }
    }
}
