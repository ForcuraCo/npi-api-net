using System;
using Forcura.NPPES;
using Xunit;

namespace NPPESAPITest
{
    public class NPPESRequestTests
    {
        [Fact]
        public void NPPESRequest_BuildsAppropriateQueryString()
        {
            var request = new NPPESRequestBuilder()
                .Skip(1)
                .Number("1738389393")
                .AddressPurpose(null)
                .Build();

            var query = request.ToQuery();

            Assert.Contains("skip", query, StringComparison.OrdinalIgnoreCase);
            Assert.Contains("number", query, StringComparison.OrdinalIgnoreCase);
            Assert.DoesNotContain("address_purpose", query, StringComparison.OrdinalIgnoreCase);
        }
    }
}
