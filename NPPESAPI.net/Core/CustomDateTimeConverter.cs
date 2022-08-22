using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Forcura.NPPES.Core
{
    internal class CustomDateTimeConverter : IsoDateTimeConverter
    {
        private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
                return null;

            var timeToParse = reader.Value.ToString();
            if (long.TryParse(timeToParse, out long longValue))
            {
                // for backward compatibility, it looks like the NPPES folks
                // found they were sending seconds and not milliseconds
                // and finally corrected this.  Unfortunately this is breaking
                // and due to the unplanned nature of their release and inappropriate versioning
                // its probably best to check validating for seconds and/or milliseconds being
                // returned here
                if (timeToParse.Length <= 10)
                {
                    return epoch.AddMilliseconds(longValue * 1000D);
                }

                return epoch.AddMilliseconds(longValue);
            }

            return base.ReadJson(reader, objectType, existingValue, serializer);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            base.WriteJson(writer, value, serializer);
        }
    }
}
