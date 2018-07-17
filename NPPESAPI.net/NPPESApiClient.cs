using Forcura.NPPES.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Forcura.NPPES
{
    public static class NPPESApiClient
    {
        private static readonly Lazy<HttpClient> defaultClient;
        private static readonly JsonSerializer serializer;
        private const string BASE_ADDRESS_PATH = "https://npiregistry.cms.hhs.gov/api/resultsDemo2/";
        private const int bufferSize = 8192;

        private static HttpClient DefaultClient => defaultClient.Value;

        static NPPESApiClient()
        {
            defaultClient = new Lazy<HttpClient>(() => new HttpClient
            {
                BaseAddress = new Uri(BASE_ADDRESS_PATH)
            });

            serializer = JsonSerializer.Create(new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                Formatting = Formatting.None,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                Converters = new List<JsonConverter>
                {
                    new AddressPurposeConverter(),
                    new AddressTypeConverter(),
                    new NPPESTypeConverter(),
                    new CustomDateTimeConverter()
                },
                ContractResolver = new NPPESContractResolver()
            });
        }

        /// <summary>
        /// Searches the NPPES NPI directory for an individual or organization based on search criteria.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<NPPESResponse> Search(NPPESRequest request, CancellationToken cancellationToken = default)
        {
            using (var responseMessage = await DefaultClient.GetAsync(request.ToQuery(), cancellationToken: cancellationToken))
            {
                if (responseMessage.IsSuccessStatusCode)
                    using (var stream = await responseMessage.Content.ReadAsStreamAsync())
                        return StreamToType<NPPESResponse>(stream);

                return null;
            }
        }

        private static T StreamToType<T>(Stream stream)
        {
            using (var streamReader = new StreamReader(stream, Encoding.UTF8, true, bufferSize, true))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return serializer.Deserialize<T>(jsonReader);
            }
        }
    }
}
