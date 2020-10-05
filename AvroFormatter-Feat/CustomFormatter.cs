using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AvroFormatterFeat
{
    public class CustomFormatter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {

            JObject itemObj = new JObject();
            itemObj.Add("string", JToken.FromObject(value));
            itemObj.WriteTo(writer);

        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string val = (string)reader.Value;
            return val;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
    }

}


