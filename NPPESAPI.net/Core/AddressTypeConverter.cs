using Forcura.NPPES.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Forcura.NPPES.Core
{
    class AddressTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(AddressType) || objectType == typeof(AddressType?);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);

            if (token.Type == JTokenType.String)
            {
                bool parsed = Enum.TryParse(token.ToString(), true, out AddressType result);

                if (objectType == typeof(AddressType?))
                    return parsed ? result : default(AddressType?);

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
