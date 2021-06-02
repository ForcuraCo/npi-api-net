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
    /// <summary>
    /// NPPES Api for making requests to the NPPES NPI registry.
    /// </summary>
    public static class NPPESApiClient
    {
        private static readonly Lazy<HttpClient> defaultClient;
        private static readonly Lazy<JsonSerializer> serializer;
        private const string BASE_ADDRESS_PATH = "https://npiregistry.cms.hhs.gov/api/";
        private const int bufferSize = 8192;

        private static HttpClient DefaultClient => defaultClient.Value;
        private static JsonSerializer Serializer => serializer.Value;

        static NPPESApiClient()
        {
            defaultClient = new Lazy<HttpClient>(() => new HttpClient
            {
                BaseAddress = new Uri(BASE_ADDRESS_PATH)
            });

            serializer = new Lazy<JsonSerializer>(() => JsonSerializer.Create(new JsonSerializerSettings
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
            }));
        }

        /// <summary>
        /// Searches the NPPES NPI directory by NPI number.
        /// </summary>
        /// <param name="npi"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<NPPESResponse> SearchAsync(string npi, CancellationToken cancellationToken = default)
        {
            var request = new NPPESRequest
            {
                Number = npi
            };

            return SearchAsync(request, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Searches the NPPES NPI directory for an individual or organization based on search criteria.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<NPPESResponse> SearchAsync(NPPESRequest request, CancellationToken cancellationToken = default)
        {
            var response = new NPPESResponse
            {
                ResultCount = 0,
                Results = null,
                Errors = null
            };

            using (var responseMessage = await DefaultClient.GetAsync(request.ToQuery(), cancellationToken: cancellationToken).ConfigureAwait(false))
            {
                // errors are returned with a 200 status code
                // so this handles success and error.
                if (responseMessage.IsSuccessStatusCode)
                {
#if NET5_0
                    using (var stream = await responseMessage.Content.ReadAsStreamAsync(cancellationToken: cancellationToken).ConfigureAwait(false))
#else
                    using (var stream = await responseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false))
#endif
                        response = StreamToType<NPPESResponse>(stream);
                }

                // any other exceptions, return the status code for 
                // troubleshooting, all other fields will be null
                response.StatusCode = responseMessage.StatusCode;
            }

            return response;
        }

        private static T StreamToType<T>(Stream stream)
        {
            using (var streamReader = new StreamReader(stream, Encoding.UTF8, true, bufferSize, true))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return Serializer.Deserialize<T>(jsonReader);
            }
        }
    }
}
