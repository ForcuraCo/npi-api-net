using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Forcura.NPPES.Core
{
    class CustomDateTimeConverter : IsoDateTimeConverter
    {
        private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
                return null;

            if (long.TryParse(reader.Value.ToString(), out long longValue))
                return epoch.AddMilliseconds(longValue * 1000D);

            return base.ReadJson(reader, objectType, existingValue, serializer);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            base.WriteJson(writer, value, serializer);
        }
    }
}
