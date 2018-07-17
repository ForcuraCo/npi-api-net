using Forcura.NPPES.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Forcura.NPPES.Core
{
    class NPPESTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(NPPESType) || objectType == typeof(NPPESType?);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);

            if (token.Type == JTokenType.String)
            {
                bool parsed = Enum.TryParse(token.ToString().Replace("-", string.Empty), true, out NPPESType result);

                if (objectType == typeof(NPPESType?))
                    return parsed ? result : default(NPPESType?);

                return result;
            }

            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
