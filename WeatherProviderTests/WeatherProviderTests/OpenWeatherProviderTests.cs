using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using WindowsFormsApp1;

namespace WeatherProviderTests
{
    [TestClass]
    public class OpenWeatherProviderTests
    {
        private static readonly ApiKeys _keys = ApiKeys.LoadFromConfig();
        private static readonly string _validApiKey = _keys.OpenWeather;
        private const string _invalidApiKey = "dummy";

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public async Task GetCurrentAsync_NullLocation_ThrowsException()
        {
            var provider = new OpenWeatherProvider(_validApiKey);
            await provider.GetCurrentAsync(null);
        }

        [TestMethod]
        public async Task GetCurrentAsync_ValidLocation_ValidKey_ReturnsWeather()
        {
            var provider = new OpenWeatherProvider(_validApiKey);
            var result = await provider.GetCurrentAsync("Bucharest");
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.WeatherMetrics);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public async Task GetCurrentAsync_ValidLocation_InvalidKey_ThrowsException()
        {
            var provider = new OpenWeatherProvider(_invalidApiKey);
            await provider.GetCurrentAsync("Bucharest");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public async Task GetCurrentAsync_InvalidLocation_ThrowsException()
        {
            var provider = new OpenWeatherProvider(_validApiKey);
            await provider.GetCurrentAsync("LocatieInexistentaTestOpenAi123");
        }
    }
}
