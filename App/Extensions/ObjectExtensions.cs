using Newtonsoft.Json;

namespace App.Extensions
{
    public static class ObjectExtensions
    {
        public static string ToJson(this object @object)
        {
            var objectJson = JsonConvert.SerializeObject(@object);

            return objectJson;
        }

        public static T ToObject<T>(this string objectJson)
        {
            var @object = JsonConvert.DeserializeObject<T>(objectJson);

            return @object;
        }
    }
}