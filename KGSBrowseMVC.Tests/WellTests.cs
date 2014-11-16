using System.IO;
using KGSBrowseMVC.Models;
using Newtonsoft.Json;
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
            Assert.Contains("{\"Depth\":1.0,\"Datum\":2.0}", json);
        }

        [Fact]
        public void CanSerialiseLinearDoubleLog()
        {
<<<<<<< HEAD
            var sut = new LinearDoubleLog("Abc",5);
=======
            var datum1 = new LogDoubleDatum ( 1.0, 2.0 );
            var datum2 = new LogDoubleDatum( -3.0, 0.4 );
            var datum3 = new LogDoubleDatum( 5.0, 6.123456 );
            LogDoubleDatum [] data = { datum1, datum2, datum3};
            var sut = new LinearDoubleLog("tester", data);
>>>>>>> 99319d69dc6b86f7da733dc8168d435487523d05
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(sut);
            Assert.Contains( 
                "{\"SampleCount\":3,\"DatumDepthPairs\":[{\"Depth\":1.0,\"Datum\":2.0},{\"Depth\":-3.0,\"Datum\":0.4},{\"Depth\":5.0,\"Datum\":6.123456}],\"Mnemonic\":\"tester\"}",
                json);
        }

        /// <summary>
        ///  Test serialisation of a LinearDoubleWell derived from a 2.6M LAS file.
        /// </summary>
        [Fact]
        public void CanSerialiseLinearDoubleWell1044781954Las()
        {
            const string testFileName = "../../Data.tests/1044781954.las";
            using (var fs = File.OpenRead(testFileName))
            using (var sr = new StreamReader(fs))
            {
                // Return for display
                var well = new Well(sr);
                var sut = well.WellToLinearDoubleWell();
                var json = JsonConvert.SerializeObject(sut);
                Assert.Contains(
                    "BIT",
                    json);
            }
        }

        /// <summary>
        ///  Test serialisation of a LinearDoubleWell derived from a 424K LAS file.
        /// </summary>
        [Fact]
        public void CanSerialiseLinearDoubleWell1044882097Las()
        {
            const string testFileName = "../../Data.tests/1044882097.las";
            using (var fs = File.OpenRead(testFileName))
            using (var sr = new StreamReader(fs))
            {
                // Return for display
                var well = new Well(sr);
                var sut = well.WellToLinearDoubleWell();
                var json = JsonConvert.SerializeObject(sut);
                Assert.Contains(
                    "DEPTH",
                    json);
            }
        }

        /// <summary>
        ///  Test serialisation of a LinearDoubleWell derived from a 10K LAS file.
        /// </summary>
        [Fact]
        public void CanSerialiseLinearDoubleWell1044781951_shortenedLas()
        {
            const string testFileName = "../../Data.tests/1044781951_shortened.las";
            using (var fs = File.OpenRead(testFileName))
            using (var sr = new StreamReader(fs))
            {
                // Return for display
                var well = new Well(sr);
                var sut = well.WellToLinearDoubleWell();
                var json = JsonConvert.SerializeObject(sut);
                Assert.Contains(
                    "DEPT",
                    json);
            }
        }
        [Fact]
        public void CanSerialiseX1()
        {
            var sut = new LogHeader("tester");
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(sut);
            Assert.Contains(
                "tester",
                json);
        }
        [Fact]
        public void CanSerialiseX2()
        {
            var sut = new LogHeader("tester");
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(sut);
            Assert.Contains(
                "tester",
                json);
        }
        [Fact]
        public void CanSerialiseX3()
        {
            var sut = new LogHeader("tester");
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(sut);
            Assert.Contains(
                "tester",
                json);
        }
    }
}
