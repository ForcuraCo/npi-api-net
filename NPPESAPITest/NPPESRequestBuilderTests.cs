using System;
using System.Linq;
using Forcura.NPPES;
using Forcura.NPPES.Models;
using Xunit;

namespace NPPESAPITest
{
    public class NPPESRequestBuilderTests
    {
        [Fact]
        public void NPPESRequestBuilder_UpdatesValue()
        {
            // arrange
            var builder = new NPPESRequestBuilder();
            const string firstNumber = "1234567890";
            const string lastNumber = "0987654321";

            // act
            var request = builder
                .Number(firstNumber)
                .Number(lastNumber)
                .Build();

            // assert
            Assert.NotNull(request);
            Assert.Equal(lastNumber, request.Number);
        }

        [Fact]
        public void NPPESRequestBuilder_NoVersionUsesLatest()
        {
            var builder = new NPPESRequestBuilder();

            var request = builder.Build();
            var maxVersion = Enum.GetValues(typeof(NPPESVersion)).Cast<NPPESVersion>().Last();

            Assert.Equal(maxVersion, request.Version);
        }

        [Fact]
        public void NPPESRequestBuilder_VersionProvidedUsesSpecified()
        {
            var request = new NPPESRequestBuilder()
                .Version(NPPESVersion.v2_1)
                .Build();

            Assert.Equal(NPPESVersion.v2_1, request.Version);
        }
    }
}
