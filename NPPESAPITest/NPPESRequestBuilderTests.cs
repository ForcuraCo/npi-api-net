using Forcura.NPPES;
using Forcura.NPPES.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace NPPESAPITest
{
    [TestClass]
    public class NPPESRequestBuilderTests
    {
        [TestMethod]
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
            Assert.IsNotNull(request);
            Assert.AreEqual(lastNumber, request.Number);
        }

        [TestMethod]
        public void NPPESRequestBuilder_NoVersionUsesLatest()
        {
            var builder = new NPPESRequestBuilder();

            var request = builder.Build();
            var maxVersion = Enum.GetValues(typeof(NPPESVersion)).Cast<NPPESVersion>().Last();

            Assert.AreEqual(maxVersion, request.Version);
        }

        [TestMethod]
        public void NPPESRequestBuilder_VersionProvidedUsesSpecified()
        {
            var request = new NPPESRequestBuilder()
                .Version(NPPESVersion.v1_0)
                .Build();

            Assert.AreEqual(NPPESVersion.v1_0, request.Version);
        }
    }
}
