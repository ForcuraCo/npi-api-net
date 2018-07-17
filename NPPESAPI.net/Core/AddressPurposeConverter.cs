using Forcura.NPPES.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Forcura.NPPES.Core
{
    class AddressPurposeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(AddressPurpose) || objectType == typeof(AddressPurpose?);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);

            if (token.Type == JTokenType.String)
            {
                bool parsed = Enum.TryParse(token.ToString(), true, out AddressPurpose result);

                if (objectType == typeof(AddressPurpose?))
                    return parsed ? result : default(AddressPurpose?);

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
