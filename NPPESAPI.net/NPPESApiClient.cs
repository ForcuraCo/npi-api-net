using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Forcura.NPPES.Core;
using Newtonsoft.Json;

namespace Forcura.NPPES
{
    /// <summary>
    /// NPPES Api for making requests to the NPPES NPI registry.
    /// </summary>
    public class NPPESApiClient
    {
        private readonly HttpClient httpClient;
        private readonly JsonSerializer serializer;

        private const string BaseAddressPath = "https://npiregistry.cms.hhs.gov/api/";
        private const int BufferSize = 8192;

        /// <summary>
        /// Initializes a new instance of <see cref="NPPESApiClient"/>.
        /// </summary>
        public NPPESApiClient()
            : this(new HttpClient())
        {

        }

        /// <summary>
        /// Initializes a new instance of <see cref="NPPESApiClient"/> with the provided <see cref="HttpClient"/>.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/>.</param>
        public NPPESApiClient(HttpClient client)
        {
            client.BaseAddress = new Uri(BaseAddressPath);

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

            httpClient = client;
        }

        /// <summary>
        /// Searches the NPPES NPI directory by NPI number.
        /// </summary>
        /// <param name="npi">The npi number to search for.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
        /// <returns></returns>
        public Task<NPPESResponse> SearchAsync(string npi, CancellationToken cancellationToken = default)
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
        /// <param name="request">The request parameters.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
        /// <returns></returns>
        public async Task<NPPESResponse> SearchAsync(NPPESRequest request, CancellationToken cancellationToken = default)
        {
            var response = new NPPESResponse
            {
                ResultCount = 0,
                Results = null,
                Errors = null
            };

            using (var responseMessage = await httpClient.GetAsync(request.ToQuery(), HttpCompletionOption.ResponseHeadersRead, cancellationToken: cancellationToken).ConfigureAwait(false))
            {
                // errors are returned with a 200 status code
                // so this handles success and error.
                if (responseMessage.IsSuccessStatusCode && responseMessage.Content is object)
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

        private T StreamToType<T>(Stream stream)
        {
            using (var streamReader = new StreamReader(stream, Encoding.UTF8, true, BufferSize, true))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return serializer.Deserialize<T>(jsonReader);
            }
        }
    }
}
