using Forcura.NPPES;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
