using Newtonsoft.Json;

namespace TinyERP.Common.Mappers
{
    public class ObjectMapper
    {
        public static TObject Map<TObject>(object sourceObject)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            string json = JsonConvert.SerializeObject(sourceObject, settings );
            return JsonConvert.DeserializeObject<TObject>(json, settings);
        }
    }
}
