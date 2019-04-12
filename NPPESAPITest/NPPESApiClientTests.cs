using Forcura.NPPES;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Threading.Tasks;

namespace NPPESAPITest
{
    [TestClass]
    public class NPPESApiClientTests
    {
        [TestMethod]
        public async Task NPPESApiClient_ReturnsSingleResultByNPI()
        {
            // arrange
            // act
            var result = await NPPESApiClient.SearchAsync("1215226147");

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ResultCount);
            Assert.AreEqual(1, result.Results.Count);
            Assert.IsNull(result.Errors);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [TestMethod]
        public async Task NPPESApiClient_NoParametersReturnsError()
        {
            // arrange
            var request = new NPPESRequest();

            // act
            var result = await NPPESApiClient.SearchAsync(request);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.ResultCount);
            Assert.IsNotNull(result.Errors);
            Assert.AreEqual(1, result.Errors.Count);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }
    }
}
