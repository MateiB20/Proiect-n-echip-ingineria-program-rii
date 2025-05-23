using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using WindowsFormsApp1;

namespace WeatherProviderTests
{
    [TestClass]
    public class WttrProviderTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task GetCurrentAsync_NullLocation_ThrowsException()
        {
            var provider = new WttrProvider();
            await provider.GetCurrentAsync(null);
        }

        [TestMethod]
        public async Task GetCurrentAsync_ValidLocation_ReturnsWeather()
        {
            var provider = new WttrProvider();
            var result = await provider.GetCurrentAsync("Bucharest");
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.WeatherMetrics);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public async Task GetCurrentAsync_InvalidLocation_ThrowsException()
        {
            var provider = new WttrProvider();
            await provider.GetCurrentAsync("LocatieInexistentaTestOpenAi123");
        }
    }
}
