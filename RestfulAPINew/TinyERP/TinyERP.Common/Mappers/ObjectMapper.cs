using Newtonsoft.Json;
using System;

namespace TinyERP.Common.Mappers
{
    public delegate void CustomMapper<TObject, TSource>(TObject tObject, TSource tSource);
    public class ObjectMapper
    {
        public static TObject Map<TSource, TObject>(TSource sourceObject, CustomMapper<TObject, TSource> callback = null)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            string json = JsonConvert.SerializeObject(sourceObject, settings);
            TObject objectMapped = JsonConvert.DeserializeObject<TObject>(json, settings);
            if (callback != null)
            {
                callback(objectMapped, sourceObject);
            }
            return objectMapped;
        }
    }
}
