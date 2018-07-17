using System;
using System.Threading.Tasks;
using Forcura.NPPES;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NPPESAPITest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            var result = await NPPESApiClient.Search(new NPPESRequest
            {
                Number = "1215226147"
            });

            Console.WriteLine("");
        }
    }
}
