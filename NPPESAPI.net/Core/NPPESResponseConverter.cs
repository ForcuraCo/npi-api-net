using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Forcura.NPPES.Core
{
    internal class NPPESResponseConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(NPPESResponse);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Unfortunately, NPPES API was updated and result_count field was changed
            // to resultCount without warning.  We'd like to think the name change will stick
            // however, if the change is reverted along the line we want to be sure we are
            // compatible both ways.
            //
            // We'll continue to review the stability of the NPPES NPI Rest API
            // and determine future direction of these changes
#if NETSTANDARD2_0_OR_GREATER || NET5_0_OR_GREATER
            object instance = objectType.GetConstructor(Type.EmptyTypes).Invoke(null);
#else
            object instance = Activator.CreateInstance(objectType);
#endif

            // create JObject for future parsing
            var jObject = JObject.Load(reader);

            // create reader to populate the object
            using (var jReader = jObject.CreateReader())
            {
                jReader.Culture = reader.Culture;
                jReader.SupportMultipleContent = reader.SupportMultipleContent;
                jReader.FloatParseHandling = reader.FloatParseHandling;
                jReader.DateParseHandling = reader.DateParseHandling;
                jReader.DateFormatString = reader.DateFormatString;
                jReader.MaxDepth = reader.MaxDepth;

                serializer.Populate(jReader, instance);
            }

            // now the fun part, check for either resultCount or result_count fields
#if NETSTANDARD2_0_OR_GREATER || NET5_0_OR_GREATER
            PropertyInfo[] props = objectType.GetProperties();
#else
            PropertyInfo[] props = objectType.GetRuntimeProperties()?.ToArray();
#endif

            foreach (var jp in jObject.Properties())
            {
                if (string.Equals(jp.Name, "resultCount", StringComparison.OrdinalIgnoreCase) || string.Equals(jp.Name, "result_count", StringComparison.OrdinalIgnoreCase))
                {
                    PropertyInfo prop = props.FirstOrDefault(pi =>
                    pi.CanWrite && string.Equals(pi.Name, nameof(NPPESResponse.ResultCount), StringComparison.OrdinalIgnoreCase));

                    if (prop != null)
                        prop.SetValue(instance, jp.Value.ToObject(prop.PropertyType, serializer));
                }
            }

            return instance;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
