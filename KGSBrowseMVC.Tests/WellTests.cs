using KGSBrowseMVC.Models;
using Xunit;

namespace KGSBrowseMVC.Tests
{
    public class WellTests
    {
        [Fact]
        public void CanSerialiseLogHeader()
        {
            var sut = new LogHeader("Abc");
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(sut);
            Assert.Contains("Abc", json);
        }

        [Fact]
        public void CanSerialiseLogDoubleDatum()
        {
            var sut = new LogDoubleDatum( 1.0, 2.0 );
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(sut);
            Assert.Contains("Abc", json);
        }

        [Fact]
        public void CanSerialiseLinearDoubleLog()
        {
            var sut = new LinearDoubleLog("Abc",5);
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(sut);
            Assert.Contains("Abc", json);
        }
    }
}
