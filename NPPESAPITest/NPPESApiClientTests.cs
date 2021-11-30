using System.Net;
using System.Threading.Tasks;
using Forcura.NPPES;
#if NETCOREAPP2_1_OR_GREATER
using Microsoft.Extensions.DependencyInjection;
#endif
using Xunit;

namespace NPPESAPITest
{
    public class NPPESApiClientTests
    {
        [Fact]
        public async Task NPPESApiClient_ReturnsSingleResultByNPI()
        {
            // arrange
            // act
            var client = new NPPESApiClient();
            var result = await client.SearchAsync("1215226147");

            // assert
            Assert.NotNull(result);
            Assert.Equal(1, result.ResultCount);
            Assert.Equal(1, result.Results.Count);
            Assert.Null(result.Errors);
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public async Task NPPESApiClient_NoParametersReturnsError()
        {
            // arrange
            var request = new NPPESRequest();

            // act
            var client = new NPPESApiClient();
            var result = await client.SearchAsync(request);

            // assert
            Assert.NotNull(result);
            Assert.Equal(0, result.ResultCount);
            Assert.NotNull(result.Errors);
            Assert.Equal(1, result.Errors.Count);
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

#if NETCOREAPP2_1_OR_GREATER
        [Fact]
        public async Task NPPESApiClient_AcceptsHttpClient()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddHttpClient<NPPESApiClient>();

            using (var provider = serviceCollection.BuildServiceProvider())
            {
                var apiClient = provider.GetRequiredService<NPPESApiClient>();

                var response = await apiClient.SearchAsync("abcdefghi", default);
            }
        }
#endif
    }
}
