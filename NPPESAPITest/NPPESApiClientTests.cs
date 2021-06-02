using System.Net;
using System.Threading.Tasks;
using Forcura.NPPES;
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
            var result = await NPPESApiClient.SearchAsync("1215226147");

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
            var result = await NPPESApiClient.SearchAsync(request);

            // assert
            Assert.NotNull(result);
            Assert.Equal(0, result.ResultCount);
            Assert.NotNull(result.Errors);
            Assert.Equal(1, result.Errors.Count);
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }
    }
}
